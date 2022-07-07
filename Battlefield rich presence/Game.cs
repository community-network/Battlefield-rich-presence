using System;
using System.Runtime.InteropServices;

namespace Battlefield_rich_presence
{
    internal class Game
    {
        public static bool IsRunning()
        {
            IntPtr window_handle = FindWindow("Battlefield™ 1", null);
            return window_handle != IntPtr.Zero;
        }

        // For Windows Mobile, replace user32.dll with coredll.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    }
}
