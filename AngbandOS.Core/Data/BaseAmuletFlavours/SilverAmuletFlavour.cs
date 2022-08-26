using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SilverAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
