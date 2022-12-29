namespace AngbandOS.Core;

[Serializable]
internal class CrimsonPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Crimson";
}
