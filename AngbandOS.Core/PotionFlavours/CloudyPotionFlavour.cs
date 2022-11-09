using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CloudyPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "Cloudy";
}
