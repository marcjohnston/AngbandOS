namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BalsaStaffFlavour : StaffFlavour
{
    private BalsaStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Beige;
    public override string Name => "Balsa";
}
