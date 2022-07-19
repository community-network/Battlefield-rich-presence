using BattlefieldRichPresence.Resources;

namespace BattlefieldRichPresence.Structs
{
    internal class ServerInfo
    {
        public string Guid { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public int NumPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string MapName { get; set; }
        public string MapLabel { get; set; }
        public string JoinLinkWeb { get; set; }
        public string GameId { get; set; }
        public string GetPlayerCountString()
        {
            string playerString = $"{NumPlayers}";
            if (MaxPlayers > 0)
            {
                playerString += $"/{MaxPlayers} players";
            }
            else if (NumPlayers == 1)
            {
                playerString += " player";
            }
            else
            {
                playerString += " players";
            }

            return playerString;
        }

        public string GetViewUrl(GameInfo gameInfo)
        {
            if (gameInfo.Game == Statics.Game.Bf2)
            {
                return $"https://bf2.tv/servers/{Ip}:{Port}";
            }
            else if (Statics.GameTrackerGames.Contains(gameInfo.Game))
            {
                return $"https://www.gametracker.com/server_info/{Ip}:{Port}/";
            }
            else if (Statics.GametoolsGames.Contains(gameInfo.Game))
            {
                return $"https://gametools.network/servers/{gameInfo.Game}/gameid/{Guid}/pc";
            }
            return null;
        }
    }
}
