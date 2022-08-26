using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DarkGreenPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Green;
    public override string Name => "Dark Green";
}
