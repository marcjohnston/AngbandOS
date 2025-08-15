namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class CanApplyArtifactBiasSlayingBooleanGetItemProperty : GetItemProperty<bool>
{
    public CanApplyArtifactBiasSlayingBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.CanApplyArtifactBiasSlaying);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.CanApplyArtifactBiasSlaying;
    }
}