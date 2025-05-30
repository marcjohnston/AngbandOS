// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Configuration;
using System.Text.Json;

namespace AngbandOS.Core;

[Serializable]
internal class Tile : IGetKey
{
    protected Game Game;
    public Tile(Game game, TileGameConfiguration tileGameConfiguration)
    {
        Game = game;
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

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        TileGameConfiguration tileDefinition = new TileGameConfiguration()
        {
            AllowMonsterToOccupy = AllowMonsterToOccupy,
            AlterActionName = AlterActionName,
            BlocksLos = BlocksLos,
            BlocksScent = BlocksScent,
            CanBeClosed = CanBeClosed,
            Color = Color,
            Description = Description,
            DimsOutsideLOS = DimsOutsideLOS,
            HasWater = HasWater,
            HiddenTreasureForTileName = HiddenTreasureForTileName,
            IsBasicWall = IsBasicWall,
            IsBorder = IsBorder,
            IsBrokenDoor = IsBrokenDoor,
            IsBush = IsBush ,
            IsClosedDoor = IsClosedDoor,
            IsDownStaircase = IsDownStaircase,
            IsEarthquakeResistant = IsEarthquakeResistant,
            IsElderSignSigil = IsElderSignSigil,
            IsGrass = IsGrass,
            IsInteresting = IsInteresting,
            IsInvisibleTrap = IsInvisibleTrap,
            IsJammedClosedDoor = IsJammedClosedDoor,
            IsMagma = IsMagma,
            IsOpenDoor = IsOpenDoor,
            IsOpenFloor = IsOpenFloor,
            IsPassable = IsPassable,
            IsPath = IsPath,
            IsPathBase = IsPathBase,
            IsPermanent = IsPermanent,
            IsPillar = IsPillar,
            IsRevealedWithDetectStairsScript = IsRevealedWithDetectStairsScript,
            IsRock = IsRock,
            IsRubble = IsRubble,
            IsSecretDoor = IsSecretDoor,
            IsShop = IsShop,
            IsTrap = IsTrap,
            IsTrapDoor = IsTrapDoor,
            IsTreasure = IsTreasure,
            IsTree = IsTree,
            IsUnidentifiedTrap = IsUnidentifiedTrap,
            IsUpStaircase = IsUpStaircase,
            IsVein = IsVein,
            IsVisibleDoor = IsVisibleDoor,
            IsVisibleTreasure = IsVisibleTreasure,
            IsWall = IsWall,
            IsWallOuter = IsWallOuter,
            IsWallPermanentOuter = IsWallPermanentOuter,
            IsWallPermanentSolid = IsWallPermanentSolid,
            IsWallSolid = IsWallSolid,
            IsWater = IsWater,
            IsWildPath = IsWildPath,
            IsYellowSignSigil = IsYellowSignSigil,
            Key = Key,
            LockLevel = LockLevel,
            MapPriority = MapPriority,
            MimicTileName = MimicTileName,
            OnJammedTileName = OnJammedTileName,
            RunPast = RunPast,
            StepOnScriptName = StepOnScriptName,
            SymbolName = SymbolName,
            VisibleTreasureForTileName = VisibleTreasureForTileName,
            YellowInTorchlight = YellowInTorchlight,
        };
        return JsonSerializer.Serialize(tileDefinition, Game.GetJsonSerializerOptions());
    }
    public string GetKey => Key;
    public void Bind()
    {
        AlterAction = AlterActionName == null ? null : Game.SingletonRepository.Get<AlterAction>(AlterActionName);
        HiddenTreasureForTile = HiddenTreasureForTileName == null ? null : Game.SingletonRepository.Get<Tile>(HiddenTreasureForTileName);
        MimicTile = MimicTileName == null ? null : Game.SingletonRepository.Get<Tile>(MimicTileName);
        OnJammedTile = OnJammedTileName == null ? null : Game.SingletonRepository.Get<Tile>(OnJammedTileName);
        StepOnScript = StepOnScriptName == null ? null : Game.SingletonRepository.Get<IScript>(StepOnScriptName);
        Symbol = Game.SingletonRepository.Get<Symbol>(SymbolName);
        VisibleTreasureForTile = VisibleTreasureForTileName == null ? null : Game.SingletonRepository.Get<Tile>(VisibleTreasureForTileName);
    }
    public override string ToString()
    {
        return GetKey;
    }

    #region Bound Properties
    /// <summary>
    /// Returns a single action to perform on the tile.
    /// </summary>
    public AlterAction? AlterAction { get; private set; }

    public Tile? HiddenTreasureForTile { get; private set; }

