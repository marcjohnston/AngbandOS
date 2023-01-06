namespace AngbandOS.Core;

[Serializable]
internal class FireTrapFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Brown;
    public override string Name => "FireTrap";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "FireTrap";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "discolored spot";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
