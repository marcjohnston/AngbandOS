using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldenAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Golden";
}
