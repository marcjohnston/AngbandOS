using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OpalRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Opal";
}
