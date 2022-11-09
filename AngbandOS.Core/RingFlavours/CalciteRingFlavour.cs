using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CalciteRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Calcite";
}
