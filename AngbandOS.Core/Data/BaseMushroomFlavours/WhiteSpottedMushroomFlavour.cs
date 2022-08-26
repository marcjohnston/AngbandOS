using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteSpottedMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Silver;
    public override string Name => "White Spotted";
}
