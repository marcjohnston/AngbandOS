using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LongRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Long";
}
