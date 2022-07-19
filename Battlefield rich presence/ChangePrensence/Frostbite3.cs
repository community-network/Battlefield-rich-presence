using System;
using BattlefieldRichPresence.Structs;
using DiscordRPC;

namespace BattlefieldRichPresence.ChangePrensence
{
    internal class Frostbite3
    {
        public static void Update(DiscordRpcClient client, DateTime startTime, GameInfo gameInfo, ServerInfo serverInfo)
        {
            ServerInfo extraInfo = Api.GetServerInfo(gameInfo.ShortName, serverInfo.Name);

            serverInfo.MaxPlayers = extraInfo.MaxPlayers;
            string state = serverInfo.GetPlayerCountString();
            state += $" - {extraInfo.MapLabel}";

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence
            {
                Details = $"{serverInfo.Name}",
                State = state,
                Timestamps = new Timestamps
                {
                    Start = startTime
                },
                Assets = new Assets
                {
                    LargeImageKey = gameInfo.ShortName,
                    LargeImageText = gameInfo.FullName,
                    SmallImageKey = "gt",
                    SmallImageText = "Battlefield rich presence"
                },
                Buttons = new[] //$"{textBox10.Text}"
                {
                        new Button { Label = "Join", Url = $"https://joinme.click/g/{gameInfo.ShortName}/{extraInfo.GameId}" },
                        new Button { Label = "View server", Url = $"https://gametools.network/servers/{gameInfo.ShortName}/gameid/{extraInfo.GameId}/pc" }
                }
            });
        }
    }
}
