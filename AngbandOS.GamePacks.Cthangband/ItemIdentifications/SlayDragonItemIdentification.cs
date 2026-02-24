namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDragonItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SlayDragonItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is especially deadly against dragons." };
    }
}