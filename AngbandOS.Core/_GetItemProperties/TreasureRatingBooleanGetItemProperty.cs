namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class TreasureRatingBooleanGetItemProperty : GetItemProperty<bool>
{
    public TreasureRatingBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.TreasureRating > 0;
    }
}