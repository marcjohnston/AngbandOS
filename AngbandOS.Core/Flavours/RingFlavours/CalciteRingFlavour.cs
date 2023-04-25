namespace AngbandOS.Core.Flavours;

[Serializable]
internal class CalciteRingFlavour : RingFlavour
{
    private CalciteRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Calcite";
}
