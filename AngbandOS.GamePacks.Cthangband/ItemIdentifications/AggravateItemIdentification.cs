namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AggravateItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(AggravateItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It aggravates nearby creatures." };
    }
}