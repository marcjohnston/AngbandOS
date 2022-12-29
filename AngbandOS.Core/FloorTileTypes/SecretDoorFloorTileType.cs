namespace AngbandOS.Core;

[Serializable]
internal class SecretDoorFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override string Name => "SecretDoor";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Tunnel;
    public override string AppearAs => "WallBasic";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.SecretDoor;
    public override string Description => "granite wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 10;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
