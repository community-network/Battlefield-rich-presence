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

        public static ServerInfo getBf5CurrentServer(string playerName)
        {
            var payload = new
            {
                playerName = playerName
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
            return JsonConvert.DeserializeObject<ServerInfo>(responseContent);
        }
    }
}
