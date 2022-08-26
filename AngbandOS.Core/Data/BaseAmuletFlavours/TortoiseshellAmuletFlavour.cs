using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TortoiseshellAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Tortoiseshell";
}
