using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class LightGreenPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Light Green";
}
