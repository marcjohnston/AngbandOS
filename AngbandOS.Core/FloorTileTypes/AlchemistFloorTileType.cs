namespace AngbandOS.Core;

[Serializable]
internal class AlchemistFloorTileType : FloorTileType
{
    public override char Character => '5';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Alchemist";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "Alchemist";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "Alchemy Shop";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsPermanent => true;
    public override bool IsShop => true;
    public override int MapPriority => 0;
}
