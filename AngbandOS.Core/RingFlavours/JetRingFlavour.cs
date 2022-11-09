using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class JetRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Black;
    public override string Name => "Jet";
}
