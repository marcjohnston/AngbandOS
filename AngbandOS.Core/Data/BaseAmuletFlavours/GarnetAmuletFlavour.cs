using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GarnetAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Red;
    public override string Name => "Garnet";
}
