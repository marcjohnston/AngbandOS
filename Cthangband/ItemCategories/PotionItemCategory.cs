using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class PotionItemCategory : BaseItemCategory
    {
        public PotionItemCategory() : base(ItemCategory.Potion)
        {
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.PotionFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Potion", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 20;
        //public override bool HatesCold => true;
        public override Colour Colour => Colour.Blue;
        //public override int PercentageBreakageChance => 100;
    }
}
