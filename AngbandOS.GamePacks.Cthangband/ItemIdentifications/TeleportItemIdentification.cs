namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TeleportItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(TeleportItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It induces random teleportation." };
    }
}