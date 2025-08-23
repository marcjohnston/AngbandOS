namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class SeeInvisBooleanGetItemProperty : GetItemProperty<bool>
{
    public SeeInvisBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(EffectiveAttributeSet.SeeInvis);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.SeeInvis;
    }
}