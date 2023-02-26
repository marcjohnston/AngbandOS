namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class JasperRingFlavour : RingFlavour
{
    private JasperRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Jasper";
}
