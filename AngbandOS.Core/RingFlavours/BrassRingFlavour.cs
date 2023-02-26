namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class BrassRingFlavour : RingFlavour
{
    private BrassRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}
