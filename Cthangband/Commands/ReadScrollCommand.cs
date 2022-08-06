using Cthangband.Enumerations;
using Cthangband.Projection;
using Cthangband.StaticData;
using System;

namespace Cthangband.Commands
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
                Profile.Instance.MsgPrint("You can't see anything.");
                return;
            }
            if (saveGame.Level.NoLight())
            {
                Profile.Instance.MsgPrint("You have no light to read by.");
                return;
            }
            if (saveGame.Player.TimedConfusion != 0)
            {
                Profile.Instance.MsgPrint("You are too confused!");
                return;
            }
            // If we weren't passed in an item, prompt for one
            Inventory.ItemFilterCategory = ItemCategory.Scroll;
            if (itemIndex == -999)
            {
                if (!SaveGame.Instance.GetItem(out itemIndex, "Read which scroll? ", true, true, true))
                {
                    if (itemIndex == -2)
                    {
                        Profile.Instance.MsgPrint("You have no scrolls to read.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Make sure the item is actually a scroll
            Inventory.ItemFilterCategory = ItemCategory.Scroll;
            if (!saveGame.Player.Inventory.ItemMatchesFilter(item))
            {
                Profile.Instance.MsgPrint("That is not a scroll!");
                Inventory.ItemFilterCategory = 0;
                return;
            }
            Inventory.ItemFilterCategory = 0;
            // Scrolls use a full turn
            SaveGame.Instance.EnergyUse = 100;
            bool identified = false;
            int itemLevel = item.ItemType.Level;
            bool usedUp = true;
            // Most types of scroll are obvious
            switch (item.ItemSubCategory)
            {
                case ScrollType.Darkness:
                    {
                        if (!saveGame.Player.HasBlindnessResistance && !saveGame.Player.HasDarkResistance)
                        {
                            saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + 3 + Program.Rng.DieRoll(5));
                        }
                        if (SaveGame.Instance.UnlightArea(10, 3))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.AggravateMonster:
                    {
                        Profile.Instance.MsgPrint("There is a high pitched humming noise.");
                        SaveGame.Instance.AggravateMonsters(1);
                        identified = true;
                        break;
                    }
                case ScrollType.CurseArmour:
                    {
                        if (SaveGame.Instance.CurseArmour())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.CurseWeapon:
                    {
                        if (SaveGame.Instance.CurseWeapon())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.SummonMonster:
                    {
                        for (i = 0; i < Program.Rng.DieRoll(3); i++)
                        {
                            if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, SaveGame.Instance.Difficulty, 0))
                            {
                                identified = true;
                            }
                        }
                        break;
                    }
                case ScrollType.SummonUndead:
                    {
                        for (i = 0; i < Program.Rng.DieRoll(3); i++)
                        {
                            if (saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, SaveGame.Instance.Difficulty,
                                Constants.SummonUndead))
                            {
                                identified = true;
                            }
                        }
                        break;
                    }
                case ScrollType.TrapCreation:
                    {
                        if (SaveGame.Instance.TrapCreation())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.PhaseDoor:
                    {
                        SaveGame.Instance.TeleportPlayer(10);
                        identified = true;
                        break;
                    }
                case ScrollType.Teleport:
                    {
                        SaveGame.Instance.TeleportPlayer(100);
                        identified = true;
                        break;
                    }
                case ScrollType.TeleportLevel:
                    {
                        SaveGame.Instance.TeleportPlayerLevel();
                        identified = true;
                        break;
                    }
                case ScrollType.WordOfRecall:
                    {
                        saveGame.Player.ToggleRecall();
                        identified = true;
                        break;
                    }
                case ScrollType.Identify:
                    {
                        identified = true;
                        if (!SaveGame.Instance.IdentifyItem())
                        {
                            usedUp = false;
                        }
                        break;
                    }
                case ScrollType.StarIdentify:
                    {
                        identified = true;
                        if (!SaveGame.Instance.IdentifyFully())
                        {
                            usedUp = false;
                        }
                        break;
                    }
                case ScrollType.RemoveCurse:
                    {
                        if (SaveGame.Instance.RemoveCurse())
                        {
                            Profile.Instance.MsgPrint("You feel as if someone is watching over you.");
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.StarRemoveCurse:
                    {
                        SaveGame.Instance.RemoveAllCurse();
                        identified = true;
                        break;
                    }
                case ScrollType.EnchantArmor:
                    {
                        identified = true;
                        if (!SaveGame.Instance.EnchantSpell(0, 0, 1))
                        {
                            usedUp = false;
                        }
                        break;
                    }
                case ScrollType.EnchantWeaponToHit:
                    {
                        if (!SaveGame.Instance.EnchantSpell(1, 0, 0))
                        {
                            usedUp = false;
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.EnchantWeaponToDam:
                    {
                        if (!SaveGame.Instance.EnchantSpell(0, 1, 0))
                        {
                            usedUp = false;
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.StarEnchantArmor:
                    {
                        if (!SaveGame.Instance.EnchantSpell(0, 0, Program.Rng.DieRoll(3) + 2))
                        {
                            usedUp = false;
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.StarEnchantWeapon:
                    {
                        if (!SaveGame.Instance.EnchantSpell(Program.Rng.DieRoll(3), Program.Rng.DieRoll(3), 0))
                        {
                            usedUp = false;
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.Recharging:
                    {
                        if (!SaveGame.Instance.Recharge(60))
                        {
                            usedUp = false;
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.Light:
                    {
                        if (SaveGame.Instance.LightArea(Program.Rng.DiceRoll(2, 8), 2))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.Mapping:
                    {
                        saveGame.Level.MapArea();
                        identified = true;
                        break;
                    }
                case ScrollType.DetectGold:
                    {
                        if (SaveGame.Instance.DetectTreasure())
                        {
                            identified = true;
                        }
                        if (SaveGame.Instance.DetectObjectsGold())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.DetectItem:
                    {
                        if (SaveGame.Instance.DetectObjectsNormal())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.DetectTrap:
                    {
                        if (SaveGame.Instance.DetectTraps())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.DetectDoor:
                    {
                        if (SaveGame.Instance.DetectDoors())
                        {
                            identified = true;
                        }
                        if (SaveGame.Instance.DetectStairs())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.DetectInvis:
                    {
                        if (SaveGame.Instance.DetectMonstersInvis())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.SatisfyHunger:
                    {
                        if (saveGame.Player.SetFood(Constants.PyFoodMax - 1))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.Blessing:
                    {
                        if (saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(12) + 6))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.HolyChant:
                    {
                        if (saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(24) + 12))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.HolyPrayer:
                    {
                        if (saveGame.Player.SetTimedBlessing(saveGame.Player.TimedBlessing + Program.Rng.DieRoll(48) + 24))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.MonsterConfusion:
                    {
                        if (!saveGame.Player.HasConfusingTouch)
                        {
                            Profile.Instance.MsgPrint("Your hands begin to glow.");
                            saveGame.Player.HasConfusingTouch = true;
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.ProtectionFromEvil:
                    {
                        i = 3 * saveGame.Player.Level;
                        if (saveGame.Player.SetTimedProtectionFromEvil(saveGame.Player.TimedProtectionFromEvil + Program.Rng.DieRoll(25) + i))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.RuneOfProtection:
                    {
                        SaveGame.Instance.ElderSign();
                        identified = true;
                        break;
                    }
                case ScrollType.TrapDoorDestruction:
                    {
                        if (SaveGame.Instance.DestroyDoorsTouch())
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.StarDestruction:
                    {
                        SaveGame.Instance.DestroyArea(saveGame.Player.MapY, saveGame.Player.MapX, 15);
                        identified = true;
                        break;
                    }
                case ScrollType.DispelUndead:
                    {
                        if (SaveGame.Instance.DispelUndead(60))
                        {
                            identified = true;
                        }
                        break;
                    }
                case ScrollType.Carnage:
                    {
                        SaveGame.Instance.Carnage(true);
                        identified = true;
                        break;
                    }
                case ScrollType.MassCarnage:
                    {
                        SaveGame.Instance.MassCarnage(true);
                        identified = true;
                        break;
                    }
                case ScrollType.Acquirement:
                    {
                        SaveGame.Instance.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, 1, true);
                        identified = true;
                        break;
                    }
                case ScrollType.StarAcquirement:
                    {
                        SaveGame.Instance.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Program.Rng.DieRoll(2) + 1, true);
                        identified = true;
                        break;
                    }
                case ScrollType.Fire:
                    {
                        SaveGame.Instance.FireBall(new ProjectFire(), 0, 150, 4);
                        if (!(saveGame.Player.TimedFireResistance != 0 || saveGame.Player.HasFireResistance || saveGame.Player.HasFireImmunity))
                        {
                            saveGame.Player.TakeHit(50 + Program.Rng.DieRoll(50), "a Scroll of Fire");
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.Ice:
                    {
                        SaveGame.Instance.FireBall(new ProjectIce(), 0, 175, 4);
                        if (!(saveGame.Player.TimedColdResistance != 0 || saveGame.Player.HasColdResistance || saveGame.Player.HasColdImmunity))
                        {
                            saveGame.Player.TakeHit(100 + Program.Rng.DieRoll(100), "a Scroll of Ice");
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.Chaos:
                    {
                        SaveGame.Instance.FireBall(new ProjectChaos(), 0, 222, 4);
                        if (!saveGame.Player.HasChaosResistance)
                        {
                            saveGame.Player.TakeHit(111 + Program.Rng.DieRoll(111), "a Scroll of Chaos");
                        }
                        identified = true;
                        break;
                    }
                case ScrollType.Rumor:
                    {
                        Profile.Instance.MsgPrint("There is message on the scroll. It says:");
                        Profile.Instance.MsgPrint(null);
                        SaveGame.Instance.GetRumour();
                        identified = true;
                        break;
                    }
                case ScrollType.Invocation:
                    {
                        var patron = SaveGame.Instance.PatronList[Program.Rng.DieRoll(SaveGame.Instance.PatronList.Length) - 1];
                        Profile.Instance.MsgPrint($"You invoke the secret name of {patron.LongName}.");
                        patron.GetReward(saveGame.Player, SaveGame.Instance.Level, SaveGame.Instance);
                        identified = true;
                        break;
                    }
                case ScrollType.Artifact:
                    {
                        SaveGame.Instance.ArtifactScroll();
                        identified = true;
                        break;
                    }
            }
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            // We might have just identified the scroll
            item.ObjectTried();
            if (identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                saveGame.Player.GainExperience((itemLevel + (saveGame.Player.Level >> 1)) / saveGame.Player.Level);
            }
            bool channeled = false;
            // Channelers can use mana instead of the scroll being used up
            if (saveGame.Player.Spellcasting.Type == CastingType.Channeling)
            {
                channeled = SaveGame.Instance.DoCmdChannel(item);
            }
            if (!channeled)
            {
                if (!usedUp)
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
                    SaveGame.Instance.Level.FloorItemIncrease(0 - itemIndex, -1);
                    SaveGame.Instance.Level.FloorItemDescribe(0 - itemIndex);
                    SaveGame.Instance.Level.FloorItemOptimize(0 - itemIndex);
                }
            }
        }

    }
}
