using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SteelPlatedWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Steel-Plated";
}
