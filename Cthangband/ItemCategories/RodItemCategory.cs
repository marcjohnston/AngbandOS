using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class RodItemCategory : BaseItemCategory
    {
        public RodItemCategory() : base(ItemCategory.Rod)
        {
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.RodFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Rod", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        //public override int BaseValue => 90;
        //public override Colour Colour => Colour.Turquoise;
        //public override string GetVerboseDescription(Item item)
        //{
        //    string s = "";
        //    if (item.IsKnown() && item.TypeSpecificValue != 0)
        //    {
        //        s += $" (charging)";
        //    }
        //    s += base.GetVerboseDescription(item);
        //    return s;
        //}
    }

}
