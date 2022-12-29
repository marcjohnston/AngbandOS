namespace AngbandOS.Core;

[Serializable]
internal class CyanPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "Cyan";
}
