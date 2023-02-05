namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class HazyPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Hazy";
}
