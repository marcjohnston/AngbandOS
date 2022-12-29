namespace AngbandOS.Core;

[Serializable]
internal class RedwoodStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Red;
    public override string Name => "Redwood";
}
