namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ImFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides immunity to fire." };
    }
}