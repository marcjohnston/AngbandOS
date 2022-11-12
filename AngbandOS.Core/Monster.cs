// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.AttackEffects;
using AngbandOS.Core.Interface;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;
using AngbandOS.Projection;
using System;
using System.Threading;

namespace AngbandOS
{
    [Serializable]
    internal class Monster
    {
        public int ConfusionLevel;

        /// <summary>
        /// How far away from the player the monster is
        /// </summary>
        public int DistanceFromPlayer;

        public int Energy;

        public int FearLevel;

        public int FirstHeldItemIndex;
        public int Generation;
        public int Health;
        public int IndividualMonsterFlags;
        public bool IsVisible;
        public int MapX;
        public int MapY;
        public int MaxHealth;
        public uint Mind;
        public MonsterRace Race;

        /// <summary>
        /// How deeply the monster is sleeping
        /// </summary>
        public int SleepLevel;

        public int Speed;
        public int StolenGold;
        public int StunLevel;
        private static readonly string[] _funnyComments = { "Wow, cosmic, man!", "Rad!", "Groovy!", "Cool!", "Far out!" };
        private readonly SaveGame SaveGame;

        public Monster(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        private static readonly string[] _funnyDesc =
        {
            "silly", "hilarious", "absurd", "insipid", "ridiculous", "laughable", "ludicrous", "far-out", "groovy",
            "postmodern", "fantastic", "dadaistic", "cubistic", "cosmic", "awesome", "incomprehensible", "fabulous",
            "amazing", "incredible", "chaotic", "wild", "preposterous"
        };

        private static readonly string[] _horrorDesc =
        {
            "abominable", "abysmal", "appalling", "baleful", "blasphemous", "disgusting", "dreadful", "filthy",
            "grisly", "hideous", "hellish", "horrible", "infernal", "loathsome", "nightmarish", "repulsive",
            "sacrilegious", "terrible", "unclean", "unspeakable"
        };

        /// <summary>
        /// </summary>
        /// <param name="mode"> </param>
        /// <returns> </returns>
        public string MonsterDesc(int mode)
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
            if (SaveGame.Player.TimedHallucinations != 0)
            {
                MonsterRace halluRace;
                do
                {
                    halluRace = SaveGame.MonsterRaces[Program.Rng.DieRoll(SaveGame.MonsterRaces.Count - 2)];
                } while ((halluRace.Flags1 & MonsterFlag1.Unique) != 0);
                string sillyName = halluRace.Name;
                name = sillyName;
            }
            bool seen = (mode & 0x80) != 0 || ((mode & 0x40) == 0 && IsVisible);
            bool pron = (seen && (mode & 0x20) != 0) || (!seen && (mode & 0x10) != 0);
            if (!seen || pron)
            {
                int kind = 0x00;
                if ((Race.Flags1 & MonsterFlag1.Female) != 0)
                {
                    kind = 0x20;
                }
                else if ((Race.Flags1 & MonsterFlag1.Male) != 0)
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
                if ((Race.Flags1 & MonsterFlag1.Female) != 0)
                {
                    desc = "herself";
                }
                else if ((Race.Flags1 & MonsterFlag1.Male) != 0)
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
                if ((Race.Flags1 & MonsterFlag1.Unique) != 0 && SaveGame.Player.TimedHallucinations == 0)
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
                    desc = (Mind & Constants.SmFriendly) != 0 ? "your " : "the ";
                    desc += name;
                }
                if ((mode & 0x02) != 0)
                {
                    desc += "'s";
                }
            }
            return desc;
        }

