using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class VioletMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Violet";
}
