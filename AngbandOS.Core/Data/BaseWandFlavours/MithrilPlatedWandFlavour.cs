using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MithrilPlatedWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril-Plated";
}
