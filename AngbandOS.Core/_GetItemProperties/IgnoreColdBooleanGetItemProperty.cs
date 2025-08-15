namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class IgnoreColdBooleanGetItemProperty : GetItemProperty<bool>
{
    public IgnoreColdBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.IgnoreCold);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.IgnoreCold;
    }
}