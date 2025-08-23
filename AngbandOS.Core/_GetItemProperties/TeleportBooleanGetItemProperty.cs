namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class TeleportBooleanGetItemProperty : GetItemProperty<bool>
{
    public TeleportBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.Teleport);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Teleport;
    }
}