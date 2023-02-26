namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class MithrilRingFlavour : RingFlavour
{
    private MithrilRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Mithril";
}
