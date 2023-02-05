namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class MetallicRedPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Metallic Red";
}
