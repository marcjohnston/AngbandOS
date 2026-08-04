namespace AngbandOS.GamePacks.Cthangband
{
    public class CursedItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributeFilterBindingKey => nameof(CursedItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It is cursed." };
    }
}