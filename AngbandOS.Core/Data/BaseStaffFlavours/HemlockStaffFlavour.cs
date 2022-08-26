using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class HemlockStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hemlock";
}
