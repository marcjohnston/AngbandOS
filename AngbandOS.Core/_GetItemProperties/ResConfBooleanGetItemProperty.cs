namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResConfBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResConfBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.ResConf);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResConf;
    }
}