using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PearlRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Pearl";
}
