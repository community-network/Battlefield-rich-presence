using System;
using System.Collections.Generic;
using System.Net.Http;
using BattlefieldRichPresence.Structs;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
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
            httpResponse.EnsureSuccessStatusCode();
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ServerInfo>(responseContent);
            
        }

        public static ServerInfo OldTitleServerInfo(string unescapedPlayerName, string gameName)
        {
            string playerName = Uri.EscapeDataString(unescapedPlayerName);
            HttpResponseMessage httpResponse = new HttpClient().GetAsync($"https://api.bflist.io/{gameName}/v1/players/{playerName}/server").Result;

            // bflist returns a 404 response if the player is not currently playing on a (known) server
            // Throw an exception in that case to avoid returning empty ServerInfo
            httpResponse.EnsureSuccessStatusCode();
            
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ServerInfo> (responseContent);
        }

        public static ServerInfo GetBfbc2ServerInfo(string unescapedPlayerName)
        {
            var query = new Dictionary<string, string>()
            {
                ["name"] = Uri.EscapeDataString(unescapedPlayerName),
                ["platform"] = "pc"
            };
            var uri = QueryHelpers.AddQueryString("https://api.gametools.network/bfbc2/currentserver/", query);
            HttpResponseMessage httpResponse = new HttpClient().GetAsync(uri).Result;
            httpResponse.EnsureSuccessStatusCode();
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ServerInfo> (responseContent);
        }

        public static ServerInfo GetCurrentServer(string playerName, Resources.Statics.Game game_name)
        {
            var payload = new
            {
                playerName
            };
            string dataString = JsonConvert.SerializeObject(payload);
            string jwtData = Jwt.Create(dataString);
            string stringPayload = JsonConvert.SerializeObject(new { data = jwtData });
            StringContent httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var url = $"https://api.gametools.network/currentserver/{Resources.Statics.ShortGameName[game_name].ToLower()}";
            HttpResponseMessage httpResponse = new HttpClient().PostAsync(url, httpContent).Result;
            httpResponse.EnsureSuccessStatusCode();
            string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
            if (responseContent == "{}")
            {
                throw new Exception("not in a server");
            }
            return JsonConvert.DeserializeObject<ServerInfo>(responseContent);
        }
    }
}
