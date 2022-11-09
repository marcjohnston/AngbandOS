using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class NickelWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override string Name => "Nickel";
}
