using System;
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
            
            if (Statics.JoinmeDotClickGames.Contains(gameInfo.Game) && serverInfo.JoinLinkWeb != null)
            {
                if (gameInfo.Game == Statics.Game.Bf2)
                {
                    presence.Buttons = new[]
                    {
                        new Button { Label = "Join", Url = serverInfo.JoinLinkWeb },
                        new Button { Label = "View server", Url = $"https://bf2.tv/servers/{serverInfo.Ip}:{serverInfo.Port}" }
                    };
                }
                else
                {
                    presence.Buttons = new[]
                    {
                        new Button { Label = "Join", Url = serverInfo.JoinLinkWeb }
                    };
                }
            }

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(presence);
        }
    }
}
