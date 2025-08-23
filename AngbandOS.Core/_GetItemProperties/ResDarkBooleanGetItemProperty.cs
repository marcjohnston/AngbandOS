namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResDarkBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResDarkBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.ResDark);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResDark;
    }
}