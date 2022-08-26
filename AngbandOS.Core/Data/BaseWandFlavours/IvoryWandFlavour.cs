using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IvoryWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
