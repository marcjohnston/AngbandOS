namespace AngbandOS.Core.Flavours;

[Serializable]
internal class TopazRingFlavour : RingFlavour
{
    private TopazRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Topaz";
}
