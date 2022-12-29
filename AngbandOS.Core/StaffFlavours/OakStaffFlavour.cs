namespace AngbandOS.Core;

[Serializable]
internal class OakStaffFlavour : StaffFlavour
{
    public override char Character => '_';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Oak";
}
