using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class TileGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("bool",
        Title = "Is Earthquake Resistant",
        Summary = "Determines whether the tile is resistant to earthquakes.")]
    public virtual bool IsEarthquakeResistant { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Path Base",
        Summary = "Determines whether the tile is a path base tile.")]
    public virtual bool IsPathBase { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Can Be Closed",
        Summary = "Determines whether the tile can be closed.")]
    public virtual bool CanBeClosed { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Invisible Trap",
        Summary = "Determines whether the tile is an invisible trap.")]
    public virtual bool IsInvisibleTrap { get; set; } = false;

    [ConfigurationProperty("string?",
        Title = "On Jammed Tile Name",
        Summary = "Specifies the tile name used when this tile is jammed.")]
    public virtual string? OnJammedTileName { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Visible Treasure For Tile Name",
        Summary = "Specifies the visible treasure tile name associated with this tile.")]
    public virtual string? VisibleTreasureForTileName { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Is Yellow Sign Sigil",
        Summary = "Determines whether the tile is a Yellow Sign sigil.")]
    public virtual bool IsYellowSignSigil { get; set; } = false;

    [ConfigurationProperty("string?",
        Title = "Step On Script Name",
        Summary = "Specifies the name of the script executed when the tile is stepped on.")]
    public virtual string? StepOnScriptName { get; set; }

    [ConfigurationProperty("string",
        Title = "Symbol Name",
        Summary = "Specifies the name of the symbol used to render the tile.")]
    public virtual string SymbolName { get; set; }

    [ConfigurationProperty("ColorEnum",
        Title = "Color",
        Summary = "Specifies the color used to render the tile.")]
    public virtual ColorEnum Color { get; set; } = ColorEnum.White;

    [ConfigurationProperty("bool",
        Title = "Is Wild Path",
        Summary = "Determines whether the tile is a wild path.")]
    public virtual bool IsWildPath { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Path",
        Summary = "Determines whether the tile is a path tile.")]
    public virtual bool IsPath { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Treasure",
        Summary = "Determines whether the tile is a treasure tile.")]
    public virtual bool IsTreasure { get; set; } = false;

    [ConfigurationProperty("bool?",
        Title = "Blocks Scent",
        Summary = "Determines whether the tile blocks the scent trail. When null, the value is derived from whether the tile blocks line of sight.")]
    public virtual bool? BlocksScent { get; set; }

    [ConfigurationProperty("string?",
        Title = "Hidden Treasure For Tile Name",
        Summary = "Specifies the visible tile name associated with this hidden treasure tile. When null, the tile is not hidden treasure.")]
    public virtual string? HiddenTreasureForTileName { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Is Visible Treasure",
        Summary = "Determines whether the tile is a visible treasure tile.")]
    public virtual bool IsVisibleTreasure { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Border",
        Summary = "Determines whether the tile is a border tile.")]
    public virtual bool IsBorder { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Magma",
        Summary = "Determines whether the tile is magma.")]
    public virtual bool IsMagma { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Wall Outer",
        Summary = "Determines whether the tile is an outer wall.")]
    public virtual bool IsWallOuter { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Wall Permanent Outer",
        Summary = "Determines whether the tile is a permanent outer wall.")]
    public virtual bool IsWallPermanentOuter { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Wall Permanent Solid",
        Summary = "Determines whether the tile is a permanent solid wall.")]
    public virtual bool IsWallPermanentSolid { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Wall Solid",
        Summary = "Determines whether the tile is a solid wall.")]
    public virtual bool IsWallSolid { get; set; } = false;

    [ConfigurationProperty("string?",
        Title = "Alter Action Name",
        Summary = "Specifies the name of the action performed on the tile.")]
    public virtual string? AlterActionName { get; set; } = null;

    [ConfigurationProperty("string?",
        Title = "Mimic Tile Name",
        Summary = "Specifies the name of the tile this tile appears to be when viewed.")]
    public virtual string? MimicTileName { get; set; } = null;

    [ConfigurationProperty("bool",
        Title = "Blocks Line Of Sight",
        Summary = "Determines whether the tile blocks line of sight.")]
    public virtual bool BlocksLos { get; set; } = false;

    [ConfigurationProperty("string",
        Title = "Description",
        Summary = "Specifies the text description of the tile.")]
    public virtual string Description { get; set; }

    [ConfigurationProperty("bool",
        Title = "Dims Outside Line Of Sight",
        Summary = "Determines whether the tile dims outside line of sight.")]
    public virtual bool DimsOutsideLOS { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Basic Wall",
        Summary = "Determines whether the tile is a basic, non-permanent dungeon wall.")]
    public virtual bool IsBasicWall { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Visible Door",
        Summary = "Determines whether the tile is a visible door.")]
    public virtual bool IsVisibleDoor { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Lock Level",
        Summary = "Specifies the lock level of the tile.")]
    public virtual int LockLevel { get; set; } = 0;

    [ConfigurationProperty("bool",
        Title = "Is Interesting",
        Summary = "Determines whether the tile is interesting and should be noticed when the player looks around.")]
    public virtual bool IsInteresting { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Open Floor",
        Summary = "Determines whether the tile is open floor that is safe to drop items on.")]
    public virtual bool IsOpenFloor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Passable",
        Summary = "Determines whether the tile is passable.")]
    public virtual bool IsPassable { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Permanent",
        Summary = "Determines whether the tile is permanent.")]
    public virtual bool IsPermanent { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Shop",
        Summary = "Determines whether the tile is a shop entrance.")]
    public virtual bool IsShop { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Trap",
        Summary = "Determines whether the tile is a known trap.")]
    public virtual bool IsTrap { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Wall",
        Summary = "Determines whether the tile is a wall, excluding secret doors.")]
    public virtual bool IsWall { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Water",
        Summary = "Determines whether the tile is water.")]
    public virtual bool IsWater { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Rock",
        Summary = "Determines whether the tile is rock.")]
    public virtual bool IsRock { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Down Staircase",
        Summary = "Determines whether the tile is a down staircase.")]
    public virtual bool IsDownStaircase { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Up Staircase",
        Summary = "Determines whether the tile is an up staircase.")]
    public virtual bool IsUpStaircase { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Grass",
        Summary = "Determines whether the tile is grass.")]
    public virtual bool IsGrass { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Has Water",
        Summary = "Determines whether the tile has water.")]
    public virtual bool HasWater { get; set; } = false;

    [ConfigurationProperty("int",
        Title = "Map Priority",
        Summary = "Specifies the priority of the tile on the map.")]
    public virtual int MapPriority { get; set; }

    [ConfigurationProperty("bool",
        Title = "Run Past",
        Summary = "Determines whether the player runs past the tile rather than stopping at it.")]
    public virtual bool RunPast { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Yellow In Torchlight",
        Summary = "Determines whether the tile appears yellow in torchlight.")]
    public virtual bool YellowInTorchlight { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Revealed With Detect Stairs Script",
        Summary = "Determines whether the tile is revealed by the detect stairs script.")]
    public virtual bool IsRevealedWithDetectStairsScript { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Allow Monster To Occupy",
        Summary = "Determines whether a monster can occupy the tile.")]
    public virtual bool AllowMonsterToOccupy { get; set; } = true;

    [ConfigurationProperty("bool",
        Title = "Is Secret Door",
        Summary = "Determines whether the tile is a secret door.")]
    public virtual bool IsSecretDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Closed Door",
        Summary = "Determines whether the tile is a closed door.")]
    public virtual bool IsClosedDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Jammed Closed Door",
        Summary = "Determines whether the tile is a door that is jammed closed.")]
    public virtual bool IsJammedClosedDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Trap Door",
        Summary = "Determines whether the tile is a trap door.")]
    public virtual bool IsTrapDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Rubble",
        Summary = "Determines whether the tile is rubble.")]
    public virtual bool IsRubble { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Broken Door",
        Summary = "Determines whether the tile is a broken door.")]
    public virtual bool IsBrokenDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Bush",
        Summary = "Determines whether the tile is a bush.")]
    public virtual bool IsBush { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Pillar",
        Summary = "Determines whether the tile is a pillar.")]
    public virtual bool IsPillar { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Elder Sign Sigil",
        Summary = "Determines whether the tile is an Elder Sign sigil.")]
    public virtual bool IsElderSignSigil { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Open Door",
        Summary = "Determines whether the tile is an open door.")]
    public virtual bool IsOpenDoor { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Vein",
        Summary = "Determines whether the tile is a vein.")]
    public virtual bool IsVein { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Unidentified Trap",
        Summary = "Determines whether the tile is an unidentified trap.")]
    public virtual bool IsUnidentifiedTrap { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Is Tree",
        Summary = "Determines whether the tile is a tree.")]
    public virtual bool IsTree { get; set; } = false;
}