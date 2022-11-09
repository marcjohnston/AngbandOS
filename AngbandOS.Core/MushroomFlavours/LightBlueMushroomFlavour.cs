using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LightBlueMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "Light Blue";
}
