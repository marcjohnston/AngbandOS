using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FoodItemCategory : BaseItemCategory
    {
        public FoodItemCategory() : base(ItemCategory.Food)
        {
        }

        public override bool CanAbsorb(Item item, Item other)
        {
            return true;
        }

        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.ItemSubCategory >= FoodType.MinFood)
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.MushroomFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Mushroom", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        public override Colour Colour => Colour.Green;
        public override int PercentageBreakageChance => 100;
    }
}
