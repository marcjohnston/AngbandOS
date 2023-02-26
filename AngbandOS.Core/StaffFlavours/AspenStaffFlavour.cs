namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class AspenStaffFlavour : StaffFlavour
{
    private AspenStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Aspen";
}
