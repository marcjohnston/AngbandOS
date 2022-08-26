using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SilverWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
