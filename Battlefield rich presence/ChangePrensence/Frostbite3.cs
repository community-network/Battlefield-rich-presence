using System;
using BattlefieldRichPresence.Resources;
using BattlefieldRichPresence.Structs;
using DiscordRPC;

namespace BattlefieldRichPresence.ChangePrensence
{
    internal class Frostbite3
    {
        public static void Update(DiscordRpcClient client, DateTime startTime, GameInfo gameInfo, ServerInfo serverInfo)
        {
            string gameId = Api.GetGameId(gameInfo.ShortName, serverInfo.Name);

            string state = serverInfo.GetPlayerCountString();
            if (gameInfo.Game == Statics.Game.Bf4)
            {
                state += $" - {serverInfo.MapLabel}";
            }

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
                        new Button { Label = "Join", Url = $"https://joinme.click/g/{gameInfo.ShortName}/{gameId}" },
                        new Button { Label = "View server", Url = $"https://gametools.network/servers/{gameInfo.ShortName}/gameid/{gameId}/pc" }
                }
            });
        }
    }
}
