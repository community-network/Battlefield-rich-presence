using BattlefieldRichPresence.Properties;
using BattlefieldRichPresence.Resources;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace BattlefieldRichPresence
{
    internal class Config
    {
        public Structs.GamesPlayerName PlayerNames;

        public Config()
        {
            Refresh();
        }

        public void Refresh()
        {
            PlayerNames = new Structs.GamesPlayerName()
            {
                Bf1942 = Settings.Default.bf1942,
                Bfvietnam = Settings.Default.bfvietnam,
                Bf2142 = Settings.Default.bf2142,
                Bfbc2 = Settings.Default.bfbc2,
                Bf3 = Settings.Default.bf3,
                Bf4 = Settings.Default.bf4, 
                Bfh = Settings.Default.bfh,
                Bf5 = Settings.Default.bf5
            };
        }

        public void Update()
        {
            Settings.Default.bf1942 = PlayerNames.Bf1942;
            Settings.Default.bfvietnam = PlayerNames.Bfvietnam;
            Settings.Default.bf2142 = PlayerNames.Bf2142;
            Settings.Default.bfbc2 = PlayerNames.Bfbc2;
            Settings.Default.bf3 = PlayerNames.Bf3;
            Settings.Default.bf4 = PlayerNames.Bf4;
            Settings.Default.bfh = PlayerNames.Bfh;
            Settings.Default.bf5 = PlayerNames.Bf5;
            Settings.Default.Save();
        }
    }
}
