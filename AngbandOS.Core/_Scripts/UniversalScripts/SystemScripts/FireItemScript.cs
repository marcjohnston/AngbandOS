// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class FireItemScript : UniversalScript, IGetKey
{
    private FireItemScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the fire script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Check that we're actually wielding a ranged weapon
        RangedWeaponWieldSlot rangedWeaponInventorySlot = (RangedWeaponWieldSlot)Game.SingletonRepository.Get<WieldSlot>(nameof(RangedWeaponWieldSlot));
        WeightedRandom<int> weightedRandom = rangedWeaponInventorySlot.WeightedRandom;
        Item? missileWeapon = Game.GetInventoryItem(weightedRandom.ChooseOrDefault());
        if (missileWeapon == null)
        {
            Game.MsgPrint("You have nothing to fire with.");
            return;
        }
        // Get the ammunition to fire
        if (!Game.SelectItem(out Item? ammunitionStack, "Fire which item? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeFiredItemFilter))))
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
        Item individualAmmunition = ammunitionStack.TakeFromStack(1);
        // ...and reduced the amount in the stack
        if (ammunitionStack.IsInInventory)
        {
            ammunitionStack.ItemDescribe();
        }
        ammunitionStack.ItemOptimize();
        Game.PlaySound(SoundEffectEnum.Shoot);
        // Get the details of the shot
        string missileName = individualAmmunition.GetFullDescription(false);
        ColorEnum missileColor = individualAmmunition.FlavorColor;
        char missileCharacter = individualAmmunition.FlavorSymbol.Character;
        int shotSpeed = Game.MissileAttacksPerRound;
        int shotDamage = Game.DiceRoll(individualAmmunition.EffectivePropertySet.DamageDice, individualAmmunition.DamageSides) + individualAmmunition.EffectivePropertySet.BonusDamage + missileWeapon.EffectivePropertySet.BonusDamage;
        int attackBonus = Game.Bonuses.AttackBonus + individualAmmunition.EffectivePropertySet.BonusHit + missileWeapon.EffectivePropertySet.BonusHit;
        int chanceToHit = Game.SkillRanged + (attackBonus * Constants.BthPlusAdj);

        // Damage multiplier depends on weapon
        int damageMultiplier = missileWeapon.MissileDamageMultiplier;

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
        int y = Game.MapY.IntValue;
        int x = Game.MapX.IntValue;
        int targetX = Game.MapX.IntValue + (99 * Game.KeypadDirectionXOffset[dir]); // TODO: Fix the 99*
        int targetY = Game.MapY.IntValue + (99 * Game.KeypadDirectionYOffset[dir]); // TODO: Fix the 99*
        // Special case for if we're hitting our own square
        if (dir == 5 && Game.TargetWho != null)
        {
            GridCoordinate? target = Game.TargetWho.GetTargetLocation();
            if (target != null)
            {
                targetX = target.X;
                targetY = target.Y;
            }
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
            Game.MoveOneStepTowards(out int newY, out int newX, y, x, Game.MapY.IntValue, Game.MapX.IntValue, targetY, targetX);
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
                Game.ConsoleView.PutCharAtMapLocation(missileCharacter, missileColor, y, x);
                Game.ConsoleView.MoveCursorTo(y, x);
                Game.UpdateScreen();
                Game.Pause(msec);
                Game.ConsoleView.RefreshMapLocation(y, x);
                Game.UpdateScreen();
            }
            else
            {
                // Pause even if we can't see it so it doesn't look weird if it goes in and out
                // of sight
                Game.Pause(msec);
            }
            // Check if we might hit a monster (not necessarily the one we were aiming at)
            if (Game.Map.Grid[y][x].MonsterIndex != 0)
            {
                GridTile tile = Game.Map.Grid[y][x];
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
                        if (monster.IsPet)
                        {
                            monsterName = monster.Name;
                            Game.MsgPrint($"{monsterName} gets angry!");
                            monster.IsPet = false;
                        }
                    }
                    // Work out the damage done
                    shotDamage = individualAmmunition.AdjustDamageForMonsterType(shotDamage, monster);
                    shotDamage = Game.PlayerCriticalRanged(individualAmmunition.EffectivePropertySet.Weight, individualAmmunition.EffectivePropertySet.BonusHit, shotDamage);
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
                        Game.MessagePain(monster, shotDamage);
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
        Game.DropNear(individualAmmunition, hitBody ? individualAmmunition.BreakageChanceProbability : null, y, x);
    }
}
