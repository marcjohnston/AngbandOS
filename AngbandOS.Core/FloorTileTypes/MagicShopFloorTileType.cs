namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class MagicShopFloorTileType : FloorTileType
{
    private MagicShopFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '6';
    public override Colour Colour => Colour.Red;
    public override string Name => "MagicShop";
    public override string AppearAs => "MagicShop";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Magic Shop";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
