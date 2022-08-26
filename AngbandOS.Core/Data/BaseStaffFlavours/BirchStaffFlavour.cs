using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class BirchStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Birch";
}
