namespace AngbandOS.GamePacks.Cthangband
{
    public class StrengthItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(StrengthItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It affects your strength." };
    }
}