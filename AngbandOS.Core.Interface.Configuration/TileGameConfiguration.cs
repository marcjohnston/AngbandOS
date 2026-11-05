using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TileGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(Title = "Is Earthquake Resistant", Summary = "Determines whether the tile is resistant to earthquakes.", DataType = "bool")]
    public virtual bool IsEarthquakeResistant { get; set; } = false;

    [ConfigurationProperty(Title = "Is Path Base", Summary = "Determines whether the tile is a path base tile.", DataType = "bool")]
    public virtual bool IsPathBase { get; set; } = false;

    [ConfigurationProperty(Title = "Can Be Closed", Summary = "Determines whether the tile can be closed.", DataType = "bool")]
    public virtual bool CanBeClosed { get; set; } = false;

    [ConfigurationProperty(Title = "Is Invisible Trap", Summary = "Determines whether the tile is an invisible trap.", DataType = "bool")]
    public virtual bool IsInvisibleTrap { get; set; } = false;

    [ConfigurationProperty(Title = "On Jammed Tile Name", Summary = "Specifies the tile name used when this tile is jammed.", DataType = "string?")]
    public virtual string? OnJammedTileName { get; set; } = null;

    [ConfigurationProperty(Title = "Visible Treasure For Tile Name", Summary = "Specifies the visible treasure tile name associated with this tile.", DataType = "string?")]
    public virtual string? VisibleTreasureForTileName { get; set; } = null;

    [ConfigurationProperty(Title = "Is Yellow Sign Sigil", Summary = "Determines whether the tile is a Yellow Sign sigil.", DataType = "bool")]
    public virtual bool IsYellowSignSigil { get; set; } = false;

    [ConfigurationProperty(Title = "Step On Script Name", Summary = "Specifies the name of the script executed when the tile is stepped on.", DataType = "string?")]
    public virtual string? StepOnScriptName { get; set; }

    [ConfigurationProperty(Title = "Symbol Name", Summary = "Specifies the name of the symbol used to render the tile.", DataType = "string")]
    public virtual string SymbolName { get; set; }

    [ConfigurationProperty(Title = "Color", Summary = "Specifies the color used to render the tile.", DataType = "ColorEnum")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty(Title = "Is Wild Path", Summary = "Determines whether the tile is a wild path.", DataType = "bool")]
    public virtual bool IsWildPath { get; set; } = false;

    [ConfigurationProperty(Title = "Is Path", Summary = "Determines whether the tile is a path tile.", DataType = "bool")]
    public virtual bool IsPath { get; set; } = false;

    [ConfigurationProperty(Title = "Is Treasure", Summary = "Determines whether the tile is a treasure tile.", DataType = "bool")]
    public virtual bool IsTreasure { get; set; } = false;

    [ConfigurationProperty(Title = "Blocks Scent", Summary = "Determines whether the tile blocks the scent trail. When null, the value is derived from whether the tile blocks line of sight.", DataType = "bool?")]
    public virtual bool? BlocksScent { get; set; }

    [ConfigurationProperty(Title = "Hidden Treasure For Tile Name", Summary = "Specifies the visible tile name associated with this hidden treasure tile. When null, the tile is not hidden treasure.", DataType = "string?")]
    public virtual string? HiddenTreasureForTileName { get; set; } = null;

    [ConfigurationProperty(Title = "Is Visible Treasure", Summary = "Determines whether the tile is a visible treasure tile.", DataType = "bool")]
    public virtual bool IsVisibleTreasure { get; set; } = false;

    [ConfigurationProperty(Title = "Is Border", Summary = "Determines whether the tile is a border tile.", DataType = "bool")]
    public virtual bool IsBorder { get; set; } = false;

    [ConfigurationProperty(Title = "Is Magma", Summary = "Determines whether the tile is magma.", DataType = "bool")]
    public virtual bool IsMagma { get; set; } = false;

    [ConfigurationProperty(Title = "Is Wall Outer", Summary = "Determines whether the tile is an outer wall.", DataType = "bool")]
    public virtual bool IsWallOuter { get; set; } = false;

    [ConfigurationProperty(Title = "Is Wall Permanent Outer", Summary = "Determines whether the tile is a permanent outer wall.", DataType = "bool")]
    public virtual bool IsWallPermanentOuter { get; set; } = false;

    [ConfigurationProperty(Title = "Is Wall Permanent Solid", Summary = "Determines whether the tile is a permanent solid wall.", DataType = "bool")]
    public virtual bool IsWallPermanentSolid { get; set; } = false;

    [ConfigurationProperty(Title = "Is Wall Solid", Summary = "Determines whether the tile is a solid wall.", DataType = "bool")]
    public virtual bool IsWallSolid { get; set; } = false;

    [ConfigurationProperty(Title = "Alter Action Name", Summary = "Specifies the name of the action performed on the tile.", DataType = "string?")]
    public virtual string? AlterActionName { get; set; } = null;

    [ConfigurationProperty(Title = "Mimic Tile Name", Summary = "Specifies the name of the tile this tile appears to be when viewed.", DataType = "string?")]
    public virtual string? MimicTileName { get; set; } = null;

    [ConfigurationProperty(Title = "Blocks Line Of Sight", Summary = "Determines whether the tile blocks line of sight.", DataType = "bool")]
    public virtual bool BlocksLos { get; set; } = false;

    [ConfigurationProperty(Title = "Description", Summary = "Specifies the text description of the tile.", DataType = "string")]
    public virtual string Description { get; set; }

    [ConfigurationProperty(Title = "Dims Outside Line Of Sight", Summary = "Determines whether the tile dims outside line of sight.", DataType = "bool")]
    public virtual bool DimsOutsideLOS { get; set; } = false;

    [ConfigurationProperty(Title = "Is Basic Wall", Summary = "Determines whether the tile is a basic, non-permanent dungeon wall.", DataType = "bool")]
    public virtual bool IsBasicWall { get; set; } = false;

    [ConfigurationProperty(Title = "Is Visible Door", Summary = "Determines whether the tile is a visible door.", DataType = "bool")]
    public virtual bool IsVisibleDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Lock Level", Summary = "Specifies the lock level of the tile.", DataType = "int")]
    public virtual int LockLevel { get; set; } = 0;

    [ConfigurationProperty(Title = "Is Interesting", Summary = "Determines whether the tile is interesting and should be noticed when the player looks around.", DataType = "bool")]
    public virtual bool IsInteresting { get; set; } = false;

    [ConfigurationProperty(Title = "Is Open Floor", Summary = "Determines whether the tile is open floor that is safe to drop items on.", DataType = "bool")]
    public virtual bool IsOpenFloor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Passable", Summary = "Determines whether the tile is passable.", DataType = "bool")]
    public virtual bool IsPassable { get; set; } = false;

    [ConfigurationProperty(Title = "Is Permanent", Summary = "Determines whether the tile is permanent.", DataType = "bool")]
    public virtual bool IsPermanent { get; set; } = false;

    [ConfigurationProperty(Title = "Is Shop", Summary = "Determines whether the tile is a shop entrance.", DataType = "bool")]
    public virtual bool IsShop { get; set; } = false;

    [ConfigurationProperty(Title = "Is Trap", Summary = "Determines whether the tile is a known trap.", DataType = "bool")]
    public virtual bool IsTrap { get; set; } = false;

    [ConfigurationProperty(Title = "Is Wall", Summary = "Determines whether the tile is a wall, excluding secret doors.", DataType = "bool")]
    public virtual bool IsWall { get; set; } = false;

    [ConfigurationProperty(Title = "Is Water", Summary = "Determines whether the tile is water.", DataType = "bool")]
    public virtual bool IsWater { get; set; } = false;

    [ConfigurationProperty(Title = "Is Rock", Summary = "Determines whether the tile is rock.", DataType = "bool")]
    public virtual bool IsRock { get; set; } = false;

    [ConfigurationProperty(Title = "Is Down Staircase", Summary = "Determines whether the tile is a down staircase.", DataType = "bool")]
    public virtual bool IsDownStaircase { get; set; } = false;

    [ConfigurationProperty(Title = "Is Up Staircase", Summary = "Determines whether the tile is an up staircase.", DataType = "bool")]
    public virtual bool IsUpStaircase { get; set; } = false;

    [ConfigurationProperty(Title = "Is Grass", Summary = "Determines whether the tile is grass.", DataType = "bool")]
    public virtual bool IsGrass { get; set; } = false;

    [ConfigurationProperty(Title = "Has Water", Summary = "Determines whether the tile has water.", DataType = "bool")]
    public virtual bool HasWater { get; set; } = false;

    [ConfigurationProperty(Title = "Map Priority", Summary = "Specifies the priority of the tile on the map.", DataType = "int")]
    public virtual int MapPriority { get; set; }

    [ConfigurationProperty(Title = "Run Past", Summary = "Determines whether the player runs past the tile rather than stopping at it.", DataType = "bool")]
    public virtual bool RunPast { get; set; } = false;

    [ConfigurationProperty(Title = "Yellow In Torchlight", Summary = "Determines whether the tile appears yellow in torchlight.", DataType = "bool")]
    public virtual bool YellowInTorchlight { get; set; } = false;

    [ConfigurationProperty(Title = "Is Revealed With Detect Stairs Script", Summary = "Determines whether the tile is revealed by the detect stairs script.", DataType = "bool")]
    public virtual bool IsRevealedWithDetectStairsScript { get; set; } = false;

    [ConfigurationProperty(Title = "Allow Monster To Occupy", Summary = "Determines whether a monster can occupy the tile.", DataType = "bool")]
    public virtual bool AllowMonsterToOccupy { get; set; } = true;

    [ConfigurationProperty(Title = "Is Secret Door", Summary = "Determines whether the tile is a secret door.", DataType = "bool")]
    public virtual bool IsSecretDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Closed Door", Summary = "Determines whether the tile is a closed door.", DataType = "bool")]
    public virtual bool IsClosedDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Jammed Closed Door", Summary = "Determines whether the tile is a door that is jammed closed.", DataType = "bool")]
    public virtual bool IsJammedClosedDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Trap Door", Summary = "Determines whether the tile is a trap door.", DataType = "bool")]
    public virtual bool IsTrapDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Rubble", Summary = "Determines whether the tile is rubble.", DataType = "bool")]
    public virtual bool IsRubble { get; set; } = false;

    [ConfigurationProperty(Title = "Is Broken Door", Summary = "Determines whether the tile is a broken door.", DataType = "bool")]
    public virtual bool IsBrokenDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Bush", Summary = "Determines whether the tile is a bush.", DataType = "bool")]
    public virtual bool IsBush { get; set; } = false;

    [ConfigurationProperty(Title = "Is Pillar", Summary = "Determines whether the tile is a pillar.", DataType = "bool")]
    public virtual bool IsPillar { get; set; } = false;

    [ConfigurationProperty(Title = "Is Elder Sign Sigil", Summary = "Determines whether the tile is an Elder Sign sigil.", DataType = "bool")]
    public virtual bool IsElderSignSigil { get; set; } = false;

    [ConfigurationProperty(Title = "Is Open Door", Summary = "Determines whether the tile is an open door.", DataType = "bool")]
    public virtual bool IsOpenDoor { get; set; } = false;

    [ConfigurationProperty(Title = "Is Vein", Summary = "Determines whether the tile is a vein.", DataType = "bool")]
    public virtual bool IsVein { get; set; } = false;

    [ConfigurationProperty(Title = "Is Unidentified Trap", Summary = "Determines whether the tile is an unidentified trap.", DataType = "bool")]
    public virtual bool IsUnidentifiedTrap { get; set; } = false;

    [ConfigurationProperty(Title = "Is Tree", Summary = "Determines whether the tile is a tree.", DataType = "bool")]
    public virtual bool IsTree { get; set; } = false;
}