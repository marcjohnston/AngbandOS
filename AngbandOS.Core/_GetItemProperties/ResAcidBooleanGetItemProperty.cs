namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResAcidBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResAcidBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ResAcid);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResAcid;
    }
}