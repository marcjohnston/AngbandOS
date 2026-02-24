namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WisdomItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(WisdomItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your wisdom." };
    }
}