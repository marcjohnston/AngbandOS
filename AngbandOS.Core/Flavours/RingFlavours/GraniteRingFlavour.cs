namespace AngbandOS.Core.Flavours;

[Serializable]
internal class GraniteRingFlavour : RingFlavour
{
    private GraniteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Black;
    public override string Name => "Granite";
}