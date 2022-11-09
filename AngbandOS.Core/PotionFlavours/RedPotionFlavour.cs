using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Red";
}
