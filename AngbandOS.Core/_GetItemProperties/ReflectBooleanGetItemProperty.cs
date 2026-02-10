namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ReflectBooleanGetItemProperty : GetItemProperty<bool>
{
    public ReflectBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.Reflect);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Reflect;
    }
}