namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class JetRingFlavour : RingFlavour
{
    private JetRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Black;
    public override string Name => "Jet";
}
