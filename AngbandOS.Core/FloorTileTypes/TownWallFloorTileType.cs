namespace AngbandOS.Core;

[Serializable]
internal class TownWallFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override string Name => "TownWall";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "TownWall";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Border;
    public override string Description => "town wall";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override bool IsWall => true;
    public override int MapPriority => 0;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
