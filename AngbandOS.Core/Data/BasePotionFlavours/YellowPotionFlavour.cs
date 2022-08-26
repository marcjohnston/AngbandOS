using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class YellowPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow";
}
