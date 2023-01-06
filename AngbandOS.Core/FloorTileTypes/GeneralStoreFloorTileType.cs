namespace AngbandOS.Core;

[Serializable]
internal class GeneralStoreFloorTileType : FloorTileType
{
    public override char Character => '1';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "GeneralStore";
    public override string AppearAs => "GeneralStore";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "General Store";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
