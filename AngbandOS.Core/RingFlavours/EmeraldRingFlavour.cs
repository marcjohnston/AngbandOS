namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class EmeraldRingFlavour : RingFlavour
{
    private EmeraldRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Emerald";
}
