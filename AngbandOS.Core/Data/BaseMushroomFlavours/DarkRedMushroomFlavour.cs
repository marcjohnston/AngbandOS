using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DarkRedMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Red;
    public override string Name => "Dark Red";
}
