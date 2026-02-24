namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class IgnoreFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(IgnoreFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It cannot be harmed by fire." };
    }
}