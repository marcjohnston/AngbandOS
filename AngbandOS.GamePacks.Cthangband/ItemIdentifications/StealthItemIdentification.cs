namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class StealthItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(StealthItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your stealth." };
    }
}