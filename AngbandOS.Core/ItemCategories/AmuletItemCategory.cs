using AngbandOS.Core.Interface;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;
using AngbandOS.Core;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class AmuletItemCategory : JewelleryItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Amulet;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.IsFixedArtifact() && item.IsFlavourAware())
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{item.SaveGame.AmuletFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Amulet", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 45;
        public override Colour Colour => Colour.Orange;
        public override int? SubCategory => null; // All amulet subcategories have been refactored.
        public override bool ObjectHasFlavor => true;
    }
}
