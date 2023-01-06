namespace AngbandOS.Core;

[Serializable]
internal class InsideGatehouseFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override string Name => "InsideGatehouse";
    public override string AppearAs => "InsideGatehouse";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "open floor";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
    public override bool YellowInTorchlight => true;
}
