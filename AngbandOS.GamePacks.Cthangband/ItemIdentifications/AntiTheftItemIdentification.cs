using AngbandOS.GamePacks.Cthangband.AttributeFilters;

namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AntiTheftItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(AntiTheftItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It prevents theft from your purse and pack." };
    }
}