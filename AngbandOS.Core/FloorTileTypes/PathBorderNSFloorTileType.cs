namespace AngbandOS.Core;

[Serializable]
internal class PathBorderNSFloorTileType : FloorTileType
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "PathBorderNS";
    public override FloorTileAlterAction AlterAction => FloorTileAlterAction.Nothing;
    public override string AppearAs => "PathBorderNS";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Border;
    public override string Description => "path";
    public override bool DimsOutsideLOS => true;
    public override bool IsPermanent => true;
    public override int MapPriority => 0;
}
