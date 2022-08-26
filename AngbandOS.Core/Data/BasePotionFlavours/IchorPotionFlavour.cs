using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class IchorPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Black;
    public override string Name => "Ichor";
}
