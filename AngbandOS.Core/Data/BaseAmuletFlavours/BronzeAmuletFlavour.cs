using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BronzeAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Bronze";
}
