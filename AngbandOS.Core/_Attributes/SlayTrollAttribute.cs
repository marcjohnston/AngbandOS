namespace AngbandOS.Core;
    [Serializable]
internal class SlayTrollAttribute : OrAttribute
{
    private SlayTrollAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SlayTroll;
}