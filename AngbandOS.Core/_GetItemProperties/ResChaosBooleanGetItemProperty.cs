namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResChaosBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResChaosBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.ResChaos);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResChaos;
    }
}