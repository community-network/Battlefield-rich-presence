using BattlefieldRichPresence.Properties;

namespace BattlefieldRichPresence
{
    internal class Config
    {
        public Structs.GamesPlayerName PlayerNames;
        public bool GatherServerInfo;
        public Guid Guid;

        public Config()
        {
            if (Settings.Default.Guid == new Guid())
            {
                Guid = Guid.NewGuid();
                Settings.Default.Guid = Guid;
                Settings.Default.Save();
            }

            Refresh();
        }

        public void Refresh()
        {
            Guid = Settings.Default.Guid;
            GatherServerInfo = Settings.Default.GatherServerInfo;
            PlayerNames = new Structs.GamesPlayerName()
            {
                Bfbc2 = Settings.Default.bfbc2,
                Bf3 = Settings.Default.bf3,
                Bf4 = Settings.Default.bf4, 
                Bfh = Settings.Default.bfh,
                Bf5 = Settings.Default.bf5
            };
        }

        public void Update()
        {
            Settings.Default.GatherServerInfo = GatherServerInfo;
            Settings.Default.Guid = Guid;

            Settings.Default.bfbc2 = PlayerNames.Bfbc2;
            Settings.Default.bf3 = PlayerNames.Bf3;
            Settings.Default.bf4 = PlayerNames.Bf4;
            Settings.Default.bfh = PlayerNames.Bfh;
            Settings.Default.bf5 = PlayerNames.Bf5;
            Settings.Default.Save();
        }
    }
}
