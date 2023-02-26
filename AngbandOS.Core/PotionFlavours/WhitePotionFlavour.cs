namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class WhitePotionFlavour : PotionFlavour
{
    private WhitePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "White";
}
