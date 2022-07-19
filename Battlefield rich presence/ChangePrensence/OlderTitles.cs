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

            RichPresence presence = new RichPresence
            {
                Details = $"{serverInfo.Name}",
                State = $"{gameInfo.GameName} - {serverInfo.NumPlayers}/{serverInfo.MaxPlayers} players",
                Timestamps = new Timestamps
                {
                    Start = startTime
                },
                Assets = new Assets
                {
                    LargeImageKey = gameInfo.ShortName,
                    LargeImageText = gameInfo.GameName,
                    SmallImageKey = gameInfo.ShortName
                }
            };
            
            if (Statics.JoinmeClickGames.Contains(gameInfo.ShortName) && serverInfo.JoinLinkWeb != null)
            {
                presence.Buttons = new[]
                {
                new Button { Label = "Join", Url = serverInfo.JoinLinkWeb }
                };
            }

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(presence);
        }
    }
}
