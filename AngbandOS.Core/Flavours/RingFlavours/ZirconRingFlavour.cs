namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ZirconRingFlavour : RingFlavour
{
    private ZirconRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Zircon";
}
