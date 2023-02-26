namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class PathBaseFloorTileType : FloorTileType
{
    private PathBaseFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathBase";
    public override string AppearAs => "PathBase";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path base";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
}
