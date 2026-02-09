namespace AngbandOS.Core;
    [Serializable]
internal class SearchFrequencyAttribute : SumAttribute
{
    private SearchFrequencyAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.SearchFrequency;
}