using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class WalnutStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Walnut";
}
