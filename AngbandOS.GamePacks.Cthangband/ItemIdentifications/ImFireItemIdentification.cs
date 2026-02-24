namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ImFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ImFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides immunity to fire." };
    }
}