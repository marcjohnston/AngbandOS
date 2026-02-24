namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class VampiricItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(VampiricItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It drains life from your foes." };
    }
}