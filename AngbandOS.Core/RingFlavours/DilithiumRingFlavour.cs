using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DilithiumRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Dilithium";
}