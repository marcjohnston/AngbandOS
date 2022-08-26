using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DilithiumRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Dilithium";
}
