namespace AngbandOS.Core;

[Serializable]
internal class DarkRedPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Dark Red";
}
