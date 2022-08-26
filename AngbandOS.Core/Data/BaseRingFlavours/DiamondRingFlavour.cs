using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DiamondRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Diamond";
}
