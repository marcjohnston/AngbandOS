using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class VioletSpeckledPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Violet Speckled";
}
