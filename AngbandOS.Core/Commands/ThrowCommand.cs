using Cthangband.Enumerations;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Throw an item
    /// </summary>
    [Serializable]
    internal class ThrowCommand : ICommand
    {
        public char Key => 'v';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DoCmdThrow(saveGame, 1);
        }

        public static void DoCmdThrow(SaveGame saveGame, int damageMultiplier)
        {
            // Get an item to throw
            if (!saveGame.GetItem(out int itemIndex, "Throw which item? ", false, true, true))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing to throw.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            TargetEngine targetEngine = new TargetEngine(saveGame);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Copy a single item from the item stack as the thrown item
            Item missile = new Item(saveGame, item) { Count = 1 };
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
            string missileName = missile.Description(false, 3);
            Colour missileColour = missile.ItemType.Colour;
            char missileCharacter = missile.ItemType.Character;
            // Thrown distance is based on the weight of the missile
            int multiplier = 10 + (2 * (damageMultiplier - 1));
            int divider = missile.Weight > 10 ? missile.Weight : 10;
            int throwDistance = (saveGame.Player.AbilityScores[Ability.Strength].StrAttackSpeedComponent + 20) * multiplier / divider;
            if (throwDistance > 10)
            {
                throwDistance = 10;
            }
            // Work out the damage done
            int damage = Program.Rng.DiceRoll(missile.DamageDice, missile.DamageDiceSides) + missile.BonusDamage;
            damage *= damageMultiplier;
            int chance = saveGame.Player.SkillThrowing + (saveGame.Player.AttackBonus * Constants.BthPlusAdj);
            // Throwing something always uses a full turn, even if you can make multiple missile attacks
            saveGame.EnergyUse = 100;
            int y = saveGame.Player.MapY;
            int x = saveGame.Player.MapX;
            int targetX = saveGame.Player.MapX + (99 * saveGame.Level.KeypadDirectionXOffset[dir]);
            int targetY = saveGame.Player.MapY + (99 * saveGame.Level.KeypadDirectionYOffset[dir]);
            if (dir == 5 && targetEngine.TargetOkay())
            {
                targetX = saveGame.TargetCol;
                targetY = saveGame.TargetRow;
            }
            saveGame.HandleStuff();
            int newY = saveGame.Player.MapY;
            int newX = saveGame.Player.MapX;
            bool hitBody = false;
            // Send the thrown object in the right direction one square at a time
            for (int curDis = 0; curDis <= throwDistance;)
            {
                // If we reach our limit, stop the object moving
                if (y == targetY && x == targetX)
                {
                    break;
                }
                saveGame.Level.MoveOneStepTowards(out newY, out newX, y, x, saveGame.Player.MapY, saveGame.Player.MapX, targetY, targetX);
                // If we hit a wall or something stop moving
                if (!saveGame.Level.GridPassable(newY, newX))
                {
                    break;
                }
                curDis++;
                x = newX;
                y = newY;
                const int msec = GlobalData.DelayFactor * GlobalData.DelayFactor * GlobalData.DelayFactor;
                // If we can see, display the thrown item with a suitable delay
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
                    // Delay even if we don't see it, so it doesn't look weird when it passes behind something
                    saveGame.Pause(msec);
                }
                // If there's a monster in the way, we might hit it regardless of whether or not it
                // is our intended target
                if (saveGame.Level.Grid[y][x].MonsterIndex != 0)
                {
                    GridTile tile = saveGame.Level.Grid[y][x];
                    Monster monster = saveGame.Level.Monsters[tile.MonsterIndex];
                    MonsterRace race = monster.Race;
                    bool visible = monster.IsVisible;
                    hitBody = true;
                    // See if it actually hit the monster
                    if (saveGame.PlayerCheckRangedHitOnMonster(chance - curDis, race.ArmourClass, monster.IsVisible))
                    {
                        string noteDies = " dies.";
                        if ((race.Flags3 & MonsterFlag3.Demon) != 0 || (race.Flags3 & MonsterFlag3.Undead) != 0 ||
                            (race.Flags3 & MonsterFlag3.Cthuloid) != 0 || (race.Flags2 & MonsterFlag2.Stupid) != 0 ||
                            "Evg".Contains(race.Character.ToString()))
                        {
                            noteDies = " is destroyed.";
                        }
                        // Let the player know what happened
                        if (!visible)
                        {
                            saveGame.MsgPrint($"The {missileName} finds a mark.");
                        }
                        else
                        {
                            string mName = monster.MonsterDesc(0);
                            saveGame.MsgPrint($"The {missileName} hits {mName}.");
                            if (monster.IsVisible)
                            {
                                saveGame.HealthTrack(tile.MonsterIndex);
                            }
                        }
                        // Adjust the damage for the particular monster type
                        damage = missile.AdjustDamageForMonsterType(damage, monster);
                        damage = saveGame.PlayerCriticalRanged(missile.Weight, missile.BonusToHit, damage);
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        if (saveGame.Level.Monsters.DamageMonster(tile.MonsterIndex, damage, out bool fear, noteDies))
                        {
                            // The monster is dead, so don't add further statuses or messages
                        }
                        else
                        {
                            // Let the player know what happens to the monster
                            saveGame.Level.Monsters.MessagePain(tile.MonsterIndex, damage);
                            if ((monster.Mind & Constants.SmFriendly) != 0 &&
                                missile.ItemType.Category != ItemCategory.Potion)
                            {
                                string mName = monster.MonsterDesc(0);
                                saveGame.MsgPrint($"{mName} gets angry!");
                                monster.Mind &= ~Constants.SmFriendly;
                            }
                            if (fear && monster.IsVisible)
                            {
                                saveGame.PlaySound(SoundEffect.MonsterFlees);
                                string mName = monster.MonsterDesc(0);
                                saveGame.MsgPrint($"{mName} flees in terror!");
                            }
                        }
                    }
                    break;
                }
            }
            // There's a chance of breakage if we hit a creature
            int chanceToBreak = hitBody ? missile.BreakageChance() : 0;
            // If we hit with a potion, the potion might affect the creature
            if (missile.ItemType.Category == ItemCategory.Potion)
            {
                if (hitBody || !saveGame.Level.GridPassable(newY, newX) || Program.Rng.DieRoll(100) < chanceToBreak)
                {
                    saveGame.MsgPrint($"The {missileName} shatters!");
                    if (saveGame.PotionSmashEffect(1, y, x, missile.ItemSubCategory))
                    {
                        if (saveGame.Level.Grid[y][x].MonsterIndex != 0 &&
                            (saveGame.Level.Monsters[saveGame.Level.Grid[y][x].MonsterIndex].Mind & Constants.SmFriendly) != 0)
                        {
                            string mName = saveGame.Level.Monsters[saveGame.Level.Grid[y][x].MonsterIndex].MonsterDesc(0);
                            saveGame.MsgPrint($"{mName} gets angry!");
                            saveGame.Level.Monsters[saveGame.Level.Grid[y][x].MonsterIndex].Mind &= ~Constants.SmFriendly;
                        }
                    }
                    return;
                }
                chanceToBreak = 0;
            }
            // Drop the item on the floor
            saveGame.Level.DropNear(missile, chanceToBreak, y, x);
        }
    }
}
