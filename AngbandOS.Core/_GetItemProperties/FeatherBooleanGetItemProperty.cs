namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class FeatherBooleanGetItemProperty : GetItemProperty<bool>
{
    public FeatherBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(AttributeEnum.Feather);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Feather;
    }
}