namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WaterFloorTileType : FloorTileType
{
    private WaterFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '~';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Water";
    public override string AppearAs => "Water";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "water";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
