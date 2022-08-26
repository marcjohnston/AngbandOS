using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WrinkledMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Wrinkled";
}
