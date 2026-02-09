namespace AngbandOS.Core;
    [Serializable]
internal class ValueAttribute : SumAttribute
{
    private ValueAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Value;
}