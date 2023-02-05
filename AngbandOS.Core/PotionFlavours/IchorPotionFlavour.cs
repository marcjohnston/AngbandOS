namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class IchorPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Black;
    public override string Name => "Ichor";
}
