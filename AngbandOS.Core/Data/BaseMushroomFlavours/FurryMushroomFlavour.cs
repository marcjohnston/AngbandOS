using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class FurryMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Furry";
}
