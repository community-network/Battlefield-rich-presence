using BattlefieldRichPresence.Resources;

namespace BattlefieldRichPresence.Structs
{
    internal class GameInfo
    {
        public Statics.Game Game { get; set; }
        public bool IsRunning { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
