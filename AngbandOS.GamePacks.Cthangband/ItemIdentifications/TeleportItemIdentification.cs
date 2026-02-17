namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class TeleportItemIdentification : ItemIdentificationGameConfiguration
    {
        public override (string AttributeKey, bool DesiredValue)[]? OrAttributeFilterBindings => new (string, bool)[] { (nameof(TeleportAttribute), true) };
        public override string[] EffectDescription => new string[] { "It induces random teleportation." };
    }
}