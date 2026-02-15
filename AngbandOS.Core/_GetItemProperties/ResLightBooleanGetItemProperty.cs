namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ResLightBooleanGetItemProperty : GetItemProperty<bool>
{
    public ResLightBooleanGetItemProperty(Game game) : base(game) { }
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ResLight;
    }
}