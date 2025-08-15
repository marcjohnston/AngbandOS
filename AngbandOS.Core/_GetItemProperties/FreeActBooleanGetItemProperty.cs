namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class FreeActBooleanGetItemProperty : GetItemProperty<bool>
{
    public FreeActBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.FreeAct);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.FreeAct;
    }
}