namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class IgnoreElecBooleanGetItemProperty : GetItemProperty<bool>
{
    public IgnoreElecBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.IgnoreElec);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.IgnoreElec;
    }
}