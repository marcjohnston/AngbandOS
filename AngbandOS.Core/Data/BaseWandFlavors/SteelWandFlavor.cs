using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SteelWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Steel";
}
