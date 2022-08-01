using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class WandItemCategory : BaseItemCategory
    {
        public WandItemCategory() : base(ItemCategory.Wand)
        {
        }
        public override string GetDescription(Item item, bool includeCountPrefix)
        {
            string flavour = item.IdentifyFlags.IsSet(Constants.IdentStoreb) ? "" : $"{SaveGame.Instance.WandFlavours[item.ItemSubCategory].Name} ";
            string ofName = item.IsFlavourAware() ? $" of {item.ItemType.Name}" : "";
            string name = $"{flavour}{Pluralize("Wand", item.Count)}{ofName}";
            return includeCountPrefix ? GetPrefixCount(true, name, item.Count, item.IsKnownArtifact) : name;
        }
        //public override int BaseValue => 50;
        //public override bool HatesElectricity => true;
        //public override bool IsCharged => true;
        //public override Colour Colour => Colour.Chartreuse;
        //public override int PercentageBreakageChance => 25;
        //public override int GetBonusValue(Item item, int value) => value / 20 * item.TypeSpecificValue;
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

        //private void ChargeWand(Item item)
        //{
        //    switch (item.ItemSubCategory)
        //    {
        //        case WandType.HealMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        //            break;

        //        case WandType.HasteMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
        //            break;

        //        case WandType.CloneMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        //            break;

        //        case WandType.TeleportAway:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        //            break;

        //        case WandType.Disarming:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 4;
        //            break;

        //        case WandType.TrapDoorDest:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        //            break;

        //        case WandType.StoneToMud:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 3;
        //            break;

        //        case WandType.Light:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        //            break;

        //        case WandType.SleepMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        //            break;

        //        case WandType.SlowMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        //            break;

        //        case WandType.ConfuseMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(12) + 6;
        //            break;

        //        case WandType.FearMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
        //            break;

        //        case WandType.DrainLife:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(3) + 3;
        //            break;

        //        case WandType.Polymorph:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        //            break;

        //        case WandType.StinkingCloud:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        //            break;

        //        case WandType.MagicMissile:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
        //            break;

        //        case WandType.AcidBolt:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        //            break;

        //        case WandType.CharmMonster:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
        //            break;

        //        case WandType.FireBolt:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
        //            break;

        //        case WandType.ColdBolt:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
        //            break;

        //        case WandType.AcidBall:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(5) + 2;
        //            break;

        //        case WandType.ElecBall:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(8) + 4;
        //            break;

        //        case WandType.FireBall:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(4) + 2;
        //            break;

        //        case WandType.ColdBall:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
        //            break;

        //        case WandType.Wonder:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
        //            break;

        //        case WandType.Annihilation:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        //            break;

        //        case WandType.DragonFire:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        //            break;

        //        case WandType.DragonCold:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        //            break;

        //        case WandType.DragonBreath:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
        //            break;

        //        case WandType.Shard:
        //            item.TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
        //            break;
        //    }
        //}

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    ChargeWand(item);
        //}
    }
}
