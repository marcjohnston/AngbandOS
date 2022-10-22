using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IndigoPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Indigo";
}
