using System;
using System.Net.Http;
using BattlefieldRichPresence.Properties;
using BattlefieldRichPresence.Structs;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattlefieldRichPresence
{
    internal class Api
    {
        public static ServerInfo GetServerInfo(string gameName, string serverName)
        {
            var payload = new
            {
                name = serverName
            };
            string stringPayload = JsonConvert.SerializeObject(payload);
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = new HttpClient().PostAsync($"https://api.gametools.network/seedergame/{gameName}", httpContent).Result;
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ServerInfo>(responseContent);
            
        }

        public static ServerInfo OldTitleServerInfo(string unescapedPlayerName, string gameName)
        {
            string playerName = Uri.EscapeDataString(unescapedPlayerName);
            HttpResponseMessage httpResponse = new HttpClient().GetAsync($"https://api.bflist.io/{gameName}/v1/players/{playerName}/server").Result;
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ServerInfo> (responseContent);
        }

        public static ServerInfo GetBf5CurrentServer(string playerName)
        {
            var payload = new
            {
                playerName
            };
            string dataString = JsonConvert.SerializeObject(payload);
            string jwtData = Jwt.Create(dataString);
            string stringPayload = JsonConvert.SerializeObject(new { data = jwtData });
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage httpResponse = new HttpClient().PostAsync("https://api.gametools.network/currentserver/bf5", httpContent).Result;
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            if (responseContent == "{}")
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
