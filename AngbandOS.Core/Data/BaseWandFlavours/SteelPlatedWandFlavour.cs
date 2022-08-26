using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SteelPlatedWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override string Name => "Steel-Plated";
}
