namespace AngbandOS.Core;
    [Serializable]
internal class ResNexusAttribute : OrAttribute
{
    private ResNexusAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.ResNexus;
}