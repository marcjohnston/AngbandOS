using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ZirconiumWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Zirconium";
}
