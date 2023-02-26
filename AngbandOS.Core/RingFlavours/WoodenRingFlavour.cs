namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class WoodenRingFlavour : RingFlavour
{
    private WoodenRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Wooden";
}
