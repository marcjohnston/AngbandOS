using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class ShortRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Green;
    public override string Name => "Short";
}
