namespace AngbandOS.GamePacks.Cthangband
{
    public class NoTeleItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(NoTeleItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It prevents teleportation." };
    }
}