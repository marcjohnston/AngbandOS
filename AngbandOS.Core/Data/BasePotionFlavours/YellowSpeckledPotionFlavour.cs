using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowSpeckledPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow Speckled";
}
