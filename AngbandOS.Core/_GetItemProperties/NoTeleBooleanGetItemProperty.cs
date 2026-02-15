namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class NoTeleBooleanGetItemProperty : GetItemProperty<bool>
{
    public NoTeleBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.NoTele;
    }
}