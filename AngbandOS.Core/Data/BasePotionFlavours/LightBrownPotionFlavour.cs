using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LightBrownPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Light Brown";
}
