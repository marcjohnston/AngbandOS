namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class BookstoreFloorTileType : FloorTileType
{
    public override char Character => '9';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Bookstore";
    public override string AppearAs => "Bookstore";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Bookstore";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
