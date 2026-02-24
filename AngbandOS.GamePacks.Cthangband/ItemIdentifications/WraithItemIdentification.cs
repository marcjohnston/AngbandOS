namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class WraithItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(WraithItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It renders you incorporeal." };
    }
}