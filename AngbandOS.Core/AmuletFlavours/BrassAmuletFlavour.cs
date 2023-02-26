namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class BrassAmuletFlavour : AmuletFlavour
{
    private BrassAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}
