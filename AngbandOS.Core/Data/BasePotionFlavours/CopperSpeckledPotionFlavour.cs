using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperSpeckledPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Copper Speckled";
}
