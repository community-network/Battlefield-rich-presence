using Battlefield_rich_presence.Resources;
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Battlefield_rich_presence
{
    internal class Game
    {

        public static Structs.GameInfo IsRunning()
        {
            Process[] process_collection = Process.GetProcesses();
            foreach (Process p in process_collection)
            {
                Regex rgx = new Regex(Statics.supported_games, RegexOptions.IgnoreCase);
                Match match = rgx.Match(p.MainWindowTitle);
                if (match.Success)
                {
                    string[] names = rgx.GetGroupNames();
                    foreach (var name in names)
                    {
                        Group grp = match.Groups[name];
                        if (!Int32.TryParse(name, out _) && grp.Value != "")
                        {
                            return new Structs.GameInfo
                            {
                                is_running = true,
                                short_name = name,
                                game_name = Statics.full_game_name[name]
                            };
                        }
                    }
                }
            }
            return new Structs.GameInfo
            {
                is_running = false,
                short_name = "",
                game_name = ""
            };
        }
    }
}
