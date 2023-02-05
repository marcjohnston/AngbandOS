namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class QuartzVisTreasFloorTileType : FloorTileType
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "QuartzVisTreas";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "QuartzVisTreas";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "quartz vein with treasure";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 19;
    public override bool RunPast => true;
}
