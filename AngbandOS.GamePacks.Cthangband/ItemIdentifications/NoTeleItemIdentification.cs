namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class NoTeleItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(NoTeleItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It prevents teleportation." };
    }
}