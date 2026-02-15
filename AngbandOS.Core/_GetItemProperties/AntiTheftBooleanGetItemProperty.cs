namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class AntiTheftBooleanGetItemProperty : GetItemProperty<bool>
{
    public AntiTheftBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.AntiTheft;
    }
}