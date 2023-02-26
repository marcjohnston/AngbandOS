namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class TurquiseRingFlavour : RingFlavour
{
    private TurquiseRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "Turquise";
}
