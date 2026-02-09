namespace AngbandOS.Core;
    [Serializable]
internal class SlayOrcAttribute : OrAttribute
{
    private SlayOrcAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayOrc;
}