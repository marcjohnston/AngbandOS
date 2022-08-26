using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class CastIronWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Cast Iron";
}
