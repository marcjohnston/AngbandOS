namespace AngbandOS.Core;

[Serializable]
internal class UpStairFloorTileType : FloorTileType
{
    public override char Character => '<';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "UpStair";
    public override string AppearAs => "UpStair";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.UpStair;
    public override string Description => "up staircase";
    public override bool DimsOutsideLOS => true;
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 25;
}
