using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MithrilPlatedRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril-Plated";
}
