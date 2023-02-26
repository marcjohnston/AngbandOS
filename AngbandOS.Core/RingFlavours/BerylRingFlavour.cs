namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class BerylRingFlavour : RingFlavour
{
    private BerylRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Beryl";
}
