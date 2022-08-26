using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChartreusePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Chartreuse";
}
