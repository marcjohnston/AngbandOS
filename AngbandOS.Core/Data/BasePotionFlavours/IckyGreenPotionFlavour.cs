using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IckyGreenPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Icky Green";
}
