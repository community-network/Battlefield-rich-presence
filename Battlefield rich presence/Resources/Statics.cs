using System.Collections.Generic;

namespace BattlefieldRichPresence.Resources
{
    internal class Statics
    {
        public static readonly string SupportedGames = @"^(?:(?:battlefield(?:(?'bf1'\u2122 1)|(?'bf3' 3\u2122)|(?'bf4' 4)|(?'bfbc2': bad company 2)|(?'bfvietnam' vietnam)))|(?:bf(?:(?'bf2'2)|(?'bf2142'2142)) \(v1\.[\.\-0-9]+, pid: [0-9]+\))|(?'bf1942'bf1942 \(Ver: \w{3}, \d+ \w{3} \d+ [:0-9]+\)))$";
        public static readonly Dictionary<string, string> FullGameName = new Dictionary<string, string>
        {
            { "bf1", "Battlefield 1" },
            { "bf3", "Battlefield 3" },
            { "bf4", "Battlefield 4" },
            { "bfvietnam", "Battlefield Vietnam" },
            { "bfbc2", "Battlefield bad company 2" },
            { "bf2", "Battlefield 2" },
            { "bf2142", "Battlefield 2142" },
            { "bf1942", "Battlefield 1942" },
        };
        public static readonly List<string> Frostbite3Games = new List<string>
        {
            "bf1",
            "bf4"
        };
        public static readonly List<string> JoinmeClickGames = new List<string>
        {
            "bf2",
            "bfvietnam",
            "bf1942"
        };
        public static readonly Dictionary<string, string> GameClientIds = new Dictionary<string, string>
        {
            { "bf1", "998710285605019708" },
            { "bf3", "998710399975305327" },
            { "bf4", "998710324922437702" },
            { "bfvietnam", "998710608025366528" },
            { "bfbc2", "998710536919330927" },
            { "bf2", "998710361446416424" },
            { "bf2142", "998710479692234904" },
            { "bf1942", "998710441595392090" },
        };
    }
}
