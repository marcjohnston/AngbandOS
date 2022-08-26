using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PucePotionFlavour : BasePotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Puce";
}
