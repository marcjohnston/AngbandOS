namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class ConDartFloorTileType : FloorTileType
{
    private ConDartFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '^';
    public override Colour Colour => Colour.Red;
    public override string Name => "ConDart";
    public override AlterAction? AlterAction => new DisarmAlterAction();
    public override string AppearAs => "ConDart";
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "dart trap";
    public override bool IsInteresting => true;
    public override bool IsPassable => true;
    public override bool IsTrap => true;
    public override int MapPriority => 20;
}
