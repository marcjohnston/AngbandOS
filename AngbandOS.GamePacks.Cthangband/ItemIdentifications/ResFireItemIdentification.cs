namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFireItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(ResFireItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to fire." };
    }
}