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
                Regex rgx = new Regex(Statics.SupportedGames, RegexOptions.IgnoreCase);
                Match match = rgx.Match(p.MainWindowTitle);
                if (match.Success)
                {
                    string[] names = rgx.GetGroupNames();
                    foreach (var name in names)
                    {
                        Group grp = match.Groups[name];
                        if (!Int32.TryParse(name, out _) && grp.Value != "")
                        {
                            return new GameInfo
                            {
                                IsRunning = true,
                                ShortName = name,
                                GameName = Statics.FullGameName[name]
                            };
                        }
                    }
                }
            }
            return new GameInfo
            {
                IsRunning = false,
                ShortName = "",
                GameName = ""
            };
        }
    }
}
