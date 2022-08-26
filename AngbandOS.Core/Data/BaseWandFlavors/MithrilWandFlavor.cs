using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MithrilWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril";
}
