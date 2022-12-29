namespace AngbandOS.Core;

[Serializable]
internal class BluePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Blue";
}
