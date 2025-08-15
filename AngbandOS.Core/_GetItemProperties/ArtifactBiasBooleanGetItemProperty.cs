namespace AngbandOS.Core.GetItemProperties;
    [Serializable]
internal class ArtifactBiasBooleanGetItemProperty : GetItemProperty<bool>
{
    public ArtifactBiasBooleanGetItemProperty(Game game) : base(game) { }

    public override string DebugDescription => nameof(EffectivePropertySet.ArtifactBias);
    public override bool Get(Item item)
    {
        return item.EffectivePropertySet.ArtifactBias != null;
    }
}