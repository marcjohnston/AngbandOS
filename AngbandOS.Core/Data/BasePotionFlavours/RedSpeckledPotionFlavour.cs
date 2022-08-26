using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RedSpeckledPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Red Speckled";
}
