using System;
using System.Net;
using System.Web.Script.Serialization;

namespace Battlefield_rich_presence
{
    internal class Api
    {
        public static string GetGameId(GameReader.CurrentServerReader current_server_reader)
        {
            var post = new
            {
                name = current_server_reader.ServerName
            };
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            string dataString = json_serializer.Serialize(post);
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";

            return webClient.UploadString(new Uri("https://api.gametools.network/seedergameid/bf1"), "POST", dataString).Replace("\"", "");
        }
    }
}
