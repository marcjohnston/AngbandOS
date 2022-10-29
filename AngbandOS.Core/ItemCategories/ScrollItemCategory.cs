using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class ScrollItemCategory : BaseItemCategory
    {
        public override bool ObjectHasFlavor => true;
        public override ItemCategory CategoryEnum => ItemCategory.Scroll;
        public override bool CanAbsorb(Item item, Item other)
        {
            return true;
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $" titled \"{item.SaveGame.ScrollFlavours[item.ItemSubCategory].Name}\"";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{Pluralize("Scroll", item.Count)}{flavour}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 20;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightBeige;
        public override int PercentageBreakageChance => 50;
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
