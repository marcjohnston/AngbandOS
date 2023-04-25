namespace AngbandOS.Core.Flavours;

[Serializable]
internal class MahoganyStaffFlavour : StaffFlavour
{
    private MahoganyStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Mahogany";
}
