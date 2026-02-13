namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ReflectBooleanGetItemProperty : GetItemProperty<bool>
{
    public ReflectBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Reflect;
    }
}