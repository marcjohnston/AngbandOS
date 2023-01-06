namespace AngbandOS.Core;

[Serializable]
internal class SpikedPitFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Grey;
    public override string Name => "SpikedPit";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "SpikedPit";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "pit";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
