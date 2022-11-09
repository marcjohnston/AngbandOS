using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ZirconiumWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Zirconium";
}
