namespace AngbandOS.Core;

[Serializable]
internal class LeadPlatedWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead-Plated";
}
