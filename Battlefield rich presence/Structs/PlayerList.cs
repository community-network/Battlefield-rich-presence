using System.Collections.Generic;

namespace BattlefieldRichPresence.Structs
{
    internal class PlayerList
    {
        public int index { get; set; }
        public int teamId { get; set; }
        public byte mark { get; set; }
        public Platoon platoon { get; set; }
        public int squad_id { get; set; }
        public string squad_name { get; set; }
        public int rank { get; set; }
        public string name { get; set; }
        public long player_id { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int score { get; set; }
        public Dictionary<string, string> player_class { get; set; }
        public byte Spectator { get; set; }
        public Dictionary<string, string> vehicle { get; set; }
        public List<Dictionary<string, string>> weapons { get; set; }
    }

    internal class Platoon
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }
}