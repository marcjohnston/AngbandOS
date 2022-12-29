namespace AngbandOS.Core;

[Serializable]
internal class LocustStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Locust";
}
