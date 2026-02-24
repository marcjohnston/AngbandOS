namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class HeavilyCursedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(HeavilyCursedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is heavily cursed." };
    }
}