using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IvoryAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
