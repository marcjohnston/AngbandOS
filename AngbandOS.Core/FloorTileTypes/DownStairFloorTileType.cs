namespace AngbandOS.Core;

[Serializable]
internal class DownStairFloorTileType : FloorTileType
{
    public override char Character => '>';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "DownStair";
    public override string AppearAs => "DownStair";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.DownStair;
    public override string Description => "down staircase";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 25;
}
