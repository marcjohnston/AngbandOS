using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow";
}
