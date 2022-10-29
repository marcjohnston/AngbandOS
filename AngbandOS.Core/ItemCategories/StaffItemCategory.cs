using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class StaffItemCategory : BaseItemCategory
    {
        public override bool ObjectHasFlavor => true;
        public override ItemCategory CategoryEnum => ItemCategory.Staff;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{item.SaveGame.StaffFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Staff", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }

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

        public override int BaseValue => 70;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        //public override bool IsCharged => true;
        public override Colour Colour => Colour.Purple;
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

        public override void ApplyMagic(Item item, int level, int power)
        {
            switch (item.ItemSubCategory)
            {
                case StaffType.Darkness:
                    item.TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Slowness:
                    item.TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.HasteMonsters:
                    item.TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Summoning:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Teleportation:
                    item.TypeSpecificValue = Program.Rng.DieRoll(4) + 5;
                    break;

                case StaffType.Identify:
                    item.TypeSpecificValue = Program.Rng.DieRoll(15) + 5;
                    break;

                case StaffType.RemoveCurse:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Starlight:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Light:
                    item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.Mapping:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 5;
                    break;

                case StaffType.DetectGold:
                    item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.DetectItem:
                    item.TypeSpecificValue = Program.Rng.DieRoll(15) + 6;
                    break;

                case StaffType.DetectTrap:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.DetectDoor:
                    item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case StaffType.DetectInvis:
                    item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.DetectEvil:
                    item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.CureLight:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Curing:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Healing:
                    item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.TheMagi:
                    item.TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.SleepMonsters:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.SlowMonsters:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Speed:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Probing:
                    item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case StaffType.DispelEvil:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Power:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Holiness:
                    item.TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.Carnage:
                    item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.Earthquakes:
                    item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case StaffType.Destruction:
                    item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;
            }
        }
    }
}
