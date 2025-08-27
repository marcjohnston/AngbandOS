namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ArtifactBiasSlayingDisabledBooleanGetItemProperty : GetItemProperty<bool>
{
    public ArtifactBiasSlayingDisabledBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectiveAttributeSet.ArtifactBiasSlayingDisabled);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ArtifactBiasSlayingDisabled;
    }
}