namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BanyanStaffFlavour : StaffFlavour
{
    private BanyanStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Banyan";
}
