namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class SummonRuneFloorTileType : FloorTileType
{
    private SummonRuneFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '^';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "SummonRune";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "SummonRune";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "strange rune";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
