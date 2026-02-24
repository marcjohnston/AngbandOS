namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImColdItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ImColdItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides immunity to cold." };
    }
}