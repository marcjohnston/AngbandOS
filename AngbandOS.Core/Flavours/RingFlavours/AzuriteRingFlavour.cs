namespace AngbandOS.Core.Flavours;

[Serializable]
internal class AzuriteRingFlavour : RingFlavour
{
    private AzuriteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Azurite";
}
