namespace BattlefieldRichPresence.GameReader
{
    internal class Offsets
    {
        public const long OffsetClientgamecontext = 0x1437F7758;
        public const long OffsetGamerenderer = 0x1439E6D08;
        public const long OffsetObfuscationmgr = 0x14351D058;

        ////////////////////////////////////////////////////////////////////

        public const int ServerNameOffset = 0x3A1F3F8;
        public const int ServerIdOffset = 0x37FF1A0;
        public const int ServerTimeOffset = 0x3A31138;

        public const int ServerScoreOffset = 0x3A0FC40;

        public static int[] ServerName = { 0x30, 0x00 };
        public static int[] ServerId = { 0x418 };
        public static int[] ServerTime = { 0x20, 0x38, 0x58, 0x78 };

        public static int[] ServerScoreTeam = { 0x58, 0x18, 0x08 };
        public static int[] ServerScoreTeam1 = { 0x58, 0x18, 0x08, 0x2B0 };
        public static int[] ServerScoreTeam2 = { 0x58, 0x18, 0x08, 0x2B8 };
    }
}
