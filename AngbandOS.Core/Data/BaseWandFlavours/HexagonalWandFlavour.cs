using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HexagonalWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Hexagonal";
}
