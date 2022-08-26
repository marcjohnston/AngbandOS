using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class CopperPlatedRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Copper-Plated";
}
