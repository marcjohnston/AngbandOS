namespace AngbandOS.Core.Flavours;

[Serializable]
internal class OpalRingFlavour : RingFlavour
{
    private OpalRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Opal";
}
