namespace AngbandOS.Core;

[Serializable]
internal class CopperSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Copper Speckled";
}
