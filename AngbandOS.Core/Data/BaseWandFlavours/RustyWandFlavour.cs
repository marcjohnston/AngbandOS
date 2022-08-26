using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RustyWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
