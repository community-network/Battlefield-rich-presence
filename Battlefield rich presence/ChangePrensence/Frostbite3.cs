using System;
using BattlefieldRichPresence.Structs;
using DiscordRPC;

namespace BattlefieldRichPresence.ChangePrensence
{
    internal class Frostbite3
    {
        public static void Update(DiscordRpcClient client, DateTime startTime, GameInfo gameInfo, ServerInfo serverInfo)
        {
            string gameId = Api.GetGameId(gameInfo.ShortName, serverInfo.Name);

            string state = $"{gameInfo.GameName} - {serverInfo.NumPlayers} players";
            if (serverInfo.MaxPlayers > 0)
            {
                state = $"{gameInfo.GameName} - {serverInfo.NumPlayers}/{serverInfo.MaxPlayers} players";
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
                    LargeImageText = gameInfo.GameName,
                    SmallImageKey = gameInfo.ShortName
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
