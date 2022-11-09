using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MithrilPlatedRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril-Plated";
}
