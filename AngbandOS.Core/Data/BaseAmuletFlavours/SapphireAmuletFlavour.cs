using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SapphireAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Sapphire";
}
