namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class BlessedBooleanGetItemProperty : GetItemProperty<bool>
{
    public BlessedBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectiveAttributeSet.Blessed);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Blessed;
    }
}