using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AquamarineRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Aquamarine";
}
