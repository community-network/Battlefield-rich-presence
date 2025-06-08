using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using BattlefieldRichPresence.Resources;
using BattlefieldRichPresence.Structs;

namespace BattlefieldRichPresence
{
    internal class Game
    {
        public static GameInfo IsRunning()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                // Avoid running regex for processes without a main window/an empty title
                if (p.MainWindowHandle == IntPtr.Zero || p.MainWindowTitle == string.Empty)
                {
                    continue;
                }
                
                Regex rgx = new Regex(Statics.SupportedGamesRegex, RegexOptions.IgnoreCase);
                Match match = rgx.Match(p.MainWindowTitle);
                if (match.Success)
                {
                    string[] names = rgx.GetGroupNames();
                    foreach (var name in names)
                    {
                        Group grp = match.Groups[name];
                        if (!Int32.TryParse(name, out _) && grp.Value != "")
                        {
                            Statics.Game game = (Statics.Game)Enum.Parse(typeof(Statics.Game), name);
                            return new GameInfo
                            {
                                Game = game,
                                IsRunning = true,
                                ShortName = Statics.ShortGameName[game],
                                FullName = Statics.FullGameName[game]
                            };
                        }
                    }
                }
            }
            return new GameInfo
            {
                IsRunning = false,
                ShortName = "",
                FullName = ""
            };
        }
    }
}
