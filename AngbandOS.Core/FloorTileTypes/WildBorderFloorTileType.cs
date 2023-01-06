namespace AngbandOS.Core;

[Serializable]
internal class WildBorderFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "WildBorder";
    public override string AppearAs => "Grass";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Border;
    public override string Description => "border";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
    public override bool YellowInTorchlight => true;
}
