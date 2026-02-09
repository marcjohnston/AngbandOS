namespace AngbandOS.Core;
    [Serializable]
internal class WeightAttribute : SumAttribute
{
    private WeightAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Weight;
}