namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class MoonstoneRingFlavour : RingFlavour
{
    private MoonstoneRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Moonstone";
}
