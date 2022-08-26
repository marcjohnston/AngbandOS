using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class IvoryWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory";
}
