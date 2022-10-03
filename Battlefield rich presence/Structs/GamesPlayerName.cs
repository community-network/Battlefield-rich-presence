namespace BattlefieldRichPresence.Structs
{
    internal class GamesPlayerName
    {
        public string Bfbc2 { get; set; }
        public string Bf3 { get; set; }
        public string Bf4 { get; set; }
        public string Bfh { get; set; }
        public string Bf5 { get; set; }

        public object this[string propertyName]
        {
            get => GetType().GetProperty(propertyName)?.GetValue(this);
            set => GetType().GetProperty(propertyName)?.SetValue(this, value, null);
        }
    }
}
