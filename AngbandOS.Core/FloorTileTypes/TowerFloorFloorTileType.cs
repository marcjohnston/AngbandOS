namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class TowerFloorFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override string Name => "TowerFloor";
    public override string AppearAs => "TowerFloor";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Floor;
    public override string Description => "open floor";
    public override bool DimsOutsideLOS => true;
    public override bool IsOpenFloor => true;
    public override bool IsPassable => true;
    public override int MapPriority => 5;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
