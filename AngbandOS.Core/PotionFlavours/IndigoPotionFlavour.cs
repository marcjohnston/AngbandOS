namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class IndigoPotionFlavour : PotionFlavour
{
    private IndigoPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Indigo";
}
