using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MithrilWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril";
}