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
            Bf5,
            Bf2042,
        }
        // Regex group names need to match enum keys, since we need to map the matched group to an enum value 
        public static readonly string SupportedGamesRegex = @"^(?:(?:battlefield(?:(?'Bf1'\u2122 1)|(?'Bf5'\u2122 V)|(?'Bf2042'\u2122 2042)|(?'Bf3' 3\u2122)|(?'Bf4' 4)|(?'Bfh' Hardline)|(?'Bfbc2': bad company 2)|(?'Bfvietnam' vietnam)))|(?:bf(?:(?'Bf2'2)|(?'Bf2142'2142)) \(v1\.[\.\-0-9]+, pid: [0-9]+\))|(?'Bf1942'bf1942 \(Ver: \w+, \d+ \w+\.? \d+(?: [:0-9]+)?\)))$";
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
            { Game.Bf5, "Bf5" },
            { Game.Bf2042, "Bf2042" }
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
            { Game.Bf5, "Battlefield V" },
            { Game.Bf2042, "Battlefield 2042" }
        };
        public static readonly List<Game> NewTitles = new List<Game> 
        {
            Game.Bf5,
            Game.Bf2042,
        };
        public static readonly List<Game> NameChangeUiGames = new List<Game>
        {
            Game.Bf3,
            Game.Bf4,
            Game.Bfh,
            Game.Bf5,
            Game.Bf2042
        };

        public static readonly List<Game> GameDataReaderGames = new List<Game>
        {
            Game.Bf1942,
            Game.Bfvietnam,
            Game.Bf2,
            Game.Bf2142,
            Game.Bfbc2
        };
        public static readonly List<Game> Frostbite3Games = new List<Game>
        {
            Game.Bf4,
            Game.Bf1,
            Game.Bf5,
            Game.Bf2042
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
            { Game.Bf5, "1009379254926053458" },
            { Game.Bf2042, "1083853115545108632" }
        };


        public static string getSquadName(int squadID)
        {
            switch (squadID)
            {
                case 0:
                case 99:
                    return "Apples";
                case 1:
                    return "Butter";
                case 2:
                    return "Charliie";
                case 3:
                    return "Duff";
                case 4:
                    return "Edward";
                case 5:
                    return "Freddie";
                case 6:
                    return "George";
                case 7:
                    return "Harry";
                case 8:
                    return "Ink";
                case 9:
                    return "Johnnie";
                case 10:
                    return "King";
                case 11:
                    return "London";
                case 12:
                    return "Monkey";
                case 13:
                    return "Nuts";
                case 14:
                    return "Orange";
                case 15:
                    return "Pudding";
                default:
                    return squadID.ToString();
            }
        }

        public static Dictionary<string, string> getPlayerClass(string item)
        {
            var items = new Dictionary<string, Dictionary<string, string>>()
            {
                {"ID_M_TANKER", new Dictionary<string, string>(){ { "name", "Tanker" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconTankerLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconTankerLarge.png" } } },
                {"ID_M_PILOT", new Dictionary<string, string>(){ { "name", "Pilot" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconPilotLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconPilotLarge.png" } } },
                {"ID_M_CAVALRY", new Dictionary<string, string>(){ { "name", "Cavalry" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconRiderLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconRiderLarge.png" } } },
                {"ID_M_SENTRY", new Dictionary<string, string>(){ { "name", "Sentry" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconSentryLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconSentryLarge.png" } } },
                {"ID_M_FLAMETHROWER", new Dictionary<string, string>(){ { "name", "Flamethrower" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconFlamethrowerLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconFlamethrowerLarge.png" } } },
                {"ID_M_INFILTRATOR", new Dictionary<string, string>(){ { "name", "Infiltrator" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconInfiltratorLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconInfiltratorLarge.png" } } },
                {"ID_M_TRENCHRAIDER", new Dictionary<string, string>(){ { "name", "Trenchraider" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconTrenchRaiderLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconTrenchRaiderLarge.png" } } },
                {"ID_M_ANTITANK", new Dictionary<string, string>(){ { "name", "Anti-tank" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconAntiTankLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconAntiTankLarge.png" } } },
                {"ID_M_ASSAULT", new Dictionary<string, string>(){ { "name", "Assult" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconAssaultLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconAssaultLarge.png" } } },
                {"ID_M_MEDIC", new Dictionary<string, string>(){ { "name", "Medic" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconMedicLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconMedicLarge.png" } } },
                {"ID_M_SUPPORT", new Dictionary<string, string>(){ { "name", "Support" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconSupportLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconSupportLarge.png" } } },
                {"ID_M_SCOUT", new Dictionary<string, string>(){ { "name", "Scount" }, { "black", "https://cdn.gametools.network/kits/bf1/black/KitIconScoutLarge.png" }, { "white", "https://cdn.gametools.network/kits/bf1/white/KitIconScoutLarge.png" } } }
            };

            if (item != null && items.TryGetValue(item, out Dictionary<string, string> result))
            {
                result.Add("id", item);
                return result;
            }
            return new Dictionary<string, string>() { { "id", item }, { "name", null }, { "black", null }, { "white", null } };
        }

        public static Dictionary<string, string> getItem(string item)
        {
            var items = new Dictionary<string, Dictionary<string, string>>(){
                {"U_M1911", new Dictionary<string, string>(){ {"name", "M1911"}, {"shortName", "M1911"}, {"image", "https://cdn.gametools.network/weapons/bf1/Colt1911-ed324bf1.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_LugerP08", new Dictionary<string, string>(){ {"name", "P08"}, {"shortName", "P08"}, {"image", "https://cdn.gametools.network/weapons/bf1/LugerP08-7f07aa2d.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_FN1903", new Dictionary<string, string>(){ {"name", "Mle 1903"}, {"shortName", "M1903"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mle1903-a0fe1ec3.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_BorchardtC93", new Dictionary<string, string>(){ {"name", "C93"}, {"shortName", "C93"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mle1903-a0fe1ec3.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_SmithWesson", new Dictionary<string, string>(){ {"name", "No. 3 Revolver"}, {"shortName", "No3 Rev"}, {"image", "https://cdn.gametools.network/weapons/bf1/SmithWesson-e26b4f24.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_Kolibri", new Dictionary<string, string>(){ {"name", "Kolibri"}, {"shortName", "Kolibri"}, {"image", "https://cdn.gametools.network/weapons/bf1/KolibriPistol-ec20b160.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_NagantM1895", new Dictionary<string, string>(){ {"name", "Nagant Revolver"}, {"shortName", "Nagant Rev"}, {"image", "https://cdn.gametools.network/weapons/bf1/NagantM1895-05035f4a.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_Obrez", new Dictionary<string, string>(){ {"name", "Obrez"}, {"shortName", "Obrez"}, {"image", "https://cdn.gametools.network/weapons/bf1/ObrezPistol-0c86b6ed.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_Webley_Mk6", new Dictionary<string, string>(){ {"name", "Revolver Mk VI"}, {"shortName", "Mk VI"}, {"image", "https://cdn.gametools.network/weapons/bf1/Webley_MK6-da81b474.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_M1911_Preorder_Hellfighter", new Dictionary<string, string>(){ {"name", "Hellfighter M1911"}, {"shortName", "M1911 HF"}, {"image", "https://cdn.gametools.network/weapons/bf1/Colt1911-ed324bf1.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_LugerP08_Wep_Preorder", new Dictionary<string, string>(){ {"name", "Red Baron's P08"}, {"shortName", "P08 HNJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/LugerP08-7f07aa2d.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_M1911_Suppressed", new Dictionary<string, string>(){ {"name", "M1911 Silencer"}, {"shortName", "M1911 XYQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/M1911Silencer-d6c0e687.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_SingleActionArmy", new Dictionary<string, string>(){ {"name", "Peacekeeper"}, {"shortName", "Peacekeeper"}, {"image", "https://cdn.gametools.network/weapons/bf1/Colt_SAA-ef15294c.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_M1911_Preorder_Triforce", new Dictionary<string, string>(){ {"name", "M1911 Triforce"}, {"shortName", "M1911 BBXZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Colt1911-ed324bf1.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_GermanStick", new Dictionary<string, string>(){ {"name", "Stick"}, {"shortName", "German Stick"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetFragmented-8c15152e.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_FragGrenade", new Dictionary<string, string>(){ {"name", "Frag"}, {"shortName", "Frag Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetFragmented-8c15152e.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_GasGrenade", new Dictionary<string, string>(){ {"name", "Gas"}, {"shortName", "Gas Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetGas-2bee4386.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_ImpactGrenade", new Dictionary<string, string>(){ {"name", "Impact"}, {"shortName", "Impact Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetImpact-f0c7f39e.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_Incendiary", new Dictionary<string, string>(){ {"name", "Incendiary"}, {"shortName", "Incendiary"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetIncindiary-68d49a3a.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_MiniGrenade", new Dictionary<string, string>(){ {"name", "Mini"}, {"shortName", "Mini Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetMiniOffensive-2d19e08a.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_SmokeGrenade", new Dictionary<string, string>(){ {"name", "Smoke"}, {"shortName", "Smoke Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetSmoke-af84f434.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_Grenade_AT", new Dictionary<string, string>(){ {"name", "Light AT"}, {"shortName", "Grenade AT"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetTrooperATGrenade-a6575030.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_ImprovisedGrenade", new Dictionary<string, string>(){ {"name", "Improvised"}, {"shortName", "Imsp Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/ImprovisedGrenade-fea87071.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_RussianBox", new Dictionary<string, string>(){ {"name", "Russian"}, {"shortName", "Russian Box"}, {"image", "https://cdn.gametools.network/weapons/bf1/RU_Grenade-a7e29a54.png"}, {"type", "equipment"}, {"subtype", "grenade"}, {"class", "All"}}},
                {"U_RemingtonM10_Wep_Slug", new Dictionary<string, string>(){ {"name", "Model 10-A Slug"}, {"shortName", "10A XDK"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonM10-08ab3f5b.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_RemingtonM10_Wep_Choke", new Dictionary<string, string>(){ {"name", "Model 10-A Hunter"}, {"shortName", "10A LR"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonM10-08ab3f5b.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_RemingtonM10", new Dictionary<string, string>(){ {"name", "Model 10-A Factory"}, {"shortName", "10A YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonM10-08ab3f5b.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_Winchester1897_Wep_Sweeper", new Dictionary<string, string>(){ {"name", "M97 Trench Gun Sweeper"}, {"shortName", "M97 SD"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1897-bb453195.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_Winchester1897_Wep_LowRecoil", new Dictionary<string, string>(){ {"name", "M97 Trench Gun Back-Bored"}, {"shortName", "M97 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1897-bb453195.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_Winchester1897_Wep_Choke", new Dictionary<string, string>(){ {"name", "M97 Trench Gun Hunter"}, {"shortName", "M97 LR"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1897-bb453195.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_MP18_Wep_Trench", new Dictionary<string, string>(){ {"name", "MP 18 Trench"}, {"shortName", "MP18 HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/BergmannSchmeisserMP18-761af430.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_MP18_Wep_Burst", new Dictionary<string, string>(){ {"name", "MP 18 Experimental"}, {"shortName", "MP18 SY"}, {"image", "https://cdn.gametools.network/weapons/bf1/BergmannSchmeisserMP18-761af430.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_MP18_Wep_Accuracy", new Dictionary<string, string>(){ {"name", "MP 18 Optical"}, {"shortName", "MP18 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/BergmannSchmeisserMP18-761af430.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_BerettaM1918_Wep_Trench", new Dictionary<string, string>(){ {"name", "Automatico M1918 Trench"}, {"shortName", "MP1918 HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Beretta1918-3daab991.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_BerettaM1918_Wep_Stability", new Dictionary<string, string>(){ {"name", "Automatico M1918 Storm"}, {"shortName", "MP1918 CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/Beretta1918-3daab991.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_BerettaM1918", new Dictionary<string, string>(){ {"name", "Automatico M1918 Factory"}, {"shortName", "MP1918 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/Beretta1918-3daab991.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_BrowingA5_Wep_LowRecoil", new Dictionary<string, string>(){ {"name", "12g Automatic Shotgun ( Back-Bored )"}, {"shortName", "12g BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/BrowingA5-95b260b4.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_BrowingA5_Wep_Choke", new Dictionary<string, string>(){ {"name", "12g Automatic Shotgun ( Hunter )"}, {"shortName", "12g LR"}, {"image", "https://cdn.gametools.network/weapons/bf1/BrowingA5-95b260b4.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_BrowingA5_Wep_ExtensionTube", new Dictionary<string, string>(){ {"name", "12g Automatic Shotgun ( Extended )"}, {"shortName", "12g JC"}, {"image", "https://cdn.gametools.network/weapons/bf1/BrowingA5-95b260b4.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_Hellriegel1915", new Dictionary<string, string>(){ {"name", "Hellriegel 1915 Factory"}, {"shortName", "H1915 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/Hellriegel1915-e2513c1e.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_Hellriegel1915_Wep_Accuracy", new Dictionary<string, string>(){ {"name", "Hellriegel 1915 Defensive"}, {"shortName", "H1915 FY"}, {"image", "https://cdn.gametools.network/weapons/bf1/Hellriegel1915-e2513c1e.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_Winchester1897_Wep_Preorder", new Dictionary<string, string>(){ {"name", "Hellfighter Trench"}, {"shortName", "M97 DYZS"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1897-bb453195.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_SjogrenShotgun", new Dictionary<string, string>(){ {"name", "Sjogren Inertial Factory"}, {"shortName", "RDP YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/SjogrenShotgun-e95b3db0.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_SjogrenShotgun_Wep_Slug", new Dictionary<string, string>(){ {"name", "Sjogren Inertial Slug"}, {"shortName", "RDP XDK"}, {"image", "https://cdn.gametools.network/weapons/bf1/SjogrenShotgun-e95b3db0.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_Ribeyrolles", new Dictionary<string, string>(){ {"name", "Ribeyrolles 1918 Factory"}, {"shortName", "L1918 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/Ribeyrolles-0e43197c.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_Ribeyrolles_Wep_Optical", new Dictionary<string, string>(){ {"name", "Ribeyrolles 1918 Optical"}, {"shortName", "L1918 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Ribeyrolles-0e43197c.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_RemingtonModel1900", new Dictionary<string, string>(){ {"name", "Model 1900 Factory"}, {"shortName", "M1900 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonModel1900-e80b885b.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_RemingtonModel1900_Wep_Slug", new Dictionary<string, string>(){ {"name", "Model 1900 Slug"}, {"shortName", "M1900 XDK"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonModel1900-e80b885b.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_MaximSMG", new Dictionary<string, string>(){ {"name", "SMG 08/18 Factory"}, {"shortName", "SMG0818 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/MaximSMG-c3563db7.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_MaximSMG_Wep_Accuracy", new Dictionary<string, string>(){ {"name", "SMG 08/18 Optical"}, {"shortName", "SMG0818 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/MaximSMG-c3563db7.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_SteyrM1912_P16", new Dictionary<string, string>(){ {"name", "Maschinenpistole Storm"}, {"shortName", "M1912 P.16 CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/SteyrM1912Stock-a1ad884f.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Assualt"}}},
                {"U_SteyrM1912_P16_Wep_Burst", new Dictionary<string, string>(){ {"name", "Maschinenpistole Experimental"}, {"shortName", "M1912 P.16 SY"}, {"image", "https://cdn.gametools.network/weapons/bf1/SteyrM1912Stock-a1ad884f.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Assualt"}}},
                {"U_Mauser1917Trench", new Dictionary<string, string>(){ {"name", "M1917 Trench Carbine"}, {"shortName", "M1917 KBQ ZH"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserM1917TrenchCarbine-9a4158a1.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_Mauser1917Trench_Wep_Scope", new Dictionary<string, string>(){ {"name", "M1917 Patrol Varbine"}, {"shortName", "M1917 KBQ XL"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserM1917TrenchCarbine-9a4158a1.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_ChauchatSMG", new Dictionary<string, string>(){ {"name", "RSC SMG Factory"}, {"shortName", "RSC YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/Chauchat-Ribeyrolles-4af8a912.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_ChauchatSMG_Wep_Optical", new Dictionary<string, string>(){ {"name", "RSC SMG Optical"}, {"shortName", "RSC MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Chauchat-Ribeyrolles-4af8a912.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_M1919Thompson_Wep_Trench", new Dictionary<string, string>(){ {"name", "Annihilator Trench"}, {"shortName", "Annihilator HG"}, {"image", "https://cdn.gametools.network/weapons/bf1/ThompsonAnnihilatorTr-1a660e74.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_M1919Thompson_Wep_Stability", new Dictionary<string, string>(){ {"name", "Annihilator Storm"}, {"shortName", "Annihilator CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/ThompsonAnnihilatorTr-1a660e74.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Assualt"}}},
                {"U_M1919Thompson", new Dictionary<string, string>(){ {"name", "M1919 Submachine Gun"}, {"shortName", "M1919"}, {"image", "https://cdn.gametools.network/weapons/bf1/M1919Thompson-1cf7343d.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_FrommerStopAuto", new Dictionary<string, string>(){ {"name", "Formmer Stop Auto"}, {"shortName", "FrommerStopAuto"}, {"image", "https://cdn.gametools.network/weapons/bf1/FrommerStop-506df97e.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Assualt"}}},
                {"U_SawnOffShotgun", new Dictionary<string, string>(){ {"name", "Sawed Off Shotgun"}, {"shortName", "SawnOffShotgun"}, {"image", "https://cdn.gametools.network/weapons/bf1/SawedOfShotgun-d31e0dd8.png"}, {"type", "primary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_GasserM1870", new Dictionary<string, string>(){ {"name", "Gasser M1870"}, {"shortName", "M1870"}, {"image", "https://cdn.gametools.network/weapons/bf1/GasserM1870-00471df4.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Assualt"}}},
                {"U_LancasterHowdah", new Dictionary<string, string>(){ {"name", "Howdah Pistol"}, {"shortName", "Howdah"}, {"image", "https://cdn.gametools.network/weapons/bf1/LancasterHowdah-9100578c.png"}, {"type", "secondary"}, {"subtype", "shotgun"}, {"class", "Assualt"}}},
                {"U_Hammerless", new Dictionary<string, string>(){ {"name", "1903 Hammerless"}, {"shortName", "1903"}, {"image", "https://cdn.gametools.network/weapons/bf1/Hammerless-e61505d4.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Assualt"}}},
                {"U_Dynamite", new Dictionary<string, string>(){ {"name", "Dynamite"}, {"shortName", "Dynamite"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetDynamite-b6283212.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Assualt"}}},
                {"U_ATGrenade", new Dictionary<string, string>(){ {"name", "Anti-Tank Grenade"}, {"shortName", "ATGrenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetATGrenade-4b135d46.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Assualt"}}},
                {"U_ATMine", new Dictionary<string, string>(){ {"name", "Anti-Tank Mine"}, {"shortName", "ATMine"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetMine-527cef72.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Assualt"}}},
                {"U_BreechGun", new Dictionary<string, string>(){ {"name", "AT Rocket Gun"}, {"shortName", "AT"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetBreechgun-f2188c3f.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Assualt"}}},
                {"U_BreechGun_Flak", new Dictionary<string, string>(){ {"name", "AA Rocket Gun"}, {"shortName", "AAT"}, {"image", "https://cdn.gametools.network/weapons/bf1/AA-Rocket-Gun-49a4e8d1.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Assualt"}}},
                {"U_CeiRigottiM1895_Wep_Trench", new Dictionary<string, string>(){ {"name", "Cei-Rigotti Trench"}, {"shortName", "M1895 HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/CeiRigotti-8ae129e0.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_CeiRigottiM1895_Wep_Range", new Dictionary<string, string>(){ {"name", "Cei-Rigotti Optical"}, {"shortName", "M1895 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/CeiRigotti-8ae129e0.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_CeiRigottiM1895", new Dictionary<string, string>(){ {"name", "Cei-Rigotti Factory"}, {"shortName", "M1895 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/CeiRigotti-8ae129e0.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_MauserSL1916_Wep_Scope", new Dictionary<string, string>(){ {"name", "Selbstlader M1916 Sniper"}, {"shortName", "M1916 SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserSelbstladerM1916-c86e8775.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_MauserSL1916_Wep_Range", new Dictionary<string, string>(){ {"name", "Selbstlader M1916 Optical"}, {"shortName", "M1916 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserSelbstladerM1916-c86e8775.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_MauserSL1916", new Dictionary<string, string>(){ {"name", "Selbstlader M1916 Favtory"}, {"shortName", "M1916 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserSelbstladerM1916-c86e8775.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_WinchesterM1907_Wep_Trench", new Dictionary<string, string>(){ {"name", "M1907 SL Trench"}, {"shortName", "M1907 JGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1907-3e99346c.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_WinchesterM1907_Wep_Auto", new Dictionary<string, string>(){ {"name", "M1907 SL Sweeper"}, {"shortName", "M1907 SD"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1907-3e99346c.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_WinchesterM1907", new Dictionary<string, string>(){ {"name", "M1907 semi-automatic rifle (original factory)"}, {"shortName", "M1907 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterM1907-3e99346c.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_Mondragon_Wep_Range", new Dictionary<string, string>(){ {"name", "Mondragon Optical"}, {"shortName", "Mondragon MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mondragon-a3950be7.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_Mondragon_Wep_Stability", new Dictionary<string, string>(){ {"name", "Mondragon Storm"}, {"shortName", "Mondragon CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mondragon-a3950be7.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_Mondragon_Wep_Bipod", new Dictionary<string, string>(){ {"name", "Mondragon Sniper"}, {"shortName", "Mondragon JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mondragon-a3950be7.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_RemingtonModel8", new Dictionary<string, string>(){ {"name", "Autoloading 8.35 Factory"}, {"shortName", "8.35 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonM8_Special-398391d9.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_RemingtonModel8_Wep_Scope", new Dictionary<string, string>(){ {"name", "Autoloading 8.35 Marksman"}, {"shortName", "8.35 SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonM8_Special-398391d9.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_RemingtonModel8_Wep_ExtendedMag", new Dictionary<string, string>(){ {"name", "Autoloading 8.25 Extended"}, {"shortName", "8.25 JC"}, {"image", "https://cdn.gametools.network/weapons/bf1/RemingtonM8_Special-398391d9.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_Luger1906", new Dictionary<string, string>(){ {"name", "Selbstlader 1906 Favtory"}, {"shortName", "1906 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/Luger1906-3238a6b3.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_Luger1906_Wep_Scope", new Dictionary<string, string>(){ {"name", "Selbstlader 1906 Sniper"}, {"shortName", "1906 JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/Luger1906-3238a6b3.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_RSC1917_Wep_Range", new Dictionary<string, string>(){ {"name", "RSC 1917 Optical"}, {"shortName", "RSC 1917 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/RSC1917-35904a91.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_RSC1917", new Dictionary<string, string>(){ {"name", "RSC 1917 Factory"}, {"shortName", "RSC 1917 YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/RSC1917-35904a91.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_FederovAvtomat_Wep_Trench", new Dictionary<string, string>(){ {"name", "Federov Automatic Rifle (Trench Warfare )"}, {"shortName", "Fedorov HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/FederovAvtomat-aa228b15.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_FederovAvtomat_Wep_Range", new Dictionary<string, string>(){ {"name", "Federov Automatic Rifle (Scope )"}, {"shortName", "Fedorov MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/FederovAvtomat-aa228b15.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_GeneralLiuRifle", new Dictionary<string, string>(){ {"name", "General Liu Rifle Factory"}, {"shortName", "GeneralLiu YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/GeneralLiu-f926d015.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_GeneralLiuRifle_Wep_Stability", new Dictionary<string, string>(){ {"name", "General Liu Rifle Storm"}, {"shortName", "GeneralLiu CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/GeneralLiu-f926d015.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_FarquharHill_Wep_Range", new Dictionary<string, string>(){ {"name", "Farquhar-Hill Optical"}, {"shortName", "Farquhar MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/FarquharHill-11f5925b.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_FarquharHill_Wep_Stability", new Dictionary<string, string>(){ {"name", "Farquhar-Hill Storm"}, {"shortName", "Farquhar CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/FarquharHill-11f5925b.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_BSAHowellM1916", new Dictionary<string, string>(){ {"name", "Howel Automatic Factory"}, {"shortName", "Howell YC"}, {"image", "https://cdn.gametools.network/weapons/bf1/BSA_Howell-c3f2e18b.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_BSAHowellM1916_Wep_Scope", new Dictionary<string, string>(){ {"name", "Howel Automatic Sniper"}, {"shortName", "Howell JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/BSA_Howell-c3f2e18b.png"}, {"type", "primary"}, {"subtype", "slr"}, {"class", "Medic"}}},
                {"U_FedorovDegtyarev", new Dictionary<string, string>(){ {"name", "Fedorov Degtyarev"}, {"shortName", "Fedorov SL"}, {"image", "https://cdn.gametools.network/weapons/bf1/FederovDegtyarev-ed497b9d.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Medic"}}},
                {"U_WebFosAutoRev_455Webley", new Dictionary<string, string>(){ {"name", "Auto Revolver"}, {"shortName", "Auto Rev"}, {"image", "https://cdn.gametools.network/weapons/bf1/WebleyFosberyAutoRevolver-a57ea28c.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Medic"}}},
                {"U_MauserC96", new Dictionary<string, string>(){ {"name", "C96"}, {"shortName", "C96"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserC96-52835b08.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Medic"}}},
                {"U_Mauser1914", new Dictionary<string, string>(){ {"name", "Taschenpistol M1914"}, {"shortName", "M1914"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mauser1914-53a1954e.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Medic"}}},
                {"U_Syringe", new Dictionary<string, string>(){ {"name", "Medical Syringe"}, {"shortName", "Syringe"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetSyringe-e6c764c2.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Medic"}}},
                {"U_MedicBag", new Dictionary<string, string>(){ {"name", "Medical Crate"}, {"shortName", "MedicBag"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetMedicBag-159f240b.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Medic"}}},
                {"U_Bandages", new Dictionary<string, string>(){ {"name", "Bandage Pouch"}, {"shortName", "Bandages"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetBandages-1d1fc900.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Medic"}}},
                {"_RGL_Frag", new Dictionary<string, string>(){ {"name", "Rifle Grenade - FRG"}, {"shortName", "RGL Frag"}, {"image", "https://cdn.gametools.network/weapons/bf1/MedicRifleLauncher_B-a712e224.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Medic"}}},
                {"_RGL_Smoke", new Dictionary<string, string>(){ {"name", "Rifle Grenade - SMK"}, {"shortName", "RGL Smoke"}, {"image", "https://cdn.gametools.network/weapons/bf1/MedicRifleLauncher_A-438b725e.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Medic"}}},
                {"_RGL_HE", new Dictionary<string, string>(){ {"name", "Rifle Grenade - HE"}, {"shortName", "RGL HE"}, {"image", "https://cdn.gametools.network/weapons/bf1/MedicRifleLauncher_B-a712e224.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Medic"}}},
                {"U_LewisMG_Wep_Suppression", new Dictionary<string, string>(){ {"name", "Lewis Gun Supressive"}, {"shortName", "LewisMG YZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/LewisLMG-832c29e8.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_LewisMG_Wep_Range", new Dictionary<string, string>(){ {"name", "Lewis Gun Optical"}, {"shortName", "LewisMG MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/LewisLMG-832c29e8.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_LewisMG", new Dictionary<string, string>(){ {"name", "Lewis Gun Low Weight"}, {"shortName", "LewisMG QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/LewisLMG-832c29e8.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_HotchkissM1909_Wep_Stability", new Dictionary<string, string>(){ {"name", "M1909 Benet-Mercie Storm"}, {"shortName", "M1909 CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/HotchkissLMG-06defda3.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_HotchkissM1909_Wep_Range", new Dictionary<string, string>(){ {"name", "M1909 Benet-Mercie Optical"}, {"shortName", "M1909 MZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/HotchkissLMG-06defda3.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_HotchkissM1909_Wep_Bipod", new Dictionary<string, string>(){ {"name", "M1909 Benet-Mercie Telescoptic"}, {"shortName", "M1909 WYMJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/HotchkissLMG-06defda3.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_MadsenMG_Wep_Trench", new Dictionary<string, string>(){ {"name", "Madsen MG Trench"}, {"shortName", "MadsenMG HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/MadsenMG-51e41523.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_MadsenMG_Wep_Stability", new Dictionary<string, string>(){ {"name", "Madsen MG Storm"}, {"shortName", "MadsenMG CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/MadsenMG-51e41523.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_MadsenMG", new Dictionary<string, string>(){ {"name", "Madsen MG Low Weight"}, {"shortName", "MadsenMG QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/MadsenMG-51e41523.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_Bergmann1915MG_Wep_Suppression", new Dictionary<string, string>(){ {"name", "MG15 n.A. Suppressive"}, {"shortName", "MG15 YZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Bergmann1915MG-891af31f.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_Bergmann1915MG_Wep_Stability", new Dictionary<string, string>(){ {"name", "MG15 n.A. Storm"}, {"shortName", "MG15 CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/Bergmann1915MG-891af31f.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_Bergmann1915MG", new Dictionary<string, string>(){ {"name", "MG15 n.A. Low Weight"}, {"shortName", "MG15 QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/Bergmann1915MG-891af31f.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_BARM1918_Wep_Trench", new Dictionary<string, string>(){ {"name", "BAR M1918 Trench"}, {"shortName", "M1918 HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Barm1918-3c14511c.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_BARM1918_Wep_Stability", new Dictionary<string, string>(){ {"name", "BAR M1918 Storm"}, {"shortName", "M1918 CF"}, {"image", "https://cdn.gametools.network/weapons/bf1/Barm1918-3c14511c.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_BARM1918_Wep_Bipod", new Dictionary<string, string>(){ {"name", "BAR M1918 Telescopic"}, {"shortName", "M1918 WYMJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Barm1918-3c14511c.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_BARM1918A2", new Dictionary<string, string>(){ {"name", "M1918A2 Browning Automatic Rifle"}, {"shortName", "M1918A2"}, {"image", "https://cdn.gametools.network/weapons/bf1/BARM1918A2-48c755b2.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_HuotAutoRifle", new Dictionary<string, string>(){ {"name", "Huot Automatic Low Weight"}, {"shortName", "Huot QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/HuotAutoRifle-4ab70c1a.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_HuotAutoRifle_Wep_Range", new Dictionary<string, string>(){ {"name", "Huot Automatic Optical"}, {"shortName", "Huot HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/HuotAutoRifle-4ab70c1a.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_Chauchat", new Dictionary<string, string>(){ {"name", "Chauchat Low Weight"}, {"shortName", "Chauchat QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/Chauchat-787ad478.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_Chauchat_Wep_Bipod", new Dictionary<string, string>(){ {"name", "Chauchat Telescopic"}, {"shortName", "Chauchat WYMJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Chauchat-787ad478.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_ParabellumLMG", new Dictionary<string, string>(){ {"name", "Parabellum MG14/17 Low Weight"}, {"shortName", "MG1417 QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/ParabellumMG1417-09dccd5b.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_ParabellumLMG_Wep_Suppression", new Dictionary<string, string>(){ {"name", "Parabellum MG14/17 Supressive"}, {"shortName", "MG1417 YZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/ParabellumMG1417-09dccd5b.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_PerinoM1908", new Dictionary<string, string>(){ {"name", "Perino Model 1908 Low Weight"}, {"shortName", "M1908 QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/Perino1908-e97144b1.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_PerinoM1908_Wep_Defensive", new Dictionary<string, string>(){ {"name", "Perino Model 1908 Defensive"}, {"shortName", "M1908 FY"}, {"image", "https://cdn.gametools.network/weapons/bf1/Perino1908-e97144b1.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_BrowningM1917", new Dictionary<string, string>(){ {"name", "M1917 MG Low Weight"}, {"shortName", "M1917 QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/Browning1917-61290bc9.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_BrowningM1917_Wep_Suppression", new Dictionary<string, string>(){ {"name", "M1917 MG Telescopic"}, {"shortName", "M1917 WYMJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Browning1917-61290bc9.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_MG0818", new Dictionary<string, string>(){ {"name", "lMG 08/18 Low Weight"}, {"shortName", "MG0818 QLH"}, {"image", "https://cdn.gametools.network/weapons/bf1/LMG_08-18-743c1aa8.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_MG0818_Wep_Defensive", new Dictionary<string, string>(){ {"name", "lMG 08/18 Supressive"}, {"shortName", "MG0818 YZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/LMG_08-18-743c1aa8.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_WinchesterBurton_Wep_Trench", new Dictionary<string, string>(){ {"name", "Burton LMR Trench"}, {"shortName", "Burton LMR ZH"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterBurton-ce3988cc.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_WinchesterBurton_Wep_Optical", new Dictionary<string, string>(){ {"name", "Burton LMR Optical"}, {"shortName", "Burton LMR HZJ"}, {"image", "https://cdn.gametools.network/weapons/bf1/WinchesterBurton-ce3988cc.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Support"}}},
                {"U_MauserC96AutoPistol", new Dictionary<string, string>(){ {"name", "C96 Patrol Carbine"}, {"shortName", "C96 KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserC96CCarbine-741ab77d.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_LugerArtillery", new Dictionary<string, string>(){ {"name", "P08 Artillerie"}, {"shortName", "P08 Artillery"}, {"image", "https://cdn.gametools.network/weapons/bf1/LugerArtillery-1fbfb83c.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_PieperCarbine", new Dictionary<string, string>(){ {"name", "Pieper M1893"}, {"shortName", "M1893"}, {"image", "https://cdn.gametools.network/weapons/bf1/PieperCarbine-31e63cfb.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_M1911_Stock", new Dictionary<string, string>(){ {"name", "M1911 Extended"}, {"shortName", "M1911 JC"}, {"image", "https://cdn.gametools.network/weapons/bf1/M1911ExtendedMag-eb019f60.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_FN1903stock", new Dictionary<string, string>(){ {"name", "Mle 1903 Extended"}, {"shortName", "Mle 1903 JC"}, {"image", "https://cdn.gametools.network/weapons/bf1/FN1903stock-d8904447.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_C93Carbine", new Dictionary<string, string>(){ {"name", "C93 Carbine"}, {"shortName", "C93 KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/C93CarbineSup-120665d1.png"}, {"type", "primary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_SteyrM1912", new Dictionary<string, string>(){ {"name", "Repetierpistole M1912"}, {"shortName", "M1912"}, {"image", "https://cdn.gametools.network/weapons/bf1/SteyrM1912-a49c97dd.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_Bulldog", new Dictionary<string, string>(){ {"name", "Bull Dog Revolver"}, {"shortName", "Bulldog"}, {"image", "https://cdn.gametools.network/weapons/bf1/Bulldog-d95cfd90.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_BerettaM1915", new Dictionary<string, string>(){ {"name", "Modello 1915"}, {"shortName", "Modello 1915"}, {"image", "https://cdn.gametools.network/weapons/bf1/Beretta1915-e2c3c8d8.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Support"}}},
                {"U_M1911_A1", new Dictionary<string, string>(){ {"name", "M1911 A1"}, {"shortName", "M1911A1"}, {"image", "https://cdn.gametools.network/weapons/bf1/Colt1911-ed324bf1.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"U_AmmoCrate", new Dictionary<string, string>(){ {"name", "Ammo Crate"}, {"shortName", "Ammo Crate"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetAmmoCrate-61f48e78.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_AmmoPouch", new Dictionary<string, string>(){ {"name", "Ammo Pouch"}, {"shortName", "Ammo Pouch"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetSmallAmmoPack-5837fde5.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_Mortar", new Dictionary<string, string>(){ {"name", "Mortar - AIR"}, {"shortName", "Mortar KB"}, {"image", "https://cdn.gametools.network/weapons/bf1/MortarAirburst-77c9647f.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_Mortar_HE", new Dictionary<string, string>(){ {"name", "Mortar - HE"}, {"shortName", "Mortar GB"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetMortar-84e30045.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_Wrench", new Dictionary<string, string>(){ {"name", "Repair Tool"}, {"shortName", "Wrench"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetWrench-07e2c76d.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_LimpetMine", new Dictionary<string, string>(){ {"name", "Limpet Charge"}, {"shortName", "Limpet Mine"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetLimpetMine-a6d78b8f.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_Crossbow", new Dictionary<string, string>(){ {"name", "Crossbow Launcher - FRG"}, {"shortName", "Crossbow PP"}, {"image", "https://cdn.gametools.network/weapons/bf1/crossbow-5f3dc5e6.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_Crossbow_HE", new Dictionary<string, string>(){ {"name", "Crossbow Launcher - HE"}, {"shortName", "Crossbow GB"}, {"image", "https://cdn.gametools.network/weapons/bf1/crossbow-5f3dc5e6.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Support"}}},
                {"U_WinchesterM1895_Wep_Trench", new Dictionary<string, string>(){ {"name", "Russian 1895 Trench"}, {"shortName", "1895 HGZ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Winchester1895-69d56c0b.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_WinchesterM1895_Wep_Long", new Dictionary<string, string>(){ {"name", "Russian 1895 Sniper"}, {"shortName", "1895 JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/Winchester1895-69d56c0b.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_WinchesterM1895", new Dictionary<string, string>(){ {"name", "Russian 1895 Infantry"}, {"shortName", "1895 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Winchester1895-69d56c0b.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Gewehr98_Wep_Scope", new Dictionary<string, string>(){ {"name", "Gewehr 98 Marksman"}, {"shortName", "G98 SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserGewehr98-f159616f.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Gewehr98_Wep_LongRange", new Dictionary<string, string>(){ {"name", "Gewehr 98 Sniper"}, {"shortName", "G98 JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserGewehr98-f159616f.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Gewehr98", new Dictionary<string, string>(){ {"name", "Gewehr 98 Infantry"}, {"shortName", "G98 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserGewehr98-f159616f.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_LeeEnfieldSMLE_Wep_Scope", new Dictionary<string, string>(){ {"name", "SMLE MKIII Marksman"}, {"shortName", "MKIII SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/LeeEnfield-52626131.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_LeeEnfieldSMLE_Wep_Med", new Dictionary<string, string>(){ {"name", "SMLE MKIII Carbine"}, {"shortName", "MKIII KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/LeeEnfield-52626131.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_LeeEnfieldSMLE", new Dictionary<string, string>(){ {"name", "SMLE MKIII Infantry"}, {"shortName", "MKIII BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/LeeEnfield-52626131.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_SteyrManM1895_Wep_Scope", new Dictionary<string, string>(){ {"name", "Gewehr M.95 Marksman"}, {"shortName", "G95 SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mannlicher1895-7850a8ec.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_SteyrManM1895_Wep_Med", new Dictionary<string, string>(){ {"name", "Gewehr M.95 Carbine"}, {"shortName", "G95 KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mannlicher1895-7850a8ec.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_SteyrManM1895", new Dictionary<string, string>(){ {"name", "Gewehr M.95 Infantry"}, {"shortName", "G95 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Mannlicher1895-7850a8ec.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_SpringfieldM1903_Wep_Scope", new Dictionary<string, string>(){ {"name", "M1903 Marksman"}, {"shortName", "M1903 SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/SpringfieldM1903-c8ae5988.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_SpringfieldM1903_Wep_LongRange", new Dictionary<string, string>(){ {"name", "M1903 Sniper"}, {"shortName", "M1903 JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/SpringfieldM1903-c8ae5988.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_SpringfieldM1903_Wep_Pedersen", new Dictionary<string, string>(){ {"name", "M1903 Experimental"}, {"shortName", "M1903 SY"}, {"image", "https://cdn.gametools.network/weapons/bf1/SpringfieldM1903-c8ae5988.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_MartiniHenry", new Dictionary<string, string>(){ {"name", "Martini-Henry Infantry"}, {"shortName", "MartiniHenry BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/MartinHenry-c8477a11.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_MartiniHenry_Wep_LongRange", new Dictionary<string, string>(){ {"name", "Martini-Henry Sniper"}, {"shortName", "MartiniHenry JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/MartinHenry-c8477a11.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_LeeEnfieldSMLE_Wep_Preorder", new Dictionary<string, string>(){ {"name", "Lawrence of Arabia's SMLE"}, {"shortName", "SMLE LLS"}, {"image", "https://cdn.gametools.network/weapons/bf1/LeeEnfield-52626131.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Lebel1886_Wep_LongRange", new Dictionary<string, string>(){ {"name", "Lebel Model 1886 Sniper"}, {"shortName", "M1886 JJS"}, {"image", "https://cdn.gametools.network/weapons/bf1/Lebel1886-31bf07f8.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Lebel1886", new Dictionary<string, string>(){ {"name", "Lebel Model 1886 Infantry"}, {"shortName", "M1886 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Lebel1886-31bf07f8.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_MosinNagant1891", new Dictionary<string, string>(){ {"name", "Mosin-Nagant M91 Infantry"}, {"shortName", "M91 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/MosinNagantM1891-fac2efac.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_MosinNagant1891_Wep_Scope", new Dictionary<string, string>(){ {"name", "Mosin-Nagant M91 Marksman"}, {"shortName", "M91 SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/MosinNagantM1891-fac2efac.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_MosinNagantM38", new Dictionary<string, string>(){ {"name", "Mosin - Nagant M38 Carbine"}, {"shortName", "M38 KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/MosinNagantM38-dd529587.png"}, {"type", null}, {"subtype", null}, {"class", null}}},
                {"U_VetterliVitaliM1870", new Dictionary<string, string>(){ {"name", "Vetteril-Vitali M1870/87 Infantry"}, {"shortName", "M1870 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Vetterli-VitaliM1870-87-faadf520.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_VetterliVitaliM1870_Wep_Med", new Dictionary<string, string>(){ {"name", "Vetteril-Vitali M1870/87 Carbine"}, {"shortName", "M1870 KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Vetterli-VitaliM1870-87-faadf520.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Type38Arisaka", new Dictionary<string, string>(){ {"name", "Type 38 Arisaka Infantry"}, {"shortName", "Type38 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Type38Arisaka-a1c192e3.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Type38Arisaka_Wep_Scope", new Dictionary<string, string>(){ {"name", "Type 38 Arisaka Patrol"}, {"shortName", "Type38 XL"}, {"image", "https://cdn.gametools.network/weapons/bf1/Type38Arisaka-a1c192e3.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_CarcanoCarbine", new Dictionary<string, string>(){ {"name", "Carcano M91 Carbine"}, {"shortName", "M91 KBQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/M1891CarcanoCarbine-cc7d34a1.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_CarcanoCarbine_Wep_Scope", new Dictionary<string, string>(){ {"name", "Carcano M91 Patrol Carbine"}, {"shortName", "M91 KBQ XL"}, {"image", "https://cdn.gametools.network/weapons/bf1/M1891CarcanoCarbine-cc7d34a1.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_RossMkIII", new Dictionary<string, string>(){ {"name", "Ross MkIII Infantry"}, {"shortName", "RossMkIII BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Ross_Mk3-f8900bf5.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_RossMkIII_Wep_Scope", new Dictionary<string, string>(){ {"name", "Ross MkIII Marksman"}, {"shortName", "RossMkIII SSS"}, {"image", "https://cdn.gametools.network/weapons/bf1/Ross_Mk3-f8900bf5.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Enfield1917", new Dictionary<string, string>(){ {"name", "M1917 Enfield Infantry"}, {"shortName", "M1917 BB"}, {"image", "https://cdn.gametools.network/weapons/bf1/Enfield1917-d33fc14d.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_Enfield1917_Wep_LongRange", new Dictionary<string, string>(){ {"name", "M1917 Enfield Silenced"}, {"shortName", "M1917 XYQ"}, {"image", "https://cdn.gametools.network/weapons/bf1/Enfield1917-d33fc14d.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Scout"}}},
                {"U_MarsAutoPistol", new Dictionary<string, string>(){ {"name", "Mars Automatic"}, {"shortName", "MarsAutoPistol"}, {"image", "https://cdn.gametools.network/weapons/bf1/MarsAutoPistol-7f2606e9.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Scout"}}},
                {"U_Bodeo1889", new Dictionary<string, string>(){ {"name", "Bodeo 1889"}, {"shortName", "Bodeo 1889"}, {"image", "https://cdn.gametools.network/weapons/bf1/Bodeo1889-a62282b6.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Scout"}}},
                {"U_FrommerStop", new Dictionary<string, string>(){ {"name", "Frommer Stop"}, {"shortName", "Frommer Stop"}, {"image", "https://cdn.gametools.network/weapons/bf1/FrommerStopAuto-ea5b918e.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "Scout"}}},
                {"U_FlareGun", new Dictionary<string, string>(){ {"name", "Flare Gun - Spot"}, {"shortName", "Flare Gun ZC"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetWebleyScottFlaregun-4438a413.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_FlareGun_Flash", new Dictionary<string, string>(){ {"name", "Flare Gun - Flash"}, {"shortName", "Flare Gun SG"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetWebleyScottFlaregunFlash-40b27cca.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_TrPeriscope", new Dictionary<string, string>(){ {"name", "Trench Periscope"}, {"shortName", "Tr Periscope"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetTrenchPeriscope-d916e58e.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_Shield", new Dictionary<string, string>(){ {"name", "Sniper Shield"}, {"shortName", "Shield"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetShield-9a6f10a4.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_HelmetDecoy", new Dictionary<string, string>(){ {"name", "Sniper Decoy"}, {"shortName", "Helmet Decoy"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetHelmetDecoy-182ae8c4.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_TripWireBomb", new Dictionary<string, string>(){ {"name", "Tripwire - HE"}, {"shortName", "Trip Wire Bomb"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetTripWireGrenade-1618bbc3.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_TripWireGas", new Dictionary<string, string>(){ {"name", "Tripwire - GAS"}, {"shortName", "Trip Wire Gas"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetTripWireBombGas-f1eabac0.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_TripWireBurn", new Dictionary<string, string>(){ {"name", "Tripwire - INC"}, {"shortName", "Trip Wire Burn"}, {"image", "https://cdn.gametools.network/weapons/bf1/TripWireBombINC-6a9a41fb.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"_KBullet", new Dictionary<string, string>(){ {"name", "K Bullets"}, {"shortName", "K Bullet"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetKBullets-0ec1f92a.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Scout"}}},
                {"U_MaximMG0815", new Dictionary<string, string>(){ {"name", "MG 08/15"}, {"shortName", "Maxim MG0815"}, {"image", "https://cdn.gametools.network/weapons/bf1/Maxim0815-0879ffaa.png"}, {"type", "primary"}, {"subtype", "lmg"}, {"class", "Elite"}}},
                {"U_VillarPerosa", new Dictionary<string, string>(){ {"name", "Villar Perosa"}, {"shortName", "Villar Perosa"}, {"image", "https://cdn.gametools.network/weapons/bf1/VillarPerosa-4ba7d141.png"}, {"type", "primary"}, {"subtype", "smg"}, {"class", "Elite"}}},
                {"U_FlameThrower", new Dictionary<string, string>(){ {"name", "Wex"}, {"shortName", "Wex"}, {"image", "https://cdn.gametools.network/weapons/bf1/WEXFlammenwerfer-13f2b3af.png"}, {"type", "primary"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"U_Incendiary_Hero", new Dictionary<string, string>(){ {"name", "Incendiary"}, {"shortName", "Incendiary Hero"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetIncindiary-68d49a3a.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"U_RoyalClub", new Dictionary<string, string>(){ {"name", "Trench Club"}, {"shortName", "Royal Club"}, {"image", "https://cdn.gametools.network/weapons/bf1/Steelclub-83b053cf.png"}, {"type", "primary"}, {"subtype", "melee"}, {"class", "Elite"}}},
                {"U_MartiniGrenadeLauncher", new Dictionary<string, string>(){ {"name", "Martini Grenade Launcher"}, {"shortName", "Martini GL"}, {"image", "https://cdn.gametools.network/weapons/bf1/MartiniHenryGrenadeLauncher-65e27bf0.png"}, {"type", "primary"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"U_SawnOffShotgun_FK", new Dictionary<string, string>(){ {"name", "Sawn Off Shotgun"}, {"shortName", "SawnOffShotgun"}, {"image", "https://cdn.gametools.network/weapons/bf1/SawedOfShotgun-d31e0dd8.png"}, {"type", "secondary"}, {"subtype", "shotgun"}, {"class", "Elite"}}},
                {"U_FlareGun_Elite", new Dictionary<string, string>(){ {"name", "Flare Gun Artillerie"}, {"shortName", "FlareGun Elite"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetWebleyScottFlaregunFlash-40b27cca.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"U_SpawnBeacon", new Dictionary<string, string>(){ {"name", "Spawn Beacon"}, {"shortName", "Spawn Beacon"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetHeliograph-66004cd6.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"U_TankGewehr", new Dictionary<string, string>(){ {"name", "Tank Gewehr"}, {"shortName", "Tank Gewehr"}, {"image", "https://cdn.gametools.network/weapons/bf1/MauserTankgewehr1918-aedf4c56.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Elite"}}},
                {"U_TrPeriscope_Elite", new Dictionary<string, string>(){ {"name", "Periscope"}, {"shortName", "Tr Periscope"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetTrenchPeriscope-d916e58e.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"U_ATGrenade_VhKit", new Dictionary<string, string>(){ {"name", "Anti-Tank Grenade"}, {"shortName", "AT Grenade"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetATGrenade-4b135d46.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Elite"}}},
                {"ID_P_VNAME_MARKV", new Dictionary<string, string>(){ {"name", "Mark V Landship"}, {"shortName", "Mark V"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRMarkV-bf3b1d1a.png"}, {"type", "tank"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_A7V", new Dictionary<string, string>(){ {"name", "A7V Heavy Tank"}, {"shortName", "AV7"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GERA7V-bfc09237.png"}, {"type", "tank"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_FT17", new Dictionary<string, string>(){ {"name", "FT-17 Light Tank"}, {"shortName", "FT-17"}, {"image", "https://cdn.gametools.network/vehicles/bf1/FRARenaultFt-17-aea9e5e7.png"}, {"type", "tank"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_ARTILLERYTRUCK", new Dictionary<string, string>(){ {"name", "Artillery Truck"}, {"shortName", "ARTILLERYTRUCK"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRPierceArrowAALorry-6e6d8d9f.png"}, {"type", "tank"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_STCHAMOND", new Dictionary<string, string>(){ {"name", "St Chamond"}, {"shortName", "STCHAMOND"}, {"image", "https://cdn.gametools.network/vehicles/bf1/FRAStChamond-3123e0cd.png"}, {"type", "tank"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_ASSAULTTRUCK", new Dictionary<string, string>(){ {"name", "Putilov Garford"}, {"shortName", "ASSAULTTRUCK"}, {"image", "https://cdn.gametools.network/vehicles/bf1/PutilovGarford-20a4fd91.png"}, {"type", "tank"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_HALBERSTADT", new Dictionary<string, string>(){ {"name", "Halberstadt CL. II Attack Plane"}, {"shortName", "HALBERSTADT"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GERHalberstadtCLII-c1cb8257.png"}, {"type", "plane"}, {"subtype", "attack plane"}, {"class", null}}},
                {"ID_P_VNAME_BRISTOL", new Dictionary<string, string>(){ {"name", "Bristol F2.B Attack Plane"}, {"shortName", "BRISTOL"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRBristolF2B-141b8daa.png"}, {"type", "plane"}, {"subtype", "attack plane"}, {"class", null}}},
                {"ID_P_VNAME_SALMSON", new Dictionary<string, string>(){ {"name", "A.E.F 2-A2 Attack Plane"}, {"shortName", "SALMSON"}, {"image", "https://cdn.gametools.network/vehicles/bf1/FRA_Salmson_2-05f47b5c.png"}, {"type", "plane"}, {"subtype", "attack plane"}, {"class", null}}},
                {"ID_P_VNAME_RUMPLER", new Dictionary<string, string>(){ {"name", "Rumpler C.I Attack Plane"}, {"shortName", "RUMPLER"}, {"image", "https://cdn.gametools.network/vehicles/bf1/AHU_Rumpler_CI-eb45a6be.png"}, {"type", "plane"}, {"subtype", "attack plane"}, {"class", null}}},
                {"ID_P_VNAME_GOTHA", new Dictionary<string, string>(){ {"name", "Gotha G.IV Bomber"}, {"shortName", "GOTHA"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GERGothaGIV-54bfb0bf.png"}, {"type", "plane"}, {"subtype", "bomber"}, {"class", null}}},
                {"ID_P_VNAME_CAPRONI", new Dictionary<string, string>(){ {"name", "Caproni CA.5 Bomber"}, {"shortName", "CAPRONI"}, {"image", "https://cdn.gametools.network/vehicles/bf1/ITACaproniCa5-31fc77c8.png"}, {"type", "plane"}, {"subtype", "bomber"}, {"class", null}}},
                {"ID_P_VNAME_DH10", new Dictionary<string, string>(){ {"name", "Airco DH.10"}, {"shortName", "DH10"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBR_Airco_DH10-05e772e8.png"}, {"type", "plane"}, {"subtype", "bomber"}, {"class", null}}},
                {"ID_P_VNAME_HBG1", new Dictionary<string, string>(){ {"name", "Hansa-Brandenburg G.I"}, {"shortName", "HBG1"}, {"image", "https://cdn.gametools.network/vehicles/bf1/AHU_Hansa_Brandenburg_GI-042fc3dc.png"}, {"type", "plane"}, {"subtype", "bomber"}, {"class", null}}},
                {"ID_P_VNAME_SPAD", new Dictionary<string, string>(){ {"name", "SPAD S XIII Fighter"}, {"shortName", "SPAD S XIII"}, {"image", "https://cdn.gametools.network/vehicles/bf1/FRA_SPAD_X_XIII-8f60a194.png"}, {"type", "plane"}, {"subtype", "fighter"}, {"class", null}}},
                {"ID_P_VNAME_SOPWITH", new Dictionary<string, string>(){ {"name", "Sopwith Camel Fighter"}, {"shortName", "SOPWITH"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRSopwithCamel-39d664a3.png"}, {"type", "plane"}, {"subtype", "fighter"}, {"class", null}}},
                {"ID_P_VNAME_DR1", new Dictionary<string, string>(){ {"name", "DR.1 Fighter"}, {"shortName", "DR1"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GERFokkerDR1-14f95745.png"}, {"type", "plane"}, {"subtype", "fighter"}, {"class", null}}},
                {"ID_P_VNAME_ALBATROS", new Dictionary<string, string>(){ {"name", "Albatros DIII Fighter"}, {"shortName", "ALBATROS"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GER_Albatros_DIII-5ca9e1d3.png"}, {"type", "plane"}, {"subtype", "fighter"}, {"class", null}}},
                {"ID_P_VNAME_ILYAMUROMETS", new Dictionary<string, string>(){ {"name", "Heavy Bomber - Ilya Muromets"}, {"shortName", "ILYAMUROMETS"}, {"image", "https://cdn.gametools.network/vehicles/bf1/IlyaMurometsHeavyBomber-74779164.png"}, {"type", "plane"}, {"subtype", "heavy bomber"}, {"class", null}}},
                {"ID_P_VNAME_ASTRATORRES", new Dictionary<string, string>(){ {"name", "C-Class Airship"}, {"shortName", "ASTRATORRES"}, {"image", "https://cdn.gametools.network/vehicles/bf1/AstraTorresAirship-e2148807.png"}, {"type", "plane"}, {"subtype", "heavy bomber"}, {"class", null}}},
                {"ID_P_VNAME_HMS_LANCE", new Dictionary<string, string>(){ {"name", "L Class Destoryer"}, {"shortName", "HMS LANCE"}, {"image", "https://cdn.gametools.network/vehicles/bf1/HMSLancerDestroyer-65317e44.png"}, {"type", "boat"}, {"subtype", "destroyer"}, {"class", null}}},
                {"ID_P_VNAME_HORSE", new Dictionary<string, string>(){ {"name", "Horse"}, {"shortName", "HORSE"}, {"image", "https://cdn.gametools.network/vehicles/bf1/Horse-c07830d0.png"}, {"type", "cavalry"}, {"subtype", null}, {"class", null}}},
                {"U_WinchesterM1895_Horse", new Dictionary<string, string>(){ {"name", "Russian 1895"}, {"shortName", "M1895 Horse"}, {"image", "https://cdn.gametools.network/weapons/bf1/Winchester1895-69d56c0b.png"}, {"type", "primary"}, {"subtype", "sniper"}, {"class", "Cavalry"}}},
                {"U_AmmoPouch_Cav", new Dictionary<string, string>(){ {"name", "Ammo Pouch"}, {"shortName", "Ammo Pouch"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetSmallAmmoPack-5837fde5.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Cavalry"}}},
                {"U_Bandages_Cav", new Dictionary<string, string>(){ {"name", "Bandages"}, {"shortName", "Bandages"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetBandages-1d1fc900.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Cavalry"}}},
                {"U_Grenade_AT_Cavalry", new Dictionary<string, string>(){ {"name", "Light AT Grenade"}, {"shortName", "Grenade AT"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetTrooperATGrenade-a6575030.png"}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "Cavalry"}}},
                {"U_LugerP08_VhKit", new Dictionary<string, string>(){ {"name", "P08"}, {"shortName", "LugerP08 VhKit"}, {"image", "https://cdn.gametools.network/weapons/bf1/LugerP08-7f07aa2d.png"}, {"type", "secondary"}, {"subtype", "pistol"}, {"class", "All"}}},
                {"ID_P_INAME_U_MORTAR", new Dictionary<string, string>(){ {"name", "Special Airburst Mortar"}, {"shortName", "MORTAR"}, {"image", "https://cdn.gametools.network/weapons/bf1/MortarAirburst-77c9647f.png"}, {"type", "special"}, {"subtype", null}, {"class", null}}},
                {"ID_P_INAME_MORTAR_HE", new Dictionary<string, string>(){ {"name", "Special HE Mortar"}, {"shortName", "MORTAR HE"}, {"image", "https://cdn.gametools.network/weapons/bf1/GadgetMortar-84e30045.png"}, {"type", "special"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_MODEL30", new Dictionary<string, string>(){ {"name", "M30 Scout"}, {"shortName", "MODEL30"}, {"image", "https://cdn.gametools.network/vehicles/bf1/USADodgeScoutCar-843c9c16.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_MERCEDES_37", new Dictionary<string, string>(){ {"name", "37/95 Scout"}, {"shortName", "MERCEDES 37"}, {"image", "https://cdn.gametools.network/vehicles/bf1/AHU_Mercedes_37_95-69b407d2.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_BENZ_MG", new Dictionary<string, string>(){ {"name", "KFT Scout"}, {"shortName", "BENZ MG"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GER_Benz_MGCarrier-474daf7b.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_MOTORCYCLE", new Dictionary<string, string>(){ {"name", "MC 18J Sidecar"}, {"shortName", "MOTORCYCLE"}, {"image", "https://cdn.gametools.network/vehicles/bf1/USAHarleyDavidsson18J-27b0d7ef.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_NSU", new Dictionary<string, string>(){ {"name", "MC 3.5HP Sidecar"}, {"shortName", "NSU"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GER_NSU_1914-e1a63515.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_ROLLS", new Dictionary<string, string>(){ {"name", "RNAS Armored Transport"}, {"shortName", "ROLLS"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRRollsRoyceArmoredCar-4c6ccdf0.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_ROMFELL", new Dictionary<string, string>(){ {"name", "Romfell Armored Transport"}, {"shortName", "ROMFELL"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GER_Romfell-79d5be52.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_EHRHARDT", new Dictionary<string, string>(){ {"name", "EV4 Armored Transport"}, {"shortName", "EHRHARDT"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GER_Ehrhardt_EV4-1e718572.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_TERNI", new Dictionary<string, string>(){ {"name", "F.T. Scout"}, {"shortName", "TERNI"}, {"image", "https://cdn.gametools.network/vehicles/bf1/ITA_Fiat_Terni-3d8076d6.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_MAS15", new Dictionary<string, string>(){ {"name", "Torpedo Boat"}, {"shortName", "MAS15"}, {"image", "https://cdn.gametools.network/vehicles/bf1/ITAMAS-51e28b0e.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_YLIGHTER", new Dictionary<string, string>(){ {"name", "Landing Craft"}, {"shortName", "MAS15"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBR_Y_Lighter-468f2eaa.png"}, {"type", "transport"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_FIELDGUN", new Dictionary<string, string>(){ {"name", "FK 96 Field Gun"}, {"shortName", "FIELDGUN"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GERFk96nA-760d0461.png"}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_TURRET", new Dictionary<string, string>(){ {"name", "HE Auto-Cannon"}, {"shortName", "TURRET"}, {"image", "https://cdn.gametools.network/vehicles/bf1/FRAFortressTurret-9fb165ad.png"}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_AASTATION", new Dictionary<string, string>(){ {"name", "Anti-Air Gun"}, {"shortName", "AASTATION"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRQF1-63882f78.png"}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_INAME_MAXIM", new Dictionary<string, string>(){ {"name", "Mounted Heavy Machine Gun"}, {"shortName", "MAXIM"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRVickers-ea4826ae.png"}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_BL9", new Dictionary<string, string>(){ {"name", "Siege Gun"}, {"shortName", "BL9"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRBL9-0a10176d.png"}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_COASTALBATTERY", new Dictionary<string, string>(){ {"name", "Fortress Gun "}, {"shortName", "COASTALBATTERY"}, {"image", "https://cdn.gametools.network/vehicles/bf1/DagoCoastalArtilleryGun-b4b737b1.png"}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_SK45GUN", new Dictionary<string, string>(){ {"name", "Fortress Gun"}, {"shortName", "SK45GUN"}, {"image", null}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_ZEPPELIN", new Dictionary<string, string>(){ {"name", "Blimp"}, {"shortName", "ZEPPELIN"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GERZeppelinL30-62618731.png"}, {"type", "wellfare"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_ARMOREDTRAIN", new Dictionary<string, string>(){ {"name", "Armored Train"}, {"shortName", "ARMOREDTRAIN"}, {"image", "https://cdn.gametools.network/vehicles/bf1/RUSArmoredTrain-564a4e48.png"}, {"type", "wellfare"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_IRONDUKE", new Dictionary<string, string>(){ {"name", "Dreadnought"}, {"shortName", "IRONDUKE"}, {"image", "https://cdn.gametools.network/vehicles/bf1/GBRHMSIronDuke-3b82016f.png"}, {"type", "wellfare"}, {"subtype", null}, {"class", null}}},
                {"ID_P_VNAME_CHAR", new Dictionary<string, string>(){ {"name", "Char 2C"}, {"shortName", "CHAR"}, {"image", "https://cdn.gametools.network/vehicles/bf1/FRAChar2C-b8f3c0e2.png"}, {"type", "wellfare"}, {"subtype", null}, {"class", null}}},
                {"U_GrenadeClub", new Dictionary<string, string>(){ {"name", "Dud Stick"}, {"shortName", "Grenade Club"}, {"image", null}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"U_Club", new Dictionary<string, string>(){ {"name", "stick"}, {"shortName", "Club"}, {"image", null}, {"type", "stationary"}, {"subtype", null}, {"class", null}}},
                {"U_GasMask", new Dictionary<string, string>(){ {"name", "Gas Mask"}, {"shortName", "Gas Mask"}, {"image", null}, {"type", "equipment"}, {"subtype", "gadget"}, {"class", "All"}}}
            };

            if (item != null && items.TryGetValue(item, out Dictionary<string, string> result))
            {
                result.Add("id", item);
                return result;
            }
            return new Dictionary<string, string>() { { "id", item }, { "name", null }, { "shortName", null }, { "image", null }, { "type", null }, { "subtype", null }, { "class", null } };
        }
    }
}
