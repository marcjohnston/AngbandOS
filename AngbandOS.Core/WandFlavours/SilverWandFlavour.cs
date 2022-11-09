using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
