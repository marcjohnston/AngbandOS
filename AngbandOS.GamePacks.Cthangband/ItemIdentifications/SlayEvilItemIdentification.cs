namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayEvilItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SlayEvilItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It fights against evil with holy fury." };
    }
}