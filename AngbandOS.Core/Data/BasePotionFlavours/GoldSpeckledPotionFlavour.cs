using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldSpeckledPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "Gold Speckled";
}
