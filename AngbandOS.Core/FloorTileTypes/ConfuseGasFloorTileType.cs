namespace AngbandOS.Core;

[Serializable]
internal class ConfuseGasFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Green;
    public override string Name => "ConfuseGas";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Disarm;
    public override string AppearAs => "ConfuseGas";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "gas trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
