namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class LocustStaffFlavour : StaffFlavour
{
    private LocustStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Locust";
}
