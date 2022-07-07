using System;

namespace Battlefield_rich_presence.GameReader
{
    internal class Player
    {

        // Decrypt the player pointer
        public static long EncryptedPlayerMgr_GetPlayer(long EncryptedPlayerMgr, int id)
        {
            long XorValue1 = Memory.Read<long>(EncryptedPlayerMgr + 0x20) ^ Memory.Read<long>(EncryptedPlayerMgr + 0x8);
            long XorValue2 = XorValue1 ^ Memory.Read<long>(EncryptedPlayerMgr + 0x10);
            if (!Memory.IsValid(XorValue2))
            {
                return 0;
            }

            return XorValue1 ^ Memory.Read<long>(XorValue2 + 0x8 * id);
        }

        // Read other player pointers
        public static long GetPlayerById(int id)
        {
            long pClientGameContext = Memory.Read<long>(Offsets.OFFSET_CLIENTGAMECONTEXT);
            if (!Memory.IsValid(pClientGameContext))
            {
                return 0;
            }

            long pPlayerManager = Memory.Read<long>(pClientGameContext + 0x68);
            if (!Memory.IsValid(pPlayerManager))
            {
                return 0;
            }

            long pObfuscationMgr = Memory.Read<long>(Offsets.OFFSET_OBFUSCATIONMGR);
            if (!Memory.IsValid(pObfuscationMgr))
            {
                return 0;
            }

            long PlayerListXorValue = Memory.Read<long>(pPlayerManager + 0xF8);
            long PlayerListKey = PlayerListXorValue ^ Memory.Read<long>(pObfuscationMgr + 0x70);

            long mpBucketArray = Memory.Read<long>(pObfuscationMgr + 0x10);

            // These two are read with Int32
            int mnBucketCount = Memory.Read<int>(pObfuscationMgr + 0x18);
            if (mnBucketCount == 0)
            {
                return 0;
            }
            //int mnElementCount = RPM.ReadMemory<int>(pObfuscationMgr + 0x1C);

            int startCount = (int)PlayerListKey % mnBucketCount;

            // node
            long mpBucketArray_startCount = Memory.Read<long>(mpBucketArray + Convert.ToInt64(startCount * 8));
            long node_first = Memory.Read<long>(mpBucketArray_startCount);
            long node_second = Memory.Read<long>(mpBucketArray_startCount + 0x8);
            long node_mpNext = Memory.Read<long>(mpBucketArray_startCount + 0x10);

            while (PlayerListKey != node_first)
            {
                mpBucketArray_startCount = node_mpNext;

                node_first = Memory.Read<long>(mpBucketArray_startCount);
                node_second = Memory.Read<long>(mpBucketArray_startCount + 0x8);
                node_mpNext = Memory.Read<long>(mpBucketArray_startCount + 0x10);
            }

            long EncryptedPlayerMgr = node_second;
            //long MaxPlayerCount = RPM.ReadMemory<long>(EncryptedPlayerMgr + 0x18);

            return EncryptedPlayerMgr_GetPlayer(EncryptedPlayerMgr, id);
        }

        // read own pointer
        public static long GetLocalPlayer()
        {
            long pClientGameContext = Memory.Read<long>(Offsets.OFFSET_CLIENTGAMECONTEXT);
            if (!Memory.IsValid(pClientGameContext))
            {
                return 0;
            }

            long pPlayerManager = Memory.Read<long>(pClientGameContext + 0x68);
            if (!Memory.IsValid(pPlayerManager))
            {
                return 0;
            }

            long pObfuscationMgr = Memory.Read<long>(Offsets.OFFSET_OBFUSCATIONMGR);
            if (!Memory.IsValid(pObfuscationMgr))
            {
                return 0;
            }

            long LocalPlayerListXorValue = Memory.Read<long>(pPlayerManager + 0xF0);
            long LocalPlayerListKey = LocalPlayerListXorValue ^ Memory.Read<long>(pObfuscationMgr + 0x70);

            long mpBucketArray = Memory.Read<long>(pObfuscationMgr + 0x10);

            int mnBucketCount = Memory.Read<int>(pObfuscationMgr + 0x18);
            if (mnBucketCount == 0)
            {
                return 0;
            }
            //int mnElementCount = RPM.ReadMemory<int>(pObfuscationMgr + 0x1C);

            int startCount = (int)LocalPlayerListKey % mnBucketCount;

            // node
            long mpBucketArray_startCount = Memory.Read<long>(mpBucketArray + Convert.ToInt64(startCount * 8));
            long node_first = Memory.Read<long>(mpBucketArray_startCount);
            long node_second = Memory.Read<long>(mpBucketArray_startCount + 0x8);
            long node_mpNext = Memory.Read<long>(mpBucketArray_startCount + 0x10);

            while (LocalPlayerListKey != node_first)
            {
                mpBucketArray_startCount = node_mpNext;

                node_first = Memory.Read<long>(mpBucketArray_startCount);
                node_second = Memory.Read<long>(mpBucketArray_startCount + 0x8);
                node_mpNext = Memory.Read<long>(mpBucketArray_startCount + 0x10);
            }

            long EncryptedPlayerMgr = node_second;
            //long MaxPlayerCount = RPM.ReadMemory<long>(EncryptedPlayerMgr + 0x18);

            return EncryptedPlayerMgr_GetPlayer(EncryptedPlayerMgr, 0);
        }
    }
}
