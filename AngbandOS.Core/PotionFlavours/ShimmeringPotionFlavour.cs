namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class ShimmeringPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Shimmering";
}
