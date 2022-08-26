using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RunedWandFlavour : BaseWandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Runed";
}
