using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrassAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}
