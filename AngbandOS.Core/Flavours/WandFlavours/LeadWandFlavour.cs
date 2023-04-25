namespace AngbandOS.Core.Flavours;

[Serializable]
internal class LeadWandFlavour : WandFlavour
{
    private LeadWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead";
}
