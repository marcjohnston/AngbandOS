namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResFireBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResFireBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResFire;
    }
}