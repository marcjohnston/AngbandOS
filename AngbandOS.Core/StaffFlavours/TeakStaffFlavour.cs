namespace AngbandOS.Core.StaffFlavours;

[Serializable]
internal class TeakStaffFlavour : StaffFlavour
{
    private TeakStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Teak";
}
