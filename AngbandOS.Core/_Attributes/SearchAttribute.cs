namespace AngbandOS.Core;
    [Serializable]
internal class SearchAttribute : SumAttribute
{
    private SearchAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.Search;
}