using AngbandOS.Core;
using AngbandOS.Core.ItemFilters;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.Projection;
using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Read a scroll from the inventory or floor
    /// </summary>
    /// <param name="itemIndex"> The inventory index of the scroll to be read </param>
    [Serializable]
    internal class ReadScrollCommand : ICommand
    {
        public char Key => 'r';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int itemIndex = -999;

            int i;
            // Make sure we're in a situation where we can read
            if (saveGame.Player.TimedBlindness != 0)
            {
                saveGame.MsgPrint("You can't see anything.");
                return;
            }
            if (saveGame.Level.NoLight())
            {
                saveGame.MsgPrint("You have no light to read by.");
                return;
            }
            if (saveGame.Player.TimedConfusion != 0)
            {
                saveGame.MsgPrint("You are too confused!");
                return;
            }
            // If we weren't passed in an item, prompt for one
            if (itemIndex == -999)
            {
                if (!saveGame.GetItem(out itemIndex, "Read which scroll? ", true, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Scroll)))
                {
                    if (itemIndex == -2)
                    {
                        saveGame.MsgPrint("You have no scrolls to read.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is actually a scroll
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Scroll)))
            {
                saveGame.MsgPrint("That is not a scroll!");
                return;
            }
            // Scrolls use a full turn
            saveGame.EnergyUse = 100;
            //bool identified = false;
            //bool usedUp = true;

            ScrollItemCategory scrollItem = (ScrollItemCategory)item.BaseItemCategory;
            ReadScrollEvent readScrollEventArgs = new ReadScrollEvent(saveGame);
            scrollItem.Read(readScrollEventArgs);

            // Most types of scroll are obvious
            //switch (item.ItemSubCategory)
            //{
                //case ScrollType.Darkness:
                //    {
                //        if (!saveGame.Player.HasBlindnessResistance && !saveGame.Player.HasDarkResistance)
                //        {
                //            saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + 3 + Program.Rng.DieRoll(5));
                //        }
                //        if (saveGame.UnlightArea(10, 3))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.AggravateMonster:
                //    {
                //        saveGame.MsgPrint("There is a high pitched humming noise.");
                //        saveGame.AggravateMonsters(1);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.CurseArmour:
                //    {
                //        if (saveGame.CurseArmour())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.CurseWeapon:
                //    {
                //        if (saveGame.CurseWeapon())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.SummonMonster:
                //    {
                //        for (i = 0; i < Program.Rng.DieRoll(3); i++)
                //        {
                //            if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, 0))
                //            {
                //                identified = true;
                //            }
                //        }
                //        break;
                    //}
                //case ScrollType.SummonUndead:
                //    {
                //        for (i = 0; i < Program.Rng.DieRoll(3); i++)
                //        {
                //            if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty,
                //                Constants.SummonUndead))
                //            {
                //                identified = true;
                //            }
                //        }
                //        break;
                //    }
                //case ScrollType.TrapCreation:
                //    {
                //        if (saveGame.TrapCreation())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.PhaseDoor:
                //    {
                //        saveGame.TeleportPlayer(10);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Teleport:
                //    {
                //        saveGame.TeleportPlayer(100);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.TeleportLevel:
                //    {
                //        saveGame.TeleportPlayerLevel();
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.WordOfRecall:
                //    {
                //        saveGame.Player.ToggleRecall();
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Identify:
                //    {
                //        identified = true;
                //        if (!saveGame.IdentifyItem())
                //        {
                //            usedUp = false;
                //        }
                //        break;
                //    }
                //case ScrollType.StarIdentify:
                //    {
                //        identified = true;
                //        if (!saveGame.IdentifyFully())
                //        {
                //            usedUp = false;
                //        }
                //        break;
                //    }
                //case ScrollType.RemoveCurse:
                //    {
                //        if (saveGame.RemoveCurse())
                //        {
                //            saveGame.MsgPrint("You feel as if someone is watching over you.");
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.StarRemoveCurse:
                //    {
                //        saveGame.RemoveAllCurse();
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.EnchantArmor:
                //    {
                //        identified = true;
                //        if (!saveGame.EnchantSpell(0, 0, 1))
                //        {
                //            usedUp = false;
                //        }
                //        break;
                //    }
                //case ScrollType.EnchantWeaponToHit:
                //    {
                //        if (!saveGame.EnchantSpell(1, 0, 0))
                //        {
                //            usedUp = false;
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.EnchantWeaponToDam:
                //    {
                //        if (!saveGame.EnchantSpell(0, 1, 0))
                //        {
                //            usedUp = false;
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.StarEnchantArmor:
                //    {
                //        if (!saveGame.EnchantSpell(0, 0, Program.Rng.DieRoll(3) + 2))
                //        {
                //            usedUp = false;
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.StarEnchantWeapon:
                //    {
                //        if (!saveGame.EnchantSpell(Program.Rng.DieRoll(3), Program.Rng.DieRoll(3), 0))
                //        {
                //            usedUp = false;
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Recharging:
                //    {
                //        if (!saveGame.Recharge(60))
                //        {
                //            usedUp = false;
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Light:
                //    {
                //        if (saveGame.LightArea(Program.Rng.DiceRoll(2, 8), 2))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.Mapping:
                //    {
                //        saveGame.Level.MapArea();
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.DetectGold:
                //    {
                //        if (saveGame.DetectTreasure())
                //        {
                //            identified = true;
                //        }
                //        if (saveGame.DetectObjectsGold())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.DetectItem:
                //    {
                //        if (saveGame.DetectObjectsNormal())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.DetectTrap:
                //    {
                //        if (saveGame.DetectTraps())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.DetectDoor:
                //    {
                //        if (saveGame.DetectDoors())
                //        {
                //            identified = true;
                //        }
                //        if (saveGame.DetectStairs())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.DetectInvis:
                //    {
                //        if (saveGame.DetectMonstersInvis())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.SatisfyHunger:
                //    {
                //        if (saveGame.Player.SetFood(Constants.PyFoodMax - 1))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.Blessing:
                //    {
                //        if (saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(12) + 6))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.HolyChant:
                //    {
                //        if (saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(24) + 12))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.HolyPrayer:
                //    {
                //        if (saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(48) + 24))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.MonsterConfusion:
                //    {
                //        if (!saveGame.Player.HasConfusingTouch)
                //        {
                //            saveGame.MsgPrint("Your hands begin to glow.");
                //            saveGame.Player.HasConfusingTouch = true;
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.ProtectionFromEvil:
                //    {
                //        i = 3 * saveGame.Player.Level;
                //        if (saveGame.Player.SetTimedProtectionFromEvil(saveGame.Player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + i))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.RuneOfProtection:
                //    {
                //        saveGame.ElderSign();
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.TrapDoorDestruction:
                //    {
                //        if (saveGame.DestroyDoorsTouch())
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.StarDestruction:
                //    {
                //        saveGame.DestroyArea(saveGame.Player.MapY, saveGame.Player.MapX, 15);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.DispelUndead:
                //    {
                //        if (saveGame.DispelUndead(60))
                //        {
                //            identified = true;
                //        }
                //        break;
                //    }
                //case ScrollType.Carnage:
                //    {
                //        saveGame.Carnage(true);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.MassCarnage:
                //    {
                //        saveGame.MassCarnage(true);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Acquirement:
                //    {
                //        saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, 1, true);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.StarAcquirement:
                //    {
                //        saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, true);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Fire:
                //    {
                //        saveGame.FireBall(new ProjectFire(saveGame), 0, 150, 4);
                //        if (!(saveGame.Player.TimedFireResistance != 0 || saveGame.Player.HasFireResistance || saveGame.Player.HasFireImmunity))
                //        {
                //            saveGame.Player.TakeHit(50 + Program.Rng.DieRoll(50), "a Scroll of Fire");
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Ice:
                //    {
                //        saveGame.FireBall(new ProjectIce(saveGame), 0, 175, 4);
                //        if (!(saveGame.Player.TimedColdResistance != 0 || saveGame.Player.HasColdResistance || saveGame.Player.HasColdImmunity))
                //        {
                //            saveGame.Player.TakeHit(100 + Program.Rng.DieRoll(100), "a Scroll of Ice");
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Chaos:
                //    {
                //        saveGame.FireBall(new ProjectChaos(saveGame), 0, 222, 4);
                //        if (!saveGame.Player.HasChaosResistance)
                //        {
                //            saveGame.Player.TakeHit(111 + Program.Rng.DieRoll(111), "a Scroll of Chaos");
                //        }
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Rumor:
                //    {
                //        saveGame.MsgPrint("There is message on the scroll. It says:");
                //        saveGame.MsgPrint(null);
                //        saveGame.GetRumour();
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Invocation:
                //    {
                //        var patron = saveGame.PatronList[Program.Rng.DieRoll(saveGame.PatronList.Length) - 1];
                //        saveGame.MsgPrint($"You invoke the secret name of {patron.LongName}.");
                //        patron.GetReward(saveGame);
                //        identified = true;
                //        break;
                //    }
                //case ScrollType.Artifact:
                //    {
                //        saveGame.ArtifactScroll();
                //        identified = true;
                //        break;
                //    }
            //}
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We might have just identified the scroll
            item.ObjectTried();
            if (readScrollEventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                int itemLevel = item.BaseItemCategory.Level;
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            bool channeled = false;
            // Channelers can use mana instead of the scroll being used up
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = saveGame.DoCmdChannel(item);
            }
            if (!channeled)
            {
                if (!readScrollEventArgs.UsedUp)
                {
                    return;
                }
                // If it wasn't used up then decrease the amount in the stack
                if (itemIndex >= 0)
                {
                    saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -1);
                    saveGame.Player.Inventory.InvenItemDescribe(itemIndex);
                    saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
                }
                else
                {
                    saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                    saveGame.Level.FloorItemDescribe(0 - itemIndex);
                    saveGame.Level.FloorItemOptimize(0 - itemIndex);
                }
            }
        }

    }
}
