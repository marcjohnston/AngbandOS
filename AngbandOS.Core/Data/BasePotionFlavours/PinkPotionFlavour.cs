using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PinkPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Pink";
}
