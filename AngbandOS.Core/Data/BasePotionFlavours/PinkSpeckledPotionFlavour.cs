using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PinkSpeckledPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Pink Speckled";
}
