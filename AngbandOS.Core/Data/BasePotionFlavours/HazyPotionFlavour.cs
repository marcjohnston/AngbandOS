using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HazyPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Hazy";
}
