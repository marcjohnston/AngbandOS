namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BirchStaffFlavour : StaffFlavour
{
    private BirchStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Birch";
}