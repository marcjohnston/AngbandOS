namespace AngbandOS.Core;

[Serializable]
internal class BlindGasFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Green;
    public override string Name => "BlindGas";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Disarm;
    public override string AppearAs => "BlindGas";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "gas trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
