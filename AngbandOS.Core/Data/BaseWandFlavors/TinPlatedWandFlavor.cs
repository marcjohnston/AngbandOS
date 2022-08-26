using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TinPlatedWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Tin-Plated";
}
