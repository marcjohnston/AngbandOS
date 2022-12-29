namespace AngbandOS.Core;

[Serializable]
internal class ClottedRedPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Clotted Red";
}
