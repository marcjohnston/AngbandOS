namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class HeavyCurseBooleanGetItemProperty : GetItemProperty<bool>
{
    public HeavyCurseBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.HeavyCurse);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.HeavyCurse;
    }
}