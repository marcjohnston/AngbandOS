namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SilverRingFlavour : RingFlavour
{
    private SilverRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
