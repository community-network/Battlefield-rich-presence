using System;
using System.Collections.Generic;
using BattlefieldRichPresence.Structs;
using DiscordRPC;

namespace BattlefieldRichPresence.ChangePrensence
{
    internal class Frostbite3
    {
        public static void Update(DiscordRpcClient client, DateTime startTime, GameInfo gameInfo, ServerInfo serverInfo)
        {
            ServerInfo extraInfo = serverInfo;

            if (gameInfo.Game != Resources.Statics.Game.Bf5)
            {
                extraInfo = Api.GetServerInfo(gameInfo.ShortName, serverInfo.Name);
            }

            serverInfo.MaxPlayers = extraInfo.MaxPlayers;
            string state = serverInfo.GetPlayerCountString();
            state += $" - {extraInfo.MapLabel}";

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            RichPresence presence = new RichPresence
            {
                Details = $"{serverInfo.Name}",
                State = state,
                Timestamps = new Timestamps
                {
                    Start = startTime
                },
                Assets = new Assets
                {
                    LargeImageKey = gameInfo.ShortName.ToLower(),
                    LargeImageText = gameInfo.FullName,
                    SmallImageKey = "gt",
                    SmallImageText = "Battlefield rich presence"
                }
            };

            List<Button> buttons = new List<Button>();

            String apiName = gameInfo.ShortName.ToLower();

            if (gameInfo.Game != Resources.Statics.Game.Bf5)
            {
                buttons.Add(new Button { Label = "Join", Url = $"https://joinme.click/g/{gameInfo.ShortName.ToLower()}/{extraInfo.GameId}" });
            } else
            {
                apiName = "bfv";
            }

            buttons.Add(new Button { Label = "View server", Url = $"https://gametools.network/servers/{apiName}/gameid/{extraInfo.GameId}/pc" });

            presence.Buttons = buttons.ToArray();
            client.SetPresence(presence);
        }
    }
}
