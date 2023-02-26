namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class MarbleRingFlavour : RingFlavour
{
    private MarbleRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Marble";
}
