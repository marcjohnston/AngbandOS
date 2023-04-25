namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MithrilRodFlavour : RodFlavour
{
    private MithrilRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril";
}
