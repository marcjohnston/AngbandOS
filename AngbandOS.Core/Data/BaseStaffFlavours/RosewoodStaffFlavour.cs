using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class RosewoodStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Red;
    public override string Name => "Rosewood";
}
