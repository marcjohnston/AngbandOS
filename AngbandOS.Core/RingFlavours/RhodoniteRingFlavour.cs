using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RhodoniteRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Rhodonite";
}