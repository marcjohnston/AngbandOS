using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SteelWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override string Name => "Steel";
}
