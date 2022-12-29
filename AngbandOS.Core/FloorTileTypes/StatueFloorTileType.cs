namespace AngbandOS.Core;

[Serializable]
internal class StatueFloorTileType : FloorTileType
{
    public override char Character => ':';
    public override string Name => "Statue";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "Statue";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "statue";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
    public override bool YellowInTorchlight => true;
}
