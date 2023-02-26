namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class TigerEyeRingFlavour : RingFlavour
{
    private TigerEyeRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Tiger Eye";
}
