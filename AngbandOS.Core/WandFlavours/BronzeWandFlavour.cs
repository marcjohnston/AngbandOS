namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class BronzeWandFlavour : WandFlavour
{
    private BronzeWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Bronze";
}
