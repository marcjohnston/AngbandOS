namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class DreadCurseBooleanGetItemProperty : GetItemProperty<bool>
{
    public DreadCurseBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.DreadCurse;
    }
}