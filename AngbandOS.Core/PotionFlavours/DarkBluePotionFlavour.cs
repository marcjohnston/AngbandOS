using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DarkBluePotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Dark Blue";
}
