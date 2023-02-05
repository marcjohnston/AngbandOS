namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class IndigoPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Indigo";
}
