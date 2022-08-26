using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SteelRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override string Name => "Steel";
}
