using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TitaniumWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Titanium";
}
