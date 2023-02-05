namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class GreenSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Green;
    public override string Name => "Green Speckled";
}
