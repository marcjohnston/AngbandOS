namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class SustChaItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(SustChaItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It sustains your charisma." };
    }
}