namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BronzeRodFlavour : RodFlavour
{
    private BronzeRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Bronze";
}
