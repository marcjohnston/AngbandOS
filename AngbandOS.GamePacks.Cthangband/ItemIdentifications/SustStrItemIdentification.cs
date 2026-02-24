namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustStrItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SustStrItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your strength." };
    }
}