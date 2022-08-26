using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Red";
}
