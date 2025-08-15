namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class AggravateBooleanGetItemProperty : GetItemProperty<bool>
{
    public AggravateBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.Aggravate);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Aggravate;
    }
}