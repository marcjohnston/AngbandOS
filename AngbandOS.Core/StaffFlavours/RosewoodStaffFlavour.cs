using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RosewoodStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Red;
    public override string Name => "Rosewood";
}