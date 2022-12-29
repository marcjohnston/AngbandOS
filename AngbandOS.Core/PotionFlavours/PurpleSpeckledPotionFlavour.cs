namespace AngbandOS.Core;

[Serializable]
internal class PurpleSpeckledPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Purple Speckled";
}
