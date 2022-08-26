using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlueMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Blue";
}
