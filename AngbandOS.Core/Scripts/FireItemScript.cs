// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireItemScript : Script, IScript, IRepeatableScript
{
    private FireItemScript(Game game) : base(game) { }

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
        RangedWeaponInventorySlot rangedWeaponInventorySlot = (RangedWeaponInventorySlot)Game.SingletonRepository.InventorySlots.Get(nameof(RangedWeaponInventorySlot));
        WeightedRandom<int> weightedRandom = rangedWeaponInventorySlot.WeightedRandom;
        Item? missileWeapon = Game.GetInventoryItem(weightedRandom.ChooseOrDefault());
        if (missileWeapon == null || missileWeapon.Category == 0)
        {
            Game.MsgPrint("You have nothing to fire with.");
            return;
        }
        // Get the ammunition to fire
        if (!Game.SelectItem(out Item? ammunitionStack, "Fire which item? ", false, true, true, Game.SingletonRepository.ItemFilters.Get(nameof(CanBeFiredItemFilter))))
        {
            Game.MsgPrint("You have nothing to fire.");
            return;
        }
        if (ammunitionStack == null)
        {
            return;
        }
        // Find out where we're aiming at
        if (!Game.GetDirectionWithAim(out int dir))
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
        Game.PlaySound(SoundEffectEnum.Shoot);
        // Get the details of the shot
        string missileName = individualAmmunition.Description(false, 3);
        ColorEnum missileColor = individualAmmunition.Factory.FlavorColor;
        char missileCharacter = individualAmmunition.Factory.FlavorSymbol.Character;
        int shotSpeed = Game.MissileAttacksPerRound;
        int shotDamage = Game.DiceRoll(individualAmmunition.DamageDice, individualAmmunition.DamageDiceSides) + individualAmmunition.BonusDamage + missileWeapon.BonusDamage;
        int attackBonus = Game.AttackBonus + individualAmmunition.BonusToHit + missileWeapon.BonusToHit;
        int chanceToHit = Game.SkillRanged + (attackBonus * Constants.BthPlusAdj);
        // Damage multiplier depends on weapon
        BowWeaponItemFactory missileWeaponItemCategory = (BowWeaponItemFactory)missileWeapon.Factory;
        int damageMultiplier = missileWeaponItemCategory.MissileDamageMultiplier;
        // Extra might gives us an increased multiplier
        if (Game.HasExtraMight)
        {
            damageMultiplier++;
        }
        shotDamage *= damageMultiplier;
        // We're actually going to track the shot and draw it square by square
        int shotDistance = 10 + (5 * damageMultiplier);
        // Divide by our shot speed to give the equivalent of x shots per turn
        Game.EnergyUse = 100 / shotSpeed;
        int y = Game.MapY;
        int x = Game.MapX;
        int targetX = Game.MapX + (99 * Game.KeypadDirectionXOffset[dir]);
        int targetY = Game.MapY + (99 * Game.KeypadDirectionYOffset[dir]);
        // Special case for if we're hitting our own square
        if (dir == 5 && Game.TargetOkay())
        {
            targetX = Game.TargetCol;
            targetY = Game.TargetRow;
        }
        Game.HandleStuff();
        bool hitBody = false;
        // Loop until we've reached our distance or hit something
        for (int curDis = 0; curDis <= shotDistance;)
        {
            if (y == targetY && x == targetX)
            {
                break;
            }
            // Move a step towards the target
            Game.MoveOneStepTowards(out int newY, out int newX, y, x, Game.MapY, Game.MapX, targetY, targetX);
            // If we were blocked by a wall or something then stop short
            if (!Game.GridPassable(newY, newX))
            {
                break;
            }
            curDis++;
            x = newX;
            y = newY;
            int msec = Constants.DelayFactorInMilliseconds;
            // If we can see the current projectile location, show it briefly
            if (Game.PanelContains(y, x) && Game.PlayerCanSeeBold(y, x))
            {
                Game.MainForm.PutCharAtMapLocation(missileCharacter, missileColor, y, x);
                Game.MainForm.GotoMapLocation(y, x);
                Game.UpdateScreen();
                Game.Pause(msec);
                Game.MainForm.RefreshMapLocation(y, x);
                Game.UpdateScreen();
            }
            else
            {
                // Pause even if we can't see it so it doesn't look weird if it goes in and out
                // of sight
                Game.Pause(msec);
            }
            // Check if we might hit a monster (not necessarily the one we were aiming at)
            if (Game.Grid[y][x].MonsterIndex != 0)
            {
                GridTile tile = Game.Grid[y][x];
                Monster monster = Game.Monsters[tile.MonsterIndex];
                MonsterRace race = monster.Race;
                bool visible = monster.IsVisible;
                hitBody = true;
                // Check if we actually hit it
                if (Game.PlayerCheckRangedHitOnMonster(chanceToHit - curDis, race.ArmorClass, monster.IsVisible))
                {
                    string noteDies = " dies.";
                    if (race.Demon || race.Undead || race.Cthuloid || race.Stupid || "Evg".Contains(race.Symbol.Character.ToString()))
                    {
                        noteDies = " is destroyed.";
                    }
                    if (!visible)
                    {
                        Game.MsgPrint($"The {missileName} finds a mark.");
                    }
                    else
                    {
                        string monsterName = monster.Name;
                        Game.MsgPrint($"The {missileName} hits {monsterName}.");
                        if (monster.IsVisible)
                        {
                            Game.HealthTrack(tile.MonsterIndex);
                        }
                        // Note that pets only get angry if they see us and we see them
                        if (monster.SmFriendly)
                        {
                            monsterName = monster.Name;
                            Game.MsgPrint($"{monsterName} gets angry!");
                            monster.SmFriendly = false;
                        }
                    }
                    // Work out the damage done
                    shotDamage = individualAmmunition.AdjustDamageForMonsterType(shotDamage, monster);
                    shotDamage = Game.PlayerCriticalRanged(individualAmmunition.Weight, individualAmmunition.BonusToHit, shotDamage);
                    if (shotDamage < 0)
                    {
                        shotDamage = 0;
                    }
                    if (Game.DamageMonster(tile.MonsterIndex, shotDamage, out bool fear, noteDies))
                    {
                        // The monster is dead, so don't add further statuses or messages
                    }
                    else
                    {
                        Game.MessagePain(tile.MonsterIndex, shotDamage);
                        if (fear && monster.IsVisible)
                        {
                            Game.PlaySound(SoundEffectEnum.MonsterFlees);
                            string mName = monster.Name;
                            Game.MsgPrint($"{mName} flees in terror!");
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
        Game.DropNear(individualAmmunition, j, y, x);
    }
}
