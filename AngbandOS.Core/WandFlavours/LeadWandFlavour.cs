using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LeadWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead";
}
