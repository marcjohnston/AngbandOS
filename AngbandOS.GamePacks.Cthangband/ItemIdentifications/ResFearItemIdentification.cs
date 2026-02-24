namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class ResFearItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(ResFearItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It makes you completely fearless." };
    }
}