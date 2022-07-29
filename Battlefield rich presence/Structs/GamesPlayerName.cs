using System.Reflection;
using System;

namespace BattlefieldRichPresence.Structs
{
    internal class GamesPlayerName
    {
        public string Bf1942 { get; set; }
        public string Bfvietnam { get; set; }
        public string Bf2142 { get; set; }
        public string Bfbc2 { get; set; }
        public string Bf3 { get; set; }
        public string Bf4 { get; set; }
        public string Bfh { get; set; }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName)?.GetValue(this); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }
    }
}
