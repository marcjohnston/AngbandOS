using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ClottedRedPotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Clotted Red";
}
