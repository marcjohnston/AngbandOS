using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class LightBluePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Light Blue";
}
