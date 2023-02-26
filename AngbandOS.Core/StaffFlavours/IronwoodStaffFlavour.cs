namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class IronwoodStaffFlavour : StaffFlavour
{
    private IronwoodStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Ironwood";
}
