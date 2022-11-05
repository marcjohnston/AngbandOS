using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class RodItemCategory : BaseItemCategory
    {
        public override bool EasyKnow => true;
        public override bool ObjectHasFlavor => true;
        public override ItemCategory CategoryEnum => ItemCategory.Rod;
        public override bool CanAbsorb(Item item, Item other)
        {
            if (item.TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{item.SaveGame.RodFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Rod", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 90;
        public override Colour Colour => Colour.Turquoise;
        public override string GetVerboseDescription(Item item)
        {
            string s = "";
            if (item.IsKnown() && item.TypeSpecificValue != 0)
            {
                s += $" (charging)";
            }
            s += base.GetVerboseDescription(item);
            return s;
        }
    }

}
