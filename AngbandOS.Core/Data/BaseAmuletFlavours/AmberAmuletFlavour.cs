using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AmberAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Amber";
}
