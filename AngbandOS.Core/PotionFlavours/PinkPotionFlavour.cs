namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PinkPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Pink";
}
