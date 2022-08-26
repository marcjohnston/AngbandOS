using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class NickelWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override string Name => "Nickel";
}
