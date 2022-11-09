using AngbandOS.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WireRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override string Name => "Wire";
}
