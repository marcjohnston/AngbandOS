using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class AmuletItemCategory : JewelleryItemCategory
    {
        public AmuletItemCategory() : base(ItemCategory.Amulet)
        {
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            if (item.IsFixedArtifact() && item.IsFlavourAware())
            {
                return base.GetDescription(item, includeCountPrefix);
            }
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.AmuletFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Amulet", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        //public override int BaseValue => 45;
        //public override Colour Colour => Colour.Orange;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
        //    {
        //        power = -1;
        //    }

        //    IArtifactBias artifactBias = null;
        //    switch (item.ItemSubCategory)
        //    {
        //        case AmuletType.Wisdom:
        //        case AmuletType.Charisma:
        //            {
        //                item.TypeSpecificValue = 1 + GetBonusValue(5, level);
        //                if (power < 0)
        //                {
        //                    item.IdentifyFlags.Set(Constants.IdentBroken);
        //                    item.IdentifyFlags.Set(Constants.IdentCursed);
        //                    item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        //                }
        //                break;
        //            }
        //        case AmuletType.NoMagic:
        //        case AmuletType.NoTele:
        //            {
        //                if (power < 0)
        //                {
        //                    item.IdentifyFlags.Set(Constants.IdentCursed);
        //                }
        //                break;
        //            }
        //        case AmuletType.Resistance:
        //            {
        //                if (Program.Rng.DieRoll(3) == 1)
        //                {
        //                    ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
        //                }
        //                if (Program.Rng.DieRoll(5) == 1)
        //                {
        //                    item.RandartFlags2.Set(ItemFlag2.ResPois);
        //                }
        //            }
        //            break;

        //        case AmuletType.Searching:
        //            {
        //                item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        //                if (power < 0)
        //                {
        //                    item.IdentifyFlags.Set(Constants.IdentBroken);
        //                    item.IdentifyFlags.Set(Constants.IdentCursed);
        //                    item.TypeSpecificValue = 0 - item.TypeSpecificValue;
        //                }
        //                break;
        //            }
        //        case AmuletType.TheMagi:
        //            {
        //                item.TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        //                item.BonusArmourClass = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        //                if (Program.Rng.DieRoll(3) == 1)
        //                {
        //                    item.RandartFlags3.Set(ItemFlag3.SlowDigest);
        //                }
        //                if (SaveGame.Instance.Level != null)
        //                {
        //                    SaveGame.Instance.Level.TreasureRating += 25;
        //                }
        //                break;
        //            }
        //        case AmuletType.Doom:
        //            {
        //                item.IdentifyFlags.Set(Constants.IdentBroken);
        //                item.IdentifyFlags.Set(Constants.IdentCursed);
        //                item.TypeSpecificValue = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
        //                item.BonusArmourClass = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
        //                break;
        //            }
        //    }
        //}
    }
}
