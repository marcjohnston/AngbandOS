using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MetallicGreenPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Metallic Green";
}