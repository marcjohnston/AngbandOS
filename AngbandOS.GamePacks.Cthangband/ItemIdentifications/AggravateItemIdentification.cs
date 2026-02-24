using AngbandOS.GamePacks.Cthangband.AttributeFilters;

namespace AngbandOS.GamePacks.Cthangband
{
    [Serializable]
    public class AggravateItemIdentification : ItemIdentificationGameConfiguration
{
        public override string AttributesFilterBindingKey => nameof(AggravateItemIdentificationAttributeFilter);
        public override string[] EffectDescription => new string[] { "It aggravates nearby creatures." };
    }
}