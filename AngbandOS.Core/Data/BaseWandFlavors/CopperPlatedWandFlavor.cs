using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class CopperPlatedWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Copper-Plated";
}
