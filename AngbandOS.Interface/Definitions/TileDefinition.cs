namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class TileDefinition : IPoco
{
    protected virtual string? OnJammedTileName => null;
    protected virtual string? VisibleTreasureForTileName => null;

    public virtual string Key { get; set; }

    public virtual void StepOn() { }

    public bool IsValid()
    {
        return true;
    }

    /// <summary>
    /// Returns the name of the symbol to be used for rendering.  This property is bound to the Symbol property during binding.
    /// </summary>
    public virtual string SymbolName { get; set; }

    /// <summary>
    /// Returns the color to render the tile as.  Returns white, by default.
    /// </summary>
    public virtual ColorEnum Color => ColorEnum.White;

    public virtual bool IsWildPath { get; set; } = false;

    /// <summary>
    /// Returns true for all path tiles; false, otherwise.  Returns false, by default.  PathBase, PathBorderEW, PathBorderNS, PathEW, PathJunction and PathNS return true.
    /// </summary>
    public virtual bool IsPath { get; set; } = false;

    public virtual bool IsTreasure { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile type blocks the scent trail.  Defaults to return true, if the tile type blocks line of sight; false, otherwise.  Secret doors typically block line of sight but will allow
    /// the scent to pass through.
    /// </summary>
    public virtual bool BlocksScent { get; set; }

    /// <summary>
    /// Returns null, if the tile type is not a hidden treasure; otherwise, when the tile is a hidden treasure, the visible tile type is returned.
    /// </summary>
    public virtual string? HiddenTreasureForTileName { get; set; } = null;

    /// <summary>
    /// Returns true, if the tile type is a visible treasure.  Defaults to false.  Magma and quartz are treasure tile types.
    /// </summary>
    public virtual bool IsVisibleTreasure { get; set; } = false;

    public virtual bool IsBorder { get; set; } = false;

    public virtual bool IsMagma { get; set; } = false;

    /// <summary>
    /// Returns the name of the single action to perform on the tile.
    /// </summary>
    public virtual string? AlterActionName { get; set; } = null;

    /// <summary>
    /// The name of the tile this tile should appear as when looked at; or null, if this tile is invisible/transparent.  Non-transparent,
    /// non-mimicing tiles will name themself.  Mimicing tiles will return a name for a different tile.  Transparent tile that are
    /// considered invisible will return null.  Invisible tiles will render the background feature.
    /// </summary>
    public virtual string? MimicTileName { get; set; } = null; 

    /// <summary>
    /// The tile blocks line of sight.
    /// </summary>
    public virtual bool BlocksLos => false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual string Description { get; set; }

    /// <summary>
    /// The the tile this one should appear to be when looked at.
    /// </summary>
    public virtual bool DimsOutsideLOS { get; set; } = false;

    /// <summary>
    /// The tile is a basic (not permanent) dungeon wall.
    /// </summary>
    public virtual bool IsBasicWall { get; set; } = false;

    /// <summary>
    /// Returns true for all visible doors (locked and jammed); false, otherwise.  Secret doors return false; all other doors return true.
    /// </summary>
    public virtual bool IsVisibleDoor { get; set; } = false;

    public virtual int LockLevel { get; set; } = 0;

    /// <summary>
    /// The tile is 'interesting' and should be noticed when the player looks around.
    /// </summary>
    public virtual bool IsInteresting { get; set; } = false;

    /// <summary>
    /// The tile is open floor safe to drop items on.
    /// </summary>
    public virtual bool IsOpenFloor { get; set; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual bool IsPassable { get; set; } = false;

    /// <summary>
    /// A text description of the tile.
    /// </summary>
    public virtual bool IsPermanent { get; set; } = false;

    /// <summary>
    /// The tile is a shop entrance.
    /// </summary>
    public virtual bool IsShop { get; set; } = false;

    /// <summary>
    /// The tile is a known trap.
    /// </summary>
    public virtual bool IsTrap { get; set; } = false;

    /// <summary>
    /// The tile is a wall (not including a secret door).
    /// </summary>
    public virtual bool IsWall { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is water; false, otherwise.  Returns false, by default.  The WaterBorder and the Water tiles both return true.
    /// </summary>
    public virtual bool IsWater { get; set; } = false;
    /// <summary>
    /// The priority on the map.
    /// </summary>
    public virtual int MapPriority { get; set; }

    /// <summary>
    /// The player will run past the tile rather than stopping at it.
    /// </summary>
    public virtual bool RunPast { get; set; } = false;

    /// <summary>
    /// The tile this one should appear to be when looked at.
    /// </summary>
    public virtual bool YellowInTorchlight { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile should be revealed with the detect stairs script.  Returns false, by default.  UpStairs and DownStairs tiles return true.
    /// </summary>
    public virtual bool IsRevealedWithDetectStairsScript { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile allows a monster to occupy it.  Returns true, by default.  YellowSignSigils and ElderSignSigils return false.
    /// </summary>
    public virtual bool AllowMonsterToOccupy { get; set; } = true;

    /// <summary>
    /// Returns true, if the tile is a secret door.  Returns false, by default.  Secret doors return true.
    /// </summary>
    public virtual bool IsSecretDoor { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is a closed door.  Returns false, by default.  Locked doors all return true.  Jammed doors return false.  Returns false, by default.
    /// </summary>
    public virtual bool IsClosedDoor { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is a door that is jammed closed.  Returns false, by default.  Jammed doors all return true.
    /// </summary>
    public virtual bool IsJammedClosedDoor { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is a trap door.  Returns false, by default.  Trap doors all return true.
    /// </summary>
    public virtual bool IsTrapDoor { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is rubble.  Returns false, by default.  Rubble returns true.
    /// </summary>
    public virtual bool IsRubble { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is an open door.  Returns false, by default.  Open and broken doors returns true.
    /// </summary>
    public virtual bool IsOpenDoor { get; set; } = false;


    /// <summary>
    /// Returns true, if the tile is a vein.  Returns false, by default.  Magma hidden treasure, magma, magma visible treasure, 
    /// quartz hidden, quartz and quartz visible treasure tiles all returns true.
    /// </summary>
    public virtual bool IsVein { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is an unidentified trap.  Returns false, by default.  Invisible traps return true.
    /// </summary>
    public virtual bool IsUnidentifiedTrap { get; set; } = false;

    /// <summary>
    /// Returns true, if the tile is a tree.  Returns false, by default.  Bush, scarecrow, signpost and tree tiles all return true.
    public virtual bool IsTree { get; set; } = false;
}
