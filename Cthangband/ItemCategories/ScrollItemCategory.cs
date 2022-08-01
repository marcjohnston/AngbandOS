using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollItemCategory : BaseItemCategory
    {
        public ScrollItemCategory() : base(ItemCategory.Scroll)
        {
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : SaveGame.Instance.ScrollFlavours[item.ItemSubCategory].Name;
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{Pluralize("Scroll", item.Count)} titled \"{flavour}\"{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 20;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBeige;
        public override int PercentageBreakageChance => 50;
    }
}
