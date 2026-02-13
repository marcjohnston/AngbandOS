namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ImAcidBooleanGetItemProperty : GetItemProperty<bool>
{
    public ImAcidBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ImAcid;
    }
}