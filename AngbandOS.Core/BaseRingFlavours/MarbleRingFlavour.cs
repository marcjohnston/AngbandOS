using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MarbleRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Marble";
}
