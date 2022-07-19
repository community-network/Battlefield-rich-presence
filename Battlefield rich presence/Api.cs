using System;
using System.Net;
using System.Web.Script.Serialization;
using BattlefieldRichPresence.Structs;

namespace BattlefieldRichPresence
{
    internal class Api
    {
        public static string GetGameId(string gameName, string serverName)
        {
            var post = new
            {
                name = serverName
            };
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            string dataString = jsonSerializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            return webClient.UploadString(new Uri($"https://api.gametools.network/seedergameid/{gameName}"), "POST", dataString).Replace("\"", "");
        }

        public static ServerInfo OldTitleServerInfo(Config config, string gameName)
        {
            WebClient webClient = new WebClient();
            string data = webClient.DownloadString(new Uri($"https://api.bflist.io/{gameName}/v1/players/{Uri.EscapeDataString(config.PlayerName)}/server"));
            JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
            return jsonSerializer.Deserialize<ServerInfo>(data);
        }
    }
}
