using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperPlatedWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Copper-Plated";
}
