namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class MagmaVisTreasFloorTileType : FloorTileType
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "MagmaVisTreas";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "MagmaVisTreas";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Vein;
    public override string Description => "magma vein with treasure";
    public override bool DimsOutsideLOS => true;
    public override bool IsWall => true;
    public override int MapPriority => 19;
    public override bool RunPast => true;
}
