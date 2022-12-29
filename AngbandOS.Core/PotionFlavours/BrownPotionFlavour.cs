namespace AngbandOS.Core;

[Serializable]
internal class BrownPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Brown";
}
