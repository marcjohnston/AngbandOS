using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MetallicBluePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Metallic Blue";
}