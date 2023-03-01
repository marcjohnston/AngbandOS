using System.Reflection;

namespace AngbandOS.Core
{
    internal static class Constants
    {
        public const int BreakYellowSign = 99;
        public const int BthPlusAdj = 3;
        public const int ConsoleHeight = 45;
        public const int ConsoleWidth = 80;
        public const int EnchToac = 0x04;
        public const int EnchTodam = 0x02;
        public const int EnchTohit = 0x01;
        public const int FollowDistance = 4;
        public const int FuelLamp = 15000;
        public const int FuelTorch = 5000;
        public const int GenerateChoose = 0;
        public const int GenerateRandom = 1;
        public const int GenerateReplay = 2;
        public const int GreatObj = 20; // This is a 1-in-chance of getting great gold or a great object.
        public const int GroupMax = 32;

        public const int KeymapModeOrig = 0;
        public const int KeymapModeRogue = 1;
        public const int KeymapModes = 2;

        /// <summary>
        /// Returns the maximum number of grid tiles that can be lit at one time.
        /// </summary>
        public const int LightMax = 128;
        public const int MaKnee = 1;
        public const int MaSlow = 2;
        public const int MaxAmulets = 17;
        public const int MaxCaves = 20;
        public const int MaxClass = 16;
        public const int MaxColors = 66;
        public const int MaxDepth = 128;
        public const int MaxGenders = 3;
        public const int MaxMa = 17;
        public const int MaxMAllocChance = 160;
        public const int MaxMetals = 39;
        public const int MaxMIdx = 512;
        public const int MaxMindcraftPowers = 12;
        public const int MaxOIdx = 256;
        public const int MaxPatron = 16;
        public const int MaxRange = 18;
        public const int MaxRealm = 8;
        public const int MaxRepro = 100;
        public const int MaxShort = 32767;
        public const int MaxShroom = 20;
        public const int MaxSight = 20;
        public const int MaxStackSize = 100;
        public const int MaxStoresTotal = 96;
        public const int MaxNumberOfScrollFlavoursGenerated = 54;
        public const int MaxUchar = 255;
        public const int MaxWoods = 32;
        public const int MflagBorn = 0x10;
        public const int MflagMark = 0x80;
        public const int MflagNice = 0x20;
        public const int MflagShow = 0x40;
        public const int MflagView = 0x01;
        public const int MinMAllocLevel = 14;
        public const int MinMAllocTd = 4;
        public const int MinMAllocTn = 8;
        public const int MonDrainLife = 2;
        public const int MonMultAdj = 8;
        public const int MonsterFlowDepth = 32;
        public const int MonSummonAdj = 2;
        public const int NastyMon = 50;
        public const int ObjGoldList = 480;
        public const int PenetrateInvulnerability = 13;
        public const uint PnCombine = 0x00000001;
        public const uint PnReorder = 0x00000002;
        public const int PyFoodAlert = 2000;
        public const int PyFoodFaint = 500;
        public const int PyFoodFull = 10000;
        public const int PyFoodMax = 15000;
        public const int PyFoodStarve = 100;
        public const int PyFoodWeak = 1000;
        public const int PyMaxExp = 99999999;
        public const int PyMaxGold = 999999999;
        public const int PyMaxLevel = 50;
        public const int PyRegenFaint = 33;
        public const int PyRegenHpbase = 1442;
        public const int PyRegenMnbase = 524;
        public const int PyRegenNormal = 197;
        public const int PyRegenWeak = 98;
        public const int RoadDown = 0x04;
        public const int RoadLeft = 0x01;
        public const int RoadRight = 0x08;
        public const int RoadUp = 0x02;
        public const int ScreenHgt = 42;
        public const int ScreenWid = 66;
        public const int SexFemale = 0;
        public const int SexMale = 1;
        public const int StoreObjLevel = 5;
        public const int StoreShuffle = 21;
        public const int TargetGrid = 0x08;
        public const int TargetKill = 0x01;
        public const int TargetLook = 0x02;
        public const int TargetXtra = 0x04;
        public const int TempMax = 1536;
        public const int TextACursedSize = 50;
        public const int TextAHighSize = 66;
        public const int TextALowSize = 85;
        public const int TextAMedSize = 84;
        public const int TextElvishSize = 216;
        public const int TextWCursedSize = 39;
        public const int TextWHighSize = 87;
        public const int TextWLowSize = 98;
        public const int TextWMedSize = 106;
        public const int TurnsInADay = 108000;
        public const int TurnsInAHalfDay = TurnsInADay / 2;
        public const int UseDevice = 3;
        public const int ViewMax = 1536;
        public const int WeirdLuck = 12;
        public const int WildernessHeight = 44;
        public const int WildernessWidth = 66;

        public const int DelayFactorInMilliseconds = 64;
        public const int HitpointWarn = 2;

        /// <summary>
        /// Spell flags for each book
        /// </summary>
        public static readonly uint[] BookSpellFlags = { 0x000000ff, 0x0000ff00, 0x00ff0000, 0xff000000 };

        public static readonly string[] DescStatNeg = { "weak", "stupid", "naive", "clumsy", "sickly", "ugly" };
        public static readonly string[] DescStatPos = { "strong", "smart", "wise", "dextrous", "healthy", "cute" };

