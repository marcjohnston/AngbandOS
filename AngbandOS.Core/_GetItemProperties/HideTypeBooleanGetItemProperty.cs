namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class HideTypeBooleanGetItemProperty : GetItemProperty<bool>
{
    public HideTypeBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.HideType);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.HideType;
    }
}