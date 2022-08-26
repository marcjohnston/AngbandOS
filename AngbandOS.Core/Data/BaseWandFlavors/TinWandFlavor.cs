using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TinWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Tin";
}
