using AngbandOS.Core.Interface;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class RingItemCategory : JewelleryItemClass
    {
        public override bool HasFlavor => true;
        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Ring;
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.IsFixedArtifact() && item.IsFlavourAware())
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentStoreb ? "" : $"{item.SaveGame.RingFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.BaseItemCategory.FriendlyName}" : "";
            string name = $"{flavour}{Pluralize("Ring", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        public override int BaseValue => 45;
        public override bool HatesElectricity => true;
        public override Colour Colour => Colour.Gold;

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                power = -1;
            }
            IArtifactBias artifactBias = null;
            switch (item.ItemSubCategory)
            {
                case RingType.Attacks:
                    {
                        item.TypeSpecificValue = GetBonusValue(3, level);
                        if (item.TypeSpecificValue < 1)
                        {
                            item.TypeSpecificValue = 1;
                        }
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
                        }
                        break;
                    }
                case RingType.Str:
                case RingType.Con:
                case RingType.Dex:
                case RingType.Int:
                    {
                        item.TypeSpecificValue = 1 + GetBonusValue(5, level);
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
                        }
                        break;
                    }
                case RingType.Speed:
                    {
                        item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                        while (Program.Rng.RandomLessThan(100) < 50)
                        {
                            item.TypeSpecificValue++;
                        }
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
                            break;
                        }
                        if (item.SaveGame.Level != null)
                        {
                            item.SaveGame.Level.TreasureRating += 25;
                        }
                        break;
                    }
                case RingType.Lordly:
                    {
                        do
                        {
                            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(20) + 18);
                        } while (Program.Rng.DieRoll(4) == 1);
                        item.BonusArmourClass = 10 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                        if (item.SaveGame.Level != null)
                        {
                            item.SaveGame.Level.TreasureRating += 5;
                        }
                    }
                    break;

                case RingType.Searching:
                    {
                        item.TypeSpecificValue = 1 + GetBonusValue(5, level);
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.TypeSpecificValue = 0 - item.TypeSpecificValue;
                        }
                        break;
                    }
                case RingType.Flames:
                case RingType.Acid:
                case RingType.Ice:
                    {
                        item.BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                        break;
                    }
                case RingType.Weakness:
                case RingType.Stupidity:
                    {
                        item.IdentBroken = true;
                        item.IdentCursed = true;
                        item.TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                        break;
                    }
                case RingType.Woe:
                    {
                        item.IdentBroken = true;
                        item.IdentCursed = true;
                        item.BonusArmourClass = 0 - (5 + GetBonusValue(10, level));
                        item.TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                        break;
                    }
                case RingType.Damage:
                    {
                        item.BonusDamage = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.BonusDamage = 0 - item.BonusDamage;
                        }
                        break;
                    }
                case RingType.Accuracy:
                    {
                        item.BonusToHit = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.BonusToHit = 0 - item.BonusToHit;
                        }
                        break;
                    }
                case RingType.Protection:
                    {
                        item.BonusArmourClass = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.BonusArmourClass = 0 - item.BonusArmourClass;
                        }
                        break;
                    }
                case RingType.Slaying:
                    {
                        item.BonusDamage = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                        item.BonusToHit = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                        if (power < 0)
                        {
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            item.BonusToHit = 0 - item.BonusToHit;
                            item.BonusDamage = 0 - item.BonusDamage;
                        }
                        break;
                    }
            }
        }

        public override string DescribeActivationEffect(Item item)
        {
            switch (item.ItemSubCategory)
            {
                case RingType.Flames:
                    return "ball of fire and resist fire";

                case RingType.Ice:
                    return "ball of cold and resist cold";

                case RingType.Acid:
                    return "ball of acid and resist acid";

                default:
                    return null;
            }
        }
    }
}
