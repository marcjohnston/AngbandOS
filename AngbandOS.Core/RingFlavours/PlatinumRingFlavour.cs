namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class PlatinumRingFlavour : RingFlavour
{
    private PlatinumRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Platinum";
}
