namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PinkSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Pink Speckled";
}
