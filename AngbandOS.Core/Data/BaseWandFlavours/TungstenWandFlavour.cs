using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class TungstenWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Tungsten";
}
