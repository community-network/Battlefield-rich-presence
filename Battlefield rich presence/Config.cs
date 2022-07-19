using BattlefieldRichPresence.Properties;

namespace BattlefieldRichPresence
{
    internal class Config
    {
        public string PlayerName;

        public Config()
        {
            Refresh();
        }

        public void Refresh()
        {
            PlayerName = Settings.Default.playerName;
        }

        public void Update()
        {
            Settings.Default.playerName = PlayerName;
            Settings.Default.Save();
        }
    }
}
