namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class VampiricBooleanGetItemProperty : GetItemProperty<bool>
{
    public VampiricBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.Vampiric);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Vampiric;
    }
}