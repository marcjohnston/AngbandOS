using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PlatinumRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Platinum";
}
