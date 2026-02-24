namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResShardsItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResShardsItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to shards." };
    }
}