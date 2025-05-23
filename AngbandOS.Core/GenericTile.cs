﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericTile : Tile
{
    public GenericTile(Game game, TileGameConfiguration tileGameConfiguration) : base(game)
    {
        AllowMonsterToOccupy = tileGameConfiguration.AllowMonsterToOccupy;
        AlterActionName = tileGameConfiguration.AlterActionName;
        BlocksLos = tileGameConfiguration.BlocksLos;
        BlocksScent = tileGameConfiguration.BlocksScent;
        CanBeClosed = tileGameConfiguration.CanBeClosed;
        Color = tileGameConfiguration.Color;
        Description = tileGameConfiguration.Description;
        DimsOutsideLOS = tileGameConfiguration.DimsOutsideLOS;
        HasWater = tileGameConfiguration.HasWater;
        HiddenTreasureForTileName = tileGameConfiguration.HiddenTreasureForTileName;
        IsBasicWall = tileGameConfiguration.IsBasicWall;
        IsBorder = tileGameConfiguration.IsBorder;
        IsBrokenDoor = tileGameConfiguration.IsBrokenDoor;
        IsBush = tileGameConfiguration.IsBush;
        IsClosedDoor = tileGameConfiguration.IsClosedDoor;
        IsDownStaircase = tileGameConfiguration.IsDownStaircase;
        IsEarthquakeResistant = tileGameConfiguration.IsEarthquakeResistant;
        IsElderSignSigil = tileGameConfiguration.IsElderSignSigil;
        IsGrass = tileGameConfiguration.IsGrass;
        IsInteresting = tileGameConfiguration.IsInteresting;
        IsInvisibleTrap = tileGameConfiguration.IsInvisibleTrap;
        IsJammedClosedDoor = tileGameConfiguration.IsJammedClosedDoor;
        IsMagma = tileGameConfiguration.IsMagma;
        IsOpenDoor = tileGameConfiguration.IsOpenDoor;
        IsOpenFloor = tileGameConfiguration.IsOpenFloor;
        IsPassable = tileGameConfiguration.IsPassable;
        IsPath = tileGameConfiguration.IsPath;
        IsPathBase = tileGameConfiguration.IsPathBase;
        IsPermanent = tileGameConfiguration.IsPermanent;
        IsPillar = tileGameConfiguration.IsPillar;
        IsRevealedWithDetectStairsScript = tileGameConfiguration.IsRevealedWithDetectStairsScript;
        IsRock = tileGameConfiguration.IsRock;
        IsRubble = tileGameConfiguration.IsRubble;
        IsSecretDoor = tileGameConfiguration.IsSecretDoor;
        IsShop = tileGameConfiguration.IsShop;
        IsTrap = tileGameConfiguration.IsTrap;
        IsTrapDoor = tileGameConfiguration.IsTrapDoor;
        IsTreasure = tileGameConfiguration.IsTreasure;
        IsTree = tileGameConfiguration.IsTree;
        IsUnidentifiedTrap = tileGameConfiguration.IsUnidentifiedTrap;
        IsUpStaircase = tileGameConfiguration.IsUpStaircase;
        IsVein = tileGameConfiguration.IsVein;
        IsVisibleDoor = tileGameConfiguration.IsVisibleDoor;
        IsVisibleTreasure = tileGameConfiguration.IsVisibleTreasure;
        IsWall = tileGameConfiguration.IsWall;
        IsWallOuter = tileGameConfiguration.IsWallOuter;
        IsWallPermanentOuter = tileGameConfiguration.IsWallPermanentOuter;
        IsWallPermanentSolid = tileGameConfiguration.IsWallPermanentSolid;
        IsWallSolid = tileGameConfiguration.IsWallSolid;
        IsWater = tileGameConfiguration.IsWater;
        IsWildPath = tileGameConfiguration.IsWildPath;
        IsYellowSignSigil = tileGameConfiguration.IsYellowSignSigil;
        Key = tileGameConfiguration.Key ?? tileGameConfiguration.GetType().Name;
        LockLevel = tileGameConfiguration.LockLevel;
        MapPriority = tileGameConfiguration.MapPriority;
        MimicTileName = tileGameConfiguration.MimicTileName;
        OnJammedTileName = tileGameConfiguration.OnJammedTileName;
        RunPast = tileGameConfiguration.RunPast;
        StepOnScriptName = tileGameConfiguration.StepOnScriptName;
        SymbolName = tileGameConfiguration.SymbolName;
        VisibleTreasureForTileName = tileGameConfiguration.VisibleTreasureForTileName;
        YellowInTorchlight = tileGameConfiguration.YellowInTorchlight;
    }

    public override bool IsEarthquakeResistant { get; } = false;
    public override bool IsYellowSignSigil { get; } = false;
    public override bool CanBeClosed { get; } = false;
    public override bool IsInvisibleTrap { get; } = false;
    public override bool IsPathBase { get; } = false;
    public override bool IsBrokenDoor { get; } = false;
    public override bool IsBush { get; } = false;
    public override bool IsElderSignSigil { get; } = false;
    public override bool IsPillar { get; } = false;

    protected override string? OnJammedTileName { get; }
    protected override string? VisibleTreasureForTileName { get; }

    public override string Key { get; }

    /// <summary>
    /// Returns the name of the script to run when the player steps on the tile; or null, if no script should run.  This property is bound to the StepOnScript property during
    /// the binding phase.
    /// </summary>
    protected override string? StepOnScriptName { get; } = null;

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is bound to the Symbol property during binding.
    /// </summary>
    protected override string SymbolName { get; }

    /// <summary>
    /// Returns the color to render the tile as.  Returns white, by default.
    /// </summary>
    public override ColorEnum Color { get; } = ColorEnum.White;

    public override bool IsWildPath { get; } = false;

    public override bool IsGrass { get; } = false;
    public override bool IsUpStaircase { get; } = false;
    public override bool IsDownStaircase { get; } = false;

    /// <summary>
    /// Returns true for all path tiles; false, otherwise.  Returns false, by default.  PathBase, PathBorderEW, PathBorderNS, PathEW, PathJunction and PathNS return true.
    /// </summary>
    public override bool IsPath { get; } = false;

    public override bool IsTreasure { get; } = false;

    public override bool IsRock { get; } = false;
    public override bool IsWater { get; } = false;

    /// <summary>
    /// Returns true, if the tile type blocks the scent trail.  Defaults to return true, if the tile type blocks line of sight; false, otherwise.  Secret doors typically block line of sight but will allow
    /// the scent to pass through.
    /// </summary>
    public override bool? BlocksScent { get; }

    /// <summary>
    /// Returns null, if the tile type is not a hidden treasure; otherwise, when the tile is a hidden treasure, the visible tile type is returned.
    /// </summary>
    protected override string? HiddenTreasureForTileName { get; } = null;

    /// <summary>
    /// Returns true, if the tile type is a visible treasure.  Defaults to false.  Magma and quartz are treasure tile types.
    /// </summary>
    public override bool IsVisibleTreasure { get; } = false;

    public override bool IsBorder { get; } = false;

    public override bool IsMagma { get; } = false;

    protected override string? AlterActionName { get; } = null;

    /// <summary>
    /// The name of the tile this tile should appear as when looked at; or null, if this tile is invisible/transparent.  Non-transparent,
    /// non-mimicing tiles will name themself.  Mimicing tiles will return a name for a different tile.  Transparent tile that are
    /// considered invisible will return null.  Invisible tiles will render the background feature.
    /// </summary>
    protected override string? MimicTileName { get; } = null; // TODO: Right now, there is nothing that is transparent.  The NULL means, no mimic.

    /// <summary>
    /// The tile blocks line of sight.
    /// </summary>
    public override bool BlocksLos { get; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public override string Description { get; }

    /// <summary>
    /// The the tile this one should appear to be when looked at.
    /// </summary>
    public override bool DimsOutsideLOS { get; } = false;

    /// <summary>
    /// The tile is a basic (not permanent) dungeon wall.
    /// </summary>
    public override bool IsBasicWall { get; } = false;

    /// <summary>
    /// Returns true for all visible doors (locked and jammed); false, otherwise.  Secret doors return false; all other doors return true.
    /// </summary>
    public override bool IsVisibleDoor { get; } = false;

    public override int LockLevel { get; } = 0;

    /// <summary>
    /// The tile is 'interesting' and should be noticed when the player looks around.
    /// </summary>
    public override bool IsInteresting { get; } = false;

    /// <summary>
    /// The tile is open floor safe to drop items on.
    /// </summary>
    public override bool IsOpenFloor { get; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public override bool IsPassable { get; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public override bool IsPermanent { get; } = false;

    /// <summary>
    /// The tile is a shop entrance.
    /// </summary>
    public override bool IsShop { get; } = false;

    /// <summary>
    /// The tile is a known trap.
    /// </summary>
    public override bool IsTrap { get; } = false;

    /// <summary>
    /// The tile is a wall (not including a secret door).
    /// </summary>
    public override bool IsWall { get; } = false;

    public override bool IsWallOuter { get; } = false;
    public override bool IsWallPermanentOuter { get; } = false;
    public override bool IsWallPermanentSolid { get; } = false;
    public override bool IsWallSolid { get; } = false;
    /// <summary>
    /// Returns true, if the tile is water; false, otherwise.  Returns false, by default.  The WaterBorder and the Water tiles both return true.
    /// </summary>
    public override bool HasWater { get; } = false;
    /// <summary>
    /// The priority on the map.
    /// </summary>
    public override int MapPriority { get; }

    /// <summary>
    /// The player will run past the tile rather than stopping at it.
    /// </summary>
    public override bool RunPast { get; } = false;

    /// <summary>
    /// The tile this one should appear to be when looked at.
    /// </summary>
    public override bool YellowInTorchlight { get; } = false;

    /// <summary>
    /// Returns true, if the tile should be revealed with the detect stairs script.  Returns false, by default.  UpStairs and DownStairs tiles return true.
    /// </summary>
    public override bool IsRevealedWithDetectStairsScript { get; } = false;

    /// <summary>
    /// Returns true, if the tile allows a monster to occupy it.  Returns true, by default.  YellowSignSigils and ElderSignSigils return false.
    /// </summary>
    public override bool AllowMonsterToOccupy { get; } = true;

    /// <summary>
    /// Returns true, if the tile is a secret door.  Returns false, by default.  Secret doors return true.
    /// </summary>
    public override bool IsSecretDoor { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a closed door.  Returns false, by default.  Locked doors all return true.  Jammed doors return false.  Returns false, by default.
    /// </summary>
    public override bool IsClosedDoor { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a door that is jammed closed.  Returns false, by default.  Jammed doors all return true.
    /// </summary>
    public override bool IsJammedClosedDoor { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a trap door.  Returns false, by default.  Trap doors all return true.
    /// </summary>
    public override bool IsTrapDoor { get; } = false;

    /// <summary>
    /// Returns true, if the tile is rubble.  Returns false, by default.  Rubble returns true.
    /// </summary>
    public override bool IsRubble { get; } = false;

    /// <summary>
    /// Returns true, if the tile is an open door.  Returns false, by default.  Open and broken doors returns true.
    /// </summary>
    public override bool IsOpenDoor { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a vein.  Returns false, by default.  Magma hidden treasure, magma, magma visible treasure, 
    /// quartz hidden, quartz and quartz visible treasure tiles all returns true.
    /// </summary>
    public override bool IsVein { get; } = false;

    /// <summary>
    /// Returns true, if the tile is an unidentified trap.  Returns false, by default.  Invisible traps return true.
    /// </summary>
    public override bool IsUnidentifiedTrap { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a tree.  Returns false, by default.  Bush, scarecrow, signpost and tree tiles all return true.
    public override bool IsTree { get; } = false;
}
