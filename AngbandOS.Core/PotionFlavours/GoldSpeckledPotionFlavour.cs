namespace AngbandOS.Core;

[Serializable]
internal class GoldSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "Gold Speckled";
}
