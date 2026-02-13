namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class TelepathyBooleanGetItemProperty : GetItemProperty<bool>
{
    public TelepathyBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.Telepathy;
    }
}