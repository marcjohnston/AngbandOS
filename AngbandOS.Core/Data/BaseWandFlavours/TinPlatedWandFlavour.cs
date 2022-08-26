using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TinPlatedWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override string Name => "Tin-Plated";
}
