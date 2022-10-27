using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MagentaPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Magenta";
}
