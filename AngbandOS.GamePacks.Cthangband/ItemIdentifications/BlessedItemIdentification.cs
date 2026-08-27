namespace AngbandOS.GamePacks.Cthangband
{
    public class BlessedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(BlessedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It has been blessed by the gods." };
    }
}