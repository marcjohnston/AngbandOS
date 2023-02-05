namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class SilverStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
