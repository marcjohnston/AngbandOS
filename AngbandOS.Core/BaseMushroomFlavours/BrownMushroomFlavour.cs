using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrownMushroomFlavour : BaseMushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Brown";
}
