namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class HoldLifeBooleanGetItemProperty : GetItemProperty<bool>
{
    public HoldLifeBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.HoldLife);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.HoldLife;
    }
}