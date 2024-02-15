// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class Monster : IItemContainer
{
    public int ConfusionLevel;

    /// <summary>
    /// How far away from the player the monster is
    /// </summary>
    public int DistanceFromPlayer;

    public int Energy;

    public int FearLevel;

    public List<Item> Items = new List<Item>();
    public int Generation;
    public int Health;
    public int IndividualMonsterFlags;
    public bool IsVisible;
    public int MapX;
    public int MapY;
    public int MaxHealth;

    public bool SmCloned = false;
    public bool SmFriendly = false;
    public bool SmImmAcid = false;
    public bool SmImmCold = false;
    public bool SmImmElec = false;
    public bool SmImmFire = false;
    public bool SmImmFree = false;
    public bool SmImmMana = false;
    public bool SmImmReflect = false;
    public bool SmImmXxx5 = false;
    public bool SmOppAcid = false;
    public bool SmOppCold = false;
    public bool SmOppElec = false;
    public bool SmOppFire = false;
    public bool SmOppPois = false;
    public bool SmOppXXx1 = false;
    public bool SmResAcid = false;
    public bool SmResBlind = false;
    public bool SmResChaos = false;
    public bool SmResCold = false;
    public bool SmResConf = false;
    public bool SmResDark = false;
    public bool SmResDisen = false;
    public bool SmResElec = false;
    public bool SmResFear = false;
    public bool SmResFire = false;
    public bool SmResLight = false;
    public bool SmResNeth = false;
    public bool SmResNexus = false;
    public bool SmResPois = false;
    public bool SmResShard = false;
    public bool SmResSound = false;

    public MonsterRace Race;

    /// <summary>
    /// How deeply the monster is sleeping
    /// </summary>
    public int SleepLevel;

    public int Speed;
    public int StolenGold;
    public int StunLevel;
    private readonly SaveGame SaveGame;

    public Monster(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public string DescribeItemLocation(Item oPtr) => $"being held by {Race.Name}";

    public string Label(Item oPtr) => ""; // TODO: Items held by a monster cannot be selected.

    public void AddItem(Item oPtr)
    {
        Items.Add(oPtr);
    }

    public void RemoveItem(Item oPtr)
    {
        Items.Remove(oPtr);
    }

    /// <summary>
    /// Modifies the quantity of an item.  No player stats are modified.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ItemIncrease(Item oPtr, int num)
    {
        num += oPtr.Count;
        if (num > 255)
        {
            num = 255;
        }
        else if (num < 0)
        {
            num = 0;
        }
        num -= oPtr.Count;
        oPtr.Count += num;
    }

    /// <summary>
    /// Renders a description of the item.  For a non-inventory slot, the description is rendered as the player viewing the item.
    /// </summary>
    /// <param name="item"></param>
    public void ItemDescribe(Item oPtr)
    {
        string oName = oPtr.Description(true, 3);
        SaveGame.MsgPrint($"You see {oName}.");
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero. 
    /// </summary>
    /// <param name="oPtr"></param>
    public void ItemOptimize(Item oPtr)
    {
        if (oPtr.Count != 0)
        {
            return;
        }
        Items.Remove(oPtr);
    }

    public void ProcessWorld()
    {
        foreach (Item item in Items)
        {
            item.ProcessWorld();
        }
    }

    /// <summary>
    /// Returns false, because the item container doesn't belong to the players inventory.
    /// </summary>
    public bool IsInInventory => false;
    public bool IsInEquipment => false;

    public string TakeOffMessage(Item oPtr) => ""; // TODO: Monsters do not support removal messages yet.

    /// <summary>
    /// Returns the name of the monster.
    /// </summary>
    public string Name => MonsterDescription(0x00);

    /// <summary>
    /// Returns a possessive or reflexive name for the monster.
    /// </summary>
    public string PossessiveName => MonsterDescription(0x22);

    /// <summary>
    /// Returns the  indefinite name for the monster, assuming the monster is visible.
    /// </summary>
    public string IndefiniteVisibleName => MonsterDescription(0x88);

    /// <summary>
    /// Returns the indefinite name for the monster, when the monster is hidden.
    /// </summary>
    public string IndefiniteWhenHiddenName => MonsterDescription(0x04);

    /// <summary>
    /// Return the name of the monster, assuming the monster is visible.
    /// </summary>
    public string VisibleName => MonsterDescription(0x80);

    /// <summary>
    /// Returns the indefinite name fo the monster, when the monster is visible.
    /// </summary>
    public string IndefinitionWhenVisibleName => MonsterDescription(0x08);

    /// <summary>
    /// </summary>
    /// <param name="mode"> </param>
    /// <returns> </returns>
    private string MonsterDescription(int mode)
    {
        // * Mode Flags:
        // *   0x01 --&gt; Objective(or Reflexive)
        // *   0x02 --&gt; Possessive(or Reflexive)
        // *   0x04 --&gt; Use indefinites for hidden monsters("something")
        // *   0x08 --&gt; Use indefinites for visible monsters("a kobold")
        // *   0x10 --&gt; Pronominalize hidden monsters
        // *   0x20 --&gt; Pronominalize visible monsters
        // *   0x40 --&gt; Assume the monster is hidden
        // *   0x80 --&gt; Assume the monster is visible *
        // * Useful Modes:
        // *   0x00 --&gt; Full nominative name("the kobold") or "it"
        // *   0x04 --&gt; Full nominative name("the kobold") or "something"
        // *   0x80 --&gt; Genocide resistance name("the kobold")
        // *   0x88 --&gt; Killing name("a kobold")
        // *   0x22 --&gt; Possessive, genderized if visable("his") or "its"
        // *   0x23 --&gt; Reflexive, genderized if visable("himself") or "itself"
        if (Race == null)
        {
            return string.Empty;
        }
        string desc;
        string name = Race.Name;
        if (SaveGame.TimedHallucinations.TurnsRemaining != 0)
        {
            MonsterRace halluRace;
            do
            {
                halluRace = SaveGame.SingletonRepository.MonsterRaces[SaveGame.DieRoll(SaveGame.SingletonRepository.MonsterRaces.Count - 2)];
            } while (halluRace.Unique);
            string sillyName = halluRace.Name;
            name = sillyName;
        }
        bool seen = (mode & 0x80) != 0 || ((mode & 0x40) == 0 && IsVisible);
        bool pron = (seen && (mode & 0x20) != 0) || (!seen && (mode & 0x10) != 0);
        if (!seen || pron)
        {
            int kind = 0x00;
            if (Race.Female)
            {
                kind = 0x20;
            }
            else if (Race.Male)
            {
                kind = 0x10;
            }
            if (!pron)
            {
                kind = 0x00;
            }
            string res = "it";
            switch (kind + (mode & 0x07))
            {
                case 0x00:
                    res = "it";
                    break;

                case 0x01:
                    res = "it";
                    break;

                case 0x02:
                    res = "its";
                    break;

                case 0x03:
                    res = "itself";
                    break;

                case 0x04:
                    res = "something";
                    break;

                case 0x05:
                    res = "something";
                    break;

                case 0x06:
                    res = "something's";
                    break;

                case 0x07:
                    res = "itself";
                    break;

                case 0x10:
                    res = "he";
                    break;

                case 0x11:
                    res = "him";
                    break;

                case 0x12:
                    res = "his";
                    break;

                case 0x13:
                    res = "himself";
                    break;

                case 0x14:
                    res = "someone";
                    break;

                case 0x15:
                    res = "someone";
                    break;

                case 0x16:
                    res = "someone's";
                    break;

                case 0x17:
                    res = "himself";
                    break;

                case 0x20:
                    res = "she";
                    break;

                case 0x21:
                    res = "her";
                    break;

                case 0x22:
                    res = "her";
                    break;

                case 0x23:
                    res = "herself";
                    break;

                case 0x24:
                    res = "someone";
                    break;

                case 0x25:
                    res = "someone";
                    break;

                case 0x26:
                    res = "someone's";
                    break;

                case 0x27:
                    res = "herself";
                    break;
            }
            desc = res;
        }
        else if ((mode & 0x02) != 0 && (mode & 0x01) != 0)
        {
            if (Race.Female)
            {
                desc = "herself";
            }
            else if (Race.Male)
            {
                desc = "himself";
            }
            else
            {
                desc = "itself";
            }
        }
        else
        {
            if (Race.Unique && SaveGame.TimedHallucinations.TurnsRemaining == 0)
            {
                desc = name;
            }
            else if ((mode & 0x08) != 0)
            {
                desc = name[0].IsVowel() ? "an " : "a ";
                desc += name;
            }
            else
            {
                desc = SmFriendly ? "your " : "the ";
                desc += name;
            }
            if ((mode & 0x02) != 0)
            {
                desc += "'s";
            }
        }
        return desc;
    }

    public void SanityBlast(bool necro)
    {
        bool happened = false;
        int power = 100;
        if (necro)
        {
            this.SaveGame.MsgPrint("Your sanity is shaken by reading the Necronomicon!");
        }
        else
        {
            power = Race.Level + 10;
            string mName = Name;
            if (Race.Unique)
            {
                power *= 2;
            }
            else
            {
                if (Race.Friends)
                {
                    power /= 2;
                }
            }
            if (!this.SaveGame.HackMind)
            {
                return;
            }
            if (!IsVisible)
            {
                return;
            }
            if (!Race.EldritchHorror)
            {
                return;
            }
            if (SmFriendly && SaveGame.DieRoll(8) != 1)
            {
                return;
            }
            if (SaveGame.DieRoll(power) < SaveGame.SkillSavingThrow)
            {
                return;
            }
            if (SaveGame.TimedHallucinations.TurnsRemaining != 0)
            {
                this.SaveGame.MsgPrint($"You behold the {this.SaveGame.SingletonRepository.FunnyDescriptions.ToWeightedRandom().Choose()} visage of {mName}!");
                if (SaveGame.DieRoll(3) == 1)
                {
                    this.SaveGame.MsgPrint(this.SaveGame.SingletonRepository.FunnyComments.ToWeightedRandom().Choose());
                    SaveGame.TimedHallucinations.AddTimer(SaveGame.DieRoll(Race.Level));
                }
                return;
            }
            this.SaveGame.MsgPrint($"You behold the {this.SaveGame.SingletonRepository.HorrificDescriptions.ToWeightedRandom().Choose()} visage of {mName}!");
            Race.Knowledge.Characteristics.EldritchHorror = true;

            // Allow the race to resist.
            if (SaveGame.DieRoll(100) < SaveGame.Race.ChanceOfSanityBlastImmunity(SaveGame.ExperienceLevel))
            {
                return;
            }
        }
        if (SaveGame.DieRoll(power) < SaveGame.SkillSavingThrow)
        {
            if (!SaveGame.HasConfusionResistance)
            {
                SaveGame.TimedConfusion.AddTimer(SaveGame.RandomLessThan(4) + 4);
            }
            if (!SaveGame.HasChaosResistance && SaveGame.DieRoll(3) == 1)
            {
                SaveGame.TimedHallucinations.AddTimer(SaveGame.RandomLessThan(250) + 150);
            }
            return;
        }
        if (SaveGame.DieRoll(power) < SaveGame.SkillSavingThrow)
        {
            SaveGame.TryDecreasingAbilityScore(Ability.Intelligence);
            SaveGame.TryDecreasingAbilityScore(Ability.Wisdom);
            return;
        }
        if (SaveGame.DieRoll(power) < SaveGame.SkillSavingThrow)
        {
            if (!SaveGame.HasConfusionResistance)
            {
                SaveGame.TimedConfusion.AddTimer(SaveGame.RandomLessThan(4) + 4);
            }
            if (!SaveGame.HasFreeAction)
            {
                SaveGame.TimedParalysis.AddTimer(SaveGame.RandomLessThan(4) + 4);
            }
            while (SaveGame.RandomLessThan(100) > SaveGame.SkillSavingThrow)
            {
                SaveGame.TryDecreasingAbilityScore(Ability.Intelligence);
            }
            while (SaveGame.RandomLessThan(100) > SaveGame.SkillSavingThrow)
            {
                SaveGame.TryDecreasingAbilityScore(Ability.Wisdom);
            }
            if (!SaveGame.HasChaosResistance)
            {
                SaveGame.TimedHallucinations.AddTimer(SaveGame.RandomLessThan(250) + 150);
            }
            return;
        }
        if (SaveGame.DieRoll(power) < SaveGame.SkillSavingThrow)
        {
            if (SaveGame.DecreaseAbilityScore(Ability.Intelligence, 10, true))
            {
                happened = true;
            }
            if (SaveGame.DecreaseAbilityScore(Ability.Wisdom, 10, true))
            {
                happened = true;
            }
            if (happened)
            {
                this.SaveGame.MsgPrint("You feel much less sane than before.");
            }
            return;
        }
        if (SaveGame.DieRoll(power) < SaveGame.SkillSavingThrow)
        {
            if (this.SaveGame.LoseAllInfo())
            {
                this.SaveGame.MsgPrint("You forget everything in your utmost terror!");
            }
            return;
        }
        this.SaveGame.MsgPrint("The exposure to eldritch forces warps you.");
        SaveGame.Dna.GainMutation();
        this.SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        this.SaveGame.HandleStuff();
    }

    /// <summary>
    /// Have an individual monster take its turn
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster </param>
    /// <param name="noise"> The amount of noise the player is making </param>
    public void ProcessMonster(uint noise)
    {
        const int BreakElderSign = 550;

        // Is the monster asleep?
        if (SleepLevel != 0)
        {
            // if the player aggravates, notice them more
            uint notice = 0;
            if (!SaveGame.HasAggravation)
            {
                notice = (uint)SaveGame.RandomLessThan(1024);
            }
            // If the player makes too much noise (or aggravates)
            if (notice * notice * notice <= noise)
            {
                int wakeAmount = 1;
                if (DistanceFromPlayer < 50)
                {
                    wakeAmount = 100 / DistanceFromPlayer;
                }
                // Aggravate wakes the monster fully, if it notices at all
                if (SaveGame.HasAggravation)
                {
                    wakeAmount = SleepLevel;
                }
                // If we're not awake yet, just sleep less deeply
                if (SleepLevel > wakeAmount)
                {
                    SleepLevel -= wakeAmount;
                    // The player may notice
                    if (IsVisible && Race.Knowledge.RIgnore < Constants.MaxUchar)
                    {
                        Race.Knowledge.RIgnore++;
                    }
                }
                else
                {
                    // Wake us up
                    SleepLevel = 0;
                    // If the player sees us wake up, let them know
                    if (IsVisible)
                    {
                        string monsterName = Name;
                        SaveGame.MsgPrint($"{monsterName} wakes up.");
                        // And let the player notice how easily we wake
                        if (Race.Knowledge.RWake < Constants.MaxUchar)
                        {
                            Race.Knowledge.RWake++;
                        }
                    }
                }
            }
            // If we're still asleep after all that, do nothing else for our turn
            if (SleepLevel != 0)
            {
                return;
            }
        }
        // If we're stunned, then reduce our stun saveGame.Level
        if (StunLevel != 0)
        {
            int stunRelief = 1;
            // We have a saveGame.Level-based chance of shaking off the stun completely
            if (SaveGame.RandomLessThan(5000) <= Race.Level * Race.Level)
            {
                stunRelief = StunLevel;
            }
            // Reduce our stun if the relief is not enough to get rid of it
            if (StunLevel > stunRelief)
            {
                StunLevel -= stunRelief;
            }
            else
            {
                // Get rid of all of our stun
                StunLevel = 0;
                // If the player sees us, let them know we're no longer stunned
                if (IsVisible)
                {
                    string monsterName = Name;
                    SaveGame.MsgPrint($"{monsterName} is no longer stunned.");
                }
            }
            // If we are still stunned, don't take a turn
            if (StunLevel != 0)
            {
                return;
            }
        }
        // If we're confused
        if (ConfusionLevel != 0)
        {
            // Reduce our confusion by an amount based on our saveGame.Level
            int confusionRelief = SaveGame.DieRoll((Race.Level / 10) + 1);
            if (ConfusionLevel > confusionRelief)
            {
                ConfusionLevel -= confusionRelief;
            }
            else
            {
                // If we're no longer confused, the player will see this
                ConfusionLevel = 0;
                if (IsVisible)
                {
                    string monsterName = Name;
                    SaveGame.MsgPrint($"{monsterName} is no longer confused.");
                }
            }
        }
        // If we're curently friendly and the player aggravates, then stop being friendly
        bool getsAngry = false;
        if (SmFriendly && SaveGame.HasAggravation)
        {
            getsAngry = true;
        }
        // If we're unique, don't stay friendly
        if (SmFriendly && !SaveGame.IsWizard && Race.Unique)
        {
            getsAngry = true;
        }
        // If we got angry, let the player see that
        if (getsAngry)
        {
            string monsterName = Name;
            SaveGame.MsgPrint($"{monsterName} suddenly becomes hostile!");
            SmFriendly = false;
        }
        // Are we afraid?
        if (FearLevel != 0)
        {
            // Reduce our fear by an amount based on our saveGame.Level
            int fearRelief = SaveGame.DieRoll((Race.Level / 10) + 1);
            if (FearLevel > fearRelief)
            {
                FearLevel -= fearRelief;
            }
            else
            {
                FearLevel = 0;
                // If the player can see us, they can see we're no longer afraid
                if (IsVisible)
                {
                    string monsterName = Name;
                    string monsterPossessive = PossessiveName;
                    SaveGame.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                }
            }
        }
        int oldY = MapY;
        int oldX = MapX;
        // If it's suitable for us to reproduce
        if (Race.Multiply && SaveGame.NumRepro < Constants.MaxRepro && Generation < 10)
        {
            // Find how many spaces we've got near us
            int k;
            int y;
            for (k = 0, y = oldY - 1; y <= oldY + 1; y++)
            {
                for (int x = oldX - 1; x <= oldX + 1; x++)
                {
                    if (SaveGame.Grid[y][x].MonsterIndex != 0)
                    {
                        k++;
                    }
                }
            }
            // If we're friendly, then our babies are friendly too
            bool isFriend = SmFriendly;
            // If there's lots of space, then pop out a baby
            if (k < 4 && (k == 0 || SaveGame.RandomLessThan(k * Constants.MonMultAdj) == 0))
            {
                if (SaveGame.MultiplyMonster(this, isFriend, false))
                {
                    // If the player saw this, they now know we can multiply
                    if (IsVisible)
                    {
                        Race.Knowledge.Characteristics.Multiply = true;
                    }
                    // Having a baby takes our entire turn
                    return;
                }
            }
        }
        // If we can usefully cast a spell against the player, then that's our turn
        if (TryCastingASpellAgainstPlayer())
        {
            return;
        }
        // If we can usefully cast a spell against another monster, then that's our turn
        if (TryCastingASpellAgainstAnotherMonster())
        {
            return;
        }
        // Initialise our possible moves
        PotentialMovesList potentialMoves = new PotentialMovesList();
        potentialMoves[0] = 0;
        potentialMoves[1] = 0;
        potentialMoves[2] = 0;
        potentialMoves[3] = 0;
        potentialMoves[4] = 0;
        potentialMoves[5] = 0;
        potentialMoves[6] = 0;
        potentialMoves[7] = 0;
        // If we're confused, have four attempts to move randomly
        if (ConfusionLevel != 0)
        {
            potentialMoves[0] = 5;
            potentialMoves[1] = 5;
            potentialMoves[2] = 5;
            potentialMoves[3] = 5;
        }
        // If we move randomly most of the time, have a high chance of putting four random moves
        // in the matrix
        else if (Race.RandomMove50 && Race.RandomMove25 && SaveGame.RandomLessThan(100) < 75)
        {
            // If the player sees us, then they learn about our random movement
            if (IsVisible)
            {
                Race.Knowledge.Characteristics.RandomMove50 = true;
                Race.Knowledge.Characteristics.RandomMove25 = true;
            }
            potentialMoves[0] = 5;
            potentialMoves[1] = 5;
            potentialMoves[2] = 5;
            potentialMoves[3] = 5;
        }
        // If we have a moderate chance of moving randomly, maybe put four random moves in our matrix
        else if (Race.RandomMove50 && SaveGame.RandomLessThan(100) < 50)
        {
            // If the player sees us, then they learn about our random movement
            if (IsVisible)
            {
                Race.Knowledge.Characteristics.RandomMove50 = true;
            }
            potentialMoves[0] = 5;
            potentialMoves[1] = 5;
            potentialMoves[2] = 5;
            potentialMoves[3] = 5;
        }
        // If we have a low chance of moving randomly, maybe put four random moves in our matrix
        else if (Race.RandomMove25 && SaveGame.RandomLessThan(100) < 25)
        {
            // If the player sees us, then they learn about our random movement
            if (IsVisible)
            {
                Race.Knowledge.Characteristics.RandomMove25 = true;
            }
            potentialMoves[0] = 5;
            potentialMoves[1] = 5;
            potentialMoves[2] = 5;
            potentialMoves[3] = 5;
        }
        // If we're the player's friend and we're too far away, add sensible moves to our matrix
        else if (SmFriendly)
        {
            if (DistanceFromPlayer > Constants.FollowDistance)
            {
                GetMovesTowardsPlayer(SaveGame, potentialMoves);
            }
            else
            {
                // If we're close to the player (and friendly) just use random moves
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
                // Possibly override these random moves with attacks on enemies
                GetMovesTowardsEnemyMonsters(SaveGame, potentialMoves);
            }
        }
        // If all the above fail, we must be a hostile monster who wants to move towards the player
        else
        {
            // If we fail to get sensible moves, give up on our turn
            if (!GetMovesTowardsPlayer(SaveGame, potentialMoves))
            {
                return;
            }
        }
        bool doTurn = false;
        bool doMove = false;
        bool doView = false;
        bool didOpenDoor = false;
        bool didBashDoor = false;
        bool didTakeItem = false;
        bool didKillItem = false;
        bool didMoveBody = false;
        bool didKillBody = false;
        bool didPassWall = false;
        bool didKillWall = false;
        // Go through our possible moves until we come to the limit of the ones we've had suggested
        for (int i = 0; potentialMoves[i] != 0; i++)
        {
            int d = potentialMoves[i];
            // Moves of '5' (i.e. 'stay still') are placeholders for random moves
            if (d == 5)
            {
                d = SaveGame.OrderedDirection[SaveGame.RandomLessThan(8)];
            }
            // Work out where the move will take us
            int newY = oldY + SaveGame.KeypadDirectionYOffset[d];
            int newX = oldX + SaveGame.KeypadDirectionXOffset[d];
            GridTile tile = SaveGame.Grid[newY][newX];
            Monster monsterInTargetTile = SaveGame.Monsters[tile.MonsterIndex];
            // If we can simply move there, then we will do so
            if (SaveGame.GridPassable(newY, newX))
            {
                doMove = true;
            }
            // Bushes don't actually block us, so we can move there too
            else if (SaveGame.Grid[newY][newX].FeatureType.Name == "Bush")
            {
                doMove = true;
            }
            // We can always attack the player, even if the move would otherwse not be allowed
            else if (newY == SaveGame.MapY && newX == SaveGame.MapX)
            {
                doMove = true;
            }
            // We can always attack another monster, even if the move would otherwise not be allowed
            else if (tile.MonsterIndex != -0)
            {
                doMove = true;
            }
            // We can never go through permanent walls even if we can phase through or destroy
            // normal walls
            else if (tile.FeatureType.IsPermanent)
            {
            }
            // If we can phase through walls then they don't block us
            else if (Race.PassWall)
            {
                doMove = true;
                didPassWall = true;
            }
            // If we can tunnel through walls then they don't block us
            else if (Race.KillWall)
            {
                doMove = true;
                didKillWall = true;
                // Occasionally make a noise if we're going to tunnel
                if (SaveGame.DieRoll(20) == 1)
                {
                    SaveGame.MsgPrint("There is a grinding sound.");
                }
                // Remove the wall (and the player's memory of it) and remind ourselves to
                // update the view if the player can see it
                tile.TileFlags.Clear(GridTile.PlayerMemorized);
                SaveGame.RevertTileToBackground(newY, newX);
                if (SaveGame.PlayerHasLosBold(newY, newX))
                {
                    doView = true;
                }
            }
            // If we're trying to get through a door
            else if (tile.FeatureType.IsVisibleDoor)
            {
                bool mayBash = true;
                doTurn = true;
                // If we can open the door then try to do so
                if (Race.OpenDoor)
                {
                    // We can always open unlocked doors
                    if ((tile.FeatureType.IsClosedDoor && tile.FeatureType.LockLevel == 0) || tile.FeatureType.IsSecretDoor)
                    {
                        didOpenDoor = true;
                        mayBash = false;
                    }
                    // We have a chance to unlock locked doors
                    else if (tile.FeatureType.Name.Contains("Locked"))
                    {
                        int k = int.Parse(tile.FeatureType.Name.Substring(10));
                        if (SaveGame.RandomLessThan(Health / 10) > k)
                        {
                            SaveGame.CaveSetFeat(newY, newX, "LockedDoor0");
                            mayBash = false;
                        }
                    }
                }
                // If we can't open doors (or failed to unlock the door), then we can bash it down
                if (mayBash && Race.BashDoor)
                {
                    int k = int.Parse(tile.FeatureType.Name.Substring(10));
                    // If we succeeded, let the player hear it
                    if (SaveGame.RandomLessThan(Health / 10) > k)
                    {
                        SaveGame.MsgPrint("You hear a door burst open!");
                        didBashDoor = true;
                        doMove = true;
                    }
                }
                // If we opened it or bashed it, replace the closed door with the relevant open
                // or broken one
                if (didOpenDoor || didBashDoor)
                {
                    if (didBashDoor && SaveGame.RandomLessThan(100) < 50)
                    {
                        SaveGame.CaveSetFeat(newY, newX, "BrokenDoor");
                    }
                    else
                    {
                        SaveGame.CaveSetFeat(newY, newX, "OpenDoor");
                    }
                    // If the player can see, remind ourselves to update the view later
                    if (SaveGame.PlayerHasLosBold(newY, newX))
                    {
                        doView = true;
                    }
                }
            }
            // If we're going to move onto an Elder Sign and we're capable of doing attacks
            if (doMove && tile.FeatureType.Name == "ElderSign" && !Race.NeverAttack)
            {
                // Assume we're not moving
                doMove = false;
                // We have a chance of breaking the sign based on our saveGame.Level
                if (SaveGame.DieRoll(BreakElderSign) < Race.Level)
                {
                    // If the player knows the sign is there, let them know it was broken
                    if (tile.TileFlags.IsSet(GridTile.PlayerMemorized))
                    {
                        SaveGame.MsgPrint("The Elder Sign is broken!");
                    }
                    tile.TileFlags.Clear(GridTile.PlayerMemorized);
                    SaveGame.RevertTileToBackground(newY, newX);
                    // Breaking the sign means we can move after all
                    doMove = true;
                }
            }
            // If we're going to move onto a Yellow Sign and we can attack
            else if (doMove && tile.FeatureType.Name == "YellowSign" &&
                     !Race.NeverAttack)
            {
                // Assume we're not moving
                doMove = false;
                // We have a chance to break the sign
                if (SaveGame.DieRoll(Constants.BreakYellowSign) < Race.Level)
                {
                    // If the player knows about the sign, let them know it was broken
                    if (tile.TileFlags.IsSet(GridTile.PlayerMemorized))
                    {
                        // If the player was on the sign, hurt them
                        if (newY == SaveGame.MapY && newX == SaveGame.MapX)
                        {
                            SaveGame.MsgPrint("The rune explodes!");
                            SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)), 0, 2 * ((SaveGame.ExperienceLevel / 2) + SaveGame.DiceRoll(7, 7)), 2);
                        }
                        else
                        {
                            SaveGame.MsgPrint("An Yellow Sign was disarmed.");
                        }
                    }
                    tile.TileFlags.Clear(GridTile.PlayerMemorized);
                    SaveGame.RevertTileToBackground(newY, newX);
                    // We can do the move after all
                    doMove = true;
                }
            }
            // If we're going to attack the player, but our race never attacks, then cancel the move
            if (doMove && newY == SaveGame.MapY && newX == SaveGame.MapX && Race.NeverAttack)
            {
                doMove = false;
            }
            // If we're trying to move onto the player, then attack them instead
            if (doMove && newY == SaveGame.MapY && newX == SaveGame.MapX)
            {
                MonsterAttackPlayer();
                doMove = false;
                doTurn = true;
            }
            // If we're trying to move onto another monster
            if (doMove && tile.MonsterIndex != 0)
            {
                MonsterRace targetMonsterRace = monsterInTargetTile.Race;
                // Assume for the moment we're not doing the move
                doMove = false;
                // If we can trample other monsters on our team and we're tougher than the one
                // that's in our way...
                if (Race.KillBody && Race.Mexp > targetMonsterRace.Mexp && SaveGame.GridPassable(newY, newX) && !(SmFriendly && monsterInTargetTile.SmFriendly))
                {
                    // Remove the other monster and replace it
                    doMove = true;
                    didKillBody = true;
                    SaveGame.DeleteMonster(newY, newX);
                    monsterInTargetTile = SaveGame.Monsters[tile.MonsterIndex];
                }
                // If we're not on the same team as the other monster or we're confused
                else if (SmFriendly != monsterInTargetTile.SmFriendly || ConfusionLevel != 0)
                {
                    doMove = false;
                    // Attack the monster in the target tile
                    if (monsterInTargetTile.Race != null && monsterInTargetTile.Health >= 0)
                    {
                        if (AttackAnotherMonster(tile.MonsterIndex))
                        {
                            return;
                        }
                    }
                }
                // If the other monster is on our team and we can't trample it, maybe we can
                // push past
                else if (Race.MoveBody && Race.Mexp > targetMonsterRace.Mexp && SaveGame.GridPassable(newY, newX) && SaveGame.GridPassable(MapY, MapX))
                {
                    doMove = true;
                    didMoveBody = true;
                }
            }
            // If we're going to do a move but we can't move, cancel it
            if (doMove && Race.NeverMove)
            {
                doMove = false;
            }
            // If we're going to do a move
            if (doMove)
            {
                doTurn = true;
                // Swap positions with the monster that is in the tile we're aiming for
                SaveGame.Grid[oldY][oldX].MonsterIndex = tile.MonsterIndex;
                // If it was actually a monster then update it accordingly
                if (tile.MonsterIndex != 0)
                {
                    monsterInTargetTile.MapY = oldY;
                    monsterInTargetTile.MapX = oldX;
                    SaveGame.UpdateMonsterVisibility(tile.MonsterIndex, true);
                    // Pushing past something wakes it up
                    SaveGame.Monsters[tile.MonsterIndex].SleepLevel = 0;
                }
                // Update our position
                tile.MonsterIndex = GetMonsterIndex();
                MapY = newY;
                MapX = newX;
                SaveGame.UpdateMonsterVisibility(GetMonsterIndex(), true);
                SaveGame.RedrawSingleLocation(oldY, oldX);
                SaveGame.RedrawSingleLocation(newY, newX);
                // If we are hostile and the player saw us move, then saveGame.Disturb them
                if (IsVisible && (IndividualMonsterFlags & Constants.MflagView) != 0)
                {
                    if (!SmFriendly)
                    {
                        SaveGame.Disturb(false);
                    }
                }
                // Check through the items in the tile we just entered
                foreach (Item item in tile.Items.ToArray()) // We need to use a copy because the collection can change
                {
                    // We ignore gold
                    if (item.Factory.IsIgnoredByMonsters)
                    {
                        continue;
                    }
                    // If we pick up or stomp on items, check the item type
                    if ((Race.TakeItem || Race.KillItem) && !SmFriendly)
                    {
                        bool willHurt = false;
                        item.RefreshFlagBasedProperties();
                        string itemName = item.Description(true, 3);
                        string monsterName = IndefiniteWhenHiddenName;
                        if (item.Characteristics.KillDragon && Race.Dragon)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayDragon && Race.Dragon)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayTroll && Race.Troll)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayGiant && Race.Giant)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayOrc && Race.Orc)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayDemon && Race.Demon)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayUndead && Race.Undead)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayAnimal && Race.Animal)
                        {
                            willHurt = true;
                        }
                        if (item.Characteristics.SlayEvil && Race.Evil)
                        {
                            willHurt = true;
                        }
                        // Monsters won't pick up artifacts or items that hurt them
                        if (item.FixedArtifact != null || willHurt || !string.IsNullOrEmpty(item.RandartName))
                        {
                            if (Race.TakeItem)
                            {
                                didTakeItem = true;
                                if (IsVisible && SaveGame.PlayerHasLosBold(newY, newX))
                                {
                                    SaveGame.MsgPrint($"{monsterName} tries to pick up {itemName}, but fails.");
                                }
                            }
                        }
                        // If we picked up the item and the player saw, let them know
                        else if (Race.TakeItem)
                        {
                            didTakeItem = true;
                            if (SaveGame.PlayerHasLosBold(newY, newX))
                            {
                                SaveGame.MsgPrint($"{monsterName} picks up {itemName}.");
                            }
                            // And pick up the actual item
                            SaveGame.ExciseObject(item);
                            item.Marked = false;
                            item.Y = 0;
                            item.X = 0;
                            item.HoldingMonsterIndex = GetMonsterIndex();
                            Items.Add(item);
                        }
                        else
                        {
                            // We can't pick up the item, so just stomp on it
                            didKillItem = true;
                            // If the player saw us, let them know
                            if (SaveGame.PlayerHasLosBold(newY, newX))
                            {
                                SaveGame.MsgPrint($"{monsterName} crushes {itemName}.");
                            }
                            SaveGame.DeleteObject(item);
                        }
                    }
                }
            }
            // If we did something, then don't try another potential move
            if (doTurn)
            {
                break;
            }
        }
        // If all our moves failed, have another go at casting a spell at the player
        if (!doTurn && !doMove && FearLevel == 0 && !SmFriendly)
        {
            if (TryCastingASpellAgainstPlayer())
            {
                return;
            }
        }
        // Update the view if necessary
        if (doView)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateScentFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        }
        // If we did something unusual and the player saw, let them remember we can do that
        if (IsVisible)
        {
            if (didOpenDoor)
            {
                Race.Knowledge.Characteristics.OpenDoor = true;
            }
            if (didBashDoor)
            {
                Race.Knowledge.Characteristics.BashDoor = true;
            }
            if (didTakeItem)
            {
                Race.Knowledge.Characteristics.TakeItem = true;
            }
            if (didKillItem)
            {
                Race.Knowledge.Characteristics.KillItem = true;
            }
            if (didMoveBody)
            {
                Race.Knowledge.Characteristics.MoveBody = true;
            }
            if (didKillBody)
            {
                Race.Knowledge.Characteristics.KillBody = true;
            }
            if (didPassWall)
            {
                Race.Knowledge.Characteristics.PassWall = true;
            }
            if (didKillWall)
            {
                Race.Knowledge.Characteristics.KillWall = true;
            }
        }
        // If we couldn't do anything because we were afraid and cornered, lose our fear
        if (!doTurn && !doMove && FearLevel != 0)
        {
            FearLevel = 0;
            if (IsVisible)
            {
                string monsterName = Name;
                SaveGame.MsgPrint($"{monsterName} turns to fight!");
            }
        }
    }
    /// <summary>
    /// Make a set of attacks on another monster
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster making the attack </param>
    /// <param name="targetIndex"> The index of the target monster </param>
    /// <returns> True if the attack happened, false if not </returns>
    private bool AttackAnotherMonster(int targetIndex)
    {
        Monster target = SaveGame.Monsters[targetIndex];
        MonsterRace targetRace = target.Race;
        int ySaver = target.MapY;
        int xSaver = target.MapX;
        // If we never attack then we shouldn't this time
        if (Race.NeverAttack)
        {
            return false;
        }
        int armorClass = targetRace.ArmorClass;
        int monsterLevel = Race.Level >= 1 ? Race.Level : 1;
        string monsterName = Name;

        bool blinked = false;
        // If the player can't see either monster, they just hear noise
        if (!(IsVisible || target.IsVisible))
        {
            SaveGame.MsgPrint("You hear noise.");
        }
        // We have up to four attacks
        for (int attackNumber = 0; attackNumber < Race.Attacks.Length; attackNumber++)
        {
            bool visible = false;
            bool obvious = false;
            int damage = 0;
            AttackEffect? effect = Race.Attacks[attackNumber].Effect;
            Attack method = Race.Attacks[attackNumber].Method;
            int dDice = Race.Attacks[attackNumber].DDice;
            int dSide = Race.Attacks[attackNumber].DSide;
            // Can't attack ourselves
            if (target == this)
            {
                break;
            }
            // If the target has moved, abort
            if (target.MapX != xSaver || target.MapY != ySaver)
            {
                break;
            }
            // If we blinked away after stealing on a previous attack, abort
            if (blinked)
            {
                break;
            }
            if (IsVisible)
            {
                visible = true;
            }

            // If we hit the monster, describe the type of hit
            if (effect == null || CheckHitMonsterVersusMonster(effect.Power, monsterLevel, armorClass))
            {
                SaveGame.Disturb(true);
                if (method.AttackAwakensTarget)
                {
                    target.SleepLevel = 0;
                }

                // Display the attack description
                if (IsVisible || target.IsVisible)
                {
                    SaveGame.MsgPrint($"{monsterName} {method.MonsterAction(target)}.");
                }
                obvious = true;
                damage = this.SaveGame.DiceRoll(dDice, dSide);
                // Default to a missile attack
                Projectile pt = SaveGame.SingletonRepository.Projectiles.Get(nameof(MissileProjectile));
                // Choose the correct type of attack to display, as well as any other special
                // effects for the attack
                if (effect == null)
                {
                    damage = 0;
                    pt = null;
                }
                else
                    effect.ApplyToMonster(this, armorClass, ref damage, ref pt, ref blinked);

                // Implement the attack as a projectile
                if (pt != null)
                {
                    SaveGame.Project(GetMonsterIndex(), 0, target.MapY, target.MapX, damage, pt, ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                    // If we touched the target we might get burned or zapped
                    if (method.AttackTouchesTarget)
                    {
                        if (targetRace.FireAura && !Race.ImmuneFire)
                        {
                            if (IsVisible || target.IsVisible)
                            {
                                // Auras prevent us blinking away
                                blinked = false;
                                // The player may see and learn that the target has the aura
                                SaveGame.MsgPrint($"{monsterName} is suddenly very hot!");
                                if (target.IsVisible)
                                {
                                    targetRace.Knowledge.Characteristics.FireAura = true;
                                }
                            }
                            SaveGame.Project(targetIndex, 0, MapY, MapX, this.SaveGame.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)), SaveGame.SingletonRepository.Projectiles.Get(nameof(Projection.FireProjectile)), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                        }
                        if (targetRace.LightningAura && !Race.ImmuneLightning)
                        {
                            if (IsVisible || target.IsVisible)
                            {
                                // Auras prevent us blinking away
                                blinked = false;
                                // The player may see and learn that the target has the aura
                                SaveGame.MsgPrint($"{monsterName} gets zapped!");
                                if (target.IsVisible)
                                {
                                    targetRace.Knowledge.Characteristics.LightningAura = true;
                                }
                            }
                            SaveGame.Project(targetIndex, 0, MapY, MapX, this.SaveGame.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)),
                                SaveGame.SingletonRepository.Projectiles.Get(nameof(Projection.ElecProjectile)), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                        }
                    }
                }
            }
            else
            {
                // We didn't hit, so just let the player know that if we are visible
                if (method.AttackTouchesTarget && !method.RendersMissMessage && IsVisible)
                {
                    SaveGame.Disturb(false);
                    SaveGame.MsgPrint($"{monsterName} misses {target.Name}.");
                }
            }
            // If the player saw what happened, they know more abouyt what attacks we have
            if (visible)
            {
                if (obvious || damage != 0 || Race.Knowledge.RBlows[attackNumber] > 10)
                {
                    if (Race.Knowledge.RBlows[attackNumber] < Constants.MaxUchar)
                    {
                        Race.Knowledge.RBlows[attackNumber]++;
                    }
                }
            }
        }
        // If we stole and should therefore blink away, then do so.
        if (blinked)
        {
            SaveGame.MsgPrint(IsVisible ? "The thief flees laughing!" : "You hear laughter!");
            TeleportAway(SaveGame, (Constants.MaxSight * 2) + 5);
        }
        // We made the attack
        return true;
    }

    /// <summary>
    /// Choose and use an attack spell to cast when in combat with the player
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster </param>
    /// <returns> True if a spell was cast, false if not </returns>
    private bool TryCastingASpellAgainstPlayer()
    {
        bool noInnate = false;

        // No spells if we're confused
        if (ConfusionLevel != 0)
        {
            return false;
        }
        // No spells if we're being nice because we've just been summoned
        if ((IndividualMonsterFlags & Constants.MflagNice) != 0)
        {
            return false;
        }
        // No spells on the player if they're our friend
        if (SmFriendly)
        {
            return false;
        }
        // We aren't guaranteed to cast a spell even if we can
        int chance = Race.FrequencyChance;
        if (chance == 0)
        {
            return false;
        }
        if (SaveGame.RandomLessThan(100) >= chance)
        {
            return false;
        }

        // Innate abilities are inherently less likely than actual spells
        if (SaveGame.RandomLessThan(100) >= chance * 2)
        {
            noInnate = true;
        }

        // If we're too far from the player don't cast a spell
        if (DistanceFromPlayer > Constants.MaxRange)
        {
            return false;
        }

        // If we have no line of sight to the player, don't cast a spell
        if (!SaveGame.Projectable(MapY, MapX, SaveGame.MapY, SaveGame.MapX))
        {
            return false;
        }

        // Gather together the abilities we have
        int monsterLevel = Race.Level >= 1 ? Race.Level : 1;
        MonsterSpellList spells = Race.Spells;

        // If we're not allowed innate abilities, then things on Flags4 can't be used
        if (noInnate)
        {
            spells = spells.Remove((_spell) => _spell.IsInnate);
        }

        // If we're smart and badly injured, we may want to prioritise spells that disable the
        // player, summon help, or let us escape over spells that do direct damage
        if (Race.Smart && Health < MaxHealth / 10 && SaveGame.RandomLessThan(100) < 50)
        {

            spells = spells.Where((_spell) => _spell.IsIntelligent);

            // If we just got rid of all our spells then don't cast
            if (spells.Count == 0)
            {
                return false;
            }
        }

        // Ditch any spells that we've seen the player resist before so we know they'll be ineffective
        spells = RemoveIneffectiveSpells(SaveGame, spells);

        // If we just got rid of all our spells then don't cast
        if (spells.Count == 0)
        {
            return false;
        }

        // If we don't have a clean shot, and we're stupid, remove bolt spells
        if (spells.Contains((_spell) => _spell.CanBeReflected) && !Race.Stupid && !SaveGame.CleanShot(MapY, MapX, SaveGame.MapY, SaveGame.MapX))
        {
            spells = spells.Remove((_spell) => _spell.CanBeReflected);
        }

        // If there's nowhere around the player to put a summoned creature, then remove
        // summoning spells
        if (spells.Contains((_spell) => _spell.SummonsHelp) && !Race.Stupid && !SaveGame.SummonPossible(SaveGame.MapY, SaveGame.MapX))
        {
            spells = spells.Remove((_spell) => _spell.SummonsHelp);
        }

        // If we've removed all our spells, don't cast anything
        if (spells.Count == 0)
        {
            return false;
        }

        // If the player's already dead or off the saveGame.Level, don't cast
        if (!SaveGame.Playing || SaveGame.IsDead || SaveGame.NewLevelFlag)
        {
            return false;
        }
        string monsterName = Name;
        string monsterPossessive = PossessiveName;
        string monsterDescription = IndefiniteVisibleName;

        // Pick one of our spells to cast, based on our priorities
        MonsterSpell? thrownSpell = ChooseSpellAgainstPlayer(spells);

        // If we decided not to cast, don't
        if (thrownSpell == null)
        {
            return false;
        }

        // Stupid monsters may fail spells
        int failrate = 25 - ((monsterLevel + 3) / 4);
        if (Race.Stupid)
        {
            failrate = 0;
        }

        // Only check for actual spells - nothing is so stupid it fails to breathe
        if (!thrownSpell.UsesBreathe && SaveGame.RandomLessThan(100) < failrate)
        {
            SaveGame.MsgPrint($"{monsterName} tries to cast a spell, but fails.");
            return true;
        }

        // Any action on the player automatically disturbs the player.
        SaveGame.Disturb(true);

        // Render a message to the player.
        bool playerIsBlind = SaveGame.TimedBlindness.TurnsRemaining != 0;
        string? message = playerIsBlind ? thrownSpell.VsPlayerBlindMessage : thrownSpell.VsPlayerActionMessage(this);
        if (message != null)
        {
            SaveGame.MsgPrint(message);
        }

        // Execute the spell.
        thrownSpell.ExecuteOnPlayer(SaveGame, this);

        // Learn from the spell.
        foreach (SpellResistantDetection smartLearn in thrownSpell.SmartLearn)
        {
            SaveGame.UpdateSmartLearn(this, smartLearn);
        }

        // If the player saw us cast the spell, let them learn we can do that
        bool seenByPlayer = !playerIsBlind && IsVisible;
        if (seenByPlayer)
        {
            Race.Knowledge.RSpells.Add(thrownSpell);
            if (thrownSpell.IsInnate)
            {
                Race.Knowledge.RCastInate++;
            }
            else
            {
                Race.Knowledge.RCastSpell++;
            }
        }
        // If we killed the player, let their descendants remember that
        if (SaveGame.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
        {
            Race.Knowledge.RDeaths++;
        }
        // We did cast a spell
        return true;
    }

    /// <summary>
    /// Try to cast a spell on another monster
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster casting the spell </param>
    /// <returns> True if we cast a spell, false otherwise </returns>
    private bool TryCastingASpellAgainstAnotherMonster()
    {
        bool friendly = SmFriendly;

        // Can't cast a spell if we're confused
        if (ConfusionLevel != 0)
        {
            return false;
        }

        // We have a chance to cast a spell based on our race
        int chance = Race.FrequencyChance;
        if (chance == 0)
        {
            return false;
        }
        if (this.SaveGame.RandomLessThan(100) >= chance)
        {
            return false;
        }

        MonsterSpellList monsterSpells = Race.Spells;

        // Look through the monster list to find a potential target
        for (int i = 1; i < SaveGame.MMax; i++)
        {
            int targetIndex = i;
            Monster target = SaveGame.Monsters[targetIndex];
            MonsterRace targetRace = target.Race;

            // Can't cast spells on ourself
            if (target == this)
            {
                continue;
            }

            // Can't cast spells on empty monster slots
            if (target.Race == null)
            {
                continue;
            }

            // Don't cast spells on monsters from the same team
            if (SmFriendly == target.SmFriendly)
            {
                continue;
            }

            // If the target is too far away from the player, don't cast a spell
            if (target.DistanceFromPlayer > Constants.MaxRange)
            {
                continue;
            }

            // If we don't have line of sight to the target, don't cast a spell
            if (!SaveGame.Projectable(MapY, MapX, target.MapY, target.MapX))
            {
                continue;
            }

            // If we're smart and badly injured, we may want to prioritise spells that disable
            // the target, summon help, or let us escape over spells that do direct damage
            if (Race.Smart && Health < MaxHealth / 10 && this.SaveGame.RandomLessThan(100) < 50)
            {
                monsterSpells = monsterSpells.Where((MonsterSpell _monsterSpell) => _monsterSpell.IsIntelligent);

                // If we just got rid of all our spells then abort
                if (monsterSpells.Count == 0)
                {
                    return false;
                }
            }
            // If there's nowhere around the target to put a summoned creature, then remove
            // summoning spells
            if (monsterSpells.Contains((MonsterSpell _monsterSpell) => _monsterSpell.SummonsHelp) && !Race.Stupid && !SaveGame.SummonPossible(target.MapY, target.MapX))
            {
                monsterSpells = monsterSpells.Remove((MonsterSpell _monsterSpell) => _monsterSpell.SummonsHelp);
            }

            // If we've removed all our spells, don't cast anything
            if (monsterSpells.Count == 0)
            {
                return false;
            }

            // If the player's already dead or off the level, don't cast
            if (!SaveGame.Playing || SaveGame.IsDead || SaveGame.NewLevelFlag)
            {
                return false;
            }

            // Against other monsters we pick spells randomly
            MonsterSpell thrownSpell = Race.Spells.ToWeightedRandom(SaveGame).Choose();
            bool blind = SaveGame.TimedBlindness.TurnsRemaining != 0;
            bool seeTarget = !blind && target.IsVisible;
            bool seen = !blind && IsVisible;
            bool seeEither = seen || seeTarget;

            // If the player can see either monster, disturb the player.
            if (seeEither)
            {
                SaveGame.Disturb(true);
            }

            // Render a message to the player.
            string? message = !seeEither ? thrownSpell.VsMonsterUnseenMessage : thrownSpell.VsMonsterSeenMessage(this, target);
            if (message != null)
            {
                SaveGame.MsgPrint(message);
            }

            // Execute the action on the monster.
            thrownSpell.ExecuteOnMonster(SaveGame, this, target);

            // Spells will wake up the target if it's asleep
            if (thrownSpell.WakesSleepingMonsters)
            {
                target.SleepLevel = 0;
            }

            // If the player saw us cast the spell, let them learn we can do that
            if (seen)
            {
                Race.Knowledge.RSpells = Race.Knowledge.RSpells.Add(thrownSpell);

                // Check to see if the spell was an innate ability.
                if (thrownSpell.IsInnate)
                {
                    // Increase the innate ability cast count.
                    if (Race.Knowledge.RCastInate < Constants.MaxUchar) // TODO: The MaxUChar is wrong for an INT
                    {
                        Race.Knowledge.RCastInate++;
                    }

                }

                // Increase the counter for the number of spells casted.
                if (Race.Knowledge.RCastSpell < Constants.MaxUchar) // TODO: The MaxUChar is wrong for an INT
                {
                    Race.Knowledge.RCastSpell++;
                }
            }
            // If we killed the player, let their descendants remember that
            if (SaveGame.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
            {
                Race.Knowledge.RDeaths++;
            }
            // We did cast a spell
            return true;
        }
        return false;
    }

    /// <summary>
    /// Use a breath weapon on another monster
    /// </summary>
    /// <param name="monsterIndex"> The monster doing the breathing </param>
    /// <param name="targetY"> The y coordinate of the target </param>
    /// <param name="targetX"> The x coordinate of the target </param>
    /// <param name="projectile"> The type of breath being used </param>
    /// <param name="damage"> The damage the breath will do </param>
    /// <param name="radius"> The radius of the attack, or zero for the default radius </param>
    public void BreatheAtMonster(SaveGame saveGame, int targetY, int targetX, Projectile projectile, int damage, int radius)
    {
        const ProjectionFlag projectionFlags = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
        // Radius 0 means use the default radius
        if (radius < 1)
        {
            radius = Race.Powerful ? 3 : 2;
        }
        // Make the radius negative to indicate we need a cone instead of a ball
        radius = 0 - radius;
        saveGame.Project(GetMonsterIndex(), radius, targetY, targetX, damage, projectile, projectionFlags);
    }

    /// <summary>
    /// Fire some kind of ball attack at the player
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster firing the attack </param>
    /// <param name="projectile"> The type of effect the ball has </param>
    /// <param name="damage"> The damage done by the ball </param>
    /// <param name="radius"> The radius of the ball, or zero to use the default radius </param>
    public void FireBallAtPlayer(SaveGame saveGame, Projectile projectile, int damage, int radius)
    {
        const ProjectionFlag projectionFlag = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
        if (radius < 1)
        {
            radius = Race.Powerful ? 3 : 2;
        }
        saveGame.Project(GetMonsterIndex(), radius, saveGame.MapY, saveGame.MapX, damage, projectile, projectionFlag);
    }

    /// <summary>
    /// Breathe on the player
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster doing the breathing </param>
    /// <param name="projectile"> The projectile that is being breathed </param>
    /// <param name="damage"> The damage done by the breath </param>
    /// <param name="radius">
    /// The (positive) radius of the breath weapon, or zero for the default radius
    /// </param>
    public void BreatheAtPlayer(SaveGame saveGame, Projectile projectile, int damage, int radius)
    {
        const ProjectionFlag projectionFlags = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
        // Radius 0 means use the default radius
        if (radius < 1)
        {
            radius = Race.Powerful ? 3 : 2;
        }
        // Make the radius negative to indicate we need a cone instead of a ball
        radius = 0 - radius;
        saveGame.Project(GetMonsterIndex(), radius, saveGame.MapY, saveGame.MapX, damage, projectile, projectionFlags);
    }

    /// <summary>
    /// Fire a bolt of some kind at another monster
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster doing the firing </param>
    /// <param name="targetY"> The y coordinate of the target </param>
    /// <param name="targetX"> The x coordinate of the target </param>
    /// <param name="projectile"> The projectile to be fired </param>
    /// <param name="damage"> The damage the projectile should do </param>
    public void FireBoltAtMonster(SaveGame saveGame, int targetY, int targetX, Projectile projectile, int damage)
    {
        const ProjectionFlag projectionFlags = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
        saveGame.Project(GetMonsterIndex(), 0, targetY, targetX, damage, projectile, projectionFlags);
    }

    /// <summary>
    /// Take damage after being hit by another monster
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster taking the damage </param>
    /// <param name="damage"> The damage taken </param>
    /// <param name="fear"> Whether the damage makes us afraid </param>
    /// <param name="note"> A special descriptive note that replaces the normal death message </param>
    public void TakeDamageFromAnotherMonster(SaveGame saveGame, int damage, out bool fear, string note)
    {
        fear = false;
        // Track the monster that has just taken damage
        if (saveGame.TrackedMonsterIndex == GetMonsterIndex())
        {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawHealthFlaggedAction)).Set();
        }
        SleepLevel = 0;
        // Take the damage
        Health -= damage;
        // Did it kill us?
        if (Health < 0)
        {
            // Uniques and guardians can never be killed by other monsters
            if (Race.Unique || Race.Guardian)
            {
                Health = 1;
            }
            else
            {
                // Construct a message telling the player what happened
                string monsterName = Name;
                saveGame.PlaySound(SoundEffectEnum.MonsterDies);
                // Append the note if there is one
                if (!string.IsNullOrEmpty(note))
                {
                    saveGame.MsgPrint(monsterName + note);
                }
                // Don't tell the player if the monster is not visible
                else if (!IsVisible)
                {
                }
                // Some non-living things are destroyed rather than dying
                else if (Race.Demon || Race.Undead ||
                         Race.Cthuloid || Race.Stupid ||
                         Race.Nonliving || "Evg".Contains(Race.Symbol.Character.ToString()))
                {
                    saveGame.MsgPrint($"{monsterName} is destroyed.");
                }
                else
                {
                    saveGame.MsgPrint($"{monsterName} is killed.");
                }
                // Let the save game know we've died
                saveGame.MonsterDeath(GetMonsterIndex());
                // Delete us from the monster list
                saveGame.DeleteMonsterByIndex(GetMonsterIndex(), true);
                fear = false;
                return;
            }
        }
        // Assuming we survived, check if the attack made us afraid
        if (FearLevel != 0 && damage > 0)
        {
            // If we're already afraid, we might get desperate and overcome our fear
            int tmp = SaveGame.DieRoll(damage);
            if (tmp < FearLevel)
            {
                FearLevel -= tmp;
            }
            else
            {
                FearLevel = 0;
                fear = false;
            }
        }
        // If we weren't already afraid, this attack might make us afraid
        if (FearLevel == 0 && !Race.ImmuneFear)
        {
            int percentage = 100 * Health / MaxHealth;
            if ((percentage <= 10 && SaveGame.RandomLessThan(10) < percentage) || (damage >= Health && SaveGame.RandomLessThan(100) < 80))
            {
                fear = true;
                FearLevel = SaveGame.DieRoll(10) + (damage >= Health && percentage > 7 ? 20 : (11 - percentage) * 5);
            }
        }
    }

    /// <summary>
    /// Cast a bolt spell at the player
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster casting the bolt </param>
    /// <param name="projectile"> The projectile being used for the bolt </param>
    /// <param name="damage"> The damage that the bolt will do </param>
    public void FireBoltAtPlayer(Projectile projectile, int damage)
    {
        const ProjectionFlag projectionFlags = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
        SaveGame.Project(GetMonsterIndex(), 0, SaveGame.MapY, SaveGame.MapX, damage, projectile, projectionFlags);
    }

    /// <summary>
    /// Forget what the monster has seen, clearing all smart flags except for ally and clone
    /// </summary>
    public void ForgetSmartness()
    {
        SmImmAcid = false;
        SmImmCold = false;
        SmImmElec = false;
        SmImmFire = false;
        SmImmFree = false;
        SmImmMana = false;
        SmImmReflect = false;
        SmImmXxx5 = false;
        SmOppAcid = false;
        SmOppCold = false;
        SmOppElec = false;
        SmOppFire = false;
        SmOppPois = false;
        SmOppXXx1 = false;
        SmResAcid = false;
        SmResBlind = false;
        SmResChaos = false;
        SmResCold = false;
        SmResConf = false;
        SmResDark = false;
        SmResDisen = false;
        SmResElec = false;
        SmResFear = false;
        SmResFire = false;
        SmResLight = false;
        SmResNeth = false;
        SmResNexus = false;
        SmResPois = false;
        SmResShard = false;
        SmResSound = false;
    }

    /// <summary>
    /// Remove flags for ineffective spells from the monster's flags and return them.
    /// </summary>
    private MonsterSpellList RemoveIneffectiveSpells(SaveGame saveGame, MonsterSpellList spells)
    {
        // If we're stupid, we won't realise how ineffective things are
        if (Race.Stupid)
        {
            return spells;
        }

        // Tiny chance of forgetting what we've seen, clearing all smart flags except for ally and clone
        if (SaveGame.RandomLessThan(100) < 1)
        {
            ForgetSmartness();
        }

        // If we know the player is immune to acid, don't do acid spells
        if (SmImmAcid)
        {
            spells = spells.Remove((_spell) => _spell.UsesAcid && RealiseSpellIsUseless(100));
        }

        // If we know the player resists acid both temporarily and permanently, probably don't
        // do acid spells
        else if (SmOppAcid && SmResAcid)
        {
            spells = spells.Remove((_spell) => _spell.UsesAcid && RealiseSpellIsUseless(80));
        }

        // If we know the player resists acid at all, maybe don't do acid spells
        else if (SmOppAcid || SmResAcid)
        {
            spells = spells.Remove((_spell) => _spell.UsesAcid && RealiseSpellIsUseless(30));
        }

        // If we know the player is immune to lightning, don't do lightning spells
        if (SmImmElec)
        {
            spells = spells.Remove((_spell) => _spell.UsesLightning && RealiseSpellIsUseless(100));
        }

        // If we know the player resists lightning both temporarily and permanently, probably
        // don't do lightning spells
        else if (SmOppElec && SmResElec)
        {
            spells = spells.Remove((_spell) => _spell.UsesLightning && RealiseSpellIsUseless(80));
        }

        // If we know the player resists lightning at all, maybe don't do lightning spells
        else if (SmOppElec || SmResElec)
        {
            spells = spells.Remove((_spell) => _spell.UsesLightning && RealiseSpellIsUseless(30));
        }

        // If we know the player is immune to fire, don't do fire spells
        if (SmImmFire)
        {
            spells = spells.Remove((_spell) => _spell.UsesFire && RealiseSpellIsUseless(100));
        }

        // If we know the player resists fire both temporarily and permanently, probably don't
        // do fire spells
        else if (SmOppFire && SmResFire)
        {
            spells = spells.Remove((_spell) => _spell.UsesFire && RealiseSpellIsUseless(80));
        }

        // If we know the player resists fire at all, maybe don't do fire spells
        else if (SmOppFire || SmResFire)
        {
            spells = spells.Remove((_spell) => _spell.UsesFire && RealiseSpellIsUseless(30));
        }

        // If we know the player is immune to cold, don't do fire spells
        if (SmImmCold)
        {
            spells = spells.Remove((_spell) => _spell.UsesCold && RealiseSpellIsUseless(100));
        }

        // If we know the player resists cold both temporarily and permanently, probably don't do cold spells
        else if (SmOppCold && SmResCold)
        {
            spells = spells.Remove((_spell) => _spell.UsesCold && RealiseSpellIsUseless(80));
        }

        // If we know the player resists cold at all, maybe don't do cold spells
        else if (SmOppCold || SmResCold)
        {
            spells = spells.Remove((_spell) => _spell.UsesCold && RealiseSpellIsUseless(30));
        }

        // If we know the player resists poison both temporarily and permanently, probably don't
        // do poison spells
        if (SmOppPois && SmResPois)
        {
            spells = spells.Remove((_spell) => _spell.UsesPoison && RealiseSpellIsUseless(80));
            spells = spells.Remove((_spell) => _spell.UsesRadiation && RealiseSpellIsUseless(40));
        }

        // If we know the player resists poison at all, maybe don't do cold spells
        else if (SmOppPois || SmResPois)
        {
            spells = spells.Remove((_spell) => _spell.UsesPoison && RealiseSpellIsUseless(30));
        }

        // If we know the player resists nether, maybe don't do nether spells
        if (SmResNeth)
        {
            spells = spells.Remove((_spell) => _spell.UsesPoison && RealiseSpellIsUseless(50));
        }

        // If we know the player resists light, maybe don't do light spells
        if (SmResLight)
        {
            spells = spells.Remove((_spell) => _spell.UsesLight && RealiseSpellIsUseless(50));
        }

        // If we know the player resists darkness, maybe don't do darkness spells
        if (SmResDark)
        {
            spells = spells.Remove((_spell) => _spell.UsesDarkness && RealiseSpellIsUseless(50));
        }

        // If we know the player resists fear, don't do fear spells
        if (SmResFear)
        {
            spells = spells.Remove((_spell) => _spell.UsesFear && RealiseSpellIsUseless(100));
        }

        // If we know the player resists confiusion, maybe don't do confusion spells
        if (SmResConf)
        {
            spells = spells.Remove((_spell) => _spell.UsesConfusion && RealiseSpellIsUseless(_spell.UsesBreathe ? 50 : 100));
        }

        // If we know the player resists chaos, maybe don't do chaos or confusion spells
        if (SmResChaos)
        {
            spells = spells.Remove((_spell) => _spell.UsesConfusion && RealiseSpellIsUseless(_spell.UsesBreathe ? 50 : 100));
            spells = spells.Remove((_spell) => _spell.UsesChaos && RealiseSpellIsUseless(50));
        }

        // If we know the player resists disenchantment, don't do disenchantment spells
        if (SmResDisen)
        {
            spells = spells.Remove((_spell) => _spell.UsesDisenchantment && RealiseSpellIsUseless(100));
        }

        // If we know the player resists blindness, don't do blindness spells
        if (SmResBlind)
        {
            spells = spells.Remove((_spell) => _spell.UsesBlindness && RealiseSpellIsUseless(100));
        }

        // If we know the player resists nexus, maybe don't do nexus or teleport spells
        if (SmResNexus)
        {
            spells = spells.Remove((_spell) => _spell.UsesNexus && RealiseSpellIsUseless(50));
        }

        // If we know the player resists sound, maybe don't do sound spells
        if (SmResSound)
        {
            spells = spells.Remove((_spell) => _spell.UsesSound && RealiseSpellIsUseless(50));
        }

        // If we know the player resists shards, maybe don't do shard spells
        if (SmResShard)
        {
            spells = spells.Remove((_spell) => _spell.UsesShards && RealiseSpellIsUseless(_spell.UsesBreathe ? 50 : 20));
        }

        // If we know the player reflects bolts, don't do bolt spells
        if (SmImmReflect)
        {
            spells = spells.Remove((_spell) => _spell.CanBeReflected && RealiseSpellIsUseless(100));
        }

        // If we know the player has free action, don't do slow or hold spells
        if (SmImmFree)
        {
            spells = spells.Remove((_spell) => _spell.RestrictsFreeAction && RealiseSpellIsUseless(100));
        }

        // If we know the player has no mana, don't do mana drain
        if (SmImmMana)
        {
            spells = spells.Remove((_spell) => _spell.DrainsMana && RealiseSpellIsUseless(100));
        }
        return spells;
    }

    /// <summary>
    /// Roll a percentage change of a monster realising it shouldn't do something because the
    /// player resisted it last time. Monsters that are not smart have half the passed chance.
    /// </summary>
    /// <param name="race"> The monster's race </param>
    /// <param name="percentage"> The chance of it happening </param>
    /// <returns> True if it should happen, or false if it should not </returns>
    private bool RealiseSpellIsUseless(int percentage)
    {
        if (!Race.Smart)
        {
            percentage /= 2;
        }
        return SaveGame.RandomLessThan(100) < percentage;
    }

    /// <summary>
    /// Populate a list with possible moves towards the player. Note that we won't always move
    /// directly towards the player, based on factors such as if we're in a group in a room or
    /// if we're afraid of the player.
    /// </summary>
    /// <param name="monsterIndex"> the index of the monster who is moving </param>
    /// <param name="movesList"> The list to be populated with moves </param>
    /// <returns> True if we have potential moves or false if we don't </returns>
    private bool GetMovesTowardsPlayer(SaveGame saveGame, PotentialMovesList movesList)
    {
        int moveVal = 0;
        bool done = false;
        // Default to moving towards the player's exact location
        GridCoordinate targetLocation = new GridCoordinate(saveGame.MapX, saveGame.MapY);
        // Adjust our target based on the player's scent if we can't move in a straight line to them
        TrackPlayerByScent(saveGame, targetLocation);
        // Get the relative move needed to reach our target location
        GridCoordinate desiredRelativeMovement = new GridCoordinate(MapX - targetLocation.X, MapY - targetLocation.Y);
        if (!SmFriendly)
        {
            // If we're a pack animal that can't go through walls
            if (Race.Friends && Race.Animal &&
                !Race.PassWall && !Race.KillWall)
            {
                int room = 0;
                // Check if the player is in a room by counting the room tiles around them
                for (int i = 0; i < 8; i++)
                {
                    if (saveGame.Grid[saveGame.MapY + saveGame.OrderedDirectionYOffset[i]][saveGame.MapX + saveGame.OrderedDirectionXOffset[i]].TileFlags.IsSet(GridTile.InRoom))
                    {
                        room++;
                    }
                }
                // If the player isn't in a room and they're healthy, wait to ambush them rather
                // than running headlong into the corridor after them and queueing up to get hit
                if (room < 8 && saveGame.Health > saveGame.MaxHealth * 3 / 4)
                {
                    if (FindAmbushSpot(saveGame, desiredRelativeMovement))
                    {
                        done = true;
                    }
                }
            }
            // If we're not done and we have friends make our movement slightly depend on our
            // index so we spread out and don't block each other
            if (!done && Race.Friends)
            {
                for (int i = 0; i < 8; i++)
                {
                    int monsterIndex = GetMonsterIndex();
                    targetLocation = new GridCoordinate(saveGame.MapX + saveGame.OrderedDirectionXOffset[(monsterIndex + i) & 7], saveGame.MapY + saveGame.OrderedDirectionYOffset[(monsterIndex + i) & 7]);
                    // We might have got a '5' meaning stay where we are, so replace that with
                    // moving towards the player
                    if (MapY == targetLocation.Y && MapX == targetLocation.X)
                    {
                        targetLocation = new GridCoordinate(saveGame.MapX, saveGame.MapY);
                        break;
                    }
                    // Repeat till we get a direction we can move in
                    if (!saveGame.GridPassableNoCreature(targetLocation.Y, targetLocation.X))
                    {
                        continue;
                    }
                    break;
                }
                desiredRelativeMovement = new GridCoordinate(MapX - targetLocation.X, MapY - targetLocation.Y);
                done = true;
            }
        }
        // If we're an ally then check if we should retreat
        if (SmFriendly)
        {
            if (MonsterShouldRetreat(saveGame))
            {
                // If we should be scared, simply move the opposite way to the player
                desiredRelativeMovement = new GridCoordinate(-desiredRelativeMovement.X, - desiredRelativeMovement.Y);
            }
        }
        else
        {
            // If we're not an ally then check if we should retreat
            if (!done && MonsterShouldRetreat(saveGame))
            {
                // If we should retreat, then try to find a safe spot where the player can't
                // shoot or see us
                if (!FindSafeSpot(saveGame, desiredRelativeMovement))
                {
                    // If we failed to find one, just back off
                    desiredRelativeMovement = new GridCoordinate(-desiredRelativeMovement.X, -desiredRelativeMovement.Y);
                }
                else
                {
                    // We found a safe spot, so head there, but prioritise avoiding the player's scent
                    AvoidPlayersScent(saveGame, desiredRelativeMovement);
                }
            }
        }
        // If our best move is to stand still, don't move
        if (desiredRelativeMovement.X == 0 && desiredRelativeMovement.Y == 0)
        {
            return false;
        }
        // Convert the target location to an actual direction
        int ax = Math.Abs(desiredRelativeMovement.X);
        int ay = Math.Abs(desiredRelativeMovement.Y);
        if (desiredRelativeMovement.Y < 0)
        {
            moveVal += 8;
        }
        if (desiredRelativeMovement.X > 0)
        {
            moveVal += 4;
        }
        if (ay > ax << 1)
        {
            moveVal++;
            moveVal++;
        }
        else if (ax > ay << 1)
        {
            moveVal++;
        }
        // Add some potential moves to the list based on the direction we've decided to go in
        switch (moveVal)
        {
            case 0:
                movesList[0] = 9;
                if (ay > ax)
                {
                    movesList[1] = 8;
                    movesList[2] = 6;
                    movesList[3] = 7;
                    movesList[4] = 3;
                }
                else
                {
                    movesList[1] = 6;
                    movesList[2] = 8;
                    movesList[3] = 3;
                    movesList[4] = 7;
                }
                break;

            case 1:
            case 9:
                movesList[0] = 6;
                if (desiredRelativeMovement.Y < 0)
                {
                    movesList[1] = 3;
                    movesList[2] = 9;
                    movesList[3] = 2;
                    movesList[4] = 8;
                }
                else
                {
                    movesList[1] = 9;
                    movesList[2] = 3;
                    movesList[3] = 8;
                    movesList[4] = 2;
                }
                break;

            case 2:
            case 6:
                movesList[0] = 8;
                if (desiredRelativeMovement.X < 0)
                {
                    movesList[1] = 9;
                    movesList[2] = 7;
                    movesList[3] = 6;
                    movesList[4] = 4;
                }
                else
                {
                    movesList[1] = 7;
                    movesList[2] = 9;
                    movesList[3] = 4;
                    movesList[4] = 6;
                }
                break;

            case 4:
                movesList[0] = 7;
                if (ay > ax)
                {
                    movesList[1] = 8;
                    movesList[2] = 4;
                    movesList[3] = 9;
                    movesList[4] = 1;
                }
                else
                {
                    movesList[1] = 4;
                    movesList[2] = 8;
                    movesList[3] = 1;
                    movesList[4] = 9;
                }
                break;

            case 5:
            case 13:
                movesList[0] = 4;
                if (desiredRelativeMovement.Y < 0)
                {
                    movesList[1] = 1;
                    movesList[2] = 7;
                    movesList[3] = 2;
                    movesList[4] = 8;
                }
                else
                {
                    movesList[1] = 7;
                    movesList[2] = 1;
                    movesList[3] = 8;
                    movesList[4] = 2;
                }
                break;

            case 8:
                movesList[0] = 3;
                if (ay > ax)
                {
                    movesList[1] = 2;
                    movesList[2] = 6;
                    movesList[3] = 1;
                    movesList[4] = 9;
                }
                else
                {
                    movesList[1] = 6;
                    movesList[2] = 2;
                    movesList[3] = 9;
                    movesList[4] = 1;
                }
                break;

            case 10:
            case 14:
                movesList[0] = 2;
                if (desiredRelativeMovement.X < 0)
                {
                    movesList[1] = 3;
                    movesList[2] = 1;
                    movesList[3] = 6;
                    movesList[4] = 4;
                }
                else
                {
                    movesList[1] = 1;
                    movesList[2] = 3;
                    movesList[3] = 4;
                    movesList[4] = 6;
                }
                break;

            case 12:
                movesList[0] = 1;
                if (ay > ax)
                {
                    movesList[1] = 2;
                    movesList[2] = 4;
                    movesList[3] = 3;
                    movesList[4] = 7;
                }
                else
                {
                    movesList[1] = 4;
                    movesList[2] = 2;
                    movesList[3] = 7;
                    movesList[4] = 3;
                }
                break;
        }
        return true;
    }

    /// <summary>
    /// Modify a monster's move away from the player based on where their scent is coming from
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster </param>
    /// <param name="coord"> The location we're moving to </param>
    private void AvoidPlayersScent(SaveGame saveGame, GridCoordinate coord)
    {
        int monsterY = MapY;
        int monsterX = MapX;
        int dY = monsterY - coord.Y;
        int dX = monsterX - coord.X;
        // If the scent too strong, keep going where we were going
        if (saveGame.Grid[monsterY][monsterX].ScentAge < saveGame.Grid[saveGame.MapY][saveGame.MapX].ScentAge)
        {
            return;
        }
        if (saveGame.Grid[monsterY][monsterX].ScentStrength > Constants.MonsterFlowDepth)
        {
            return;
        }
        if (saveGame.Grid[monsterY][monsterX].ScentStrength > Race.NoticeRange)
        {
            return;
        }
        int gy = 0;
        int gx = 0;
        int when = 0;
        int score = -1;
        // Check each of the eight directions
        for (int i = 7; i >= 0; i--)
        {
            int y = monsterY + saveGame.OrderedDirectionYOffset[i];
            int x = monsterX + saveGame.OrderedDirectionXOffset[i];
            // If we have no scent there, or the scent is too recent, ignore it
            if (saveGame.Grid[y][x].ScentAge == 0)
            {
                continue;
            }
            if (saveGame.Grid[y][x].ScentAge < when)
            {
                continue;
            }
            // If the scent is weaker than in the other directions, go that way
            int dis = saveGame.Distance(y, x, dY, dX);
            int s = (5000 / (dis + 3)) - (500 / (saveGame.Grid[y][x].ScentStrength + 1));
            if (s < 0)
            {
                s = 0;
            }
            if (s < score)
            {
                continue;
            }
            when = saveGame.Grid[y][x].ScentAge;
            score = s;
            gy = y;
            gx = x;
        }
        // If we didn't find any scent at all, keep going the way we were going
        if (when == 0)
        {
            return;
        }
        // Go towards the weakest scent
        coord = new GridCoordinate(monsterX - gx, monsterY - gy);
    }

    /// <summary>
    /// Adjust the coordinates we're trying to move to if we can't get directly there for some reason
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster trying to move </param>
    /// <param name="target"> The target location we're moving to </param>
    private void TrackPlayerByScent(SaveGame saveGame, GridCoordinate target)
    {
        // If we can move through walls then we don't need to adjust anything
        if (Race.PassWall)
        {
            return;
        }
        if (Race.KillWall)
        {
            return;
        }
        int y1 = MapY;
        int x1 = MapX;
        GridTile cPtr = saveGame.Grid[y1][x1];
        // If we have no scent of the player then don't change where we were going
        if (cPtr.ScentAge < saveGame.Grid[saveGame.MapY][saveGame.MapX].ScentAge)
        {
            if (cPtr.ScentAge == 0)
            {
                return;
            }
        }
        if (cPtr.ScentStrength > Constants.MonsterFlowDepth)
        {
            return;
        }
        if (cPtr.ScentStrength > Race.NoticeRange)
        {
            return;
        }
        // If we can actually see the player then don't change where we are going
        if (saveGame.PlayerHasLosBold(y1, x1))
        {
            return;
        }
        int when = 0;
        int cost = 999;
        // Check the eight directions we can move to see which has the most recent or strongest scent
        for (int i = 7; i >= 0; i--)
        {
            int y = y1 + saveGame.OrderedDirectionYOffset[i];
            int x = x1 + saveGame.OrderedDirectionXOffset[i];
            if (saveGame.Grid[y][x].ScentAge == 0)
            {
                continue;
            }
            if (saveGame.Grid[y][x].ScentAge < when)
            {
                continue;
            }
            if (saveGame.Grid[y][x].ScentStrength > cost)
            {
                continue;
            }
            when = saveGame.Grid[y][x].ScentAge;
            cost = saveGame.Grid[y][x].ScentStrength;
            // Give us a target in the general direction of the strongest scent
            target = new GridCoordinate(saveGame.MapX + (16 * saveGame.OrderedDirectionXOffset[i]), saveGame.MapY + (16 * saveGame.OrderedDirectionYOffset[i]));
        }
    }

    /// <summary>
    /// Try to find a position where the player can't see you from which to ambush them
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster that is trying to hide </param>
    /// <param name="relativeTarget">
    /// A map location, which will be amended to contain the hiding spot
    /// </param>
    /// <returns> True if a hiding spot was found, or false if it wasn't </returns>
    private bool FindAmbushSpot(SaveGame saveGame, GridCoordinate relativeTarget)
    {
        int fy = MapY;
        int fx = MapX;
        int hidingSpotY = 0;
        int hidingSpotX = 0;
        int shortestDistance = 999;
        int tooCloseToPlayer = (saveGame.Distance(saveGame.MapY, saveGame.MapX, fy, fx) * 3 / 4) + 2;
        // Start with a short search radius and slowly increase
        for (int d = 1; d < 10; d++)
        {
            int y;
            for (y = fy - d; y <= fy + d; y++)
            {
                int x;
                for (x = fx - d; x <= fx + d; x++)
                {
                    // Make sure the spot is valid
                    if (!saveGame.InBounds(y, x))
                    {
                        continue;
                    }
                    if (!saveGame.GridPassable(y, x))
                    {
                        continue;
                    }
                    // Make sure the spot is the right distance
                    if (saveGame.Distance(y, x, fy, fx) != d)
                    {
                        continue;
                    }
                    // Make sure the spot is actually hidden
                    if (!saveGame.PlayerCanSeeBold(y, x) && saveGame.CleanShot(fy, fx, y, x))
                    {
                        // If the spot is closer to the player than any previously found spot
                        // (but not too close), remember it
                        int dis = saveGame.Distance(y, x, saveGame.MapY, saveGame.MapX);
                        if (dis < shortestDistance && dis >= tooCloseToPlayer)
                        {
                            hidingSpotY = y;
                            hidingSpotX = x;
                            shortestDistance = dis;
                        }
                    }
                }
            }
            // If we found at least one spot, return true with the coordinates
            if (shortestDistance < 999)
            {
                relativeTarget = new GridCoordinate(fx - hidingSpotX, fy - hidingSpotY);
                return true;
            }
        }
        // We didn't find a spot
        return false;
    }

    /// <summary>
    /// Check if a monster will decide to run away from the player. Note that this doesn't
    /// decide whether the monster should become scared, only whether or not it will move away
    /// (if it is scared this is likely)
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster </param>
    /// <returns> True if the monster should run away, false if not </returns>
    private bool MonsterShouldRetreat(SaveGame saveGame)
    {
        // Don't move away if we're already too far away to see the player
        if (DistanceFromPlayer > Constants.MaxSight + 5)
        {
            return false;
        }
        // If we're the player's friend then don't move away from them
        if (SmFriendly)
        {
            return false;
        }
        // If we're scared then definitely move away
        if (FearLevel != 0)
        {
            return true;
        }
        // If we're very close, stay close for potential melee
        if (DistanceFromPlayer <= 5)
        {
            return false;
        }
        int playerLevel = saveGame.ExperienceLevel;
        int monsterLevel = Race.Level + (GetMonsterIndex() & 0x08) + 25;
        // If we're tougher than the player, don't move away
        if (monsterLevel > playerLevel + 4)
        {
            return false;
        }
        // If we're significantly weaker than the player, move away
        if (monsterLevel + 4 <= playerLevel)
        {
            return true;
        }
        // If we're significantly less healthy than the player, move away
        int playerHealth = saveGame.Health;
        int playerMaxHealth = saveGame.MaxHealth;
        int monsterHealth = Health;
        int monsterMaxHealth = MaxHealth;
        int playerHealthFactor = (playerLevel * playerMaxHealth) + (playerHealth << 2);
        int monsterHealthFactor = (monsterLevel * monsterMaxHealth) + (monsterHealth << 2);
        return playerHealthFactor * monsterMaxHealth > monsterHealthFactor * playerMaxHealth;
    }

    /// <summary>
    /// Returns the index of this monster in the monster list.  This method is provided for backwards compatability and should NOT be used.  Will be deleted when no longer needed.
    /// </summary>
    public int GetMonsterIndex() // TODO: Needs to be removed.
    {
        for (int i = 0; i < SaveGame.Monsters.Length; i++)
        {
            if (SaveGame.Monsters[i] == this)
                return i;
        }
        throw new Exception("Internal error monster not found for get monster index.");
    }

    /// <summary>
    /// Have a monster make an attack on the player
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster making the attack </param>
    public void MonsterAttackPlayer()
    {
        int attackNumber;
        bool touched = false;
        bool fear = false;
        bool alive = true;
        // If the monster never attacks, then it shouldn't be attacking us now
        if (Race.NeverAttack)
        {
            return;
        }
        // Friends don't hit friends
        if (SmFriendly)
        {
            return;
        }

        int armorClass = SaveGame.BaseArmorClass + SaveGame.ArmorClassBonus;
        int monsterLevel = Race.Level >= 1 ? Race.Level : 1;
        string monsterName = Name;
        string monsterDescription = IndefiniteVisibleName;
        bool blinked = false;
        // Monsters get up to four attacks
        for (attackNumber = 0; attackNumber < Race.Attacks.Length; attackNumber++)
        {
            bool visible = false;
            bool obvious = false;
            int power = 0;
            int damage = 0;
            AttackEffect? effect = Race.Attacks[attackNumber].Effect;
            Attack method = Race.Attacks[attackNumber].Method;
            int damageDice = Race.Attacks[attackNumber].DDice;
            int damageSides = Race.Attacks[attackNumber].DSide;

            // Stop if player is dead or gone
            if (!alive || SaveGame.IsDead || SaveGame.NewLevelFlag)
            {
                break;
            }
            if (IsVisible)
            {
                visible = true;
            }
            // Get the basic attack power from the attack type
            if (effect != null)
            {
                power = effect.Power;
            }
                
            // Check if the monster actually hits us
            if (effect == null || MonsterCheckHitOnPlayer(this.SaveGame, power, monsterLevel))
            {
                SaveGame.Disturb(true);
                // Protection From Evil might repel the attack
                if (SaveGame.TimedProtectionFromEvil.TurnsRemaining > 0 && Race.Evil && SaveGame.ExperienceLevel >= monsterLevel && this.SaveGame.RandomLessThan(100) + SaveGame.ExperienceLevel > 50)
                {
                    if (IsVisible)
                    {
                        // If it does, then they player knows the monster is evil
                        Race.Knowledge.Characteristics.Evil = true;
                    }
                    SaveGame.MsgPrint($"{monsterName} is repelled.");
                    continue;
                }

                // Print the message
                string action = method.PlayerAction;
                if (!string.IsNullOrEmpty(action))
                {
                    SaveGame.MsgPrint($"{monsterName} {action}.");
                }
                obvious = true;
                // Work out base damage done by the attack
                damage = this.SaveGame.DiceRoll(damageDice, damageSides);
                // Apply any modifiers to the damage
                if (effect == null)
                {
                    obvious = true;
                    damage = 0;
                }
                else
                {
                    effect.ApplyToPlayer(monsterLevel, GetMonsterIndex(), armorClass, monsterDescription, this, ref obvious, ref damage, ref blinked);
                }

                // Be nice and don't let us be both stunned and cut by the same blow
                bool doCut = method.AttackCutsTarget;
                bool doStun = method.AttackStunsTarget;
                if (doCut && doStun)
                {
                    if (this.SaveGame.RandomLessThan(100) < 50)
                    {
                        doCut = false;
                    }
                    else
                    {
                        doStun = false;
                    }
                }
                int critLevel;
                if (doCut)
                {
                    // Get how bad the hit was based on the actual damage out of the possible damage
                    critLevel = MonsterCritical(damageDice, damageSides, damage);
                    int k;
                    switch (critLevel)
                    {
                        case 0:
                            k = 0;
                            break;

                        case 1:
                            k = this.SaveGame.DieRoll(5);
                            break;

                        case 2:
                            k = this.SaveGame.DieRoll(5) + 5;
                            break;

                        case 3:
                            k = this.SaveGame.DieRoll(20) + 20;
                            break;

                        case 4:
                            k = this.SaveGame.DieRoll(50) + 50;
                            break;

                        case 5:
                            k = this.SaveGame.DieRoll(100) + 100;
                            break;

                        case 6:
                            k = 300;
                            break;

                        default:
                            k = 500;
                            break;
                    }
                    if (k != 0)
                    {
                        SaveGame.TimedBleeding.AddTimer(k);
                    }
                }
                if (doStun)
                {
                    // Get how bad the hit was based on the actual damage out of the possible damage
                    critLevel = MonsterCritical(damageDice, damageSides, damage);
                    int k;
                    switch (critLevel)
                    {
                        case 0:
                            k = 0;
                            break;

                        case 1:
                            k = this.SaveGame.DieRoll(5);
                            break;

                        case 2:
                            k = this.SaveGame.DieRoll(10) + 10;
                            break;

                        case 3:
                            k = this.SaveGame.DieRoll(20) + 20;
                            break;

                        case 4:
                            k = this.SaveGame.DieRoll(30) + 30;
                            break;

                        case 5:
                            k = this.SaveGame.DieRoll(40) + 40;
                            break;

                        case 6:
                            k = 100;
                            break;

                        default:
                            k = 200;
                            break;
                    }
                    if (k != 0)
                    {
                        SaveGame.TimedStun.AddTimer(k);
                    }
                }
                // If the monster touched us then it may take damage from our defensive abilities
                if (touched)
                {
                    if (SaveGame.HasFireShield && alive)
                    {
                        if (!Race.ImmuneFire)
                        {
                            SaveGame.MsgPrint($"{monsterName} is suddenly very hot!");
                            if (SaveGame.DamageMonster(GetMonsterIndex(), this.SaveGame.DiceRoll(2, 6), out fear,
                                " turns into a pile of ash."))
                            {
                                blinked = false;
                                alive = false;
                            }
                        }
                        else
                        {
                            // The player noticed that the monster took no fire damage
                            if (IsVisible)
                            {
                                Race.Knowledge.Characteristics.ImmuneFire = true;
                            }
                        }
                    }
                    if (SaveGame.HasLightningShield && alive)
                    {
                        if (!Race.ImmuneLightning)
                        {
                            SaveGame.MsgPrint($"{monsterName} gets zapped!");
                            if (SaveGame.DamageMonster(GetMonsterIndex(), this.SaveGame.DiceRoll(2, 6), out fear,
                                " turns into a pile of cinder."))
                            {
                                blinked = false;
                                alive = false;
                            }
                        }
                        else
                        {
                            // The player noticed that the monster took no lightning damage
                            if (IsVisible)
                            {
                                Race.Knowledge.Characteristics.ImmuneLightning = true;
                            }
                        }
                    }
                }
            }
            else
            {
                // It missed us, so give us the appropriate message
                if (method.RendersMissMessage && IsVisible)
                {
                    SaveGame.Disturb(true);
                    SaveGame.MsgPrint($"{monsterName} misses you.");
                }
            }
            // If the player saw the monster, they now know more about what attacks it can do
            if (visible)
            {
                if (obvious || damage != 0 || Race.Knowledge.RBlows[attackNumber] > 10)
                {
                    if (Race.Knowledge.RBlows[attackNumber] < Constants.MaxUchar)
                    {
                        Race.Knowledge.RBlows[attackNumber]++;
                    }
                }
            }
        }
        // If the monster teleported away after stealing, let the player know and do the actual teleport
        if (blinked)
        {
            SaveGame.MsgPrint("The thief flees laughing!");
            TeleportAway(SaveGame, (Constants.MaxSight * 2) + 5);
        }
        // If the attack just killed the player, let future generations remember what killed
        // their ancestor
        if (SaveGame.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
        {
            Race.Knowledge.RDeaths++;
        }
        // If the monster just got scared, let the player know
        if (IsVisible && fear)
        {
            SaveGame.PlaySound(SoundEffectEnum.MonsterFlees);
            SaveGame.MsgPrint($"{monsterName} flees in terror!");
        }
    }

    public void TeleportAway(SaveGame saveGame, int dis)
    {
        int ny = 0;
        int nx = 0;
        bool look = true;
        if (Race == null)
        {
            return;
        }
        int oy = MapY;
        int ox = MapX;
        int min = dis / 2;
        while (look)
        {
            if (dis > 200)
            {
                dis = 200;
            }
            for (int i = 0; i < 500; i++)
            {
                while (true)
                {
                    ny = SaveGame.RandomSpread(oy, dis);
                    nx = SaveGame.RandomSpread(ox, dis);
                    int d = saveGame.Distance(oy, ox, ny, nx);
                    if (d >= min && d <= dis)
                    {
                        break;
                    }
                }
                if (!saveGame.InBounds(ny, nx))
                {
                    continue;
                }
                if (!saveGame.GridPassableNoCreature(ny, nx))
                {
                    continue;
                }
                if (saveGame.Grid[ny][nx].FeatureType.Name == "ElderSign")
                {
                    continue;
                }
                if (saveGame.Grid[ny][nx].FeatureType.Name == "YellowSign")
                {
                    continue;
                }
                look = false;
                break;
            }
            dis *= 2;
            min /= 2;
        }
        saveGame.PlaySound(SoundEffectEnum.Teleport);
        saveGame.Grid[ny][nx].MonsterIndex = GetMonsterIndex();
        saveGame.Grid[oy][ox].MonsterIndex = 0;
        MapY = ny;
        MapX = nx;
        saveGame.UpdateMonsterVisibility(GetMonsterIndex(), true);
        saveGame.RedrawSingleLocation(oy, ox);
        saveGame.RedrawSingleLocation(ny, nx);
    }

    /// <summary>
    /// Get a list of potential moves towards an enemy monster if there is one
    /// </summary>
    /// <param name="monster"> The monster making the moves </param>
    /// <param name="movesList"> The list in which to insert the moves </param>
    private void GetMovesTowardsEnemyMonsters(SaveGame saveGame, PotentialMovesList movesList)
    {
        int[][] spiralGridOffsets =
        {
            new[] {-1, 0}, new[] {0, -1}, new[] {1, 0}, new[] {0, +1}, new[] {-1, -1}, new[] {1, -1}, new[] {1, 1},
            new[] {-1, 1}, new[] {-2, 0}, new[] {0, -2}, new[] {2, 0}, new[] {0, 2}, new[] {-2, -1}, new[] {1, -2},
            new[] {2, 1}, new[] {-1, 2}, new[] {-1, -2}, new[] {2, -1}, new[] {1, 2}, new[] {-2, 1}, new[] {-2, -2},
            new[] {2, -2}, new[] {2, 2}, new[] {-2, 2}, new[] {-3, 0}, new[] {0, -3}, new[] {3, 0}, new[] {0, 3},
            new[] {-3, -1}, new[] {1, -3}, new[] {3, 1}, new[] {-1, 3}, new[] {-3, 1}, new[] {-1, -3}, new[] {3, -1},
            new[] {1, 3}, new[] {-3, -2}, new[] {2, -3}, new[] {3, 2}, new[] {-2, 3}, new[] {-3, 2}, new[] {-2, -3},
            new[] {3, -2}, new[] {2, 3}, new[] {-3, -3}, new[] {3, -3}, new[] {3, 3}, new[] {-3, 3}, new[] {-4, 0},
            new[] {0, -4}, new[] {4, 0}, new[] {0, 4}, new[] {1, -4}, new[] {4, 1}, new[] {-1, 4}, new[] {-4, -1},
            new[] {-4, 1}, new[] {-1, -4}, new[] {4, -1}, new[] {1, 4}, new[] {-4, -2}, new[] {2, -4}, new[] {4, 2},
            new[] {-2, 4}, new[] {-4, 2}, new[] {-2, -4}, new[] {4, -2}, new[] {2, 4}, new[] {-4, -3}, new[] {3, -4},
            new[] {4, 3}, new[] {-3, 4}, new[] {-4, 3}, new[] {-3, -4}, new[] {4, -3}, new[] {3, 4}, new[] {-4, -4},
            new[] {4, -4}, new[] {4, 4}, new[] {-4, 4}
        };
        // Go through the possible places an enemy could be
        for (int i = 0; i < 80; i++)
        {
            // Get the location of the place (these are ordered so they start close and spiral out)
            int y = MapY + spiralGridOffsets[i][0];
            int x = MapX + spiralGridOffsets[i][1];
            // Check if we're in bounds and have a monster
            if (saveGame.InBounds(y, x))
            {
                if (saveGame.Grid[y][x].MonsterIndex != 0)
                {
                    Monster enemy = saveGame.Monsters[saveGame.Grid[y][x].MonsterIndex];
                    // Only go for monsters who are awake and on the opposing side
                    if (enemy.SmFriendly != SmFriendly && enemy.SleepLevel == 0)
                    {
                        // Add moves directly towards and either side of the enemy based on its
                        // relative location
                        x -= MapX;
                        y -= MapY;
                        if (y < 0 && x == 0)
                        {
                            movesList[0] = 8;
                            movesList[1] = 7;
                            movesList[2] = 9;
                        }
                        else if (y > 0 && x == 0)
                        {
                            movesList[0] = 2;
                            movesList[1] = 1;
                            movesList[2] = 3;
                        }
                        else if (x > 0 && y == 0)
                        {
                            movesList[0] = 6;
                            movesList[1] = 9;
                            movesList[2] = 3;
                        }
                        else if (x < 0 && y == 0)
                        {
                            movesList[0] = 4;
                            movesList[1] = 7;
                            movesList[2] = 1;
                        }
                        if (y < 0 && x < 0)
                        {
                            movesList[0] = 7;
                            movesList[1] = 4;
                            movesList[2] = 8;
                        }
                        else if (y < 0 && x > 0)
                        {
                            movesList[0] = 9;
                            movesList[1] = 6;
                            movesList[2] = 8;
                        }
                        else if (y > 0 && x < 0)
                        {
                            movesList[0] = 1;
                            movesList[1] = 4;
                            movesList[2] = 2;
                        }
                        else if (y > 0 && x > 0)
                        {
                            movesList[0] = 3;
                            movesList[1] = 6;
                            movesList[2] = 2;
                        }
                        break;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Check whether a monster hits another monster with an attack
    /// </summary>
    /// <param name="power"> The power of the attack type </param>
    /// <param name="level"> The level of the attacking monster </param>
    /// <param name="armorClass"> The armor class of the defending monster </param>
    /// <returns> True for a hit or false for a miss </returns>
    private bool CheckHitMonsterVersusMonster(int power, int level, int armorClass)
    {
        // Base 5% chance to hit and 5% chance to miss
        int k = SaveGame.RandomLessThan(100);
        if (k < 10)
        {
            return k < 5;
        }
        // If we didn't auto hit or miss, use the standard formula for attacking
        int i = power + (level * 3);
        return i > 0 && SaveGame.DieRoll(i) > armorClass * 3 / 4;
    }

    /// <summary>
    /// Chooses a spell for the monster to attack the player with
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster casting the spell </param>
    /// <param name="spells">A list of the 'magic numbers' of the spells the monster can cast</param>
    /// <param name="listSize"> The number of spells in the spell list </param>
    /// <returns> The 'magic number' of the spell the monster will cast </returns>
    private MonsterSpell ChooseSpellAgainstPlayer(MonsterSpellList spells)
    {
        // If the monster is stupid, cast a random spell
        if (Race.Stupid)
        {
            return spells.ToWeightedRandom(SaveGame).Choose();
        }

        // Priority One: If we're afraid or hurt, always use a random escape spell if we have one
        if (Health < MaxHealth / 3 || FearLevel != 0)
        {
            MonsterSpellList escapeSpells = spells.Where((_spell) => _spell.ProvidesEscape);
            if (escapeSpells.Count > 0)
            {
                return escapeSpells.ToWeightedRandom(SaveGame).Choose();
            }
        }
        // Priority Two: If we're hurt, always use a random healing spell if we have one
        if (Health < MaxHealth / 3)
        {
            MonsterSpellList healingSpells = spells.Where((_spell) => _spell.Heals);
            if (healingSpells.Count > 0)
            {
                return healingSpells.ToWeightedRandom(SaveGame).Choose();
            }
        }
        // Priority Three: If we're near the player and have no attack spells, probably use a
        // tactical spell
        MonsterSpellList attackSpells = spells.Where((_spell) => _spell.IsAttack);
        MonsterSpellList tacticalSpells = spells.Where((_spell) => _spell.IsTactical);
        if (SaveGame.Distance(SaveGame.MapY, SaveGame.MapX, MapY, MapX) < 4 && attackSpells.Count > 0 && this.SaveGame.RandomLessThan(100) < 75)
        {
            if (tacticalSpells.Count > 0)
            {
                return tacticalSpells.ToWeightedRandom(SaveGame).Choose();
            }
        }

        // Priority Four: If we're at less than full health, probably use a healing spell
        if (Health < MaxHealth * 3 / 4 && this.SaveGame.RandomLessThan(100) < 75)
        {
            MonsterSpellList healingSpells = spells.Where((_spell) => _spell.Heals);
            if (healingSpells.Count > 0)
            {
                return healingSpells.ToWeightedRandom(SaveGame).Choose();
            }
        }
        // Priority Five: If we have a summoning spell, maybe use it
        MonsterSpellList summonSpells = spells.Where((_spell) => _spell.SummonsHelp);
        if (summonSpells.Count > 0 && this.SaveGame.RandomLessThan(100) < 50)
        {
            return summonSpells.ToWeightedRandom(SaveGame).Choose();
        }

        // Priority Six: If we have a direct attack spell, probably use it
        if (attackSpells.Count > 0 && this.SaveGame.RandomLessThan(100) < 85)
        {
            return attackSpells.ToWeightedRandom(SaveGame).Choose();
        }

        // Priority Seven: If we have a tactical spell, maybe use it
        if (tacticalSpells.Count > 0 && this.SaveGame.RandomLessThan(100) < 50)
        {
            return tacticalSpells.ToWeightedRandom(SaveGame).Choose();
        }

        // Priority Eight: If we have a haste spell, maybe use it
        MonsterSpellList hasteSpells = spells.Where((_spell) => _spell.Hastens);
        if (hasteSpells.Count > 0 && this.SaveGame.RandomLessThan(100) < 20 + Race.Speed - Speed)
        {
            return hasteSpells.ToWeightedRandom(SaveGame).Choose();
        }

        // Priority Nine: If we have an annoying spell, probably use it
        MonsterSpellList annoyanceSpells = spells.Where((_spell) => _spell.Annoys);
        if (annoyanceSpells.Count > 0 && this.SaveGame.RandomLessThan(100) < 85)
        {
            return annoyanceSpells.ToWeightedRandom(SaveGame).Choose();
        }

        // Priority Ten: Give up on using a spell
        return null;
    }

    /// <summary>
    /// Find a spot that as far from the player as possible an safe from attack
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster trying to find safety </param>
    /// <param name="relativeTarget">
    /// A map location, which will be amended to contain the safe spot
    /// </param>
    /// <returns> True if a safe spot was found, or false if it wasn't </returns>
    private bool FindSafeSpot(SaveGame saveGame, GridCoordinate relativeTarget)
    {
        int safeSpotY = 0;
        int safeSpotX = 0;
        int longestDistance = 0;
        // Start with a short search radius and slowly increase
        for (int d = 1; d < 10; d++)
        {
            int y;
            for (y = MapY - d; y <= MapY + d; y++)
            {
                int x;
                for (x = MapY - d; x <= MapY + d; x++)
                {
                    // Make sure the spot is valid
                    if (!saveGame.InBounds(y, x))
                    {
                        continue;
                    }
                    if (!saveGame.GridPassable(y, x))
                    {
                        continue;
                    }
                    // Make sure the spot is the right distance
                    if (saveGame.Distance(y, x, MapY, MapY) != d)
                    {
                        continue;
                    }
                    // Reject spots that smell too strongly of the player
                    if (saveGame.Grid[y][x].ScentAge < saveGame.Grid[saveGame.MapY][saveGame.MapX].ScentAge)
                    {
                        continue;
                    }
                    if (saveGame.Grid[y][x].ScentStrength > saveGame.Grid[MapY][MapY].ScentStrength + (2 * d))
                    {
                        continue;
                    }
                    // Make sure the spot is actually hidden
                    if (!saveGame.Projectable(y, x, saveGame.MapY, saveGame.MapX))
                    {
                        // If the spot is further from the player than any previously found
                        // spot, remember it
                        int dis = saveGame.Distance(y, x, saveGame.MapY, saveGame.MapX);
                        if (dis > longestDistance)
                        {
                            safeSpotY = y;
                            safeSpotX = x;
                            longestDistance = dis;
                        }
                    }
                }
            }
            // If we found a spot then save its coordinates and return true
            if (longestDistance > 0)
            {
                relativeTarget = new GridCoordinate(MapY - safeSpotX, MapY - safeSpotY);
                return true;
            }
        }
        // We found nowhere suitable
        return false;
    }

    /// <summary>
    /// Check whether an attack hits the player.
    /// </summary>
    /// <param name="attackPower"> The power of the attack </param>
    /// <param name="monsterLevel"> The level of the monster making the attack </param>
    /// <returns> True if the attack hit, false if not </returns>
    private bool MonsterCheckHitOnPlayer(SaveGame saveGame, int attackPower, int monsterLevel)
    {
        // Straight five percent chance of hit or miss
        int k = SaveGame.RandomLessThan(100);
        if (k < 10)
        {
            return k < 5;
        }
        // Otherwise, compare the power and level to the player's armor class
        int i = attackPower + (monsterLevel * 3);
        int ac = saveGame.BaseArmorClass + saveGame.ArmorClassBonus;
        return i > 0 && SaveGame.DieRoll(i) > ac * 3 / 4;
    }

    /// <summary>
    /// Work out if the monster hit the player hard enough to cause a critical hit (a cut or a stun)
    /// </summary>
    /// <param name="dice"> The number of dice of damage caused </param>
    /// <param name="sides"> The number of sides on each damage dice </param>
    /// <param name="damage"> The actual damage the attack caused </param>
    /// <returns> </returns>
    private int MonsterCritical(int dice, int sides, int damage)
    {
        int additionalSeverity = 0;
        int maxDamage = dice * sides;
        // If we did less than 95% of maximum damage, definitely no cuts or stun
        if (damage < maxDamage * 19 / 20)
        {
            return 0;
        }
        // If we did less than 20 damage, then usually no cuts or stun
        if (damage < 20 && SaveGame.RandomLessThan(100) >= damage)
        {
            return 0;
        }
        // We're going to do a crit based on the damage done, and doing max damage increases the severity
        if (damage == maxDamage)
        {
            additionalSeverity++;
        }
        // More than 20 damage increases the severity a random number of times
        if (damage >= 20)
        {
            while (SaveGame.RandomLessThan(100) < 2)
            {
                additionalSeverity++;
            }
        }
        // Higher damage means more severe base (to which the increase is added)
        if (damage > 45)
        {
            return 6 + additionalSeverity;
        }
        if (damage > 33)
        {
            return 5 + additionalSeverity;
        }
        if (damage > 25)
        {
            return 4 + additionalSeverity;
        }
        if (damage > 18)
        {
            return 3 + additionalSeverity;
        }
        if (damage > 11)
        {
            return 2 + additionalSeverity;
        }
        return 1 + additionalSeverity;
    }
}