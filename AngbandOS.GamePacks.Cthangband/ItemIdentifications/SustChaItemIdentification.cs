namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustChaItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(SustChaItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your charisma." };
    }
}