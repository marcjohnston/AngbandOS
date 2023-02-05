namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class RunedStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Runed";
}
