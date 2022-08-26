using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class DarkBluePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Dark Blue";
}
