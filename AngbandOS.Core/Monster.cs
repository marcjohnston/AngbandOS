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

    /// <summary>
    /// Returns the remaining health points for the monster.  A negative value (<0) means the monster is dead.
    /// </summary>
    private int _fearLevel;

    /// <summary>
    /// Returns the remaining health points for the monster.  A negative (<0) value means the monster is dead.  This property add change tracking when set to update the <see cref="Game.TrackedMonsterChanged"/> change tracking
    /// property, when the tracked monster health changes.
    /// </summary>
    public int FearLevel
    {
        get
        {
            return _fearLevel;
        }
        set
        {
            _fearLevel = value;
            if (Game.TrackedMonster.NullMonsterValue == this)
            {
                Game.TrackedMonsterChanged.SetChangedFlag();
            }
        }
    }

    public List<Item> Items = new List<Item>();

    /// <summary>
    /// Returns 0, if the monster is not a clone; or one plus the parent generation, when the monster is a clone.
    /// </summary>
    public int Generation;

    /// <summary>
    /// Returns the remaining health points for the monster.  A negative value (<0) means the monster is dead.
    /// </summary>
    private int _health;

    /// <summary>
    /// Returns the remaining health points for the monster.  A negative (<0) value means the monster is dead.  This property add change tracking when set to update the <see cref="Game.TrackedMonsterChanged"/> change tracking
    /// property, when the tracked monster health changes.
    /// </summary>
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (Game.TrackedMonster.NullMonsterValue == this)
            {
                Game.TrackedMonsterChanged.SetChangedFlag();
            }
        }
    }

    public int IndividualMonsterFlags;

    /// <summary>
    /// Returns true, if the monster is visible; false, otherwise.
    /// </summary>
    private bool _isVisible;

    /// <summary>
    /// Returns true, if the monster is visible; false, otherwise.  This property add change tracking when set to update the <see cref="Game.TrackedMonsterChanged"/> change tracking
    /// property, when the tracked monster visibility changes.
    /// </summary>
    public bool IsVisible
    {
        get
        {
            return _isVisible;
        }
        set
        {
            _isVisible = value;
            if (Game.TrackedMonster.NullMonsterValue == this)
            {
                Game.TrackedMonsterChanged.SetChangedFlag();
            }
        }
    }

    public int MapX;
    public int MapY;

    /// <summary>
    /// Returns the maximum health points for the monster.
    /// </summary>
    private int _maxHealth;

    /// <summary>
    /// Returns the maximum health points for the monster.  This property add change tracking when set to update the <see cref="Game.TrackedMonsterChanged"/> change tracking
    /// property, when the tracked monster health changes.
    /// </summary>
    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
            if (Game.TrackedMonster.NullMonsterValue == this)
            {
                Game.TrackedMonsterChanged.SetChangedFlag();
            }
        }
    }

    /// <summary>
    /// Returns true, if the monster is a clone via the MultiplyMonster.
    /// </summary>
    public bool SmCloned = false;

    /// <summary>
    /// Returns the true, if the monster is friendly; false, otherwise.
    /// </summary>
    private bool _isPet;

    /// <summary>
    /// Returns the true, if the monster is friendly; false, otherwise.  This property add change tracking when set to update the <see cref="Game.TrackedMonsterChanged"/> change tracking
    /// property, when the tracked monster health changes.
    /// </summary>
    public bool IsPet
    {
        get
        {
            return _isPet;
        }
        set
        {
            _isPet = value;
            if (Game.TrackedMonster.NullMonsterValue == this)
            {
                Game.TrackedMonsterChanged.SetChangedFlag();
            }
        }
    }

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
    /// Returns the how deep a monster is sleeping.
    /// </summary>
    private int _sleepLevel;

    /// <summary>
    /// Returns the how deep a monster is sleeping.  This property add change tracking when set to update the <see cref="Game.TrackedMonsterChanged"/> change tracking
    /// property, when the tracked monster health changes.
    /// </summary>
    public int SleepLevel
    {
        get
        {
            return _sleepLevel;
        }
        set
        {
            _sleepLevel = value;
            if (Game.TrackedMonster.NullMonsterValue == this)
            {
                Game.TrackedMonsterChanged.SetChangedFlag();
            }
        }
    }

    public int Speed;
    public int StolenGold;
    public int StunLevel;
    private readonly Game Game;

    public Monster(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the level of the monster.  The Player and the NobodyGhost show as level 1.
    /// </summary>
    public int Level => Race.Level >= 1 ? Race.Level : 1;

    public string DescribeItemLocation(Item oPtr) => $"being held by {Race.FriendlyName}";

    public string Label(Item oPtr) => ""; // TODO: Items held by a monster cannot be selected.

    /// <summary>
    /// Modifies the quantity of an item.  No player stats are modified.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="num"></param>
    public void ModifyItemStackCount(Item oPtr, int num)
    {
        oPtr.ModifyStackCount(num);
    }

    /// <summary>
    /// Renders a description of the item.  For a non-inventory slot, the description is rendered as the player viewing the item.
    /// </summary>
    /// <param name="item"></param>
    public string DescribeContainer(Item oPtr)
    {
        string oName = oPtr.GetFullDescription(true);
        return $"You see {oName}.";
    }

    /// <summary>
    /// Checks the quantity of an item and removes it, when the quanity is zero. 
    /// </summary>
    /// <param name="oPtr"></param>
    public void ItemOptimize(Item oPtr)
    {
        if (oPtr.StackCount != 0)
        {
            return;
        }
        Items.Remove(oPtr);
    }

    public void ProcessWorld()
    {
        foreach (Item item in Items)
        {
            item.MonsterProcessWorld(this);
        }
    }

    /// <summary>
    /// Returns false, because the item container doesn't belong to the players inventory.
    /// </summary>
    public bool IsWielded => false;
    public bool IsWieldedAsEquipment => false;

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
        // *   0x22 --&gt; Possessive, genderized if visible (e.g. "his") or (e.g. "its", if invisible)
        // *   0x23 --&gt; Reflexive, genderized if visible (e.g. "himself") or (e.g. "itself", if invisible)
        if (Race == null)
        {
            return string.Empty;
        }
        string desc;
        string name = Race.FriendlyName;
        if (Game.HallucinationsTimer.Value != 0)
        {
            MonsterRace halluRace;
            do
            {
                halluRace = Game.SingletonRepository.Get<MonsterRace>(Game.DieRoll(Game.SingletonRepository.Count<MonsterRace>() - 2));
            } while (halluRace.Unique);
            string sillyName = halluRace.FriendlyName;
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
            if (Race.Unique && Game.HallucinationsTimer.Value == 0)
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
                desc = IsPet ? "your " : "the ";
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
            this.Game.MsgPrint("Your sanity is shaken by reading the Necronomicon!");
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
            if (!this.Game.HackMind)
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
            if (IsPet && Game.DieRoll(8) != 1)
            {
                return;
            }
            if (Game.DieRoll(power) < Game.SkillSavingThrow)
            {
                return;
            }
            if (Game.HallucinationsTimer.Value != 0)
            {
                this.Game.MsgPrint($"You behold the {new WeightedRandom<string>(Game, Game.FunnyDescriptions).ChooseOrDefault()} visage of {mName}!");
                if (Game.DieRoll(3) == 1)
                {
                    this.Game.MsgPrint(new WeightedRandom<string>(Game, Game.FunnyComments).ChooseOrDefault());
                    Game.HallucinationsTimer.AddTimer(Game.DieRoll(Race.Level));
                }
                return;
            }
            this.Game.MsgPrint($"You behold the {new WeightedRandom<string>(Game, Game.HorrificDescriptions).ChooseOrDefault()} visage of {mName}!");
            Race.Knowledge.Characteristics.EldritchHorror = true;

            // Allow the race to resist.
            if (Game.DieRoll(100) < Game.Race.ChanceOfSanityBlastImmunity(Game.ExperienceLevel.IntValue))
            {
                return;
            }
        }
        if (Game.DieRoll(power) < Game.SkillSavingThrow)
        {
            if (!Game.HasConfusionResistance)
            {
                Game.ConfusionTimer.AddTimer(Game.RandomLessThan(4) + 4);
            }
            if (!Game.HasChaosResistance && Game.DieRoll(3) == 1)
            {
                Game.HallucinationsTimer.AddTimer(Game.RandomLessThan(250) + 150);
            }
            return;
        }
        if (Game.DieRoll(power) < Game.SkillSavingThrow)
        {
            Game.TryDecreasingAbilityScore(Game.IntelligenceAbility);
            Game.TryDecreasingAbilityScore(Game.WisdomAbility);
            return;
        }
        if (Game.DieRoll(power) < Game.SkillSavingThrow)
        {
            if (!Game.HasConfusionResistance)
            {
                Game.ConfusionTimer.AddTimer(Game.RandomLessThan(4) + 4);
            }
            if (!Game.HasFreeAction)
            {
                Game.ParalysisTimer.AddTimer(Game.RandomLessThan(4) + 4);
            }
            while (Game.RandomLessThan(100) > Game.SkillSavingThrow)
            {
                Game.TryDecreasingAbilityScore(Game.IntelligenceAbility);
            }
            while (Game.RandomLessThan(100) > Game.SkillSavingThrow)
            {
                Game.TryDecreasingAbilityScore(Game.WisdomAbility);
            }
            if (!Game.HasChaosResistance)
            {
                Game.HallucinationsTimer.AddTimer(Game.RandomLessThan(250) + 150);
            }
            return;
        }
        if (Game.DieRoll(power) < Game.SkillSavingThrow)
        {
            if (Game.DecreaseAbilityScore(Game.IntelligenceAbility, 10, true))
            {
                happened = true;
            }
            if (Game.DecreaseAbilityScore(Game.WisdomAbility, 10, true))
            {
                happened = true;
            }
            if (happened)
            {
                this.Game.MsgPrint("You feel much less sane than before.");
            }
            return;
        }
        if (Game.DieRoll(power) < Game.SkillSavingThrow)
        {
            if (this.Game.LoseAllInfo())
            {
                this.Game.MsgPrint("You forget everything in your utmost terror!");
            }
            return;
        }
        this.Game.MsgPrint("The exposure to eldritch forces warps you.");
        Game.RunScript(nameof(GainMutationScript));
        this.Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        this.Game.HandleStuff();
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
            if (!Game.HasAggravation)
            {
                notice = (uint)Game.RandomLessThan(1024);
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
                if (Game.HasAggravation)
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
                        Game.MsgPrint($"{monsterName} wakes up.");
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
        // If we're stunned, then reduce our stun game.Level
        if (StunLevel != 0)
        {
            int stunRelief = 1;
            // We have a game.Level-based chance of shaking off the stun completely
            if (Game.RandomLessThan(5000) <= Race.Level * Race.Level)
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
                    Game.MsgPrint($"{monsterName} is no longer stunned.");
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
            // Reduce our confusion by an amount based on our game.Level
            int confusionRelief = Game.DieRoll((Race.Level / 10) + 1);
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
                    Game.MsgPrint($"{monsterName} is no longer confused.");
                }
            }
        }
        // If we're curently friendly and the player aggravates, then stop being friendly
        bool getsAngry = false;
        if (IsPet && Game.HasAggravation)
        {
            getsAngry = true;
        }
        // If we're unique, don't stay friendly
        if (IsPet && !Game.IsWizard.BoolValue && Race.Unique)
        {
            getsAngry = true;
        }
        // If we got angry, let the player see that
        if (getsAngry)
        {
            string monsterName = Name;
            Game.MsgPrint($"{monsterName} suddenly becomes hostile!");
            IsPet = false;
        }
        // Are we afraid?
        if (FearLevel != 0)
        {
            // Reduce our fear by an amount based on our game.Level
            int fearRelief = Game.DieRoll((Race.Level / 10) + 1);
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
                    Game.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                }
            }
        }
        int oldY = MapY;
        int oldX = MapX;
        // If it's suitable for us to reproduce
        if (Race.Multiply && Game.NumRepro < Constants.MaxRepro && Generation < 10)
        {
            // Find how many spaces we've got near us
            int k;
            int y;
            for (k = 0, y = oldY - 1; y <= oldY + 1; y++)
            {
                for (int x = oldX - 1; x <= oldX + 1; x++)
                {
                    if (Game.Map.Grid[y][x].MonsterIndex != 0)
                    {
                        k++;
                    }
                }
            }
            // If we're friendly, then our babies are friendly too
            bool isFriend = IsPet;
            // If there's lots of space, then pop out a baby
            if (k < 4 && (k == 0 || Game.RandomLessThan(k * Constants.MonMultAdj) == 0))
            {
                if (Game.MultiplyMonster(this, isFriend, false))
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
        else if (Race.RandomMove50 && Race.RandomMove25 && Game.RandomLessThan(100) < 75)
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
        else if (Race.RandomMove50 && Game.RandomLessThan(100) < 50)
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
        else if (Race.RandomMove25 && Game.RandomLessThan(100) < 25)
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
        else if (IsPet)
        {
            if (DistanceFromPlayer > Constants.FollowDistance)
            {
                GetMovesTowardsPlayer(potentialMoves);
            }
            else
            {
                // If we're close to the player (and friendly) just use random moves
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
                // Possibly override these random moves with attacks on enemies
                GetMovesTowardsEnemyMonsters(potentialMoves);
            }
        }
        // If all the above fail, we must be a hostile monster who wants to move towards the player
        else
        {
            // If we fail to get sensible moves, give up on our turn
            if (!GetMovesTowardsPlayer(potentialMoves))
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
                d = Game.OrderedDirection[Game.RandomLessThan(8)];
            }
            // Work out where the move will take us
            int newY = oldY + Game.KeypadDirectionYOffset[d];
            int newX = oldX + Game.KeypadDirectionXOffset[d];
            GridTile tile = Game.Map.Grid[newY][newX];
            Monster monsterInTargetTile = Game.Monsters[tile.MonsterIndex];
            // If we can simply move there, then we will do so
            if (Game.GridPassable(newY, newX))
            {
                doMove = true;
            }
            // Bushes don't actually block us, so we can move there too
            else if (Game.Map.Grid[newY][newX].FeatureType.IsBush)
            {
                doMove = true;
            }
            // We can always attack the player, even if the move would otherwse not be allowed
            else if (newY == Game.MapY.IntValue && newX == Game.MapX.IntValue)
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
                if (Game.DieRoll(20) == 1)
                {
                    Game.MsgPrint("There is a grinding sound.");
                }
                // Remove the wall (and the player's memory of it) and remind ourselves to
                // update the view if the player can see it
                tile.PlayerMemorized = false;
                Game.RevertTileToBackground(newY, newX);
                if (Game.PlayerHasLosBold(newY, newX))
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
                    else if (tile.FeatureType.IsClosedDoor)
                    {
                        int k = tile.FeatureType.LockLevel;
                        if (Game.RandomLessThan(Health / 10) > k)
                        {
                            Game.CaveSetFeat(newY, newX, Game.SingletonRepository.Get<Tile>("LockedDoor0"));
                            mayBash = false;
                        }
                    }
                }
                // If we can't open doors (or failed to unlock the door), then we can bash it down
                if (mayBash && Race.BashDoor)
                {
                    int k = tile.FeatureType.LockLevel;
                    // If we succeeded, let the player hear it
                    if (Game.RandomLessThan(Health / 10) > k)
                    {
                        Game.MsgPrint("You hear a door burst open!");
                        didBashDoor = true;
                        doMove = true;
                    }
                }
                // If we opened it or bashed it, replace the closed door with the relevant open
                // or broken one
                if (didOpenDoor || didBashDoor)
                {
                    if (didBashDoor && Game.RandomLessThan(100) < 50)
                    {
                        Game.CaveSetFeat(newY, newX, Game.SingletonRepository.Get<Tile>(nameof(BrokenDoorTile)));
                    }
                    else
                    {
                        Game.CaveSetFeat(newY, newX, Game.SingletonRepository.Get<Tile>(nameof(OpenDoorTile)));
                    }
                    // If the player can see, remind ourselves to update the view later
                    if (Game.PlayerHasLosBold(newY, newX))
                    {
                        doView = true;
                    }
                }
            }
            // If we're going to move onto an Elder Sign and we're capable of doing attacks
            if (doMove && tile.FeatureType.IsElderSignSigil && !Race.NeverAttack)
            {
                // Assume we're not moving
                doMove = false;
                // We have a chance of breaking the sign based on our game.Level
                if (Game.DieRoll(BreakElderSign) < Race.Level)
                {
                    // If the player knows the sign is there, let them know it was broken
                    if (tile.PlayerMemorized)
                    {
                        Game.MsgPrint("The Elder Sign is broken!");
                    }
                    tile.PlayerMemorized = false;
                    Game.RevertTileToBackground(newY, newX);
                    // Breaking the sign means we can move after all
                    doMove = true;
                }
            }
            // If we're going to move onto a Yellow Sign and we can attack
            else if (doMove && tile.FeatureType.IsYellowSignSigil && !Race.NeverAttack)
            {
                // Assume we're not moving
                doMove = false;
                // We have a chance to break the sign
                if (Game.DieRoll(Constants.BreakYellowSign) < Race.Level)
                {
                    // If the player knows about the sign, let them know it was broken
                    if (tile.PlayerMemorized)
                    {
                        // If the player was on the sign, hurt them
                        if (newY == Game.MapY.IntValue && newX == Game.MapX.IntValue)
                        {
                            Game.MsgPrint("The rune explodes!");
                            Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile)), 0, 2 * ((Game.ExperienceLevel.IntValue / 2) + Game.DiceRoll(7, 7)), 2);
                        }
                        else
                        {
                            Game.MsgPrint("An Yellow Sign was disarmed.");
                        }
                    }
                    tile.PlayerMemorized = false;
                    Game.RevertTileToBackground(newY, newX);
                    // We can do the move after all
                    doMove = true;
                }
            }
            // If we're going to attack the player, but our race never attacks, then cancel the move
            if (doMove && newY == Game.MapY.IntValue && newX == Game.MapX.IntValue && Race.NeverAttack)
            {
                doMove = false;
            }
            // If we're trying to move onto the player, then attack them instead
            if (doMove && newY == Game.MapY.IntValue && newX == Game.MapX.IntValue)
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
                if (Race.KillBody && Race.Mexp > targetMonsterRace.Mexp && Game.GridPassable(newY, newX) && !(IsPet && monsterInTargetTile.IsPet))
                {
                    // Remove the other monster and replace it
                    doMove = true;
                    didKillBody = true;
                    Game.DeleteMonsterAtGridLocation(newY, newX);
                    monsterInTargetTile = Game.Monsters[tile.MonsterIndex];
                }
                // If we're not on the same team as the other monster or we're confused
                else if (IsPet != monsterInTargetTile.IsPet || ConfusionLevel != 0)
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
                else if (Race.MoveBody && Race.Mexp > targetMonsterRace.Mexp && Game.GridPassable(newY, newX) && Game.GridPassable(MapY, MapX))
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
                Game.Map.Grid[oldY][oldX].MonsterIndex = tile.MonsterIndex;
                // If it was actually a monster then update it accordingly
                if (tile.MonsterIndex != 0)
                {
                    monsterInTargetTile.MapY = oldY;
                    monsterInTargetTile.MapX = oldX;
                    Game.UpdateMonsterVisibility(tile.MonsterIndex, true);
                    // Pushing past something wakes it up
                    Game.Monsters[tile.MonsterIndex].SleepLevel = 0;
                }
                // Update our position
                tile.MonsterIndex = GetMonsterIndex();
                MapY = newY;
                MapX = newX;
                Game.UpdateMonsterVisibility(GetMonsterIndex(), true);
                Game.ConsoleView.RefreshMapLocation(oldY, oldX);
                Game.ConsoleView.RefreshMapLocation(newY, newX);
                // If we are hostile and the player saw us move, then game.Disturb them
                if (IsVisible && (IndividualMonsterFlags & Constants.MflagView) != 0)
                {
                    if (!IsPet)
                    {
                        Game.Disturb(false);
                    }
                }
                // Check through the items in the tile we just entered
                foreach (Item item in tile.Items.ToArray()) // We need to use a copy because the collection can change
                {
                    // We ignore gold
                    if (item.IsIgnoredByMonsters)
                    {
                        continue;
                    }
                    // If we pick up or stomp on items, check the item type
                    if ((Race.TakeItem || Race.KillItem) && !IsPet)
                    {
                        bool willHurt = false;
                        RoItemPropertySet mergedCharacteristics = item.GetEffectiveItemProperties();
                        string itemName = item.GetFullDescription(true);
                        string monsterName = IndefiniteWhenHiddenName;
                        if (mergedCharacteristics.KillDragon && Race.Dragon)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayDragon && Race.Dragon)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayTroll && Race.Troll)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayGiant && Race.Giant)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayOrc && Race.Orc)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayDemon && Race.Demon)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayUndead && Race.Undead)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayAnimal && Race.Animal)
                        {
                            willHurt = true;
                        }
                        if (mergedCharacteristics.SlayEvil && Race.Evil)
                        {
                            willHurt = true;
                        }
                        // Monsters won't pick up artifacts or items that hurt them
                        if (item.IsArtifact || willHurt)
                        {
                            if (Race.TakeItem)
                            {
                                didTakeItem = true;
                                if (IsVisible && Game.PlayerHasLosBold(newY, newX))
                                {
                                    Game.MsgPrint($"{monsterName} tries to pick up {itemName}, but fails.");
                                }
                            }
                        }
                        // If we picked up the item and the player saw, let them know
                        else if (Race.TakeItem)
                        {
                            didTakeItem = true;
                            if (Game.PlayerHasLosBold(newY, newX))
                            {
                                Game.MsgPrint($"{monsterName} picks up {itemName}.");
                            }
                            // And pick up the actual item
                            Game.ExciseObject(item);
                            item.WasNoticed = false;
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
                            if (Game.PlayerHasLosBold(newY, newX))
                            {
                                Game.MsgPrint($"{monsterName} crushes {itemName}.");
                            }
                            Game.DeleteObject(item);
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
        if (!doTurn && !doMove && FearLevel == 0 && !IsPet)
        {
            if (TryCastingASpellAgainstPlayer())
            {
                return;
            }
        }
        // Update the view if necessary
        if (doView)
        {
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateScentFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
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
                Game.MsgPrint($"{monsterName} turns to fight!");
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
        Monster target = Game.Monsters[targetIndex];
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
            Game.MsgPrint("You hear noise.");
        }
        // We have up to four attacks
        for (int attackNumber = 0; attackNumber < Race.Attacks.Length; attackNumber++)
        {
            bool visible = false;
            bool obvious = false;
            int damage = 0;
            AttackEffect? effect = Race.Attacks[attackNumber].Effect;
            Attack method = Race.Attacks[attackNumber].Method;
            int dDice = Race.Attacks[attackNumber].Dice;
            int dSide = Race.Attacks[attackNumber].Sides;
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
                Game.Disturb(true);
                if (method.AttackAwakensTarget)
                {
                    target.SleepLevel = 0;
                }

                // Display the attack description
                if (IsVisible || target.IsVisible)
                {
                    string monsterAction = String.Format(method.MonsterAction, monsterName);
                    Game.MsgPrint($"{monsterName} {monsterName}.");
                }
                obvious = true;
                damage = this.Game.DiceRoll(dDice, dSide);
                // Default to a missile attack
                Projectile pt = Game.SingletonRepository.Get<Projectile>(nameof(MissileProjectile));
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
                    pt.Fire(GetMonsterIndex(), 0, target.MapY, target.MapX, damage, kill: true, stop: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false);
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
                                Game.MsgPrint($"{monsterName} is suddenly very hot!");
                                if (target.IsVisible)
                                {
                                    targetRace.Knowledge.Characteristics.FireAura = true;
                                }
                            }
                            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(FireProjectile));
                            projectile.Fire(targetIndex, 0, MapY, MapX, this.Game.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)), kill: true, stop: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false);
                        }
                        if (targetRace.LightningAura && !Race.ImmuneLightning)
                        {
                            if (IsVisible || target.IsVisible)
                            {
                                // Auras prevent us blinking away
                                blinked = false;
                                // The player may see and learn that the target has the aura
                                Game.MsgPrint($"{monsterName} gets zapped!");
                                if (target.IsVisible)
                                {
                                    targetRace.Knowledge.Characteristics.LightningAura = true;
                                }
                            }
                            Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ElectricityProjectile));
                            projectile.Fire(targetIndex, 0, MapY, MapX, this.Game.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)), kill: true, stop: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false);
                        }
                    }
                }
            }
            else
            {
                // We didn't hit, so just let the player know that if we are visible
                if (method.AttackTouchesTarget && !method.RendersMissMessage && IsVisible)
                {
                    Game.Disturb(false);
                    Game.MsgPrint($"{monsterName} misses {target.Name}.");
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
            Game.MsgPrint(IsVisible ? "The thief flees laughing!" : "You hear laughter!");
            TeleportAway((Constants.MaxSight * 2) + 5);
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
        if (IsPet)
        {
            return false;
        }
        // We aren't guaranteed to cast a spell even if we can
        int chance = Race.FrequencyChance;
        if (chance == 0)
        {
            return false;
        }
        if (Game.RandomLessThan(100) >= chance)
        {
            return false;
        }

        // Innate abilities are inherently less likely than actual spells
        if (Game.RandomLessThan(100) >= chance * 2)
        {
            noInnate = true;
        }

        // If we're too far from the player don't cast a spell
        if (DistanceFromPlayer > Constants.MaxRange)
        {
            return false;
        }

        // If we have no line of sight to the player, don't cast a spell
        if (!Game.Projectable(MapY, MapX, Game.MapY.IntValue, Game.MapX.IntValue))
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
        if (Race.Smart && Health < MaxHealth / 10 && Game.RandomLessThan(100) < 50)
        {

            spells = spells.Where((_spell) => _spell.IsIntelligent);

            // If we just got rid of all our spells then don't cast
            if (spells.Count == 0)
            {
                return false;
            }
        }

        // Ditch any spells that we've seen the player resist before so we know they'll be ineffective
        spells = RemoveIneffectiveSpells(spells);

        // If we just got rid of all our spells then don't cast
        if (spells.Count == 0)
        {
            return false;
        }

        // If we don't have a clean shot, and we're stupid, remove bolt spells
        if (spells.Contains((_spell) => _spell.CanBeReflected) && !Race.Stupid && !Game.CleanShot(MapY, MapX, Game.MapY.IntValue, Game.MapX.IntValue))
        {
            spells = spells.Remove((_spell) => _spell.CanBeReflected);
        }

        // If there's nowhere around the player to put a summoned creature, then remove
        // summoning spells
        if (spells.Contains((_spell) => _spell.SummonsHelp) && !Race.Stupid && !Game.SummonPossible(Game.MapY.IntValue, Game.MapX.IntValue))
        {
            spells = spells.Remove((_spell) => _spell.SummonsHelp);
        }

        // If we've removed all our spells, don't cast anything
        if (spells.Count == 0)
        {
            return false;
        }

        // If the player's already dead or off the game.Level, don't cast
        if (!Game.Playing || Game.IsDead || Game.NewLevelFlag)
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
        if (!thrownSpell.UsesBreathe && Game.RandomLessThan(100) < failrate)
        {
            Game.MsgPrint($"{monsterName} tries to cast a spell, but fails.");
            return true;
        }

        // Any action on the player automatically disturbs the player.
        Game.Disturb(true);

        // Render a message to the player.
        bool playerIsBlind = Game.BlindnessTimer.Value != 0;

        // Choose which message to render.
        string? message = playerIsBlind ? thrownSpell.VsPlayerBlindMessage : IsVisible ? thrownSpell.VsPlayerActionMessage : thrownSpell.VsPlayerActionMessageOnInvisibleMonster;

        // Check to see if there is a message to be rendered.
        if (message != null)
        {
            // Provide additional macro formatting.
            string kinName = Race.Unique ? "minions" : "kin";
            message = String.Format(message, monsterName, monsterPossessive, kinName);
            Game.MsgPrint(message);
        }

        // Execute the spell.
        thrownSpell.ExecuteOnPlayer(this);

        // Learn from the spell.
        foreach (SpellResistantDetection smartLearn in thrownSpell.SmartLearn)
        {
            Game.UpdateSmartLearn(this, smartLearn);
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
        if (Game.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
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
        bool friendly = IsPet;

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
        if (this.Game.RandomLessThan(100) >= chance)
        {
            return false;
        }

        MonsterSpellList monsterSpells = Race.Spells;

        // Look through the monster list to find a potential target
        for (int i = 1; i < Game.MonsterMax; i++)
        {
            int targetIndex = i;
            Monster target = Game.Monsters[targetIndex];
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
            if (IsPet == target.IsPet)
            {
                continue;
            }

            // If the target is too far away from the player, don't cast a spell
            if (target.DistanceFromPlayer > Constants.MaxRange)
            {
                continue;
            }

            // If we don't have line of sight to the target, don't cast a spell
            if (!Game.Projectable(MapY, MapX, target.MapY, target.MapX))
            {
                continue;
            }

            // If we're smart and badly injured, we may want to prioritise spells that disable
            // the target, summon help, or let us escape over spells that do direct damage
            if (Race.Smart && Health < MaxHealth / 10 && this.Game.RandomLessThan(100) < 50)
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
            if (monsterSpells.Contains((MonsterSpell _monsterSpell) => _monsterSpell.SummonsHelp) && !Race.Stupid && !Game.SummonPossible(target.MapY, target.MapX))
            {
                monsterSpells = monsterSpells.Remove((MonsterSpell _monsterSpell) => _monsterSpell.SummonsHelp);
            }

            // If we've removed all our spells, don't cast anything
            if (monsterSpells.Count == 0)
            {
                return false;
            }

            // If the player's already dead or off the level, don't cast
            if (!Game.Playing || Game.IsDead || Game.NewLevelFlag)
            {
                return false;
            }

            // Against other monsters we pick spells randomly
            MonsterSpell? thrownSpell = Race.Spells.ToWeightedRandom(Game).ChooseOrDefault();
            if (thrownSpell == null)
            {
                return false; // We were unable to cast a spell.
            }

            bool blind = Game.BlindnessTimer.Value != 0;
            bool seeTarget = !blind && target.IsVisible;
            bool seen = !blind && IsVisible;
            bool seeEither = seen || seeTarget;

            // If the player can see either monster, disturb the player.
            if (seeEither)
            {
                Game.Disturb(true);
            }

            // Render a message to the player.
            string? message = !seeEither ? thrownSpell.VsMonsterUnseenMessage : thrownSpell.VsMonsterSeenMessage;
            if (message != null)
            {
                string kinName = Race.Unique ? "minions" : "kin";
                string targetMonsterName = target.Name;
                string targetPossessive = target.Name != "it" ? "s" : "'s";
                message = String.Format(message, Name, PossessiveName, kinName, targetMonsterName, $"{targetMonsterName}{targetPossessive}");
                Game.MsgPrint(message);
            }

            // Execute the action on the monster.
            thrownSpell.ExecuteOnMonster(this, target);

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
            if (Game.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
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
    public void BreatheAtMonster(int targetY, int targetX, Projectile projectile, int damage, int radius) // TODO: Why is this not used
    {
        // Radius 0 means use the default radius
        if (radius < 1)
        {
            radius = Race.Powerful ? 3 : 2;
        }
        // Make the radius negative to indicate we need a cone instead of a ball
        radius = 0 - radius;
        projectile.Fire(GetMonsterIndex(), radius, targetY, targetX, damage, grid: true, item: true, kill: true, jump: false, beam: false, thru: false, hide: false, stop: false);
    }

    /// <summary>
    /// Fire some kind of ball attack at the player
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster firing the attack </param>
    /// <param name="projectile"> The type of effect the ball has </param>
    /// <param name="damage"> The damage done by the ball </param>
    /// <param name="radius"> The radius of the ball, or zero to use the default radius </param>
    public void FireBallAtPlayer(Projectile projectile, int damage, int radius) // TODO: Why is this not used
    {
        if (radius < 1)
        {
            radius = Race.Powerful ? 3 : 2;
        }
        projectile.Fire(GetMonsterIndex(), radius, Game.MapY.IntValue, Game.MapX.IntValue, damage, grid: true, item: true, kill: true, jump: false, beam: false, thru: false, hide: false, stop: false);
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
    public void BreatheAtPlayer(Projectile projectile, int damage, int radius) // TODO: Why is this not used
    {
        // Radius 0 means use the default radius
        if (radius < 1)
        {
            radius = Race.Powerful ? 3 : 2;
        }
        // Make the radius negative to indicate we need a cone instead of a ball
        radius = 0 - radius;
        projectile.Fire(GetMonsterIndex(), radius, Game.MapY.IntValue, Game.MapX.IntValue, damage, grid: true, item: true, kill: true, jump: false, beam: false, thru: false, hide: false, stop: false);
    }

    /// <summary>
    /// Fire a bolt of some kind at another monster
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster doing the firing </param>
    /// <param name="targetY"> The y coordinate of the target </param>
    /// <param name="targetX"> The x coordinate of the target </param>
    /// <param name="projectile"> The projectile to be fired </param>
    /// <param name="damage"> The damage the projectile should do </param>
    public void FireBoltAtMonster(int targetY, int targetX, Projectile projectile, int damage) // TODO: Why is this not used
    {
        projectile.Fire(GetMonsterIndex(), 0, targetY, targetX, damage, kill: true, stop: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false);
    }

    /// <summary>
    /// Take damage after being hit by another monster
    /// </summary>
    /// <param name="monsterIndex"> The index of the monster taking the damage </param>
    /// <param name="damage"> The damage taken </param>
    /// <param name="fear"> Whether the damage makes us afraid </param>
    /// <param name="note"> A special descriptive note that replaces the normal death message </param>
    public void TakeDamageFromAnotherMonster(int damage, out bool fear, string note)
    {
        fear = false;
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
                Game.PlaySound(SoundEffectEnum.MonsterDies);
                // Append the note if there is one
                if (!string.IsNullOrEmpty(note))
                {
                    Game.MsgPrint(monsterName + note);
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
                    Game.MsgPrint($"{monsterName} is destroyed.");
                }
                else
                {
                    Game.MsgPrint($"{monsterName} is killed.");
                }
                // Let the save game know we've died
                Game.MonsterDeath(this);
                // Delete us from the monster list
                Game.DeleteMonsterByIndex(GetMonsterIndex(), true);
                fear = false;
                return;
            }
        }
        // Assuming we survived, check if the attack made us afraid
        if (FearLevel != 0 && damage > 0)
        {
            // If we're already afraid, we might get desperate and overcome our fear
            int tmp = Game.DieRoll(damage);
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
            if ((percentage <= 10 && Game.RandomLessThan(10) < percentage) || (damage >= Health && Game.RandomLessThan(100) < 80))
            {
                fear = true;
                FearLevel = Game.DieRoll(10) + (damage >= Health && percentage > 7 ? 20 : (11 - percentage) * 5);
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
        projectile.Fire(GetMonsterIndex(), 0, Game.MapY.IntValue, Game.MapX.IntValue, damage, kill: true, stop: true, jump: false, beam: false, thru: false, hide: false, grid: false, item: false);
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
    private MonsterSpellList RemoveIneffectiveSpells(MonsterSpellList spells)
    {
        // If we're stupid, we won't realise how ineffective things are
        if (Race.Stupid)
        {
            return spells;
        }

        // Tiny chance of forgetting what we've seen, clearing all smart flags except for ally and clone
        if (Game.RandomLessThan(100) < 1)
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
        return Game.RandomLessThan(100) < percentage;
    }

    /// <summary>
    /// Populate a list with possible moves towards the player. Note that we won't always move
    /// directly towards the player, based on factors such as if we're in a group in a room or
    /// if we're afraid of the player.
    /// </summary>
    /// <param name="monsterIndex"> the index of the monster who is moving </param>
    /// <param name="movesList"> The list to be populated with moves </param>
    /// <returns> True if we have potential moves or false if we don't </returns>
    private bool GetMovesTowardsPlayer(PotentialMovesList movesList)
    {
        int moveVal = 0;
        bool done = false;
        // Default to moving towards the player's exact location
        GridCoordinate targetLocation = new GridCoordinate(Game.MapX.IntValue, Game.MapY.IntValue);
        // Adjust our target based on the player's scent if we can't move in a straight line to them
        TrackPlayerByScent(targetLocation);
        // Get the relative move needed to reach our target location
        GridCoordinate desiredRelativeMovement = new GridCoordinate(MapX - targetLocation.X, MapY - targetLocation.Y);
        if (!IsPet)
        {
            // If we're a pack animal that can't go through walls
            if (Race.Friends && Race.Animal &&
                !Race.PassWall && !Race.KillWall)
            {
                int room = 0;
                // Check if the player is in a room by counting the room tiles around them
                for (int i = 0; i < 8; i++)
                {
                    if (Game.Map.Grid[Game.MapY.IntValue + Game.OrderedDirectionYOffset[i]][Game.MapX.IntValue + Game.OrderedDirectionXOffset[i]].InRoom)
                    {
                        room++;
                    }
                }
                // If the player isn't in a room and they're healthy, wait to ambush them rather
                // than running headlong into the corridor after them and queueing up to get hit
                if (room < 8 && Game.Health.IntValue > Game.MaxHealth.IntValue * 3 / 4)
                {
                    if (FindAmbushSpot(desiredRelativeMovement))
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
                    targetLocation = new GridCoordinate(Game.MapX.IntValue + Game.OrderedDirectionXOffset[(monsterIndex + i) & 7], Game.MapY.IntValue + Game.OrderedDirectionYOffset[(monsterIndex + i) & 7]);
                    // We might have got a '5' meaning stay where we are, so replace that with
                    // moving towards the player
                    if (MapY == targetLocation.Y && MapX == targetLocation.X)
                    {
                        targetLocation = new GridCoordinate(Game.MapX.IntValue, Game.MapY.IntValue);
                        break;
                    }
                    // Repeat till we get a direction we can move in
                    if (!Game.GridPassableNoCreature(targetLocation.Y, targetLocation.X))
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
        if (IsPet)
        {
            if (MonsterShouldRetreat())
            {
                // If we should be scared, simply move the opposite way to the player
                desiredRelativeMovement = new GridCoordinate(-desiredRelativeMovement.X, - desiredRelativeMovement.Y);
            }
        }
        else
        {
            // If we're not an ally then check if we should retreat
            if (!done && MonsterShouldRetreat())
            {
                // If we should retreat, then try to find a safe spot where the player can't
                // shoot or see us
                if (!FindSafeSpot(desiredRelativeMovement))
                {
                    // If we failed to find one, just back off
                    desiredRelativeMovement = new GridCoordinate(-desiredRelativeMovement.X, -desiredRelativeMovement.Y);
                }
                else
                {
                    // We found a safe spot, so head there, but prioritise avoiding the player's scent
                    AvoidPlayersScent(desiredRelativeMovement);
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
    private void AvoidPlayersScent(GridCoordinate coord)
    {
        int monsterY = MapY;
        int monsterX = MapX;
        int dY = monsterY - coord.Y;
        int dX = monsterX - coord.X;
        // If the scent too strong, keep going where we were going
        if (Game.Map.Grid[monsterY][monsterX].ScentAge < Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue].ScentAge)
        {
            return;
        }
        if (Game.Map.Grid[monsterY][monsterX].ScentStrength > Constants.MonsterFlowDepth)
        {
            return;
        }
        if (Game.Map.Grid[monsterY][monsterX].ScentStrength > Race.NoticeRange)
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
            int y = monsterY + Game.OrderedDirectionYOffset[i];
            int x = monsterX + Game.OrderedDirectionXOffset[i];
            // If we have no scent there, or the scent is too recent, ignore it
            if (Game.Map.Grid[y][x].ScentAge == 0)
            {
                continue;
            }
            if (Game.Map.Grid[y][x].ScentAge < when)
            {
                continue;
            }
            // If the scent is weaker than in the other directions, go that way
            int dis = Game.Distance(y, x, dY, dX);
            int s = (5000 / (dis + 3)) - (500 / (Game.Map.Grid[y][x].ScentStrength + 1));
            if (s < 0)
            {
                s = 0;
            }
            if (s < score)
            {
                continue;
            }
            when = Game.Map.Grid[y][x].ScentAge;
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
    private void TrackPlayerByScent(GridCoordinate target)
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
        GridTile cPtr = Game.Map.Grid[y1][x1];
        // If we have no scent of the player then don't change where we were going
        if (cPtr.ScentAge < Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue].ScentAge)
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
        if (Game.PlayerHasLosBold(y1, x1))
        {
            return;
        }
        int when = 0;
        int cost = 999;
        // Check the eight directions we can move to see which has the most recent or strongest scent
        for (int i = 7; i >= 0; i--)
        {
            int y = y1 + Game.OrderedDirectionYOffset[i];
            int x = x1 + Game.OrderedDirectionXOffset[i];
            if (Game.Map.Grid[y][x].ScentAge == 0)
            {
                continue;
            }
            if (Game.Map.Grid[y][x].ScentAge < when)
            {
                continue;
            }
            if (Game.Map.Grid[y][x].ScentStrength > cost)
            {
                continue;
            }
            when = Game.Map.Grid[y][x].ScentAge;
            cost = Game.Map.Grid[y][x].ScentStrength;
            // Give us a target in the general direction of the strongest scent
            target = new GridCoordinate(Game.MapX.IntValue + (16 * Game.OrderedDirectionXOffset[i]), Game.MapY.IntValue + (16 * Game.OrderedDirectionYOffset[i]));
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
    private bool FindAmbushSpot(GridCoordinate relativeTarget)
    {
        int fy = MapY;
        int fx = MapX;
        int hidingSpotY = 0;
        int hidingSpotX = 0;
        int shortestDistance = 999;
        int tooCloseToPlayer = (Game.Distance(Game.MapY.IntValue, Game.MapX.IntValue, fy, fx) * 3 / 4) + 2;
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
                    if (!Game.InBounds(y, x))
                    {
                        continue;
                    }
                    if (!Game.GridPassable(y, x))
                    {
                        continue;
                    }
                    // Make sure the spot is the right distance
                    if (Game.Distance(y, x, fy, fx) != d)
                    {
                        continue;
                    }
                    // Make sure the spot is actually hidden
                    if (!Game.PlayerCanSeeBold(y, x) && Game.CleanShot(fy, fx, y, x))
                    {
                        // If the spot is closer to the player than any previously found spot
                        // (but not too close), remember it
                        int dis = Game.Distance(y, x, Game.MapY.IntValue, Game.MapX.IntValue);
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
    private bool MonsterShouldRetreat()
    {
        // Don't move away if we're already too far away to see the player
        if (DistanceFromPlayer > Constants.MaxSight + 5)
        {
            return false;
        }
        // If we're the player's friend then don't move away from them
        if (IsPet)
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
        int playerLevel = Game.ExperienceLevel.IntValue;
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
        int playerHealth = Game.Health.IntValue;
        int playerMaxHealth = Game.MaxHealth.IntValue;
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
        for (int i = 0; i < Game.Monsters.Length; i++)
        {
            if (Game.Monsters[i] == this)
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
        if (IsPet)
        {
            return;
        }

        string monsterName = Name;
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
            int damageDice = Race.Attacks[attackNumber].Dice;
            int damageSides = Race.Attacks[attackNumber].Sides;

            // Stop if player is dead or gone
            if (!alive || Game.IsDead || Game.NewLevelFlag)
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
            if (effect == null || MonsterCheckHitOnPlayer(power))
            {
                Game.Disturb(true);
                // Protection From Evil might repel the attack
                if (Game.ProtectionFromEvilTimer.Value > 0 && Race.Evil && Game.ExperienceLevel.IntValue >= Level && this.Game.RandomLessThan(100) + Game.ExperienceLevel.IntValue > 50)
                {
                    if (IsVisible)
                    {
                        // If it does, then they player knows the monster is evil
                        Race.Knowledge.Characteristics.Evil = true;
                    }
                    Game.MsgPrint($"{monsterName} is repelled.");
                    continue;
                }

                // Are there player action messages to choose from.
                if (method.PlayerActionMessages != null)
                {
                    // Select one of them.
                    string? action = new WeightedRandom<string>(Game, method.PlayerActionMessages).ChooseOrDefault();

                    // Is t
                    if (!string.IsNullOrEmpty(action))
                    {
                        // Print the message.
                        Game.MsgPrint($"{monsterName} {action}.");
                    }
                }

                obvious = true;
                // Work out base damage done by the attack
                damage = this.Game.DiceRoll(damageDice, damageSides);
                // Apply any modifiers to the damage
                if (effect == null)
                {
                    obvious = true;
                    damage = 0;
                }
                else
                {
                    effect.ApplyToPlayer(this, ref obvious, ref damage, ref blinked);
                }

                // Be nice and don't let us be both stunned and cut by the same blow
                bool doCut = method.AttackCutsTarget;
                bool doStun = method.AttackStunsTarget;
                if (doCut && doStun)
                {
                    if (this.Game.RandomLessThan(100) < 50)
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
                            k = this.Game.DieRoll(5);
                            break;

                        case 2:
                            k = this.Game.DieRoll(5) + 5;
                            break;

                        case 3:
                            k = this.Game.DieRoll(20) + 20;
                            break;

                        case 4:
                            k = this.Game.DieRoll(50) + 50;
                            break;

                        case 5:
                            k = this.Game.DieRoll(100) + 100;
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
                        Game.BleedingTimer.AddTimer(k);
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
                            k = this.Game.DieRoll(5);
                            break;

                        case 2:
                            k = this.Game.DieRoll(10) + 10;
                            break;

                        case 3:
                            k = this.Game.DieRoll(20) + 20;
                            break;

                        case 4:
                            k = this.Game.DieRoll(30) + 30;
                            break;

                        case 5:
                            k = this.Game.DieRoll(40) + 40;
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
                        Game.StunTimer.AddTimer(k);
                    }
                }
                // If the monster touched us then it may take damage from our defensive abilities
                if (touched)
                {
                    if (Game.HasFireSheath && alive)
                    {
                        if (!Race.ImmuneFire)
                        {
                            Game.MsgPrint($"{monsterName} is suddenly very hot!");
                            if (Game.DamageMonster(GetMonsterIndex(), this.Game.DiceRoll(2, 6), out fear, " turns into a pile of ash."))
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
                    if (Game.HasElectricitySheath && alive)
                    {
                        if (!Race.ImmuneLightning)
                        {
                            Game.MsgPrint($"{monsterName} gets zapped!");
                            if (Game.DamageMonster(GetMonsterIndex(), this.Game.DiceRoll(2, 6), out fear, " turns into a pile of cinder."))
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
                    Game.Disturb(true);
                    Game.MsgPrint($"{monsterName} misses you.");
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
            Game.MsgPrint("The thief flees laughing!");
            TeleportAway((Constants.MaxSight * 2) + 5);
        }
        // If the attack just killed the player, let future generations remember what killed
        // their ancestor
        if (Game.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
        {
            Race.Knowledge.RDeaths++;
        }
        // If the monster just got scared, let the player know
        if (IsVisible && fear)
        {
            Game.PlaySound(SoundEffectEnum.MonsterFlees);
            Game.MsgPrint($"{monsterName} flees in terror!");
        }
    }

    public void TeleportAway(int dis)
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
                    ny = this.Game.RandomSpread(oy, dis);
                    nx = this.Game.RandomSpread(ox, dis);
                    int d = Game.Distance(oy, ox, ny, nx);
                    if (d >= min && d <= dis)
                    {
                        break;
                    }
                }
                if (!Game.InBounds(ny, nx))
                {
                    continue;
                }
                if (!Game.GridPassableNoCreature(ny, nx))
                {
                    continue;
                }
                if (Game.Map.Grid[ny][nx].FeatureType.IsElderSignSigil)
                {
                    continue;
                }
                if (Game.Map.Grid[ny][nx].FeatureType.IsYellowSignSigil)
                {
                    continue;
                }
                look = false;
                break;
            }
            dis *= 2;
            min /= 2;
        }
        Game.PlaySound(SoundEffectEnum.Teleport);
        Game.Map.Grid[ny][nx].MonsterIndex = GetMonsterIndex();
        Game.Map.Grid[oy][ox].MonsterIndex = 0;
        MapY = ny;
        MapX = nx;
        Game.UpdateMonsterVisibility(GetMonsterIndex(), true);
        Game.ConsoleView.RefreshMapLocation(oy, ox);
        Game.ConsoleView.RefreshMapLocation(ny, nx);
    }

    /// <summary>
    /// Get a list of potential moves towards an enemy monster if there is one
    /// </summary>
    /// <param name="monster"> The monster making the moves </param>
    /// <param name="movesList"> The list in which to insert the moves </param>
    private void GetMovesTowardsEnemyMonsters(PotentialMovesList movesList)
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
            if (Game.InBounds(y, x))
            {
                if (Game.Map.Grid[y][x].MonsterIndex != 0)
                {
                    Monster enemy = Game.Monsters[Game.Map.Grid[y][x].MonsterIndex];
                    // Only go for monsters who are awake and on the opposing side
                    if (enemy.IsPet != IsPet && enemy.SleepLevel == 0)
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
        int k = Game.RandomLessThan(100);
        if (k < 10)
        {
            return k < 5;
        }
        // If we didn't auto hit or miss, use the standard formula for attacking
        int i = power + (level * 3);
        return i > 0 && Game.DieRoll(i) > armorClass * 3 / 4;
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
            return spells.ToWeightedRandom(Game).ChooseOrDefault();
        }

        // Priority One: If we're afraid or hurt, always use a random escape spell if we have one
        if (Health < MaxHealth / 3 || FearLevel != 0)
        {
            MonsterSpellList escapeSpells = spells.Where((_spell) => _spell.ProvidesEscape);
            if (escapeSpells.Count > 0)
            {
                return escapeSpells.ToWeightedRandom(Game).ChooseOrDefault();
            }
        }
        // Priority Two: If we're hurt, always use a random healing spell if we have one
        if (Health < MaxHealth / 3)
        {
            MonsterSpellList healingSpells = spells.Where((_spell) => _spell.Heals);
            if (healingSpells.Count > 0)
            {
                return healingSpells.ToWeightedRandom(Game).ChooseOrDefault();
            }
        }
        // Priority Three: If we're near the player and have no attack spells, probably use a
        // tactical spell
        MonsterSpellList attackSpells = spells.Where((_spell) => _spell.IsAttack);
        MonsterSpellList tacticalSpells = spells.Where((_spell) => _spell.IsTactical);
        if (Game.Distance(Game.MapY.IntValue, Game.MapX.IntValue, MapY, MapX) < 4 && attackSpells.Count > 0 && this.Game.RandomLessThan(100) < 75)
        {
            if (tacticalSpells.Count > 0)
            {
                return tacticalSpells.ToWeightedRandom(Game).ChooseOrDefault();
            }
        }

        // Priority Four: If we're at less than full health, probably use a healing spell
        if (Health < MaxHealth * 3 / 4 && this.Game.RandomLessThan(100) < 75)
        {
            MonsterSpellList healingSpells = spells.Where((_spell) => _spell.Heals);
            if (healingSpells.Count > 0)
            {
                return healingSpells.ToWeightedRandom(Game).ChooseOrDefault();
            }
        }
        // Priority Five: If we have a summoning spell, maybe use it
        MonsterSpellList summonSpells = spells.Where((_spell) => _spell.SummonsHelp);
        if (summonSpells.Count > 0 && this.Game.RandomLessThan(100) < 50)
        {
            return summonSpells.ToWeightedRandom(Game).ChooseOrDefault();
        }

        // Priority Six: If we have a direct attack spell, probably use it
        if (attackSpells.Count > 0 && this.Game.RandomLessThan(100) < 85)
        {
            return attackSpells.ToWeightedRandom(Game).ChooseOrDefault();
        }

        // Priority Seven: If we have a tactical spell, maybe use it
        if (tacticalSpells.Count > 0 && this.Game.RandomLessThan(100) < 50)
        {
            return tacticalSpells.ToWeightedRandom(Game).ChooseOrDefault();
        }

        // Priority Eight: If we have a haste spell, maybe use it
        MonsterSpellList hasteSpells = spells.Where((_spell) => _spell.Hastens);
        if (hasteSpells.Count > 0 && this.Game.RandomLessThan(100) < 20 + Race.Speed - Speed)
        {
            return hasteSpells.ToWeightedRandom(Game).ChooseOrDefault();
        }

        // Priority Nine: If we have an annoying spell, probably use it
        MonsterSpellList annoyanceSpells = spells.Where((_spell) => _spell.Annoys);
        if (annoyanceSpells.Count > 0 && this.Game.RandomLessThan(100) < 85)
        {
            return annoyanceSpells.ToWeightedRandom(Game).ChooseOrDefault();
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
    private bool FindSafeSpot(GridCoordinate relativeTarget)
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
                    if (!Game.InBounds(y, x))
                    {
                        continue;
                    }
                    if (!Game.GridPassable(y, x))
                    {
                        continue;
                    }
                    // Make sure the spot is the right distance
                    if (Game.Distance(y, x, MapY, MapY) != d)
                    {
                        continue;
                    }
                    // Reject spots that smell too strongly of the player
                    if (Game.Map.Grid[y][x].ScentAge < Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue].ScentAge)
                    {
                        continue;
                    }
                    if (Game.Map.Grid[y][x].ScentStrength > Game.Map.Grid[MapY][MapY].ScentStrength + (2 * d))
                    {
                        continue;
                    }
                    // Make sure the spot is actually hidden
                    if (!Game.Projectable(y, x, Game.MapY.IntValue, Game.MapX.IntValue))
                    {
                        // If the spot is further from the player than any previously found
                        // spot, remember it
                        int dis = Game.Distance(y, x, Game.MapY.IntValue, Game.MapX.IntValue);
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
    private bool MonsterCheckHitOnPlayer(int attackPower)
    {
        // Straight five percent chance of hit or miss
        int k = this.Game.RandomLessThan(100);
        if (k < 10)
        {
            return k < 5;
        }
        // Otherwise, compare the power and level to the player's armor class
        int i = attackPower + (Level * 3);
        int ac = Game.DisplayedBaseArmorClass.IntValue + Game.ArmorClassBonus;
        return i > 0 && this.Game.DieRoll(i) > ac * 3 / 4;
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
        if (damage < 20 && Game.RandomLessThan(100) >= damage)
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
            while (Game.RandomLessThan(100) < 2)
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