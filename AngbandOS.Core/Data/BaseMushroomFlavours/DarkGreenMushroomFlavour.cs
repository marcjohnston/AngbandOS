using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class DarkGreenMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Green;
    public override string Name => "Dark Green";
}
