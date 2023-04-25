namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MalachiteRingFlavour : RingFlavour
{
    private MalachiteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Malachite";
}
