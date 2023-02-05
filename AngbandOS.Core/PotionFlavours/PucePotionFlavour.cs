namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PucePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Puce";
}
