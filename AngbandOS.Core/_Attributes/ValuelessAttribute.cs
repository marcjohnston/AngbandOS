namespace AngbandOS.Core;
    [Serializable]
internal class ValuelessAttribute : OrAttribute
{
    private ValuelessAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Valueless;
}