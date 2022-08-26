using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PewterAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "Pewter";
}
