namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class RosewoodStaffFlavour : StaffFlavour
{
    private RosewoodStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Red;
    public override string Name => "Rosewood";
}
