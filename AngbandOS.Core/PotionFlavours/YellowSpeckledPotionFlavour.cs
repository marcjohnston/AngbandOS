namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class YellowSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow Speckled";
}
