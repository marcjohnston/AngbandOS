using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class SilverStaffFlavour : BaseStaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
