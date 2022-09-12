using System;
using System.Net;
using System.Web.Script.Serialization;
using BattlefieldRichPresence.Structs;

namespace BattlefieldRichPresence
{
    internal class Api
    {
        public static ServerInfo GetServerInfo(string gameName, string serverName)
        {
            var post = new
            {
                name = serverName
            };
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string dataString = jsonSerializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            string data = webClient.UploadString(new Uri($"https://api.gametools.network/seedergame/{gameName}"), "POST", dataString);
            return jsonSerializer.Deserialize<ServerInfo>(data);
        }

        public static ServerInfo OldTitleServerInfo(string unescapedPlayerName, string gameName)
        {
            WebClient webClient = new WebClient();
            string playerName = Uri.EscapeDataString(unescapedPlayerName);
            string data = webClient.DownloadString(new Uri($"https://api.bflist.io/{gameName}/v1/players/{playerName}/server"));
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Deserialize<ServerInfo>(data);
        }

        public static ServerInfo GetBf5CurrentServer(string playerName)
        {
            var post = new
            {
                playerName
            };
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string dataString = jsonSerializer.Serialize(post);
            WebClient webClient = new WebClient();
            string jwtData = Jwt.Create(dataString);
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string postData = jsonSerializer.Serialize(new { data = jwtData });
            string data = webClient.UploadString(new Uri("https://api.gametools.network/currentserver/bf5"), "POST", postData);
            if (data == "{}")
            {
                throw new Exception("not in a server");
            }
            return jsonSerializer.Deserialize<ServerInfo>(data);
        }

        public static void PostPlayerlist(GameReader.CurrentServerReader currentServerReader, Guid guid)
        {
            var post = new
            {
                guid = guid.ToString(),
                serverinfo = new
                {
                    name = currentServerReader.ServerName,
                    gameId = currentServerReader.GameId
                },
                teams = new
                {
                    team1 = currentServerReader.PlayerListsTeam1,
                    team2 = currentServerReader.PlayerListsTeam2,
                    scoreteam1 = currentServerReader.ServerScoreTeam1,
                    scoreteam2 = currentServerReader.ServerScoreTeam2,
                    scoreteam1FromKills = currentServerReader.Team1ScoreFromKill,
                    scoreteam2FromKills = currentServerReader.Team2ScoreFromKill,
                    scoreteam1FromFlags = currentServerReader.Team1ScoreFromFlags,
                    scoreteam2FromFlags = currentServerReader.Team2ScoreFromFlags,
                }
            };
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string dataString = jsonSerializer.Serialize(post);
            WebClient webClient = new WebClient();
            string jwtData = Jwt.Create(dataString, guid.ToString());
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string postData = jsonSerializer.Serialize(new { data = jwtData });
            webClient.UploadString(new Uri("https://api.gametools.network/seederplayerlist/bf1"), "POST", postData);
        }
    }
}
