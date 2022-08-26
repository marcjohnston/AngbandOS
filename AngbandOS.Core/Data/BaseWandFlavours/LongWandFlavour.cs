using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LongWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Green;
    public override string Name => "Long";
}
