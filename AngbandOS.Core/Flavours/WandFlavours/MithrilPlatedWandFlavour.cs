namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MithrilPlatedWandFlavour : WandFlavour
{
    private MithrilPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril-Plated";
}
