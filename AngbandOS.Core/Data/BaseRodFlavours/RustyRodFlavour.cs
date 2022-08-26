using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RustyRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Rusty";
}
