namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class EasyKnowBooleanGetItemProperty : GetItemProperty<bool>
{
    public EasyKnowBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.EasyKnow;
    }
}