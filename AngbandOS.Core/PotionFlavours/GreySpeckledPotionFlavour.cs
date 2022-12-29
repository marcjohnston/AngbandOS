namespace AngbandOS.Core;

[Serializable]
internal class GreySpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Grey Speckled";
}
