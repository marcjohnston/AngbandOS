namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ActivationItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ActivationItemIdentificationAttributeFilter);
        public override string[]? InterpolationExpressionAttributeNames => new string[] { nameof(SystemAttributes.ActivationAttribute) };
        public override string[] EffectDescription => new string[] { "It can be activated for...", "{0}", "...if it is being worn." };
    }
}