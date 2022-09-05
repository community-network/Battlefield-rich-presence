using System;
using System.Net;
using System.Web.Script.Serialization;
using BattlefieldRichPresence.Properties;
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

        public static ServerInfo getBf5CurrentServer(string playerName)
        {
            var post = new
            {
                playerName = playerName
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            string jwtData = Jwt.Create(dataString);
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string postData = json_serializer.Serialize(new { data = jwtData });
            string data = webClient.UploadString(new Uri("https://api.gametools.network/currentserver/bf5"), "POST", postData);
            if (data == "{}")
            {
                throw new Exception("not in a server");
            }
            return json_serializer.Deserialize<ServerInfo>(data);
        }

        public static void PostPlayerlist(GameReader.CurrentServerReader current_server_reader, Guid guid)
        {
            var post = new
            {
                guid = guid.ToString(),
                serverinfo = new
                {
                    name = current_server_reader.ServerName
                },
                teams = new
                {
                    team1 = current_server_reader.PlayerListsTeam1,
                    team2 = current_server_reader.PlayerListsTeam2,
                    scoreteam1 = current_server_reader.ServerScoreTeam1,
                    scoreteam2 = current_server_reader.ServerScoreTeam2
                }
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            string jwtData = Jwt.Create(dataString, guid.ToString());
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string postData = json_serializer.Serialize(new { data = jwtData });
            webClient.UploadString(new Uri("https://api.gametools.network/seederplayerlist/bf1"), "POST", postData);
        }
    }
}
