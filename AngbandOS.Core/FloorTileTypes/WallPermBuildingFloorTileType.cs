namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class WallPermBuildingFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override string Name => "WallPermBuilding";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "WallPermBuilding";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "building";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override bool IsWall => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
