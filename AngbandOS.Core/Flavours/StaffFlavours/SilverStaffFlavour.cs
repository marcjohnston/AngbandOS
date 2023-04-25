namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SilverStaffFlavour : StaffFlavour
{
    private SilverStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}
