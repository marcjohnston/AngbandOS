namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreColdItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(IgnoreColdItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It cannot be harmed by cold." };
    }
}