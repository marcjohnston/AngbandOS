namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class BlackPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Black;
    public override string Name => "Black";
}
