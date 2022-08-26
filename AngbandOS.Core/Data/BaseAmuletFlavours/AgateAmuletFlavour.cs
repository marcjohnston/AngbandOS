using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AgateAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Agate";
}
