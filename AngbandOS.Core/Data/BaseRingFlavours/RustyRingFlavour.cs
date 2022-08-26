using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RustyRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
