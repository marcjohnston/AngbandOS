using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HexagonalWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Hexagonal";
}
