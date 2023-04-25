namespace AngbandOS.Core.Flavours;

[Serializable]
internal class EucalyptusStaffFlavour : StaffFlavour
{
    private EucalyptusStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Eucalyptus";
}
