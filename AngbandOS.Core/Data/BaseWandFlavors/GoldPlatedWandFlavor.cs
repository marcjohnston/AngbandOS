using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class GoldPlatedWandFlavor : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold-Plated";
}