        public void SanityBlast(SaveGame saveGame, bool necro)
        {
            Player player = SaveGame.Player;
            bool happened = false;
            int power = 100;
            if (necro)
            {
                SaveGame.MsgPrint("Your sanity is shaken by reading the Necronomicon!");
            }
            else
            {
                power = Race.Level + 10;
                string mName = MonsterDesc(0);
                if ((Race.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    power *= 2;
                }
                else
                {
                    if ((Race.Flags1 & MonsterFlag1.Friends) != 0)
                    {
                        power /= 2;
                    }
                }
                if (!SaveGame.HackMind)
                {
                    return;
                }
                if (!IsVisible)
                {
                    return;
                }
                if ((Race.Flags2 & MonsterFlag2.EldritchHorror) == 0)
                {
                    return;
                }
                if ((Mind & Constants.SmFriendly) != 0 && Program.Rng.DieRoll(8) != 1)
                {
                    return;
                }
                if (Program.Rng.DieRoll(power) < player.SkillSavingThrow)
                {
                    return;
                }
                if (player.TimedHallucinations != 0)
                {
                    SaveGame.MsgPrint($"You behold the {_funnyDesc[Program.Rng.DieRoll(Constants.MaxFunny) - 1]} visage of {mName}!");
                    if (Program.Rng.DieRoll(3) == 1)
                    {
                        SaveGame.MsgPrint(_funnyComments[Program.Rng.DieRoll(Constants.MaxComment) - 1]);
                        player.TimedHallucinations += Program.Rng.DieRoll(Race.Level);
                    }
                    return;
                }
                SaveGame.MsgPrint($"You behold the {_horrorDesc[Program.Rng.DieRoll(Constants.MaxHorror) - 1]} visage of {mName}!");
                Race.Knowledge.RFlags2 |= MonsterFlag2.EldritchHorror;

                // Allow the race to resist.
                if (Program.Rng.DieRoll(100) < player.Race.ChanceOfSanityBlastImmunity(player.Level))
                {
                    return;
                }
            }
            if (Program.Rng.DieRoll(power) < player.SkillSavingThrow)
            {
                if (!player.HasConfusionResistance)
                {
                    player.SetTimedConfusion(player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                }
                if (!player.HasChaosResistance && Program.Rng.DieRoll(3) == 1)
                {
                    player.SetTimedHallucinations(player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 150);
                }
                return;
            }
            if (Program.Rng.DieRoll(power) < player.SkillSavingThrow)
            {
                player.TryDecreasingAbilityScore(Ability.Intelligence);
                player.TryDecreasingAbilityScore(Ability.Wisdom);
                return;
            }
            if (Program.Rng.DieRoll(power) < player.SkillSavingThrow)
            {
                if (!player.HasConfusionResistance)
                {
                    player.SetTimedConfusion(player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                }
                if (!player.HasFreeAction)
                {
                    player.SetTimedParalysis(player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4);
                }
                while (Program.Rng.RandomLessThan(100) > player.SkillSavingThrow)
                {
                    player.TryDecreasingAbilityScore(Ability.Intelligence);
                }
                while (Program.Rng.RandomLessThan(100) > player.SkillSavingThrow)
                {
                    player.TryDecreasingAbilityScore(Ability.Wisdom);
                }
                if (!player.HasChaosResistance)
                {
                    player.SetTimedHallucinations(player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 150);
                }
                return;
            }
            if (Program.Rng.DieRoll(power) < player.SkillSavingThrow)
            {
                if (player.DecreaseAbilityScore(Ability.Intelligence, 10, true))
                {
                    happened = true;
                }
                if (player.DecreaseAbilityScore(Ability.Wisdom, 10, true))
                {
                    happened = true;
                }
                if (happened)
                {
                    SaveGame.MsgPrint("You feel much less sane than before.");
                }
                return;
            }
            if (Program.Rng.DieRoll(power) < player.SkillSavingThrow)
            {
                if (SaveGame.LoseAllInfo())
                {
                    SaveGame.MsgPrint("You forget everything in your utmost terror!");
                }
                return;
            }
            SaveGame.MsgPrint("The exposure to eldritch forces warps you.");
            player.Dna.GainMutation(saveGame);
            player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            SaveGame.HandleStuff();
        }

        /// <summary>
        /// Have an individual monster take its turn
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <param name="noise"> The amount of noise the player is making </param>
        public void ProcessMonster(SaveGame saveGame, uint noise)
        {
            // Is the monster asleep?
            if (SleepLevel != 0)
            {
                // if the player aggravates, notice them more
                uint notice = 0;
                if (!saveGame.Player.HasAggravation)
                {
                    notice = (uint)Program.Rng.RandomLessThan(1024);
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
                    if (saveGame.Player.HasAggravation)
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
                            string monsterName = MonsterDesc(0);
                            saveGame.MsgPrint($"{monsterName} wakes up.");
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
                if (Program.Rng.RandomLessThan(5000) <= Race.Level * Race.Level)
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
                        string monsterName = MonsterDesc(0);
                        saveGame.MsgPrint($"{monsterName} is no longer stunned.");
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
                int confusionRelief = Program.Rng.DieRoll((Race.Level / 10) + 1);
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
                        string monsterName = MonsterDesc(0);
                        saveGame.MsgPrint($"{monsterName} is no longer confused.");
                    }
                }
            }
            // If we're curently friendly and the player aggravates, then stop being friendly
            bool getsAngry = false;
            if ((Mind & Constants.SmFriendly) != 0 && saveGame.Player.HasAggravation)
            {
                getsAngry = true;
            }
            // If we're unique, don't stay friendly
            if ((Mind & Constants.SmFriendly) != 0 && !saveGame.Player.IsWizard && (Race.Flags1 & MonsterFlag1.Unique) != 0)
            {
                getsAngry = true;
            }
            // If we got angry, let the player see that
            if (getsAngry)
            {
                string monsterName = MonsterDesc(0);
                saveGame.MsgPrint($"{monsterName} suddenly becomes hostile!");
                Mind &= ~Constants.SmFriendly;
            }
            // Are we afraid?
            if (FearLevel != 0)
            {
                // Reduce our fear by an amount based on our saveGame.Level
                int fearRelief = Program.Rng.DieRoll((Race.Level / 10) + 1);
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
                        string monsterName = MonsterDesc(0);
                        string monsterPossessive = MonsterDesc(0x22);
                        saveGame.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                    }
                }
            }
            int oldY = MapY;
            int oldX = MapX;
            // If it's suitable for us to reproduce
            if ((Race.Flags2 & MonsterFlag2.Multiply) != 0 && saveGame.Level.Monsters.NumRepro < Constants.MaxRepro && Generation < 10)
            {
                // Find how many spaces we've got near us
                int k;
                int y;
                for (k = 0, y = oldY - 1; y <= oldY + 1; y++)
                {
                    for (int x = oldX - 1; x <= oldX + 1; x++)
                    {
                        if (saveGame.Level.Grid[y][x].MonsterIndex != 0)
                        {
                            k++;
                        }
                    }
                }
                // If we're friendly, then our babies are friendly too
                bool isFriend = (Mind & Constants.SmFriendly) != 0;
                // If there's lots of space, then pop out a baby
                if (k < 4 && (k == 0 || Program.Rng.RandomLessThan(k * Constants.MonMultAdj) == 0))
                {
                    if (saveGame.Level.Monsters.MultiplyMonster(this, isFriend, false))
                    {
                        // If the player saw this, they now know we can multiply
                        if (IsVisible)
                        {
                            Race.Knowledge.RFlags2 |= MonsterFlag2.Multiply;
                        }
                        // Having a baby takes our entire turn
                        return;
                    }
                }
            }
            // If we can usefully cast a spell against the player, then that's our turn
            if (TryCastingASpellAgainstPlayer(saveGame))
            {
                return;
            }
            // If we can usefully cast a spell against another monster, then that's our turn
            if (TryCastingASpellAgainstAnotherMonster(saveGame))
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
            else if ((Race.Flags1 & MonsterFlag1.RandomMove50) != 0 && (Race.Flags1 & MonsterFlag1.RandomMove25) != 0 && Program.Rng.RandomLessThan(100) < 75)
            {
                // If the player sees us, then they learn about our random movement
                if (IsVisible)
                {
                    Race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove50;
                    Race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove25;
                }
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we have a moderate chance of moving randomly, maybe put four random moves in our matrix
            else if ((Race.Flags1 & MonsterFlag1.RandomMove50) != 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                // If the player sees us, then they learn about our random movement
                if (IsVisible)
                {
                    Race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove50;
                }
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we have a low chance of moving randomly, maybe put four random moves in our matrix
            else if ((Race.Flags1 & MonsterFlag1.RandomMove25) != 0 && Program.Rng.RandomLessThan(100) < 25)
            {
                // If the player sees us, then they learn about our random movement
                if (IsVisible)
                {
                    Race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove25;
                }
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we're the player's friend and we're too far away, add sensible moves to our matrix
            else if ((Mind & Constants.SmFriendly) != 0)
            {
                if (DistanceFromPlayer > Constants.FollowDistance)
                {
                    GetMovesTowardsPlayer(saveGame, potentialMoves);
                }
                else
                {
                    // If we're close to the player (and friendly) just use random moves
                    potentialMoves[0] = 5;
                    potentialMoves[1] = 5;
                    potentialMoves[2] = 5;
                    potentialMoves[3] = 5;
                    // Possibly override these random moves with attacks on enemies
                    GetMovesTowardsEnemyMonsters(saveGame, potentialMoves);
                }
            }
            // If all the above fail, we must be a hostile monster who wants to move towards the player
            else
            {
                // If we fail to get sensible moves, give up on our turn
                if (!GetMovesTowardsPlayer(saveGame, potentialMoves))
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
                    d = saveGame.Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
                }
                // Work out where the move will take us
                int newY = oldY + saveGame.Level.KeypadDirectionYOffset[d];
                int newX = oldX + saveGame.Level.KeypadDirectionXOffset[d];
                GridTile tile = saveGame.Level.Grid[newY][newX];
                Monster monsterInTargetTile = saveGame.Level.Monsters[tile.MonsterIndex];
                // If we can simply move there, then we will do so
                if (saveGame.Level.GridPassable(newY, newX))
                {
                    doMove = true;
                }
                // Bushes don't actually block us, so we can move there too
                else if (saveGame.Level.Grid[newY][newX].FeatureType.Name == "Bush")
                {
                    doMove = true;
                }
                // We can always attack the player, even if the move would otherwse not be allowed
                else if (newY == saveGame.Player.MapY && newX == saveGame.Player.MapX)
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
                else if ((Race.Flags2 & MonsterFlag2.PassWall) != 0)
                {
                    doMove = true;
                    didPassWall = true;
                }
                // If we can tunnel through walls then they don't block us
                else if ((Race.Flags2 & MonsterFlag2.KillWall) != 0)
                {
                    doMove = true;
                    didKillWall = true;
                    // Occasionally make a noise if we're going to tunnel
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        saveGame.MsgPrint("There is a grinding sound.");
                    }
                    // Remove the wall (and the player's memory of it) and remind ourselves to
                    // update the view if the player can see it
                    tile.TileFlags.Clear(GridTile.PlayerMemorised);
                    saveGame.Level.RevertTileToBackground(newY, newX);
                    if (saveGame.Level.PlayerHasLosBold(newY, newX))
                    {
                        doView = true;
                    }
                }
                // If we're trying to get through a door
                else if (tile.FeatureType.IsClosedDoor)
                {
                    bool mayBash = true;
                    doTurn = true;
                    // If we can open the door then try to do so
                    if ((Race.Flags2 & MonsterFlag2.OpenDoor) != 0)
                    {
                        // We can always open unlocked doors
                        if (tile.FeatureType.Name == "LockedDoor0" || tile.FeatureType.Name == "SecretDoor")
                        {
                            didOpenDoor = true;
                            mayBash = false;
                        }
                        // We have a chance to unlock locked doors
                        else if (tile.FeatureType.Name.Contains("Locked"))
                        {
                            int k = int.Parse(tile.FeatureType.Name.Substring(10));
                            if (Program.Rng.RandomLessThan(Health / 10) > k)
                            {
                                saveGame.Level.CaveSetFeat(newY, newX, "LockedDoor0");
                                mayBash = false;
                            }
                        }
                    }
                    // If we can't open doors (or failed to unlock the door), then we can bash it down
                    if (mayBash && (Race.Flags2 & MonsterFlag2.BashDoor) != 0)
                    {
                        int k = int.Parse(tile.FeatureType.Name.Substring(10));
                        // If we succeeded, let the player hear it
                        if (Program.Rng.RandomLessThan(Health / 10) > k)
                        {
                            saveGame.MsgPrint("You hear a door burst open!");
                            didBashDoor = true;
                            doMove = true;
                        }
                    }
                    // If we opened it or bashed it, replace the closed door with the relevant open
                    // or broken one
                    if (didOpenDoor || didBashDoor)
                    {
                        if (didBashDoor && Program.Rng.RandomLessThan(100) < 50)
                        {
                            saveGame.Level.CaveSetFeat(newY, newX, "BrokenDoor");
                        }
                        else
                        {
                            saveGame.Level.CaveSetFeat(newY, newX, "OpenDoor");
                        }
                        // If the player can see, remind ourselves to update the view later
                        if (saveGame.Level.PlayerHasLosBold(newY, newX))
                        {
                            doView = true;
                        }
                    }
                }
                // If we're going to move onto an Elder Sign and we're capable of doing attacks
                if (doMove && tile.FeatureType.Name == "ElderSign" && (Race.Flags1 & MonsterFlag1.NeverAttack) == 0)
                {
                    // Assume we're not moving
                    doMove = false;
                    // We have a chance of breaking the sign based on our saveGame.Level
                    if (Program.Rng.DieRoll(Constants.BreakElderSign) < Race.Level)
                    {
                        // If the player knows the sign is there, let them know it was broken
                        if (tile.TileFlags.IsSet(GridTile.PlayerMemorised))
                        {
                            saveGame.MsgPrint("The Elder Sign is broken!");
                        }
                        tile.TileFlags.Clear(GridTile.PlayerMemorised);
                        saveGame.Level.RevertTileToBackground(newY, newX);
                        // Breaking the sign means we can move after all
                        doMove = true;
                    }
                }
                // If we're going to move onto a Yellow Sign and we can attack
                else if (doMove && tile.FeatureType.Name == "YellowSign" &&
                         (Race.Flags1 & MonsterFlag1.NeverAttack) == 0)
                {
                    // Assume we're not moving
                    doMove = false;
                    // We have a chance to break the sign
                    if (Program.Rng.DieRoll(Constants.BreakYellowSign) < Race.Level)
                    {
                        // If the player knows about the sign, let them know it was broken
                        if (tile.TileFlags.IsSet(GridTile.PlayerMemorised))
                        {
                            // If the player was on the sign, hurt them
                            if (newY == saveGame.Player.MapY && newX == saveGame.Player.MapX)
                            {
                                saveGame.MsgPrint("The rune explodes!");
                                saveGame.FireBall(new ProjectMana(saveGame), 0, 2 * ((saveGame.Player.Level / 2) + Program.Rng.DiceRoll(7, 7)), 2);
                            }
                            else
                            {
                                saveGame.MsgPrint("An Yellow Sign was disarmed.");
                            }
                        }
                        tile.TileFlags.Clear(GridTile.PlayerMemorised);
                        saveGame.Level.RevertTileToBackground(newY, newX);
                        // We can do the move after all
                        doMove = true;
                    }
                }
                // If we're going to attack the player, but our race never attacks, then cancel the move
                if (doMove && newY == saveGame.Player.MapY && newX == saveGame.Player.MapX && (Race.Flags1 & MonsterFlag1.NeverAttack) != 0)
                {
                    doMove = false;
                }
                // If we're trying to move onto the player, then attack them instead
                if (doMove && newY == saveGame.Player.MapY && newX == saveGame.Player.MapX)
                {
                    MonsterAttackPlayer(saveGame);
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
                    if ((Race.Flags2 & MonsterFlag2.KillBody) != 0 && Race.Mexp > targetMonsterRace.Mexp && saveGame.Level.GridPassable(newY, newX) && !((Mind & Constants.SmFriendly) != 0 && (monsterInTargetTile.Mind & Constants.SmFriendly) != 0))
                    {
                        // Remove the other monster and replace it
                        doMove = true;
                        didKillBody = true;
                        saveGame.Level.DeleteMonster(newY, newX);
                        monsterInTargetTile = saveGame.Level.Monsters[tile.MonsterIndex];
                    }
                    // If we're not on the same team as the other monster or we're confused
                    else if ((Mind & Constants.SmFriendly) != (monsterInTargetTile.Mind & Constants.SmFriendly) || ConfusionLevel != 0)
                    {
                        doMove = false;
                        // Attack the monster in the target tile
                        if (monsterInTargetTile.Race != null && monsterInTargetTile.Health >= 0)
                        {
                            if (AttackAnotherMonster(saveGame, tile.MonsterIndex))
                            {
                                return;
                            }
                        }
                    }
                    // If the other monster is on our team and we can't trample it, maybe we can
                    // push past
                    else if ((Race.Flags2 & MonsterFlag2.MoveBody) != 0 && Race.Mexp > targetMonsterRace.Mexp && saveGame.Level.GridPassable(newY, newX) && saveGame.Level.GridPassable(MapY, MapX))
                    {
                        doMove = true;
                        didMoveBody = true;
                    }
                }
                // If we're going to do a move but we can't move, cancel it
                if (doMove && (Race.Flags1 & MonsterFlag1.NeverMove) != 0)
                {
                    doMove = false;
                }
                // If we're going to do a move
                if (doMove)
                {
                    int nextItemIndex;
                    doTurn = true;
                    // Swap positions with the monster that is in the tile we're aiming for
                    saveGame.Level.Grid[oldY][oldX].MonsterIndex = tile.MonsterIndex;
                    // If it was actually a monster then update it accordingly
                    if (tile.MonsterIndex != 0)
                    {
                        monsterInTargetTile.MapY = oldY;
                        monsterInTargetTile.MapX = oldX;
                        saveGame.Level.Monsters.UpdateMonsterVisibility(tile.MonsterIndex, true);
                        // Pushing past something wakes it up
                        saveGame.Level.Monsters[tile.MonsterIndex].SleepLevel = 0;
                    }
                    // Update our position
                    tile.MonsterIndex = GetMonsterIndex(saveGame);
                    MapY = newY;
                    MapX = newX;
                    saveGame.Level.Monsters.UpdateMonsterVisibility(GetMonsterIndex(saveGame), true);
                    saveGame.Level.RedrawSingleLocation(oldY, oldX);
                    saveGame.Level.RedrawSingleLocation(newY, newX);
                    // If we are hostile and the player saw us move, then saveGame.Disturb them
                    if (IsVisible && (IndividualMonsterFlags & Constants.MflagView) != 0)
                    {
                        if ((Mind & Constants.SmFriendly) == 0)
                        {
                            saveGame.Disturb(false);
                        }
                    }
                    // Check through the items in the tile we just entered
                    for (int thisItemIndex = tile.ItemIndex; thisItemIndex != 0; thisItemIndex = nextItemIndex)
                    {
                        Item item = saveGame.Level.Items[thisItemIndex];
                        nextItemIndex = item.NextInStack;
                        // We ignore gold
                        if (item.Category == ItemCategory.Gold)
                        {
                            continue;
                        }
                        // If we pick up or stomp on items, check the item type
                        if (((Race.Flags2 & MonsterFlag2.TakeItem) != 0 || (Race.Flags2 & MonsterFlag2.KillItem) != 0) && (Mind & Constants.SmFriendly) == 0)
                        {
                            uint flg3 = 0;
                            item.RefreshFlagBasedProperties();
                            string itemName = item.Description(true, 3);
                            string monsterName = MonsterDesc(0x04);
                            if (item.Characteristics.KillDragon)
                            {
                                flg3 |= MonsterFlag3.Dragon;
                            }
                            if (item.Characteristics.SlayDragon)
                            {
                                flg3 |= MonsterFlag3.Dragon;
                            }
                            if (item.Characteristics.SlayTroll)
                            {
                                flg3 |= MonsterFlag3.Troll;
                            }
                            if (item.Characteristics.SlayGiant)
                            {
                                flg3 |= MonsterFlag3.Giant;
                            }
                            if (item.Characteristics.SlayOrc)
                            {
                                flg3 |= MonsterFlag3.Orc;
                            }
                            if (item.Characteristics.SlayDemon)
                            {
                                flg3 |= MonsterFlag3.Demon;
                            }
                            if (item.Characteristics.SlayUndead)
                            {
                                flg3 |= MonsterFlag3.Undead;
                            }
                            if (item.Characteristics.SlayAnimal)
                            {
                                flg3 |= MonsterFlag3.Animal;
                            }
                            if (item.Characteristics.SlayEvil)
                            {
                                flg3 |= MonsterFlag3.Evil;
                            }
                            // Monsters won't pick up artifacts or items that hurt them
                            if (item.IsFixedArtifact() || (Race.Flags3 & flg3) != 0 || !string.IsNullOrEmpty(item.RandartName))
                            {
                                if ((Race.Flags2 & MonsterFlag2.TakeItem) != 0)
                                {
                                    didTakeItem = true;
                                    if (IsVisible && saveGame.Level.PlayerHasLosBold(newY, newX))
                                    {
                                        saveGame.MsgPrint($"{monsterName} tries to pick up {itemName}, but fails.");
                                    }
                                }
                            }
                            // If we picked up the item and the player saw, let them know
                            else if ((Race.Flags2 & MonsterFlag2.TakeItem) != 0)
                            {
                                didTakeItem = true;
                                if (saveGame.Level.PlayerHasLosBold(newY, newX))
                                {
                                    saveGame.MsgPrint($"{monsterName} picks up {itemName}.");
                                }
                                // And pick up the actual item
                                saveGame.Level.ExciseObjectIdx(thisItemIndex);
                                item.Marked = false;
                                item.Y = 0;
                                item.X = 0;
                                item.HoldingMonsterIndex = GetMonsterIndex(saveGame);
                                item.NextInStack = FirstHeldItemIndex;
                                FirstHeldItemIndex = thisItemIndex;
                            }
                            else
                            {
                                // We can't pick up the item, so just stomp on it
                                didKillItem = true;
                                // If the player saw us, let them know
                                if (saveGame.Level.PlayerHasLosBold(newY, newX))
                                {
                                    saveGame.MsgPrint($"{monsterName} crushes {itemName}.");
                                }
                                saveGame.Level.DeleteObjectIdx(thisItemIndex);
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
            if (!doTurn && !doMove && FearLevel == 0 && (Mind & Constants.SmFriendly) == 0)
            {
                if (TryCastingASpellAgainstPlayer(saveGame))
                {
                    return;
                }
            }
            // Update the view if necessary
            if (doView)
            {
                saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateMonsters);
            }
            // If we did something unusual and the player saw, let them remember we can do that
            if (IsVisible)
            {
                if (didOpenDoor)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.OpenDoor;
                }
                if (didBashDoor)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.BashDoor;
                }
                if (didTakeItem)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.TakeItem;
                }
                if (didKillItem)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.KillItem;
                }
                if (didMoveBody)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.MoveBody;
                }
                if (didKillBody)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.KillBody;
                }
                if (didPassWall)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.PassWall;
                }
                if (didKillWall)
                {
                    Race.Knowledge.RFlags2 |= MonsterFlag2.KillWall;
                }
            }
            // If we couldn't do anything because we were afraid and cornered, lose our fear
            if (!doTurn && !doMove && FearLevel != 0)
            {
                FearLevel = 0;
                if (IsVisible)
                {
                    string monsterName = MonsterDesc(0);
                    saveGame.MsgPrint($"{monsterName} turns to fight!");
                }
            }
        }
        /// <summary>
        /// Make a set of attacks on another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster making the attack </param>
        /// <param name="targetIndex"> The index of the target monster </param>
        /// <returns> True if the attack happened, false if not </returns>
        private bool AttackAnotherMonster(SaveGame saveGame, int targetIndex)
        {
            Monster target = saveGame.Level.Monsters[targetIndex];
            MonsterRace targetRace = target.Race;
            bool touched = false;
            int ySaver = target.MapY;
            int xSaver = target.MapX;
            // If we never attack then we shouldn't this time
            if ((Race.Flags1 & MonsterFlag1.NeverAttack) != 0)
            {
                return false;
            }
            int armourClass = targetRace.ArmourClass;
            int monsterLevel = Race.Level >= 1 ? Race.Level : 1;
            string monsterName = MonsterDesc(0);
            string targetName = target.MonsterDesc(0);
            MonsterDesc(0x88);
            bool blinked = false;
            // If the player can't see either monster, they just hear noise
            if (!(IsVisible || target.IsVisible))
            {
                saveGame.MsgPrint("You hear noise.");
            }
            // We have up to four attacks
            if (Race.Attacks != null)
            {
                for (int attackNumber = 0; attackNumber < Race.Attacks.Length; attackNumber++)
                {
                    bool visible = false;
                    bool obvious = false;
                    int power = 0;
                    int damage = 0;
                    string act = null;
                    BaseAttackEffect effect = Race.Attacks[attackNumber].Effect;
                    AttackType method = Race.Attacks[attackNumber].Method;
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
                    // If we don't have an attack in this attack slot, abort
                    if (method == 0)
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
                    // Get the power of the attack based on the attack type
                    power = effect.Power;

                    // If we hit the monster, describe the type of hit
                    if (effect == null || CheckHitMonsterVersusMonster(power, monsterLevel, armourClass))
                    {
                        saveGame.Disturb(true);
                        switch (method)
                        {
                            case AttackType.Hit:
                                act = "hits {0}.";
                                touched = true;
                                break;

                            case AttackType.Touch:
                                act = "touches {0}.";
                                touched = true;
                                break;

                            case AttackType.Punch:
                                act = "punches {0}.";
                                touched = true;
                                break;

                            case AttackType.Kick:
                                act = "kicks {0}.";
                                touched = true;
                                break;

                            case AttackType.Claw:
                                act = "claws {0}.";
                                touched = true;
                                break;

                            case AttackType.Bite:
                                act = "bites {0}.";
                                touched = true;
                                break;

                            case AttackType.Sting:
                                act = "stings {0}.";
                                touched = true;
                                break;

                            case AttackType.Butt:
                                act = "butts {0}.";
                                touched = true;
                                break;

                            case AttackType.Crush:
                                act = "crushes {0}.";
                                touched = true;
                                break;

                            case AttackType.Engulf:
                                act = "engulfs {0}.";
                                touched = true;
                                break;

                            case AttackType.Charge:
                                act = "charges {0}.";
                                touched = true;
                                break;

                            case AttackType.Crawl:
                                act = "crawls on {0}.";
                                touched = true;
                                break;

                            case AttackType.Drool:
                                act = "drools on {0}.";
                                touched = false;
                                break;

                            case AttackType.Spit:
                                act = "spits on {0}.";
                                touched = false;
                                break;

                            case AttackType.Gaze:
                                act = "gazes at {0}.";
                                touched = false;
                                break;

                            case AttackType.Wail:
                                act = "wails at {0}.";
                                touched = false;
                                break;

                            case AttackType.Spore:
                                act = "releases spores at {0}.";
                                touched = false;
                                break;

                            case AttackType.Worship:
                                act = "hero worships {0}.";
                                touched = false;
                                break;

                            case AttackType.Beg:
                                act = "begs {0} for money.";
                                touched = false;
                                target.SleepLevel = 0;
                                break;

                            case AttackType.Insult:
                                act = "insults {0}.";
                                touched = false;
                                target.SleepLevel = 0;
                                break;

                            case AttackType.Moan:
                                act = "moans at {0}.";
                                touched = false;
                                target.SleepLevel = 0;
                                break;

                            case AttackType.Show:
                                act = "sings to {0}.";
                                touched = false;
                                target.SleepLevel = 0;
                                break;
                        }
                        // Display the attack description
                        if (!string.IsNullOrEmpty(act))
                        {
                            string temp = string.Format(act, targetName);
                            if (IsVisible || target.IsVisible)
                            {
                                saveGame.MsgPrint($"{monsterName} {temp}");
                            }
                        }
                        obvious = true;
                        damage = Program.Rng.DiceRoll(dDice, dSide);
                        // Default to a missile attack
                        Projectile pt = new ProjectMissile(saveGame);
                        // Choose the correct type of attack to display, as well as any other special
                        // effects for the attack
                        if (effect == null)
                        {
                            damage = 0;
                            pt = null;
                        }
                        else
                            effect.ApplyToMonster(saveGame, this, armourClass, ref damage, ref pt, ref blinked);

                        // Implement the attack as a projectile
                        if (pt != null)
                        {
                            saveGame.Project(GetMonsterIndex(saveGame), 0, target.MapY, target.MapX, damage, pt, ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                            // If we touched the target we might get burned or zapped
                            if (touched)
                            {
                                if ((targetRace.Flags2 & MonsterFlag2.FireAura) != 0 && (Race.Flags3 & MonsterFlag3.ImmuneFire) == 0)
                                {
                                    if (IsVisible || target.IsVisible)
                                    {
                                        // Auras prevent us blinking away
                                        blinked = false;
                                        // The player may see and learn that the target has the aura
                                        saveGame.MsgPrint($"{monsterName} is suddenly very hot!");
                                        if (target.IsVisible)
                                        {
                                            targetRace.Knowledge.RFlags2 |= MonsterFlag2.FireAura;
                                        }
                                    }
                                    saveGame.Project(targetIndex, 0, MapY, MapX, Program.Rng.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)), new ProjectFire(saveGame), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                                }
                                if ((targetRace.Flags2 & MonsterFlag2.LightningAura) != 0 && (Race.Flags3 & MonsterFlag3.ImmuneLightning) == 0)
                                {
                                    if (IsVisible || target.IsVisible)
                                    {
                                        // Auras prevent us blinking away
                                        blinked = false;
                                        // The player may see and learn that the target has the aura
                                        saveGame.MsgPrint($"{monsterName} gets zapped!");
                                        if (target.IsVisible)
                                        {
                                            targetRace.Knowledge.RFlags2 |= MonsterFlag2.LightningAura;
                                        }
                                    }
                                    saveGame.Project(targetIndex, 0, MapY, MapX, Program.Rng.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)),
                                        new ProjectElec(saveGame), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                                }
                            }
                        }
                    }
                    else
                    {
                        // We didn't hit, so just let the player know that if we are visible
                        switch (method)
                        {
                            case AttackType.Hit:
                            case AttackType.Touch:
                            case AttackType.Punch:
                            case AttackType.Kick:
                            case AttackType.Claw:
                            case AttackType.Bite:
                            case AttackType.Sting:
                            case AttackType.Butt:
                            case AttackType.Crush:
                            case AttackType.Engulf:
                            case AttackType.Charge:
                                if (IsVisible)
                                {
                                    saveGame.Disturb(false);
                                    saveGame.MsgPrint($"{monsterName} misses {targetName}.");
                                }
                                break;
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
            }
            // If we stole and should therefore blink away, then do so.
            if (blinked)
            {
                saveGame.MsgPrint(IsVisible ? "The thief flees laughing!" : "You hear laughter!");
                TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
            }
            // We made the attack
            return true;
        }

        /// <summary>
        /// Choose and use an attack spell to cast when in combat with the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <returns> True if a spell was cast, false if not </returns>
        private bool TryCastingASpellAgainstPlayer(SaveGame saveGame)
        {
            int k;
            int[] spell = new int[96];
            int num = 0;
            bool noInnate = false;
            int playerX = saveGame.Player.MapX;
            int playerY = saveGame.Player.MapY;
            int count = 0;
            bool playerIsBlind = saveGame.Player.TimedBlindness != 0;
            bool seenByPlayer = !playerIsBlind && IsVisible;
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
            if ((Mind & Constants.SmFriendly) != 0)
            {
                return false;
            }
            // We aren't guaranteed to cast a spell even if we can
            int chance = Race.FrequencyChance;
            if (chance == 0)
            {
                return false;
            }
            if (Program.Rng.RandomLessThan(100) >= chance)
            {
                return false;
            }
            // Innate abilities are inherently less likely than actual spells
            if (Program.Rng.RandomLessThan(100) >= chance * 2)
            {
                noInnate = true;
            }
            // If we're too far from the player don't cast a spell
            if (DistanceFromPlayer > Constants.MaxRange)
            {
                return false;
            }
            // If we have no line of sight to the player, don't cast a spell
            if (!saveGame.Level.Projectable(MapY, MapX, saveGame.Player.MapY, saveGame.Player.MapX))
            {
                return false;
            }
            // Gather together the abilities we have
            int monsterLevel = Race.Level >= 1 ? Race.Level : 1;
            uint f4 = Race.Flags4;
            uint f5 = Race.Flags5;
            uint f6 = Race.Flags6;
            // If we're not allowed innate abilities, then things on Flags4 can't be used
            if (noInnate)
            {
                f4 = 0;
            }
            // If we're smart and badly injured, we may want to prioritise spells that disable the
            // player, summon help, or let us escape over spells that do direct damage
            if ((Race.Flags2 & MonsterFlag2.Smart) != 0 && Health < MaxHealth / 10 && Program.Rng.RandomLessThan(100) < 50)
            {
                f4 &= MonsterFlag4.IntMask;
                f5 &= MonsterFlag5.IntMask;
                f6 &= MonsterFlag6.IntMask;
                // If we just got rid of all our spells then don't cast
                if (f4 == 0 && f5 == 0 && f6 == 0)
                {
                    return false;
                }
            }
            // Ditch any spells that we've seen the player resist before so we know they'll be ineffective
            RemoveIneffectiveSpells(saveGame, out f4, f4, out f5, f5, out f6, f6);
            // If we just got rid of all our spells then don't cast
            if (f4 == 0 && f5 == 0 && f6 == 0)
            {
                return false;
            }
            // If we don't have a clean shot, and we're stupid, remove bolt spells
            if (((f4 & MonsterFlag4.BoltMask) != 0 || (f5 & MonsterFlag5.BoltMask) != 0 || (f6 & MonsterFlag6.BoltMask) != 0) && (Race.Flags2 & MonsterFlag2.Stupid) == 0 && !saveGame.CleanShot(MapY, MapX, saveGame.Player.MapY, saveGame.Player.MapX))
            {
                f4 &= ~MonsterFlag4.BoltMask;
                f5 &= ~MonsterFlag5.BoltMask;
                f6 &= ~MonsterFlag6.BoltMask;
            }
            // If there's nowhere around the player to put a summoned creature, then remove
            // summoning spells
            if (((f4 & MonsterFlag4.SummonMask) != 0 || (f5 & MonsterFlag5.SummonMask) != 0 || (f6 & MonsterFlag6.SummonMask) != 0) && (Race.Flags2 & MonsterFlag2.Stupid) == 0 && !saveGame.SummonPossible(saveGame.Player.MapY, saveGame.Player.MapX))
            {
                f4 &= ~MonsterFlag4.SummonMask;
                f5 &= ~MonsterFlag5.SummonMask;
                f6 &= ~MonsterFlag6.SummonMask;
            }
            // If we've removed all our spells, don't cast anything
            if (f4 == 0 && f5 == 0 && f6 == 0)
            {
                return false;
            }
            // Gather up all the spells that are left and put them in an array Flags4 spells are 96
            // + bit number (0-31)
            for (k = 0; k < 32; k++)
            {
                if ((f4 & (1u << k)) != 0)
                {
                    spell[num++] = k + (32 * 3);
                }
            }
            // Flags5 spells are 128 + bit number (0-31)
            for (k = 0; k < 32; k++)
            {
                if ((f5 & (1u << k)) != 0)
                {
                    spell[num++] = k + (32 * 4);
                }
            }
            // Flags6 spells are 160 + bit number (0-31)
            for (k = 0; k < 32; k++)
            {
                if ((f6 & (1 << k)) != 0)
                {
                    spell[num++] = k + (32 * 5);
                }
            }
            // If we ended up with no spells, don't cast
            if (num == 0)
            {
                return false;
            }
            // If the player's already dead or off the saveGame.Level, don't cast
            if (!saveGame.Playing || saveGame.Player.IsDead || saveGame.NewLevelFlag)
            {
                return false;
            }
            string monsterName = MonsterDesc(0x00);
            string monsterPossessive = MonsterDesc(0x22);
            string monsterDescription = MonsterDesc(0x88);
            // Pick one of our spells to cast, based on our priorities
            int thrownSpell = ChooseSpellAgainstPlayer(saveGame, spell, num);
            // If we decided not to cast, don't
            if (thrownSpell == 0)
            {
                return false;
            }
            // Stupid monsters may fail spells
            int failrate = 25 - ((monsterLevel + 3) / 4);
            if ((Race.Flags2 & MonsterFlag2.Stupid) != 0)
            {
                failrate = 0;
            }
            // Only check for actual spells - nothing is so stupid it fails to breathe
            if (thrownSpell >= 128 && Program.Rng.RandomLessThan(100) < failrate)
            {
                saveGame.MsgPrint($"{monsterName} tries to cast a spell, but fails.");
                return true;
            }
            // Now do whatever the actual spell does
            switch (thrownSpell)
            {
                // MonsterFlag4.Shriek
                case 96 + 0:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} makes a high pitched shriek.");
                    saveGame.AggravateMonsters(GetMonsterIndex(saveGame));
                    break;

                // MonsterFlag4.Xxx2
                case 96 + 1:
                // MonsterFlag4.Xxx3
                case 96 + 2:
                    break;

                // MonsterFlag4.ShardBall
                case 96 + 3:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles something." : $"{monsterName} fires a shard ball.");
                    FireBallAtPlayer(saveGame, new ProjectShard(saveGame), Health / 4 > 800 ? 800 : Health / 4, 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsShard);
                    break;

                // MonsterFlag4.Arrow1D6
                case 96 + 4:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires an arrow.");
                    FireBoltAtPlayer(saveGame, new ProjectArrow(saveGame), Program.Rng.DiceRoll(1, 6));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag4.Arrow3D6
                case 96 + 5:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires an arrow!");
                    FireBoltAtPlayer(saveGame, new ProjectArrow(saveGame), Program.Rng.DiceRoll(3, 6));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag4.Arrow5D6
                case 96 + 6:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName}s makes a strange noise." : $"{monsterName} fires a missile.");
                    FireBoltAtPlayer(saveGame, new ProjectArrow(saveGame), Program.Rng.DiceRoll(5, 6));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag4.Arrow7D6
                case 96 + 7:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires a missile!");
                    FireBoltAtPlayer(saveGame, new ProjectArrow(saveGame), Program.Rng.DiceRoll(7, 6));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag4.BreatheAcid
                case 96 + 8:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes acid.");
                    BreatheAtPlayer(saveGame, new ProjectAcid(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsAcid);
                    break;

                // MonsterFlag4.BreatheLightning
                case 96 + 9:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes lightning.");
                    BreatheAtPlayer(saveGame, new ProjectElec(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsElec);
                    break;

                // MonsterFlag4.BreatheFire
                case 96 + 10:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes fire.");
                    BreatheAtPlayer(saveGame, new ProjectFire(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsFire);
                    break;

                // MonsterFlag4.BreatheCold
                case 96 + 11:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes frost.");
                    BreatheAtPlayer(saveGame, new ProjectCold(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsCold);
                    break;

                // MonsterFlag4.BreathePoison
                case 96 + 12:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes gas.");
                    BreatheAtPlayer(saveGame, new ProjectPois(saveGame), Health / 3 > 800 ? 800 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsPois);
                    break;

                // MonsterFlag4.BreatheNether
                case 96 + 13:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes nether.");
                    BreatheAtPlayer(saveGame, new ProjectNether(saveGame), Health / 6 > 550 ? 550 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsNeth);
                    break;

                // MonsterFlag4.BreatheLight
                case 96 + 14:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes light.");
                    BreatheAtPlayer(saveGame, new ProjectLight(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsLight);
                    break;

                // MonsterFlag4.BreatheDark
                case 96 + 15:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes darkness.");
                    BreatheAtPlayer(saveGame, new ProjectDark(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsDark);
                    break;

                // MonsterFlag4.BreatheConfusion
                case 96 + 16:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes confusion.");
                    BreatheAtPlayer(saveGame, new ProjectConfusion(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsConf);
                    break;

                // MonsterFlag4.BreatheSound
                case 96 + 17:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes sound.");
                    BreatheAtPlayer(saveGame, new ProjectSound(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsSound);
                    break;

                // MonsterFlag4.BreatheChaos
                case 96 + 18:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes chaos.");
                    BreatheAtPlayer(saveGame, new ProjectChaos(saveGame), Health / 6 > 600 ? 600 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsChaos);
                    break;

                // MonsterFlag4.BreatheDisenchant
                case 96 + 19:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes disenchantment.");
                    BreatheAtPlayer(saveGame, new ProjectDisenchant(saveGame), Health / 6 > 500 ? 500 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsDisen);
                    break;

                // MonsterFlag4.BreatheNexus
                case 96 + 20:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes nexus.");
                    BreatheAtPlayer(saveGame, new ProjectNexus(saveGame), Health / 3 > 250 ? 250 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsNexus);
                    break;

                // MonsterFlag4.BreatheTime
                case 96 + 21:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes time.");
                    BreatheAtPlayer(saveGame, new ProjectTime(saveGame), Health / 3 > 150 ? 150 : Health / 3, 0);
                    break;

                // MonsterFlag4.BreatheInertia
                case 96 + 22:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes inertia.");
                    BreatheAtPlayer(saveGame, new ProjectInertia(saveGame), Health / 6 > 200 ? 200 : Health / 6, 0);
                    break;

                // MonsterFlag4.BreatheGravity
                case 96 + 23:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes gravity.");
                    BreatheAtPlayer(saveGame, new ProjectGravity(saveGame), Health / 3 > 200 ? 200 : Health / 3, 0);
                    break;

                // MonsterFlag4.BreatheShards
                case 96 + 24:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes shards.");
                    BreatheAtPlayer(saveGame, new ProjectExplode(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsShard);
                    break;

                // MonsterFlag4.BreathePlasma
                case 96 + 25:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes plasma.");
                    BreatheAtPlayer(saveGame, new ProjectPlasma(saveGame), Health / 6 > 150 ? 150 : Health / 6, 0);
                    break;

                // MonsterFlag4.BreatheForce
                case 96 + 26:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes force.");
                    BreatheAtPlayer(saveGame, new ProjectForce(saveGame), Health / 6 > 200 ? 200 : Health / 6, 0);
                    break;

                // MonsterFlag4.BreatheMana
                case 96 + 27:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes magical energy.");
                    BreatheAtPlayer(saveGame, new ProjectMana(saveGame), Health / 3 > 250 ? 250 : Health / 3, 0);
                    break;

                // MonsterFlag4.RadiationBall
                case 96 + 28:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a ball of radiation.");
                    FireBallAtPlayer(saveGame, new ProjectNuke(saveGame), monsterLevel + Program.Rng.DiceRoll(10, 6), 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsPois);
                    break;

                // MonsterFlag4.BreatheRadiation
                case 96 + 29:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes toxic waste.");
                    BreatheAtPlayer(saveGame, new ProjectNuke(saveGame), Health / 3 > 800 ? 800 : Health / 3, 0);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsPois);
                    break;

                // MonsterFlag4.ChaosBall
                case 96 + 30:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles frighteningly." : $"{monsterName} invokes raw chaos.");
                    FireBallAtPlayer(saveGame, new ProjectChaos(saveGame), (monsterLevel * 2) + Program.Rng.DiceRoll(10, 10), 4);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsChaos);
                    break;

                // MonsterFlag4.BreatheDisintegration
                case 96 + 31:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes disintegration.");
                    BreatheAtPlayer(saveGame, new ProjectDisintegrate(saveGame), Health / 3 > 300 ? 300 : Health / 3, 0);
                    break;

                // MonsterFlag5.AcidBall
                case 128 + 0:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts an acid ball.");
                    FireBallAtPlayer(saveGame, new ProjectAcid(saveGame), Program.Rng.DieRoll(monsterLevel * 3) + 15, 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsAcid);
                    break;

                // MonsterFlag5.LightningBall
                case 128 + 1:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a lightning ball.");
                    FireBallAtPlayer(saveGame, new ProjectElec(saveGame), Program.Rng.DieRoll(monsterLevel * 3 / 2) + 8, 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsElec);
                    break;

                // MonsterFlag5.FireBall
                case 128 + 2:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a fire ball.");
                    FireBallAtPlayer(saveGame, new ProjectFire(saveGame), Program.Rng.DieRoll(monsterLevel * 7 / 2) + 10, 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsFire);
                    break;

                // MonsterFlag5.ColdBall
                case 128 + 3:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a frost ball.");
                    FireBallAtPlayer(saveGame, new ProjectCold(saveGame), Program.Rng.DieRoll(monsterLevel * 3 / 2) + 10, 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsCold);
                    break;

                // MonsterFlag5.PoisonBall
                case 128 + 4:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a stinking cloud.");
                    FireBallAtPlayer(saveGame, new ProjectPois(saveGame), Program.Rng.DiceRoll(12, 2), 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsPois);
                    break;

                // MonsterFlag5.NetherBall
                case 128 + 5:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a nether ball.");
                    FireBallAtPlayer(saveGame, new ProjectNether(saveGame), 50 + Program.Rng.DiceRoll(10, 10) + monsterLevel, 2);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsNeth);
                    break;

                // MonsterFlag5.WaterBall
                case 128 + 6:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} gestures fluidly.");
                    saveGame.MsgPrint("You are engulfed in a whirlpool.");
                    FireBallAtPlayer(saveGame, new ProjectWater(saveGame), Program.Rng.DieRoll(monsterLevel * 5 / 2) + 50, 4);
                    break;

                // MonsterFlag5.ManaBall
                case 128 + 7:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles powerfully." : $"{monsterName} invokes a mana storm.");
                    FireBallAtPlayer(saveGame, new ProjectMana(saveGame), (monsterLevel * 5) + Program.Rng.DiceRoll(10, 10), 4);
                    break;

                // MonsterFlag5.DarkBall
                case 128 + 8:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles powerfully." : $"{monsterName} invokes a darkness storm.");
                    FireBallAtPlayer(saveGame, new ProjectDark(saveGame), (monsterLevel * 5) + Program.Rng.DiceRoll(10, 10), 4);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsDark);
                    break;

                // MonsterFlag5.DrainMana
                case 128 + 9:
                    if (saveGame.Player.Mana != 0)
                    {
                        saveGame.Disturb(true);
                        saveGame.MsgPrint($"{monsterName} draws psychic energy from you!");
                        int r1 = (Program.Rng.DieRoll(monsterLevel) / 2) + 1;
                        if (r1 >= saveGame.Player.Mana)
                        {
                            r1 = saveGame.Player.Mana;
                            saveGame.Player.Mana = 0;
                            saveGame.Player.FractionalMana = 0;
                        }
                        else
                        {
                            saveGame.Player.Mana -= r1;
                        }
                        saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                        if (Health < MaxHealth)
                        {
                            Health += 6 * r1;
                            if (Health > MaxHealth)
                            {
                                Health = MaxHealth;
                            }
                            if (saveGame.TrackedMonsterIndex == GetMonsterIndex(saveGame))
                            {
                                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                            }
                            if (seenByPlayer)
                            {
                                saveGame.MsgPrint($"{monsterName} appears healthier.");
                            }
                        }
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsMana);
                    break;

                // MonsterFlag5.MindBlast
                case 128 + 10:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(!seenByPlayer
                        ? "You feel something focusing on your mind."
                        : $"{monsterName} gazes deep into your eyes.");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.MsgPrint("Your mind is blasted by psionic energy.");
                        if (!saveGame.Player.HasConfusionResistance)
                        {
                            saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                        }
                        if (!saveGame.Player.HasChaosResistance && Program.Rng.DieRoll(3) == 1)
                        {
                            saveGame.Player.SetTimedHallucinations(saveGame.Player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 150);
                        }
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), monsterDescription);
                    }
                    break;

                // MonsterFlag5.BrainSmash
                case 128 + 11:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(!seenByPlayer
                        ? "You feel something focusing on your mind."
                        : $"{monsterName} looks deep into your eyes.");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.MsgPrint("Your mind is blasted by psionic energy.");
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(12, 15), monsterDescription);
                        if (!saveGame.Player.HasBlindnessResistance)
                        {
                            saveGame.Player.SetTimedBlindness(saveGame.Player.TimedBlindness + 8 + Program.Rng.RandomLessThan(8));
                        }
                        if (!saveGame.Player.HasConfusionResistance)
                        {
                            saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                        }
                        if (!saveGame.Player.HasFreeAction)
                        {
                            saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4);
                        }
                        saveGame.Player.SetTimedSlow(saveGame.Player.TimedSlow + Program.Rng.RandomLessThan(4) + 4);
                        while (Program.Rng.RandomLessThan(100) > saveGame.Player.SkillSavingThrow)
                        {
                            saveGame.Player.TryDecreasingAbilityScore(Ability.Intelligence);
                        }
                        while (Program.Rng.RandomLessThan(100) > saveGame.Player.SkillSavingThrow)
                        {
                            saveGame.Player.TryDecreasingAbilityScore(Ability.Wisdom);
                        }
                        if (!saveGame.Player.HasChaosResistance)
                        {
                            saveGame.Player.SetTimedHallucinations(saveGame.Player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 150);
                        }
                    }
                    break;

                // MonsterFlag5.CauseLightWounds
                case 128 + 12:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} points at you and curses.");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.CurseEquipment(33, 0);
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(3, 8), monsterDescription);
                    }
                    break;

                // MonsterFlag5.CauseSeriousWounds
                case 128 + 13:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} points at you and curses horribly.");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.CurseEquipment(50, 5);
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(8, 8), monsterDescription);
                    }
                    break;

                // MonsterFlag5.CauseCriticalWounds
                case 128 + 14:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles loudly."
                        : $"{monsterName} points at you, incanting terribly!");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.CurseEquipment(80, 15);
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(10, 15), monsterDescription);
                    }
                    break;

                // MonsterFlag5.CauseMortalWounds
                case 128 + 15:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} screams the word 'DIE!'"
                        : $"{monsterName} points at you, screaming the word DIE!");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.TakeHit(Program.Rng.DiceRoll(15, 15), monsterDescription);
                        saveGame.Player.SetTimedBleeding(saveGame.Player.TimedBleeding + Program.Rng.DiceRoll(10, 10));
                    }
                    break;

                // MonsterFlag5.AcidBolt
                case 128 + 16:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a acid bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectAcid(saveGame), Program.Rng.DiceRoll(7, 8) + (monsterLevel / 3));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsAcid);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.LightningBolt
                case 128 + 17:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a lightning bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectElec(saveGame), Program.Rng.DiceRoll(4, 8) + (monsterLevel / 3));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsElec);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.FireBolt
                case 128 + 18:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a fire bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectFire(saveGame), Program.Rng.DiceRoll(9, 8) + (monsterLevel / 3));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsFire);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.ColdBolt
                case 128 + 19:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a frost bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectCold(saveGame), Program.Rng.DiceRoll(6, 8) + (monsterLevel / 3));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsCold);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.PoisonBolt
                case 128 + 20:
                    break;

                // MonsterFlag5.NetherBolt
                case 128 + 21:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a nether bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectNether(saveGame), 30 + Program.Rng.DiceRoll(5, 5) + (monsterLevel * 3 / 2));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsNeth);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.WaterBolt
                case 128 + 22:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a water bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectWater(saveGame), Program.Rng.DiceRoll(10, 10) + monsterLevel);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.ManaBolt
                case 128 + 23:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a mana bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectMana(saveGame), Program.Rng.DieRoll(monsterLevel * 7 / 2) + 50);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.PlasmaBolt
                case 128 + 24:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a plasma bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectPlasma(saveGame), 10 + Program.Rng.DiceRoll(8, 7) + monsterLevel);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.IceBolt
                case 128 + 25:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts an ice bolt.");
                    FireBoltAtPlayer(saveGame, new ProjectIce(saveGame), Program.Rng.DiceRoll(6, 6) + monsterLevel);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsCold);
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.MagicMissile
                case 128 + 26:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a magic missile.");
                    FireBoltAtPlayer(saveGame, new ProjectMissile(saveGame), Program.Rng.DiceRoll(2, 6) + (monsterLevel / 3));
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsReflect);
                    break;

                // MonsterFlag5.Scare
                case 128 + 27:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles, and you hear scary noises."
                        : $"{monsterName} casts a fearful illusion.");
                    if (saveGame.Player.HasFearResistance)
                    {
                        saveGame.MsgPrint("You refuse to be frightened.");
                    }
                    else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You refuse to be frightened.");
                    }
                    else
                    {
                        saveGame.Player.SetTimedFear(saveGame.Player.TimedFear + Program.Rng.RandomLessThan(4) + 4);
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsFear);
                    break;

                // MonsterFlag5.Blindness
                case 128 + 28:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a spell, burning your eyes!");
                    if (saveGame.Player.HasBlindnessResistance)
                    {
                        saveGame.MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.SetTimedBlindness(12 + Program.Rng.RandomLessThan(4));
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsBlind);
                    break;

                // MonsterFlag5.Confuse
                case 128 + 29:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles, and you hear puzzling noises." : $"{monsterName} creates a mesmerising illusion.");
                    if (saveGame.Player.HasConfusionResistance)
                    {
                        saveGame.MsgPrint("You disbelieve the feeble spell.");
                    }
                    else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You disbelieve the feeble spell.");
                    }
                    else
                    {
                        saveGame.Player.SetTimedConfusion(saveGame.Player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsConf);
                    break;

                // MonsterFlag5.Slow
                case 128 + 30:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} drains power from your muscles!");
                    if (saveGame.Player.HasFreeAction)
                    {
                        saveGame.MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.SetTimedSlow(saveGame.Player.TimedSlow + Program.Rng.RandomLessThan(4) + 4);
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsFree);
                    break;

                // MonsterFlag5.Hold
                case 128 + 31:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} stares deep into your eyes!");
                    if (saveGame.Player.HasFreeAction)
                    {
                        saveGame.MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.Player.SetTimedParalysis(saveGame.Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4);
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsFree);
                    break;

                // MonsterFlag6.Haste
                case 160 + 0:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} concentrates on {monsterPossessive} body.");
                    if (Speed < Race.Speed + 10)
                    {
                        saveGame.MsgPrint($"{monsterName} starts moving faster.");
                        Speed += 10;
                    }
                    else if (Speed < Race.Speed + 20)
                    {
                        saveGame.MsgPrint($"{monsterName} starts moving faster.");
                        Speed += 2;
                    }
                    break;

                // MonsterFlag6.DreadCurse
                case 160 + 1:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} invokes the Dread Curse of Azathoth!");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        int dummy = (65 + Program.Rng.DieRoll(25)) * saveGame.Player.Health / 100;
                        saveGame.MsgPrint("Your feel your life fade away!");
                        saveGame.Player.TakeHit(dummy, monsterName);
                        saveGame.Player.CurseEquipment(100, 20);
                        if (saveGame.Player.Health < 1)
                        {
                            saveGame.Player.Health = 1;
                        }
                    }
                    break;

                // MonsterFlag6.Heal
                case 160 + 2:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} concentrates on {monsterPossessive} wounds.");
                    Health += monsterLevel * 6;
                    if (Health >= MaxHealth)
                    {
                        Health = MaxHealth;
                        saveGame.MsgPrint(seenByPlayer
                            ? $"{monsterName} looks completely healed!"
                            : $"{monsterName} sounds completely healed!");
                    }
                    else
                    {
                        saveGame.MsgPrint(seenByPlayer ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
                    }
                    if (saveGame.TrackedMonsterIndex == GetMonsterIndex(saveGame))
                    {
                        saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                    if (FearLevel != 0)
                    {
                        FearLevel = 0;
                        saveGame.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                    }
                    break;

                // MonsterFlag6.Xxx2
                case 160 + 3:
                    break;

                // MonsterFlag6.Blink
                case 160 + 4:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} blinks away.");
                    TeleportAway(saveGame, 10);
                    break;

                // MonsterFlag6.TeleportSelf
                case 160 + 5:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} teleports away.");
                    TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
                    break;

                // MonsterFlag6.Xxx3
                case 160 + 6:
                // MonsterFlag6.Xxx4
                case 160 + 7:
                    break;

                // MonsterFlag6.TeleportTo
                case 160 + 8:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} commands you to return.");
                    saveGame.TeleportPlayerTo(MapY, MapX);
                    break;

                // MonsterFlag6.TeleportAway
                case 160 + 9:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} teleports you away.");
                    saveGame.TeleportPlayer(100);
                    break;

                // MonsterFlag6.TeleportLevel
                case 160 + 10:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles strangely."
                        : $"{monsterName} gestures at your feet.");
                    if (saveGame.Player.HasNexusResistance)
                    {
                        saveGame.MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        saveGame.TeleportPlayerLevel();
                    }
                    saveGame.Level.Monsters.UpdateSmartLearn(this, Constants.DrsNexus);
                    break;

                // MonsterFlag6.Xxx5
                case 160 + 11:
                    break;

                // MonsterFlag6.Darkness
                case 160 + 12:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} gestures in shadow.");
                    saveGame.UnlightArea(0, 3);
                    break;

                // MonsterFlag6.CreateTraps
                case 160 + 13:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles, and then cackles evilly."
                        : $"{monsterName} casts a spell and cackles evilly.");
                    saveGame.TrapCreation();
                    break;

                // MonsterFlag6.Forget
                case 160 + 14:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint($"{monsterName} tries to blank your mind.");
                    if (Program.Rng.RandomLessThan(100) < saveGame.Player.SkillSavingThrow)
                    {
                        saveGame.MsgPrint("You resist the effects!");
                    }
                    else if (saveGame.LoseAllInfo())
                    {
                        saveGame.MsgPrint("Your memories fade away.");
                    }
                    break;

                // MonsterFlag6.Xxx6
                case 160 + 15:
                    break;

                // MonsterFlag6.SummonKin
                case 160 + 16:
                    saveGame.Disturb(true);
                    if (playerIsBlind)
                    {
                        saveGame.MsgPrint($"{monsterName} mumbles.");
                    }
                    else
                    {
                        string kin = (Race.Flags1 & MonsterFlag1.Unique) != 0 ? "minions" : "kin";
                        saveGame.MsgPrint($"{monsterName} magically summons {monsterPossessive} {kin}.");
                    }
                    saveGame.Level.Monsters.SummonKinType = Race.Character;
                    for (k = 0; k < 6; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonKin))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonReaver
                case 160 + 17:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons Black Reavers!");
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear heavy steps nearby.");
                    }
                    saveGame.SummonReaver();
                    break;

                // MonsterFlag6.SummonMonster
                case 160 + 18:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons help!");
                    for (k = 0; k < 1; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, 0))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonMonsters
                case 160 + 19:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons monsters!");
                    for (k = 0; k < 8; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, 0))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonAnt
                case 160 + 20:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons ants.");
                    for (k = 0; k < 6; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonAnt))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonSpider
                case 160 + 21:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons spiders.");
                    for (k = 0; k < 6; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonSpider))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHound
                case 160 + 22:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons hounds.");
                    for (k = 0; k < 6; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHound))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHydra
                case 160 + 23:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons hydras.");
                    for (k = 0; k < 6; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHydra))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonCthuloid
                case 160 + 24:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons a Cthuloid entity!");
                    for (k = 0; k < 1; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonCthuloid))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonDemon
                case 160 + 25:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons a demon!");
                    for (k = 0; k < 1; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonDemon))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonUndead
                case 160 + 26:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons an undead adversary!");
                    for (k = 0; k < 1; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonUndead))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonDragon
                case 160 + 27:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons a dragon!");
                    for (k = 0; k < 1; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonDragon))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHiUndead
                case 160 + 28:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(
                        playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons greater undead!");
                    for (k = 0; k < 8; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHiUndead))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many creepy things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHiDragon
                case 160 + 29:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons ancient dragons!");
                    for (k = 0; k < 8; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHiDragon))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many powerful things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonGreatOldOne
                case 160 + 30:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(
                        playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons Great Old Ones!");
                    for (k = 0; k < 8; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonGoo))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear immortal beings appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonUnique
                case 160 + 31:
                    saveGame.Disturb(true);
                    saveGame.MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons special opponents!");
                    for (k = 0; k < 8; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonUnique))
                        {
                            count++;
                        }
                    }
                    for (k = 0; k < 8; k++)
                    {
                        if (saveGame.Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHiUndead))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        saveGame.MsgPrint("You hear many powerful things appear nearby.");
                    }
                    break;
            }
            // If the player saw us cast the spell, let them learn we can do that
            if (seenByPlayer)
            {
                if (thrownSpell < 32 * 4)
                {
                    Race.Knowledge.RFlags4 |= 1u << (thrownSpell - (32 * 3));
                    if (Race.Knowledge.RCastInate < Constants.MaxUchar)
                    {
                        Race.Knowledge.RCastInate++;
                    }
                }
                else if (thrownSpell < 32 * 5)
                {
                    Race.Knowledge.RFlags5 |= 1u << (thrownSpell - (32 * 4));
                    if (Race.Knowledge.RCastSpell < Constants.MaxUchar)
                    {
                        Race.Knowledge.RCastSpell++;
                    }
                }
                else if (thrownSpell < 32 * 6)
                {
                    Race.Knowledge.RFlags6 |= 1u << (thrownSpell - (32 * 5));
                    if (Race.Knowledge.RCastSpell < Constants.MaxUchar)
                    {
                        Race.Knowledge.RCastSpell++;
                    }
                }
            }
            // If we killed the player, let their descendants remember that
            if (saveGame.Player.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
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
        private bool TryCastingASpellAgainstAnotherMonster(SaveGame saveGame)
        {
            int count = 0;
            int[] spell = new int[96];
            int num = 0;
            bool wakeUp = false;
            bool blind = saveGame.Player.TimedBlindness != 0;
            bool seen = !blind && IsVisible;
            bool friendly = (Mind & Constants.SmFriendly) != 0;
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
            if (Program.Rng.RandomLessThan(100) >= chance)
            {
                return false;
            }
            // Look through the monster list to find a potential target
            for (int i = 1; i < saveGame.Level.MMax; i++)
            {
                int targetIndex = i;
                Monster target = saveGame.Level.Monsters[targetIndex];
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
                if ((Mind & Constants.SmFriendly) == (target.Mind & Constants.SmFriendly))
                {
                    continue;
                }
                // If the target is too far away from the player, don't cast a spell
                if (target.DistanceFromPlayer > Constants.MaxRange)
                {
                    continue;
                }
                // If we don't have line of sight to the target, don't cast a spell
                if (!saveGame.Level.Projectable(MapY, MapX, target.MapY, target.MapX))
                {
                    continue;
                }
                int y = target.MapY;
                int x = target.MapX;
                int rlev = Race.Level >= 1 ? Race.Level : 1;
                uint f4 = Race.Flags4;
                uint f5 = Race.Flags5;
                uint f6 = Race.Flags6;
                // If we're smart and badly injured, we may want to prioritise spells that disable
                // the target, summon help, or let us escape over spells that do direct damage
                if ((Race.Flags2 & MonsterFlag2.Smart) != 0 && Health < MaxHealth / 10 &&
                    Program.Rng.RandomLessThan(100) < 50)
                {
                    f4 &= MonsterFlag4.IntMask;
                    f5 &= MonsterFlag5.IntMask;
                    f6 &= MonsterFlag6.IntMask;
                    // If we just got rid of all our spells then abort
                    if (f4 == 0 && f5 == 0 && f6 == 0)
                    {
                        return false;
                    }
                }
                // If there's nowhere around the target to put a summoned creature, then remove
                // summoning spells
                if (((f4 & MonsterFlag4.SummonMask) != 0 || (f5 & MonsterFlag5.SummonMask) != 0 || (f6 & MonsterFlag6.SummonMask) != 0) && (Race.Flags2 & MonsterFlag2.Stupid) == 0 && !saveGame.SummonPossible(target.MapY, target.MapX))
                {
                    f4 &= ~MonsterFlag4.SummonMask;
                    f5 &= ~MonsterFlag5.SummonMask;
                    f6 &= ~MonsterFlag6.SummonMask;
                }
                // If we've removed all our spells, don't cast anything
                if (f4 == 0 && f5 == 0 && f6 == 0)
                {
                    return false;
                }
                // Gather up all the spells that are left and put them in an array Flags4 spells are 96
                // + bit number (0-31)
                int k;
                for (k = 0; k < 32; k++)
                {
                    if ((f4 & (1u << k)) != 0)
                    {
                        spell[num++] = k + (32 * 3);
                    }
                }
                for (k = 0; k < 32; k++)
                {
                    if ((f5 & (1u << k)) != 0)
                    {
                        spell[num++] = k + (32 * 4);
                    }
                }
                for (k = 0; k < 32; k++)
                {
                    if ((f6 & (1u << k)) != 0)
                    {
                        spell[num++] = k + (32 * 5);
                    }
                }
                // If we ended up with no spells, don't cast
                if (num == 0)
                {
                    return false;
                }
                // If the player's already dead or off the level, don't cast
                if (!saveGame.Playing || saveGame.Player.IsDead || saveGame.NewLevelFlag)
                {
                    return false;
                }
                string monsterName = MonsterDesc(0x00);
                string monsterPossessive = MonsterDesc(0x22);
                string targetName = target.MonsterDesc(0x00);
                MonsterDesc(0x88);
                // Against other monsters we pick spells randomly
                int thrownSpell = spell[Program.Rng.RandomLessThan(num)];
                bool seeMonster = seen;
                bool seeTarget = !blind && target.IsVisible;
                bool seeEither = seeMonster || seeTarget;
                bool seeBoth = seeMonster && seeTarget;
                // If we decided not to cast, don't
                switch (thrownSpell)
                {
                    // MonsterFlag4.Shriek
                    case 96 + 0:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeMonster ? "You hear a shriek." : $"{monsterName} shrieks at {targetName}.");
                        wakeUp = true;
                        break;

                    // MonsterFlag4.Xxx2
                    case 96 + 1:
                    // MonsterFlag4.Xxx3
                    case 96 + 2:
                        break;

                    // MonsterFlag4.ShardBall
                    case 96 + 3:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a shard ball at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectShard(saveGame), Health / 4 > 800 ? 800 : Health / 4, 2);
                        break;

                    // MonsterFlag4.Arrow1D6
                    case 96 + 4:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear a strange noise." : $"{monsterName} fires an arrow at {targetName}");
                        FireBoltAtMonster(saveGame, y, x, new ProjectArrow(saveGame), Program.Rng.DiceRoll(1, 6));
                        break;

                    // MonsterFlag4.Arrow3D6
                    case 96 + 5:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear a strange noise." : $"{monsterName} fires an arrow at {targetName}");
                        FireBoltAtMonster(saveGame, y, x, new ProjectArrow(saveGame), Program.Rng.DiceRoll(3, 6));
                        break;

                    // MonsterFlag4.Arrow5D6
                    case 96 + 6:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear a strange noise." : $"{monsterName} fires a missile at {targetName}");
                        FireBoltAtMonster(saveGame, y, x, new ProjectArrow(saveGame), Program.Rng.DiceRoll(5, 6));
                        break;

                    // MonsterFlag4.Arrow7D6
                    case 96 + 7:
                        if (!seeEither)
                        {
                            saveGame.MsgPrint("You hear a strange noise.");
                        }
                        else
                        {
                            saveGame.Disturb(true);
                        }
                        saveGame.MsgPrint(blind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires a missile at {targetName}");
                        FireBoltAtMonster(saveGame, y, x, new ProjectArrow(saveGame), Program.Rng.DiceRoll(7, 6));
                        break;

                    // MonsterFlag4.BreatheAcid
                    case 96 + 8:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes acid at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectAcid(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheLightning
                    case 96 + 9:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes lightning at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectElec(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheFire
                    case 96 + 10:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes fire at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectFire(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheCold
                    case 96 + 11:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes frost at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectCold(saveGame), Health / 3 > 1600 ? 1600 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreathePoison
                    case 96 + 12:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes gas at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectPois(saveGame), Health / 3 > 800 ? 800 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheNether
                    case 96 + 13:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes nether at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectNether(saveGame), Health / 6 > 550 ? 550 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheLight
                    case 96 + 14:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes light at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectLight(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheDark
                    case 96 + 15:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes darkness at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectDark(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheConfusion
                    case 96 + 16:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes confusion at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectConfusion(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheSound
                    case 96 + 17:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes sound at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectSound(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheChaos
                    case 96 + 18:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes chaos at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectChaos(saveGame), Health / 6 > 600 ? 600 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheDisenchant
                    case 96 + 19:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes disenchantment at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectDisenchant(saveGame), Health / 6 > 500 ? 500 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheNexus
                    case 96 + 20:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes nexus at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectNexus(saveGame), Health / 3 > 250 ? 250 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheTime
                    case 96 + 21:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes time at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectTime(saveGame), Health / 3 > 150 ? 150 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheInertia
                    case 96 + 22:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes inertia at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectInertia(saveGame), Health / 6 > 200 ? 200 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheGravity
                    case 96 + 23:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes gravity at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectGravity(saveGame), Health / 3 > 200 ? 200 : Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheShards
                    case 96 + 24:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes shards at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectExplode(saveGame), Health / 6 > 400 ? 400 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreathePlasma
                    case 96 + 25:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes plasma at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectPlasma(saveGame), Health / 6 > 150 ? 150 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheForce
                    case 96 + 26:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes force at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectForce(saveGame), Health / 6 > 200 ? 200 : Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheMana
                    case 96 + 27:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes magical energy at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectMana(saveGame), Health / 3 > 250 ? 250 : Health / 3, 0);
                        break;

                    // MonsterFlag4.RadiationBall
                    case 96 + 28:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a ball of radiation at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectNuke(saveGame), rlev + Program.Rng.DiceRoll(10, 6), 2);
                        break;

                    // MonsterFlag4.BreatheRadiation
                    case 96 + 29:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes toxic waste at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectNuke(saveGame), Health / 3 > 800 ? 800 : Health / 3, 0);
                        break;

                    // MonsterFlag4.ChaosBall
                    case 96 + 30:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble frighteningly." : $"{monsterName} invokes raw chaos upon {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectChaos(saveGame), (rlev * 2) + Program.Rng.DiceRoll(10, 10), 4);
                        break;

                    // MonsterFlag4.BreatheDisintegration
                    case 96 + 31:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear breathing noise." : $"{monsterName} breathes disintegration at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectDisintegrate(saveGame), Health / 3 > 300 ? 300 : Health / 3, 0);
                        break;

                    // MonsterFlag5.AcidBall
                    case 128 + 0:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts an acid ball at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectAcid(saveGame), Program.Rng.DieRoll(rlev * 3) + 15, 2);
                        break;

                    // MonsterFlag5.LightningBall
                    case 128 + 1:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a lightning ball at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectElec(saveGame), Program.Rng.DieRoll(rlev * 3 / 2) + 8, 2);
                        break;

                    // MonsterFlag5.FireBall
                    case 128 + 2:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a fire ball at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectFire(saveGame), Program.Rng.DieRoll(rlev * 7 / 2) + 10, 2);
                        break;

                    // MonsterFlag5.ColdBall
                    case 128 + 3:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a frost ball at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectCold(saveGame), Program.Rng.DieRoll(rlev * 3 / 2) + 10, 2);
                        break;

                    // MonsterFlag5.PoisonBall
                    case 128 + 4:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a stinking cloud at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectPois(saveGame), Program.Rng.DiceRoll(12, 2), 2);
                        break;

                    // MonsterFlag5.NetherBall
                    case 128 + 5:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} casts a nether ball at {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectNether(saveGame), 50 + Program.Rng.DiceRoll(10, 10) + rlev, 2);
                        break;

                    // MonsterFlag5.WaterBall
                    case 128 + 6:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble." : $"{monsterName} gestures fluidly at {targetName}");
                        saveGame.MsgPrint($"{targetName} is engulfed in a whirlpool.");
                        BreatheAtMonster(saveGame, y, x, new ProjectWater(saveGame), Program.Rng.DieRoll(rlev * 5 / 2) + 50, 4);
                        break;

                    // MonsterFlag5.ManaBall
                    case 128 + 7:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble powerfully." : $"{monsterName} invokes a mana storm upon {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectMana(saveGame), (rlev * 5) + Program.Rng.DiceRoll(10, 10), 4);
                        break;

                    // MonsterFlag5.DarkBall
                    case 128 + 8:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(!seeEither ? "You hear someone mumble powerfully." : $"{monsterName} invokes a darkness storm upon {targetName}");
                        BreatheAtMonster(saveGame, y, x, new ProjectDark(saveGame), (rlev * 5) + Program.Rng.DiceRoll(10, 10), 4);
                        break;

                    // MonsterFlag5.DrainMana
                    case 128 + 9:
                        int r1 = (Program.Rng.DieRoll(rlev) / 2) + 1;
                        if (seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} draws psychic energy from {targetName}");
                        }
                        if (Health < MaxHealth)
                        {
                            if (!(targetRace.Flags4 != 0 || targetRace.Flags5 != 0 || targetRace.Flags6 != 0))
                            {
                                if (seeBoth)
                                {
                                    saveGame.MsgPrint($"{targetName} is unaffected!");
                                }
                            }
                            else
                            {
                                Health += 6 * r1;
                                if (Health > MaxHealth)
                                {
                                    Health = MaxHealth;
                                }
                                if (saveGame.TrackedMonsterIndex == GetMonsterIndex(saveGame))
                                {
                                    saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                                }
                                if (seen)
                                {
                                    saveGame.MsgPrint($"{monsterName} appears healthier.");
                                }
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.MindBlast
                    case 128 + 10:
                        saveGame.Disturb(true);
                        if (seen)
                        {
                            saveGame.MsgPrint($"{monsterName} gazes intently at {targetName}");
                        }
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0 || (targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0 ||
                            targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if ((targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0 && seen)
                            {
                                targetRace.Knowledge.RFlags3 |= MonsterFlag3.ImmuneConfusion;
                            }
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected!");
                            }
                        }
                        else
                        {
                            saveGame.MsgPrint($"{targetName} is blasted by psionic energy.");
                            target.ConfusionLevel += Program.Rng.RandomLessThan(4) + 4;
                            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(8, 8), out _, " collapses, a mindless husk.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.BrainSmash
                    case 128 + 11:
                        saveGame.Disturb(true);
                        if (seen)
                        {
                            saveGame.MsgPrint($"{monsterName} gazes intently at {targetName}");
                        }
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0 || (targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0 ||
                            targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if ((targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0 && seen)
                            {
                                targetRace.Knowledge.RFlags3 |= MonsterFlag3.ImmuneConfusion;
                            }
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected!");
                            }
                        }
                        else
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is blasted by psionic energy.");
                            }
                            target.ConfusionLevel += Program.Rng.RandomLessThan(4) + 4;
                            target.Speed -= Program.Rng.RandomLessThan(4) + 4;
                            target.StunLevel += Program.Rng.RandomLessThan(4) + 4;
                            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(12, 15), out _, " collapses, a mindless husk.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseLightWounds
                    case 128 + 12:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} points at {targetName} and curses.");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(3, 8), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseSeriousWounds
                    case 128 + 13:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} points at {targetName} and curses horribly.");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(8, 8), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseCriticalWounds
                    case 128 + 14:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} points at {targetName}, incanting terribly!");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(10, 15), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseMortalWounds
                    case 128 + 15:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} points at {targetName}, screaming the word 'DIE!'");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            target.TakeDamageFromAnotherMonster(saveGame, Program.Rng.DiceRoll(15, 15), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.AcidBolt
                    case 128 + 16:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a acid bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectAcid(saveGame), Program.Rng.DiceRoll(7, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.LightningBolt
                    case 128 + 17:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a lightning bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectElec(saveGame), Program.Rng.DiceRoll(4, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.FireBolt
                    case 128 + 18:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a fire bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectFire(saveGame), Program.Rng.DiceRoll(9, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.ColdBolt
                    case 128 + 19:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a frost bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectCold(saveGame), Program.Rng.DiceRoll(6, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.PoisonBolt
                    case 128 + 20:
                        break;

                    // MonsterFlag5.NetherBolt
                    case 128 + 21:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a nether bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectNether(saveGame), 30 + Program.Rng.DiceRoll(5, 5) + (rlev * 3 / 2));
                        break;

                    // MonsterFlag5.WaterBolt
                    case 128 + 22:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a water bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectWater(saveGame), Program.Rng.DiceRoll(10, 10) + rlev);
                        break;

                    // MonsterFlag5.ManaBolt
                    case 128 + 23:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a mana bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectMana(saveGame), Program.Rng.DieRoll(rlev * 7 / 2) + 50);
                        break;

                    // MonsterFlag5.PlasmaBolt
                    case 128 + 24:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a plasma bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectPlasma(saveGame), 10 + Program.Rng.DiceRoll(8, 7) + rlev);
                        break;

                    // MonsterFlag5.IceBolt
                    case 128 + 25:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts an ice bolt at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectIce(saveGame), Program.Rng.DiceRoll(6, 6) + rlev);
                        break;

                    // MonsterFlag5.MagicMissile
                    case 128 + 26:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a magic missile at {targetName}");
                        }
                        FireBoltAtMonster(saveGame, y, x, new ProjectMissile(saveGame), Program.Rng.DiceRoll(2, 6) + (rlev / 3));
                        break;

                    // MonsterFlag5.Scare
                    case 128 + 27:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles, and you hear scary noises.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} casts a fearful illusion at {targetName}");
                        }
                        if ((targetRace.Flags3 & MonsterFlag3.ImmuneFear) != 0)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} refuses to be frightened.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} refuses to be frightened.");
                            }
                        }
                        else
                        {
                            if (target.FearLevel == 0 && seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} flees in terror!");
                            }
                            target.FearLevel += Program.Rng.RandomLessThan(4) + 4;
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Blindness
                    case 128 + 28:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            string it = targetName != "it" ? "s" : "'s";
                            saveGame.MsgPrint($"{monsterName} casts a spell, burning {targetName}{it} eyes.");
                        }
                        if ((targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is blinded!");
                            }
                            target.ConfusionLevel += 12 + Program.Rng.RandomLessThan(4);
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Confuse
                    case 128 + 29:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles, and you hear puzzling noises.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} creates a mesmerising illusion in front of {targetName}");
                        }
                        if ((targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} disbelieves the feeble spell.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} disbelieves the feeble spell.");
                            }
                        }
                        else
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} seems confused.");
                            }
                            target.ConfusionLevel += 12 + Program.Rng.RandomLessThan(4);
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Slow
                    case 128 + 30:
                        saveGame.Disturb(true);
                        if (!blind && seeEither)
                        {
                            string it = targetName == "it" ? "s" : "'s";
                            saveGame.MsgPrint($"{monsterName} drains power from {targetName}{it} muscles.");
                        }
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else
                        {
                            target.Speed -= 10;
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} starts moving slower.");
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Hold
                    case 128 + 31:
                        saveGame.Disturb(true);
                        if (!blind && seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} stares intently at {targetName}");
                        }
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0 || (targetRace.Flags3 & MonsterFlag3.ImmuneStun) != 0)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else
                        {
                            target.StunLevel += Program.Rng.DieRoll(4) + 4;
                            if (seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is paralyzed!");
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag6.Haste
                    case 160 + 0:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} concentrates on {monsterPossessive} body.");
                        }
                        if (Speed < Race.Speed + 10)
                        {
                            if (seeMonster)
                            {
                                saveGame.MsgPrint($"{monsterName} starts moving faster.");
                            }
                            Speed += 10;
                        }
                        else if (Speed < Race.Speed + 20)
                        {
                            if (seeMonster)
                            {
                                saveGame.MsgPrint($"{monsterName} starts moving faster.");
                            }
                            Speed += 2;
                        }
                        break;

                    // MonsterFlag6.DreadCurse
                    case 160 + 1:
                        saveGame.Disturb(false);
                        saveGame.MsgPrint(!seeMonster
                            ? "You hear someone invoke the Dread Curse of Azathoth!"
                            : $"{monsterName} invokes the Dread Curse of Azathoth on {targetName}");
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0)
                        {
                            if (!blind && seeTarget)
                            {
                                saveGame.MsgPrint($"{targetName} is unaffected!");
                            }
                        }
                        else
                        {
                            if (Race.Level + Program.Rng.DieRoll(20) > targetRace.Level + 10 + Program.Rng.DieRoll(20))
                            {
                                target.Health -= (65 + Program.Rng.DieRoll(25)) * target.Health / 100;
                                if (target.Health < 1)
                                {
                                    target.Health = 1;
                                }
                            }
                            else
                            {
                                if (seeTarget)
                                {
                                    saveGame.MsgPrint($"{targetName} resists!");
                                }
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag6.Heal
                    case 160 + 2:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} concentrates on {monsterPossessive} wounds.");
                        }
                        Health += rlev * 6;
                        if (Health >= MaxHealth)
                        {
                            Health = MaxHealth;
                            saveGame.MsgPrint(seen ? $"{monsterName} looks completely healed!" : $"{monsterName} sounds completely healed!");
                        }
                        else
                        {
                            saveGame.MsgPrint(seen ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
                        }
                        if (saveGame.TrackedMonsterIndex == GetMonsterIndex(saveGame))
                        {
                            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                        }
                        if (FearLevel != 0)
                        {
                            FearLevel = 0;
                            if (seeMonster)
                            {
                                saveGame.MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                            }
                        }
                        break;

                    // MonsterFlag6.Xxx2
                    case 160 + 3:
                        break;

                    // MonsterFlag6.Blink
                    case 160 + 4:
                        saveGame.Disturb(true);
                        if (seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} blinks away.");
                        }
                        TeleportAway(saveGame, 10);
                        break;

                    // MonsterFlag6.TeleportSelf
                    case 160 + 5:
                        saveGame.Disturb(true);
                        if (seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} teleports away.");
                        }
                        TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
                        break;

                    // MonsterFlag6.Xxx3
                    case 160 + 6:
                    // MonsterFlag6.Xxx4
                    case 160 + 7:
                    // MonsterFlag6.TeleportTo
                    case 160 + 8:
                        break;

                    // MonsterFlag6.TeleportAway
                    case 160 + 9:
                        bool resistsTele = false;
                        saveGame.Disturb(true);
                        saveGame.MsgPrint($"{monsterName} teleports {targetName} away.");
                        if ((targetRace.Flags3 & MonsterFlag3.ResistTeleport) != 0)
                        {
                            if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0)
                            {
                                if (seeTarget)
                                {
                                    targetRace.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                                    saveGame.MsgPrint($"{targetName} is unaffected!");
                                }
                                resistsTele = true;
                            }
                            else if (targetRace.Level > Program.Rng.DieRoll(100))
                            {
                                if (seeTarget)
                                {
                                    targetRace.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                                    saveGame.MsgPrint($"{targetName} resists!");
                                }
                                resistsTele = true;
                            }
                        }
                        if (!resistsTele)
                        {
                            target.TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
                        }
                        break;

                    // MonsterFlag6.TeleportLevel
                    case 160 + 10:
                    // MonsterFlag6.Xxx5
                    case 160 + 11:
                        break;

                    // MonsterFlag6.Darkness
                    case 160 + 12:
                        saveGame.Disturb(true);
                        saveGame.MsgPrint(blind ? $"{monsterName} mumbles." : $"{monsterName} gestures in shadow.");
                        if (seen)
                        {
                            saveGame.MsgPrint($"{targetName} is surrounded by darkness.");
                        }
                        saveGame.Project(GetMonsterIndex(saveGame), 3, y, x, 0, new ProjectDarkWeak(saveGame), ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill);
                        saveGame.UnlightRoom(y, x);
                        break;

                    // MonsterFlag6.CreateTraps
                    case 160 + 13:
                    // MonsterFlag6.Forget
                    case 160 + 14:
                    // MonsterFlag6.Xxx6
                    case 160 + 15:
                        break;

                    // MonsterFlag6.SummonKin
                    case 160 + 16:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            string kin = (Race.Flags1 & MonsterFlag1.Unique) != 0 ? "minions" : "kin";
                            saveGame.MsgPrint($"{monsterName} magically summons {monsterPossessive} {kin}.");
                        }
                        saveGame.Level.Monsters.SummonKinType = Race.Character;
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonKin, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonKin))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonReaver
                    case 160 + 17:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons Black Reavers!");
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear heavy steps nearby.");
                        }
                        if (friendly)
                        {
                            saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonReaver, true);
                        }
                        else
                        {
                            saveGame.SummonReaver();
                        }
                        break;

                    // MonsterFlag6.SummonMonster
                    case 160 + 18:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons help!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, 0))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonMonsters
                    case 160 + 19:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons monsters!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, 0))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonAnt
                    case 160 + 20:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons ants.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonAnt, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonAnt))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonSpider
                    case 160 + 21:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons spiders.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonSpider, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonSpider))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHound
                    case 160 + 22:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons hounds.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonHound, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHound))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHydra
                    case 160 + 23:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons hydras.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonHydra, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHydra))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonCthuloid
                    case 160 + 24:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons a Cthuloid entity!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonCthuloid, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonCthuloid))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonDemon
                    case 160 + 25:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons a demon!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonDemon, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonDemon))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonUndead
                    case 160 + 26:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons an undead adversary!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonUndead, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonUndead))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonDragon
                    case 160 + 27:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons a dragon!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonDragon, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonDragon))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHiUndead
                    case 160 + 28:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons greater undead!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev,
                                    Constants.SummonHiUndeadNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHiUndead))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many creepy things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHiDragon
                    case 160 + 29:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons ancient dragons!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev,
                                    Constants.SummonHiDragonNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHiDragon))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many powerful things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonGreatOldOne
                    case 160 + 30:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons Great Old Ones!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonGoo))
                            {
                                count++;
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear immortal beings appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonUnique
                    case 160 + 31:
                        saveGame.Disturb(true);
                        if (blind || !seeMonster)
                        {
                            saveGame.MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            saveGame.MsgPrint($"{monsterName} magically summons special opponents!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (!friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonUnique))
                                {
                                    count++;
                                }
                            }
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (saveGame.Level.Monsters.SummonSpecificFriendly(y, x, rlev,
                                    Constants.SummonHiUndeadNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (saveGame.Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHiUndead))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            saveGame.MsgPrint("You hear many powerful things appear nearby.");
                        }
                        break;
                }
                // Most spells will wake up the target if it's asleep
                if (wakeUp)
                {
                    target.SleepLevel = 0;
                }
                // If the player saw us cast the spell, let them learn we can do that
                if (seen)
                {
                    if (thrownSpell < 32 * 4)
                    {
                        Race.Knowledge.RFlags4 |= 1u << (thrownSpell - (32 * 3));
                        if (Race.Knowledge.RCastInate < Constants.MaxUchar)
                        {
                            Race.Knowledge.RCastInate++;
                        }
                    }
                    else if (thrownSpell < 32 * 5)
                    {
                        Race.Knowledge.RFlags5 |= 1u << (thrownSpell - (32 * 4));
                        if (Race.Knowledge.RCastSpell < Constants.MaxUchar)
                        {
                            Race.Knowledge.RCastSpell++;
                        }
                    }
                    else if (thrownSpell < 32 * 6)
                    {
                        Race.Knowledge.RFlags6 |= 1u << (thrownSpell - (32 * 5));
                        if (Race.Knowledge.RCastSpell < Constants.MaxUchar)
                        {
                            Race.Knowledge.RCastSpell++;
                        }
                    }
                }
                // If we killed the player, let their descendants remember that
                if (saveGame.Player.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
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
        private void BreatheAtMonster(SaveGame saveGame, int targetY, int targetX, Projectile projectile, int damage, int radius)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            // Radius 0 means use the default radius
            if (radius < 1)
            {
                radius = (Race.Flags2 & MonsterFlag2.Powerful) != 0 ? 3 : 2;
            }
            // Make the radius negative to indicate we need a cone instead of a ball
            radius = 0 - radius;
            saveGame.Project(GetMonsterIndex(saveGame), radius, targetY, targetX, damage, projectile, projectionFlags);
        }

        /// <summary>
        /// Fire some kind of ball attack at the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster firing the attack </param>
        /// <param name="projectile"> The type of effect the ball has </param>
        /// <param name="damage"> The damage done by the ball </param>
        /// <param name="radius"> The radius of the ball, or zero to use the default radius </param>
        private void FireBallAtPlayer(SaveGame saveGame, Projectile projectile, int damage, int radius)
        {
            const ProjectionFlag projectionFlag = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            if (radius < 1)
            {
                radius = (Race.Flags2 & MonsterFlag2.Powerful) != 0 ? 3 : 2;
            }
            saveGame.Project(GetMonsterIndex(saveGame), radius, saveGame.Player.MapY, saveGame.Player.MapX, damage, projectile, projectionFlag);
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
        private void BreatheAtPlayer(SaveGame saveGame, Projectile projectile, int damage, int radius)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            // Radius 0 means use the default radius
            if (radius < 1)
            {
                radius = (Race.Flags2 & MonsterFlag2.Powerful) != 0 ? 3 : 2;
            }
            // Make the radius negative to indicate we need a cone instead of a ball
            radius = 0 - radius;
            saveGame.Project(GetMonsterIndex(saveGame), radius, saveGame.Player.MapY, saveGame.Player.MapX, damage, projectile, projectionFlags);
        }

        /// <summary>
        /// Fire a bolt of some kind at another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster doing the firing </param>
        /// <param name="targetY"> The y coordinate of the target </param>
        /// <param name="targetX"> The x coordinate of the target </param>
        /// <param name="projectile"> The projectile to be fired </param>
        /// <param name="damage"> The damage the projectile should do </param>
        private void FireBoltAtMonster(SaveGame saveGame, int targetY, int targetX, Projectile projectile, int damage)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            saveGame.Project(GetMonsterIndex(saveGame), 0, targetY, targetX, damage, projectile, projectionFlags);
        }

        /// <summary>
        /// Take damage after being hit by another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster taking the damage </param>
        /// <param name="damage"> The damage taken </param>
        /// <param name="fear"> Whether the damage makes us afraid </param>
        /// <param name="note"> A special descriptive note that replaces the normal death message </param>
        private void TakeDamageFromAnotherMonster(SaveGame saveGame, int damage, out bool fear, string note)
        {
            fear = false;
            // Track the monster that has just taken damage
            if (saveGame.TrackedMonsterIndex == GetMonsterIndex(saveGame))
            {
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
            }
            SleepLevel = 0;
            // Take the damage
            Health -= damage;
            // Did it kill us?
            if (Health < 0)
            {
                // Uniques and guardians can never be killed by other monsters
                if ((Race.Flags1 & MonsterFlag1.Unique) != 0 || (Race.Flags1 & MonsterFlag1.Guardian) != 0)
                {
                    Health = 1;
                }
                else
                {
                    // Construct a message telling the player what happened
                    string monsterName = MonsterDesc(0);
                    saveGame.PlaySound(SoundEffect.MonsterDies);
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
                    else if ((Race.Flags3 & MonsterFlag3.Demon) != 0 || (Race.Flags3 & MonsterFlag3.Undead) != 0 ||
                             (Race.Flags3 & MonsterFlag3.Cthuloid) != 0 || (Race.Flags2 & MonsterFlag2.Stupid) != 0 ||
                             (Race.Flags3 & MonsterFlag3.Nonliving) != 0 || "Evg".Contains(Race.Character.ToString()))
                    {
                        saveGame.MsgPrint($"{monsterName} is destroyed.");
                    }
                    else
                    {
                        saveGame.MsgPrint($"{monsterName} is killed.");
                    }
                    // Let the save game know we've died
                    saveGame.MonsterDeath(GetMonsterIndex(saveGame));
                    // Delete us from the monster list
                    saveGame.Level.Monsters.DeleteMonsterByIndex(GetMonsterIndex(saveGame), true);
                    fear = false;
                    return;
                }
            }
            // Assuming we survived, check if the attack made us afraid
            if (FearLevel != 0 && damage > 0)
            {
                // If we're already afraid, we might get desperate and overcome our fear
                int tmp = Program.Rng.DieRoll(damage);
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
            if (FearLevel == 0 && (Race.Flags3 & MonsterFlag3.ImmuneFear) == 0)
            {
                int percentage = 100 * Health / MaxHealth;
                if ((percentage <= 10 && Program.Rng.RandomLessThan(10) < percentage) || (damage >= Health && Program.Rng.RandomLessThan(100) < 80))
                {
                    fear = true;
                    FearLevel = Program.Rng.DieRoll(10) + (damage >= Health && percentage > 7 ? 20 : (11 - percentage) * 5);
                }
            }
        }

        /// <summary>
        /// Cast a bolt spell at the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster casting the bolt </param>
        /// <param name="projectile"> The projectile being used for the bolt </param>
        /// <param name="damage"> The damage that the bolt will do </param>
        private void FireBoltAtPlayer(SaveGame saveGame, Projectile projectile, int damage)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            saveGame.Project(GetMonsterIndex(saveGame), 0, saveGame.Player.MapY, saveGame.Player.MapX, damage, projectile, projectionFlags);
        }

        /// <summary>
        /// Remove flags for ineffective spells from the monster's flags and return them.
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <param name="modifiedFlags4"> Flags4 after having spells removed </param>
        /// <param name="initialFlags4"> Flags4 before having spells removed </param>
        /// <param name="modifiedFlags5"> Flags5 after having spells removed </param>
        /// <param name="initialFlags5"> Flags5 before having spells removed </param>
        /// <param name="modifiedFlags6"> Flags6 after having spells removed </param>
        /// <param name="initialFlags6"> Flags6 before having spells removed </param>
        private void RemoveIneffectiveSpells(SaveGame saveGame, out uint modifiedFlags4, uint initialFlags4, out uint modifiedFlags5, uint initialFlags5, out uint modifiedFlags6, uint initialFlags6)
        {
            uint flags4 = initialFlags4;
            uint flags5 = initialFlags5;
            uint flags6 = initialFlags6;
            modifiedFlags4 = initialFlags4;
            modifiedFlags5 = initialFlags5;
            modifiedFlags6 = initialFlags6;
            // If we're stupid, we won't realise how ineffective things are
            if ((Race.Flags2 & MonsterFlag2.Stupid) != 0)
            {
                return;
            }
            // Tiny chance of forgetting what we've seen, clearing all smart flags except for ally
            // and clone
            if (Mind != 0 && Program.Rng.RandomLessThan(100) < 1)
            {
                Mind &= (Constants.SmFriendly | Constants.SmCloned);
            }
            uint mindFlags = Mind;
            // If we're not aware of any of the player's resistances, don't bother going through them
            if (mindFlags == 0)
            {
                return;
            }
            // If we know the player is immune to acid, don't do acid spells
            if ((mindFlags & Constants.SmImmAcid) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.BreatheAcid;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.AcidBall;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
            }
            // If we know the player resists acid both temporarily and permanently, probably don't
            // do acid spells
            else if ((mindFlags & Constants.SmOppAcid) != 0 && (mindFlags & Constants.SmResAcid) != 0)
            {
                if (RealiseSpellIsUseless(80))
                {
                    flags4 &= ~MonsterFlag4.BreatheAcid;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.AcidBall;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
            }
            // If we know the player resists acid at all, maybe don't do acid spells
            else if ((mindFlags & Constants.SmOppAcid) != 0 || (mindFlags & Constants.SmResAcid) != 0)
            {
                if (RealiseSpellIsUseless(30))
                {
                    flags4 &= ~MonsterFlag4.BreatheAcid;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.AcidBall;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
            }
            // If we know the player is immune to lightning, don't do lightning spells
            if ((mindFlags & Constants.SmImmElec) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.BreatheLightning;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.LightningBall;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
            }
            // If we know the player resists lightning both temporarily and permanently, probably
            // don't do lightning spells
            else if ((mindFlags & Constants.SmOppElec) != 0 && (mindFlags & Constants.SmResElec) != 0)
            {
                if (RealiseSpellIsUseless(80))
                {
                    flags4 &= ~MonsterFlag4.BreatheLightning;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.LightningBall;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
            }
            // If we know the player resists lightning at all, maybe don't do lightning spells
            else if ((mindFlags & Constants.SmOppElec) != 0 || (mindFlags & Constants.SmResElec) != 0)
            {
                if (RealiseSpellIsUseless(30))
                {
                    flags4 &= ~MonsterFlag4.BreatheLightning;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.LightningBall;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
            }
            // If we know the player is immune to fire, don't do fire spells
            if ((mindFlags & Constants.SmImmFire) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.BreatheFire;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.FireBall;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
            }
            // If we know the player resists fire both temporarily and permanently, probably don't
            // do fire spells
            else if ((mindFlags & Constants.SmOppFire) != 0 && (mindFlags & Constants.SmResFire) != 0)
            {
                if (RealiseSpellIsUseless(80))
                {
                    flags4 &= ~MonsterFlag4.BreatheFire;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.FireBall;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
            }
            // If we know the player resists fire at all, maybe don't do fire spells
            else if ((mindFlags & Constants.SmOppFire) != 0 || (mindFlags & Constants.SmResFire) != 0)
            {
                if (RealiseSpellIsUseless(30))
                {
                    flags4 &= ~MonsterFlag4.BreatheFire;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.FireBall;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
            }
            // If we know the player is immune to cold, don't do fire spells
            if ((mindFlags & Constants.SmImmCold) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.BreatheCold;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.ColdBall;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
            }
            // If we know the player resists cold both temporarily and permanently, probably don't
            // do cold spells
            else if ((mindFlags & Constants.SmOppCold) != 0 && (mindFlags & Constants.SmResCold) != 0)
            {
                if (RealiseSpellIsUseless(80))
                {
                    flags4 &= ~MonsterFlag4.BreatheCold;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.ColdBall;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
            }
            // If we know the player resists cold at all, maybe don't do cold spells
            else if ((mindFlags & Constants.SmOppCold) != 0 || (mindFlags & Constants.SmResCold) != 0)
            {
                if (RealiseSpellIsUseless(30))
                {
                    flags4 &= ~MonsterFlag4.BreatheCold;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.ColdBall;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
            }
            // If we know the player resists poison both temporarily and permanently, probably don't
            // do poison spells
            if ((mindFlags & Constants.SmOppPois) != 0 && (mindFlags & Constants.SmResPois) != 0)
            {
                if (RealiseSpellIsUseless(80))
                {
                    flags4 &= ~MonsterFlag4.BreathePoison;
                }
                if (RealiseSpellIsUseless(80))
                {
                    flags5 &= ~MonsterFlag5.PoisonBall;
                }
                if (RealiseSpellIsUseless(40))
                {
                    flags4 &= ~MonsterFlag4.RadiationBall;
                }
                if (RealiseSpellIsUseless(40))
                {
                    flags4 &= ~MonsterFlag4.BreatheRadiation;
                }
            }
            // If we know the player resists poison at all, maybe don't do cold spells
            else if ((mindFlags & Constants.SmOppPois) != 0 || (mindFlags & Constants.SmResPois) != 0)
            {
                if (RealiseSpellIsUseless(30))
                {
                    flags4 &= ~MonsterFlag4.BreathePoison;
                }
                if (RealiseSpellIsUseless(30))
                {
                    flags5 &= ~MonsterFlag5.PoisonBall;
                }
            }
            // If we know the player resists nether, maybe don't do nether spells
            if ((mindFlags & Constants.SmResNeth) != 0)
            {
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheNether;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags5 &= ~MonsterFlag5.NetherBall;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags5 &= ~MonsterFlag5.NetherBolt;
                }
            }
            // If we know the player resists light, maybe don't do light spells
            if ((mindFlags & Constants.SmResLight) != 0)
            {
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheLight;
                }
            }
            // If we know the player resists darkness, maybe don't do darkness spells
            if ((mindFlags & Constants.SmResDark) != 0)
            {
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheDark;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags5 &= ~MonsterFlag5.DarkBall;
                }
            }
            // If we know the player resists fear, don't do fear spells
            if ((mindFlags & Constants.SmResFear) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.Scare;
                }
            }
            // If we know the player resists confiusion, maybe don't do confusion spells
            if ((mindFlags & Constants.SmResConf) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.Confuse;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheConfusion;
                }
            }
            // If we know the player resists chaos, maybe don't do chaos or confusion spells
            if ((mindFlags & Constants.SmResChaos) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.Confuse;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheConfusion;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheChaos;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.ChaosBall;
                }
            }
            // If we know the player resists disenchantment, don't do disenchantment spells
            if ((mindFlags & Constants.SmResDisen) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.BreatheDisenchant;
                }
            }
            // If we know the player resists blindness, don't do blindness spells
            if ((mindFlags & Constants.SmResBlind) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.Blindness;
                }
            }
            // If we know the player resists nexus, maybe don't do nexus or teleport spells
            if ((mindFlags & Constants.SmResNexus) != 0)
            {
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheNexus;
                }
                if (RealiseSpellIsUseless(50))
                {
                    flags6 &= ~MonsterFlag6.TeleportLevel;
                }
            }
            // If we know the player resists sound, maybe don't do sound spells
            if ((mindFlags & Constants.SmResSound) != 0)
            {
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheSound;
                }
            }
            // If we know the player resists shards, maybe don't do shard spells
            if ((mindFlags & Constants.SmResShard) != 0)
            {
                if (RealiseSpellIsUseless(50))
                {
                    flags4 &= ~MonsterFlag4.BreatheShards;
                }
                if (RealiseSpellIsUseless(20))
                {
                    flags4 &= ~MonsterFlag4.ShardBall;
                }
            }
            // If we know the player reflects bolts, don't do bolt spells
            if ((mindFlags & Constants.SmImmReflect) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.PoisonBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.NetherBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.WaterBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.ManaBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.PlasmaBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.MagicMissile;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.Arrow1D6;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.Arrow3D6;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.Arrow5D6;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags4 &= ~MonsterFlag4.Arrow7D6;
                }
            }
            // If we know the player has free action, don't do slow or hold spells
            if ((mindFlags & Constants.SmImmFree) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.Hold;
                }
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.Slow;
                }
            }
            // If we know the player has no mana, don't do mana drain
            if ((mindFlags & Constants.SmImmMana) != 0)
            {
                if (RealiseSpellIsUseless(100))
                {
                    flags5 &= ~MonsterFlag5.DrainMana;
                }
            }
            modifiedFlags4 = flags4;
            modifiedFlags5 = flags5;
            modifiedFlags6 = flags6;
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
            if ((Race.Flags2 & MonsterFlag2.Smart) == 0)
            {
                percentage /= 2;
            }
            return Program.Rng.RandomLessThan(100) < percentage;
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
            MapCoordinate targetLocation = new MapCoordinate(saveGame.Player.MapX, saveGame.Player.MapY);
            // Adjust our target based on the player's scent if we can't move in a straight line to them
            TrackPlayerByScent(saveGame, targetLocation);
            // Get the relative move needed to reach our target location
            MapCoordinate desiredRelativeMovement = new MapCoordinate();
            desiredRelativeMovement.Y = MapY - targetLocation.Y;
            desiredRelativeMovement.X = MapX - targetLocation.X;
            if ((Mind & Constants.SmFriendly) == 0)
            {
                // If we're a pack animal that can't go through walls
                if ((Race.Flags1 & MonsterFlag1.Friends) != 0 && (Race.Flags3 & MonsterFlag3.Animal) != 0 &&
                    (Race.Flags2 & MonsterFlag2.PassWall) == 0 && (Race.Flags2 & MonsterFlag2.KillWall) == 0)
                {
                    int room = 0;
                    // Check if the player is in a room by counting the room tiles around them
                    for (int i = 0; i < 8; i++)
                    {
                        if (saveGame.Level.Grid[saveGame.Player.MapY + saveGame.Level.OrderedDirectionYOffset[i]][saveGame.Player.MapX + saveGame.Level.OrderedDirectionXOffset[i]].TileFlags.IsSet(GridTile.InRoom))
                        {
                            room++;
                        }
                    }
                    // If the player isn't in a room and they're healthy, wait to ambush them rather
                    // than running headlong into the corridor after them and queueing up to get hit
                    if (room < 8 && saveGame.Player.Health > saveGame.Player.MaxHealth * 3 / 4)
                    {
                        if (FindAmbushSpot(saveGame, desiredRelativeMovement))
                        {
                            done = true;
                        }
                    }
                }
                // If we're not done and we have friends make our movement slightly depend on our
                // index so we spread out and don't block each other
                if (!done && (Race.Flags1 & MonsterFlag1.Friends) != 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        int monsterIndex = GetMonsterIndex(saveGame);
                        targetLocation.Y = saveGame.Player.MapY + saveGame.Level.OrderedDirectionYOffset[(monsterIndex + i) & 7];
                        targetLocation.X = saveGame.Player.MapX + saveGame.Level.OrderedDirectionXOffset[(monsterIndex + i) & 7];
                        // We might have got a '5' meaning stay where we are, so replace that with
                        // moving towards the player
                        if (MapY == targetLocation.Y && MapX == targetLocation.X)
                        {
                            targetLocation.Y = saveGame.Player.MapY;
                            targetLocation.X = saveGame.Player.MapX;
                            break;
                        }
                        // Repeat till we get a direction we can move in
                        if (!saveGame.Level.GridPassableNoCreature(targetLocation.Y, targetLocation.X))
                        {
                            continue;
                        }
                        break;
                    }
                    desiredRelativeMovement.Y = MapY - targetLocation.Y;
                    desiredRelativeMovement.X = MapX - targetLocation.X;
                    done = true;
                }
            }
            // If we're an ally then check if we should retreat
            if ((Mind & Constants.SmFriendly) != 0)
            {
                if (MonsterShouldRetreat(saveGame))
                {
                    // If we should be scared, simply move the opposite way to the player
                    desiredRelativeMovement.Y = -desiredRelativeMovement.Y;
                    desiredRelativeMovement.X = -desiredRelativeMovement.X;
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
                        desiredRelativeMovement.Y = -desiredRelativeMovement.Y;
                        desiredRelativeMovement.X = -desiredRelativeMovement.X;
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
        private void AvoidPlayersScent(SaveGame saveGame, MapCoordinate coord)
        {
            int monsterY = MapY;
            int monsterX = MapX;
            int dY = monsterY - coord.Y;
            int dX = monsterX - coord.X;
            // If the scent too strong, keep going where we were going
            if (saveGame.Level.Grid[monsterY][monsterX].ScentAge < saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX].ScentAge)
            {
                return;
            }
            if (saveGame.Level.Grid[monsterY][monsterX].ScentStrength > Constants.MonsterFlowDepth)
            {
                return;
            }
            if (saveGame.Level.Grid[monsterY][monsterX].ScentStrength > Race.NoticeRange)
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
                int y = monsterY + saveGame.Level.OrderedDirectionYOffset[i];
                int x = monsterX + saveGame.Level.OrderedDirectionXOffset[i];
                // If we have no scent there, or the scent is too recent, ignore it
                if (saveGame.Level.Grid[y][x].ScentAge == 0)
                {
                    continue;
                }
                if (saveGame.Level.Grid[y][x].ScentAge < when)
                {
                    continue;
                }
                // If the scent is weaker than in the other directions, go that way
                int dis = saveGame.Level.Distance(y, x, dY, dX);
                int s = (5000 / (dis + 3)) - (500 / (saveGame.Level.Grid[y][x].ScentStrength + 1));
                if (s < 0)
                {
                    s = 0;
                }
                if (s < score)
                {
                    continue;
                }
                when = saveGame.Level.Grid[y][x].ScentAge;
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
            coord.Y = monsterY - gy;
            coord.X = monsterX - gx;
        }

        /// <summary>
        /// Adjust the coordinates we're trying to move to if we can't get directly there for some reason
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster trying to move </param>
        /// <param name="target"> The target location we're moving to </param>
        private void TrackPlayerByScent(SaveGame saveGame, MapCoordinate target)
        {
            // If we can move through walls then we don't need to adjust anything
            if ((Race.Flags2 & MonsterFlag2.PassWall) != 0)
            {
                return;
            }
            if ((Race.Flags2 & MonsterFlag2.KillWall) != 0)
            {
                return;
            }
            int y1 = MapY;
            int x1 = MapX;
            GridTile cPtr = saveGame.Level.Grid[y1][x1];
            // If we have no scent of the player then don't change where we were going
            if (cPtr.ScentAge < saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX].ScentAge)
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
            if (saveGame.Level.PlayerHasLosBold(y1, x1))
            {
                return;
            }
            int when = 0;
            int cost = 999;
            // Check the eight directions we can move to see which has the most recent or strongest scent
            for (int i = 7; i >= 0; i--)
            {
                int y = y1 + saveGame.Level.OrderedDirectionYOffset[i];
                int x = x1 + saveGame.Level.OrderedDirectionXOffset[i];
                if (saveGame.Level.Grid[y][x].ScentAge == 0)
                {
                    continue;
                }
                if (saveGame.Level.Grid[y][x].ScentAge < when)
                {
                    continue;
                }
                if (saveGame.Level.Grid[y][x].ScentStrength > cost)
                {
                    continue;
                }
                when = saveGame.Level.Grid[y][x].ScentAge;
                cost = saveGame.Level.Grid[y][x].ScentStrength;
                // Give us a target in the general direction of the strongest scent
                target.Y = saveGame.Player.MapY + (16 * saveGame.Level.OrderedDirectionYOffset[i]);
                target.X = saveGame.Player.MapX + (16 * saveGame.Level.OrderedDirectionXOffset[i]);
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
        private bool FindAmbushSpot(SaveGame saveGame, MapCoordinate relativeTarget)
        {
            int fy = MapY;
            int fx = MapX;
            int hidingSpotY = 0;
            int hidingSpotX = 0;
            int shortestDistance = 999;
            int tooCloseToPlayer = (saveGame.Level.Distance(saveGame.Player.MapY, saveGame.Player.MapX, fy, fx) * 3 / 4) + 2;
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
                        if (!saveGame.Level.InBounds(y, x))
                        {
                            continue;
                        }
                        if (!saveGame.Level.GridPassable(y, x))
                        {
                            continue;
                        }
                        // Make sure the spot is the right distance
                        if (saveGame.Level.Distance(y, x, fy, fx) != d)
                        {
                            continue;
                        }
                        // Make sure the spot is actually hidden
                        if (!saveGame.Level.PlayerCanSeeBold(y, x) && saveGame.CleanShot(fy, fx, y, x))
                        {
                            // If the spot is closer to the player than any previously found spot
                            // (but not too close), remember it
                            int dis = saveGame.Level.Distance(y, x, saveGame.Player.MapY, saveGame.Player.MapX);
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
                    relativeTarget.Y = fy - hidingSpotY;
                    relativeTarget.X = fx - hidingSpotX;
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
            if ((Mind & Constants.SmFriendly) != 0)
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
            int playerLevel = saveGame.Player.Level;
            int monsterLevel = Race.Level + (GetMonsterIndex(saveGame) & 0x08) + 25;
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
            int playerHealth = saveGame.Player.Health;
            int playerMaxHealth = saveGame.Player.MaxHealth;
            int monsterHealth = Health;
            int monsterMaxHealth = MaxHealth;
            int playerHealthFactor = (playerLevel * playerMaxHealth) + (playerHealth << 2);
            int monsterHealthFactor = (monsterLevel * monsterMaxHealth) + (monsterHealth << 2);
            return playerHealthFactor * monsterMaxHealth > monsterHealthFactor * playerMaxHealth;
        }

        /// <summary>
        /// Returns the index of this monster in the monster list.  This method is provided for backwards compatability and should NOT be used.  Will be deleted when no longer needed.
        /// </summary>
        private int GetMonsterIndex(SaveGame saveGame) // TODO: Needs to be removed.
        {
            return saveGame.Level.Monsters.GetMonsterIndex(this);
        }

        /// <summary>
        /// Have a monster make an attack on the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster making the attack </param>
        public void MonsterAttackPlayer(SaveGame saveGame)
        {
            int attackNumber;
            bool touched = false;
            bool fear = false;
            bool alive = true;
            // If the monster never attacks, then it shouldn't be attacking us now
            if ((Race.Flags1 & MonsterFlag1.NeverAttack) != 0)
            {
                return;
            }
            // Friends don't hit friends
            if ((Mind & Constants.SmFriendly) != 0)
            {
                return;
            }

            int armourClass = saveGame.Player.BaseArmourClass + saveGame.Player.ArmourClassBonus;
            int monsterLevel = Race.Level >= 1 ? Race.Level : 1;
            string monsterName = MonsterDesc(0);
            string monsterDescription = MonsterDesc(0x88);
            bool blinked = false;
            // Monsters get up to four attacks
            if (Race.Attacks != null)
            {
                for (attackNumber = 0; attackNumber < Race.Attacks.Length; attackNumber++)
                {
                    bool visible = false;
                    bool obvious = false;
                    int power = 0;
                    int damage = 0;
                    string act = null;
                    BaseAttackEffect? effect = Race.Attacks[attackNumber].Effect;
                    AttackType method = Race.Attacks[attackNumber].Method;
                    int damageDice = Race.Attacks[attackNumber].DDice;
                    int damageSides = Race.Attacks[attackNumber].DSide;
                    // If the monster doesn't have an attack in this slot, stop looping
                    if (method == AttackType.Nothing)
                    {
                        break;
                    }
                    // Stop if player is dead or gone
                    if (!alive || saveGame.Player.IsDead || saveGame.NewLevelFlag)
                    {
                        break;
                    }
                    if (IsVisible)
                    {
                        visible = true;
                    }
                    // Get the basic attack power from the attack type
                    if (effect != null)
                        power = effect.Power;

                    // Check if the monster actually hits us
                    if (effect == null || MonsterCheckHitOnPlayer(SaveGame, power, monsterLevel))
                    {
                        saveGame.Disturb(true);
                        // Protection From Evil might repel the attack
                        if (saveGame.Player.TimedProtectionFromEvil > 0 && (Race.Flags3 & MonsterFlag3.Evil) != 0 && saveGame.Player.Level >= monsterLevel && Program.Rng.RandomLessThan(100) + saveGame.Player.Level > 50)
                        {
                            if (IsVisible)
                            {
                                // If it does, then they player knows the monster is evil
                                Race.Knowledge.RFlags3 |= MonsterFlag3.Evil;
                            }
                            saveGame.MsgPrint($"{monsterName} is repelled.");
                            continue;
                        }
                        bool doCut = false;
                        bool doStun = false;
                        // Give a description and remember the possible extras based on the attack method
                        switch (method)
                        {
                            case AttackType.Hit:
                                {
                                    act = "hits you.";
                                    doCut = true;
                                    doStun = true;
                                    touched = true;
                                    break;
                                }
                            case AttackType.Touch:
                                {
                                    act = "touches you.";
                                    touched = true;
                                    break;
                                }
                            case AttackType.Punch:
                                {
                                    act = "punches you.";
                                    touched = true;
                                    doStun = true;
                                    break;
                                }
                            case AttackType.Kick:
                                {
                                    act = "kicks you.";
                                    touched = true;
                                    doStun = true;
                                    break;
                                }
                            case AttackType.Claw:
                                {
                                    act = "claws you.";
                                    touched = true;
                                    doCut = true;
                                    break;
                                }
                            case AttackType.Bite:
                                {
                                    act = "bites you.";
                                    doCut = true;
                                    touched = true;
                                    break;
                                }
                            case AttackType.Sting:
                                {
                                    act = "stings you.";
                                    touched = true;
                                    break;
                                }
                            case AttackType.Butt:
                                {
                                    act = "butts you.";
                                    doStun = true;
                                    touched = true;
                                    break;
                                }
                            case AttackType.Crush:
                                {
                                    act = "crushes you.";
                                    doStun = true;
                                    touched = true;
                                    break;
                                }
                            case AttackType.Engulf:
                                {
                                    act = "engulfs you.";
                                    touched = true;
                                    break;
                                }
                            case AttackType.Charge:
                                {
                                    act = "charges you.";
                                    touched = true;
                                    break;
                                }
                            case AttackType.Crawl:
                                {
                                    act = "crawls on you.";
                                    touched = true;
                                    break;
                                }
                            case AttackType.Drool:
                                {
                                    act = "drools on you.";
                                    break;
                                }
                            case AttackType.Spit:
                                {
                                    act = "spits on you.";
                                    break;
                                }
                            case AttackType.Gaze:
                                {
                                    act = "gazes at you.";
                                    break;
                                }
                            case AttackType.Wail:
                                {
                                    act = "wails at you.";
                                    break;
                                }
                            case AttackType.Spore:
                                {
                                    act = "releases spores at you.";
                                    break;
                                }
                            case AttackType.Worship:
                                {
                                    string[] worships = { "looks up at you!", "asks how many dragons you've killed!", "asks for your autograph!", "tries to shake your hand!", "pretends to be you!", "dances around you!", "tugs at your clothing!", "asks if you will adopt him!" };
                                    act = worships[Program.Rng.RandomLessThan(8)];
                                    break;
                                }
                            case AttackType.Beg:
                                {
                                    act = "begs you for money.";
                                    break;
                                }
                            case AttackType.Insult:
                                {
                                    string[] insults = { "insults you!", "insults your mother!", "gives you the finger!", "humiliates you!", "defiles you!", "dances around you!", "makes obscene gestures!", "moons you!" };
                                    act = insults[Program.Rng.RandomLessThan(8)];
                                    break;
                                }
                            case AttackType.Moan:
                                {
                                    string[] moans = { "seems sad about something.", "asks if you have seen his dogs.", "tells you to get off his land.", "mumbles something about mushrooms." };
                                    act = moans[Program.Rng.RandomLessThan(4)];
                                    break;
                                }
                            case AttackType.Show:
                                {
                                    act = Program.Rng.DieRoll(3) == 1 ? "sings 'We are a happy family.'" : "sings 'I love you, you love me.'";
                                    break;
                                }
                        }
                        // Print the message
                        if (!string.IsNullOrEmpty(act))
                        {
                            saveGame.MsgPrint($"{monsterName} {act}");
                        }
                        obvious = true;
                        // Work out base damage done by the attack
                        damage = Program.Rng.DiceRoll(damageDice, damageSides);
                        // Apply any modifiers to the damage
                        if (effect == null)
                        {
                            obvious = true;
                            damage = 0;
                        }
                        else
                            effect.ApplyToPlayer(saveGame, monsterLevel, GetMonsterIndex(saveGame), armourClass, monsterDescription, this, ref obvious, ref damage, ref blinked);

                        // Be nice and don't let us be both stunned and cut by the same blow
                        if (doCut && doStun)
                        {
                            if (Program.Rng.RandomLessThan(100) < 50)
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
                                    k = Program.Rng.DieRoll(5);
                                    break;

                                case 2:
                                    k = Program.Rng.DieRoll(5) + 5;
                                    break;

                                case 3:
                                    k = Program.Rng.DieRoll(20) + 20;
                                    break;

                                case 4:
                                    k = Program.Rng.DieRoll(50) + 50;
                                    break;

                                case 5:
                                    k = Program.Rng.DieRoll(100) + 100;
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
                                saveGame.Player.SetTimedBleeding(saveGame.Player.TimedBleeding + k);
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
                                    k = Program.Rng.DieRoll(5);
                                    break;

                                case 2:
                                    k = Program.Rng.DieRoll(10) + 10;
                                    break;

                                case 3:
                                    k = Program.Rng.DieRoll(20) + 20;
                                    break;

                                case 4:
                                    k = Program.Rng.DieRoll(30) + 30;
                                    break;

                                case 5:
                                    k = Program.Rng.DieRoll(40) + 40;
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
                                saveGame.Player.SetTimedStun(saveGame.Player.TimedStun + k);
                            }
                        }
                        // If the monster touched us then it may take damage from our defensive abilities
                        if (touched)
                        {
                            if (saveGame.Player.HasFireShield && alive)
                            {
                                if ((Race.Flags3 & MonsterFlag3.ImmuneFire) == 0)
                                {
                                    saveGame.MsgPrint($"{monsterName} is suddenly very hot!");
                                    if (saveGame.Level.Monsters.DamageMonster(GetMonsterIndex(saveGame), Program.Rng.DiceRoll(2, 6), out fear,
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
                                        Race.Knowledge.RFlags3 |= MonsterFlag3.ImmuneFire;
                                    }
                                }
                            }
                            if (saveGame.Player.HasLightningShield && alive)
                            {
                                if ((Race.Flags3 & MonsterFlag3.ImmuneLightning) == 0)
                                {
                                    saveGame.MsgPrint($"{monsterName} gets zapped!");
                                    if (saveGame.Level.Monsters.DamageMonster(GetMonsterIndex(saveGame), Program.Rng.DiceRoll(2, 6), out fear,
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
                                        Race.Knowledge.RFlags3 |= MonsterFlag3.ImmuneLightning;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // It missed us, so give us the appropriate message
                        switch (method)
                        {
                            case AttackType.Hit:
                            case AttackType.Touch:
                            case AttackType.Punch:
                            case AttackType.Kick:
                            case AttackType.Claw:
                            case AttackType.Bite:
                            case AttackType.Sting:
                            case AttackType.Butt:
                            case AttackType.Crush:
                            case AttackType.Engulf:
                            case AttackType.Charge:
                                if (IsVisible)
                                {
                                    saveGame.Disturb(true);
                                    saveGame.MsgPrint($"{monsterName} misses you.");
                                }
                                break;
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
            }
            // If the monster teleported away after stealing, let the player know and do the actual teleport
            if (blinked)
            {
                saveGame.MsgPrint("The thief flees laughing!");
                TeleportAway(saveGame, (Constants.MaxSight * 2) + 5);
            }
            // If the attack just killed the player, let future generations remember what killed
            // their ancestor
            if (saveGame.Player.IsDead && Race.Knowledge.RDeaths < Constants.MaxShort)
            {
                Race.Knowledge.RDeaths++;
            }
            // If the monster just got scared, let the player know
            if (IsVisible && fear)
            {
                saveGame.PlaySound(SoundEffect.MonsterFlees);
                saveGame.MsgPrint($"{monsterName} flees in terror!");
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
                        ny = Program.Rng.RandomSpread(oy, dis);
                        nx = Program.Rng.RandomSpread(ox, dis);
                        int d = saveGame.Level.Distance(oy, ox, ny, nx);
                        if (d >= min && d <= dis)
                        {
                            break;
                        }
                    }
                    if (!saveGame.Level.InBounds(ny, nx))
                    {
                        continue;
                    }
                    if (!saveGame.Level.GridPassableNoCreature(ny, nx))
                    {
                        continue;
                    }
                    if (saveGame.Level.Grid[ny][nx].FeatureType.Name == "ElderSign")
                    {
                        continue;
                    }
                    if (saveGame.Level.Grid[ny][nx].FeatureType.Name == "YellowSign")
                    {
                        continue;
                    }
                    look = false;
                    break;
                }
                dis *= 2;
                min /= 2;
            }
            saveGame.PlaySound(SoundEffect.Teleport);
            saveGame.Level.Grid[ny][nx].MonsterIndex = GetMonsterIndex(saveGame);
            saveGame.Level.Grid[oy][ox].MonsterIndex = 0;
            MapY = ny;
            MapX = nx;
            saveGame.Level.Monsters.UpdateMonsterVisibility(GetMonsterIndex(saveGame), true);
            saveGame.Level.RedrawSingleLocation(oy, ox);
            saveGame.Level.RedrawSingleLocation(ny, nx);
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
                if (saveGame.Level.InBounds(y, x))
                {
                    if (saveGame.Level.Grid[y][x].MonsterIndex != 0)
                    {
                        Monster enemy = saveGame.Level.Monsters[saveGame.Level.Grid[y][x].MonsterIndex];
                        // Only go for monsters who are awake and on the opposing side
                        if ((enemy.Mind & Constants.SmFriendly) != (Mind & Constants.SmFriendly) &&
                            enemy.SleepLevel == 0)
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
        /// <param name="armourClass"> The armour class of the defending monster </param>
        /// <returns> True for a hit or false for a miss </returns>
        private bool CheckHitMonsterVersusMonster(int power, int level, int armourClass)
        {
            // Base 5% chance to hit and 5% chance to miss
            int k = Program.Rng.RandomLessThan(100);
            if (k < 10)
            {
                return k < 5;
            }
            // If we didn't auto hit or miss, use the standard formula for attacking
            int i = power + (level * 3);
            return i > 0 && Program.Rng.DieRoll(i) > armourClass * 3 / 4;
        }

        /// <summary>
        /// Chooses a spell for the monster to attack the player with
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster casting the spell </param>
        /// <param name="spells">A list of the 'magic numbers' of the spells the monster can cast</param>
        /// <param name="listSize"> The number of spells in the spell list </param>
        /// <returns> The 'magic number' of the spell the monster will cast </returns>
        private int ChooseSpellAgainstPlayer(SaveGame saveGame, int[] spells, int listSize)
        {
            // If the monster is stupid, cast a random spell
            if ((Race.Flags2 & MonsterFlag2.Stupid) != 0)
            {
                return spells[Program.Rng.RandomLessThan(listSize)];
            }
            // Deposit the spells into a number of buckets based on what they are used for
            int[] escape = new int[96];
            int escapeNum = 0;
            int[] attack = new int[96];
            int attackNum = 0;
            int[] summon = new int[96];
            int summonNum = 0;
            int[] tactic = new int[96];
            int tacticNum = 0;
            int[] annoy = new int[96];
            int annoyNum = 0;
            int[] haste = new int[96];
            int hasteNum = 0;
            int[] heal = new int[96];
            int healNum = 0;
            for (int i = 0; i < listSize; i++)
            {
                if (SpellIsForEscape(spells[i]))
                {
                    escape[escapeNum++] = spells[i];
                }
                if (SpellIsForAttack(spells[i]))
                {
                    attack[attackNum++] = spells[i];
                }
                if (SpellIsForSummoning(spells[i]))
                {
                    summon[summonNum++] = spells[i];
                }
                if (SpellIsTactical(spells[i]))
                {
                    tactic[tacticNum++] = spells[i];
                }
                if (SpellIsForAnnoyance(spells[i]))
                {
                    annoy[annoyNum++] = spells[i];
                }
                if (SpellIsForHaste(spells[i]))
                {
                    haste[hasteNum++] = spells[i];
                }
                if (SpellIsForHealing(spells[i]))
                {
                    heal[healNum++] = spells[i];
                }
            }
            // Priority One: If we're afraid or hurt, always use a random escape spell if we have one
            if (Health < MaxHealth / 3 || FearLevel != 0)
            {
                if (escapeNum != 0)
                {
                    return escape[Program.Rng.RandomLessThan(escapeNum)];
                }
            }
            // Priority Two: If we're hurt, always use a random healing spell if we have one
            if (Health < MaxHealth / 3)
            {
                if (healNum != 0)
                {
                    return heal[Program.Rng.RandomLessThan(healNum)];
                }
            }
            // Priority Three: If we're near the player and have no attack spells, probably use a
            // tactical spell
            if (saveGame.Level.Distance(saveGame.Player.MapY, saveGame.Player.MapX, MapY, MapX) < 4 && attackNum != 0 &&
                Program.Rng.RandomLessThan(100) < 75)
            {
                if (tacticNum != 0)
                {
                    return tactic[Program.Rng.RandomLessThan(tacticNum)];
                }
            }
            // Priority Four: If we're at less than full health, probably use a healing spell
            if (Health < MaxHealth * 3 / 4 && Program.Rng.RandomLessThan(100) < 75)
            {
                if (healNum != 0)
                {
                    return heal[Program.Rng.RandomLessThan(healNum)];
                }
            }
            // Priority Five: If we have a summoning spell, maybe use it
            if (summonNum != 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                return summon[Program.Rng.RandomLessThan(summonNum)];
            }
            // Priority Six: If we have a direct attack spell, probably use it
            if (attackNum != 0 && Program.Rng.RandomLessThan(100) < 85)
            {
                return attack[Program.Rng.RandomLessThan(attackNum)];
            }
            // Priority Seven: If we have a tactical spell, maybe use it
            if (tacticNum != 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                return tactic[Program.Rng.RandomLessThan(tacticNum)];
            }
            // Priority Eight: If we have a haste spell, maybe use it
            if (hasteNum != 0 && Program.Rng.RandomLessThan(100) < 20 + Race.Speed - Speed)
            {
                return haste[Program.Rng.RandomLessThan(hasteNum)];
            }
            // Priority Nine: If we have an annoying spell, probably use it
            if (annoyNum != 0 && Program.Rng.RandomLessThan(100) < 85)
            {
                return annoy[Program.Rng.RandomLessThan(annoyNum)];
            }
            // Priority Ten: Give up on using a spell
            return 0;
        }

        /// <summary>
        /// Return whether or not a spell is suitable for annoying the player
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell is annoying, false otherwise </returns>
        private bool SpellIsForAnnoyance(int spell)
        {
            // MonsterFlag4.Shriek
            if (spell == 96 + 0)
            {
                return true;
            }
            // MonsterFlag5.DrainMana MonsterFlag5.MindBlast MonsterFlag5.BrainSmash
            // MonsterFlag5.CauseLightWounds MonsterFlag5.CauseSeriousWounds MonsterFlag5.CauseCriticalWounds
            if (spell >= 128 + 9 && spell <= 128 + 14)
            {
                return true;
            }
            // MonsterFlag5.Scare MonsterFlag5.Blindness MonsterFlag5.Confuse MonsterFlag5.Slow MonsterFlag5.Hold
            if (spell >= 128 + 27 && spell <= 128 + 31)
            {
                return true;
            }
            // MonsterFlag6.TeleportTo
            if (spell == 160 + 8)
            {
                return true;
            }
            // MonsterFlag6.Darkness MonsterFlag6.CreateTraps MonsterFlag6.Forget
            if (spell >= 160 + 12 && spell <= 160 + 14)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return whether a spell is primarily an attack spell
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell is an attack spell, false otherwise </returns>
        private bool SpellIsForAttack(int spell)
        {
            // MonsterFlag4.ShardBall MonsterFlag4.Arrow1D6 MonsterFlag4.Arrow3D6
            // MonsterFlag4.Arrow5D6 MonsterFlag4.Arrow7D6 MonsterFlag4.BreatheAcid
            // MonsterFlag4.BreatheLightning MonsterFlag4.BreatheFire MonsterFlag4.BreatheCold
            // MonsterFlag4.BreathePoison MonsterFlag4.BreatheNether MonsterFlag4.BreatheLight
            // MonsterFlag4.BreatheDark MonsterFlag4.BreatheConfusion MonsterFlag4.BreatheSound
            // MonsterFlag4.BreatheChaos MonsterFlag4.BreatheDisenchant MonsterFlag4.BreatheNexus
            // MonsterFlag4.BreatheTime MonsterFlag4.BreatheInertia MonsterFlag4.BreatheGravity
            // MonsterFlag4.BreatheShards MonsterFlag4.BreathePlasma MonsterFlag4.BreatheForce
            // MonsterFlag4.BreatheMana MonsterFlag4.RadiationBall MonsterFlag4.BreatheRadiation
            // MonsterFlag4.ChaosBall MonsterFlag4.BreatheDisintegration
            if (spell < 128 && spell > 96)
            {
                return true;
            }
            // MonsterFlag5.AcidBall MonsterFlag5.LightningBall MonsterFlag5.FireBall
            // MonsterFlag5.ColdBall MonsterFlag5.PoisonBall MonsterFlag5.NetherBall
            // MonsterFlag5.WaterBall MonsterFlag5.ManaBall MonsterFlag5.DarkBall
            if (spell >= 128 && spell <= 128 + 8)
            {
                return true;
            }
            // MonsterFlag5.CauseLightWounds MonsterFlag5.CauseSeriousWounds
            // MonsterFlag5.CauseCriticalWounds MonsterFlag5.CauseMortalWounds MonsterFlag5.AcidBolt
            // MonsterFlag5.LightningBolt MonsterFlag5.FireBolt MonsterFlag5.ColdBolt
            // MonsterFlag5.PoisonBolt MonsterFlag5.NetherBolt MonsterFlag5.WaterBolt
            // MonsterFlag5.ManaBolt MonsterFlag5.PlasmaBolt MonsterFlag5.IceBolt
            // MonsterFlag5.MagicMissile MonsterFlag5.Scare
            if (spell >= 128 + 12 && spell <= 128 + 27)
            {
                return true;
            }
            // MonsterFlag6.DreadCurse
            if (spell == 160 + 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return whether or not a spell is suitable for escaping the player
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell is good for escaping, false otherwise </returns>
        private bool SpellIsForEscape(int spell)
        {
            // MonsterFlag6.Blink MonsterFlag6.TeleportSelf
            if (spell == 160 + 4 || spell == 160 + 5)
            {
                return true;
            }
            // MonsterFlag6.TeleportAway MonsterFlag6.TeleportLevel
            if (spell == 160 + 9 || spell == 160 + 10)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return whether or not a spell is suitable for hasting oneself
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell is good for hasting, false otherwise </returns>
        private bool SpellIsForHaste(int spell)
        {
            // MonsterFlag6.Haste
            return spell == 160 + 0;
        }

        /// <summary>
        /// Return whether or not a spell is suitable for healing oneself
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell is good for healing, false otherwise </returns>
        private bool SpellIsForHealing(int spell)
        {
            // MonsterFlag6.Heal
            return spell == 160 + 2;
        }

        /// <summary>
        /// Return whether or not a spell is a summoning spell
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell is a summoning spell, false otherwise </returns>
        private bool SpellIsForSummoning(int spell)
        {
            // MonsterFlag6.SummonKin MonsterFlag6.SummonReaver MonsterFlag6.SummonMonster
            // MonsterFlag6.SummonMonsters MonsterFlag6.SummonAnt MonsterFlag6.SummonSpider
            // MonsterFlag6.SummonHound MonsterFlag6.SummonHydra MonsterFlag6.SummonCthuloid
            // MonsterFlag6.SummonDemon MonsterFlag6.SummonUndead MonsterFlag6.SummonDragon
            // MonsterFlag6.SummonHiUndead MonsterFlag6.SummonHiDragon
            // MonsterFlag6.SummonGreatOldOne MonsterFlag6.SummonUnique
            return spell >= 160 + 16;
        }

        /// <summary>
        /// Return whether or not a spell gives a tactical advantage
        /// </summary>
        /// <param name="spell"> The spell's number (32*flags + bit in flag) </param>
        /// <returns> True if the spell gives a tactical advantage, false otherwise </returns>
        private bool SpellIsTactical(int spell)
        {
            // MonsterFlag6.Blink
            return spell == 160 + 4;
        }

        /// <summary>
        /// Find a spot that as far from the player as possible an safe from attack
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster trying to find safety </param>
        /// <param name="relativeTarget">
        /// A map location, which will be amended to contain the safe spot
        /// </param>
        /// <returns> True if a safe spot was found, or false if it wasn't </returns>
        private bool FindSafeSpot(SaveGame saveGame, MapCoordinate relativeTarget)
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
                        if (!saveGame.Level.InBounds(y, x))
                        {
                            continue;
                        }
                        if (!saveGame.Level.GridPassable(y, x))
                        {
                            continue;
                        }
                        // Make sure the spot is the right distance
                        if (saveGame.Level.Distance(y, x, MapY, MapY) != d)
                        {
                            continue;
                        }
                        // Reject spots that smell too strongly of the player
                        if (saveGame.Level.Grid[y][x].ScentAge < saveGame.Level.Grid[saveGame.Player.MapY][saveGame.Player.MapX].ScentAge)
                        {
                            continue;
                        }
                        if (saveGame.Level.Grid[y][x].ScentStrength > saveGame.Level.Grid[MapY][MapY].ScentStrength + (2 * d))
                        {
                            continue;
                        }
                        // Make sure the spot is actually hidden
                        if (!saveGame.Level.Projectable(y, x, saveGame.Player.MapY, saveGame.Player.MapX))
                        {
                            // If the spot is further from the player than any previously found
                            // spot, remember it
                            int dis = saveGame.Level.Distance(y, x, saveGame.Player.MapY, saveGame.Player.MapX);
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
                    relativeTarget.Y = MapY - safeSpotY;
                    relativeTarget.X = MapY - safeSpotX;
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
            int k = Program.Rng.RandomLessThan(100);
            if (k < 10)
            {
                return k < 5;
            }
            // Otherwise, compare the power and level to the player's armour class
            int i = attackPower + (monsterLevel * 3);
            int ac = saveGame.Player.BaseArmourClass + saveGame.Player.ArmourClassBonus;
            return i > 0 && Program.Rng.DieRoll(i) > ac * 3 / 4;
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
            if (damage < 20 && Program.Rng.RandomLessThan(100) >= damage)
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
                while (Program.Rng.RandomLessThan(100) < 2)
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
}