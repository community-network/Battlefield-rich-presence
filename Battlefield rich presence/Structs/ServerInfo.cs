namespace BattlefieldRichPresence.Structs
{
    internal class ServerInfo
    {
        public string Name { get; set; }
        public int NumPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string MapName { get; set; }
        public string MapLabel { get; set; }
        public string JoinLinkWeb { get; set; }
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
    }
}
