namespace Battlefield_rich_presence.GameReader
{
    internal class Offsets
    {
        public const long OFFSET_CLIENTGAMECONTEXT = 0x1437F7758;
        public const long OFFSET_GAMERENDERER = 0x1439E6D08;
        public const long OFFSET_OBFUSCATIONMGR = 0x14351D058;

        ////////////////////////////////////////////////////////////////////

        public const int ServerName_Offset = 0x3A1F3F8;
        public const int ServerID_Offset = 0x37FF1A0;
        public const int ServerTime_Offset = 0x3A31138;

        public const int ServerScore_Offset = 0x3A0FC40;

        public static int[] ServerName = new int[] { 0x30, 0x00 };
        public static int[] ServerID = new int[] { 0x418 };
        public static int[] ServerTime = new int[] { 0x20, 0x38, 0x58, 0x78 };

        public static int[] ServerScoreTeam = new int[] { 0x58, 0x18, 0x08 };
        public static int[] ServerScoreTeam1 = new int[] { 0x58, 0x18, 0x08, 0x2B0 };
        public static int[] ServerScoreTeam2 = new int[] { 0x58, 0x18, 0x08, 0x2B8 };
    }
}
