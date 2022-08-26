using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class MetallicPurplePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Metallic Purple";
}
