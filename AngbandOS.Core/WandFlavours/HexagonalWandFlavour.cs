namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class HexagonalWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Hexagonal";
}
