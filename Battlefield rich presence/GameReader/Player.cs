using System;

namespace BattlefieldRichPresence.GameReader
{
    internal class Player
    {

        // Decrypt the player pointer
        public static long EncryptedPlayerMgr_GetPlayer(long encryptedPlayerMgr, int id)
        {
            long xorValue1 = Memory.Read<long>(encryptedPlayerMgr + 0x20) ^ Memory.Read<long>(encryptedPlayerMgr + 0x8);
            long xorValue2 = xorValue1 ^ Memory.Read<long>(encryptedPlayerMgr + 0x10);
            if (!Memory.IsValid(xorValue2))
            {
                return 0;
            }

            return xorValue1 ^ Memory.Read<long>(xorValue2 + 0x8 * id);
        }

        // Read other player pointers
        public static long GetPlayerById(int id)
        {
            long pClientGameContext = Memory.Read<long>(Offsets.OffsetClientgamecontext);
            if (!Memory.IsValid(pClientGameContext))
            {
                return 0;
            }

            long pPlayerManager = Memory.Read<long>(pClientGameContext + 0x68);
            if (!Memory.IsValid(pPlayerManager))
            {
                return 0;
            }

            long pObfuscationMgr = Memory.Read<long>(Offsets.OffsetObfuscationmgr);
            if (!Memory.IsValid(pObfuscationMgr))
            {
                return 0;
            }

            long playerListXorValue = Memory.Read<long>(pPlayerManager + 0xF8);
            long playerListKey = playerListXorValue ^ Memory.Read<long>(pObfuscationMgr + 0x70);

            long mpBucketArray = Memory.Read<long>(pObfuscationMgr + 0x10);

            // These two are read with Int32
            int mnBucketCount = Memory.Read<int>(pObfuscationMgr + 0x18);
            if (mnBucketCount == 0)
            {
                return 0;
            }
            //int mnElementCount = RPM.ReadMemory<int>(pObfuscationMgr + 0x1C);

            int startCount = (int)playerListKey % mnBucketCount;

            // node
            long mpBucketArrayStartCount = Memory.Read<long>(mpBucketArray + Convert.ToInt64(startCount * 8));
            long nodeFirst = Memory.Read<long>(mpBucketArrayStartCount);
            long nodeSecond = Memory.Read<long>(mpBucketArrayStartCount + 0x8);
            long nodeMpNext = Memory.Read<long>(mpBucketArrayStartCount + 0x10);

            while (playerListKey != nodeFirst)
            {
                mpBucketArrayStartCount = nodeMpNext;

                nodeFirst = Memory.Read<long>(mpBucketArrayStartCount);
                nodeSecond = Memory.Read<long>(mpBucketArrayStartCount + 0x8);
                nodeMpNext = Memory.Read<long>(mpBucketArrayStartCount + 0x10);
            }

            long encryptedPlayerMgr = nodeSecond;
            //long MaxPlayerCount = RPM.ReadMemory<long>(EncryptedPlayerMgr + 0x18);

            return EncryptedPlayerMgr_GetPlayer(encryptedPlayerMgr, id);
        }

        // read own pointer
        public static long GetLocalPlayer()
        {
            long pClientGameContext = Memory.Read<long>(Offsets.OffsetClientgamecontext);
            if (!Memory.IsValid(pClientGameContext))
            {
                return 0;
            }

            long pPlayerManager = Memory.Read<long>(pClientGameContext + 0x68);
            if (!Memory.IsValid(pPlayerManager))
            {
                return 0;
            }

            long pObfuscationMgr = Memory.Read<long>(Offsets.OffsetObfuscationmgr);
            if (!Memory.IsValid(pObfuscationMgr))
            {
                return 0;
            }

            long localPlayerListXorValue = Memory.Read<long>(pPlayerManager + 0xF0);
            long localPlayerListKey = localPlayerListXorValue ^ Memory.Read<long>(pObfuscationMgr + 0x70);

            long mpBucketArray = Memory.Read<long>(pObfuscationMgr + 0x10);

            int mnBucketCount = Memory.Read<int>(pObfuscationMgr + 0x18);
            if (mnBucketCount == 0)
            {
                return 0;
            }
            //int mnElementCount = RPM.ReadMemory<int>(pObfuscationMgr + 0x1C);

            int startCount = (int)localPlayerListKey % mnBucketCount;

            // node
            long mpBucketArrayStartCount = Memory.Read<long>(mpBucketArray + Convert.ToInt64(startCount * 8));
            long nodeFirst = Memory.Read<long>(mpBucketArrayStartCount);
            long nodeSecond = Memory.Read<long>(mpBucketArrayStartCount + 0x8);
            long nodeMpNext = Memory.Read<long>(mpBucketArrayStartCount + 0x10);

            while (localPlayerListKey != nodeFirst)
            {
                mpBucketArrayStartCount = nodeMpNext;

                nodeFirst = Memory.Read<long>(mpBucketArrayStartCount);
                nodeSecond = Memory.Read<long>(mpBucketArrayStartCount + 0x8);
                nodeMpNext = Memory.Read<long>(mpBucketArrayStartCount + 0x10);
            }

            long encryptedPlayerMgr = nodeSecond;
            //long MaxPlayerCount = RPM.ReadMemory<long>(EncryptedPlayerMgr + 0x18);

            return EncryptedPlayerMgr_GetPlayer(encryptedPlayerMgr, 0);
        }
    }
}
