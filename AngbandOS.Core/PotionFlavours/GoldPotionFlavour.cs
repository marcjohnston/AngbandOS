namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class GoldPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}
