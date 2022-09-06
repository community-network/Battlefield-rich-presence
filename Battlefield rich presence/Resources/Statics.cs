using System.Collections.Generic;

namespace BattlefieldRichPresence.Resources
{
    internal class Statics
    {
        public enum Game
        {
            None,
            Bf1942,
            Bfvietnam,
            Bf2,
            Bf2142,
            Bfbc2,
            Bf3,
            Bf4,
            Bfh,
            Bf1,
            Bf5
        }
        // Regex group names need to match enum keys, since we need to map the matched group to an enum value 
        public static readonly string SupportedGamesRegex = @"^(?:(?:battlefield(?:(?'Bf1'\u2122 1)|(?'Bf5'\u2122 V)|(?'Bf3' 3\u2122)|(?'Bf4' 4)|(?'Bfh' Hardline)|(?'Bfbc2': bad company 2)|(?'Bfvietnam' vietnam)))|(?:bf(?:(?'Bf2'2)|(?'Bf2142'2142)) \(v1\.[\.\-0-9]+, pid: [0-9]+\))|(?'Bf1942'bf1942 \(Ver: \w{3}, \d+ \w{3} \d+ [:0-9]+\)))$";
        public static readonly Dictionary<Game, string> ShortGameName = new Dictionary<Game, string>
        {
            { Game.Bf1942, "Bf1942" },
            { Game.Bfvietnam, "Bfvietnam" },
            { Game.Bf2, "Bf2" },
            { Game.Bf2142, "Bf2142" },
            { Game.Bfbc2, "Bfbc2" },
            { Game.Bf3, "Bf3" },
            { Game.Bf4, "Bf4" },
            { Game.Bfh, "Bfh" },
            { Game.Bf1, "Bf1" },
            { Game.Bf5, "Bf5" }
        };
        public static readonly Dictionary<Game, string> FullGameName = new Dictionary<Game, string>
        {
            { Game.Bf1942, "Battlefield 1942" },
            { Game.Bfvietnam, "Battlefield Vietnam" },
            { Game.Bf2, "Battlefield 2" },
            { Game.Bf2142, "Battlefield 2142" },
            { Game.Bfbc2, "Battlefield: Bad Company 2" },
            { Game.Bf3, "Battlefield 3" },
            { Game.Bf4, "Battlefield 4" },
            { Game.Bfh, "Battlefield Hardline" },
            { Game.Bf1, "Battlefield 1" },
            { Game.Bf5, "Battlefield V" }
        };
        public static readonly List<Game> NameChangeUiGames = new List<Game>
        {
            Game.Bfbc2,
            Game.Bf3,
            Game.Bf4,
            Game.Bfh,
            Game.Bf5
        };

        public static readonly List<Game> GameDataReaderGames = new List<Game>
        {
            Game.Bf1942,
            Game.Bfvietnam,
            Game.Bf2,
            Game.Bf2142
        };
        public static readonly List<Game> Frostbite3Games = new List<Game>
        {
            Game.Bf4,
            Game.Bf1,
            Game.Bf5
        };
        public static readonly List<Game> JoinmeDotClickGames = new List<Game>
        {
            Game.Bf1942,
            Game.Bfvietnam,
            Game.Bf2
        };
        public static readonly List<Game> GameTrackerGames = new List<Game>
        {
            Game.Bf1942,
            Game.Bf2142,
            Game.Bfvietnam,
            Game.Bfbc2
        };
        public static readonly List<Game> GametoolsGames = new List<Game>
        {
            Game.Bf3,
            Game.Bfh
        };
        public static readonly Dictionary<Game, string> GameClientIds = new Dictionary<Game, string>
        {
            { Game.Bf1942, "998710441595392090" },
            { Game.Bfvietnam, "998710608025366528" },
            { Game.Bf2, "998710361446416424" },
            { Game.Bf2142, "998710479692234904" },
            { Game.Bfbc2, "998710536919330927" },
            { Game.Bf3, "998710399975305327" },
            { Game.Bf4, "998710324922437702" },
            { Game.Bfh, "999057759876161587" },
            { Game.Bf1, "998710285605019708" },
            { Game.Bf5, "1009379254926053458" }
        };
    }
}
