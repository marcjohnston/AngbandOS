namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TunnelItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(TunnelItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your ability to tunnel." };
    }
}