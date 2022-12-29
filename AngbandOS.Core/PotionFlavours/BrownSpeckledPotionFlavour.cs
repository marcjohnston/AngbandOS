namespace AngbandOS.Core;

[Serializable]
internal class BrownSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Brown Speckled";
}
