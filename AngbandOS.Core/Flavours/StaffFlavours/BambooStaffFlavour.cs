namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BambooStaffFlavour : StaffFlavour
{
    private BambooStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Bamboo";
}
