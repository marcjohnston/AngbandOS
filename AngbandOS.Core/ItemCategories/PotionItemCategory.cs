using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class PotionItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Potion;
        public override bool CanAbsorb(Item item, Item other)
        {
            return true;
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{item.SaveGame.PotionFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Potion", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 20;
        public override bool HatesCold => true;
        public override Colour Colour => Colour.Blue;
        public override int PercentageBreakageChance => 100;

        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 60)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 240)
            {
                return MassRoll(1, 5);
            }
            return 0;
        }
    }
}
