﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireItemScript : Script, IScript, IRepeatableScript
{
    private FireItemScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the fire script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the fire script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Check that we're actually wielding a ranged weapon
        RangedWeaponInventorySlot rangedWeaponInventorySlot = (RangedWeaponInventorySlot)SaveGame.SingletonRepository.InventorySlots.Get(nameof(RangedWeaponInventorySlot));
        WeightedRandom<int> weightedRandom = rangedWeaponInventorySlot.WeightedRandom;
        Item? missileWeapon = SaveGame.GetInventoryItem(weightedRandom.Choose());
        if (missileWeapon == null || missileWeapon.Category == 0)
        {
            SaveGame.MsgPrint("You have nothing to fire with.");
            return;
        }
        // Get the ammunition to fire
        if (!SaveGame.SelectItem(out Item? ammunitionStack, "Fire which item? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeFiredItemFilter))))
        {
            SaveGame.MsgPrint("You have nothing to fire.");
            return;
        }
        if (ammunitionStack == null)
        {
            return;
        }
        // Find out where we're aiming at
        if (!SaveGame.GetDirectionWithAim(out int dir))
        {
            return;
        }
        // Copy an ammunition piece from the stack...
        Item individualAmmunition = ammunitionStack.Clone(1);
        // ...and reduced the amount in the stack
        ammunitionStack.ItemIncrease(-1);
        if (ammunitionStack.IsInInventory)
        {
            ammunitionStack.ItemDescribe();
        }
        ammunitionStack.ItemOptimize();
        SaveGame.PlaySound(SoundEffectEnum.Shoot);
        // Get the details of the shot
        string missileName = individualAmmunition.Description(false, 3);
        ColorEnum missileColor = individualAmmunition.Factory.FlavorColor;
        char missileCharacter = individualAmmunition.Factory.FlavorSymbol.Character;
        int shotSpeed = SaveGame.MissileAttacksPerRound;
        int shotDamage = SaveGame.Rng.DiceRoll(individualAmmunition.DamageDice, individualAmmunition.DamageDiceSides) + individualAmmunition.BonusDamage + missileWeapon.BonusDamage;
        int attackBonus = SaveGame.AttackBonus + individualAmmunition.BonusToHit + missileWeapon.BonusToHit;
        int chanceToHit = SaveGame.SkillRanged + (attackBonus * Constants.BthPlusAdj);
        // Damage multiplier depends on weapon
        BowWeaponItemFactory missileWeaponItemCategory = (BowWeaponItemFactory)missileWeapon.Factory;
        int damageMultiplier = missileWeaponItemCategory.MissileDamageMultiplier;
        // Extra might gives us an increased multiplier
        if (SaveGame.HasExtraMight)
        {
            damageMultiplier++;
        }
        shotDamage *= damageMultiplier;
        // We're actually going to track the shot and draw it square by square
        int shotDistance = 10 + (5 * damageMultiplier);
        // Divide by our shot speed to give the equivalent of x shots per turn
        SaveGame.EnergyUse = 100 / shotSpeed;
        int y = SaveGame.MapY;
        int x = SaveGame.MapX;
        int targetX = SaveGame.MapX + (99 * SaveGame.KeypadDirectionXOffset[dir]);
        int targetY = SaveGame.MapY + (99 * SaveGame.KeypadDirectionYOffset[dir]);
        // Special case for if we're hitting our own square
        if (dir == 5 && SaveGame.TargetOkay())
        {
            targetX = SaveGame.TargetCol;
            targetY = SaveGame.TargetRow;
        }
        SaveGame.HandleStuff();
        bool hitBody = false;
        // Loop until we've reached our distance or hit something
        for (int curDis = 0; curDis <= shotDistance;)
        {
            if (y == targetY && x == targetX)
            {
                break;
            }
            // Move a step towards the target
            SaveGame.MoveOneStepTowards(out int newY, out int newX, y, x, SaveGame.MapY, SaveGame.MapX, targetY, targetX);
            // If we were blocked by a wall or something then stop short
            if (!SaveGame.GridPassable(newY, newX))
            {
                break;
            }
            curDis++;
            x = newX;
            y = newY;
            int msec = Constants.DelayFactorInMilliseconds;
            // If we can see the current projectile location, show it briefly
            if (SaveGame.PanelContains(y, x) && SaveGame.PlayerCanSeeBold(y, x))
            {
                SaveGame.PrintCharacterAtMapLocation(missileCharacter, missileColor, y, x);
                SaveGame.MoveCursorRelative(y, x);
                SaveGame.UpdateScreen();
                SaveGame.Pause(msec);
                SaveGame.RedrawSingleLocation(y, x);
                SaveGame.UpdateScreen();
            }
            else
            {
                // Pause even if we can't see it so it doesn't look weird if it goes in and out
                // of sight
                SaveGame.Pause(msec);
            }
            // Check if we might hit a monster (not necessarily the one we were aiming at)
            if (SaveGame.Grid[y][x].MonsterIndex != 0)
            {
                GridTile tile = SaveGame.Grid[y][x];
                Monster monster = SaveGame.Monsters[tile.MonsterIndex];
                MonsterRace race = monster.Race;
                bool visible = monster.IsVisible;
                hitBody = true;
                // Check if we actually hit it
                if (SaveGame.PlayerCheckRangedHitOnMonster(chanceToHit - curDis, race.ArmorClass, monster.IsVisible))
                {
                    string noteDies = " dies.";
                    if (race.Demon || race.Undead || race.Cthuloid || race.Stupid || "Evg".Contains(race.Symbol.Character.ToString()))
                    {
                        noteDies = " is destroyed.";
                    }
                    if (!visible)
                    {
                        SaveGame.MsgPrint($"The {missileName} finds a mark.");
                    }
                    else
                    {
                        string monsterName = monster.Name;
                        SaveGame.MsgPrint($"The {missileName} hits {monsterName}.");
                        if (monster.IsVisible)
                        {
                            SaveGame.HealthTrack(tile.MonsterIndex);
                        }
                        // Note that pets only get angry if they see us and we see them
                        if (monster.SmFriendly)
                        {
                            monsterName = monster.Name;
                            SaveGame.MsgPrint($"{monsterName} gets angry!");
                            monster.SmFriendly = false;
                        }
                    }
                    // Work out the damage done
                    shotDamage = individualAmmunition.AdjustDamageForMonsterType(shotDamage, monster);
                    shotDamage = SaveGame.PlayerCriticalRanged(individualAmmunition.Weight, individualAmmunition.BonusToHit, shotDamage);
                    if (shotDamage < 0)
                    {
                        shotDamage = 0;
                    }
                    if (SaveGame.DamageMonster(tile.MonsterIndex, shotDamage, out bool fear, noteDies))
                    {
                        // The monster is dead, so don't add further statuses or messages
                    }
                    else
                    {
                        SaveGame.MessagePain(tile.MonsterIndex, shotDamage);
                        if (fear && monster.IsVisible)
                        {
                            SaveGame.PlaySound(SoundEffectEnum.MonsterFlees);
                            string mName = monster.Name;
                            SaveGame.MsgPrint($"{mName} flees in terror!");
                        }
                    }
                }
                // Stop the ammo's travel since we hit something
                break;
            }
        }
        // If we hit something we have a chance to break the ammo, otherwise it just drops at
        // the end of its travel
        int j = hitBody ? individualAmmunition.Factory.PercentageBreakageChance : 0;
        SaveGame.DropNear(individualAmmunition, j, y, x);
    }
}