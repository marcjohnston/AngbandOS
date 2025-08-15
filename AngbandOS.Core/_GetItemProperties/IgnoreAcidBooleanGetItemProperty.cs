namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class IgnoreAcidBooleanGetItemProperty : GetItemProperty<bool>
{
    public IgnoreAcidBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.IgnoreAcid);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.IgnoreAcid;
    }
}