    /// <summary>
    /// The tile this tile should appear as when looked at; or null, if this tile is invisible/transparent.  Non-transparent, non-mimicing
    /// tiles will return themself.  Mimicing tiles will return a different tile.  Transparent tile that are considered invisible
    /// will return null.  Invisible tiles will render the background feature.
    /// </summary>
    public Tile? MimicTile { get; private set; }
    public Tile? OnJammedTile { get; protected set; }

    /// <summary>
    /// Returns the script to run when the player steps on the tile; or null, if no script should run.  This property is bound from the StepOnScriptName property during
    /// the binding phase.
    /// </summary>
    public IScript? StepOnScript { get; private set; }

    /// <summary>
    /// Returns the symbol to use for rendering.  This property is bound from the SymbolName property during binding.
    /// </summary>
    public Symbol Symbol { get; private set; }
    public Tile? VisibleTreasureForTile { get; protected set; }
    #endregion

    #region Light-weight Virtual Properties
    /// <summary>
    /// Returns true, if the tile allows a monster to occupy it.  Returns true, by default.  YellowSignSigils and ElderSignSigils return false.
    /// </summary>
    public virtual bool AllowMonsterToOccupy { get; } = true;

    protected virtual string? AlterActionName { get; } = null;

    /// <summary>
    /// The tile blocks line of sight.
    /// </summary>
    public virtual bool BlocksLos { get; } = false;

    /// <summary>
    /// Returns true, if the tile type blocks the scent trail.  Defaults to return true, if the tile type blocks line of sight; false, otherwise.  Secret doors typically block line of sight but will allow
    /// the scent to pass through.
    /// </summary>
    public virtual bool? BlocksScent { get; } = null;

    public virtual bool CanBeClosed { get; } = false;

    /// <summary>
    /// Returns the color to render the tile as.  Returns white, by default.
    /// </summary>
    public virtual ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual string Description { get; }

    /// <summary>
    /// The the tile this one should appear to be when looked at.
    /// </summary>
    public virtual bool DimsOutsideLOS { get; } = false;

    /// <summary>
    /// Returns true, if the tile has water; false, otherwise.  Returns false, by default.  The WaterBorder and the Water tiles both return true.
    /// </summary>
    public virtual bool HasWater { get; } = false;

    /// <summary>
    /// Returns null, if the tile type is not a hidden treasure; otherwise, when the tile is a hidden treasure, the visible tile type is returned.
    /// </summary>
    protected virtual string? HiddenTreasureForTileName { get; } = null;

    /// <summary>
    /// The tile is a basic (not permanent) dungeon wall.
    /// </summary>
    public virtual bool IsBasicWall { get; } = false;

    public virtual bool IsBorder { get; } = false;

    public virtual bool IsBrokenDoor { get; } = false;

