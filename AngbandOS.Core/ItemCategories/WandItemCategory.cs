using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class WandItemCategory : BaseItemCategory
    {
        public override bool ObjectHasFlavor => true;
        public override ItemCategory CategoryEnum => ItemCategory.Wand;
        public abstract bool ExecuteActivation(SaveGame saveGame, int dir);
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{item.SaveGame.WandFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Wand", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 50;
        public override bool HatesElectricity => true;
        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (item.TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Chartreuse;
        public override int PercentageBreakageChance => 25;
        public override int GetBonusRealValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue += value / 20 * item.TypeSpecificValue;
            return bonusValue;
        }

        public override string GetVerboseDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                s += $" ({item.TypeSpecificValue} {Pluralize("charge", item.TypeSpecificValue)})";
            }
            s += base.GetVerboseDescription(item);
            return s;
        }
    }
}
