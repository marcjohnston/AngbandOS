namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResShardsItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(ResShardsAttribute), true) };
        public override string[] EffectDescription => new string[] { "It provides resistance to shards." };
    }
}