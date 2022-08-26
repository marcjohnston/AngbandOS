using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MetallicRedPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Metallic Red";
}
