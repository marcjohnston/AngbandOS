namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class LeadRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead";
}
