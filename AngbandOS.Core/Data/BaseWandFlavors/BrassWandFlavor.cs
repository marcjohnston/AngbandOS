using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BrassWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}
