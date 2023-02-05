namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class GreyPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Grey";
}
