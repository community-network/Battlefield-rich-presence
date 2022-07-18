using System;
using Battlefield_rich_presence.Resources;
using Battlefield_rich_presence.Structs;
using DiscordRPC;

namespace Battlefield_rich_presence.ChangePrensence
{
    internal class OlderTitles
    {
        public static void Update(DiscordRpcClient client, DateTime start_time, GameInfo game_info, ServerInfo server_info)
        {

            RichPresence presence = new RichPresence()
            {
                Details = $"{server_info.name}",
                State = $"{game_info.game_name} - {server_info.numPlayers}/{server_info.maxPlayers} players",
                Timestamps = new Timestamps()
                {
                    Start = start_time
                },
                Assets = new Assets()
                {
                    LargeImageKey = game_info.short_name,
                    LargeImageText = game_info.game_name,
                    SmallImageKey = game_info.short_name
                }
            };
            
            if (Statics.joinme_click_games.Contains(game_info.short_name))
            {
                presence.Buttons = new Button[]
                {
                new Button() { Label = "Join", Url = $"https://joinme.click/g/{game_info.short_name}/{server_info.ip}:{server_info.port}" }
                };
            }

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(presence);
        }
    }
}
