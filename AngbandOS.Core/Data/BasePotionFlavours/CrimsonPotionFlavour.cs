using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class CrimsonPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Crimson";
}
