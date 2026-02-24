namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class RegenItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(RegenItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It speeds your regenerative powers." };
    }
}