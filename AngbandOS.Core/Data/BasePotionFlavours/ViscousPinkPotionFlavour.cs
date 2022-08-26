using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ViscousPinkPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Viscous Pink";
}
