namespace AngbandOS.Core.GetItemProperties;
internal class ArtifactBiasCanSlayBooleanGetItemProperty : GetItemProperty<bool>
{
    public ArtifactBiasCanSlayBooleanGetItemProperty(Game game) : base(game) { }

    public override bool Get(Item item)
    {
        return item.EffectiveAttributeSet.Get<OrEffectiveAttributeValue>(nameof(ArtifactBiasCanSlayAttribute)).Get();
    }
}