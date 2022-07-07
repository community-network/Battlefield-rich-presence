using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlefield_rich_presence.Structs
{
    internal class PlayerList
    {
        public int index { get; set; }
        public int teamId { get; set; }
        public byte mark { get; set; }

        public int rank { get; set; }
        public string name { get; set; }
        public long player_id { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int score { get; set; }
    }
}
