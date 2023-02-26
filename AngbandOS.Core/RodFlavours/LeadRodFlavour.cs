namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class LeadRodFlavour : RodFlavour
{
    private LeadRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead";
}
