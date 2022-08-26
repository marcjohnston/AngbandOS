using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class VermillionPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Vermillion";
}
