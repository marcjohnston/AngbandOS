namespace AngbandOS.GamePacks.Cthangband
{
    public class ResSoundItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResSoundItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It provides resistance to sound." };
    }
}