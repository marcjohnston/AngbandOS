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
                if (!SaveGame.Instance.GetItem(out itemIndex, "Aim which wand? ", true, true, true))
                {
                    if (itemIndex == -2)
                    {
                        Profile.Instance.MsgPrint("You have no wand to aim.");
                    }
                    return;
                }
            }
            // Get the item and check if it is really a wand
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            Inventory.ItemFilterCategory = ItemCategory.Wand;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                Profile.Instance.MsgPrint("That is not a wand!");
                Inventory.ItemFilterCategory = 0;
                return;
            }
            Inventory.ItemFilterCategory = 0;
            // We can't use wands directly from the floor, since we need to aim them
            if (itemIndex < 0 && item.Count > 1)
            {
                Profile.Instance.MsgPrint("You must first pick up the wands.");
                return;
            }
            // Aim the wand
            TargetEngine targetEngine = new TargetEngine(saveGame.Player, saveGame.Level);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Using a wand takes 100 energy
            SaveGame.Instance.EnergyUse = 100;
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
                Profile.Instance.MsgPrint("You failed to use the wand properly.");
                return;
            }
            // Make sure we have charges
            if (item.TypeSpecificValue <= 0)
            {
                Profile.Instance.MsgPrint("The wand has no charges left.");
                item.IdentifyFlags.Set(Constants.IdentEmpty);
                return;
            }
            Gui.PlaySound(SoundEffect.ZapRod);
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
                        if (SaveGame.Instance.HealMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.HasteMonster:
                    {
                        if (SaveGame.Instance.SpeedMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.CloneMonster:
                    {
                        if (SaveGame.Instance.CloneMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.TeleportAway:
                    {
                        if (SaveGame.Instance.TeleportMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Disarming:
                    {
                        if (SaveGame.Instance.DisarmTrap(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.TrapDoorDest:
                    {
                        if (SaveGame.Instance.DestroyDoor(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.StoneToMud:
                    {
                        if (SaveGame.Instance.WallToMud(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Light:
                    {
                        Profile.Instance.MsgPrint("A line of blue shimmering light appears.");
                        SaveGame.Instance.LightLine(dir);
                        ident = true;
                        break;
                    }
                case WandType.SleepMonster:
                    {
                        if (SaveGame.Instance.SleepMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.SlowMonster:
                    {
                        if (SaveGame.Instance.SlowMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.ConfuseMonster:
                    {
                        if (SaveGame.Instance.ConfuseMonster(dir, 10))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.FearMonster:
                    {
                        if (SaveGame.Instance.FearMonster(dir, 10))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.DrainLife:
                    {
                        if (SaveGame.Instance.DrainLife(dir, 75))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Polymorph:
                    {
                        if (SaveGame.Instance.PolyMonster(dir))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.StinkingCloud:
                    {
                        SaveGame.Instance.FireBall(new ProjectPois(), dir, 12, 2);
                        ident = true;
                        break;
                    }
                case WandType.MagicMissile:
                    {
                        SaveGame.Instance.FireBoltOrBeam(20, new ProjectMissile(), dir,
                            Program.Rng.DiceRoll(2, 6));
                        ident = true;
                        break;
                    }
                case WandType.AcidBolt:
                    {
                        SaveGame.Instance.FireBoltOrBeam(20, new ProjectAcid(), dir,
                            Program.Rng.DiceRoll(3, 8));
                        ident = true;
                        break;
                    }
                case WandType.CharmMonster:
                    {
                        if (SaveGame.Instance.CharmMonster(dir, 45))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.FireBolt:
                    {
                        SaveGame.Instance.FireBoltOrBeam(20, new ProjectFire(), dir,
                            Program.Rng.DiceRoll(6, 8));
                        ident = true;
                        break;
                    }
                case WandType.ColdBolt:
                    {
                        SaveGame.Instance.FireBoltOrBeam(20, new ProjectCold(), dir,
                            Program.Rng.DiceRoll(3, 8));
                        ident = true;
                        break;
                    }
                case WandType.AcidBall:
                    {
                        SaveGame.Instance.FireBall(new ProjectAcid(), dir, 60, 2);
                        ident = true;
                        break;
                    }
                case WandType.ElecBall:
                    {
                        SaveGame.Instance.FireBall(new ProjectElec(), dir, 32, 2);
                        ident = true;
                        break;
                    }
                case WandType.FireBall:
                    {
                        SaveGame.Instance.FireBall(new ProjectFire(), dir, 72, 2);
                        ident = true;
                        break;
                    }
                case WandType.ColdBall:
                    {
                        SaveGame.Instance.FireBall(new ProjectCold(), dir, 48, 2);
                        ident = true;
                        break;
                    }
                case WandType.Wonder:
                    {
                        Profile.Instance.MsgPrint("Oops. Wand of wonder activated.");
                        break;
                    }
                case WandType.DragonFire:
                    {
                        SaveGame.Instance.FireBall(new ProjectFire(), dir, 100, 3);
                        ident = true;
                        break;
                    }
                case WandType.DragonCold:
                    {
                        SaveGame.Instance.FireBall(new ProjectCold(), dir, 80, 3);
                        ident = true;
                        break;
                    }
                case WandType.DragonBreath:
                    {
                        switch (Program.Rng.DieRoll(5))
                        {
                            case 1:
                                {
                                    SaveGame.Instance.FireBall(new ProjectAcid(), dir, 100, -3);
                                    break;
                                }
                            case 2:
                                {
                                    SaveGame.Instance.FireBall(new ProjectElec(), dir, 80, -3);
                                    break;
                                }
                            case 3:
                                {
                                    SaveGame.Instance.FireBall(new ProjectFire(), dir, 100, -3);
                                    break;
                                }
                            case 4:
                                {
                                    SaveGame.Instance.FireBall(new ProjectCold(), dir, 80, -3);
                                    break;
                                }
                            default:
                                {
                                    SaveGame.Instance.FireBall(new ProjectPois(), dir, 60, -3);
                                    break;
                                }
                        }
                        ident = true;
                        break;
                    }
                case WandType.Annihilation:
                    {
                        if (SaveGame.Instance.DrainLife(dir, 125))
                        {
                            ident = true;
                        }
                        break;
                    }
                case WandType.Shard:
                    {
                        SaveGame.Instance.FireBall(new ProjectShard(), dir, 75 + Program.Rng.DieRoll(50),
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
                channeled = SaveGame.Instance.DoCmdChannel(item);
            }
            // We didn't use mana, so decrease the wand's charges
            if (!channeled)
            {
                item.TypeSpecificValue--;
                // If the wand is part of a stack, split it off from the others
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item splitItem = new Item(item) { Count = 1 };
                    item.TypeSpecificValue++;
                    item.Count--;
                    saveGame.Player.WeightCarried -= splitItem.Weight;
                    itemIndex = saveGame.Player.Inventory.InvenCarry(splitItem, false);
                    Profile.Instance.MsgPrint("You unstack your wand.");
                }
                // Let us know we have used a charge
                if (itemIndex >= 0)
                {
                    saveGame.Player.Inventory.ReportChargeUsageFromInventory(itemIndex);
                }
                else
                {
                    SaveGame.Instance.Level.ReportChargeUsageFromFloor(0 - itemIndex);
                }
            }
        }
    }
}
