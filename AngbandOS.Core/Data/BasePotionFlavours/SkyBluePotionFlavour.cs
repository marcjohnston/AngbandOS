using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SkyBluePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Sky Blue";
}
