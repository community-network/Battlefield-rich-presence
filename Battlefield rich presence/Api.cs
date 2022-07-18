using System;
using System.Net;
using System.Web.Script.Serialization;

namespace Battlefield_rich_presence
{
    internal class Api
    {
        public static string GetGameId(string game_name, string server_name)
        {
            var post = new
            {
                name = server_name
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
            return webClient.UploadString(new Uri($"https://api.gametools.network/seedergameid/{game_name}"), "POST", dataString).Replace("\"", "");
        }

        public static Structs.ServerInfo OldTitleServerInfo(Config config, string game_name)
        {
            WebClient webClient = new WebClient();
            string data = webClient.DownloadString(new Uri($"https://api.bflist.io/{game_name}/v1/players/{Uri.EscapeDataString(config.playerName)}/server"));
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<Structs.ServerInfo>(data);
        }
    }
}
