using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TangerinePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Tangerine";
}