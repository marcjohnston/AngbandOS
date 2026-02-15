namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class CanApplyBlessedArtifactBiasBooleanGetItemProperty : GetItemProperty<bool>
{
    public CanApplyBlessedArtifactBiasBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.CanApplyBlessedArtifactBias;
    }
}