using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
