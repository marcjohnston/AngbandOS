namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class BubblingPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Bubbling";
}
