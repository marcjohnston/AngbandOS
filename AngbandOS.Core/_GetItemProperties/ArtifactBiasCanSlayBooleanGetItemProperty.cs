namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ArtifactBiasCanSlayBooleanGetItemProperty : GetItemProperty<bool>
{
    public ArtifactBiasCanSlayBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ArtifactBiasCanSlay;
    }
}