using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battlefield_rich_presence
{
    internal class Config
    {
        public string playerName;

        public Config()
        {
            Refresh();
        }

        public void Refresh()
        {
            playerName = Properties.Settings.Default.playerName;
        }

        public void Update()
        {
            Properties.Settings.Default.playerName = playerName;
            Properties.Settings.Default.Save();
        }
    }
}
