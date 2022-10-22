using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OilyYellowPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Oily Yellow";
}
