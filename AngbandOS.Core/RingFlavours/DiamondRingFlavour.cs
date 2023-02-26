namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class DiamondRingFlavour : RingFlavour
{
    private DiamondRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Diamond";
}
