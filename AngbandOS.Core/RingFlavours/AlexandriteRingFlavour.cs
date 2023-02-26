namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class AlexandriteRingFlavour : RingFlavour
{
    private AlexandriteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Alexandrite";
}
