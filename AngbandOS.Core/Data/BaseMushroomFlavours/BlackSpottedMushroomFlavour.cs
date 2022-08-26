using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BlackSpottedMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Black;
    public override string Name => "Black Spotted";
}
