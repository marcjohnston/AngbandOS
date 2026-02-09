namespace AngbandOS.Core;
    [Serializable]
internal class TreasureRatingAttribute : SumAttribute
{
    private TreasureRatingAttribute(Game game) : base(game) { }
    public override int Index => (int)AttributeEnum.TreasureRating;
}