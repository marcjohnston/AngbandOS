namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class SycamoreStaffFlavour : StaffFlavour
{
    private SycamoreStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Sycamore";
}
