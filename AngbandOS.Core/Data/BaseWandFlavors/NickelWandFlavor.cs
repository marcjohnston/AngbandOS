using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class NickelWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Nickel";
}
