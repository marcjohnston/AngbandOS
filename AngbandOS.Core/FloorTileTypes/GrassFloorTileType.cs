namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class GrassFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Grass";
    public override string AppearAs => "Grass";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Floor;
    public override string Description => "open floor";
    public override bool DimsOutsideLOS => true;
    public override bool IsOpenFloor => true;
    public override bool IsPassable => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
