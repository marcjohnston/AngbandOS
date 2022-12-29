namespace AngbandOS.Core;

[Serializable]
internal class SmokyPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Smoky";
}
