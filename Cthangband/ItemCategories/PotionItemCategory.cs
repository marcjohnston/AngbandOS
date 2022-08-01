using Cthangband.Enumerations;
using Cthangband.StaticData;

namespace Cthangband.ItemCategories
{
    internal class PotionItemCategory : BaseItemCategory
    {
        //public override string GetDescription(Item item, bool includeCountPrefix)
        //{
        //    string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.PotionFlavours[item.ItemSubCategory].Name} ";
        //    string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
        //    string name = $"{flavour}{Pluralize("Potion", item.Count)}{ofName}";
        //    return includeCountPrefix ? GetPrefixCount(true, name, item.Count) : name;
        //}
        //public override int BaseValue => 20;
        //public override bool HatesCold => true;
        //public override Colour Colour => Colour.Blue;
        //public override int PercentageBreakageChance => 100;
    }
}
