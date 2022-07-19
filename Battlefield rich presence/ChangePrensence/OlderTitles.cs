using System;
using System.Collections.Generic;
using BattlefieldRichPresence.Resources;
using BattlefieldRichPresence.Structs;
using DiscordRPC;

namespace BattlefieldRichPresence.ChangePrensence
{
    internal class OlderTitles
    {
        public static void Update(DiscordRpcClient client, DateTime startTime, GameInfo gameInfo, ServerInfo serverInfo)
        {
            string mapName;
            switch (gameInfo.Game)
            {
                case Statics.Game.Bf1942:
                case Statics.Game.Bfvietnam:
                case Statics.Game.Bf2:
                case Statics.Game.Bf2142:
                    mapName = serverInfo.MapName;
                    break;
                default:
                    mapName = serverInfo.MapLabel;
                    break;
            }
            
            RichPresence presence = new RichPresence
            {
                Details = $"{serverInfo.Name}",
                State = $"{serverInfo.GetPlayerCountString()} - {mapName}",
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
                }
            };

            List<Button> buttons = new List<Button>();

            if (Statics.JoinmeDotClickGames.Contains(gameInfo.Game) && serverInfo.JoinLinkWeb != null)
            {
                buttons.Add(new Button { Label = "Join", Url = serverInfo.JoinLinkWeb });
            }

            string joinUrl = serverInfo.GetJoinUrl(gameInfo);
            if (joinUrl != null)
            {
                buttons.Add(new Button { Label = "View server", Url = joinUrl });
            }
            
            if (buttons.Count > 0)
            {
                presence.Buttons = buttons.ToArray();
            }

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(presence);
        }
    }
}
