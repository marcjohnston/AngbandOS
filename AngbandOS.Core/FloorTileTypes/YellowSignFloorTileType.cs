namespace AngbandOS.Core;

[Serializable]
internal class YellowSignFloorTileType : FloorTileType
{
    public override char Character => ';';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "YellowSign";
    public override string AppearAs => "YellowSign";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Sigil;
    public override string Description => "Yellow Sign";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override int MapPriority => 20;
}
