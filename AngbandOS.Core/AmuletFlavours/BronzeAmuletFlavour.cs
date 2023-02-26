namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class BronzeAmuletFlavour : AmuletFlavour
{
    private BronzeAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Bronze";
}
