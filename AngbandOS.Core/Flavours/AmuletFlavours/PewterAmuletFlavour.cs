namespace AngbandOS.Core.Flavours;

[Serializable]
internal class PewterAmuletFlavour : AmuletFlavour
{
    private PewterAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "Pewter";
}
