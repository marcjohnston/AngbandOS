namespace AngbandOS.Core;

[Serializable]
internal class ChartreusePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Chartreuse";
}
