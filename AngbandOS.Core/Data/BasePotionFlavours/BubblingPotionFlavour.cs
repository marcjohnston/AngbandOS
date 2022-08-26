using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BubblingPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "Bubbling";
}
