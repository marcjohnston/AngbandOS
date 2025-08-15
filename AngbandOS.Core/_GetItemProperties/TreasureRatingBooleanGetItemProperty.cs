namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class TreasureRatingBooleanGetItemProperty : GetItemProperty<bool>
{
    public TreasureRatingBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.TreasureRating);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.TreasureRating > 0;
    }
}