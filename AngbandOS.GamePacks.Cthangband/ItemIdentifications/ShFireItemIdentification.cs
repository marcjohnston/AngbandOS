namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ShFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ShFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It produces a fiery sheath." };
    }
}