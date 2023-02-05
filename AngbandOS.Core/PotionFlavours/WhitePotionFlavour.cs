namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class WhitePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "White";
}
