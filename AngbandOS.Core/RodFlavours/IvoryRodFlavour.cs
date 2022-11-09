using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IvoryRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
