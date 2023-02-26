namespace AngbandOS.Core.FloorTileTypes;

[Serializable]
internal class FountainFloorTileType : FloorTileType
{
    private FountainFloorTileType(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '~';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Fountain";
    public override AlterAction? AlterAction => new TunnelAlterAction();
    public override string AppearAs => "Fountain";
    public override bool BlocksLos => true;
    public override FloorTileTypeCategory Category => FloorTileTypeCategory.Miscellaneous;
    public override string Description => "fountain";
    public override bool DimsOutsideLOS => true;
    public override int MapPriority => 0;
}
