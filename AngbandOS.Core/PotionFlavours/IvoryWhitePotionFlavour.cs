using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IvoryWhitePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "Ivory White";
}