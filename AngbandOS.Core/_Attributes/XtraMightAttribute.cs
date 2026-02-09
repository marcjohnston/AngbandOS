namespace AngbandOS.Core;
    [Serializable]
internal class XtraMightAttribute : OrAttribute
{
    private XtraMightAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.XtraMight;
}