namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class PearlRingFlavour : RingFlavour
{
    private PearlRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Pearl";
}
