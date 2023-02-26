namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class PathEWFloorTileType : FloorTileType
{
    private PathEWFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathEW";
    public override string AppearAs => "PathEW";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
}
