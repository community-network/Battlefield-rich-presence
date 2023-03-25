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
            RichPresence presence = new RichPresence
            {
                Details = $"{serverInfo.Name}",
                State = $"{serverInfo.GetPlayerCountString()} - {serverInfo.MapName}",
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

            if (Statics.JoinmeDotClickGames.Contains(gameInfo.Game) && serverInfo.JoinLinkWeb != null)
            {
                buttons.Add(new Button { Label = "Join", Url = serverInfo.JoinLinkWeb });
            }

            string viewUrl = serverInfo.GetViewUrl(gameInfo);
            if (viewUrl != null)
            {
                buttons.Add(new Button { Label = "View server", Url = viewUrl });
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
