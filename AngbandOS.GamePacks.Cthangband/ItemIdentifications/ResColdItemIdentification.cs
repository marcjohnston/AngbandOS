namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResColdItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResColdItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to cold." };
    }
}