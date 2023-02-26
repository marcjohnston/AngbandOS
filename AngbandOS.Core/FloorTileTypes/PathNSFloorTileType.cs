namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class PathNSFloorTileType : FloorTileType
{
    private PathNSFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathNS";
    public override string AppearAs => "PathNS";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
}
