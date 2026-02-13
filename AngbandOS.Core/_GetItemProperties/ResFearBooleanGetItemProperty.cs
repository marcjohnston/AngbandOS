namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResFearBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResFearBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResFear;
    }
}