        public static readonly int[] ExtractEnergy =
        {
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* Slow */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-50 */     1,  1,  1,  1,  1,  1,  1,  1,  1,  1,
	/* S-40 */     2,  2,  2,  2,  2,  2,  2,  2,  2,  2,
	/* S-30 */     2,  2,  2,  2,  2,  2,  2,  3,  3,  3,
	/* S-20 */     3,  3,  3,  3,  3,  4,  4,  4,  4,  4,
	/* S-10 */     5,  5,  5,  5,  6,  6,  7,  7,  8,  9,
	/* Norm */    10, 11, 12, 13, 14, 15, 16, 17, 18, 19,
	/* F+10 */    20, 21, 22, 23, 24, 25, 26, 27, 28, 29,
	/* F+20 */    30, 31, 32, 33, 34, 35, 36, 36, 37, 37,
	/* F+30 */    38, 38, 39, 39, 40, 40, 40, 41, 41, 41,
	/* F+40 */    42, 42, 42, 43, 43, 43, 44, 44, 44, 44,
	/* F+50 */    45, 45, 45, 45, 45, 46, 46, 46, 46, 46,
	/* F+60 */    47, 47, 47, 47, 47, 48, 48, 48, 48, 48,
	/* F+70 */    49, 49, 49, 49, 49, 49, 49, 49, 49, 49,
	/* Fast */    49, 49, 49, 49, 49, 49, 49, 49, 49, 49
        };

        public static readonly int[] PlayerExp =
        {
            10, 25, 45, 70, 100, 140, 200, 280, 380, 500, 650, 850, 1100, 1400, 1800, 2300, 2900, 3600, 4400, 5400,
            6800, 8400, 10200, 12500, 17500, 25000, 35000, 50000, 75000, 100000, 150000, 200000, 275000, 350000, 450000,
            550000, 700000, 850000, 1000000, 1250000, 1500000, 1800000, 2100000, 2400000, 2700000, 3000000, 3500000,
            4000000, 4500000, 5000000
        };

        public static readonly string[] StatNames = { "STR: ", "INT: ", "WIS: ", "DEX: ", "CON: ", "CHA: " };

        public static readonly string[] StatNamesReduced = { "str: ", "int: ", "wis: ", "dex: ", "con: ", "cha: " };

        public static readonly string[] SymbolIdentification =
                                                                {
            " :A dark grid", "!:A potion (or oil)", "\":An amulet (or necklace)", "#:A wall (or secret door)",
            "$:Treasure (gold or gems)", "%:A vein (magma or quartz)", "&:Entrance to Inn", "':An open door",
            "(:Soft armour", "):A shield", "*:A vein with treasure", "+:A closed door", ",:Food (or mushroom patch)",
            "-:A wand (or rod)", ".:Floor", "/:A polearm (Axe/Pike/etc)", "0:Entrance to Pawnbrokers",
            "1:Entrance to General Store", "2:Entrance to Armoury", "3:Entrance to Weaponsmith", "4:Entrance to Temple",
            "5:Entrance to Alchemy shop", "6:Entrance to Magic Stores", "7:Entrance to Black Market",
            "8:Entrance to Hall of Records", "9:Entrance to Bookstore", "::Rubble",
            ";:An Elder Sign / Yellow Sign", "<:An up staircase", "=:A ring", ">:A down staircase",
            "?:A scroll", "@:You (or the entrance to your home)", "A:Abomination", "B:Bird", "C:Canine",
            "D:Ancient Dragon/Wyrm", "E:Elemental", "F:Dragon Fly", "G:Ghost", "H:Hybrid", "I:Insect", "J:Snake",
            "K:Killer Beetle", "L:Lich", "M:Multi-Headed Reptile", "O:Ogre", "P:Giant Humanoid",
            "Q:Quylthulg (Pulsing Flesh Mound)", "R:Reptile/Amphibian", "S:Spider/Scorpion/Tick", "T:Troll",
            "U:Major Demon", "V:Vampire", "W:Wight/Wraith/etc", "X:Extradimensional Entity", "Y:Yeti", "Z:Zephyr Hound",
            "[:Hard armour", "\\:A hafted weapon (mace/whip/etc)", "]:Misc. armour", "^:A trap", "_:A staff", "a:Ant",
            "b:Bat", "c:Centipede", "d:Dragon", "e:Floating Eye", "f:Feline", "g:Golem", "h:Hobbit/Elf/Dwarf",
            "i:Icky Thing", "j:Jelly", "k:Kobold", "l:Louse", "m:Mold", "n:Naga", "o:Orc", "p:Person/Human",
            "q:Quadruped", "r:Rodent", "s:Skeleton", "t:Townsperson", "u:Minor Demon", "v:Vortex", "w:Worm/Worm-Mass",
            "x:Xorn/Xaren/etc", "y:Yeek", "z:Zombie/Mummy", "{:A missile (arrow/bolt/shot)", "|:An edged weapon (sword/dagger/etc)",
            "}:A launcher (bow/crossbow/sling)", "~:A tool (or miscellaneous item)", null
        };

        public static readonly int VersionMajor = Assembly.GetExecutingAssembly().GetName().Version.Major;
        public static readonly int VersionMinor = Assembly.GetExecutingAssembly().GetName().Version.Minor;
        public static readonly int VersionBuild = Assembly.GetExecutingAssembly().GetName().Version.Build;
        public static readonly string VersionName = Assembly.GetExecutingAssembly().GetName().Name;
        public static readonly string VersionStamp = $"Version {VersionMajor}.{VersionMinor}.{VersionBuild}";
    }
}