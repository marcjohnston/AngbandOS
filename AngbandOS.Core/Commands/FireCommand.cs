using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using AngbandOS.Core.Interface;
using AngbandOS.ItemCategories;
using AngbandOS.Core;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Fire the missile weapon we have in our hand
    /// </summary>
    [Serializable]
    internal class FireCommand : ICommand
    {
        public char Key => 'f';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            // Check that we're actually wielding a ranged weapon
            Item missileWeapon = saveGame.Player.Inventory[InventorySlot.RangedWeapon];
            if (missileWeapon.Category == 0)
            {
                saveGame.MsgPrint("You have nothing to fire with.");
                return;
            }
            // Get the ammunition to fire
            Inventory.ItemFilterCategory = saveGame.Player.AmmunitionItemCategory;
            if (!saveGame.GetItem(out int itemIndex, "Fire which item? ", false, true, true))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing to fire.");
                }
                return;
            }
            Item ammunitionStack = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            TargetEngine targetEngine = new TargetEngine(saveGame);
            // Find out where we're aiming at
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Copy an ammunition piece from the stack...
            Item individualAmmunition = new Item(saveGame, ammunitionStack) { Count = 1 };
            // ...and reduced the amount in the stack
            if (itemIndex >= 0)
            {
                saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -1);
                saveGame.Player.Inventory.InvenItemDescribe(itemIndex);
                saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
            }
            else
            {
                saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                saveGame.Level.FloorItemOptimize(0 - itemIndex);
            }
            saveGame.PlaySound(SoundEffect.Shoot);
            // Get the details of the shot
            string missileName = individualAmmunition.Description(false, 3);
            Colour missileColour = individualAmmunition.ItemType.Colour;
            char missileCharacter = individualAmmunition.ItemType.Character;
            int shotSpeed = saveGame.Player.MissileAttacksPerRound;
            int shotDamage = Program.Rng.DiceRoll(individualAmmunition.DamageDice, individualAmmunition.DamageDiceSides) + individualAmmunition.BonusDamage + missileWeapon.BonusDamage;
            int attackBonus = saveGame.Player.AttackBonus + individualAmmunition.BonusToHit + missileWeapon.BonusToHit;
            int chanceToHit = saveGame.Player.SkillRanged + (attackBonus * Constants.BthPlusAdj);
            // Damage multiplier depends on weapon
            BowWeaponItemCategory missileWeaponItemCategory = (BowWeaponItemCategory)missileWeapon.ItemType.BaseItemCategory;
            int damageMultiplier = missileWeaponItemCategory.MissileDamageMultiplier;
            // Extra might gives us an increased multiplier
            if (saveGame.Player.HasExtraMight)
            {
                damageMultiplier++;
            }
            shotDamage *= damageMultiplier;
            // We're actually going to track the shot and draw it square by square
            int shotDistance = 10 + (5 * damageMultiplier);
            // Divide by our shot speed to give the equivalent of x shots per turn
            saveGame.EnergyUse = 100 / shotSpeed;
            int y = saveGame.Player.MapY;
            int x = saveGame.Player.MapX;
            int targetX = saveGame.Player.MapX + (99 * saveGame.Level.KeypadDirectionXOffset[dir]);
            int targetY = saveGame.Player.MapY + (99 * saveGame.Level.KeypadDirectionYOffset[dir]);
            // Special case for if we're hitting our own square
            if (dir == 5 && targetEngine.TargetOkay())
            {
                targetX = saveGame.TargetCol;
                targetY = saveGame.TargetRow;
            }
            saveGame.HandleStuff();
            bool hitBody = false;
            // Loop until we've reached our distance or hit something
            for (int curDis = 0; curDis <= shotDistance;)
            {
                if (y == targetY && x == targetX)
                {
                    break;
                }
                // Move a step towards the target
                saveGame.Level.MoveOneStepTowards(out int newY, out int newX, y, x, saveGame.Player.MapY, saveGame.Player.MapX, targetY, targetX);
                // If we were blocked by a wall or something then stop short
                if (!saveGame.Level.GridPassable(newY, newX))
                {
                    break;
                }
                curDis++;
                x = newX;
                y = newY;
                int msec = GlobalData.DelayFactor * GlobalData.DelayFactor * GlobalData.DelayFactor;
                // If we can see the current projectile location, show it briefly
                if (saveGame.Level.PanelContains(y, x) && saveGame.Level.PlayerCanSeeBold(y, x))
                {
                    saveGame.Level.PrintCharacterAtMapLocation(missileCharacter, missileColour, y, x);
                    saveGame.Level.MoveCursorRelative(y, x);
                    saveGame.UpdateScreen();
                    saveGame.Pause(msec);
                    saveGame.Level.RedrawSingleLocation(y, x);
                    saveGame.UpdateScreen();
                }
                else
                {
                    // Pause even if we can't see it so it doesn't look weird if it goes in and out
                    // of sight
                    saveGame.Pause(msec);
                }
                // Check if we might hit a monster (not necessarily the one we were aiming at)
                if (saveGame.Level.Grid[y][x].MonsterIndex != 0)
                {
                    GridTile tile = saveGame.Level.Grid[y][x];
                    Monster monster = saveGame.Level.Monsters[tile.MonsterIndex];
                    MonsterRace race = monster.Race;
                    bool visible = monster.IsVisible;
                    hitBody = true;
                    // Check if we actually hit it
                    if (saveGame.PlayerCheckRangedHitOnMonster(chanceToHit - curDis, race.ArmourClass, monster.IsVisible))
                    {
                        string noteDies = " dies.";
                        if ((race.Flags3 & MonsterFlag3.Demon) != 0 || (race.Flags3 & MonsterFlag3.Undead) != 0 ||
                            (race.Flags3 & MonsterFlag3.Cthuloid) != 0 || (race.Flags2 & MonsterFlag2.Stupid) != 0 ||
                            "Evg".Contains(race.Character.ToString()))
                        {
                            noteDies = " is destroyed.";
                        }
                        if (!visible)
                        {
                            saveGame.MsgPrint($"The {missileName} finds a mark.");
                        }
                        else
                        {
                            string monsterName = monster.MonsterDesc(0);
                            saveGame.MsgPrint($"The {missileName} hits {monsterName}.");
                            if (monster.IsVisible)
                            {
                                saveGame.HealthTrack(tile.MonsterIndex);
                            }
                            // Note that pets only get angry if they see us and we see them
                            if ((monster.Mind & Constants.SmFriendly) != 0)
                            {
                                monsterName = monster.MonsterDesc(0);
                                saveGame.MsgPrint($"{monsterName} gets angry!");
                                monster.Mind &= ~Constants.SmFriendly;
                            }
                        }
                        // Work out the damage done
                        shotDamage = individualAmmunition.AdjustDamageForMonsterType(shotDamage, monster);
                        shotDamage = saveGame.PlayerCriticalRanged(individualAmmunition.Weight, individualAmmunition.BonusToHit, shotDamage);
                        if (shotDamage < 0)
                        {
                            shotDamage = 0;
                        }
                        if (saveGame.Level.Monsters.DamageMonster(tile.MonsterIndex, shotDamage, out bool fear, noteDies))
                        {
                            // The monster is dead, so don't add further statuses or messages
                        }
                        else
                        {
                            saveGame.Level.Monsters.MessagePain(tile.MonsterIndex, shotDamage);
                            if (fear && monster.IsVisible)
                            {
                                saveGame.PlaySound(SoundEffect.MonsterFlees);
                                string mName = monster.MonsterDesc(0);
                                saveGame.MsgPrint($"{mName} flees in terror!");
                            }
                        }
                    }
                    // Stop the ammo's travel since we hit something
                    break;
                }
            }
            // If we hit something we have a chance to break the ammo, otherwise it just drops at
            // the end of its travel
            int j = hitBody ? individualAmmunition.BreakageChance() : 0;
            saveGame.Level.DropNear(individualAmmunition, j, y, x);
        }
    }
}
