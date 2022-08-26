using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CrystalAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Crystal";
}
