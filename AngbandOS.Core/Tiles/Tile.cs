// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.Interface.Definitions;
using System.Text.Json;

namespace AngbandOS.Core.Tiles;

[Serializable]
internal abstract class Tile : IGetKey
{
    protected Game Game;
    protected Tile(Game game)
    {
        Game = game;
    }

    public Tile? OnJammedTile { get; protected set; }
    protected virtual string? OnJammedTileName => null;
    public Tile? VisibleTreasureForTile { get; protected set; }
    protected virtual string? VisibleTreasureForTileName => null;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        TileDefinition tileDefinition = new TileDefinition()
        {
            AllowMonsterToOccupy = AllowMonsterToOccupy,
            AlterActionName = AlterActionName,
            BlocksLos = BlocksLos,
            BlocksScent = BlocksScent,
            Color = Color,
            Description = Description,
            DimsOutsideLOS = DimsOutsideLOS,
            HiddenTreasureForTileName = HiddenTreasureForTileName,
            IsBasicWall = IsBasicWall,
            IsBorder = IsBorder,
            IsClosedDoor = IsClosedDoor,
            IsInteresting = IsInteresting,
            IsJammedClosedDoor = IsJammedClosedDoor,
            IsMagma = IsMagma,
            IsOpenDoor = IsOpenDoor,
            IsOpenFloor = IsOpenFloor,
            IsPassable = IsPassable,
            IsPath = IsPath,
            IsPermanent = IsPermanent,
            IsRevealedWithDetectStairsScript = IsRevealedWithDetectStairsScript,
            IsRubble = IsRubble,
            IsSecretDoor = IsSecretDoor,
            IsShop = IsShop,
            IsTrap = IsTrap,
            IsTrapDoor = IsTrapDoor,
            IsTreasure = IsTreasure,
            IsTree = IsTree,
            IsUnidentifiedTrap = IsUnidentifiedTrap,
            IsVein = IsVein,
            IsVisibleDoor = IsVisibleDoor,
            IsVisibleTreasure = IsVisibleTreasure,
            IsWall = IsWall,
            IsWater = IsWater,
            IsWildPath = IsWildPath,
            Key = Key,
            LockLevel = LockLevel,
            MapPriority = MapPriority,
            MimicTileName = MimicTileName,
            RunPast = RunPast,
            StepOnScriptName = StepOnScriptName,
            SymbolName = SymbolName,
            YellowInTorchlight = YellowInTorchlight
        };
        return JsonSerializer.Serialize<TileDefinition>(tileDefinition);
    }
    public virtual string Key => GetType().Name;
    public string GetKey => Key;
    public void Bind()
    {
        MimicTile = MimicTileName == null ? null : Game.SingletonRepository.Tiles.Get(MimicTileName);
        HiddenTreasureForTile = HiddenTreasureForTileName == null ? null : Game.SingletonRepository.Tiles.Get(HiddenTreasureForTileName);
        OnJammedTile = OnJammedTileName == null ? null : Game.SingletonRepository.Tiles.Get(OnJammedTileName);
        VisibleTreasureForTile = VisibleTreasureForTileName == null ? null : Game.SingletonRepository.Tiles.Get(VisibleTreasureForTileName);
        AlterAction = AlterActionName == null ? null : Game.SingletonRepository.AlterActions.Get(AlterActionName);
        Symbol = Game.SingletonRepository.Symbols.Get(SymbolName);
        StepOnScript = StepOnScriptName == null ? null : (IScript)Game.SingletonRepository.Scripts.Get(StepOnScriptName);
    }

    /// <summary>
    /// Returns the script to run when the player steps on the tile; or null, if no script should run.  This property is bound from the StepOnScriptName property during
    /// the binding phase.
    /// </summary>
    public IScript? StepOnScript { get; private set; }

    /// <summary>
    /// Returns the name of the script to run when the player steps on the tile; or null, if no script should run.  This property is bound to the StepOnScript property during
    /// the binding phase.
    /// </summary>
    protected virtual string? StepOnScriptName => null;

    /// <summary>
    /// Returns the symbol to use for rendering.  This property is bound from the SymbolName property during binding.
    /// </summary>
    public Symbol Symbol { get; private set; }

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is bound to the Symbol property during binding.
    /// </summary>
    protected abstract string SymbolName { get; }

    /// <summary>
    /// Returns the color to render the tile as.  Returns white, by default.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    public virtual bool IsWildPath => false;
    
    /// <summary>
    /// Returns true for all path tiles; false, otherwise.  Returns false, by default.  PathBase, PathBorderEW, PathBorderNS, PathEW, PathJunction and PathNS return true.
    /// </summary>
    public virtual bool IsPath => false;

    public virtual bool IsTreasure => false;

    /// <summary>
    /// Returns true, if the tile type blocks the scent trail.  Defaults to return true, if the tile type blocks line of sight; false, otherwise.  Secret doors typically block line of sight but will allow
    /// the scent to pass through.
    /// </summary>
    public virtual bool BlocksScent => BlocksLos;

    public Tile? HiddenTreasureForTile { get; private set; }

    /// <summary>
    /// Returns null, if the tile type is not a hidden treasure; otherwise, when the tile is a hidden treasure, the visible tile type is returned.
    /// </summary>
    protected virtual string? HiddenTreasureForTileName => null;

    /// <summary>
    /// Returns true, if the tile type is a visible treasure.  Defaults to false.  Magma and quartz are treasure tile types.
    /// </summary>
    public virtual bool IsVisibleTreasure => false;

    public virtual bool IsBorder => false;

    public virtual bool IsMagma => false;
    /// <summary>
    /// Returns a single action to perform on the tile.
    /// </summary>
    public AlterAction? AlterAction { get; private set; }

    protected virtual string? AlterActionName => null;

    /// <summary>
    /// The tile this tile should appear as when looked at; or null, if this tile is invisible/transparent.  Non-transparent, non-mimicing
    /// tiles will return themself.  Mimicing tiles will return a different tile.  Transparent tile that are considered invisible
    /// will return null.  Invisible tiles will render the background feature.
    /// </summary>
    public Tile? MimicTile { get; private set; }

    /// <summary>
    /// The name of the tile this tile should appear as when looked at; or null, if this tile is invisible/transparent.  Non-transparent,
    /// non-mimicing tiles will name themself.  Mimicing tiles will return a name for a different tile.  Transparent tile that are
    /// considered invisible will return null.  Invisible tiles will render the background feature.
    /// </summary>
    protected virtual string? MimicTileName => null; // TODO: Right now, there is nothing that is transparent.  The NULL means, no mimic.

    /// <summary>
    /// The tile blocks line of sight.
    /// </summary>
    public virtual bool BlocksLos => false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public abstract string Description { get; }

    /// <summary>
    /// The the tile this one should appear to be when looked at.
    /// </summary>
    public virtual bool DimsOutsideLOS => false;

    /// <summary>
    /// The tile is a basic (not permanent) dungeon wall.
    /// </summary>
    public virtual bool IsBasicWall => false;

    /// <summary>
    /// Returns true for all visible doors (locked and jammed); false, otherwise.  Secret doors return false; all other doors return true.
    /// </summary>
    public virtual bool IsVisibleDoor => false;

    public virtual int LockLevel => 0;

    /// <summary>
    /// The tile is 'interesting' and should be noticed when the player looks around.
    /// </summary>
    public virtual bool IsInteresting => false;

    /// <summary>
    /// The tile is open floor safe to drop items on.
    /// </summary>
    public virtual bool IsOpenFloor => false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual bool IsPassable => false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual bool IsPermanent => false;

    /// <summary>
    /// The tile is a shop entrance.
    /// </summary>
    public virtual bool IsShop => false;

    /// <summary>
    /// The tile is a known trap.
    /// </summary>
    public virtual bool IsTrap => false;

    /// <summary>
    /// The tile is a wall (not including a secret door).
    /// </summary>
    public virtual bool IsWall => false;

    /// <summary>
    /// Returns true, if the tile is water; false, otherwise.  Returns false, by default.  The WaterBorder and the Water tiles both return true.
    /// </summary>
    public virtual bool IsWater => false;
    /// <summary>
    /// The priority on the map.
    /// </summary>
    public abstract int MapPriority { get; }

    /// <summary>
    /// The player will run past the tile rather than stopping at it.
    /// </summary>
    public virtual bool RunPast => false;

    /// <summary>
    /// The tile this one should appear to be when looked at.
    /// </summary>
    public virtual bool YellowInTorchlight => false;

    /// <summary>
    /// Returns true, if the tile should be revealed with the detect stairs script.  Returns false, by default.  UpStairs and DownStairs tiles return true.
    /// </summary>
    public virtual bool IsRevealedWithDetectStairsScript => false;

    /// <summary>
    /// Returns true, if the tile allows a monster to occupy it.  Returns true, by default.  YellowSignSigils and ElderSignSigils return false.
    /// </summary>
    public virtual bool AllowMonsterToOccupy => true;

    /// <summary>
    /// Returns true, if the tile is a secret door.  Returns false, by default.  Secret doors return true.
    /// </summary>
    public virtual bool IsSecretDoor => false;

    /// <summary>
    /// Returns true, if the tile is a closed door.  Returns false, by default.  Locked doors all return true.  Jammed doors return false.  Returns false, by default.
    /// </summary>
    public virtual bool IsClosedDoor => false;

    /// <summary>
    /// Returns true, if the tile is a door that is jammed closed.  Returns false, by default.  Jammed doors all return true.
    /// </summary>
    public virtual bool IsJammedClosedDoor => false;

    /// <summary>
    /// Returns true, if the tile is a trap door.  Returns false, by default.  Trap doors all return true.
    /// </summary>
    public virtual bool IsTrapDoor => false;

    /// <summary>
    /// Returns true, if the tile is rubble.  Returns false, by default.  Rubble returns true.
    /// </summary>
    public virtual bool IsRubble => false;

    /// <summary>
    /// Returns true, if the tile is an open door.  Returns false, by default.  Open and broken doors returns true.
    /// </summary>
    public virtual bool IsOpenDoor => false;


    /// <summary>
    /// Returns true, if the tile is a vein.  Returns false, by default.  Magma hidden treasure, magma, magma visible treasure, 
    /// quartz hidden, quartz and quartz visible treasure tiles all returns true.
    /// </summary>
    public virtual bool IsVein => false;

    /// <summary>
    /// Returns true, if the tile is an unidentified trap.  Returns false, by default.  Invisible traps return true.
    /// </summary>
    public virtual bool IsUnidentifiedTrap => false;

    /// <summary>
    /// Returns true, if the tile is a tree.  Returns false, by default.  Bush, scarecrow, signpost and tree tiles all return true.
    public virtual bool IsTree => false;
}
