namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MithrilWandFlavour : WandFlavour
{
    private MithrilWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril";
}
