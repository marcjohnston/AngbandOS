namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class LeadPlatedRodFlavour : RodFlavour
{
    private LeadPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead-Plated";
}