    public virtual bool IsBush { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a closed door.  Returns false, by default.  Locked doors all return true.  Jammed doors return false.  Returns false, by default.
    /// </summary>
    public virtual bool IsClosedDoor { get; } = false;

    /// <summary>
    /// The tile is a down staircase.
    /// </summary>
    public virtual bool IsDownStaircase { get; } = false;

    /// <summary>
    /// Returns true, if the tile is not affected by an earthquake.  The Elder Sigil and Yellow Sigil tiles return true.
    /// </summary>
    public virtual bool IsEarthquakeResistant { get; } = false;

    public virtual bool IsElderSignSigil { get; } = false;

    /// <summary>
    /// The tile is grass.
    /// </summary>
    public virtual bool IsGrass { get; } = false;

    /// <summary>
    /// The tile is 'interesting' and should be noticed when the player looks around.
    /// </summary>
    public virtual bool IsInteresting { get; } = false;

    public virtual bool IsInvisibleTrap { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a door that is jammed closed.  Returns false, by default.  Jammed doors all return true.
    /// </summary>
    public virtual bool IsJammedClosedDoor { get; } = false;

    public virtual bool IsMagma { get; } = false;

    /// <summary>
    /// Returns true, if the tile is an open door.  Returns false, by default.  Open and broken doors returns true.
    /// </summary>
    public virtual bool IsOpenDoor { get; } = false;

    /// <summary>
    /// The tile is open floor safe to drop items on.
    /// </summary>
    public virtual bool IsOpenFloor { get; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual bool IsPassable { get; } = false;
    
    /// <summary>
    /// Returns true for all path tiles; false, otherwise.  Returns false, by default.  PathBase, PathBorderEW, PathBorderNS, PathEW, PathJunction and PathNS return true.
    /// </summary>
    public virtual bool IsPath { get; } = false;
    public virtual bool IsPathBase { get; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual bool IsPermanent { get; } = false;

    public virtual bool IsPillar { get; } = false;

    /// <summary>
    /// Returns true, if the tile should be revealed with the detect stairs script.  Returns false, by default.  UpStairs and DownStairs tiles return true.
    /// </summary>
    public virtual bool IsRevealedWithDetectStairsScript { get; } = false;

    /// <summary>
    /// The tile is rock.
    /// </summary>
    public virtual bool IsRock { get; } = false;

    /// <summary>
    /// Returns true, if the tile is rubble.  Returns false, by default.  The RubbleTile returns true.
    /// </summary>
    public virtual bool IsRubble { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a secret door.  Returns false, by default.  Secret doors return true.
    /// </summary>
    public virtual bool IsSecretDoor { get; } = false;

    /// <summary>
    /// The tile is a shop entrance.
    /// </summary>
    public virtual bool IsShop { get; } = false;

    /// <summary>
    /// The tile is a known trap.
    /// </summary>
    public virtual bool IsTrap { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a trap door.  Returns false, by default.  Trap doors all return true.
    /// </summary>
    public virtual bool IsTrapDoor { get; } = false;

    public virtual bool IsTreasure { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a tree.  Returns false, by default.  Bush, scarecrow, signpost and tree tiles all return true.
    public virtual bool IsTree { get; } = false;

    /// <summary>
    /// Returns true, if the tile is an unidentified trap.  Returns false, by default.  Invisible traps return true.
    /// </summary>
    public virtual bool IsUnidentifiedTrap { get; } = false;

    /// <summary>
    /// The tile is a up staircase.
    /// </summary>
    public virtual bool IsUpStaircase { get; } = false;

    /// <summary>
    /// Returns true, if the tile is a vein.  Returns false, by default.  Magma hidden treasure, magma, magma visible treasure, 
    /// quartz hidden, quartz and quartz visible treasure tiles all returns true.
    /// </summary>
    public virtual bool IsVein { get; } = false;

    /// <summary>
    /// Returns true for all visible doors (locked and jammed); false, otherwise.  Secret doors return false; all other doors return true.
    /// </summary>
    public virtual bool IsVisibleDoor { get; } = false;

    /// <summary>
    /// Returns true, if the tile type is a visible treasure.  Defaults to false.  Magma and quartz are treasure tile types.
    /// </summary>
    public virtual bool IsVisibleTreasure { get; } = false;

    /// <summary>
    /// The tile is a wall (not including a secret door).
    /// </summary>
    public virtual bool IsWall { get; } = false;

    public virtual bool IsWallOuter { get; } = false;
    public virtual bool IsWallPermanentOuter { get; } = false;
    public virtual bool IsWallPermanentSolid { get; } = false;
    public virtual bool IsWallSolid { get; } = false;

    /// <summary>
    /// The tile is water.
    /// </summary>
    public virtual bool IsWater { get; } = false;

    public virtual bool IsWildPath { get; } = false;
    public virtual bool IsYellowSignSigil { get; } = false;
    public virtual string Key { get; } 

    public virtual int LockLevel { get; } = 0;

    /// <summary>
    /// The name of the tile this tile should appear as when looked at; or null, if this tile is invisible/transparent.  Non-transparent,
    /// non-mimicing tiles will name themself.  Mimicing tiles will return a name for a different tile.  Transparent tile that are
    /// considered invisible will return null.  Invisible tiles will render the background feature.
    /// </summary>
    protected virtual string? MimicTileName { get; } = null; // TODO: Right now, there is nothing that is transparent.  The NULL means, no mimic.
    protected virtual string? OnJammedTileName { get; } = null;

    /// <summary>
    /// The player will run past the tile rather than stopping at it.
    /// </summary>
    public virtual bool RunPast { get; } = false;

    /// <summary>
    /// The priority on the map.
    /// </summary>
    public virtual int MapPriority { get; }

    /// <summary>
    /// Returns the name of the script to run when the player steps on the tile; or null, if no script should run.  This property is bound to the StepOnScript property during
    /// the binding phase.
    /// </summary>
    protected virtual string? StepOnScriptName { get; } = null;

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is bound to the Symbol property during binding.
    /// </summary>
    protected virtual string SymbolName { get; }

    protected virtual string? VisibleTreasureForTileName { get; } = null;

    /// <summary>
    /// The tile this one should appear to be when looked at.
    /// </summary>
    public virtual bool YellowInTorchlight { get; } = false;
    #endregion
}
