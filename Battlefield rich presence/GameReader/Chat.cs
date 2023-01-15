namespace BattlefieldRichPresence.GameReader
{
    internal class Chat
    {
        public const int OFFSET_CHAT_LAST_SENDER = 0x138;
        public const int OFFSET_CHAT_LAST_CONTENT = 0x140;

        /// <summary>
        /// Determine whether the Battlefield 1 chat box is open
        /// </summary>
        /// <returns></returns>
        public static bool GetChatIsOpen()
        {
            var address = Memory.Read<long>(Memory.GetBaseAddress() + 0x39F1E50);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x08);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x28);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x00);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x20);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x18);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x28);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x38);
            if (!Memory.IsValid(address))
                return false;
            address = Memory.Read<long>(address + 0x40);
            if (!Memory.IsValid(address))
                return false;

            return Memory.Read<byte>(address + 0x30) == 0x01;
        }

        /// <summary>
        /// Get the pointer of the chat box, return the pointer if successful, return 0 if failed
        /// </summary>
        /// <returns></returns>
        public static long ChatMessagePointer()
        {
            var address = Memory.Read<long>(Memory.GetBaseAddress() + 0x3A327E0);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x20);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x18);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x38);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x08);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x68);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0xB8);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x10);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x10);
            if (!Memory.IsValid(address))
                return 0;
            else
                return address;
        }

        /// <summary>
        /// Get the list of chat boxes, return a pointer if successful, return 0 if failed
        /// </summary>
        /// <returns></returns>
        public static long ChatListPointer()
        {
            var address = Memory.Read<long>(Memory.GetBaseAddress() + 0x39F1E50);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x70);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x20);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x18);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x28);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x28);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x38);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0xD8);
            if (!Memory.IsValid(address))
                return 0;
            address = Memory.Read<long>(address + 0x50);
            if (!Memory.IsValid(address))
                return 0;
            else
                return address;
        }

        public static string GetLastChatSender(out long pSender)
        {
            pSender = 0;
            if (ChatListPointer() != 0)
            {
                pSender = Memory.Read<long>(ChatListPointer() + OFFSET_CHAT_LAST_SENDER);
                return Memory.ReadString(Memory.Read<long>(pSender), 32);
            }
            return string.Empty;
        }

        public static string GetLastChatContent(out long pContent)
        {
            pContent = 0;
            if (ChatListPointer() != 0)
            {
                pContent = Memory.Read<long>(ChatListPointer() + OFFSET_CHAT_LAST_CONTENT);
                return Memory.ReadString(Memory.Read<long>(pContent), 256);
            }
            return string.Empty;
        }
    }
}
