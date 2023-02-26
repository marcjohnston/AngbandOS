namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WaterBorderFloorTileType : FloorTileType
{
    private WaterBorderFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '~';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "WaterBorder";
    public override string AppearAs => "Water";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Border;
    public override string Description => "sea";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
}
