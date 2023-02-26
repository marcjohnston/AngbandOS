namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WildPathNSFloorTileType : FloorTileType
{
    private WildPathNSFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "WildPathNS";
    public override string AppearAs => "WildPathNS";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
}
