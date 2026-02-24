namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AntiTheftItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(AntiTheftItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It prevents theft from your purse and pack." };
    }
}