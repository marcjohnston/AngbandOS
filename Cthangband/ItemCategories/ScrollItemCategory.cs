using Cthangband.Enumerations;
using Cthangband.StaticData;

namespace Cthangband.ItemCategories
{
    internal class ScrollItemCategory : BaseItemCategory
    {
        //public override string GetDescription(Item item, bool includeCountPrefix)
        //{
        //    string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : SaveGame.Instance.ScrollFlavours[item.ItemSubCategory].Name;
        //    string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
        //    string name = $"{Pluralize("Scroll", item.Count)} titled \"{flavour}\"{ofName}";
        //    return includeCountPrefix ? GetPrefixCount(true, name, item.Count) : name;
        //}
        //public override int BaseValue => 20;
        //public override bool HatesFire => true;
        //public override bool HatesAcid => true;

        //public override Colour Colour => Colour.BrightBeige;
        //public override int PercentageBreakageChance => 50;
    }
}
