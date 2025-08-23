namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SlayTrollBooleanGetItemProperty : GetItemProperty<bool>
{
    public SlayTrollBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.SlayTroll);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SlayTroll;
    }
}