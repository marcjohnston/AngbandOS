namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class FieldFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Field";
    public override string AppearAs => "Field";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Floor;
    public override string Description => "field";
    public override bool DimsOutsideLOS => true;
    public override bool IsOpenFloor => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
    public override bool YellowInTorchlight => true;
}
