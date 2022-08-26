using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ShortWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Short";
}
