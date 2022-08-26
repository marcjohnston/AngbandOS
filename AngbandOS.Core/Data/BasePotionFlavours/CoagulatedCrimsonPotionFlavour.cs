using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CoagulatedCrimsonPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Coagulated Crimson";
}
