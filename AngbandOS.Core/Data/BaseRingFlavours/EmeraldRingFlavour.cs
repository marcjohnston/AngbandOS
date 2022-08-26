using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class EmeraldRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Emerald";
}
