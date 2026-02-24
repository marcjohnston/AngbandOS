namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ReflectItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ReflectItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It reflects bolts and arrows." };
    }
}