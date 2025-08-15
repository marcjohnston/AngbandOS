namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class AntiTheftBooleanGetItemProperty : GetItemProperty<bool>
{
    public AntiTheftBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.AntiTheft);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.AntiTheft;
    }
}