// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal static class Constants
{
    public const int BreakYellowSign = 99;
    public const int BthPlusAdj = 3;
    public const int EnchToac = 0x04;
    public const int EnchTodam = 0x02;
    public const int EnchTohit = 0x01;
    public const int FuelLamp = 15000;
    public const int FuelTorch = 5000;
    public const int GreatObj = 20; // This is a 1-in-chance of getting great gold or a great object.
    public const int GroupMax = 32;

    public const int KeymapModeOrig = 0;
    public const int KeymapModes = 2;

    public const int MaxDepth = 128;
    public const int MaxMAllocChance = 160;

    /// <summary>
    /// Returns the maximum number of monsters.
    /// </summary>
    public const int MaxMIdx = 512;
    public const int MaxRange = 18;
    public const int MaxRepro = 100;
    public const int MaxShort = 32767;
    public const int MaxSight = 20;
    public const int MaxStackSize = 100;
    public const int MaxUchar = 255;
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
    public const int PyFoodAlert = 2000; // TODO: This doesn't coincide with the widget
    public const int PyFoodFaint = 500; // TODO: This doesn't coincide with the widget
    public const int PyFoodFull = 10000; // TODO: This doesn't coincide with the widget
    public const int PyFoodMax = 15000; // TODO: This doesn't coincide with the widget
    public const int PyFoodStarve = 100; // TODO: This doesn't coincide with the widget
    public const int PyFoodWeak = 1000; // TODO: This doesn't coincide with the widget
    public const int PyMaxExp = 99999999;
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

    /// <summary>
    /// Returns the number of rows that the screen can accommodate for the playing field.  This is the ConsoleHeight - 3.
    /// </summary>
    public const int PlayableScreenHeight = 42;

    /// <summary>
    /// Returns the number of columns that the screen can accommodate for the playing field.  This is the ConsoleWidth - 14;
    /// </summary>
    public const int PlayableScreenWidth = 66;
    public const int StoreObjLevel = 5;
    public const int StoreShuffle = 21;
    public const int TargetKill = 0x01;
    public const int TargetLook = 0x02;
    public const int TempMax = 1536;
    public const int TurnsInADay = 108000;
    public const int UseDevice = 3;
    public const int WeirdLuck = 12;
    public const int WildernessHeight = 44;
    public const int WildernessWidth = 66;

    public const int DelayFactorInMilliseconds = 64;
    public const int HitpointWarn = 2;
}