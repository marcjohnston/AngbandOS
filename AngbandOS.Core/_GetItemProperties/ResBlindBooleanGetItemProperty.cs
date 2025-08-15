namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResBlindBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResBlindBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectivePropertySet.ResBlind);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResBlind;
    }
}