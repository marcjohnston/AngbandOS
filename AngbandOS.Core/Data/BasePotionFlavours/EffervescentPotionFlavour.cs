using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class EffervescentPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Effervescent";
}
