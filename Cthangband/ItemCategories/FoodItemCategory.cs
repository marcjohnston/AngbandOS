using Cthangband.Enumerations;
using Cthangband.StaticData;

namespace Cthangband.ItemCategories
{
    internal class FoodItemCategory : BaseItemCategory
    {
        //public override string GetDescription(Item item, bool includeCountPrefix)
        //{
        //    if (item.ItemSubCategory >= FoodType.MinFood)
        //    {
        //        return base.Description(item, includeCountPrefix);
        //    }
        //    string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.MushroomFlavours[item.ItemSubCategory].Name} ";
        //    string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
        //    string name = $"{flavour}{Pluralize("Mushroom", item.Count)}{ofName}";
        //    return includeCountPrefix ? GetPrefixCount(true, name, item.Count) : name;
        //}
        //public override int BaseValue => 5;
        //public override bool CanBeConsumed => true;
        //public override Colour Colour => Colour.Green;
        //public override int PercentageBreakageChance => 100;
    }
}
