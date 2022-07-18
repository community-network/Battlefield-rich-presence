using System;
using Battlefield_rich_presence.Structs;
using DiscordRPC;

namespace Battlefield_rich_presence.ChangePrensence
{
    internal class Frostbite3
    {
        public static void Update(DiscordRpcClient client, DateTime start_time, GameInfo game_info, ServerInfo server_info)
        {
            string game_id = Api.GetGameId(game_info.short_name, server_info.name);

            string state = $"{game_info.game_name} - {server_info.numPlayers} players";
            if (server_info.maxPlayers > 0)
            {
                state = $"{game_info.game_name} - {server_info.numPlayers}/{server_info.maxPlayers} players";
            }

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = $"{server_info.name}",
                State = state,
                Timestamps = new Timestamps()
                {
                    Start = start_time
                },
                Assets = new Assets()
                {
                    LargeImageKey = game_info.short_name,
                    LargeImageText = game_info.game_name,
                    SmallImageKey = game_info.short_name
                },
                Buttons = new Button[] //$"{textBox10.Text}"
                {
                        new Button() { Label = "Join", Url = $"https://joinme.click/g/{game_info.short_name}/{game_id}" },
                        new Button() { Label = "View server", Url = $"https://gametools.network/servers/{game_info.short_name}/gameid/{game_id}/pc" }
                }
            });
        }
    }
}
