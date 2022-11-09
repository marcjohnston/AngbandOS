using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AmberAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Amber";
}
