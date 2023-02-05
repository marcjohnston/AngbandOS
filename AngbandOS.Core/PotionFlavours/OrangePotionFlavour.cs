namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class OrangePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Orange";
}
