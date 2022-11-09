using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class HemlockStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Hemlock";
}
