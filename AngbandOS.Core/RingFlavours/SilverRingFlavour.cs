using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
