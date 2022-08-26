using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MagnesiumWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Magnesium";
}
