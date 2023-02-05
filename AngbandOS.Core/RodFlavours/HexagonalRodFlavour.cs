namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class HexagonalRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Hexagonal";
}
