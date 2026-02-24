namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SlayDragonBaneItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SlayDragonBaneItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is a great bane of dragons." };
    }
}