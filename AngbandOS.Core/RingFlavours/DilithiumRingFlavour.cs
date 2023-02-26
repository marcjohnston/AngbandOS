namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class DilithiumRingFlavour : RingFlavour
{
    private DilithiumRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "Dilithium";
}
