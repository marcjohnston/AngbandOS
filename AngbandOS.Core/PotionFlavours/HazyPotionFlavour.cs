using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HazyPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Hazy";
}
