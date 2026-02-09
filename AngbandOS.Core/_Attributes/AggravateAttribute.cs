namespace AngbandOS.Core;
    [Serializable]
internal class AggravateAttribute : OrAttribute
{
    private AggravateAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Aggravate;
}