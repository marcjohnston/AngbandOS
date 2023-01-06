namespace AngbandOS.Core;

[Serializable]
internal class ArmouryFloorTileType : FloorTileType
{
    public override char Character => '2';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Armoury";
    public override string AppearAs => "Armoury";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Armoury";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
