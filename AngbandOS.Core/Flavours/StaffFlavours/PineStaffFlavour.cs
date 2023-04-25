namespace AngbandOS.Core.Flavours;

[Serializable]
internal class PineStaffFlavour : StaffFlavour
{
    private PineStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Pine";
}
