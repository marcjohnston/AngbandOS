using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MithrilPlatedWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril-Plated";
}
