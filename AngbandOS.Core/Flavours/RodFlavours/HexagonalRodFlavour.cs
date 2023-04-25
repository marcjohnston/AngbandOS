namespace AngbandOS.Core.Flavours;

[Serializable]
internal class HexagonalRodFlavour : RodFlavour
{
    private HexagonalRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Hexagonal";
}
