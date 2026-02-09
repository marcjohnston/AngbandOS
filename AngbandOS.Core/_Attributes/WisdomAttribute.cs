namespace AngbandOS.Core;
    [Serializable]
internal class WisdomAttribute : SumAttribute
{
    private WisdomAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Wisdom;
}