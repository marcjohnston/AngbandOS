using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class LeadWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead";
}
