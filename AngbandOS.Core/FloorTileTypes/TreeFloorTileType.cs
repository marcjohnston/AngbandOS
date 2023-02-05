namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class TreeFloorTileType : FloorTileType
{
    public override char Character => '#';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Tree";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Tree";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Tree;
    public override string Description => "tree";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
