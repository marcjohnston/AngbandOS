using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WireRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override string Name => "Wire";
}
