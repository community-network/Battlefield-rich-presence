﻿namespace BattlefieldRichPresence.Structs
{
    internal class ServerInfo
    {
        public string Name { get; set; }
        public int NumPlayers { get; set; }
        public int MaxPlayers { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string JoinLinkWeb { get; set; }
    }
}