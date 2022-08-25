using Cthangband.Enumerations;
using Cthangband.Projection;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Aim a wand from your inventory
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the wand, or -999 to select one </param>
    [Serializable]
    internal class AimWandCommand : ICommand
    {
        public char Key => 'a';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;
            if (itemIndex == -999)
            {
                // Prompt for an item, showing only wands
                Inventory.ItemFilterCategory = ItemCategory.Wand;
                if (!saveGame.GetItem(out itemIndex, "Aim which wand? ", true, true, true))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no wand to aim.");
                    }
                    return;
                }
            }
            // Get the item and check if it is really a wand
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            Inventory.ItemFilterCategory = ItemCategory.Wand;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                saveGame.MsgPrint("That is not a wand!");
                Inventory.ItemFilterCategory = 0;
                return;
            }
            Inventory.ItemFilterCategory = 0;
            // We can't use wands directly from the floor, since we need to aim them
            if (itemIndex < 0 && item.Count > 1)
            {
                saveGame.MsgPrint("You must first pick up the wands.");
                return;
            }
            // Aim the wand
            TargetEngine targetEngine = new TargetEngine(saveGame);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Using a wand takes 100 energy
            saveGame.EnergyUse = 100;
            bool ident = false;
            int itemLevel = item.ItemType.Level;
            // Chance of success is your skill - item level, with item level capped at 50 and your
            // skill halved if you're confused
            int chance = saveGame.Player.SkillUseDevice;
            if (saveGame.Player.TimedConfusion != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always a small chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                saveGame.MsgPrint("You failed to use the wand properly.");
                return;
            }
            // Make sure we have charges
            if (item.TypeSpecificValue <= 0)
            {
                saveGame.MsgPrint("The wand has no charges left.");
                item.IdentifyFlags.Set(Constants.IdentEmpty);
                return;
            }
            saveGame.PlaySound(SoundEffect.ZapRod);
            int subCategory = item.ItemSubCategory;
            // Wand of wonder just chooses another type of wand less than its own index
            if (subCategory == WandType.Wonder)
            {
                subCategory = Program.Rng.RandomLessThan(WandType.Wonder);
            }
            switch (subCategory)
            {
                case WandType.HealMonster:
                    {
                        if (saveGame.HealMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.HasteMonster:
                    {
                        if (saveGame.SpeedMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.CloneMonster:
                    {
                        if (saveGame.CloneMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.TeleportAway:
                    {
                        if (saveGame.TeleportMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Disarming:
                    {
                        if (saveGame.DisarmTrap(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.TrapDoorDest:
                    {
                        if (saveGame.DestroyDoor(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.StoneToMud:
                    {
                        if (saveGame.WallToMud(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Light:
                    {
                        saveGame.MsgPrint("A line of blue shimmering light appears.");
                        saveGame.LightLine(dir);
                        ident = true;
                        break;
                    }
                case WandType.SleepMonster:
                    {
                        if (saveGame.SleepMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.SlowMonster:
                    {
                        if (saveGame.SlowMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.ConfuseMonster:
                    {
                        if (saveGame.ConfuseMonster(dir, 10))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.FearMonster:
                    {
                        if (saveGame.FearMonster(dir, 10))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.DrainLife:
                    {
                        if (saveGame.DrainLife(dir, 75))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Polymorph:
                    {
                        if (saveGame.PolyMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.StinkingCloud:
                    {
                        saveGame.FireBall(new ProjectPois(saveGame), dir, 12, 2);
                        ident = true;
                        break;
                    }
                case WandType.MagicMissile:
                    {
                        saveGame.FireBoltOrBeam(20, new ProjectMissile(saveGame), dir,
                            Program.Rng.DiceRoll(2, 6));
                        ident = true;
                        break;
                    }
                case WandType.AcidBolt:
                    {
                        saveGame.FireBoltOrBeam(20, new ProjectAcid(saveGame), dir,
                            Program.Rng.DiceRoll(3, 8));
                        ident = true;
                        break;
                    }
                case WandType.CharmMonster:
                    {
                        if (saveGame.CharmMonster(dir, 45))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.FireBolt:
                    {
                        saveGame.FireBoltOrBeam(20, new ProjectFire(saveGame), dir,
                            Program.Rng.DiceRoll(6, 8));
                        ident = true;
                        break;
                    }
                case WandType.ColdBolt:
                    {
                        saveGame.FireBoltOrBeam(20, new ProjectCold(saveGame), dir,
                            Program.Rng.DiceRoll(3, 8));
                        ident = true;
                        break;
                    }
                case WandType.AcidBall:
                    {
                        saveGame.FireBall(new ProjectAcid(saveGame), dir, 60, 2);
                        ident = true;
                        break;
                    }
                case WandType.ElecBall:
                    {
                        saveGame.FireBall(new ProjectElec(saveGame), dir, 32, 2);
                        ident = true;
                        break;
                    }
                case WandType.FireBall:
                    {
                        saveGame.FireBall(new ProjectFire(saveGame), dir, 72, 2);
                        ident = true;
                        break;
                    }
                case WandType.ColdBall:
                    {
                        saveGame.FireBall(new ProjectCold(saveGame), dir, 48, 2);
                        ident = true;
                        break;
                    }
                case WandType.Wonder:
                    {
                        saveGame.MsgPrint("Oops. Wand of wonder activated.");
                        break;
                    }
                case WandType.DragonFire:
                    {
                        saveGame.FireBall(new ProjectFire(saveGame), dir, 100, 3);
                        ident = true;
                        break;
                    }
                case WandType.DragonCold:
                    {
                        saveGame.FireBall(new ProjectCold(saveGame), dir, 80, 3);
                        ident = true;
                        break;
                    }
                case WandType.DragonBreath:
                    {
                        switch (Program.Rng.DieRoll(5))
                        {
                            case 1:
                                {
                                    saveGame.FireBall(new ProjectAcid(saveGame), dir, 100, -3);
                                    break;
                                }
                            case 2:
                                {
                                    saveGame.FireBall(new ProjectElec(saveGame), dir, 80, -3);
                                    break;
                                }
                            case 3:
                                {
                                    saveGame.FireBall(new ProjectFire(saveGame), dir, 100, -3);
                                    break;
                                }
                            case 4:
                                {
                                    saveGame.FireBall(new ProjectCold(saveGame), dir, 80, -3);
                                    break;
                                }
                            default:
                                {
                                    saveGame.FireBall(new ProjectPois(saveGame), dir, 60, -3);
                                    break;
                                }
                        }
                        ident = true;
                        break;
                    }
                case WandType.Annihilation:
                    {
                        if (saveGame.DrainLife(dir, 125))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Shard:
                    {
                        saveGame.FireBall(new ProjectShard(saveGame), dir, 75 + Program.Rng.DieRoll(50),
                            2);
                        ident = true;
                        break;
                    }
            }
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // Mark the wand as having been tried
            item.ObjectTried();
            // If we just discovered the item's flavour, mark it as so
            if (ident && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            // If we're a channeler then we should be using mana instead of charges
            bool channeled = false;
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
            }
            // We didn't use mana, so decrease the wand's charges
            if (!channeled)
            {
                item.TypeSpecificValue--;
                // If the wand is part of a stack, split it off from the others
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item splitItem = new Item(saveGame, item) { Count = 1 };
                    item.TypeSpecificValue++;
                    item.Count--;
                    saveGame.Player.WeightCarried -= splitItem.Weight;
                    itemIndex = saveGame.Player.Inventory.InvenCarry(splitItem, false);
                    saveGame.MsgPrint("You unstack your wand.");
                }
                // Let us know we have used a charge
                if (itemIndex >= 0)
                {
                    saveGame.Player.Inventory.ReportChargeUsageFromInventory(itemIndex);
                }
                else
                {
                    saveGame.Level.ReportChargeUsageFromFloor(0 - itemIndex);
                }
            }
        }
    }
}
