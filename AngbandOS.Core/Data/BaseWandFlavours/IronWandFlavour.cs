using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class IronWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Iron";
}
