namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class Vorpal1InChanceItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(Vorpal1InChanceItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is very sharp and can cut your foes." };
    }
}