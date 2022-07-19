namespace BattlefieldRichPresence.Structs
{
    internal class PlayerList
    {
        public int Index { get; set; }
        public int TeamId { get; set; }
        public byte Mark { get; set; }

        public int Rank { get; set; }
        public string Name { get; set; }
        public long PlayerId { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Score { get; set; }
    }
}
