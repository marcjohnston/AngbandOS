using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HexagonalWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Hexagonal";
}
