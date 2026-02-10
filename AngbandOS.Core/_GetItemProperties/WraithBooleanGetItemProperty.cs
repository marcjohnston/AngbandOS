namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class WraithBooleanGetItemProperty : GetItemProperty<bool>
{
    public WraithBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AttributeEnum.Wraith);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Wraith;
    }
}