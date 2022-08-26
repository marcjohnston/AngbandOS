using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SilverWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
