namespace AngbandOS.Core.Flavours;

[Serializable]
internal class RhodoniteRingFlavour : RingFlavour
{
    private RhodoniteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Rhodonite";
}
