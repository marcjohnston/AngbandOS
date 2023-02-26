namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class FlouriteRingFlavour : RingFlavour
{
    private FlouriteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Green;
    public override string Name => "Flourite";
}
