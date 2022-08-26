using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class NickelPlatedWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Nickel-Plated";
}
