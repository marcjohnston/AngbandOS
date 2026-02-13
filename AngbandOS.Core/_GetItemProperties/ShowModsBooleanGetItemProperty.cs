namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ShowModsBooleanGetItemProperty : GetItemProperty<bool>
{
    public ShowModsBooleanGetItemProperty(Game game) : base(game) { }
    public override string DebugDescription => nameof(AggravateAttribute);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ShowMods;
    }
}