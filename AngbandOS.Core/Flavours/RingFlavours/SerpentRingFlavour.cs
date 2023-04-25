namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SerpentRingFlavour : RingFlavour
{
    private SerpentRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Serpent";
}
