namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PurplePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Purple";
}
