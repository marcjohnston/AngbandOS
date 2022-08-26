using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrownPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Brown";
}
