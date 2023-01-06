namespace AngbandOS.Core;

[Serializable]
internal class AcidTrapFloorTileType : FloorTileType
{
    public override char Character => '^';
    public override Colour Colour => Colour.Brown;
    public override string Name => "AcidTrap";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "AcidTrap";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "discolored spot";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
