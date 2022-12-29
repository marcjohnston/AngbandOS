namespace AngbandOS.Core;

[Serializable]
internal class DungeonFloorFloorTileType : FloorTileType
{
    public override char Character => '·';
    public override string Name => "DungeonFloor";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "DungeonFloor";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Floor;
    public override string Description => "open floor";
    public override bool DimsOutsideLOS => true;
    public override bool IsOpenFloor => true;
    public override bool IsPassable => true;
    public override int MapPriority => 5;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
