namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class InnFloorTileType : FloorTileType
{
    private InnFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '&';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Inn";
    public override string AppearAs => "Inn";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Inn";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
