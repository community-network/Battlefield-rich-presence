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
    }
}
