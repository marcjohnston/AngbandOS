namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class HexagonalWandFlavour : WandFlavour
{
    private HexagonalWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Hexagonal";
}
