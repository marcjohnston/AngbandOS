namespace AngbandOS.Core.Flavours;

[Serializable]
internal class OakStaffFlavour : StaffFlavour
{
    private OakStaffFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Oak";
}
