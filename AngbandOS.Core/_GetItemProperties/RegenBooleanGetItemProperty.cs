namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class RegenBooleanGetItemProperty : GetItemProperty<bool>
{
    public RegenBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Regen;
    }
}