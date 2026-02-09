namespace AngbandOS.Core;
    [Serializable]
internal class SustConAttribute : OrAttribute
{
    private SustConAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SustCon;
}