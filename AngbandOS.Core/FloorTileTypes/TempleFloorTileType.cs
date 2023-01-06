namespace AngbandOS.Core;

[Serializable]
internal class TempleFloorTileType : FloorTileType
{
    public override char Character => '4';
    public override Colour Colour => Colour.Green;
    public override string Name => "Temple";
    public override string AppearAs => "Temple";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Temple";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
