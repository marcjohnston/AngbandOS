namespace AngbandOS.Core.Flavours;

[Serializable]
internal class RubyRingFlavour : RingFlavour
{
    private RubyRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Ruby";
}
