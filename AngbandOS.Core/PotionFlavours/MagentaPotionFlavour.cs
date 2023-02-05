namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class MagentaPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Magenta";
}
