using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class PurplePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Purple";
}
