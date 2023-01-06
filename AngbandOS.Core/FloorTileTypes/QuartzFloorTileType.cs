namespace AngbandOS.Core;

[Serializable]
internal class QuartzFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override string Name => "Quartz";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Quartz";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "quartz vein";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 11;
    public override bool RunPast => true;
    public override bool YellowInTorchlight => true;
}
