namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class TransparentRingFlavour : RingFlavour
{
    private TransparentRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Transparent";
}
