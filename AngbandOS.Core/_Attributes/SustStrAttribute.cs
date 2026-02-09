namespace AngbandOS.Core;
    [Serializable]
internal class SustStrAttribute : OrAttribute
{
    private SustStrAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SustStr;
}