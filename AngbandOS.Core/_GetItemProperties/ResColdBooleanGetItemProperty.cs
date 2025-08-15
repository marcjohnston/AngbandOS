namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResColdBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResColdBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ResCold);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResCold;
    }
}