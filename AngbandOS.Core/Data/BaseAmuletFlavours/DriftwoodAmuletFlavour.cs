using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class DriftwoodAmuletFlavour : BaseAmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Driftwood";
}
