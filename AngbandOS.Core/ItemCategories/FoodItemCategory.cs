using AngbandOS.Core.Interface;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class FoodItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Food;
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
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{item.SaveGame.MushroomFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Mushroom", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        public override Colour Colour => Colour.Green;
        public override int PercentageBreakageChance => 100;

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }
    }
}
