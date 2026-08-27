namespace AngbandOS.GamePacks.Cthangband
{
    public class CharismaItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(CharismaItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your charisma." };
    }
}