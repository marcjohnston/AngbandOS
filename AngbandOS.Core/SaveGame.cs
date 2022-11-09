// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.ActivationPowers;
using AngbandOS.Commands;
using AngbandOS.Debug;
using AngbandOS.Enumerations;
using AngbandOS.Mutations;
using AngbandOS.Patrons;
using AngbandOS.Projection;
using AngbandOS.StaticData;
using System.Drawing;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using AngbandOS.ItemCategories;

namespace AngbandOS
{
    [Serializable]
    internal class SaveGame
    {
        /// <summary>
        /// Maximum amount of health that can be drained from an opponent in one turn
        /// </summary>
        private const int _maxVampiricDrain = 100;
        private AutoNavigator _autoNavigator;

        /// <summary>
        /// Returns the date and time when the last player input was received or the game was initially started.  Null, until the game is started.
        /// </summary>
        public DateTime? LastInputReceived = null;

        public int CommandRepeat;
        public readonly Dungeon[] Dungeons;
        public readonly Patron[] PatronList;
        public readonly QuestArray Quests;
        public readonly Town[] Towns;
        public readonly Island Wilderness = new Island();
        public int AllocKindSize;
        public AllocationEntry[] AllocKindTable;
        public int AllocRaceSize;
        public AllocationEntry[] AllocRaceTable;
        public LevelStart CameFrom;
        public bool CharacterXtra;
        public bool CreateDownStair;
        public bool CreateUpStair;
        public Dungeon CurDungeon;
        public int CurrentDepth;
        public Town CurTown;
        public string DiedFrom;
        public int DungeonDifficulty;
        public int EnergyUse;
        public bool HackMind;
        public int ItemDisplayColumn = 50;
        public ItemFilterDelegate ItemFilter;
        public bool ItemFilterAll;
        public Level Level;
        public bool MartialArtistArmourAux;
        public bool MartialArtistNotifyAux;
        public bool NewLevelFlag;
        public Player Player;
        public bool Playing;
        public int RecallDungeon;
        public int Resting;
        public int Running;
        public List<BaseAmuletFlavour> AmuletFlavours; // This is the randomized list for the game.
        public List<BaseMushroomFlavour> MushroomFlavours;
        public List<BasePotionFlavour> PotionFlavours;
        public List<BaseRingFlavour> RingFlavours;
        public List<BaseRodFlavour> RodFlavours;
        public List<ScrollFlavour> ScrollFlavours; // These are generated from the available base scrolls.
        public List<BaseStaffFlavour> StaffFlavours;
        public List<BaseWandFlavour> WandFlavours; // This is a list of all of the wand flavors.  They are randomized for each game.
        public int TargetCol;
        public int TargetRow;
        public int TargetWho;
        public int TotalFriendLevels;
        public int TotalFriends;
        public int TrackedMonsterIndex;
        public bool ViewingEquipment;
        public bool ViewingItemList;

        private List<Monster> _petList = new List<Monster>();
        private int _seedFlavor;
        public const int HurtChance = 16;

        [NonSerialized]
        private ICorePersistentStorage PersistentStorage;

        /// <summary>
        /// Returns the object used to provide game updates to the calling application.  Returns null, when the calling application did not present an update notififying object.
        /// </summary>
        [NonSerialized]
        public IUpdateNotifier? UpdateNotifier;

        /// <summary>
        /// Returns the object that the calling application provided to be used to connect the game input and output to the calling application.
        /// </summary>
        [NonSerialized]
        private IConsole _console;

        public int CommandArgument;
        public int CommandDirection;
        public char CurrentCommand;

        /// <summary>
        /// Set to skip waiting for a keypress in the Inkey() function.  Set to true when running which disturbs the player when a keystroke is found
        /// and also set to true, during wizard play with object statistics command.
        /// </summary>
        public bool DoNotWaitOnInkey;

        /// <summary>
        /// Set to indicate that there is a full screen overlay covering the normally updated locations
        /// </summary>
        public bool FullScreenOverlay;

        /// <summary>
        /// Set to indicate that the cursor should be hidden while waiting for a keypress with a
        /// full screen overlay
        /// </summary>
        public bool HideCursorOnFullScreenInkey;

        public bool InPopupMenu;
        public char QueuedCommand;
        /// DISPLAY
        public Colour AttrBlank;
        public char CharBlank;
        public int Height;
        public char[] KeyQueue;
        public int KeySize;
        public Screen Old;
        public Screen Scr;
        public int Width;
        public int[] X1;
        public int[] X2;
        public int KeyHead = 0;
        public int KeyTail = 0;
        public Screen Mem;
        public bool TotalErase;
        public int Y1;
        public int Y2;
        /// DISPLAY

        /// <summary>
        /// A buffer of artificial keypresses
        /// </summary>
        private string _keyBuffer;

        private string[][] _keymapAct;
        private string _requestCommandBuffer;
        /// GUI

        private void PopulateNewProfile()
        {
            FixedArtifacts = new FixedArtifactArray(this);
            MonsterRaces = new MonsterRaceArray(this);
            MonsterRaces.AddKnowledge();
            RareItemTypes = new RareItemTypeArray(this);
            ItemTypes = new ItemTypeArray(this);
            VaultTypes = new VaultTypeArray(this);
        }

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public SaveGame()
        {
            _autoNavigator = new AutoNavigator(this);
            Quests = new QuestArray(this);
            PopulateNewProfile();
            Towns = Town.NewTownList(this);
            Dungeons = Dungeon.NewDungeonList();
            PatronList = Patron.NewPatronList(this);
            InitializeAllocationTables();
        }

        public void Quit(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                MessageBoxShow(reason);
            }
        }


        public BaseItemCategory RandomItemType(int level, bool doNotAllowChestToBeCreated)
        {
            int i;
            int j;
            AllocationEntry[] table = AllocKindTable;
            if (level > 0)
            {
                if (Program.Rng.RandomLessThan(Constants.GreatObj) == 0)
                {
                    level = 1 + (level * Constants.MaxDepth / Program.Rng.DieRoll(Constants.MaxDepth));
                }
            }
            int total = 0;
            for (i = 0; i < AllocKindSize; i++)
            {
                if (table[i].Level > level)
                {
                    break;
                }
                table[i].FinalProbability = 0;
                int kIdx = table[i].Index;
                BaseItemCategory kPtr = ItemTypes[kIdx];
                if (doNotAllowChestToBeCreated && kPtr.CategoryEnum == ItemCategory.Chest)
                {
                    continue;
                }
                table[i].FinalProbability = table[i].FilteredProbabiity;
                total += table[i].FinalProbability;
            }
            if (total <= 0)
            {
                return null;
            }
            long value = Program.Rng.RandomLessThan(total);
            for (i = 0; i < AllocKindSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            int p = Program.Rng.RandomLessThan(100);
            if (p < 60)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < AllocKindSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            if (p < 10)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < AllocKindSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            return ItemTypes[table[i].Index];
        }

        public void MessageBoxShow(string message)
        {
            // MessageBox.Show(reason, Constants.VersionName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Serializes an object and uses the persistent storage services to write the object to the desired facilities.
        /// </summary>
        /// <param name="player">The player to save.  If the player is dead (Player == null), then this should be the corpse.</param>
        public void SavePlayer(Player player)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream memoryStream = new MemoryStream();
            formatter.Serialize(memoryStream, this);
            memoryStream.Position = 0;
            GameDetails gameDetails = new GameDetails()
            {
                CharacterName = player.Name, // The player parameter
                Level = player.Level, // The player parameter
                Gold = player.Gold, // The parameter
                IsAlive = Player != null, // If the player is dead, then the savegame Player will be null.
                Comments = ""
            };
            PersistentStorage?.WriteGame(gameDetails, memoryStream.ToArray());
        }

        public static SaveGame Initialize(ICorePersistentStorage persistentStorage)
        {
            byte[] data = null;

            // Retrieve the game from the persistent storage.
            if (persistentStorage != null)
                data = persistentStorage.ReadGame();

            // The game doesn't exist.  Start a new one.
            if (data == null)
                return new SaveGame();
            else
            {
                // Deserialize the game.
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream memoryStream = new MemoryStream(data);
                return (SaveGame)formatter.Deserialize(memoryStream);
            }
        }

        public void Play(IConsole console, ICorePersistentStorage persistentStorage, IUpdateNotifier updateNotification)
        {
            _console = console;
            LastInputReceived = DateTime.Now;
            PersistentStorage = persistentStorage;
            UpdateNotifier = updateNotification;
            InitializeDisplay(Constants.ConsoleWidth, Constants.ConsoleHeight, 256);
            MapMovementKeys();

            FullScreenOverlay = true;
            SetBackground(BackgroundImage.Normal);
            CursorVisible = false;
            if (Program.Rng.UseFixed)
            {
                Program.Rng.UseFixed = false;
            }
            if (Player == null)
            {
                PlayerFactory factory = new PlayerFactory(this);
                Player newPlayer = factory.CharacterGeneration(this, ExPlayer);
                if (newPlayer == null)
                {
                    return;
                }
                Player = newPlayer;
                foreach (Town town in Towns)
                {
                    foreach (Store store in town.Stores)
                    {
                        store.StoreInit();
                        store.StoreMaint();
                    }
                }
                Level = null;
                _seedFlavor = Program.Rng.RandomLessThan(int.MaxValue);
                CreateWorld();
                foreach (var dungeon in Dungeons)
                {
                    dungeon.RandomiseOffset();
                }
                ItemTypes.ResetStompability();
                CurrentDepth = 0;
                CurTown = Towns[Program.Rng.RandomLessThan(Towns.Length)];
                while (CurTown.Char == 'K' || CurTown.Char == 'N')
                {
                    CurTown = Towns[Program.Rng.RandomLessThan(Towns.Length)];
                }
                CurDungeon = Dungeons[CurTown.Index];
                RecallDungeon = CurDungeon.Index;
                Player.MaxDlv[RecallDungeon] = 1;
                DungeonDifficulty = 0;
                Player.WildernessX = CurTown.X;
                Player.WildernessY = CurTown.Y;
                CameFrom = LevelStart.StartRandom;
            }
            UpdateNotifier?.GameStarted();
            MsgFlag = false;
            MsgPrint(null);
            UpdateScreen();
            FlavorInit();
            ApplyFlavourVisuals();
            if (Level == null)
            {
                Level = new Level(this);
                LevelFactory factory = new LevelFactory(this);
                factory.GenerateNewLevel();
            }
            FullScreenOverlay = false;
            SetBackground(BackgroundImage.Overhead);
            Playing = true;
            if (Player.Health < 0)
            {
                Player.IsDead = true;
            }
            while (true)
            {
                DungeonLoop();
                if (Player.NoticeFlags != 0)
                {
                    NoticeStuff();
                }
                if (Player.UpdatesNeeded.IsSet())
                {
                    UpdateStuff();
                }
                if (Player.RedrawNeeded.IsSet())
                {
                    RedrawStuff();
                }
                TargetWho = 0;
                HealthTrack(0);
                Level.ForgetLight();
                Level.ForgetView();
                if (!Playing && !Player.IsDead)
                {
                    break;
                }
                Level.WipeOList();
                _petList = Level.Monsters.GetPets();
                Level.Monsters.WipeMList();
                MsgPrint(null);
                if (Player.IsDead)
                {
                    UpdateNotifier?.PlayerDied(Player.Name, DiedFrom, Player.Level);

                    // Store the player info
                    ExPlayer = new ExPlayer(Player);
                    break;
                }
                Level = new Level(this);
                LevelFactory factory = new LevelFactory(this);
                factory.GenerateNewLevel();
                Level.ReplacePets(Player.MapY, Player.MapX, _petList);
            }
            UpdateNotifier?.GameStopped();
            CloseGame();
        }

        internal delegate bool ItemFilterDelegate(Item item);

        // PROFILE MESSAGING START
        public ExPlayer ExPlayer;
        public FixedArtifactArray FixedArtifacts;
        public ItemTypeArray ItemTypes;
        public MonsterRaceArray MonsterRaces;
        public RareItemTypeArray RareItemTypes;
        public VaultTypeArray VaultTypes;
        private readonly List<string> _messageBuf = new List<string>();
        private readonly List<int> _messageCounts = new List<int>();
        private int _msgPrintP;
        public bool MsgFlag;

        public void MessageAdd(string str)
        {
            // simple case - list is empty
            if (_messageBuf.Count == 0)
            {
                _messageBuf.Add(str);
                _messageCounts.Add(1);
                return;
            }

            // If it's not blank it might be a repeat
            if (!string.IsNullOrEmpty(str))
            {
                if (_messageBuf[_messageBuf.Count - 1] == str)
                {
                    // Same as last - just increment the count
                    _messageCounts[_messageCounts.Count - 1]++;
                    return;
                }
            }

            // We're still here, so we just add ourselves
            _messageBuf.Add(str);
            _messageCounts.Add(1);
            // Limit the size
            if (_messageBuf.Count > 2048)
            {
                _messageBuf.RemoveAt(0);
                _messageCounts.RemoveAt(0);
            }
        }

        public int MessageNum()
        {
            return _messageBuf.Count;
        }

        public string MessageStr(int age)
        {
            if (age >= _messageBuf.Count)
            {
                return string.Empty;
            }
            string message = _messageBuf[_messageBuf.Count - age - 1];
            int count = _messageCounts[_messageCounts.Count - age - 1];
            if (count > 1)
            {
                message += $" (x{count})";
            }
            return message;
        }

        public void MsgPrint(string msg)
        {
            if (!MsgFlag)
            {
                _msgPrintP = 0;
            }
            int n = string.IsNullOrEmpty(msg) ? 0 : msg.Length;
            if (_msgPrintP != 0 && (string.IsNullOrEmpty(msg) || _msgPrintP + n > 72))
            {
                MsgFlush(_msgPrintP);
                MsgFlag = false;
                _msgPrintP = 0;
            }
            if (string.IsNullOrEmpty(msg))
            {
                return;
            }
            if (msg.Length > 2)
            {
                msg = msg.Substring(0, 1).ToUpper() + msg.Substring(1);
            }
            if (n > 1000)
            {
                return;
            }
            if (Player != null)
            {
                MessageAdd(msg);
            }
            string buf = msg;
            string t = buf;
            while (n > 72)
            {
                int split = 72;
                for (int check = 40; check < 72; check++)
                {
                    if (t[check] == ' ')
                    {
                        split = check;
                    }
                }
                Print(Colour.White, t.Substring(0, split), 0, 0, split);
                MsgFlush(split + 1);
                t = t.Substring(split);
                n -= split;
            }
            Print(Colour.White, t, 0, _msgPrintP, n);
            MsgFlag = true;
            _msgPrintP += n + 1;
        }
        private void MsgFlush(int x)
        {
            const Colour a = Colour.BrightBlue;
            Print(a, "-more-", 0, x);
            while (true)
            {
                Inkey();
                break;
            }
            Erase(0, 0, 255);
        }
        // PROFILE MESSAGING END

        public int Difficulty => CurrentDepth + DungeonDifficulty;

        public void ActivateDreadCurse()
        {
            int i = 0;
            do
            {
                switch (Program.Rng.DieRoll(27))
                {
                    case 1:
                    case 2:
                    case 3:
                    case 16:
                    case 17:
                        AggravateMonsters(1);
                        break;

                    case 4:
                    case 5:
                    case 6:
                        ActivateHiSummon();
                        break;

                    case 7:
                    case 8:
                    case 9:
                    case 18:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, 0);
                        break;

                    case 10:
                    case 11:
                    case 12:
                        MsgPrint("You feel your life draining away...");
                        Player.LoseExperience(Player.ExperiencePoints / 16);
                        break;

                    case 13:
                    case 14:
                    case 15:
                    case 19:
                    case 20:
                        if (!Player.HasFreeAction || Program.Rng.DieRoll(100) >= Player.SkillSavingThrow)
                        {
                            MsgPrint("You feel like a statue!");
                            if (Player.HasFreeAction)
                            {
                                Player.SetTimedParalysis(Player.TimedParalysis + Program.Rng.DieRoll(3));
                            }
                            else
                            {
                                Player.SetTimedParalysis(Player.TimedParalysis + Program.Rng.DieRoll(13));
                            }
                        }
                        break;

                    case 21:
                    case 22:
                    case 23:
                        Player.TryDecreasingAbilityScore(Program.Rng.DieRoll(6) - 1);
                        break;

                    case 24:
                        MsgPrint("Huh? Who am I? What am I doing here?");
                        LoseAllInfo();
                        break;

                    case 25:
                        SummonReaver();
                        break;

                    default:
                        while (i < 6)
                        {
                            do
                            {
                                Player.TryDecreasingAbilityScore(i);
                            } while (Program.Rng.DieRoll(2) == 1);
                            i++;
                        }
                        break;
                }
            } while (Program.Rng.DieRoll(3) == 1);
        }

        public void ChestTrap(int y, int x, int oIdx)
        {
            Item oPtr = Level.Items[oIdx];
            if (oPtr.TypeSpecificValue <= 0)
            {
                return;
            }
            int trap = GlobalData.ChestTraps[oPtr.TypeSpecificValue];
            if ((trap & Enumerations.ChestTrap.ChestLoseStr) != 0)
            {
                MsgPrint("A small needle has pricked you!");
                Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
                Player.TryDecreasingAbilityScore(Ability.Strength);
            }
            if ((trap & Enumerations.ChestTrap.ChestLoseCon) != 0)
            {
                MsgPrint("A small needle has pricked you!");
                Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
                Player.TryDecreasingAbilityScore(Ability.Constitution);
            }
            if ((trap & Enumerations.ChestTrap.ChestPoison) != 0)
            {
                MsgPrint("A puff of green gas surrounds you!");
                if (!(Player.HasPoisonResistance || Player.TimedPoisonResistance != 0))
                {
                    if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                    {
                        MsgPrint("Hagarg Ryonis's favour protects you!");
                    }
                    else
                    {
                        Player.SetTimedPoison(Player.TimedPoison + 10 + Program.Rng.DieRoll(20));
                    }
                }
            }
            if ((trap & Enumerations.ChestTrap.ChestParalyze) != 0)
            {
                MsgPrint("A puff of yellow gas surrounds you!");
                if (!Player.HasFreeAction)
                {
                    Player.SetTimedParalysis(Player.TimedParalysis + 10 + Program.Rng.DieRoll(20));
                }
            }
            if ((trap & Enumerations.ChestTrap.ChestSummon) != 0)
            {
                int num = 2 + Program.Rng.DieRoll(3);
                MsgPrint("You are enveloped in a cloud of smoke!");
                for (int i = 0; i < num; i++)
                {
                    if (Program.Rng.DieRoll(100) < Difficulty)
                    {
                        ActivateHiSummon();
                    }
                    else
                    {
                        Level.Monsters.SummonSpecific(y, x, Difficulty, 0);
                    }
                }
            }
            if ((trap & Enumerations.ChestTrap.ChestExplode) != 0)
            {
                MsgPrint("There is a sudden explosion!");
                MsgPrint("Everything inside the chest is destroyed!");
                oPtr.TypeSpecificValue = 0;
                Player.TakeHit(Program.Rng.DiceRoll(5, 8), "an exploding chest");
            }
        }

        public void DisplayWildMap()
        {
            int[] dungeonGuardians = new int[Constants.MaxCaves];
            int y, i;
            for (i = 0; i < Constants.MaxCaves; i++)
            {
                dungeonGuardians[i] = 0;
            }
            for (i = 0; i < Quests.Count; i++)
            {
                if (Quests[i].IsActive)
                {
                    dungeonGuardians[Quests[i].Dungeon]++;
                }
            }
            for (y = 0; y < 12; y++)
            {
                for (int x = 0; x < 12; x++)
                {
                    string wildMapSymbol = "^";
                    Colour wildMapAttr = Colour.Green;
                    if (Wilderness[y][x].Dungeon != null)
                    {
                        Dungeon dungeon = Wilderness[y][x].Dungeon;
                        wildMapSymbol = dungeon.Visited ? dungeon.MapSymbol : "?";
                        wildMapAttr = Wilderness[y][x].Town != null ? Colour.Grey : Colour.Brown;
                        if (dungeonGuardians[Wilderness[y][x].Dungeon.Index] != 0)
                        {
                            wildMapAttr = Colour.BrightRed;
                        }
                    }
                    if (x == 0 || y == 0 || x == 11 || y == 11)
                    {
                        wildMapSymbol = "~";
                        wildMapAttr = Colour.Blue;
                    }
                    Print(wildMapAttr, wildMapSymbol, y + 2, x + 2);
                }
            }
            Print(Colour.Purple, "+------------+", 1, 1);
            for (y = 0; y < 12; y++)
            {
                Print(Colour.Purple, "|", y + 2, 1);
                Print(Colour.Purple, "|", y + 2, 14);
            }
            Print(Colour.Purple, "+------------+", 14, 1);
            for (y = 0; y < Constants.MaxCaves; y++)
            {
                string depth = Dungeons[y].KnownDepth ? $"{Dungeons[y].MaxLevel}" : "?";
                string difficulty = Dungeons[y].KnownOffset ? $"{Dungeons[y].Offset}" : "?";
                string buffer;
                if (Dungeons[y].Visited)
                {
                    buffer = y < Towns.Length
                        ? $"{Dungeons[y].MapSymbol} = {Towns[y].Name} (L:{depth}, D:{difficulty}, Q:{dungeonGuardians[y]})"
                        : $"{Dungeons[y].MapSymbol} = {Dungeons[y].Name} (L:{depth}, D:{difficulty}, Q:{dungeonGuardians[y]})";
                }
                else
                {
                    buffer = $"? = {Dungeons[y].Name} (L:{depth}, D:{difficulty}, Q:{dungeonGuardians[y]})";
                }
                Colour keyAttr = Colour.Brown;
                if (y < Towns.Length)
                {
                    keyAttr = Colour.Grey;
                }
                if (dungeonGuardians[y] != 0)
                {
                    keyAttr = Colour.BrightRed;
                }
                Print(keyAttr, buffer, y + 1, 19);
            }
            Print(Colour.Purple, "L:levels", 16, 1);
            Print(Colour.Purple, "D:difficulty", 17, 1);
            Print(Colour.Purple, "Q:quests", 18, 1);
            Print(Colour.Purple, "(Your position is marked with the cursor)", Constants.MaxCaves + 2, 19);
        }

        public void Disturb(bool stopSearch)
        {
            if (CommandRepeat != 0)
            {
                CommandRepeat = 0;
                Player.RedrawNeeded.Set(RedrawFlag.PrState);
            }
            if (Resting != 0)
            {
                Resting = 0;
                Player.RedrawNeeded.Set(RedrawFlag.PrState);
            }
            if (Running != 0)
            {
                Running = 0;
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            }
            if (stopSearch && Player.IsSearching)
            {
                Player.IsSearching = false;
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                Player.RedrawNeeded.Set(RedrawFlag.PrState);
            }
        }

        public void DoCmdSaveGame(bool isAutosave)
        {
            if (!isAutosave)
            {
                Disturb(true);
            }
            MsgPrint(null);
            HandleStuff();
            UpdateScreen();
            DiedFrom = "(saved)";
            SavePlayer(Player);
            UpdateScreen();
            DiedFrom = "(alive and well)";
        }

        public bool GetItem(out int itemIndex, string prompt, bool canChooseFromEquipment, bool canChooseFromInventory, bool canChooseFromFloor)
        {
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            Inventory inventory = Player.Inventory;
            int currentItemIndex;
            int nextItemIndex;
            bool allowFloor = false;
            MsgPrint(null);
            bool done = false;
            bool item = false;
            itemIndex = -1;
            int i1 = 0;
            int i2 = InventorySlot.Pack - 1;
            if (!canChooseFromInventory)
            {
                i2 = -1;
            }
            while (i1 <= i2 && !inventory.GetItemOkay(i1))
            {
                i1++;
            }
            while (i1 <= i2 && !inventory.GetItemOkay(i2))
            {
                i2--;
            }
            int e1 = InventorySlot.MeleeWeapon;
            int e2 = InventorySlot.Total - 1;
            if (!canChooseFromEquipment)
            {
                e2 = -1;
            }
            while (e1 <= e2 && !inventory.GetItemOkay(e1))
            {
                e1++;
            }
            while (e1 <= e2 && !inventory.GetItemOkay(e2))
            {
                e2--;
            }
            if (canChooseFromFloor)
            {
                for (currentItemIndex = tile.ItemIndex; currentItemIndex != 0; currentItemIndex = nextItemIndex)
                {
                    Item oPtr = Level.Items[currentItemIndex];
                    nextItemIndex = oPtr.NextInStack;
                    if (inventory.ItemMatchesFilter(oPtr))
                    {
                        allowFloor = true;
                    }
                }
            }
            if (!allowFloor && i1 > i2 && e1 > e2)
            {
                ViewingItemList = false;
                itemIndex = -2;
                done = true;
            }
            else
            {
                if (!ViewingItemList)
                {
                    ItemDisplayColumn = 50;
                }
                if (ViewingItemList && ViewingEquipment && canChooseFromEquipment)
                {
                    ViewingEquipment = true;
                }
                else if (canChooseFromInventory)
                {
                    ViewingEquipment = false;
                }
                else if (canChooseFromEquipment)
                {
                    ViewingEquipment = true;
                }
                else
                {
                    ViewingEquipment = false;
                }
            }
            if (ViewingItemList)
            {
                SaveScreen();
            }
            while (!done)
            {
                if (!ViewingEquipment)
                {
                    i1.IndexToLetter();
                    i2.IndexToLetter();
                    if (ViewingItemList)
                    {
                        Player.Inventory.ShowInven();
                    }
                }
                else
                {
                    (e1 - InventorySlot.MeleeWeapon).IndexToLetter();
                    (e2 - InventorySlot.MeleeWeapon).IndexToLetter();
                    if (ViewingItemList)
                    {
                        Player.Inventory.ShowEquip();
                    }
                }
                string tmpVal;
                string outVal;
                if (!ViewingEquipment)
                {
                    outVal = "Inven:";
                    if (i1 <= i2)
                    {
                        tmpVal = $" {i1.IndexToLabel()}-{i2.IndexToLabel()},";
                        outVal += tmpVal;
                    }
                    if (!ViewingItemList)
                    {
                        outVal += " * to see,";
                    }
                    if (canChooseFromEquipment)
                    {
                        outVal += " / for Equip,";
                    }
                }
                else
                {
                    outVal = "Equip:";
                    if (e1 <= e2)
                    {
                        tmpVal = $" {e1.IndexToLabel()}-{e2.IndexToLabel()}";
                        outVal += tmpVal;
                    }
                    if (!ViewingItemList)
                    {
                        outVal += " * to see,";
                    }
                    if (canChooseFromInventory)
                    {
                        outVal += " / for Inven,";
                    }
                }
                if (allowFloor)
                {
                    outVal += " - for floor,";
                }
                outVal += " ESC";
                tmpVal = $"({outVal}) {prompt}";
                PrintLine(tmpVal, 0, 0);
                char which = Inkey();
                int k;
                switch (which)
                {
                    case '\x1b':
                        {
                            ItemDisplayColumn = 50;
                            done = true;
                            break;
                        }
                    case '*':
                    case '?':
                    case ' ':
                        {
                            if (!ViewingItemList)
                            {
                                SaveScreen();
                                ViewingItemList = true;
                            }
                            else
                            {
                                Load();
                                ViewingItemList = false;
                            }
                            break;
                        }
                    case '/':
                        {
                            if (!canChooseFromInventory || !canChooseFromEquipment)
                            {
                                break;
                            }
                            if (ViewingItemList)
                            {
                                Load();
                                SaveScreen();
                            }
                            ViewingEquipment = !ViewingEquipment;
                            break;
                        }
                    case '-':
                        {
                            if (allowFloor)
                            {
                                for (currentItemIndex = tile.ItemIndex; currentItemIndex != 0; currentItemIndex = nextItemIndex)
                                {
                                    Item oPtr = Level.Items[currentItemIndex];
                                    nextItemIndex = oPtr.NextInStack;
                                    if (!inventory.ItemMatchesFilter(oPtr))
                                    {
                                        continue;
                                    }
                                    itemIndex = 0 - currentItemIndex;
                                    item = true;
                                    done = true;
                                    break;
                                }
                                if (done)
                                {
                                }
                            }
                            break;
                        }
                    case '\n':
                    case '\r':
                        {
                            if (!ViewingEquipment)
                            {
                                k = i1 == i2 ? i1 : -1;
                            }
                            else
                            {
                                k = e1 == e2 ? e1 : -1;
                            }
                            if (!inventory.GetItemOkay(k))
                            {
                                break;
                            }
                            itemIndex = k;
                            item = true;
                            done = true;
                            break;
                        }
                    default:
                        {
                            bool ver = char.IsUpper(which);
                            if (ver)
                            {
                                which = char.ToLower(which);
                            }
                            k = !ViewingEquipment ? Player.Inventory.LabelToInven(which) : Player.Inventory.LabelToEquip(which);
                            if (!inventory.GetItemOkay(k))
                            {
                                break;
                            }
                            if (ver && !Verify("Try", k))
                            {
                                done = true;
                                break;
                            }
                            itemIndex = k;
                            item = true;
                            done = true;
                            break;
                        }
                }
            }
            if (ViewingItemList)
            {
                Load();
            }
            ViewingItemList = false;
            Inventory.ItemFilterCategory = 0;
            ItemFilter = null;
            PrintLine("", 0, 0);
            return item;
        }

        public Store GetWhichStore()
        {
            foreach (Store store in CurTown.Stores)
            {
                if (Player.MapX == store.X && Player.MapY == store.Y)
                {
                    return store;
                }
            }
            return null;
        }

        public void HandleStuff()
        {
            // Oops - we might have just died...
            if (Player == null)
            {
                return;
            }
            if (Player.UpdatesNeeded.IsSet())
            {
                UpdateStuff();
            }
            if (Player.RedrawNeeded.IsSet())
            {
                RedrawStuff();
            }
        }

        public void HealthTrack(int mIdx)
        {
            TrackedMonsterIndex = mIdx;
            Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
        }

        public void MonsterDeath(int mIdx)
        {
            int dumpItem = 0;
            int dumpGold = 0;
            int number = 0;
            int qIdx = 0;
            bool quest = false;
            int nextOIdx;
            Monster mPtr = Level.Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (rPtr == null)
            {
                return;
            }
            bool visible = mPtr.IsVisible || (rPtr.Flags1 & MonsterFlag1.Unique) != 0;
            bool good = (rPtr.Flags1 & MonsterFlag1.DropGood) != 0;
            bool great = (rPtr.Flags1 & MonsterFlag1.DropGreat) != 0;
            bool doGold = (rPtr.Flags1 & MonsterFlag1.OnlyDropItem) == 0;
            bool doItem = (rPtr.Flags1 & MonsterFlag1.OnlyDropGold) == 0;
            bool cloned = false;
            int forceCoin = rPtr.GetCoinType();
            Item qPtr;
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if ((mPtr.Mind & Constants.SmCloned) != 0)
            {
                cloned = true;
            }
            for (int thisOIdx = mPtr.FirstHeldItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item oPtr = Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                oPtr.HoldingMonsterIndex = 0;
                qPtr = new Item(this, Level.Items[thisOIdx]);
                Level.DeleteObjectIdx(thisOIdx);
                Level.DropNear(qPtr, -1, y, x);
            }
            if (mPtr.StolenGold > 0)
            {
                Item oPtr = new Item(this);
                oPtr.MakeGold(10);
                oPtr.TypeSpecificValue = mPtr.StolenGold;
                Level.DropNear(oPtr, -1, y, x);
            }
            mPtr.FirstHeldItemIndex = 0;
            if ((rPtr.Flags1 & MonsterFlag1.Drop60) != 0 && Program.Rng.RandomLessThan(100) < 60)
            {
                number++;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Drop90) != 0 && Program.Rng.RandomLessThan(100) < 90)
            {
                number++;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Drop_1D2) != 0)
            {
                number += Program.Rng.DiceRoll(1, 2);
            }
            if ((rPtr.Flags1 & MonsterFlag1.Drop_2D2) != 0)
            {
                number += Program.Rng.DiceRoll(2, 2);
            }
            if ((rPtr.Flags1 & MonsterFlag1.Drop_3D2) != 0)
            {
                number += Program.Rng.DiceRoll(3, 2);
            }
            if ((rPtr.Flags1 & MonsterFlag1.Drop_4D2) != 0)
            {
                number += Program.Rng.DiceRoll(4, 2);
            }
            if (cloned)
            {
                number = 0;
            }
            if (Quests.IsQuest(CurrentDepth) && (rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                qIdx = Quests.GetQuestNumber();
                Quests[qIdx].Killed++;
                if (Quests[qIdx].Killed == Quests[qIdx].ToKill)
                {
                    great = true;
                    good = true;
                    doGold = false;
                    number += 2;
                    quest = true;
                    Quests[qIdx].Level = 0;
                }
            }
            Level.ObjectLevel = (Difficulty + rPtr.Level) / 2;
            for (int j = 0; j < number; j++)
            {
                qPtr = new Item(this);
                if (doGold && (!doItem || Program.Rng.RandomLessThan(100) < 50))
                {
                    if (!qPtr.MakeGold(forceCoin))
                    {
                        continue;
                    }
                    dumpGold++;
                }
                else
                {
                    if (!quest || j > 1)
                    {
                        if (!qPtr.MakeObject(good, great, false))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (!qPtr.MakeObject(true, true, false))
                        {
                            continue;
                        }
                    }
                    dumpItem++;
                }
                Level.DropNear(qPtr, -1, y, x);
            }
            Level.ObjectLevel = Difficulty;
            if (visible && (dumpItem != 0 || dumpGold != 0))
            {
                Level.Monsters.LoreTreasure(mIdx, dumpItem, dumpGold);
            }
            if ((rPtr.Flags1 & MonsterFlag1.Guardian) == 0)
            {
                return;
            }
            if (Quests[qIdx].Killed != Quests[qIdx].ToKill)
            {
                return;
            }
            rPtr.Flags1 ^= MonsterFlag1.Guardian;
            if (Quests.ActiveQuests == 0)
            {
                Player.IsWinner = true;
                Player.RedrawNeeded.Set(RedrawFlag.PrTitle);
                MsgPrint("*** CONGRATULATIONS ***");
                MsgPrint("You have won the game!");
                MsgPrint("You may retire ('Q') when you are ready.");
            }
            else
            {
                if (CurrentDepth < CurDungeon.MaxLevel)
                {
                    while (!Level.CaveValidBold(y, x))
                    {
                        const int d = 1;
                        Level.Scatter(out int ny, out int nx, y, x, d);
                        y = ny;
                        x = nx;
                    }
                    Level.DeleteObject(y, x);
                    MsgPrint("A magical stairway appears...");
                    Level.CaveSetFeat(y, x, CurDungeon.Tower ? "UpStair" : "DownStair");
                    Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateMonsters);
                }
            }
        }

        public void NoticeStuff()
        {
            if (Player.NoticeFlags == 0)
            {
                return;
            }
            if ((Player.NoticeFlags & Constants.PnCombine) != 0)
            {
                Player.NoticeFlags &= ~Constants.PnCombine;
                Player.Inventory.CombinePack();
            }
            if ((Player.NoticeFlags & Constants.PnReorder) != 0)
            {
                Player.NoticeFlags &= ~Constants.PnReorder;
                Player.Inventory.ReorderPack();
            }
        }

        public void OpenChest(int y, int x, int oIdx)
        {
            Item oPtr = Level.Items[oIdx];
            ChestItemCategory chest = (ChestItemCategory)oPtr.BaseItemCategory;
            bool small = chest.IsSmall;
            int number = chest.NumberOfItemsContained;

            // Check to see if there is anything in the chest.  A chest trap will set this to zero, if it explodes.
            if (oPtr.TypeSpecificValue == 0)
            {
                number = 0;
            }
            Level.ObjectLevel = Math.Abs(oPtr.TypeSpecificValue) + 10;
            for (; number > 0; --number)
            {
                Item qPtr = new Item(this);
                if (small && Program.Rng.RandomLessThan(100) < 75)
                {
                    if (!qPtr.MakeGold(0))
                    {
                        continue;
                    }
                }
                else
                {
                    if (!qPtr.MakeObject(false, false, true))
                    {
                        continue;
                    }
                }
                Level.DropNear(qPtr, -1, y, x);
            }
            Level.ObjectLevel = Difficulty;
            oPtr.TypeSpecificValue = 0;
            oPtr.BecomeKnown();
        }

        private void InitializeDisplay(int w, int h, int k)
        {
            KeySize = k;
            KeyQueue = new char[k];
            Width = w;
            Height = h;
            X1 = new int[h];
            X2 = new int[h];
            Old = new Screen(w, h);
            Scr = new Screen(w, h);
            for (int y = 0; y < h; y++)
            {
                X1[y] = 0;
                X2[y] = w - 1;
            }
            Y1 = 0;
            Y2 = h - 1;
            TotalErase = true;
            AttrBlank = 0;
            CharBlank = ' ';
        }

        public void UpdateStuff()
        {
            if (Player.UpdatesNeeded.IsClear())
            {
                return;
            }
            PlayerStatus playerStatus = new PlayerStatus(this);
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateBonuses))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateBonuses);
                playerStatus.CalcBonuses();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateTorchRadius))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateTorchRadius);
                playerStatus.CalcTorch();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateHealth))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateHealth);
                playerStatus.CalcHitpoints();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateMana))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateMana);
                playerStatus.CalcMana();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateSpells))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateSpells);
                playerStatus.CalcSpells();
            }
            if (Player == null)
            {
                return;
            }
            if (FullScreenOverlay)
            {
                return;
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateRemoveLight))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateRemoveLight);
                Level.ForgetLight();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateRemoveView))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateRemoveView);
                Level.ForgetView();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateView))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateView);
                Level.UpdateView();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateLight))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateLight);
                Level.UpdateLight();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateScent))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateScent);
                Level.UpdateFlow();
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateDistances))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateDistances);
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateMonsters);
                Level.UpdateMonsters(true);
            }
            if (Player.UpdatesNeeded.IsSet(UpdateFlags.UpdateMonsters))
            {
                Player.UpdatesNeeded.Clear(UpdateFlags.UpdateMonsters);
                Level.UpdateMonsters(false);
            }
        }

        private void ApplyFlavourVisuals() // TODO: This is run just once
        {
            int i;
            for (i = 0; i < ItemTypes.Count; i++)
            {
                BaseItemCategory kPtr = ItemTypes[i];
                if (kPtr.HasFlavor)
                {
                    int indexx = kPtr.SubCategory ?? 0;
                    switch (kPtr.CategoryEnum)
                    {
                        case ItemCategory.Food:
                            kPtr.FlavorCharacter = MushroomFlavours[indexx].Character;
                            kPtr.FlavorColour = MushroomFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Potion:
                            kPtr.FlavorCharacter = PotionFlavours[indexx].Character;
                            kPtr.FlavorColour = PotionFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Scroll:
                            kPtr.FlavorCharacter = ScrollFlavours[indexx].Character;
                            kPtr.FlavorColour = ScrollFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Amulet:
                            kPtr.FlavorCharacter = AmuletFlavours[indexx].Character;
                            kPtr.FlavorColour = AmuletFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Ring:
                            kPtr.FlavorCharacter = RingFlavours[indexx].Character;
                            kPtr.FlavorColour = RingFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Staff:
                            kPtr.FlavorCharacter = StaffFlavours[indexx].Character;
                            kPtr.FlavorColour = StaffFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Wand:
                            kPtr.FlavorCharacter = WandFlavours[indexx].Character;
                            kPtr.FlavorColour = WandFlavours[indexx].Colour;
                            break;

                        case ItemCategory.Rod:
                            kPtr.FlavorCharacter = RodFlavours[indexx].Character;
                            kPtr.FlavorColour = RodFlavours[indexx].Colour;
                            break;
                    }
                }
            }
        }

        private void CloseGame()
        {
            HandleStuff();
            MsgPrint(null);
            FullScreenOverlay = true;
            if (Player.IsDead)
            {
                if (Player.IsWinner)
                {
                    Kingly();
                }
                Player corpse = Player;
                HighScore score = new HighScore(this);
                Player = null;
                SavePlayer(corpse);
                PrintTomb(corpse);
                if (corpse.IsWizard)
                {
                    return;
                }
                //Program.HiScores.InsertNewScore(score);
                //Program.HiScores.DisplayScores(score.Pts);
            }
            else
            {
                DoCmdSaveGame(false);
                //if (!Program.ExitToDesktop)
                //{
                //    Terminal.PlayMusic(MusicTrack.Menu);
                //    Program.HiScores.DisplayScores(new HighScore(this));
                //}
            }
        }

        private void CreateWorld()
        {
            int i;
            int j;
            int x = 0;
            int y = 0;
            Wilderness.MakeIslandContours();
            for (i = 0; i < 12; i++)
            {
                for (j = 0; j < 12; j++)
                {
                    Wilderness[i][j].Seed = Program.Rng.RandomLessThan(int.MaxValue);
                    Wilderness[i][j].Dungeon = null;
                    Wilderness[i][j].Town = null;
                    Wilderness[i][j].RoadMap = 0;
                }
            }
            for (i = 0; i < Towns.Length; i++)
            {
                Towns[i].Seed = Program.Rng.RandomLessThan(int.MaxValue);
                Towns[i].Visited = false;
                Towns[i].X = 0;
                Towns[i].Y = 0;
            }
            for (i = 0; i < Constants.MaxCaves; i++)
            {
                Dungeons[i].X = 0;
                Dungeons[i].Y = 0;
            }
            for (i = 0; i < Constants.MaxCaves; i++)
            {
                Dungeons[i].Visited = false;
                Dungeons[i].KnownDepth = false;
                Dungeons[i].KnownOffset = false;
                if (i < Towns.Length)
                {
                    Dungeons[i].Visited = true;
                    j = 0;
                    while (j == 0)
                    {
                        x = Program.Rng.RandomBetween(2, 9);
                        y = Program.Rng.RandomBetween(2, 9);
                        j = 1;
                        if (Wilderness[y][x].Dungeon != null || Wilderness[y - 1][x].Dungeon != null ||
                            Wilderness[y + 1][x].Dungeon != null || Wilderness[y][x - 1].Dungeon != null ||
                            Wilderness[y][x + 1].Dungeon != null || Wilderness[y - 1][x + 1].Dungeon != null ||
                            Wilderness[y + 1][x + 1].Dungeon != null || Wilderness[y - 1][x - 1].Dungeon != null ||
                            Wilderness[y + 1][x - 1].Dungeon != null)
                        {
                            j = 0;
                        }
                    }
                }
                else
                {
                    j = 0;
                    while (j == 0)
                    {
                        x = Program.Rng.RandomBetween(2, 9);
                        y = Program.Rng.RandomBetween(2, 9);
                        j = 1;
                        if (Wilderness[y][x].Dungeon != null)
                        {
                            j = 0;
                        }
                    }
                }
                Wilderness[y][x].Dungeon = Dungeons[i];
                if (i < Towns.Length)
                {
                    Wilderness[y][x].Town = Towns[i];
                    Towns[i].X = x;
                    Towns[i].Y = y;
                }
                Dungeons[i].X = x;
                Dungeons[i].Y = y;
            }
            for (i = 0; i < Towns.Length - 1; i++)
            {
                int curX = Towns[i].X;
                int curY = Towns[i].Y;
                int destX = Towns[i + 1].X;
                int destY = Towns[i + 1].Y;
                bool fin = false;
                while (!fin)
                {
                    int xDisp = destX - curX;
                    int xSgn = 0;
                    if (xDisp > 0)
                    {
                        xSgn = 1;
                    }
                    if (xDisp < 0)
                    {
                        xSgn = -1;
                        xDisp = -xDisp;
                    }
                    int yDisp = destY - curY;
                    int ySgn = 0;
                    if (yDisp > 0)
                    {
                        ySgn = 1;
                    }
                    if (yDisp < 0)
                    {
                        ySgn = -1;
                        yDisp = -yDisp;
                    }
                    if (xDisp == 0 && yDisp == 0)
                    {
                        fin = true;
                    }
                    else
                    {
                        int curdir;
                        int nextdir;
                        if (xDisp == yDisp && xSgn == 1 && ySgn == -1)
                        {
                            curdir = Constants.RoadUp;
                            nextdir = Constants.RoadDown;
                        }
                        else if (xSgn == 1 && xDisp >= yDisp)
                        {
                            curdir = Constants.RoadRight;
                            nextdir = Constants.RoadLeft;
                        }
                        else if (ySgn == 1 && yDisp >= xDisp)
                        {
                            curdir = Constants.RoadDown;
                            nextdir = Constants.RoadUp;
                        }
                        else if (xSgn == -1 && xDisp >= yDisp)
                        {
                            curdir = Constants.RoadLeft;
                            nextdir = Constants.RoadRight;
                        }
                        else
                        {
                            curdir = Constants.RoadUp;
                            nextdir = Constants.RoadDown;
                        }
                        Wilderness[curY][curX].RoadMap |= curdir;
                        if (curdir == Constants.RoadRight)
                        {
                            curX++;
                        }
                        else if (curdir == Constants.RoadLeft)
                        {
                            curX--;
                        }
                        else if (curdir == Constants.RoadDown)
                        {
                            curY++;
                        }
                        else
                        {
                            curY--;
                        }
                        Wilderness[curY][curX].RoadMap |= nextdir;
                    }
                }
            }
        }

        private void DungeonLoop()
        {
            TargetEngine targetEngine = new TargetEngine(this);
            NewLevelFlag = false;
            HackMind = false;
            CurrentCommand = (char)0;
            QueuedCommand = (char)0;
            CommandRepeat = 0;
            CommandArgument = 0;
            CommandDirection = 0;
            TargetWho = 0;
            HealthTrack(0);
            Level.Monsters.ShimmerMonsters = true;
            Level.Monsters.RepairMonsters = true;
            Disturb(true);
            if (Player.MaxLevelGained < Player.Level)
            {
                Player.MaxLevelGained = Player.Level;
            }
            if (Player.MaxDlv[CurDungeon.Index] < CurrentDepth)
            {
                Player.MaxDlv[CurDungeon.Index] = CurrentDepth;
            }
            if (Quests.IsQuest(CurrentDepth))
            {
                if (CurDungeon.Tower)
                {
                    CreateUpStair = false;
                }
                else
                {
                    CreateDownStair = false;
                }
            }
            if (CurrentDepth <= 0)
            {
                CreateDownStair = false;
                CreateUpStair = false;
            }
            if (CreateUpStair || CreateDownStair)
            {
                if (Level.CaveValidBold(Player.MapY, Player.MapX))
                {
                    Level.DeleteObject(Player.MapY, Player.MapX);
                    Level.CaveSetFeat(Player.MapY, Player.MapX,
                        CreateDownStair ? "DownStair" : "UpStair");
                }
                CreateDownStair = false;
                CreateUpStair = false;
            }
            targetEngine.RecenterScreenAroundPlayer();
            targetEngine.PanelBoundsCenter();
            MsgPrint(null);
            CharacterXtra = true;
            Player.RedrawNeeded.Set(RedrawFlag.PrWipe | RedrawFlag.PrBasic | RedrawFlag.PrExtra | RedrawFlag.PrEquippy);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses | UpdateFlags.UpdateHealth | UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            UpdateStuff();
            RedrawStuff();
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateDistances);
            UpdateStuff();
            RedrawStuff();
            CharacterXtra = false;
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses | UpdateFlags.UpdateHealth | UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
            Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            NoticeStuff();
            UpdateStuff();
            RedrawStuff();
            UpdateScreen();
            if (!Playing || Player.IsDead || NewLevelFlag)
            {
                return;
            }
            if (Quests.IsQuest(CurrentDepth))
            {
                Quests.QuestDiscovery();
            }
            Level.MonsterLevel = Difficulty;
            Level.ObjectLevel = Difficulty;
            HackMind = true;
            if (CameFrom == LevelStart.StartHouse)
            {
                StoreCommand.DoCmdStore(this);
                CameFrom = LevelStart.StartRandom;
            }
            if (CurrentDepth == 0)
            {
                if (Difficulty == 0)
                {
                    PlayMusic(MusicTrack.Town);
                }
                else
                {
                    PlayMusic(MusicTrack.Wilderness);
                }
            }
            else
            {
                if (Quests.IsQuest(CurrentDepth))
                {
                    PlayMusic(MusicTrack.QuestLevel);
                }
                else
                {
                    PlayMusic(MusicTrack.Dungeon);
                }
            }
            while (true)
            {
                if (Level.MCnt + 32 > Constants.MaxMIdx)
                {
                    Level.Monsters.CompactMonsters(64);
                }
                if (Level.MCnt + 32 < Level.MMax)
                {
                    Level.Monsters.CompactMonsters(0);
                }
                if (Level.OCnt + 32 > Constants.MaxOIdx)
                {
                    Level.CompactObjects(64);
                }
                if (Level.OCnt + 32 < Level.OMax)
                {
                    Level.CompactObjects(0);
                }
                ProcessPlayer();

                if (Player.NoticeFlags != 0)
                {
                    NoticeStuff();
                }
                if (Player.UpdatesNeeded.IsSet())
                {
                    UpdateStuff();
                }
                if (Player.RedrawNeeded.IsSet())
                {
                    RedrawStuff();
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
                TotalFriends = 0;
                TotalFriendLevels = 0;
                ProcessAllMonsters();
                if (Player.NoticeFlags != 0)
                {
                    NoticeStuff();
                }
                if (Player.UpdatesNeeded.IsSet())
                {
                    UpdateStuff();
                }
                if (Player.RedrawNeeded.IsSet())
                {
                    RedrawStuff();
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
                ProcessWorld();
                if (Player.NoticeFlags != 0)
                {
                    NoticeStuff();
                }
                if (Player.UpdatesNeeded.IsSet())
                {
                    UpdateStuff();
                }
                if (Player.RedrawNeeded.IsSet())
                {
                    RedrawStuff();
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
                Player.GameTime.Tick();
                if (!Player.GameTime.IsFeelTime)
                {
                    continue;
                }
                if (CurrentDepth > 0)
                {
                    Commands.FeelingAndLocationCommand.DoCmdFeeling(this, true);
                }
            }
        }

        private void FlavorInit()
        {
            int i, j;
            Program.Rng.UseFixed = true;
            Program.Rng.FixedSeed = _seedFlavor;
            PotionFlavours = new List<BasePotionFlavour>();
            List<BasePotionFlavour> tempPotions = new List<BasePotionFlavour>();
            PotionFlavours.Add(new ClearPotionFlavour());
            PotionFlavours.Add(new LightBrownPotionFlavour());
            PotionFlavours.Add(new IckyGreenPotionFlavour());
            foreach (BasePotionFlavour potionFlavour in CommandManager.BasePotionFlavours)
            {
                if (potionFlavour is ClearPotionFlavour)
                {
                    continue;
                }
                if (potionFlavour is LightBrownPotionFlavour)
                {
                    continue;
                }
                if (potionFlavour is IckyGreenPotionFlavour)
                {
                    continue;
                }
                tempPotions.Add(potionFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempPotions.Count);
                PotionFlavours.Add(tempPotions[index]);
                tempPotions.RemoveAt(index);
            } while (tempPotions.Count > 0);
            MushroomFlavours = new List<BaseMushroomFlavour>();
            List<BaseMushroomFlavour> tempMushrooms = new List<BaseMushroomFlavour>();
            foreach (BaseMushroomFlavour mushroomFlavour in CommandManager.BaseMushroomFlavours)
            {
                tempMushrooms.Add(mushroomFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempMushrooms.Count);
                MushroomFlavours.Add(tempMushrooms[index]);
                tempMushrooms.RemoveAt(index);
            } while (tempMushrooms.Count > 0);
            AmuletFlavours = new List<BaseAmuletFlavour>();
            List<BaseAmuletFlavour> tempAmulets = new List<BaseAmuletFlavour>();
            foreach (BaseAmuletFlavour amuletFlavour in CommandManager.BaseAmuletFlavours)
            {
                tempAmulets.Add(amuletFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempAmulets.Count);
                AmuletFlavours.Add(tempAmulets[index]);
                tempAmulets.RemoveAt(index);
            } while (tempAmulets.Count > 0);
            WandFlavours = new List<BaseWandFlavour>();
            List<BaseWandFlavour> tempWands = new List<BaseWandFlavour>();
            foreach (BaseWandFlavour wandFlavour in CommandManager.BaseWandFlavours)
            {
                tempWands.Add(wandFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempWands.Count);
                WandFlavours.Add(tempWands[index]);
                tempWands.RemoveAt(index);
            } while (tempWands.Count > 0);
            RingFlavours = new List<BaseRingFlavour>();
            List<BaseRingFlavour> tempRings = new List<BaseRingFlavour>();
            foreach (BaseRingFlavour ringFlavour in CommandManager.BaseRingFlavours)
            {
                tempRings.Add(ringFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempRings.Count);
                RingFlavours.Add(tempRings[index]);
                tempRings.RemoveAt(index);
            } while (tempRings.Count > 0);
            RodFlavours = new List<BaseRodFlavour>();
            List<BaseRodFlavour> tempRods = new List<BaseRodFlavour>();
            foreach (BaseRodFlavour rodFlavour in CommandManager.BaseRodFlavours)
            {
                tempRods.Add(rodFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempRods.Count);
                RodFlavours.Add(tempRods[index]);
                tempRods.RemoveAt(index);
            } while (tempRods.Count > 0);
            StaffFlavours = new List<BaseStaffFlavour>();
            List<BaseStaffFlavour> tempStaffs = new List<BaseStaffFlavour>();
            foreach (BaseStaffFlavour staffFlavour in CommandManager.BaseStaffFlavours)
            {
                tempStaffs.Add(staffFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempStaffs.Count);
                StaffFlavours.Add(tempStaffs[index]);
                tempStaffs.RemoveAt(index);
            } while (tempStaffs.Count > 0);
            ScrollFlavours = new List<ScrollFlavour>();
            List<BaseScrollFlavour> tempScrolls = new List<BaseScrollFlavour>();
            foreach (BaseScrollFlavour scrollFlavour in CommandManager.BaseScrollFlavours)
            {
                tempScrolls.Add(scrollFlavour);
            }
            for (i = 0; i < Constants.MaxNumberOfScrollFlavoursGenerated; i++)
            {
                ScrollFlavour flavour = new ScrollFlavour();
                ScrollFlavours.Add(flavour);
                int index = Program.Rng.RandomLessThan(tempScrolls.Count);
                flavour.Character = tempScrolls[index].Character;
                flavour.Colour = tempScrolls[index].Colour;
                while (true)
                {
                    string buf = "";
                    while (true)
                    {
                        string tmp = "";
                        int s = Program.Rng.RandomLessThan(100) < 30 ? 1 : 2;
                        for (int q = 0; q < s; q++)
                        {
                            tmp += BaseScrollFlavour.Syllables[Program.Rng.RandomLessThan(BaseScrollFlavour.Syllables.Length)];
                        }
                        if (buf.Length + tmp.Length > 14)
                        {
                            break;
                        }
                        buf += " ";
                        buf += tmp;
                    }
                    flavour.Name = buf.Substring(1);
                    bool okay = true;
                    for (j = 0; j < i; j++)
                    {
                        string hack1 = ScrollFlavours[j].Name;
                        string hack2 = ScrollFlavours[i].Name;
                        if (hack1.Substring(0, 4) != hack2.Substring(0, 4))
                        {
                            continue;
                        }
                        okay = false;
                        break;
                    }
                    if (okay)
                    {
                        break;
                    }
                }
            }
            Program.Rng.UseFixed = false;
            for (i = 1; i < ItemTypes.Count; i++)
            {
                BaseItemCategory kPtr = ItemTypes[i];
                if (string.IsNullOrEmpty(kPtr.FriendlyName))
                {
                    continue;
                }
                if (!kPtr.HasFlavor)
                {
                    kPtr.FlavourAware = true;
                }
            }
        }

        private void InitializeAllocationTables()
        {
            int i, j;
            BaseItemCategory kPtr;
            MonsterRace rPtr;
            int[] num = new int[Constants.MaxDepth];
            int[] aux = new int[Constants.MaxDepth];
            AllocKindSize = 0;
            for (i = 1; i < ItemTypes.Count; i++)
            {
                kPtr = ItemTypes[i];
                for (j = 0; j < 4; j++)
                {
                    if (kPtr.Chance[j] != 0)
                    {
                        AllocKindSize++;
                        num[kPtr.Locale[j]]++;
                    }
                }
            }
            for (i = 1; i < Constants.MaxDepth; i++)
            {
                num[i] += num[i - 1];
            }
            if (num[0] == 0)
            {
                Quit("No town objects!");
            }
            AllocKindTable = new AllocationEntry[AllocKindSize];
            for (int k = 0; k < AllocKindSize; k++)
            {
                AllocKindTable[k] = new AllocationEntry();
            }
            AllocationEntry[] table = AllocKindTable;
            for (i = 1; i < ItemTypes.Count; i++)
            {
                kPtr = ItemTypes[i];
                for (j = 0; j < 4; j++)
                {
                    if (kPtr.Chance[j] != 0)
                    {
                        int x = kPtr.Locale[j];
                        int p = 100 / kPtr.Chance[j];
                        int y = x > 0 ? num[x - 1] : 0;
                        int z = y + aux[x];
                        table[z].Index = i;
                        table[z].Level = x;
                        table[z].BaseProbability = p;
                        table[z].FilteredProbabiity = p;
                        table[z].FinalProbability = p;
                        aux[x]++;
                    }
                }
            }
            aux = new int[Constants.MaxDepth];
            num = new int[Constants.MaxDepth];
            AllocRaceSize = 0;
            for (i = 1; i < MonsterRaces.Count - 1; i++)
            {
                rPtr = MonsterRaces[i];
                if (rPtr.Rarity != 0)
                {
                    AllocRaceSize++;
                    num[rPtr.Level]++;
                }
            }
            for (i = 1; i < Constants.MaxDepth; i++)
            {
                num[i] += num[i - 1];
            }
            if (num[0] == 0)
            {
                Quit("No town monsters!");
            }
            AllocRaceTable = new AllocationEntry[AllocRaceSize];
            for (int k = 0; k < AllocRaceSize; k++)
            {
                AllocRaceTable[k] = new AllocationEntry();
            }
            table = AllocRaceTable;
            for (i = 1; i < MonsterRaces.Count - 1; i++)
            {
                rPtr = MonsterRaces[i];
                if (rPtr.Rarity != 0)
                {
                    int x = rPtr.Level;
                    int p = 100 / rPtr.Rarity;
                    int y = x > 0 ? num[x - 1] : 0;
                    int z = y + aux[x];
                    table[z].Index = i;
                    table[z].Level = x;
                    table[z].BaseProbability = p;
                    table[z].FilteredProbabiity = p;
                    table[z].FinalProbability = p;
                    aux[x]++;
                }
            }
        }

        private void Kingly()
        {
            CurrentDepth = 0;
            DiedFrom = "Ripe Old Age";
            Player.ExperiencePoints = Player.MaxExperienceGained;
            Player.Level = Player.MaxLevelGained;
            Player.Gold += 10000000;
            SetBackground(BackgroundImage.Crown);
            Clear();
            AnyKey(44);
        }

        private void PrintTomb(Player corpse)
        {
            {
                DateTime ct = DateTime.Now;
                if (corpse.IsWinner)
                {
                    SetBackground(BackgroundImage.Sunset);
                    PlayMusic(MusicTrack.Victory);
                }
                else
                {
                    SetBackground(BackgroundImage.Tomb);
                    PlayMusic(MusicTrack.Death);
                }
                Clear();
                string buf = corpse.Name.Trim() + corpse.Generation.ToRoman(true);
                if (corpse.IsWinner || corpse.Level > Constants.PyMaxLevel)
                {
                    buf += " the Magnificent";
                }
                Print(buf, 39, 1);
                buf = $"Level {corpse.Level} {Profession.ClassSubName(corpse.ProfessionIndex, corpse.Realm1)}";
                Print(buf, 40, 1);
                string tmp = $"Killed on Level {CurrentDepth}".PadLeft(45);
                Print(tmp, 39, 34);
                tmp = $"by {DiedFrom}".PadLeft(45);
                Print(tmp, 40, 34);
                tmp = $"on {ct:dd MMM yyyy h.mm tt}".PadLeft(45);
                Print(tmp, 41, 34);
                AnyKey(44);
            }
        }

        private void ProcessPlayer()
        {
            if (Player.GetFirstLevelMutation)
            {
                MsgPrint("You feel different!");
                Player.Dna.GainMutation(this);
                Player.GetFirstLevelMutation = false;
            }
            Player.Energy += GlobalData.ExtractEnergy[Player.Speed];
            if (Player.Energy < 100)
            {
                return;
            }
            if (Resting < 0)
            {
                if (Resting == -1)
                {
                    if (Player.Health == Player.MaxHealth && Player.Mana >= Player.MaxMana)
                    {
                        Disturb(false);
                    }
                }
                else if (Resting == -2)
                {
                    if (Player.Health == Player.MaxHealth && Player.Mana == Player.MaxMana && Player.TimedBlindness == 0 &&
                        Player.TimedConfusion == 0 && Player.TimedPoison == 0 && Player.TimedFear == 0 && Player.TimedStun == 0 &&
                        Player.TimedBleeding == 0 && Player.TimedSlow == 0 && Player.TimedParalysis == 0 && Player.TimedHallucinations == 0 &&
                        Player.WordOfRecallDelay == 0)
                    {
                        Disturb(false);
                    }
                }
            }
            if (Running != 0 || CommandRepeat != 0 || (Resting != 0 && (Resting & 0x0F) == 0))
            {
                DoNotWaitOnInkey = true;
                if (Inkey() != 0)
                {
                    Disturb(false);
                    MsgPrint("Cancelled.");
                }
            }
            while (Player.Energy >= 100)
            {
                Player.RedrawNeeded.Set(RedrawFlag.PrDtrap);
                if (Player.NoticeFlags != 0)
                {
                    NoticeStuff();
                }
                if (Player.UpdatesNeeded.IsSet())
                {
                    UpdateStuff();
                }
                if (Player.RedrawNeeded.IsSet())
                {
                    RedrawStuff();
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                UpdateScreen();
                if (Player.Inventory[InventorySlot.Pack].BaseItemCategory != null)
                {
                    const int item = InventorySlot.Pack;
                    Item oPtr = Player.Inventory[item];
                    Disturb(false);
                    MsgPrint("Your pack overflows!");
                    string oName = oPtr.Description(true, 3);
                    MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
                    Level.DropNear(oPtr, 0, Player.MapY, Player.MapX);
                    Player.Inventory.InvenItemIncrease(item, -255);
                    Player.Inventory.InvenItemDescribe(item);
                    Player.Inventory.InvenItemOptimize(item);
                    if (Player.NoticeFlags != 0)
                    {
                        NoticeStuff();
                    }
                    if (Player.UpdatesNeeded.IsSet())
                    {
                        UpdateStuff();
                    }
                    if (Player.RedrawNeeded.IsSet())
                    {
                        RedrawStuff();
                    }
                }
                if (QueuedCommand == 0)
                {
                    ViewingItemList = false;
                }
                EnergyUse = 0;
                if (Player.TimedParalysis != 0 || Player.TimedStun >= 100)
                {
                    EnergyUse = 100;
                }
                else if (Resting != 0)
                {
                    if (Resting > 0)
                    {
                        Resting--;
                        Player.RedrawNeeded.Set(RedrawFlag.PrState);
                    }
                    EnergyUse = 100;
                }
                else if (Running != 0)
                {
                    RunOneStep(0);
                }
                else if (CommandRepeat != 0)
                {
                    CommandRepeat--;
                    Player.RedrawNeeded.Set(RedrawFlag.PrState);
                    RedrawStuff();
                    MsgFlag = false;
                    PrintLine("", 0, 0);
                    ProcessCommand(true);
                }
                else
                {
                    Level.MoveCursorRelative(Player.MapY, Player.MapX);
                    RequestCommand(false);
                    ProcessCommand(false);
                }
                if (EnergyUse != 0)
                {
                    Player.Energy -= EnergyUse;
                    int i;
                    if (Level.Monsters.ShimmerMonsters)
                    {
                        Level.Monsters.ShimmerMonsters = false;
                        for (i = 1; i < Level.MMax; i++)
                        {
                            Monster mPtr = Level.Monsters[i];
                            if (mPtr.Race == null)
                            {
                                continue;
                            }
                            MonsterRace rPtr = mPtr.Race;
                            if ((rPtr.Flags1 & MonsterFlag1.AttrMulti) == 0)
                            {
                                continue;
                            }
                            Level.Monsters.ShimmerMonsters = true;
                            Level.RedrawSingleLocation(mPtr.MapY, mPtr.MapX);
                        }
                    }
                    if (Level.Monsters.RepairMonsters)
                    {
                        Level.Monsters.RepairMonsters = false;
                        for (i = 1; i < Level.MMax; i++)
                        {
                            Monster mPtr = Level.Monsters[i];
                            if (mPtr.Race == null)
                            {
                                continue;
                            }
                            if ((mPtr.IndividualMonsterFlags & Constants.MflagNice) != 0)
                            {
                                mPtr.IndividualMonsterFlags &= ~Constants.MflagNice;
                            }
                            if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
                            {
                                if ((mPtr.IndividualMonsterFlags & Constants.MflagShow) != 0)
                                {
                                    mPtr.IndividualMonsterFlags &= ~Constants.MflagShow;
                                    Level.Monsters.RepairMonsters = true;
                                }
                                else
                                {
                                    mPtr.IndividualMonsterFlags &= ~Constants.MflagMark;
                                    mPtr.IsVisible = false;
                                    Level.Monsters.UpdateMonsterVisibility(i, false);
                                    Level.RedrawSingleLocation(mPtr.MapY, mPtr.MapX);
                                }
                            }
                        }
                    }
                }
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
            }
        }

        private void ProcessWorld()
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            if (Player.GameTime.IsBirthday)
            {
                MsgPrint("Happy Birthday!");
                Level.Acquirement(Player.MapY, Player.MapX, Program.Rng.DieRoll(2) + 1, true);
                Player.Age++;
            }
            if (Player.GameTime.IsNewYear)
            {
                MsgPrint("Happy New Year!");
                Level.Acquirement(Player.MapY, Player.MapX, Program.Rng.DieRoll(2) + 1, true);
            }
            if (Player.GameTime.IsHalloween)
            {
                MsgPrint("All Hallows Eve and the ghouls come out to play...");
                Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, Constants.SummonUndead);
            }
            if (CurrentDepth <= 0)
            {
                if (Player.GameTime.IsDawn)
                {
                    GridTile cPtr;
                    int x;
                    int y;
                    MsgPrint("The sun has risen.");
                    for (y = 0; y < Level.CurHgt; y++)
                    {
                        for (x = 0; x < Level.CurWid; x++)
                        {
                            cPtr = Level.Grid[y][x];
                            cPtr.TileFlags.Set(GridTile.SelfLit);
                            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                            Level.NoteSpot(y, x);
                        }
                    }
                }
                else if (Player.GameTime.IsDusk)
                {
                    GridTile cPtr;
                    int x;
                    int y;
                    MsgPrint("The sun has fallen.");
                    for (y = 0; y < Level.CurHgt; y++)
                    {
                        for (x = 0; x < Level.CurWid; x++)
                        {
                            cPtr = Level.Grid[y][x];
                            if (cPtr.FeatureType.IsOpenFloor)
                            {
                                cPtr.TileFlags.Clear(GridTile.SelfLit);
                                Level.NoteSpot(y, x);
                            }
                        }
                    }
                }
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
                Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            }
            if (Player.GameTime.IsMidnight)
            {
                Player.Religion.DecayFavour();
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateHealth | UpdateFlags.UpdateMana);
                foreach (Town town in Towns)
                {
                    foreach (Store store in town.Stores)
                    {
                        store.StoreMaint();
                    }
                }
                if (Program.Rng.RandomLessThan(Constants.StoreShuffle) == 0)
                {
                    int town = Program.Rng.RandomLessThan(Towns.Length);
                    int store = Program.Rng.RandomLessThan(12);
                    Towns[town].Stores[store].StoreShuffle();
                }
            }
            if (!Player.GameTime.IsTurnTen)
            {
                return;
            }
            if (Program.Rng.RandomLessThan(Constants.MaxMAllocChance) == 0)
            {
                Level.Monsters.AllocMonster(Constants.MaxSight + 5, false);
            }
            if (Player.GameTime.IsTurnHundred)
            {
                RegenMonsters();
            }
            if (Player.TimedPoison != 0 && Player.TimedInvulnerability == 0)
            {
                Player.TakeHit(1, "poison");
            }
            Item oPtr;
            bool caveNoRegen = false;
            if (Player.RaceIndex == RaceId.Vampire)
            {
                if (CurrentDepth <= 0 && !Player.HasLightResistance && Player.TimedInvulnerability == 0 &&
                    Player.GameTime.IsLight)
                {
                    if (Level.Grid[Player.MapY][Player.MapX].TileFlags.IsSet(GridTile.SelfLit))
                    {
                        MsgPrint("The sun's rays scorch your undead flesh!");
                        Player.TakeHit(1, "sunlight");
                        caveNoRegen = true;
                    }
                }
                if (Player.Inventory[InventorySlot.Lightsource].Category != 0 &&
                    Player.Inventory[InventorySlot.Lightsource].ItemSubCategory >= LightType.Galadriel &&
                    Player.Inventory[InventorySlot.Lightsource].ItemSubCategory < LightType.Thrain &&
                    !Player.HasLightResistance)
                {
                    oPtr = Player.Inventory[InventorySlot.Lightsource];
                    string oName = oPtr.Description(false, 0);
                    MsgPrint($"The {oName} scorches your undead flesh!");
                    caveNoRegen = true;
                    oName = oPtr.Description(true, 0);
                    string ouch = $"wielding {oName}";
                    if (Player.TimedInvulnerability == 0)
                    {
                        Player.TakeHit(1, ouch);
                    }
                }
            }
            if (!Level.GridPassable(Player.MapY, Player.MapX))
            {
                caveNoRegen = true;
                if (Player.TimedInvulnerability == 0 && Player.TimedEtherealness == 0 &&
                    (Player.Health > Player.Level / 5 || Player.RaceIndex != RaceId.Spectre))
                {
                    string damDesc;
                    if (Player.RaceIndex == RaceId.Spectre)
                    {
                        MsgPrint("Your body feels disrupted!");
                        damDesc = "density";
                    }
                    else
                    {
                        MsgPrint("You are being crushed!");
                        damDesc = "solid rock";
                    }
                    Player.TakeHit(1 + (Player.Level / 5), damDesc);
                }
            }
            int i;
            if (Player.TimedBleeding != 0 && Player.TimedInvulnerability == 0)
            {
                if (Player.TimedBleeding > 200)
                {
                    i = 3;
                }
                else if (Player.TimedBleeding > 100)
                {
                    i = 2;
                }
                else
                {
                    i = 1;
                }
                Player.TakeHit(i, "a fatal wound");
            }
            if (Player.Food < Constants.PyFoodMax)
            {
                if (Player.GameTime.IsTurnHundred)
                {
                    i = GlobalData.ExtractEnergy[Player.Speed] * 2;
                    if (Player.HasRegeneration)
                    {
                        i += 30;
                    }
                    if (Player.HasSlowDigestion)
                    {
                        i -= 10;
                    }
                    if (i < 1)
                    {
                        i = 1;
                    }
                    Player.SetFood(Player.Food - i);
                }
            }
            else
            {
                Player.SetFood(Player.Food - 100);
            }
            if (Player.Food < Constants.PyFoodStarve)
            {
                i = (Constants.PyFoodStarve - Player.Food) / 10;
                if (Player.TimedInvulnerability == 0)
                {
                    Player.TakeHit(i, "starvation");
                }
            }
            int regenAmount = Constants.PyRegenNormal;
            if (Player.Food < Constants.PyFoodWeak)
            {
                if (Player.Food < Constants.PyFoodStarve)
                {
                    regenAmount = 0;
                }
                else if (Player.Food < Constants.PyFoodFaint)
                {
                    regenAmount = Constants.PyRegenFaint;
                }
                else
                {
                    regenAmount = Constants.PyRegenWeak;
                }
                if (Player.Food < Constants.PyFoodFaint)
                {
                    if (Player.TimedParalysis == 0 && Program.Rng.RandomLessThan(100) < 10)
                    {
                        MsgPrint("You faint from the lack of food.");
                        Disturb(true);
                        Player.SetTimedParalysis(Player.TimedParalysis + 1 + Program.Rng.RandomLessThan(5));
                    }
                }
            }
            if (Player.HasRegeneration)
            {
                regenAmount *= 2;
            }
            if (Player.IsSearching || Resting != 0)
            {
                regenAmount *= 2;
            }
            int upkeepFactor = 0;
            if (TotalFriends != 0)
            {
                int upkeepDivider = 20;
                if (Player.ProfessionIndex == CharacterClass.Mage)
                {
                    upkeepDivider = 15;
                }
                else if (Player.ProfessionIndex == CharacterClass.HighMage)
                {
                    upkeepDivider = 12;
                }
                if (TotalFriends > 1 + (Player.Level / upkeepDivider))
                {
                    upkeepFactor = TotalFriendLevels;
                    if (upkeepFactor > 100)
                    {
                        upkeepFactor = 100;
                    }
                    else if (upkeepFactor < 10)
                    {
                        upkeepFactor = 10;
                    }
                }
            }
            if (Player.Mana < Player.MaxMana)
            {
                if (upkeepFactor != 0)
                {
                    int upkeepRegen = (100 - upkeepFactor) * regenAmount / 100;
                    Player.RegenerateMana(upkeepRegen);
                }
                else
                {
                    Player.RegenerateMana(regenAmount);
                }
            }
            if (Player.TimedPoison != 0)
            {
                regenAmount = 0;
            }
            if (Player.TimedBleeding != 0)
            {
                regenAmount = 0;
            }
            if (caveNoRegen)
            {
                regenAmount = 0;
            }
            if (Player.Health < Player.MaxHealth && !caveNoRegen)
            {
                Player.RegenerateHealth(regenAmount);
            }
            if (Player.TimedHallucinations != 0)
            {
                Player.SetTimedHallucinations(Player.TimedHallucinations - 1);
            }
            if (Player.TimedBlindness != 0)
            {
                Player.SetTimedBlindness(Player.TimedBlindness - 1);
            }
            if (Player.TimedSeeInvisibility != 0)
            {
                Player.SetTimedSeeInvisibility(Player.TimedSeeInvisibility - 1);
            }
            if (Player.GooPatron.MultiRew)
            {
                Player.GooPatron.MultiRew = false;
            }
            if (Player.TimedTelepathy != 0)
            {
                Player.SetTimedTelepathy(Player.TimedTelepathy - 1);
            }
            if (Player.TimedInfravision != 0)
            {
                Player.SetTimedInfravision(Player.TimedInfravision - 1);
            }
            if (Player.TimedParalysis != 0)
            {
                Player.SetTimedParalysis(Player.TimedParalysis - 1);
            }
            if (Player.TimedConfusion != 0)
            {
                Player.SetTimedConfusion(Player.TimedConfusion - 1);
            }
            if (Player.TimedFear != 0)
            {
                Player.SetTimedFear(Player.TimedFear - 1);
            }
            if (Player.TimedHaste != 0)
            {
                Player.SetTimedHaste(Player.TimedHaste - 1);
            }
            if (Player.TimedSlow != 0)
            {
                Player.SetTimedSlow(Player.TimedSlow - 1);
            }
            if (Player.TimedProtectionFromEvil != 0)
            {
                Player.SetTimedProtectionFromEvil(Player.TimedProtectionFromEvil - 1);
            }
            if (Player.TimedInvulnerability != 0)
            {
                Player.SetTimedInvulnerability(Player.TimedInvulnerability - 1);
            }
            if (Player.TimedEtherealness != 0)
            {
                Player.SetTimedEtherealness(Player.TimedEtherealness - 1);
            }
            if (Player.TimedHeroism != 0)
            {
                Player.SetTimedHeroism(Player.TimedHeroism - 1);
            }
            if (Player.TimedSuperheroism != 0)
            {
                Player.SetTimedSuperheroism(Player.TimedSuperheroism - 1);
            }
            if (Player.TimedBlessing != 0)
            {
                Player.SetTimedBlessing(Player.TimedBlessing - 1);
            }
            if (Player.TimedStoneskin != 0)
            {
                Player.SetTimedStoneskin(Player.TimedStoneskin - 1);
            }
            if (Player.TimedAcidResistance != 0)
            {
                Player.SetTimedAcidResistance(Player.TimedAcidResistance - 1);
            }
            if (Player.TimedLightningResistance != 0)
            {
                Player.SetTimedLightningResistance(Player.TimedLightningResistance - 1);
            }
            if (Player.TimedFireResistance != 0)
            {
                Player.SetTimedFireResistance(Player.TimedFireResistance - 1);
            }
            if (Player.TimedColdResistance != 0)
            {
                Player.SetTimedColdResistance(Player.TimedColdResistance - 1);
            }
            if (Player.TimedPoisonResistance != 0)
            {
                Player.SetTimedPoisonResistance(Player.TimedPoisonResistance - 1);
            }
            if (Player.TimedPoison != 0)
            {
                int adjust = Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                Player.SetTimedPoison(Player.TimedPoison - adjust);
            }
            if (Player.TimedStun != 0)
            {
                int adjust = Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                Player.SetTimedStun(Player.TimedStun - adjust);
            }
            if (Player.TimedBleeding != 0)
            {
                int adjust = Player.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
                if (Player.TimedBleeding > 1000)
                {
                    adjust = 0;
                }
                Player.SetTimedBleeding(Player.TimedBleeding - adjust);
            }
            oPtr = Player.Inventory[InventorySlot.Lightsource];
            if (oPtr.Category == ItemCategory.Light)
            {
                if ((oPtr.ItemSubCategory == LightType.Torch || oPtr.ItemSubCategory == LightType.Lantern) && oPtr.TypeSpecificValue > 0)
                {
                    oPtr.TypeSpecificValue--;
                    if (Player.TimedBlindness != 0)
                    {
                        if (oPtr.TypeSpecificValue == 0)
                        {
                            oPtr.TypeSpecificValue++;
                        }
                    }
                    else if (oPtr.TypeSpecificValue == 0)
                    {
                        Disturb(true);
                        MsgPrint("Your light has gone out!");
                    }
                    else if (oPtr.TypeSpecificValue < 100 && oPtr.TypeSpecificValue % 10 == 0)
                    {
                        MsgPrint("Your light is growing faint.");
                    }
                }
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            if (Player.HasExperienceDrain)
            {
                if (Program.Rng.RandomLessThan(100) < 10 && Player.ExperiencePoints > 0)
                {
                    Player.ExperiencePoints--;
                    Player.MaxExperienceGained--;
                    Player.CheckExperience();
                }
            }
            if (Program.Rng.DieRoll(999) == 1 && !Player.HasAntiMagic)
            {
                if (Player.Inventory[InventorySlot.Lightsource].Category != 0 && Player.TimedInvulnerability == 0 &&
                    Player.Inventory[InventorySlot.Lightsource].ItemSubCategory == LightType.Thrain)
                {
                    MsgPrint("The Jewel of Judgement drains life from you!");
                    Player.TakeHit(Math.Min(Player.Level, 50), "the Jewel of Judgement");
                }
            }
            int j;
            for (j = 0, i = InventorySlot.MeleeWeapon; i < InventorySlot.Total; i++)
            {
                oPtr = Player.Inventory[i];
                oPtr.RefreshFlagBasedProperties();
                if (oPtr.Characteristics.DreadCurse && Program.Rng.DieRoll(100) == 1)
                {
                    ActivateDreadCurse();
                }
                if (oPtr.Characteristics.Teleport && Program.Rng.RandomLessThan(100) < 1)
                {
                    if (oPtr.IdentifyFlags.IsSet(Constants.IdentCursed) && !Player.HasAntiTeleport)
                    {
                        Disturb(true);
                        TeleportPlayer(40);
                    }
                    else
                    {
                        if (GetCheck("Teleport? "))
                        {
                            Disturb(false);
                            TeleportPlayer(50);
                        }
                    }
                }
                Player.Dna.OnProcessWorld(this, Player, Level);
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.RechargeTimeLeft > 0)
                {
                    oPtr.RechargeTimeLeft--;
                    if (oPtr.RechargeTimeLeft == 0)
                    {
                        j++;
                    }
                }
            }
            for (j = 0, i = 0; i < InventorySlot.Pack; i++)
            {
                oPtr = Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.Category == ItemCategory.Rod && oPtr.TypeSpecificValue != 0)
                {
                    oPtr.TypeSpecificValue--;
                    if (oPtr.TypeSpecificValue == 0)
                    {
                        j++;
                    }
                }
            }
            if (j != 0)
            {
                Player.NoticeFlags |= Constants.PnCombine;
            }
            Player.SenseInventory();
            for (i = 1; i < Level.OMax; i++)
            {
                oPtr = Level.Items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.Category == ItemCategory.Rod && oPtr.TypeSpecificValue != 0)
                {
                    oPtr.TypeSpecificValue--;
                }
            }
            if (Player.WordOfRecallDelay != 0)
            {
                Player.WordOfRecallDelay--;
                if (Player.WordOfRecallDelay == 0)
                {
                    Disturb(false);
                    if (CurrentDepth != 0)
                    {
                        MsgPrint(CurDungeon.Tower
                            ? "You feel yourself yanked downwards!"
                            : "You feel yourself yanked upwards!");
                        DoCmdSaveGame(true);
                        RecallDungeon = CurDungeon.Index;
                        CurrentDepth = 0;
                        if (Player.TownWithHouse > -1)
                        {
                            CurTown = Towns[Player.TownWithHouse];
                            Player.WildernessX = CurTown.X;
                            Player.WildernessY = CurTown.Y;
                            NewLevelFlag = true;
                            CameFrom = LevelStart.StartHouse;
                        }
                        else
                        {
                            Player.WildernessX = CurTown.X;
                            Player.WildernessY = CurTown.Y;
                            NewLevelFlag = true;
                            CameFrom = LevelStart.StartRandom;
                        }
                    }
                    else
                    {
                        MsgPrint(Dungeons[RecallDungeon].Tower
                            ? "You feel yourself yanked upwards!"
                            : "You feel yourself yanked downwards!");
                        DoCmdSaveGame(true);
                        CurDungeon = Dungeons[RecallDungeon];
                        Player.WildernessX = CurDungeon.X;
                        Player.WildernessY = CurDungeon.Y;
                        CurrentDepth = Player.MaxDlv[CurDungeon.Index];
                        if (CurrentDepth < 1)
                        {
                            CurrentDepth = 1;
                        }
                        NewLevelFlag = true;
                    }
                    PlaySound(SoundEffect.TeleportLevel);
                }
            }
        }

        private void RedrawStuff()
        {
            if (Player.RedrawNeeded.IsClear())
            {
                return;
            }
            if (Player == null)
            {
                return;
            }
            if (FullScreenOverlay)
            {
                return;
            }
            PlayerStatus playerStatus = new PlayerStatus(this);
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrWipe))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrWipe);
                MsgPrint(null);
                Clear();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrMap))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrMap);
                Level.PrtMap();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrBasic))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrBasic);
                Player.RedrawNeeded.Clear(RedrawFlag.PrMisc | RedrawFlag.PrTitle | RedrawFlag.PrStats);
                Player.RedrawNeeded.Clear(RedrawFlag.PrLev | RedrawFlag.PrExp | RedrawFlag.PrGold);
                Player.RedrawNeeded.Clear(RedrawFlag.PrArmor | RedrawFlag.PrHp | RedrawFlag.PrMana);
                Player.RedrawNeeded.Clear(RedrawFlag.PrDepth | RedrawFlag.PrHealth);
                playerStatus.PrtFrameBasic();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrEquippy))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrEquippy);
                CharacterViewer.PrintEquippy(this, Player);
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrMisc))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrMisc);
                playerStatus.PrtField(Player.Race.Title, ScreenLocation.RowRace, ScreenLocation.ColRace);
                playerStatus.PrtField(Profession.ClassSubName(Player.ProfessionIndex, Player.Realm1), ScreenLocation.RowClass,
                    ScreenLocation.ColClass);
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrTitle))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrTitle);
                playerStatus.PrtTitle();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrLev))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrLev);
                playerStatus.PrtLevel();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrExp))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrExp);
                playerStatus.PrtExp();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrStats))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrStats);
                playerStatus.PrtStat(Ability.Strength);
                playerStatus.PrtStat(Ability.Intelligence);
                playerStatus.PrtStat(Ability.Wisdom);
                playerStatus.PrtStat(Ability.Dexterity);
                playerStatus.PrtStat(Ability.Constitution);
                playerStatus.PrtStat(Ability.Charisma);
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrArmor))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrArmor);
                playerStatus.PrtAc();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrHp))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrHp);
                playerStatus.PrtHp();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrMana))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrMana);
                playerStatus.PrtSp();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrGold))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrGold);
                playerStatus.PrtGold();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrDepth))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrDepth);
                playerStatus.PrtDepth();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrHealth))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrHealth);
                playerStatus.HealthRedraw();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrExtra))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrExtra);
                Player.RedrawNeeded.Clear(RedrawFlag.PrCut | RedrawFlag.PrStun);
                Player.RedrawNeeded.Clear(RedrawFlag.PrHunger | RedrawFlag.PrDtrap);
                Player.RedrawNeeded.Clear(RedrawFlag.PrBlind | RedrawFlag.PrConfused);
                Player.RedrawNeeded.Clear(RedrawFlag.PrAfraid | RedrawFlag.PrPoisoned);
                Player.RedrawNeeded.Clear(RedrawFlag.PrState | RedrawFlag.PrSpeed | RedrawFlag.PrStudy);
                playerStatus.PrtFrameExtra();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrCut))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrCut);
                playerStatus.PrtCut();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrStun))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrStun);
                playerStatus.PrtStun();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrHunger))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrHunger);
                playerStatus.PrtHunger();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrDtrap))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrDtrap);
                playerStatus.PrtDtrap();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrBlind))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrBlind);
                playerStatus.PrtBlind();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrConfused))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrConfused);
                playerStatus.PrtConfused();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrAfraid))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrAfraid);
                playerStatus.PrtAfraid();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrPoisoned))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrPoisoned);
                playerStatus.PrtPoisoned();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrState))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrState);
                playerStatus.PrtState();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrSpeed))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrSpeed);
                playerStatus.PrtSpeed();
            }
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrStudy))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrStudy);
                playerStatus.PrtStudy();
            }
            playerStatus.PrtTime();
        }

        private void RegenMonsters()
        {
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (mPtr.Health < mPtr.MaxHealth)
                {
                    int frac = mPtr.MaxHealth / 100;
                    if (frac == 0)
                    {
                        frac = 1;
                    }
                    if ((rPtr.Flags2 & MonsterFlag2.Regenerate) != 0)
                    {
                        frac *= 2;
                    }
                    mPtr.Health += frac;
                    if (mPtr.Health > mPtr.MaxHealth)
                    {
                        mPtr.Health = mPtr.MaxHealth;
                    }
                    if (TrackedMonsterIndex == i)
                    {
                        Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                }
            }
        }

        private bool Verify(string prompt, int item)
        {
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            string oName = oPtr.Description(true, 3);
            string outVal = $"{prompt} {oName}? ";
            return GetCheck(outVal);
        }


        // SpellEffectsHandler
        public void AcidDam(int dam, string kbStr)
        {
            int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
            if (Player.HasAcidImmunity || dam <= 0)
            {
                return;
            }
            if (Player.HasElementalVulnerability)
            {
                dam *= 2;
            }
            if (Player.HasAcidResistance)
            {
                dam = (dam + 2) / 3;
            }
            if (Player.TimedAcidResistance != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedAcidResistance != 0 || Player.HasAcidResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Charisma);
            }
            if (MinusAc())
            {
                dam = (dam + 1) / 2;
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.TimedAcidResistance != 0 && Player.HasAcidResistance))
            {
                Player.Inventory.InvenDamage(SetAcidDestroy, inv);
            }
        }

        public void ActivateHiSummon()
        {
            int i;
            for (i = 0; i < Program.Rng.DieRoll(9) + (Difficulty / 40); i++)
            {
                switch (Program.Rng.DieRoll(26) + (Difficulty / 20))
                {
                    case 1:
                    case 2:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, Constants.SummonAnt);
                        break;

                    case 3:
                    case 4:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonSpider);
                        break;

                    case 5:
                    case 6:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonHound);
                        break;

                    case 7:
                    case 8:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonHydra);
                        break;

                    case 9:
                    case 10:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonCthuloid);
                        break;

                    case 11:
                    case 12:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonUndead);
                        break;

                    case 13:
                    case 14:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonDragon);
                        break;

                    case 15:
                    case 16:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonDemon);
                        break;

                    case 17:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, Constants.SummonGoo);
                        break;

                    case 18:
                    case 19:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonUnique);
                        break;

                    case 20:
                    case 21:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonHiUndead);
                        break;

                    case 22:
                    case 23:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty,
                            Constants.SummonHiDragon);
                        break;

                    case 24:
                    case 25:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, 100, Constants.SummonReaver);
                        break;

                    default:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, (Difficulty * 3 / 2) + 5, 0);
                        break;
                }
            }
        }

        public void AggravateMonsters(int indexOfMonsterToNotAggravateOrZeroForNone) // TODO: Monster[0] is skipped?
        {
            bool sleep = false;
            bool speed = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (i == indexOfMonsterToNotAggravateOrZeroForNone)
                {
                    continue;
                }
                if (mPtr.DistanceFromPlayer < Constants.MaxSight * 2)
                {
                    if (mPtr.SleepLevel != 0)
                    {
                        mPtr.SleepLevel = 0;
                        sleep = true;
                    }
                }
                if (Level.PlayerHasLosBold(mPtr.MapY, mPtr.MapX))
                {
                    if (mPtr.Speed < rPtr.Speed + 10)
                    {
                        mPtr.Speed = rPtr.Speed + 10;
                        speed = true;
                    }
                    if ((mPtr.Mind & Constants.SmFriendly) != 0)
                    {
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            mPtr.Mind &= ~Constants.SmFriendly;
                        }
                    }
                }
            }
            if (speed)
            {
                MsgPrint("You feel a sudden stirring nearby!");
            }
            else if (sleep)
            {
                MsgPrint("You hear a sudden stirring in the distance!");
            }
        }

        public void Alchemy()
        {
            int amt = 1;
            bool force = CommandArgument > 0;
            if (!GetItem(out int item, "Turn which item to gold? ", false, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to turn to gold.");
                }
                return;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            if (oPtr.Count > 1)
            {
                amt = GetQuantity(null, oPtr.Count, true);
                if (amt <= 0)
                {
                    return;
                }
            }
            int oldNumber = oPtr.Count;
            oPtr.Count = amt;
            string oName = oPtr.Description(true, 3);
            oPtr.Count = oldNumber;
            if (!force)
            {
                if (!(oPtr.Value() < 1))
                {
                    string outVal = $"Really turn {oName} to gold? ";
                    if (!GetCheck(outVal))
                    {
                        return;
                    }
                }
            }
            if (oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false)
            {
                string feel = "special";
                MsgPrint($"You fail to turn {oName} to gold!");
                if (oPtr.IsCursed() || oPtr.IsBroken())
                {
                    feel = "terrible";
                }
                oPtr.Inscription = feel;
                oPtr.IdentifyFlags.Set(Constants.IdentSense);
                Player.NoticeFlags |= Constants.PnCombine;
                return;
            }
            int price = oPtr.RealValue();
            if (price <= 0)
            {
                MsgPrint($"You turn {oName} to fool's gold.");
            }
            else
            {
                price /= 3;
                if (amt > 1)
                {
                    price *= amt;
                }
                if (price > 30000)
                {
                    price = 30000;
                }
                MsgPrint($"You turn {oName} to {price} coins worth of gold.");
                Player.Gold += price;
                Player.RedrawNeeded.Set(RedrawFlag.PrGold);
            }
            if (item >= 0)
            {
                Player.Inventory.InvenItemIncrease(item, -amt);
                Player.Inventory.InvenItemDescribe(item);
                Player.Inventory.InvenItemOptimize(item);
            }
            else
            {
                Level.FloorItemIncrease(0 - item, -amt);
                Level.FloorItemDescribe(0 - item);
                Level.FloorItemOptimize(0 - item);
            }
        }

        public void AlterReality()
        {
            MsgPrint("The world changes!");
            DoCmdSaveGame(true);
            NewLevelFlag = true;
            CameFrom = LevelStart.StartRandom;
        }

        public bool ApplyDisenchant()
        {
            int t = 0;
            switch (Program.Rng.DieRoll(8))
            {
                case 1:
                    t = InventorySlot.MeleeWeapon;
                    break;

                case 2:
                    t = InventorySlot.RangedWeapon;
                    break;

                case 3:
                    t = InventorySlot.Body;
                    break;

                case 4:
                    t = InventorySlot.Cloak;
                    break;

                case 5:
                    t = InventorySlot.Arm;
                    break;

                case 6:
                    t = InventorySlot.Head;
                    break;

                case 7:
                    t = InventorySlot.Hands;
                    break;

                case 8:
                    t = InventorySlot.Feet;
                    break;
            }
            Item oPtr = Player.Inventory[t];
            if (oPtr.BaseItemCategory == null)
            {
                return false;
            }
            if (oPtr.BonusToHit <= 0 && oPtr.BonusDamage <= 0 && oPtr.BonusArmourClass <= 0)
            {
                return false;
            }
            string oName = oPtr.Description(false, 0);
            string s;
            if ((oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false) &&
                Program.Rng.RandomLessThan(100) < 71)
            {
                s = oPtr.Count != 1 ? "" : "s";
                MsgPrint($"Your {oName} ({t.IndexToLabel()}) resist{s} disenchantment!");
                return true;
            }
            if (oPtr.BonusToHit > 0)
            {
                oPtr.BonusToHit--;
            }
            if (oPtr.BonusToHit > 5 && Program.Rng.RandomLessThan(100) < 20)
            {
                oPtr.BonusToHit--;
            }
            if (oPtr.BonusDamage > 0)
            {
                oPtr.BonusDamage--;
            }
            if (oPtr.BonusDamage > 5 && Program.Rng.RandomLessThan(100) < 20)
            {
                oPtr.BonusDamage--;
            }
            if (oPtr.BonusArmourClass > 0)
            {
                oPtr.BonusArmourClass--;
            }
            if (oPtr.BonusArmourClass > 5 && Program.Rng.RandomLessThan(100) < 20)
            {
                oPtr.BonusArmourClass--;
            }
            s = oPtr.Count != 1 ? "were" : "was";
            MsgPrint($"Your {oName} ({t.IndexToLabel()}) {s} disenchanted!");
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            return true;
        }

        public void ApplyNexus(Monster mPtr)
        {
            switch (Program.Rng.DieRoll(7))
            {
                case 1:
                case 2:
                case 3:
                    {
                        TeleportPlayer(200);
                        break;
                    }
                case 4:
                case 5:
                    {
                        TeleportPlayerTo(mPtr.MapY, mPtr.MapX);
                        break;
                    }
                case 6:
                    {
                        if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                        {
                            MsgPrint("You resist the effects!");
                            break;
                        }
                        TeleportPlayerLevel();
                        break;
                    }
                case 7:
                    {
                        if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                        {
                            MsgPrint("You resist the effects!");
                            break;
                        }
                        MsgPrint("Your body starts to scramble...");
                        Player.ShuffleAbilityScores();
                        break;
                    }
            }
        }

        public void ArtifactScroll()
        {
            bool okay;
            ItemFilter = ItemTesterHookWeapon;
            if (!GetItem(out int item, "Enchant which item? ", true, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to enchant.");
                }
                return;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            string oName = oPtr.Description(false, 0);
            string your = item >= 0 ? "Your" : "The";
            string s = oPtr.Count > 1 ? "" : "s";
            MsgPrint($"{your} {oName} radiate{s} a blinding light!");
            if (oPtr.FixedArtifactIndex != 0 || string.IsNullOrEmpty(oPtr.RandartName) == false)
            {
                string are = oPtr.Count > 1 ? "are" : "is";
                s = oPtr.Count > 1 ? "artifacts" : "an artifact";
                MsgPrint($"The {oName} {are} already {s}!");
                okay = false;
            }
            else if (oPtr.RareItemTypeIndex != 0)
            {
                string are = oPtr.Count > 1 ? "are" : "is";
                s = oPtr.Count > 1 ? "rare items" : "a rare item";
                MsgPrint($"The {oName} {are} already {s}!");
                okay = false;
            }
            else
            {
                if (oPtr.Count > 1)
                {
                    MsgPrint("Not enough enough energy to enchant more than one object!");
                    s = oPtr.Count > 2 ? "were" : "was";
                    MsgPrint($"{oPtr.Count - 1} of your oName {s} destroyed!");
                    oPtr.Count = 1;
                }
                okay = oPtr.CreateRandart(true);
            }
            if (!okay)
            {
                MsgPrint("The enchantment failed.");
            }
        }

        public bool BanishEvil(int dist)
        {
            return ProjectAtAllInLos(new ProjectAwayEvil(this), dist);
        }

        public void BanishMonsters(int dist)
        {
            ProjectAtAllInLos(new ProjectAwayAll(this), dist);
        }

        public void BlessWeapon()
        {
            ItemFilter = ItemTesterHookWeapon;
            if (!GetItem(out int item, "Bless which weapon? ", true, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have weapon to bless.");
                }
                return;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            string oName = oPtr.Description(false, 0);
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.IdentifyFlags.IsSet(Constants.IdentCursed))
            {
                string your;
                if ((oPtr.Characteristics.HeavyCurse && Program.Rng.DieRoll(100) < 33) || oPtr.Characteristics.PermaCurse)
                {
                    your = item >= 0 ? "your" : "the";
                    MsgPrint($"The black aura on {your} {oName} disrupts the blessing!");
                    return;
                }
                your = item >= 0 ? "your" : "the";
                MsgPrint($"A malignant aura leaves {your} {oName}.");
                oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                oPtr.IdentifyFlags.Set(Constants.IdentSense);
                oPtr.Inscription = "uncursed";
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            }
            if (oPtr.Characteristics.Blessed)
            {
                string your = item >= 0 ? "your" : "the";
                string s = oPtr.Count > 1 ? "were" : "was";
                MsgPrint($"{your} {oName} {s} blessed already.");
                return;
            }
            if (!(string.IsNullOrEmpty(oPtr.RandartName) == false || oPtr.FixedArtifactIndex != 0) ||
                Program.Rng.DieRoll(3) == 1)
            {
                string your = item >= 0 ? "your" : "the";
                string s = oPtr.Count > 1 ? "" : "s";
                MsgPrint($"{your} {oName} shine{s}!");
                oPtr.RandartItemCharacteristics.Blessed = true;
            }
            else
            {
                bool disHappened = false;
                MsgPrint("The artifact resists your blessing!");
                if (oPtr.BonusToHit > 0)
                {
                    oPtr.BonusToHit--;
                    disHappened = true;
                }
                if (oPtr.BonusToHit > 5 && Program.Rng.RandomLessThan(100) < 33)
                {
                    oPtr.BonusToHit--;
                }
                if (oPtr.BonusDamage > 0)
                {
                    oPtr.BonusDamage--;
                    disHappened = true;
                }
                if (oPtr.BonusDamage > 5 && Program.Rng.RandomLessThan(100) < 33)
                {
                    oPtr.BonusDamage--;
                }
                if (oPtr.BonusArmourClass > 0)
                {
                    oPtr.BonusArmourClass--;
                    disHappened = true;
                }
                if (oPtr.BonusArmourClass > 5 && Program.Rng.RandomLessThan(100) < 33)
                {
                    oPtr.BonusArmourClass--;
                }
                if (disHappened)
                {
                    MsgPrint("There is a  feeling in the air...");
                    string your = item >= 0 ? "your" : "the";
                    string s = oPtr.Count > 1 ? "were" : "was";
                    MsgPrint($"{your} {oName} {s} disenchanted!");
                }
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
        }

        public void CallChaos()
        {
            TargetEngine targetEngine = new TargetEngine(this);
            int plev = Player.Level;
            bool lineChaos = false;
            Projectile[] hurtTypes =
            {
                new ProjectElec(this), new ProjectPois(this), new ProjectAcid(this), new ProjectCold(this),
                new ProjectFire(this), new ProjectMissile(this), new ProjectArrow(this), new ProjectPlasma(this),
                new ProjectHolyFire(this), new ProjectWater(this), new ProjectLight(this), new ProjectDark(this),
                new ProjectForce(this), new ProjectInertia(this), new ProjectMana(this), new ProjectMeteor(this),
                new ProjectIce(this), new ProjectChaos(this), new ProjectNether(this), new ProjectDisenchant(this),
                new ProjectExplode(this), new ProjectSound(this), new ProjectNexus(this), new ProjectConfusion(this),
                new ProjectTime(this), new ProjectGravity(this), new ProjectShard(this), new ProjectNuke(this),
                new ProjectHellFire(this), new ProjectDisintegrate(this)
            };
            Projectile chaosType = hurtTypes[Program.Rng.DieRoll(30) - 1];
            if (Program.Rng.DieRoll(4) == 1)
            {
                lineChaos = true;
            }
            if (Program.Rng.DieRoll(6) == 1)
            {
                for (int dummy = 1; dummy < 10; dummy++)
                {
                    if (dummy - 5 != 0)
                    {
                        if (lineChaos)
                        {
                            FireBeam(chaosType, dummy, 75);
                        }
                        else
                        {
                            FireBall(chaosType, dummy, 75, 2);
                        }
                    }
                }
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                FireBall(chaosType, 0, 300, 8);
            }
            else
            {
                if (!targetEngine.GetDirectionWithAim(out int dir))
                {
                    return;
                }
                if (lineChaos)
                {
                    FireBeam(chaosType, dir, 150);
                }
                else
                {
                    FireBall(chaosType, dir, 150, 3 + (plev / 35));
                }
            }
        }

        public void Carnage(bool playerCast)
        {
            int msec = GlobalData.DelayFactor * GlobalData.DelayFactor * GlobalData.DelayFactor;
            GetCom("Choose a monster race (by symbol) to carnage: ", out char typ);
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    continue;
                }
                if (rPtr.Character != typ)
                {
                    continue;
                }
                if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
                {
                    continue;
                }
                Level.Monsters.DeleteMonsterByIndex(i, true);
                if (playerCast)
                {
                    Player.TakeHit(Program.Rng.DieRoll(4), "the strain of casting Carnage");
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                Player.RedrawNeeded.Set(RedrawFlag.PrHp);
                HandleStuff();
                UpdateScreen();
                Pause(msec);
            }
        }

        public void CharmAnimal(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectControlAnimal(this), dir, plev, flg);
        }

        public void CharmAnimals(int dam)
        {
            ProjectAtAllInLos(new ProjectControlAnimal(this), dam);
        }

        public bool CharmMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectCharm(this), dir, plev, flg);
        }

        public void CharmMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectCharm(this), dam);
        }

        public bool CloneMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldClone(this), dir, 0, flg);
        }

        public void ColdDam(int dam, string kbStr)
        {
            int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
            if (Player.HasColdImmunity || dam <= 0)
            {
                return;
            }
            if (Player.HasElementalVulnerability)
            {
                dam *= 2;
            }
            if (Player.HasColdResistance)
            {
                dam = (dam + 2) / 3;
            }
            if (Player.TimedColdResistance != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedColdResistance != 0 || Player.HasColdResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Strength);
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.HasColdResistance && Player.TimedColdResistance != 0))
            {
                Player.Inventory.InvenDamage(SetColdDestroy, inv);
            }
        }

        public bool ConfuseMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldConf(this), dir, plev, flg);
        }

        public void ConfuseMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectOldConf(this), dam);
        }

        public void ControlOneUndead(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectControlUndead(this), dir, plev, flg);
        }

        public void DeathRay(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectDeathRay(this), dir, plev, flg);
        }

        public void DestroyArea(int y1, int x1, int r)
        {
            int y, x;
            bool flag = false;
            for (y = y1 - r; y <= y1 + r; y++)
            {
                for (x = x1 - r; x <= x1 + r; x++)
                {
                    if (!Level.InBounds(y, x))
                    {
                        continue;
                    }
                    int k = Level.Distance(y1, x1, y, x);
                    if (k > r)
                    {
                        continue;
                    }
                    GridTile cPtr = Level.Grid[y][x];
                    cPtr.TileFlags.Clear(GridTile.InRoom | GridTile.InVault);
                    cPtr.TileFlags.Clear(GridTile.PlayerMemorised | GridTile.SelfLit);
                    if (x == Player.MapX && y == Player.MapY)
                    {
                        flag = true;
                        continue;
                    }
                    if (y == y1 && x == x1)
                    {
                        continue;
                    }
                    Level.DeleteMonster(y, x);
                    if (Level.CaveValidBold(y, x))
                    {
                        Level.DeleteObject(y, x);
                        int t = Program.Rng.RandomLessThan(200);
                        if (t < 20)
                        {
                            cPtr.SetFeature("WallBasic");
                        }
                        else if (t < 70)
                        {
                            cPtr.SetFeature("Quartz");
                        }
                        else if (t < 100)
                        {
                            cPtr.SetFeature("Magma");
                        }
                        else
                        {
                            cPtr.RevertToBackground();
                        }
                    }
                }
            }
            if (flag)
            {
                MsgPrint("There is a searing blast of light!");
                if (!Player.HasBlindnessResistance && !Player.HasLightResistance)
                {
                    Player.SetTimedBlindness(Player.TimedBlindness + 10 + Program.Rng.DieRoll(10));
                }
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateRemoveView | UpdateFlags.UpdateRemoveLight);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
        }

        public bool DestroyDoor(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
            return TargetedProject(new ProjectKillDoor(this), dir, 0, flg);
        }

        public bool DestroyDoorsTouch()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            return Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectKillDoor(this), flg);
        }

        public bool DetectAll()
        {
            bool detect = DetectTraps();
            detect |= DetectDoors();
            detect |= DetectStairs();
            detect |= DetectTreasure();
            detect |= DetectObjectsGold();
            detect |= DetectObjectsNormal();
            detect |= DetectMonstersInvis();
            detect |= DetectMonstersNormal();
            return detect;
        }

        public bool DetectDoors()
        {
            bool detect = false;
            for (int y = Level.PanelRowMin; y <= Level.PanelRowMax; y++)
            {
                for (int x = Level.PanelColMin; x <= Level.PanelColMax; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    if (cPtr.FeatureType.Category == FloorTileTypeCategory.SecretDoor)
                    {
                        Level.ReplaceSecretDoor(y, x);
                    }
                    if (cPtr.FeatureType.IsClosedDoor ||
                        cPtr.FeatureType.Category == FloorTileTypeCategory.OpenDoorway)
                    {
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(y, x);
                        detect = true;
                    }
                }
            }
            if (detect)
            {
                MsgPrint("You sense the presence of doors!");
            }
            return detect;
        }

        public bool DetectMonstersEvil()
        {
            bool flag = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                int y = mPtr.MapY;
                int x = mPtr.MapX;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if ((rPtr.Flags3 & MonsterFlag3.Evil) != 0)
                {
                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.Evil;
                    Level.Monsters.RepairMonsters = true;
                    mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                    mPtr.IsVisible = true;
                    Level.RedrawSingleLocation(y, x);
                    flag = true;
                }
            }
            if (flag)
            {
                MsgPrint("You sense the presence of evil creatures!");
            }
            return flag;
        }

        public bool DetectMonstersInvis()
        {
            bool flag = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                int y = mPtr.MapY;
                int x = mPtr.MapX;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if ((rPtr.Flags2 & MonsterFlag2.Invisible) != 0)
                {
                    rPtr.Knowledge.RFlags2 |= MonsterFlag2.Invisible;
                    Level.Monsters.RepairMonsters = true;
                    mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                    mPtr.IsVisible = true;
                    Level.RedrawSingleLocation(y, x);
                    flag = true;
                }
            }
            if (flag)
            {
                MsgPrint("You sense the presence of invisible creatures!");
            }
            return flag;
        }

        public void DetectMonstersNonliving()
        {
            bool flag = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                int y = mPtr.MapY;
                int x = mPtr.MapX;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if ((rPtr.Flags3 & MonsterFlag3.Nonliving) != 0 || (rPtr.Flags3 & MonsterFlag3.Undead) != 0 ||
                    (rPtr.Flags3 & MonsterFlag3.Cthuloid) != 0 || (rPtr.Flags3 & MonsterFlag3.Demon) != 0)
                {
                    Level.Monsters.RepairMonsters = true;
                    mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                    mPtr.IsVisible = true;
                    Level.RedrawSingleLocation(y, x);
                    flag = true;
                }
            }
            if (flag)
            {
                MsgPrint("You sense the presence of unnatural beings!");
            }
        }

        public bool DetectMonstersNormal()
        {
            bool flag = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                int y = mPtr.MapY;
                int x = mPtr.MapX;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if ((rPtr.Flags2 & MonsterFlag2.Invisible) == 0 || Player.HasSeeInvisibility || Player.TimedSeeInvisibility != 0)
                {
                    Level.Monsters.RepairMonsters = true;
                    mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                    mPtr.IsVisible = true;
                    Level.RedrawSingleLocation(y, x);
                    flag = true;
                }
            }
            if (flag)
            {
                MsgPrint("You sense the presence of monsters!");
            }
            return flag;
        }

        public bool DetectObjectsGold()
        {
            bool detect = false;
            for (int i = 1; i < Level.OMax; i++)
            {
                Item oPtr = Level.Items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.HoldingMonsterIndex != 0)
                {
                    continue;
                }
                int y = oPtr.Y;
                int x = oPtr.X;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if (oPtr.Category == ItemCategory.Gold)
                {
                    oPtr.Marked = true;
                    Level.RedrawSingleLocation(y, x);
                    detect = true;
                }
            }
            if (detect)
            {
                MsgPrint("You sense the presence of treasure!");
            }
            if (DetectMonstersString("$*"))
            {
                detect = true;
            }
            return detect;
        }

        public void DetectObjectsMagic()
        {
            bool detect = false;
            for (int i = 1; i < Level.OMax; i++)
            {
                Item oPtr = Level.Items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.HoldingMonsterIndex != 0)
                {
                    continue;
                }
                int y = oPtr.Y;
                int x = oPtr.X;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                ItemCategory tv = oPtr.Category;
                if (oPtr.IsFixedArtifact() || oPtr.IsRare() || string.IsNullOrEmpty(oPtr.RandartName) == false ||
                    tv == ItemCategory.Amulet || tv == ItemCategory.Ring || tv == ItemCategory.Staff ||
                    tv == ItemCategory.Wand || tv == ItemCategory.Rod || tv == ItemCategory.Scroll ||
                    tv == ItemCategory.Potion || tv == ItemCategory.LifeBook || tv == ItemCategory.SorceryBook ||
                    tv == ItemCategory.NatureBook || tv == ItemCategory.ChaosBook || tv == ItemCategory.DeathBook ||
                    tv == ItemCategory.CorporealBook || tv == ItemCategory.TarotBook || tv == ItemCategory.FolkBook ||
                    oPtr.BonusArmourClass > 0 || oPtr.BonusToHit + oPtr.BonusDamage > 0)
                {
                    oPtr.Marked = true;
                    Level.RedrawSingleLocation(y, x);
                    detect = true;
                }
            }
            if (detect)
            {
                MsgPrint("You sense the presence of magic objects!");
            }
        }

        public bool DetectObjectsNormal()
        {
            bool detect = false;
            for (int i = 1; i < Level.OMax; i++)
            {
                Item oPtr = Level.Items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.HoldingMonsterIndex != 0)
                {
                    continue;
                }
                int y = oPtr.Y;
                int x = oPtr.X;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if (oPtr.Category != ItemCategory.Gold)
                {
                    oPtr.Marked = true;
                    Level.RedrawSingleLocation(y, x);
                    detect = true;
                }
            }
            if (detect)
            {
                MsgPrint("You sense the presence of objects!");
            }
            if (DetectMonstersString("!=?|"))
            {
                detect = true;
            }
            return detect;
        }

        public bool DetectStairs()
        {
            bool detect = false;
            for (int y = Level.PanelRowMin; y <= Level.PanelRowMax; y++)
            {
                for (int x = Level.PanelColMin; x <= Level.PanelColMax; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    if (cPtr.FeatureType.Category == FloorTileTypeCategory.UpStair || cPtr.FeatureType.Category == FloorTileTypeCategory.DownStair)
                    {
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(y, x);
                        detect = true;
                    }
                }
            }
            if (detect)
            {
                MsgPrint("You sense the presence of stairs!");
            }
            return detect;
        }

        public bool DetectTraps()
        {
            bool detect = false;
            for (int y = Level.PanelRowMin; y <= Level.PanelRowMax; y++)
            {
                for (int x = Level.PanelColMin; x <= Level.PanelColMax; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    cPtr.TileFlags.Set(GridTile.TrapsDetected);
                    Level.RedrawSingleLocation(y, x);
                    if (cPtr.FeatureType.Category == FloorTileTypeCategory.UnidentifiedTrap)
                    {
                        Level.PickTrap(y, x);
                    }
                    if (cPtr.FeatureType.IsTrap)
                    {
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                        detect = true;
                    }
                }
            }
            Player.RedrawNeeded.Set(RedrawFlag.PrDtrap);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            if (detect)
            {
                MsgPrint("You sense the presence of traps!");
            }
            return detect;
        }

        public bool DetectTreasure()
        {
            bool detect = false;
            for (int y = Level.PanelRowMin; y <= Level.PanelRowMax; y++)
            {
                for (int x = Level.PanelColMin; x <= Level.PanelColMax; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    if (cPtr.FeatureType.Name.Contains("HidTreas"))
                    {
                        cPtr.SetFeature(cPtr.FeatureType.Name.Replace("Hid", "Vis"));
                    }
                    if (cPtr.FeatureType.Name.Contains("VisTreas"))
                    {
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(y, x);
                        detect = true;
                    }
                }
            }
            if (detect)
            {
                MsgPrint("You sense the presence of buried treasure!");
            }
            return detect;
        }

        public bool DisarmTrap(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
            return TargetedProject(new ProjectKillTrap(this), dir, 0, flg);
        }

        public void DispelDemons(int dam)
        {
            ProjectAtAllInLos(new ProjectDispDemon(this), dam);
        }

        public bool DispelEvil(int dam)
        {
            return ProjectAtAllInLos(new ProjectDispEvil(this), dam);
        }

        public void DispelGood(int dam)
        {
            ProjectAtAllInLos(new ProjectDispGood(this), dam);
        }

        public void DispelLiving(int dam)
        {
            ProjectAtAllInLos(new ProjectDispLiving(this), dam);
        }

        public bool DispelMonsters(int dam)
        {
            return ProjectAtAllInLos(new ProjectDispAll(this), dam);
        }

        public bool DispelUndead(int dam)
        {
            return ProjectAtAllInLos(new ProjectDispUndead(this), dam);
        }

        public void DoorCreation()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectMakeDoor(this), flg);
        }

        /// <summary>
        /// Returns true, if the drain life actally hits and affects a monster.
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="dam"></param>
        /// <returns></returns>
        public bool DrainLife(int dir, int dam)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldDrain(this), dir, dam, flg);
        }

        public void Earthquake(int cy, int cx, int r)
        {
            TargetEngine targetEngine = new TargetEngine(this);
            int i, y, x, yy, xx, dy, dx;
            int damage = 0;
            int sn = 0, sy = 0, sx = 0;
            bool hurt = false;
            GridTile cPtr;
            bool[][] map = new bool[32][];
            for (int j = 0; j < 32; j++)
            {
                map[j] = new bool[32];
            }
            if (r > 12)
            {
                r = 12;
            }
            for (y = 0; y < 32; y++)
            {
                for (x = 0; x < 32; x++)
                {
                    map[y][x] = false;
                }
            }
            for (dy = -r; dy <= r; dy++)
            {
                for (dx = -r; dx <= r; dx++)
                {
                    yy = cy + dy;
                    xx = cx + dx;
                    if (!Level.InBounds(yy, xx))
                    {
                        continue;
                    }
                    if (Level.Distance(cy, cx, yy, xx) > r)
                    {
                        continue;
                    }
                    cPtr = Level.Grid[yy][xx];
                    cPtr.TileFlags.Clear(GridTile.InRoom | GridTile.InVault);
                    cPtr.TileFlags.Clear(GridTile.SelfLit | GridTile.PlayerMemorised);
                    if (dx == 0 && dy == 0)
                    {
                        continue;
                    }
                    if (Program.Rng.RandomLessThan(100) < 85)
                    {
                        continue;
                    }
                    map[16 + yy - cy][16 + xx - cx] = true;
                    if (yy == Player.MapY && xx == Player.MapX)
                    {
                        hurt = true;
                    }
                }
            }
            if (hurt)
            {
                for (i = 0; i < 8; i++)
                {
                    y = Player.MapY + Level.KeypadDirectionYOffset[i];
                    x = Player.MapX + Level.KeypadDirectionXOffset[i];
                    if (!Level.GridPassableNoCreature(y, x))
                    {
                        continue;
                    }
                    if (map[16 + y - cy][16 + x - cx])
                    {
                        continue;
                    }
                    sn++;
                    if (Program.Rng.RandomLessThan(sn) > 0)
                    {
                        continue;
                    }
                    sy = y;
                    sx = x;
                }
                switch (Program.Rng.DieRoll(3))
                {
                    case 1:
                        {
                            MsgPrint("The Level.Grid ceiling collapses!");
                            break;
                        }
                    case 2:
                        {
                            MsgPrint("The Level.Grid floor twists in an unnatural way!");
                            break;
                        }
                    default:
                        {
                            MsgPrint("The Level.Grid quakes!  You are pummeled with debris!");
                            break;
                        }
                }
                if (sn == 0)
                {
                    MsgPrint("You are severely crushed!");
                    damage = 300;
                }
                else
                {
                    switch (Program.Rng.DieRoll(3))
                    {
                        case 1:
                            {
                                MsgPrint("You nimbly dodge the blast!");
                                damage = 0;
                                break;
                            }
                        case 2:
                            {
                                MsgPrint("You are bashed by rubble!");
                                damage = Program.Rng.DiceRoll(10, 4);
                                Player.SetTimedStun(Player.TimedStun + Program.Rng.DieRoll(50));
                                break;
                            }
                        case 3:
                            {
                                MsgPrint("You are crushed between the floor and ceiling!");
                                damage = Program.Rng.DiceRoll(10, 4);
                                Player.SetTimedStun(Player.TimedStun + Program.Rng.DieRoll(50));
                                break;
                            }
                    }
                    int oy = Player.MapY;
                    int ox = Player.MapX;
                    Player.MapY = sy;
                    Player.MapX = sx;
                    Level.RedrawSingleLocation(oy, ox);
                    Level.RedrawSingleLocation(Player.MapY, Player.MapX);
                    targetEngine.RecenterScreenAroundPlayer();
                }
                map[16 + Player.MapY - cy][16 + Player.MapX - cx] = false;
                if (damage != 0)
                {
                    Player.TakeHit(damage, "an earthquake");
                }
            }
            for (dy = -r; dy <= r; dy++)
            {
                for (dx = -r; dx <= r; dx++)
                {
                    yy = cy + dy;
                    xx = cx + dx;
                    if (!map[16 + yy - cy][16 + xx - cx])
                    {
                        continue;
                    }
                    cPtr = Level.Grid[yy][xx];
                    if (cPtr.MonsterIndex != 0)
                    {
                        Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
                        MonsterRace rPtr = mPtr.Race;
                        if ((rPtr.Flags2 & MonsterFlag2.KillWall) == 0 && (rPtr.Flags2 & MonsterFlag2.PassWall) == 0)
                        {
                            sn = 0;
                            if ((rPtr.Flags1 & MonsterFlag1.NeverMove) == 0)
                            {
                                for (i = 0; i < 8; i++)
                                {
                                    y = yy + Level.KeypadDirectionYOffset[i];
                                    x = xx + Level.KeypadDirectionXOffset[i];
                                    if (!Level.GridPassableNoCreature(y, x))
                                    {
                                        continue;
                                    }
                                    if (Level.Grid[y][x].FeatureType.Name == "ElderSign")
                                    {
                                        continue;
                                    }
                                    if (Level.Grid[y][x].FeatureType.Name == "YellowSign")
                                    {
                                        continue;
                                    }
                                    if (map[16 + y - cy][16 + x - cx])
                                    {
                                        continue;
                                    }
                                    sn++;
                                    if (Program.Rng.RandomLessThan(sn) > 0)
                                    {
                                        continue;
                                    }
                                    sy = y;
                                    sx = x;
                                }
                            }
                            string mName = mPtr.MonsterDesc(0);
                            MsgPrint($"{mName} wails out in pain!");
                            damage = sn != 0 ? Program.Rng.DiceRoll(4, 8) : 200;
                            mPtr.SleepLevel = 0;
                            mPtr.Health -= damage;
                            if (mPtr.Health < 0)
                            {
                                MsgPrint($"{mName} is embedded in the rock!");
                                Level.DeleteMonster(yy, xx);
                                sn = 0;
                            }
                            if (sn != 0)
                            {
                                int mIdx = Level.Grid[yy][xx].MonsterIndex;
                                Level.Grid[sy][sx].MonsterIndex = mIdx;
                                Level.Grid[yy][xx].MonsterIndex = 0;
                                mPtr.MapY = sy;
                                mPtr.MapX = sx;
                                Level.Monsters.UpdateMonsterVisibility(mIdx, true);
                                Level.RedrawSingleLocation(yy, xx);
                                Level.RedrawSingleLocation(sy, sx);
                            }
                        }
                    }
                }
            }
            for (dy = -r; dy <= r; dy++)
            {
                for (dx = -r; dx <= r; dx++)
                {
                    yy = cy + dy;
                    xx = cx + dx;
                    if (!map[16 + yy - cy][16 + xx - cx])
                    {
                        continue;
                    }
                    cPtr = Level.Grid[yy][xx];
                    if (yy == Player.MapY && xx == Player.MapX)
                    {
                        continue;
                    }
                    if (Level.CaveValidBold(yy, xx))
                    {
                        bool floor = Level.GridPassable(yy, xx);
                        Level.DeleteObject(yy, xx);
                        int t = floor ? Program.Rng.RandomLessThan(100) : 200;
                        if (t < 20)
                        {
                            cPtr.SetFeature("WallBasic");
                        }
                        else if (t < 70)
                        {
                            cPtr.SetFeature("Quartz");
                        }
                        else if (t < 100)
                        {
                            cPtr.SetFeature("Magma");
                        }
                        else
                        {
                            cPtr.RevertToBackground();
                        }
                    }
                }
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateRemoveView | UpdateFlags.UpdateRemoveLight);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
        }

        public void ElderSign()
        {
            if (!Level.GridOpenNoItem(Player.MapY, Player.MapX))
            {
                MsgPrint("The object resists the spell.");
                return;
            }
            Level.CaveSetFeat(Player.MapY, Player.MapX, "ElderSign");
        }

        public void ElderSignCreation()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
            Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectMakeElderSign(this), flg);
        }

        public void ElecDam(int dam, string kbStr)
        {
            int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
            if (Player.HasLightningImmunity || dam <= 0)
            {
                return;
            }
            if (Player.HasElementalVulnerability)
            {
                dam *= 2;
            }
            if (Player.TimedLightningResistance != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (Player.HasLightningResistance)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedLightningResistance != 0 || Player.HasLightningResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Dexterity);
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.TimedLightningResistance != 0 && Player.HasLightningResistance))
            {
                Player.Inventory.InvenDamage(SetElecDestroy, inv);
            }
        }

        public bool Enchant(Item oPtr, int n, int eflag)
        {
            bool res = false;
            bool a = oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false;
            oPtr.RefreshFlagBasedProperties();
            int prob = oPtr.Count * 100;
            if (oPtr.Category == ItemCategory.Bolt || oPtr.Category == ItemCategory.Arrow || oPtr.Category == ItemCategory.Shot)
            {
                prob /= 20;
            }
            for (int i = 0; i < n; i++)
            {
                if (Program.Rng.RandomLessThan(prob) >= 100)
                {
                    continue;
                }
                int chance;
                if ((eflag & Constants.EnchTohit) != 0)
                {
                    if (oPtr.BonusToHit < 0)
                    {
                        chance = 0;
                    }
                    else if (oPtr.BonusToHit > 15)
                    {
                        chance = 1000;
                    }
                    else
                    {
                        chance = GlobalData.EnchantTable[oPtr.BonusToHit];
                    }
                    if (Program.Rng.DieRoll(1000) > chance && (!a || Program.Rng.RandomLessThan(100) < 50))
                    {
                        oPtr.BonusToHit++;
                        res = true;
                        if (oPtr.IsCursed() && !oPtr.Characteristics.PermaCurse && oPtr.BonusToHit >= 0 && Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                            oPtr.IdentifyFlags.Set(Constants.IdentSense);
                            if (oPtr.RandartItemCharacteristics.Cursed)
                            {
                                oPtr.RandartItemCharacteristics.Cursed = false;
                            }
                            if (oPtr.RandartItemCharacteristics.HeavyCurse)
                            {
                                oPtr.RandartItemCharacteristics.HeavyCurse = false;
                            }
                            oPtr.Inscription = "uncursed";
                        }
                    }
                }
                if ((eflag & Constants.EnchTodam) != 0)
                {
                    if (oPtr.BonusDamage < 0)
                    {
                        chance = 0;
                    }
                    else if (oPtr.BonusDamage > 15)
                    {
                        chance = 1000;
                    }
                    else
                    {
                        chance = GlobalData.EnchantTable[oPtr.BonusDamage];
                    }
                    if (Program.Rng.DieRoll(1000) > chance && (!a || Program.Rng.RandomLessThan(100) < 50))
                    {
                        oPtr.BonusDamage++;
                        res = true;
                        if (oPtr.IsCursed() && !oPtr.Characteristics.PermaCurse && oPtr.BonusDamage >= 0 && Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                            oPtr.IdentifyFlags.Set(Constants.IdentSense);
                            if (oPtr.RandartItemCharacteristics.Cursed)
                            {
                                oPtr.RandartItemCharacteristics.Cursed = false;
                            }
                            if (oPtr.RandartItemCharacteristics.HeavyCurse)
                            {
                                oPtr.RandartItemCharacteristics.HeavyCurse = false;
                            }
                            oPtr.Inscription = "uncursed";
                        }
                    }
                }
                if ((eflag & Constants.EnchToac) != 0)
                {
                    if (oPtr.BonusArmourClass < 0)
                    {
                        chance = 0;
                    }
                    else if (oPtr.BonusArmourClass > 15)
                    {
                        chance = 1000;
                    }
                    else
                    {
                        chance = GlobalData.EnchantTable[oPtr.BonusArmourClass];
                    }
                    if (Program.Rng.DieRoll(1000) > chance && (!a || Program.Rng.RandomLessThan(100) < 50))
                    {
                        oPtr.BonusArmourClass++;
                        res = true;
                        if (oPtr.IsCursed() && !oPtr.Characteristics.PermaCurse && oPtr.BonusArmourClass >= 0 &&
                            Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                            oPtr.IdentifyFlags.Set(Constants.IdentSense);
                            if (oPtr.RandartItemCharacteristics.Cursed)
                            {
                                oPtr.RandartItemCharacteristics.Cursed = false;
                            }
                            if (oPtr.RandartItemCharacteristics.HeavyCurse)
                            {
                                oPtr.RandartItemCharacteristics.HeavyCurse = false;
                            }
                            oPtr.Inscription = "uncursed";
                        }
                    }
                }
            }
            if (!res)
            {
                return false;
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            return true;
        }

        public bool EnchantSpell(int numHit, int numDam, int numAc)
        {
            bool okay = false;
            ItemFilter = ItemTesterHookWeapon;
            if (numAc != 0)
            {
                ItemFilter = ItemTesterHookArmour;
            }
            if (!GetItem(out int item, "Enchant which item? ", true, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to enchant.");
                }
                return false;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            string oName = oPtr.Description(false, 0);
            string your = item >= 0 ? "Your" : "The";
            string s = oPtr.Count > 1 ? "" : "s";
            MsgPrint($"{your} {oName} glow{s} brightly!");
            if (Enchant(oPtr, numHit, Constants.EnchTohit))
            {
                okay = true;
            }
            if (Enchant(oPtr, numDam, Constants.EnchTodam))
            {
                okay = true;
            }
            if (Enchant(oPtr, numAc, Constants.EnchToac))
            {
                okay = true;
            }
            if (!okay)
            {
                MsgPrint("The enchantment failed.");
            }
            return true;
        }

        public bool FearMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectTurnAll(this), dir, plev, flg);
        }

        public bool FireBall(Projectile projectile, int dir, int dam, int rad)
        {
            TargetEngine targetEngine = new TargetEngine(this);
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            int tx = Player.MapX + (99 * Level.KeypadDirectionXOffset[dir]);
            int ty = Player.MapY + (99 * Level.KeypadDirectionYOffset[dir]);
            if (dir == 5 && targetEngine.TargetOkay())
            {
                flg &= ~ProjectionFlag.ProjectStop;
                tx = TargetCol;
                ty = TargetRow;
            }
            return Project(0, rad, ty, tx, dam, projectile, flg);
        }

        public void FireBeam(Projectile projectile, int dir, int dam)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectKill;
            TargetedProject(projectile, dir, dam, flg);
        }

        public void FireBolt(Projectile projectile, int dir, int dam)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(projectile, dir, dam, flg);
        }

        public void FireBoltOrBeam(int prob, Projectile projectile, int dir, int dam)
        {
            if (Program.Rng.RandomLessThan(100) < prob)
            {
                FireBeam(projectile, dir, dam);
            }
            else
            {
                FireBolt(projectile, dir, dam);
            }
        }

        public void FireDam(int dam, string kbStr)
        {
            int inv = dam < 30 ? 1 : dam < 60 ? 2 : 3;
            if (Player.HasFireImmunity || dam <= 0)
            {
                return;
            }
            if (Player.HasElementalVulnerability)
            {
                dam *= 2;
            }
            if (Player.HasFireResistance)
            {
                dam = (dam + 2) / 3;
            }
            if (Player.TimedFireResistance != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedFireResistance != 0 || Player.HasFireResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Strength);
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.HasFireResistance && Player.TimedFireResistance != 0))
            {
                Player.Inventory.InvenDamage(SetFireDestroy, inv);
            }
        }

        public bool HasteMonsters()
        {
            return ProjectAtAllInLos(new ProjectOldSpeed(this), Player.Level);
        }

        public bool HealMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldHeal(this), dir, Program.Rng.DiceRoll(4, 6), flg);
        }

        public bool IdentifyFully()
        {
            if (!GetItem(out int item, "Identify which item? ", true, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to identify.");
                }
                return false;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            oPtr.BecomeFlavourAware();
            oPtr.BecomeKnown();
            oPtr.IdentifyFlags.Set(Constants.IdentMental);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            HandleStuff();
            string oName = oPtr.Description(true, 3);
            if (item >= InventorySlot.MeleeWeapon)
            {
                MsgPrint($"{Player.DescribeWieldLocation(item)}: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    string itemName = oPtr.Description(true, 3);
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else if (item >= 0)
            {
                MsgPrint($"In your pack: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else
            {
                MsgPrint($"On the ground: {oName}.");
            }
            oPtr.IdentifyFully();
            return true;
        }

        public bool IdentifyItem()
        {
            if (!GetItem(out int item, "Identify which item? ", true, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to identify.");
                }
                return false;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            oPtr.BecomeFlavourAware();
            oPtr.BecomeKnown();
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            string oName = oPtr.Description(true, 3);
            if (item >= InventorySlot.MeleeWeapon)
            {
                MsgPrint($"{Player.DescribeWieldLocation(item)}: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else if (item >= 0)
            {
                MsgPrint($"In your pack: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else
            {
                MsgPrint($"On the ground: {oName}.");
            }
            return true;
        }

        public void IdentifyPack()
        {
            for (int i = 0; i < InventorySlot.Total; i++)
            {
                Item oPtr = Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                oPtr.BecomeFlavourAware();
                oPtr.BecomeKnown();
                if (oPtr.Stompable())
                {
                    string itemName = oPtr.Description(true, 3);
                    MsgPrint($"You destroy {itemName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(i, -amount);
                    Player.Inventory.InvenItemOptimize(i);
                    i--;
                }
            }
        }

        public bool ItemTesterHookArmour(Item oPtr)
        {
            switch (oPtr.Category)
            {
                case ItemCategory.DragArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.SoftArmor:
                case ItemCategory.Shield:
                case ItemCategory.Cloak:
                case ItemCategory.Crown:
                case ItemCategory.Helm:
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                    {
                        return true;
                    }
            }
            return false;
        }

        public bool ItemTesterHookRecharge(Item oPtr)
        {
            if (oPtr.Category == ItemCategory.Staff)
            {
                return true;
            }
            if (oPtr.Category == ItemCategory.Wand)
            {
                return true;
            }
            if (oPtr.Category == ItemCategory.Rod)
            {
                return true;
            }
            return false;
        }

        public bool LightArea(int dam, int rad)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;
            if (Player.TimedBlindness == 0)
            {
                MsgPrint("You are surrounded by a white light.");
            }
            Project(0, rad, Player.MapY, Player.MapX, dam, new ProjectLightWeak(this), flg);
            LightRoom(Player.MapY, Player.MapX);
            return true;
        }

        public void LightLine(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectLightWeak(this), dir, Program.Rng.DiceRoll(6, 8), flg);
        }

        public bool LoseAllInfo()
        {
            for (int i = 0; i < InventorySlot.Total; i++)
            {
                Item oPtr = Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.IdentifyFlags.IsSet(Constants.IdentMental))
                {
                    continue;
                }
                if (string.IsNullOrEmpty(oPtr.Inscription) == false && oPtr.IdentifyFlags.IsSet(Constants.IdentSense))
                {
                    string q = oPtr.Inscription;
                    if (q == "cursed" || q == "broken" || q == "good" || q == "average" || q == "excellent" ||
                        q == "worthless" || q == "special" || q == "terrible")
                    {
                        oPtr.Inscription = string.Empty;
                    }
                }
                oPtr.IdentifyFlags.Clear(Constants.IdentEmpty);
                oPtr.IdentifyFlags.Clear(Constants.IdentKnown);
                oPtr.IdentifyFlags.Clear(Constants.IdentSense);
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            Level.WizDark();
            return true;
        }

        public void MassCarnage(bool playerCast)
        {
            int msec = GlobalData.DelayFactor * GlobalData.DelayFactor * GlobalData.DelayFactor;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    continue;
                }
                if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
                {
                    continue;
                }
                if (mPtr.DistanceFromPlayer > Constants.MaxSight)
                {
                    continue;
                }
                Level.Monsters.DeleteMonsterByIndex(i, true);
                if (playerCast)
                {
                    Player.TakeHit(Program.Rng.DieRoll(3), "the strain of casting Mass Carnage");
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                Player.RedrawNeeded.Set(RedrawFlag.PrHp);
                HandleStuff();
                UpdateScreen();
                Pause(msec);
            }
        }

        public void MindblastMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectPsi(this), dam);
        }

        public bool PolyMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldPoly(this), dir, Player.Level, flg);
        }

        public int PolymorphMonster(MonsterRace rPtr)
        {
            int index = rPtr.Index;
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0 || (rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                return rPtr.Index;
            }
            int lev1 = rPtr.Level - ((Program.Rng.DieRoll(20) / Program.Rng.DieRoll(9)) + 1);
            int lev2 = rPtr.Level + (Program.Rng.DieRoll(20) / Program.Rng.DieRoll(9)) + 1;
            for (int i = 0; i < 1000; i++)
            {
                int r = Level.Monsters.GetMonNum(((Difficulty + rPtr.Level) / 2) + 5);
                if (r == 0)
                {
                    break;
                }
                rPtr = MonsterRaces[r];
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    continue;
                }
                if (rPtr.Level < lev1 || rPtr.Level > lev2)
                {
                    continue;
                }
                index = r;
                break;
            }
            return index;
        }

        public void Probing()
        {
            bool probe = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (!Level.PlayerHasLosBold(mPtr.MapY, mPtr.MapX))
                {
                    continue;
                }
                if (mPtr.IsVisible)
                {
                    if (!probe)
                    {
                        MsgPrint("Probing...");
                    }
                    string mName = mPtr.MonsterDesc(0x04);
                    MsgPrint($"{mName} has {mPtr.Health} hit points.");
                    Level.Monsters.LoreDoProbe(i);
                    probe = true;
                }
            }
            if (probe)
            {
                MsgPrint("That's all.");
            }
        }

        /// <summary>
        /// Returns true, if the projectile actally hits and affects a monster.
        /// </summary>
        /// <param name="who"></param>
        /// <param name="rad"></param>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="dam"></param>
        /// <param name="projectile"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        public bool Project(int who, int rad, int y, int x, int dam, Projectile projectile, ProjectionFlag flg)
        {
            return projectile.Fire(who, rad, y, x, dam, flg);
        }

        public bool Recharge(int num)
        {
            int i, t;
            ItemFilter = ItemTesterHookRecharge;
            if (!GetItem(out int item, "Recharge which item? ", false, true, true))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to recharge.");
                }
                return false;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            int lev = oPtr.BaseItemCategory.Level;
            if (oPtr.Category == ItemCategory.Rod)
            {
                i = (100 - lev + num) / 5;
                if (i < 1)
                {
                    i = 1;
                }
                if (Program.Rng.RandomLessThan(i) == 0)
                {
                    MsgPrint("The recharge backfires, draining the rod further!");
                    if (oPtr.TypeSpecificValue < 10000)
                    {
                        oPtr.TypeSpecificValue = (oPtr.TypeSpecificValue + 100) * 2;
                    }
                }
                else
                {
                    t = num * Program.Rng.DiceRoll(2, 4);
                    if (oPtr.TypeSpecificValue > t)
                    {
                        oPtr.TypeSpecificValue -= t;
                    }
                    else
                    {
                        oPtr.TypeSpecificValue = 0;
                    }
                }
            }
            else
            {
                i = (num + 100 - lev - (10 * oPtr.TypeSpecificValue)) / 15;
                if (i < 1)
                {
                    i = 1;
                }
                if (Program.Rng.RandomLessThan(i) == 0)
                {
                    MsgPrint("There is a bright flash of light.");
                    if (item >= 0)
                    {
                        Player.Inventory.InvenItemIncrease(item, -999);
                        Player.Inventory.InvenItemDescribe(item);
                        Player.Inventory.InvenItemOptimize(item);
                    }
                    else
                    {
                        Level.FloorItemIncrease(0 - item, -999);
                        Level.FloorItemDescribe(0 - item);
                        Level.FloorItemOptimize(0 - item);
                    }
                }
                else
                {
                    t = (num / (lev + 2)) + 1;
                    if (t > 0)
                    {
                        oPtr.TypeSpecificValue += 2 + Program.Rng.DieRoll(t);
                    }
                    oPtr.IdentifyFlags.Clear(Constants.IdentKnown);
                    oPtr.IdentifyFlags.Clear(Constants.IdentEmpty);
                }
            }
            Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            return true;
        }

        public void RemoveAllCurse()
        {
            RemoveCurseAux(true);
        }

        public bool RemoveCurse()
        {
            return RemoveCurseAux(false);
        }

        public void ReportMagics()
        {
            int i = 0, j, k;
            string[] info = new string[128];
            int[] info2 = new int[128];
            if (Player.TimedBlindness != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedBlindness);
                info[i++] = "You cannot see";
            }
            if (Player.TimedConfusion != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedConfusion);
                info[i++] = "You are confused";
            }
            if (Player.TimedFear != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedFear);
                info[i++] = "You are terrified";
            }
            if (Player.TimedPoison != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedPoison);
                info[i++] = "You are poisoned";
            }
            if (Player.TimedHallucinations != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedHallucinations);
                info[i++] = "You are hallucinating";
            }
            if (Player.TimedBlessing != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedBlessing);
                info[i++] = "You feel rightous";
            }
            if (Player.TimedHeroism != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedHeroism);
                info[i++] = "You feel heroic";
            }
            if (Player.TimedSuperheroism != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedSuperheroism);
                info[i++] = "You are in a battle rage";
            }
            if (Player.TimedProtectionFromEvil != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedProtectionFromEvil);
                info[i++] = "You are protected from evil";
            }
            if (Player.TimedStoneskin != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedStoneskin);
                info[i++] = "You are protected by a mystic shield";
            }
            if (Player.TimedInvulnerability != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedInvulnerability);
                info[i++] = "You are invulnerable";
            }
            if (Player.TimedEtherealness != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedEtherealness);
                info[i++] = "You are incorporeal";
            }
            if (Player.HasConfusingTouch)
            {
                info2[i] = 7;
                info[i++] = "Your hands are glowing dull red.";
            }
            if (Player.WordOfRecallDelay != 0)
            {
                info2[i] = ReportMagicsAux(Player.WordOfRecallDelay);
                info[i++] = "You waiting to be recalled";
            }
            if (Player.TimedAcidResistance != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedAcidResistance);
                info[i++] = "You are resistant to acid";
            }
            if (Player.TimedLightningResistance != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedLightningResistance);
                info[i++] = "You are resistant to lightning";
            }
            if (Player.TimedFireResistance != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedFireResistance);
                info[i++] = "You are resistant to fire";
            }
            if (Player.TimedColdResistance != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedColdResistance);
                info[i++] = "You are resistant to cold";
            }
            if (Player.TimedPoisonResistance != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedPoisonResistance);
                info[i++] = "You are resistant to poison";
            }
            SaveScreen();
            for (k = 1; k < 24; k++)
            {
                PrintLine("", k, 13);
            }
            PrintLine("     Your Current Magic:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                string dummy = $"{info[j]} {GlobalData.ReportMagicDurations[info2[j]]}.";
                PrintLine(dummy, k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    PrintLine("-- more --", k, 15);
                    Inkey();
                    for (; k > 2; k--)
                    {
                        PrintLine("", k, 15);
                    }
                }
            }
            PrintLine("[Press any key to continue]", k, 13);
            Inkey();
            Load();
        }

        public void SelfKnowledge()
        {
            int i = 0, j, k;
            Item oPtr;
            string[] info = new string[128];
            int plev = Player.Level;
            string dummy = "";
            ItemCharacteristics inventoryCharacteristics = new ItemCharacteristics();
            for (k = InventorySlot.MeleeWeapon; k < InventorySlot.Total; k++)
            {
                oPtr = Player.Inventory[k];
                if (oPtr.BaseItemCategory != null)
                {
                    continue;
                }
                oPtr.RefreshFlagBasedProperties();
                inventoryCharacteristics.Merge(oPtr.Characteristics);
            }
            switch (Player.RaceIndex)
            {
                case RaceId.Nibelung:
                case RaceId.Dwarf:
                    {
                        if (plev > 4)
                        {
                            info[i++] = "You can find traps, doors and stairs (cost 5).";
                        }
                    }
                    break;

                case RaceId.Hobbit:
                    {
                        if (plev > 14)
                        {
                            info[i++] = "You can produce food (cost 10).";
                        }
                    }
                    break;

                case RaceId.Gnome:
                    {
                        if (plev > 4)
                        {
                            dummy = $"You can teleport, range {1 + plev} (cost {5 + (plev / 5)}).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.HalfOrc:
                    {
                        if (plev > 2)
                        {
                            info[i++] = "You can remove fear (cost 5).";
                        }
                    }
                    break;

                case RaceId.HalfTroll:
                    {
                        if (plev > 9)
                        {
                            info[i++] = "You enter berserk fury (cost 12).";
                        }
                    }
                    break;

                case RaceId.Great:
                    {
                        if (plev > 29)
                        {
                            info[i++] = "You can dream travel (cost 50).";
                        }
                        if (plev > 39)
                        {
                            info[i++] = "You can dream a better self (cost 75).";
                        }
                    }
                    break;

                case RaceId.TchoTcho:
                    {
                        if (plev > 7)
                        {
                            info[i++] = "You can enter berserk fury (cost 10).";
                        }
                    }
                    break;

                case RaceId.HalfOgre:
                    {
                        if (plev > 24)
                        {
                            info[i++] = "You can set an Yellow Sign (cost 35).";
                        }
                    }
                    break;

                case RaceId.HalfGiant:
                    {
                        if (plev > 19)
                        {
                            info[i++] = "You can break stone walls (cost 10).";
                        }
                    }
                    break;

                case RaceId.HalfTitan:
                    {
                        if (plev > 34)
                        {
                            info[i++] = "You can probe monsters (cost 20).";
                        }
                    }
                    break;

                case RaceId.Cyclops:
                    {
                        if (plev > 19)
                        {
                            dummy = $"You can throw a boulder, dam. {3 * plev} (cost 15).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.Yeek:
                    {
                        if (plev > 14)
                        {
                            info[i++] = "You can make a terrifying scream (cost 15).";
                        }
                    }
                    break;

                case RaceId.Klackon:
                    {
                        if (plev > 8)
                        {
                            dummy = $"You can spit acid, dam. {plev} (cost 9).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.Kobold:
                    {
                        if (plev > 11)
                        {
                            dummy = $"You can throw a dart of poison, dam. {plev} (cost 8).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.DarkElf:
                    {
                        if (plev > 1)
                        {
                            dummy = $"You can cast a Magic Missile, dam {3 + ((plev - 1) / 5)} (cost 2).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.Draconian:
                    {
                        dummy = $"You can breathe, dam. {2 * plev} (cost {plev}).";
                        info[i++] = dummy;
                    }
                    break;

                case RaceId.MindFlayer:
                    {
                        if (plev > 14)
                        {
                            dummy = $"You can mind blast your enemies, dam {plev} (cost 12).";
                        }
                        info[i++] = dummy;
                    }
                    break;

                case RaceId.Imp:
                    {
                        if (plev > 29)
                        {
                            dummy = $"You can cast a Fire Ball, dam. {plev} (cost 15).";
                            info[i++] = dummy;
                        }
                        else if (plev > 8)
                        {
                            dummy = $"You can cast a Fire Bolt, dam. {plev} (cost 15).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.Golem:
                    {
                        if (plev > 19)
                        {
                            info[i++] = "You can turn your skin to stone, dur d20+30 (cost 15).";
                        }
                    }
                    break;

                case RaceId.Zombie:
                case RaceId.Skeleton:
                    {
                        if (plev > 29)
                        {
                            info[i++] = "You can restore lost life forces (cost 30).";
                        }
                    }
                    break;

                case RaceId.Vampire:
                    {
                        if (plev > 1)
                        {
                            dummy =
                                $"You can steal life from a foe, dam. {plev + Math.Max(1, plev / 10)}-{plev + (plev * Math.Max(1, plev / 10))} (cost {1 + (plev / 3)}).";
                            info[i++] = dummy;
                        }
                    }
                    break;

                case RaceId.Spectre:
                    {
                        if (plev > 3)
                        {
                            info[i++] = "You can wail to terrify your enemies (cost 3).";
                        }
                    }
                    break;

                case RaceId.Sprite:
                    {
                        if (plev > 11)
                        {
                            info[i++] = "You can throw magic dust which induces sleep (cost 12).";
                        }
                    }
                    break;
            }
            string[] mutations = Player.Dna.GetMutationList();
            if (mutations.Length > 0)
            {
                foreach (string m in mutations)
                {
                    info[i++] = m;
                }
            }
            if (Player.TimedBlindness != 0)
            {
                info[i++] = "You cannot see.";
            }
            if (Player.TimedConfusion != 0)
            {
                info[i++] = "You are confused.";
            }
            if (Player.TimedFear != 0)
            {
                info[i++] = "You are terrified.";
            }
            if (Player.TimedBleeding != 0)
            {
                info[i++] = "You are bleeding.";
            }
            if (Player.TimedStun != 0)
            {
                info[i++] = "You are stunned.";
            }
            if (Player.TimedPoison != 0)
            {
                info[i++] = "You are poisoned.";
            }
            if (Player.TimedHallucinations != 0)
            {
                info[i++] = "You are hallucinating.";
            }
            if (Player.HasAggravation)
            {
                info[i++] = "You aggravate monsters.";
            }
            if (Player.HasRandomTeleport)
            {
                info[i++] = "Your position is very uncertain.";
            }
            if (Player.TimedBlessing != 0)
            {
                info[i++] = "You feel rightous.";
            }
            if (Player.TimedHeroism != 0)
            {
                info[i++] = "You feel heroic.";
            }
            if (Player.TimedSuperheroism != 0)
            {
                info[i++] = "You are in a battle rage.";
            }
            if (Player.TimedProtectionFromEvil != 0)
            {
                info[i++] = "You are protected from evil.";
            }
            if (Player.TimedStoneskin != 0)
            {
                info[i++] = "You are protected by a mystic shield.";
            }
            if (Player.TimedInvulnerability != 0)
            {
                info[i++] = "You are temporarily invulnerable.";
            }
            if (Player.TimedEtherealness != 0)
            {
                info[i++] = "You are temporarily incorporeal.";
            }
            if (Player.HasConfusingTouch)
            {
                info[i++] = "Your hands are glowing dull red.";
            }
            if (Player.IsSearching)
            {
                info[i++] = "You are looking around very carefully.";
            }
            if (Player.SpareSpellSlots != 0)
            {
                info[i++] = "You can learn some spells/prayers.";
            }
            if (Player.WordOfRecallDelay != 0)
            {
                info[i++] = "You will soon be recalled.";
            }
            if (Player.InfravisionRange != 0)
            {
                info[i++] = "Your eyes are sensitive to infrared light.";
            }
            if (Player.HasSeeInvisibility)
            {
                info[i++] = "You can see invisible creatures.";
            }
            if (Player.HasFeatherFall)
            {
                info[i++] = "You can fly.";
            }
            if (Player.HasFreeAction)
            {
                info[i++] = "You have free action.";
            }
            if (Player.HasRegeneration)
            {
                info[i++] = "You regenerate quickly.";
            }
            if (Player.HasSlowDigestion)
            {
                info[i++] = "Your appetite is small.";
            }
            if (Player.HasTelepathy)
            {
                info[i++] = "You have ESP.";
            }
            if (Player.HasHoldLife)
            {
                info[i++] = "You have a firm hold on your life force.";
            }
            if (Player.HasReflection)
            {
                info[i++] = "You reflect arrows and bolts.";
            }
            if (Player.HasFireShield)
            {
                info[i++] = "You are surrounded with a fiery aura.";
            }
            if (Player.HasLightningShield)
            {
                info[i++] = "You are surrounded with electricity.";
            }
            if (Player.HasAntiMagic)
            {
                info[i++] = "You are surrounded by an anti-magic shell.";
            }
            if (Player.HasAntiTeleport)
            {
                info[i++] = "You cannot teleport.";
            }
            if (Player.HasGlow)
            {
                info[i++] = "You are carrying a permanent light.";
            }
            if (Player.HasAcidImmunity)
            {
                info[i++] = "You are completely immune to acid.";
            }
            else if (Player.HasAcidResistance && Player.TimedAcidResistance != 0)
            {
                info[i++] = "You resist acid exceptionally well.";
            }
            else if (Player.HasAcidResistance || Player.TimedAcidResistance != 0)
            {
                info[i++] = "You are resistant to acid.";
            }
            if (Player.HasLightningImmunity)
            {
                info[i++] = "You are completely immune to lightning.";
            }
            else if (Player.HasLightningResistance && Player.TimedLightningResistance != 0)
            {
                info[i++] = "You resist lightning exceptionally well.";
            }
            else if (Player.HasLightningResistance || Player.TimedLightningResistance != 0)
            {
                info[i++] = "You are resistant to lightning.";
            }
            if (Player.HasFireImmunity)
            {
                info[i++] = "You are completely immune to fire.";
            }
            else if (Player.HasFireResistance && Player.TimedFireResistance != 0)
            {
                info[i++] = "You resist fire exceptionally well.";
            }
            else if (Player.HasFireResistance || Player.TimedFireResistance != 0)
            {
                info[i++] = "You are resistant to fire.";
            }
            if (Player.HasColdImmunity)
            {
                info[i++] = "You are completely immune to cold.";
            }
            else if (Player.HasColdResistance && Player.TimedColdResistance != 0)
            {
                info[i++] = "You resist cold exceptionally well.";
            }
            else if (Player.HasColdResistance || Player.TimedColdResistance != 0)
            {
                info[i++] = "You are resistant to cold.";
            }
            if (Player.HasPoisonResistance && Player.TimedPoisonResistance != 0)
            {
                info[i++] = "You resist poison exceptionally well.";
            }
            else if (Player.HasPoisonResistance || Player.TimedPoisonResistance != 0)
            {
                info[i++] = "You are resistant to poison.";
            }
            if (Player.HasLightResistance)
            {
                info[i++] = "You are resistant to bright light.";
            }
            if (Player.HasDarkResistance)
            {
                info[i++] = "You are resistant to darkness.";
            }
            if (Player.HasConfusionResistance)
            {
                info[i++] = "You are resistant to confusion.";
            }
            if (Player.HasSoundResistance)
            {
                info[i++] = "You are resistant to sonic attacks.";
            }
            if (Player.HasDisenchantResistance)
            {
                info[i++] = "You are resistant to disenchantment.";
            }
            if (Player.HasChaosResistance)
            {
                info[i++] = "You are resistant to chaos.";
            }
            if (Player.HasShardResistance)
            {
                info[i++] = "You are resistant to blasts of shards.";
            }
            if (Player.HasNexusResistance)
            {
                info[i++] = "You are resistant to nexus attacks.";
            }
            if (Player.HasNetherResistance)
            {
                info[i++] = "You are resistant to nether forces.";
            }
            if (Player.HasFearResistance)
            {
                info[i++] = "You are completely fearless.";
            }
            if (Player.HasBlindnessResistance)
            {
                info[i++] = "Your eyes are resistant to blindness.";
            }
            if (Player.HasSustainStrength)
            {
                info[i++] = "Your strength is sustained.";
            }
            if (Player.HasSustainIntelligence)
            {
                info[i++] = "Your intelligence is sustained.";
            }
            if (Player.HasSustainWisdom)
            {
                info[i++] = "Your wisdom is sustained.";
            }
            if (Player.HasSustainConstitution)
            {
                info[i++] = "Your constitution is sustained.";
            }
            if (Player.HasSustainDexterity)
            {
                info[i++] = "Your dexterity is sustained.";
            }
            if (Player.HasSustainCharisma)
            {
                info[i++] = "Your charisma is sustained.";
            }
            if (inventoryCharacteristics.Str)
            {
                info[i++] = "Your strength is affected by your equipment.";
            }
            if (inventoryCharacteristics.Int)
            {
                info[i++] = "Your intelligence is affected by your equipment.";
            }
            if (inventoryCharacteristics.Wis)
            {
                info[i++] = "Your wisdom is affected by your equipment.";
            }
            if (inventoryCharacteristics.Dex)
            {
                info[i++] = "Your dexterity is affected by your equipment.";
            }
            if (inventoryCharacteristics.Con)
            {
                info[i++] = "Your constitution is affected by your equipment.";
            }
            if (inventoryCharacteristics.Cha)
            {
                info[i++] = "Your charisma is affected by your equipment.";
            }
            if (inventoryCharacteristics.Stealth)
            {
                info[i++] = "Your stealth is affected by your equipment.";
            }
            if (inventoryCharacteristics.Search)
            {
                info[i++] = "Your searching ability is affected by your equipment.";
            }
            if (inventoryCharacteristics.Infra)
            {
                info[i++] = "Your infravision is affected by your equipment.";
            }
            if (inventoryCharacteristics.Tunnel)
            {
                info[i++] = "Your digging ability is affected by your equipment.";
            }
            if (inventoryCharacteristics.Speed)
            {
                info[i++] = "Your speed is affected by your equipment.";
            }
            if (inventoryCharacteristics.Blows)
            {
                info[i++] = "Your attack speed is affected by your equipment.";
            }
            oPtr = Player.Inventory[InventorySlot.MeleeWeapon];
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.BaseItemCategory != null)
            {
                if (oPtr.Characteristics.Blessed)
                {
                    info[i++] = "Your weapon has been blessed by the gods.";
                }
                if (oPtr.Characteristics.Chaotic)
                {
                    info[i++] = "Your weapon is branded with the Yellow Sign.";
                }
                if (oPtr.Characteristics.Impact)
                {
                    info[i++] = "The impact of your weapon can cause earthquakes.";
                }
                if (oPtr.Characteristics.Vorpal)
                {
                    info[i++] = "Your weapon is very sharp.";
                }
                if (oPtr.Characteristics.Vampiric)
                {
                    info[i++] = "Your weapon drains life from your foes.";
                }
                if (oPtr.Characteristics.BrandAcid)
                {
                    info[i++] = "Your weapon melts your foes.";
                }
                if (oPtr.Characteristics.BrandElec)
                {
                    info[i++] = "Your weapon shocks your foes.";
                }
                if (oPtr.Characteristics.BrandFire)
                {
                    info[i++] = "Your weapon burns your foes.";
                }
                if (oPtr.Characteristics.BrandCold)
                {
                    info[i++] = "Your weapon freezes your foes.";
                }
                if (oPtr.Characteristics.BrandPois)
                {
                    info[i++] = "Your weapon poisons your foes.";
                }
                if (oPtr.Characteristics.SlayAnimal)
                {
                    info[i++] = "Your weapon strikes at animals with extra force.";
                }
                if (oPtr.Characteristics.SlayEvil)
                {
                    info[i++] = "Your weapon strikes at evil with extra force.";
                }
                if (oPtr.Characteristics.SlayUndead)
                {
                    info[i++] = "Your weapon strikes at undead with holy wrath.";
                }
                if (oPtr.Characteristics.SlayDemon)
                {
                    info[i++] = "Your weapon strikes at demons with holy wrath.";
                }
                if (oPtr.Characteristics.SlayOrc)
                {
                    info[i++] = "Your weapon is especially deadly against orcs.";
                }
                if (oPtr.Characteristics.SlayTroll)
                {
                    info[i++] = "Your weapon is especially deadly against trolls.";
                }
                if (oPtr.Characteristics.SlayGiant)
                {
                    info[i++] = "Your weapon is especially deadly against giants.";
                }
                if (oPtr.Characteristics.SlayDragon)
                {
                    info[i++] = "Your weapon is especially deadly against dragons.";
                }
                if (oPtr.Characteristics.KillDragon)
                {
                    info[i++] = "Your weapon is a great bane of dragons.";
                }
            }
            SaveScreen();
            for (k = 1; k < 24; k++)
            {
                PrintLine("", k, 13);
            }
            PrintLine("     Your Attributes:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                PrintLine(info[j], k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    PrintLine("-- more --", k, 15);
                    Inkey();
                    for (; k > 2; k--)
                    {
                        PrintLine("", k, 15);
                    }
                }
            }
            PrintLine("[Press any key to continue]", k, 13);
            Inkey();
            Load();
        }

        public bool SetAcidDestroy(Item oPtr)
        {
            if (!oPtr.HatesAcid())
            {
                return false;
            }
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Characteristics.IgnoreAcid)
            {
                return false;
            }
            return true;
        }

        public bool SetColdDestroy(Item oPtr)
        {
            if (!oPtr.HatesCold())
            {
                return false;
            }
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Characteristics.IgnoreCold)
            {
                return false;
            }
            return true;
        }

        public bool SetElecDestroy(Item oPtr)
        {
            if (!oPtr.HatesElec())
            {
                return false;
            }
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Characteristics.IgnoreElec)
            {
                return false;
            }
            return true;
        }

        public bool SetFireDestroy(Item oPtr)
        {
            if (!oPtr.HatesFire())
            {
                return false;
            }
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Characteristics.IgnoreFire)
            {
                return false;
            }
            return true;
        }

        public bool SleepMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldSleep(this), dir, Player.Level, flg);
        }

        public bool SleepMonsters()
        {
            return ProjectAtAllInLos(new ProjectOldSleep(this), Player.Level);
        }

        public void SleepMonstersTouch()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectKill | ProjectionFlag.ProjectHide;
            Project(0, 1, Player.MapY, Player.MapX, Player.Level, new ProjectOldSleep(this), flg);
        }

        public bool SlowMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldSlow(this), dir, Player.Level, flg);
        }

        public bool SlowMonsters()
        {
            return ProjectAtAllInLos(new ProjectOldSlow(this), Player.Level);
        }

        public bool SpeedMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldSpeed(this), dir, Player.Level, flg);
        }

        public void StairCreation()
        {
            if (!Level.CaveValidBold(Player.MapY, Player.MapX))
            {
                MsgPrint("The object resists the spell.");
                return;
            }
            Level.DeleteObject(Player.MapY, Player.MapX);
            if (CurrentDepth <= 0)
            {
                Level.CaveSetFeat(Player.MapY, Player.MapX, "DownStair");
            }
            else if (Quests.IsQuest(CurrentDepth) ||
                     CurrentDepth >= CurDungeon.MaxLevel)
            {
                Level.CaveSetFeat(Player.MapY, Player.MapX,
                    CurDungeon.Tower ? "DownStair" : "UpStair");
            }
            else if (Program.Rng.RandomLessThan(100) < 50)
            {
                Level.CaveSetFeat(Player.MapY, Player.MapX, "DownStair");
            }
            else
            {
                Level.CaveSetFeat(Player.MapY, Player.MapX, "UpStair");
            }
        }

        public void StasisMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectStasis(this), dir, Player.Level, flg);
        }

        public void StasisMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectStasis(this), dam);
        }

        public void StunMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectStun(this), dir, plev, flg);
        }

        public void StunMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectStun(this), dam);
        }

        public void SummonReaver()
        {
            int i;
            int maxReaver = (Difficulty / 50) + Program.Rng.DieRoll(6);
            for (i = 0; i < maxReaver; i++)
            {
                Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, 100, Constants.SummonReaver);
            }
        }

        public bool TeleportMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectAwayAll(this), dir, Constants.MaxSight * 5, flg);
        }

        public void TeleportPlayer(int dis)
        {
            int x = Player.MapY, y = Player.MapX;
            int xx = -1;
            bool look = true;
            if (Player.HasAntiTeleport)
            {
                MsgPrint("A mysterious force prevents you from teleporting!");
                return;
            }
            if (dis > 200)
            {
                dis = 200;
            }
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
                        y = Program.Rng.RandomSpread(Player.MapY, dis);
                        x = Program.Rng.RandomSpread(Player.MapX, dis);
                        int d = Level.Distance(Player.MapY, Player.MapX, y, x);
                        if (d >= min && d <= dis)
                        {
                            break;
                        }
                    }
                    if (!Level.InBounds(y, x))
                    {
                        continue;
                    }
                    if (!Level.GridOpenNoItemOrCreature(y, x))
                    {
                        continue;
                    }
                    if (Level.Grid[y][x].TileFlags.IsSet(GridTile.InVault))
                    {
                        continue;
                    }
                    look = false;
                    break;
                }
                dis *= 2;
                min /= 2;
            }
            PlaySound(SoundEffect.Teleport);
            int oy = Player.MapY;
            int ox = Player.MapX;
            Player.MapY = y;
            Player.MapX = x;
            Level.RedrawSingleLocation(oy, ox);
            while (xx < 2)
            {
                int yy = -1;
                while (yy < 2)
                {
                    if (xx == 0 && yy == 0)
                    {
                    }
                    else
                    {
                        if (Level.Grid[oy + yy][ox + xx].MonsterIndex != 0)
                        {
                            if ((Level.Monsters[Level.Grid[oy + yy][ox + xx].MonsterIndex].Race.Flags6 &
                                 MonsterFlag6.TeleportSelf) != 0 &&
                                (Level.Monsters[Level.Grid[oy + yy][ox + xx].MonsterIndex].Race.Flags3 &
                                 MonsterFlag3.ResistTeleport) == 0)
                            {
                                if (Level.Monsters[Level.Grid[oy + yy][ox + xx].MonsterIndex].SleepLevel == 0)
                                {
                                    TeleportToPlayer(Level.Grid[oy + yy][ox + xx].MonsterIndex);
                                }
                            }
                        }
                    }
                    yy++;
                }
                xx++;
            }
            Level.RedrawSingleLocation(Player.MapY, Player.MapX);
            TargetEngine targetEngine = new TargetEngine(this);
            targetEngine.RecenterScreenAroundPlayer();
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            HandleStuff();
        }

        public void TeleportPlayerLevel()
        {
            if (Player.HasAntiTeleport)
            {
                MsgPrint("A mysterious force prevents you from teleporting!");
                return;
            }
            var downDesc = CurDungeon.Tower ? "You rise up through the ceiling." : "You sink through the floor.";
            var upDesc = CurDungeon.Tower ? "You sink through the floor." : "You rise up through the ceiling.";
            if (CurrentDepth <= 0)
            {
                MsgPrint(downDesc);
                DoCmdSaveGame(true);
                CurrentDepth++;
                NewLevelFlag = true;
            }
            else if (Quests.IsQuest(CurrentDepth) ||
                     CurrentDepth >= CurDungeon.MaxLevel)
            {
                MsgPrint(upDesc);
                DoCmdSaveGame(true);
                CurrentDepth--;
                NewLevelFlag = true;
            }
            else if (Program.Rng.RandomLessThan(100) < 50)
            {
                MsgPrint(upDesc);
                DoCmdSaveGame(true);
                CurrentDepth--;
                NewLevelFlag = true;
                CameFrom = LevelStart.StartRandom;
            }
            else
            {
                MsgPrint(downDesc);
                DoCmdSaveGame(true);
                CurrentDepth++;
                NewLevelFlag = true;
            }
            DoCmdSaveGame(true);
            CurrentDepth++;
            NewLevelFlag = true;
            PlaySound(SoundEffect.TeleportLevel);
        }

        public void TeleportPlayerTo(int ny, int nx)
        {
            int y, x, dis = 0, ctr = 0;
            if (Player.HasAntiTeleport)
            {
                MsgPrint("A mysterious force prevents you from teleporting!");
                return;
            }
            while (true)
            {
                while (true)
                {
                    y = Program.Rng.RandomSpread(ny, dis);
                    x = Program.Rng.RandomSpread(nx, dis);
                    if (Level.InBounds(y, x))
                    {
                        break;
                    }
                }
                if (Level.GridOpenNoItemOrCreature(y, x))
                {
                    break;
                }
                if (++ctr > (4 * dis * dis) + (4 * dis) + 1)
                {
                    ctr = 0;
                    dis++;
                }
            }
            PlaySound(SoundEffect.Teleport);
            int oy = Player.MapY;
            int ox = Player.MapX;
            Player.MapY = y;
            Player.MapX = x;
            Level.RedrawSingleLocation(oy, ox);
            Level.RedrawSingleLocation(Player.MapY, Player.MapX);
            TargetEngine targetEngine = new TargetEngine(this);
            targetEngine.RecenterScreenAroundPlayer();
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            HandleStuff();
        }

        public void TeleportSwap(int dir)
        {
            TargetEngine targetEngine = new TargetEngine(this);
            int tx, ty;
            if (dir == 5 && targetEngine.TargetOkay())
            {
                tx = TargetCol;
                ty = TargetRow;
            }
            else
            {
                tx = Player.MapX + Level.KeypadDirectionXOffset[dir];
                ty = Player.MapY + Level.KeypadDirectionYOffset[dir];
            }
            GridTile cPtr = Level.Grid[ty][tx];
            if (cPtr.MonsterIndex == 0)
            {
                MsgPrint("You can't trade places with that!");
            }
            else
            {
                Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
                MonsterRace rPtr = mPtr.Race;
                if ((rPtr.Flags3 & MonsterFlag3.ResistTeleport) != 0)
                {
                    MsgPrint("Your teleportation is blocked!");
                }
                else
                {
                    PlaySound(SoundEffect.Teleport);
                    Level.Grid[Player.MapY][Player.MapX].MonsterIndex = cPtr.MonsterIndex;
                    cPtr.MonsterIndex = 0;
                    mPtr.MapY = Player.MapY;
                    mPtr.MapX = Player.MapX;
                    Player.MapX = tx;
                    Player.MapY = ty;
                    tx = mPtr.MapX;
                    ty = mPtr.MapY;
                    Level.Monsters.UpdateMonsterVisibility(Level.Grid[ty][tx].MonsterIndex, true);
                    Level.RedrawSingleLocation(ty, tx);
                    Level.RedrawSingleLocation(Player.MapY, Player.MapX);
                    targetEngine.RecenterScreenAroundPlayer();
                    Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
                    Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
                    HandleStuff();
                }
            }
        }

        public bool TrapCreation()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            return Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectMakeTrap(this), flg);
        }

        public void TurnEvil(int dam)
        {
            ProjectAtAllInLos(new ProjectTurnEvil(this), dam);
        }

        public void TurnMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectTurnAll(this), dam);
        }

        public bool UnlightArea(int dam, int rad)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;
            if (Player.TimedBlindness == 0)
            {
                MsgPrint("Darkness surrounds you.");
            }
            Project(0, rad, Player.MapY, Player.MapX, dam, new ProjectDarkWeak(this), flg);
            UnlightRoom(Player.MapY, Player.MapX);
            return true;
        }

        public void UnlightRoom(int y1, int x1)
        {
            CaveTempRoomAux(y1, x1);
            for (int i = 0; i < Level.TempN; i++)
            {
                int x = Level.TempX[i];
                int y = Level.TempY[i];
                if (!Level.GridPassable(y, x))
                {
                    continue;
                }
                CaveTempRoomAux(y + 1, x);
                CaveTempRoomAux(y - 1, x);
                CaveTempRoomAux(y, x + 1);
                CaveTempRoomAux(y, x - 1);
                CaveTempRoomAux(y + 1, x + 1);
                CaveTempRoomAux(y - 1, x - 1);
                CaveTempRoomAux(y - 1, x + 1);
                CaveTempRoomAux(y + 1, x - 1);
            }
            CaveTempRoomUnlight();
        }

        public void WallBreaker()
        {
            int dummy;
            if (Program.Rng.DieRoll(80 + Player.Level) < 70)
            {
                do
                {
                    dummy = Program.Rng.DieRoll(9);
                } while (dummy == 5 || dummy == 0);
                WallToMud(dummy);
            }
            else if (Program.Rng.DieRoll(100) > 30)
            {
                Earthquake(Player.MapY, Player.MapX, 1);
            }
            else
            {
                for (dummy = 1; dummy < 10; dummy++)
                {
                    if (dummy != 5)
                    {
                        WallToMud(dummy);
                    }
                }
            }
        }

        public void WallStone()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
            _ = Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectStoneWall(this), flg);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
        }

        public bool WallToMud(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectKillWall(this), dir, 20 + Program.Rng.DieRoll(30), flg);
        }

        public void WizardLock(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectJamDoor(this), dir, 20 + Program.Rng.DieRoll(30), flg);
        }

        public void YellowSign()
        {
            if (!Level.GridOpenNoItem(Player.MapY, Player.MapX))
            {
                MsgPrint("The object resists the spell.");
                return;
            }
            Level.CaveSetFeat(Player.MapY, Player.MapX, "YellowSign");
        }

        private void CaveTempRoomAux(int y, int x)
        {
            GridTile cPtr = Level.Grid[y][x];
            if (cPtr.TileFlags.IsSet(GridTile.TempFlag))
            {
                return;
            }
            if (cPtr.TileFlags.IsClear(GridTile.InRoom))
            {
                return;
            }
            if (Level.TempN == Constants.TempMax)
            {
                return;
            }
            cPtr.TileFlags.Set(GridTile.TempFlag);
            Level.TempY[Level.TempN] = y;
            Level.TempX[Level.TempN] = x;
            Level.TempN++;
        }

        private void CaveTempRoomLight()
        {
            for (int i = 0; i < Level.TempN; i++)
            {
                int y = Level.TempY[i];
                int x = Level.TempX[i];
                GridTile cPtr = Level.Grid[y][x];
                cPtr.TileFlags.Clear(GridTile.TempFlag);
                cPtr.TileFlags.Set(GridTile.SelfLit);
                if (cPtr.MonsterIndex != 0)
                {
                    int chance = 25;
                    Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
                    MonsterRace rPtr = mPtr.Race;
                    Level.Monsters.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
                    if ((rPtr.Flags2 & MonsterFlag2.Stupid) != 0)
                    {
                        chance = 10;
                    }
                    if ((rPtr.Flags2 & MonsterFlag2.Smart) != 0)
                    {
                        chance = 100;
                    }
                    if (mPtr.SleepLevel != 0 && Program.Rng.RandomLessThan(100) < chance)
                    {
                        mPtr.SleepLevel = 0;
                        if (mPtr.IsVisible)
                        {
                            string mName = mPtr.MonsterDesc(0);
                            MsgPrint($"{mName} wakes up.");
                        }
                    }
                }
                Level.NoteSpot(y, x);
                Level.RedrawSingleLocation(y, x);
            }
            Level.TempN = 0;
        }

        private void CaveTempRoomUnlight()
        {
            for (int i = 0; i < Level.TempN; i++)
            {
                int y = Level.TempY[i];
                int x = Level.TempX[i];
                GridTile cPtr = Level.Grid[y][x];
                cPtr.TileFlags.Clear(GridTile.TempFlag);
                cPtr.TileFlags.Clear(GridTile.SelfLit);
                if (cPtr.FeatureType.IsOpenFloor)
                {
                    cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                    Level.NoteSpot(y, x);
                }
                if (cPtr.MonsterIndex != 0)
                {
                    Level.Monsters.UpdateMonsterVisibility(cPtr.MonsterIndex, false);
                }
                Level.RedrawSingleLocation(y, x);
            }
            Level.TempN = 0;
        }

        private bool DetectMonstersString(string match)
        {
            bool flag = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                int y = mPtr.MapY;
                int x = mPtr.MapX;
                if (!Level.PanelContains(y, x))
                {
                    continue;
                }
                if (match.Contains(rPtr.Character.ToString()))
                {
                    Level.Monsters.RepairMonsters = true;
                    mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                    mPtr.IsVisible = true;
                    Level.RedrawSingleLocation(y, x);
                    flag = true;
                }
            }
            if (flag)
            {
                MsgPrint("You sense the presence of monsters!");
            }
            return flag;
        }

        private bool ItemTesterHookWeapon(Item oPtr)
        {
            switch (oPtr.Category)
            {
                case ItemCategory.Sword:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Digging:
                case ItemCategory.Bow:
                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Shot:
                    {
                        return true;
                    }
            }
            return false;
        }

        private void LightRoom(int y1, int x1)
        {
            CaveTempRoomAux(y1, x1);
            for (int i = 0; i < Level.TempN; i++)
            {
                int x = Level.TempX[i];
                int y = Level.TempY[i];
                if (!Level.GridPassable(y, x))
                {
                    continue;
                }
                CaveTempRoomAux(y + 1, x);
                CaveTempRoomAux(y - 1, x);
                CaveTempRoomAux(y, x + 1);
                CaveTempRoomAux(y, x - 1);
                CaveTempRoomAux(y + 1, x + 1);
                CaveTempRoomAux(y - 1, x - 1);
                CaveTempRoomAux(y - 1, x + 1);
                CaveTempRoomAux(y + 1, x - 1);
            }
            CaveTempRoomLight();
        }

        private bool MinusAc()
        {
            Item oPtr = null;
            switch (Program.Rng.DieRoll(6))
            {
                case 1:
                    oPtr = Player.Inventory[InventorySlot.Body];
                    break;

                case 2:
                    oPtr = Player.Inventory[InventorySlot.Arm];
                    break;

                case 3:
                    oPtr = Player.Inventory[InventorySlot.Cloak];
                    break;

                case 4:
                    oPtr = Player.Inventory[InventorySlot.Hands];
                    break;

                case 5:
                    oPtr = Player.Inventory[InventorySlot.Head];
                    break;

                case 6:
                    oPtr = Player.Inventory[InventorySlot.Feet];
                    break;
            }
            if (oPtr == null)
            {
                return false;
            }
            if (oPtr.BaseItemCategory == null)
            {
                return false;
            }
            if (oPtr.BaseArmourClass + oPtr.BonusArmourClass <= 0)
            {
                return false;
            }
            string oName = oPtr.Description(false, 0);
            oPtr.RefreshFlagBasedProperties();
            if (oPtr.Characteristics.IgnoreAcid)
            {
                MsgPrint($"Your {oName} is unaffected!");
                return true;
            }
            MsgPrint($"Your {oName} is damaged!");
            oPtr.BonusArmourClass--;
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            return true;
        }

        private bool ProjectAtAllInLos(Projectile projectile, int dam)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectJump | ProjectionFlag.ProjectKill | ProjectionFlag.ProjectHide;
            bool obvious = false;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                if (mPtr.Race == null)
                {
                    continue;
                }
                int y = mPtr.MapY;
                int x = mPtr.MapX;
                if (!Level.PlayerHasLosBold(y, x))
                {
                    continue;
                }
                if (Project(0, 0, y, x, dam, projectile, flg))
                {
                    obvious = true;
                }
            }
            return obvious;
        }

        private bool RemoveCurseAux(bool all)
        {
            int cnt = 0;
            for (int i = InventorySlot.MeleeWeapon; i < InventorySlot.Total; i++)
            {
                Item oPtr = Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (!oPtr.IsCursed())
                {
                    continue;
                }
                oPtr.RefreshFlagBasedProperties();
                if (!all && oPtr.Characteristics.HeavyCurse)
                {
                    continue;
                }
                if (oPtr.Characteristics.PermaCurse)
                {
                    continue;
                }
                oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                oPtr.IdentifyFlags.Set(Constants.IdentSense);
                if (oPtr.RandartItemCharacteristics.Cursed)
                {
                    oPtr.RandartItemCharacteristics.Cursed = false;
                }
                if (oPtr.RandartItemCharacteristics.HeavyCurse)
                {
                    oPtr.RandartItemCharacteristics.HeavyCurse = false;
                }
                oPtr.Inscription = "uncursed";
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                cnt++;
            }
            return cnt > 0;
        }

        private int ReportMagicsAux(int dur)
        {
            if (dur <= 5)
            {
                return 0;
            }
            if (dur <= 10)
            {
                return 1;
            }
            if (dur <= 20)
            {
                return 2;
            }
            if (dur <= 50)
            {
                return 3;
            }
            if (dur <= 100)
            {
                return 4;
            }
            if (dur <= 200)
            {
                return 5;
            }
            return 6;
        }

        /// <summary>
        /// Returns true, if the projectile actually hits and affects a monster.
        /// </summary>
        /// <param name="projectile"></param>
        /// <param name="dir"></param>
        /// <param name="dam"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        private bool TargetedProject(Projectile projectile, int dir, int dam, ProjectionFlag flg)
        {
            TargetEngine targetEngine = new TargetEngine(this);
            flg |= ProjectionFlag.ProjectThru;
            int tx = Player.MapX + Level.KeypadDirectionXOffset[dir];
            int ty = Player.MapY + Level.KeypadDirectionYOffset[dir];
            if (dir == 5 && targetEngine.TargetOkay())
            {
                tx = TargetCol;
                ty = TargetRow;
            }
            return Project(0, 0, ty, tx, dam, projectile, flg);
        }

        private void TeleportToPlayer(int mIdx)
        {
            int ny = Player.MapY;
            int nx = Player.MapX;
            int dis = 2;
            bool look = true;
            Monster mPtr = Level.Monsters[mIdx];
            int attempts = 500;
            if (mPtr.Race == null)
            {
                return;
            }
            if (Program.Rng.DieRoll(100) > mPtr.Race.Level)
            {
                return;
            }
            int oy = mPtr.MapY;
            int ox = mPtr.MapX;
            int min = dis / 2;
            while (look && --attempts != 0)
            {
                if (dis > 200)
                {
                    dis = 200;
                }
                for (int i = 0; i < 500; i++)
                {
                    while (true)
                    {
                        ny = Program.Rng.RandomSpread(Player.MapY, dis);
                        nx = Program.Rng.RandomSpread(Player.MapX, dis);
                        int d = Level.Distance(Player.MapY, Player.MapX, ny, nx);
                        if (d >= min && d <= dis)
                        {
                            break;
                        }
                    }
                    if (!Level.InBounds(ny, nx))
                    {
                        continue;
                    }
                    if (!Level.GridPassableNoCreature(ny, nx))
                    {
                        continue;
                    }
                    if (Level.Grid[ny][nx].FeatureType.Name == "ElderSign")
                    {
                        continue;
                    }
                    if (Level.Grid[ny][nx].FeatureType.Name == "YellowSign")
                    {
                        continue;
                    }
                    look = false;
                    break;
                }
                dis *= 2;
                min /= 2;
            }
            if (attempts < 1)
            {
                return;
            }
            PlaySound(SoundEffect.Teleport);
            Level.Grid[ny][nx].MonsterIndex = mIdx;
            Level.Grid[oy][ox].MonsterIndex = 0;
            mPtr.MapY = ny;
            mPtr.MapX = nx;
            Level.Monsters.UpdateMonsterVisibility(mIdx, true);
            Level.RedrawSingleLocation(oy, ox);
            Level.RedrawSingleLocation(ny, nx);
        }

        // CommandHandler
        /// <summary>
        /// Process the player's latest command
        /// </summary>
        public void ProcessCommand(bool isRepeated)
        {
            // Get the current command
            char c = CurrentCommand;

            // Process commands
            foreach (ICommand command in CommandManager.GameCommands)
            {
                // TODO: The IF statement below can be converted into a dictionary with the applicable object 
                // attached for improved performance.
                if (command.IsEnabled && command.Key == c)
                {
                    command.Execute(this);

                    // Apply the default repeat value.  This handles the 0, for no repeat and default repeat count (TBDocs+ ... count = 99).
                    if (!isRepeated && command.Repeat.HasValue)
                    {
                        // Only apply the default once.
                        CommandArgument = command.Repeat.Value;
                    }

                    if (CommandArgument > 0)
                    {
                        CommandRepeat = CommandArgument - 1;
                        Player.RedrawNeeded.Set(RedrawFlag.PrState);
                        CommandArgument = 0;
                    }

                    // The command was processed.  Skip the SWITCH statement.
                    return;
                }
            }
            PrintLine("Type '?' for a list of commands.", 0, 0);
        }

        // Command Engine

        /// <summary>
        /// Activate a randomly generated artifact that will therefore have been given a random power
        /// </summary>
        /// <param name="item"> The artifact being activated.</param>
        public void ActivateRandomArtifact(Item item)
        {
            // If we don't have a random artifact, abort
            if (string.IsNullOrEmpty(item.RandartName))
            {
                return;
            }
            ActivationPower artifactPower = item.BonusPowerSubType;

            if (!String.IsNullOrEmpty(artifactPower.PreActivationMessage))
            {
                MsgPrint(artifactPower.PreActivationMessage);
            }
            if (artifactPower.Activate(this))
            {
                item.RechargeTimeLeft = artifactPower.RechargeTime(Player);
            }
        }

        public bool BashClosedDoor(int y, int x, int dir)
        {
            bool more = false;
            EnergyUse = 100;
            GridTile cPtr = Level.Grid[y][x];
            MsgPrint("You smash into the door!");
            int bash = Player.AbilityScores[Ability.Strength].StrAttackSpeedComponent;
            int temp = int.Parse(cPtr.FeatureType.Name.Substring(10));
            temp = bash - (temp * 10);
            if (temp < 1)
            {
                temp = 1;
            }
            if (Program.Rng.RandomLessThan(100) < temp)
            {
                MsgPrint("The door crashes open!");
                Level.CaveSetFeat(y, x, Program.Rng.RandomLessThan(100) < 50 ? "BrokenDoor" : "OpenDoor");
                PlaySound(SoundEffect.OpenDoor);
                MovePlayer(dir, false);
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight);
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            }
            else if (Program.Rng.RandomLessThan(100) < Player.AbilityScores[Ability.Dexterity].DexTheftAvoidance + Player.Level)
            {
                MsgPrint("The door holds firm.");
                more = true;
            }
            else
            {
                MsgPrint("You are off-balance.");
                Player.SetTimedParalysis(Player.TimedParalysis + 2 + Program.Rng.RandomLessThan(2));
            }
            return more;
        }

        /// <summary>
        /// Give a fire brand to a set of bolts we're carrying
        /// </summary>
        public void BrandBolts()
        {
            for (int i = 0; i < InventorySlot.Pack; i++)
            {
                // Find a set of non-artifact bolts in our inventory
                Item item = Player.Inventory[i];
                if (item.Category != ItemCategory.Bolt)
                {
                    continue;
                }
                if (!string.IsNullOrEmpty(item.RandartName) || item.IsFixedArtifact() || item.IsRare())
                {
                    continue;
                }
                // Skip cursed or broken bolts
                if (item.IsCursed() || item.IsBroken())
                {
                    continue;
                }
                // Only a 25% chance of success per set of bolts
                if (Program.Rng.RandomLessThan(100) < 75)
                {
                    continue;
                }
                // Make the bolts into bolts of flame
                MsgPrint("Your bolts are covered in a fiery aura!");
                item.RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFlame;
                Enchant(item, Program.Rng.RandomLessThan(3) + 4,
                    Constants.EnchTohit | Constants.EnchTodam);
                // Quit after the first bolts have been upgraded
                return;
            }
            // We fell off the end of the inventory without enchanting anything
            MsgPrint("The fiery enchantment failed.");
        }

        /// <summary>
        /// Give a brand type to our melee weapon
        /// </summary>
        /// <param name="brandType"> The type of brand to give the weapon </param>
        public void BrandWeapon(int brandType)
        {
            Item item = Player.Inventory[InventorySlot.MeleeWeapon];
            // We must have a non-rare, non-artifact weapon that isn't cursed
            if (item.BaseItemCategory != null && !item.IsFixedArtifact() && !item.IsRare() &&
                string.IsNullOrEmpty(item.RandartName) && !item.IsCursed())
            {
                string act;
                string itemName = item.Description(false, 0);
                switch (brandType)
                {
                    case 4:
                        // Make it a planar weapon
                        act = "seems very unstable now.";
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponPlanarWeapon;
                        item.TypeSpecificValue = Program.Rng.DieRoll(2);
                        break;

                    case 3:
                        // Make it a vampiric weapon
                        act = "thirsts for blood!";
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponVampiric;
                        break;

                    case 2:
                        // Make it a poison brand
                        act = "is coated with poison.";
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                        break;

                    case 1:
                        // Make it a chaotic weapon
                        act = "is engulfed in raw chaos!";
                        item.RareItemTypeIndex = Enumerations.RareItemType.WeaponChaotic;
                        break;

                    default:
                        // Make it a fire or ice weapon
                        if (Program.Rng.RandomLessThan(100) < 25)
                        {
                            act = "is covered in a fiery shield!";
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfBurning;
                        }
                        else
                        {
                            act = "glows deep, icy blue!";
                            item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfFreezing;
                        }
                        break;
                }
                // Let the player know what happened
                MsgPrint($"Your {itemName} {act}");
                Enchant(item, Program.Rng.RandomLessThan(3) + 4,
                    Constants.EnchTohit | Constants.EnchTodam);
            }
            else
            {
                MsgPrint("The Branding failed.");
            }
        }

        /// <summary>
        /// Blast energy in all directions
        /// </summary>
        public void CallTheVoid()
        {
            // Make sure we're not next to a wall
            if (Level.GridPassable(Player.MapY - 1, Player.MapX - 1) && Level.GridPassable(Player.MapY - 1, Player.MapX) &&
                Level.GridPassable(Player.MapY - 1, Player.MapX + 1) && Level.GridPassable(Player.MapY, Player.MapX - 1) &&
                Level.GridPassable(Player.MapY, Player.MapX + 1) && Level.GridPassable(Player.MapY + 1, Player.MapX - 1) &&
                Level.GridPassable(Player.MapY + 1, Player.MapX) && Level.GridPassable(Player.MapY + 1, Player.MapX + 1))
            {
                // Fire area effect shards, mana, and nukes in all directions
                int i;
                for (i = 1; i < 10; i++)
                {
                    if (i - 5 != 0)
                    {
                        FireBall(new ProjectShard(this), i, 175, 2);
                    }
                }
                for (i = 1; i < 10; i++)
                {
                    if (i - 5 != 0)
                    {
                        FireBall(new ProjectMana(this), i, 175, 3);
                    }
                }
                for (i = 1; i < 10; i++)
                {
                    if (i - 5 != 0)
                    {
                        FireBall(new ProjectNuke(this), i, 175, 4);
                    }
                }
            }
            else
            {
                // We were too close to a wall, so earthquake instead
                string cast = Player.Spellcasting.Type == CastingType.Divine ? "recite" : "cast";
                string spell = Player.Spellcasting.Type == CastingType.Divine ? "prayer" : "spell";
                MsgPrint($"You {cast} the {spell} too close to a wall!");
                MsgPrint("There is a loud explosion!");
                DestroyArea(Player.MapY, Player.MapX, 20 + Player.Level);
                MsgPrint("The dungeon collapses...");
                Player.TakeHit(100 + Program.Rng.DieRoll(150), "a suicidal Call the Void");
            }
        }

        /// <summary>
        /// Check to see if a racial power works
        /// </summary>
        /// <param name="minLevel"> The minimum level for the power </param>
        /// <param name="cost"> The cost in mana to use the power </param>
        /// <param name="useStat"> The ability score used for the power </param>
        /// <param name="difficulty"> The difficulty of the power to use </param>
        /// <returns> True if the power worked, false if it didn't </returns>
        public bool CheckIfRacialPowerWorks(int minLevel, int cost, int useStat, int difficulty)
        {
            // If we don't have enough mana we'll use health instead
            bool useHealth = Player.Mana < cost;
            // Can't use it if we're too low level
            if (Player.Level < minLevel)
            {
                MsgPrint($"You need to attain level {minLevel} to use this power.");
                EnergyUse = 0;
                return false;
            }
            // Can't use it if we're confused
            if (Player.TimedConfusion != 0)
            {
                MsgPrint("You are too confused to use this power.");
                EnergyUse = 0;
                return false;
            }
            // If we're about to kill ourselves, give us chance to back out
            if (useHealth && Player.Health < cost)
            {
                if (!GetCheck("Really use the power in your weakened state? "))
                {
                    EnergyUse = 0;
                    return false;
                }
            }
            // Harder to use powers when you're stunned
            if (Player.TimedStun != 0)
            {
                difficulty += Player.TimedStun;
            }
            // Easier to use powers if you're higher level than you need to be
            else if (Player.Level > minLevel)
            {
                int levAdj = (Player.Level - minLevel) / 3;
                if (levAdj > 10)
                {
                    levAdj = 10;
                }
                difficulty -= levAdj;
            }
            // We have a minimum difficulty
            if (difficulty < 5)
            {
                difficulty = 5;
            }
            // Using a power takes a turn
            EnergyUse = 100;
            // Reduce our health or mana
            if (useHealth)
            {
                Player.TakeHit((cost / 2) + Program.Rng.DieRoll(cost / 2), "concentrating too hard");
            }
            else
            {
                Player.Mana -= (cost / 2) + Program.Rng.DieRoll(cost / 2);
            }
            // We'll need to redraw
            Player.RedrawNeeded.Set(RedrawFlag.PrHp);
            Player.RedrawNeeded.Set(RedrawFlag.PrMana);
            // Check to see if we were successful
            if (Program.Rng.DieRoll(Player.AbilityScores[useStat].Innate) >=
                (difficulty / 2) + Program.Rng.DieRoll(difficulty / 2))
            {
                return true;
            }
            // Let us know we failed
            MsgPrint("You've failed to concentrate hard enough.");
            return false;
        }

        /// <summary>
        /// Close a door
        /// </summary>
        /// <param name="y"> The y map coordinate of the door </param>
        /// <param name="x"> The x map coordinate of the door </param>
        /// <returns> True if the player should be disturbed by the door closing </returns>
        public bool CloseDoor(int y, int x)
        {
            EnergyUse = 100;
            GridTile cPtr = Level.Grid[y][x];
            if (cPtr.FeatureType.Name == "BrokenDoor")
            {
                MsgPrint("The door appears to be broken.");
            }
            else
            {
                Level.CaveSetFeat(y, x, "LockedDoor0");
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateMonsters);
                PlaySound(SoundEffect.ShutDoor);
            }
            return false;
        }

        /// <summary>
        /// Count the number of chests adjacent to the player, filling in a map coordinate with the
        /// location of the last one found
        /// </summary>
        /// <param name="mapCoordinate"> The coordinate to fill in with the location </param>
        /// <param name="trappedOnly"> True if we're only interested in trapped chests </param>
        /// <returns> The number of chests </returns>
        public int CountChests(MapCoordinate mapCoordinate, bool trappedOnly)
        {
            int count = 0;
            for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
            {
                int yy = Player.MapY + Level.OrderedDirectionYOffset[orderedDirection];
                int xx = Player.MapX + Level.OrderedDirectionXOffset[orderedDirection];
                // Get the index of first item in the tile that is a chest
                int itemIndex;
                if ((itemIndex = Level.ChestCheck(yy, xx)) == 0)
                {
                    // There wasn't a chest on the grid so skip
                    continue;
                }
                // Get the actual item from the index
                Item item = Level.Items[itemIndex];
                if (item.TypeSpecificValue == 0)
                {
                    continue;
                }
                // If we're only interested in trapped chests, skip those that aren't
                if (trappedOnly && (!item.IsKnown() || GlobalData.ChestTraps[item.TypeSpecificValue] == Enumerations.ChestTrap.ChestNotTrapped))
                {
                    continue;
                }
                count++;
                // Remember the coordinate
                mapCoordinate.Y = yy;
                mapCoordinate.X = xx;
            }
            return count;
        }

        /// <summary>
        /// Count the number of closed doors around the player, filling in a map coordinate with the
        /// location of the last one found
        /// </summary>
        /// <param name="mapCoordinate"> The location around which to search </param>
        /// <returns> The number of closed doors </returns>
        public int CountClosedDoors(MapCoordinate mapCoordinate)
        {
            int count = 0;
            for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
            {
                int yy = Player.MapY + Level.OrderedDirectionYOffset[orderedDirection];
                int xx = Player.MapX + Level.OrderedDirectionXOffset[orderedDirection];
                // We need to be aware of the door
                if (Level.Grid[yy][xx].TileFlags.IsClear(GridTile.PlayerMemorised))
                {
                    continue;
                }
                // It needs to be an actual door
                if (!Level.Grid[yy][xx].FeatureType.IsClosedDoor)
                {
                    continue;
                }
                // It can't be a secret door
                if (Level.Grid[yy][xx].FeatureType.Name == "SecretDoor")
                {
                    continue;
                }
                count++;
                // Remember the coordinate
                mapCoordinate.Y = yy;
                mapCoordinate.X = xx;
            }
            return count;
        }

        /// <summary>
        /// Get the number of known traps around the player, storing the map coordinate of the last
        /// one found
        /// </summary>
        /// <param name="mapCoordinate">
        /// The coordinate in which to store the location of the last trap found
        /// </param>
        /// <returns> The number of traps found </returns>
        public int CountKnownTraps(MapCoordinate mapCoordinate)
        {
            int count = 0;
            for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
            {
                int yy = Player.MapY + Level.OrderedDirectionYOffset[orderedDirection];
                int xx = Player.MapX + Level.OrderedDirectionXOffset[orderedDirection];
                // We need to be aware of the trap
                if (Level.Grid[yy][xx].TileFlags.IsClear(GridTile.PlayerMemorised))
                {
                    continue;
                }
                // It needs to actually be a trap
                if (!Level.Grid[yy][xx].FeatureType.IsTrap)
                {
                    continue;
                }
                count++;
                // Remember its location
                mapCoordinate.Y = yy;
                mapCoordinate.X = xx;
            }
            return count;
        }

        /// <summary>
        /// Count the number of open doors around the players location, puting the location of the
        /// last one found into a map coordinate
        /// </summary>
        /// <param name="mapCoordinate">
        /// The map coordinate into which the location should be placed
        /// </param>
        /// <returns> The number of open doors found </returns>
        public int CountOpenDoors(MapCoordinate mapCoordinate)
        {
            int count = 0;
            for (int orderedDirection = 0; orderedDirection < 9; orderedDirection++)
            {
                int yy = Player.MapY + Level.OrderedDirectionYOffset[orderedDirection];
                int xx = Player.MapX + Level.OrderedDirectionXOffset[orderedDirection];
                // We must be aware of the door
                if (Level.Grid[yy][xx].TileFlags.IsClear(GridTile.PlayerMemorised))
                {
                    continue;
                }
                // It must actually be an open door
                if (Level.Grid[yy][xx].FeatureType.Name != "OpenDoor")
                {
                    continue;
                }
                count++;
                // Remember the location
                mapCoordinate.Y = yy;
                mapCoordinate.X = xx;
            }
            return count;
        }

        /// <summary>
        /// Create phlogiston to refill a lantern or torch with
        /// </summary>
        public void CreatePhlogiston()
        {
            int maxPhlogiston;
            Item item = Player.Inventory[InventorySlot.Lightsource];
            // Maximum phlogiston is the capacity of the light source
            if (item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Lantern)
            {
                maxPhlogiston = Constants.FuelLamp;
            }
            else if (item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Torch)
            {
                maxPhlogiston = Constants.FuelTorch;
            }
            // Probably using an orb or a star essence (or maybe not holding a light source at all)
            else
            {
                MsgPrint("You are not wielding anything which uses phlogiston.");
                return;
            }
            // Item is already full
            if (item.TypeSpecificValue >= maxPhlogiston)
            {
                MsgPrint("No more phlogiston can be put in this item.");
                return;
            }
            // Add half the max fuel of the item to its current fuel
            item.TypeSpecificValue += maxPhlogiston / 2;
            MsgPrint("You add phlogiston to your light item.");
            // Make sure it doesn't overflow
            if (item.TypeSpecificValue >= maxPhlogiston)
            {
                item.TypeSpecificValue = maxPhlogiston;
                MsgPrint("Your light item is full.");
            }
            // We need to update our light after this
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
        }

        /// <summary>
        /// Heavily curse the players armour
        /// </summary>
        /// <returns> true if there was armour to curse, false otherwise </returns>
        public bool CurseArmour()
        {
            Item item = Player.Inventory[InventorySlot.Body];
            // If we're not wearing armour then nothing can happen
            if (item.BaseItemCategory == null)
            {
                return false;
            }
            // Artifacts can't be cursed, and normal armour has a chance to save
            string itemName = item.Description(false, 3);
            if ((!string.IsNullOrEmpty(item.RandartName) || item.IsFixedArtifact()) && Program.Rng.RandomLessThan(100) < 50)
            {
                MsgPrint($"A terrible black aura tries to surround your armour, but your {itemName} resists the effects!");
            }
            else
            {
                // Completely remake the armour into a set of blasted armour
                MsgPrint($"A terrible black aura blasts your {itemName}!");
                item.FixedArtifactIndex = 0;
                item.RareItemTypeIndex = Enumerations.RareItemType.ArmourBlasted;
                item.BonusArmourClass = 0 - Program.Rng.DieRoll(5) - Program.Rng.DieRoll(5);
                item.BonusToHit = 0;
                item.BonusDamage = 0;
                item.BaseArmourClass = 0;
                item.DamageDice = 0;
                item.DamageDiceSides = 0;
                item.RandartItemCharacteristics.Clear();
                item.IdentifyFlags.Set(Constants.IdentCursed);
                item.IdentifyFlags.Set(Constants.IdentBroken);
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
            }
            return true;
        }

        /// <summary>
        /// Heavily curse the player's weapon
        /// </summary>
        /// <returns> True if the player was carrying a weapon, false if not </returns>
        public bool CurseWeapon()
        {
            Item item = Player.Inventory[InventorySlot.MeleeWeapon];
            // If we don't have a weapon then nothing happens
            if (item.BaseItemCategory == null)
            {
                return false;
            }
            string itemName = item.Description(false, 3);
            // Artifacts can't be cursed, and other items have a chance to resist
            if ((item.IsFixedArtifact() || !string.IsNullOrEmpty(item.RandartName)) &&
                Program.Rng.RandomLessThan(100) < 50)
            {
                MsgPrint(
                    $"A terrible black aura tries to surround your weapon, but your {itemName} resists the effects!");
            }
            else
            {
                // Completely remake the item into a shattered weapon
                MsgPrint($"A terrible black aura blasts your {itemName}!");
                item.FixedArtifactIndex = 0;
                item.RareItemTypeIndex = Enumerations.RareItemType.WeaponShattered;
                item.BonusToHit = 0 - Program.Rng.DieRoll(5) - Program.Rng.DieRoll(5);
                item.BonusDamage = 0 - Program.Rng.DieRoll(5) - Program.Rng.DieRoll(5);
                item.BonusArmourClass = 0;
                item.BaseArmourClass = 0;
                item.DamageDice = 0;
                item.DamageDiceSides = 0;
                item.RandartItemCharacteristics.Clear();
                item.IdentifyFlags.Set(Constants.IdentCursed);
                item.IdentifyFlags.Set(Constants.IdentBroken);
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
            }
            return true;
        }

        /// <summary>
        /// Disarm a chest at a given location
        /// </summary>
        /// <param name="y"> The y coordinate of the location </param>
        /// <param name="x"> The x coordinate of the location </param>
        /// <param name="itemIndex"> The index of the chest item </param>
        /// <returns> True, if the player is allowed to another attempt to disarm the trap.</returns>
        public bool DisarmChest(int y, int x, int itemIndex)
        {
            bool allowAdditionalDisarmAttempts = false;
            Item item = Level.Items[itemIndex];
            // Disarming a chest takes a turn
            EnergyUse = 100;
            int i = Player.SkillDisarmTraps;
            // Disarming is tricky when you can't see
            if (Player.TimedBlindness != 0 || Level.NoLight())
            {
                i /= 10;
            }
            // Disarming is tricky when confused
            if (Player.TimedConfusion != 0 || Player.TimedHallucinations != 0)
            {
                i /= 10;
            }
            // Penalty for difficulty of trap
            int j = i - item.TypeSpecificValue;
            if (j < 2)
            {
                j = 2;
            }
            // If we don't know about the traps, we don't know what to disarm
            if (!item.IsKnown())
            {
                MsgPrint("I don't see any traps.");
            }
            // If it has no traps there's nothing to disarm
            else if (item.TypeSpecificValue <= 0)
            {
                MsgPrint("The chest is not trapped.");
            }
            // If it has a null trap then there's nothing to disarm
            else if (GlobalData.ChestTraps[item.TypeSpecificValue] == Enumerations.ChestTrap.ChestNotTrapped)
            {
                MsgPrint("The chest is not trapped.");
            }
            // If we made the skill roll then we disarmed it
            else if (Program.Rng.RandomLessThan(100) < j)
            {
                MsgPrint("You have disarmed the chest.");
                Player.GainExperience(item.TypeSpecificValue);
                item.TypeSpecificValue = 0 - item.TypeSpecificValue;
            }
            // If we failed to disarm it there's a chance it goes off
            else if (i > 5 && Program.Rng.DieRoll(i) > 5)
            {
                allowAdditionalDisarmAttempts = true;
                MsgPrint("You failed to disarm the chest.");
            }
            else
            {
                MsgPrint("You set off a trap!");
                ChestTrap(y, x, itemIndex);
            }
            return allowAdditionalDisarmAttempts;
        }

        /// <summary>
        /// Disarm a trap on the floor
        /// </summary>
        /// <param name="y"> The y coordinate of the trap </param>
        /// <param name="x"> The x coordinate of the trap </param>
        /// <param name="dir"> The direction the player should move in </param>
        /// <returns> </returns>
        public bool DisarmTrap(int y, int x, int dir)
        {
            bool more = false;
            // Disarming a trap costs a turn
            EnergyUse = 100;
            GridTile tile = Level.Grid[y][x];
            string trapName = tile.FeatureType.Description;
            int i = Player.SkillDisarmTraps;
            // Difficult, but possible, to disarm by feel
            if (Player.TimedBlindness != 0 || Level.NoLight())
            {
                i /= 10;
            }
            // Difficult to disarm when we're confused
            if (Player.TimedConfusion != 0 || Player.TimedHallucinations != 0)
            {
                i /= 10;
            }
            const int power = 5;
            int j = i - power;
            if (j < 2)
            {
                j = 2;
            }
            // Check the modified disarm skill
            if (Program.Rng.RandomLessThan(100) < j)
            {
                MsgPrint($"You have disarmed the {trapName}.");
                Player.GainExperience(power);
                tile.TileFlags.Clear(GridTile.PlayerMemorised);
                Level.RevertTileToBackground(y, x);
                MovePlayer(dir, true);
            }
            // We might set the trap off if we failed to disarm it
            else if (i > 5 && Program.Rng.DieRoll(i) > 5)
            {
                MsgPrint($"You failed to disarm the {trapName}.");
                more = true;
            }
            else
            {
                MsgPrint($"You set off the {trapName}!");
                MovePlayer(dir, true);
            }
            return more;
        }

        /// <summary>
        /// Channel mana to power an item instead
        /// </summary>
        /// <param name="item"> The item that we wish to power </param>
        /// <returns> True if we successfully channeled it, false if not </returns>
        public bool DoCmdChannel(Item item)
        {
            int cost;
            int price = item.BaseItemCategory.Cost;
            // Never channel worthless items
            if (price <= 0)
            {
                return false;
            }
            // Cost to channel is based on how much the item is worth and what type
            switch (item.Category)
            {
                case ItemCategory.Wand:
                    cost = price / 150;
                    break;

                case ItemCategory.Scroll:
                    cost = price / 10;
                    break;

                case ItemCategory.Potion:
                    cost = price / 20;
                    break;

                case ItemCategory.Rod:
                    cost = price / 250;
                    break;

                case ItemCategory.Staff:
                    cost = price / 100;
                    break;

                default:
                    MsgPrint("Tried to channel an unknown object type!");
                    return false;
            }
            // Always cost at least 1 mana
            if (cost < 1)
            {
                cost = 1;
            }
            // Spend the mana if we can
            if (cost <= Player.Mana)
            {
                MsgPrint("You channel mana to power the effect.");
                Player.Mana -= cost;
                Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                return true;
            }
            // Use some mana in the attempt, even if we failed
            MsgPrint("You mana is insufficient to power the effect.");
            Player.Mana -= Program.Rng.RandomLessThan(Player.Mana / 2);
            Player.RedrawNeeded.Set(RedrawFlag.PrMana);
            return false;
        }

        /// <summary>
        /// Give us a rumour, if possible one that we've not heard before
        /// </summary>
        public void GetRumour()
        {
            string rumor;
            // Build an array of all the possible rumours we can get
            char[] rumorType = new char[Quests.Count + Constants.MaxCaves + Constants.MaxCaves];
            int[] rumorIndex = new int[Quests.Count + Constants.MaxCaves + Constants.MaxCaves];
            int maxRumor = 0;
            // Add a rumour for each undiscovered quest
            for (int i = 0; i < Quests.Count; i++)
            {
                if (Quests[i].Level > 0 && !Quests[i].Discovered)
                {
                    rumorType[maxRumor] = 'q';
                    rumorIndex[maxRumor] = i;
                    maxRumor++;
                }
            }
            for (int i = 0; i < Constants.MaxCaves; i++)
            {
                // Add a rumour for each dungeon we don't know the depth of
                if (!Dungeons[i].KnownDepth)
                {
                    rumorType[maxRumor] = 'd';
                    rumorIndex[maxRumor] = i;
                    maxRumor++;
                }
                //Add a rumour for each dungeon we don't know the offset of
                if (!Dungeons[i].KnownOffset)
                {
                    rumorType[maxRumor] = 'o';
                    rumorIndex[maxRumor] = i;
                    maxRumor++;
                }
            }
            // If we already know everything, we're going to need to be told something so add all
            // the quest rumours and we'll get given a repeat of one of those
            if (maxRumor == 0)
            {
                maxRumor = 0;
                for (int i = 0; i < Quests.Count; i++)
                {
                    rumorType[maxRumor] = 'q';
                    rumorIndex[maxRumor] = i;
                    maxRumor++;
                }
            }
            // Pick a random rumour from the list
            int choice = Program.Rng.RandomLessThan(maxRumor);
            char type = rumorType[choice];
            int index = rumorIndex[choice];
            // Give us the appropriate information based on the rumour's type
            if (type == 'q')
            {
                // The rumour describes a quest
                Quests[index].Discovered = true;
                rumor = Quests.DescribeQuest(index);
            }
            else if (type == 'd')
            {
                // The rumour describes a dungeon depth
                Dungeon d = Dungeons[index];
                rumor = d.Tower
                    ? $"They say that {d.Name} has {d.MaxLevel} floors."
                    : $"They say that {d.Name} has {d.MaxLevel} levels.";
                d.KnownDepth = true;
            }
            else
            {
                // The rumour describes a dungeon difficulty
                Dungeon d = Dungeons[index];
                rumor = $"They say that {d.Name} has a relative difficulty of {d.Offset}.";
                d.KnownOffset = true;
            }
            MsgPrint(rumor);
        }

        /// <summary>
        /// Find a spike in the player's inventory
        /// </summary>
        /// <param name="inventoryIndex"> The inventory index of the spike found (if any) </param>
        /// <returns> Whether or not a spike was found </returns>
        public bool GetSpike(out int inventoryIndex)
        {
            // Loop through the inventory
            for (int i = 0; i < InventorySlot.Pack; i++)
            {
                Item item = Player.Inventory[i];
                if (item.BaseItemCategory == null)
                {
                    continue;
                }
                // If the item is a spike, return it
                if (item.Category == ItemCategory.Spike)
                {
                    inventoryIndex = i;
                    return true;
                }
            }
            // We found nothing, so return false
            inventoryIndex = -1;
            return false;
        }

        /// <summary>
        /// Return whether or not an item can be activated
        /// </summary>
        /// <param name="item"> The item to check </param>
        /// <returns> True if the item can be activated </returns>
        public bool ItemFilterActivatable(Item item)
        {
            if (!item.IsKnown())
            {
                return false;
            }
            item.RefreshFlagBasedProperties();
            return item.Characteristics.Activate;
        }

        /// <summary>
        /// Return whether or not an item is a high level book
        /// </summary>
        /// <param name="item"> The item to check </param>
        /// <returns> True if the item is a high level book </returns>
        public bool ItemFilterHighLevelBook(Item item)
        {
            if (item.Category == ItemCategory.LifeBook || item.Category == ItemCategory.SorceryBook ||
                item.Category == ItemCategory.NatureBook || item.Category == ItemCategory.ChaosBook ||
                item.Category == ItemCategory.DeathBook || item.Category == ItemCategory.TarotBook)
            {
                return item.ItemSubCategory > 1;
            }
            return false;
        }

        /// <summary>
        /// Return whether or not an item can fuel a lantern
        /// </summary>
        /// <param name="item"> The item to check </param>
        /// <returns> True if the item can fuel a lantern </returns>
        public bool ItemFilterLanternFuel(Item item)
        {
            if (item.Category == ItemCategory.Flask)
            {
                return true;
            }
            if (item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Lantern)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Return whether or not an item can fuel a torch
        /// </summary>
        /// <param name="item"> The item to check </param>
        /// <returns> True if the item can fuel a torch </returns>
        public bool ItemFilterTorchFuel(Item item)
        {
            return item.Category == ItemCategory.Light && item.ItemSubCategory == LightType.Torch;
        }

        /// <summary>
        /// Return whether or not an item can be worn or wielded
        /// </summary>
        /// <param name="item"> The item to check </param>
        /// <returns> True if the item can be worn or wielded </returns>
        public bool ItemFilterWearable(Item item)
        {
            return Player.Inventory.WieldSlot(item) >= InventorySlot.MeleeWeapon;
        }

        /// <summary>
        /// Attempt to move the player in the given direction
        /// </summary>
        /// <param name="direction"> The direction in which to move </param>
        /// <param name="dontPickup"> Whether or not to skip picking up any objects we step on </param>
        public void MovePlayer(int direction, bool dontPickup)
        {
            bool canPassWalls = false;
            int newY = Player.MapY + Level.KeypadDirectionYOffset[direction];
            int newX = Player.MapX + Level.KeypadDirectionXOffset[direction];
            GridTile tile = Level.Grid[newY][newX];
            Monster monster = Level.Monsters[tile.MonsterIndex];
            // Check if we can pass through walls
            if (Player.TimedEtherealness != 0 || Player.RaceIndex == RaceId.Spectre)
            {
                canPassWalls = true;
                // Permanent features can't be passed through even if we could otherwise
                if (Level.Grid[newY][newX].FeatureType.IsPermanent)
                {
                    canPassWalls = false;
                }
            }
            // If there's a monster we can see or an invisible monster on a tile we can move to,
            // deal with it
            if (tile.MonsterIndex != 0 && (monster.IsVisible || Level.GridPassable(newY, newX) || canPassWalls))
            {
                // Check if it's a friend, and if we are in a fit state to distinguish friend from foe
                if ((monster.Mind & Constants.SmFriendly) != 0 &&
                    !(Player.TimedConfusion != 0 || Player.TimedHallucinations != 0 || !monster.IsVisible || Player.TimedStun != 0) &&
                    (Level.GridPassable(newY, newX) || canPassWalls))
                {
                    // Wake up the monster, and track it
                    monster.SleepLevel = 0;
                    string monsterName = monster.MonsterDesc(0);
                    // If we can see it, no need to mention it
                    if (monster.IsVisible)
                    {
                        HealthTrack(tile.MonsterIndex);
                    }
                    // If we can't see it then let us push past it and tell us what happened
                    else if (Level.GridPassable(Player.MapY, Player.MapX) ||
                             (monster.Race.Flags2 & MonsterFlag2.PassWall) != 0)
                    {
                        MsgPrint($"You push past {monsterName}.");
                        monster.MapY = Player.MapY;
                        monster.MapX = Player.MapX;
                        Level.Grid[Player.MapY][Player.MapX].MonsterIndex = tile.MonsterIndex;
                        tile.MonsterIndex = 0;
                        Level.Monsters.UpdateMonsterVisibility(Level.Grid[Player.MapY][Player.MapX].MonsterIndex, true);
                    }
                    // If we couldn't push past it, tell us it was in the way
                    else
                    {
                        MsgPrint($"{monsterName} is in your way!");
                        EnergyUse = 0;
                        return;
                    }
                }
                // If the monster wasn't friendly, attack it
                else
                {
                    PlayerAttackMonster(newY, newX);
                    return;
                }
            }
            // We didn't attack a monster or get blocked by one, so start testing terrain features
            if (!dontPickup && tile.FeatureType.IsTrap)
            {
                // If we're walking onto a known trap, assume we're trying to disarm it
                DisarmTrap(newY, newX, direction);
                return;
            }
            // If the tile we're moving onto isn't passable then we can't move onto it
            if (!Level.GridPassable(newY, newX) && !canPassWalls)
            {
                Disturb(false);
                // If we can't see it and haven't memories it, tell us what we bumped into
                if (tile.TileFlags.IsClear(GridTile.PlayerMemorised) &&
                    (Player.TimedBlindness != 0 || tile.TileFlags.IsClear(GridTile.PlayerLit)))
                {
                    if (tile.FeatureType.Name == "Rubble")
                    {
                        MsgPrint("You feel some rubble blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    else if (tile.FeatureType.Category == FloorTileTypeCategory.Tree)
                    {
                        MsgPrint($"You feel a {tile.FeatureType.Description} blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    else if (tile.FeatureType.Name == "Pillar")
                    {
                        MsgPrint("You feel a pillar blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    else if (tile.FeatureType.Name.Contains("Water"))
                    {
                        MsgPrint("Your way seems to be blocked by water.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    // If we're moving onto a border, change wilderness location
                    else if (tile.FeatureType.Name.Contains("Border"))
                    {
                        if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                        {
                            CurTown = Wilderness[Player.WildernessY][Player.WildernessX].Town;
                            MsgPrint($"You stumble out of {CurTown.Name}.");
                        }
                        if (newY == 0)
                        {
                            Player.MapY = Level.CurHgt - 2;
                            Player.WildernessY--;
                        }
                        if (newY == Level.CurHgt - 1)
                        {
                            Player.MapY = 1;
                            Player.WildernessY++;
                        }
                        if (newX == 0)
                        {
                            Player.MapX = Level.CurWid - 2;
                            Player.WildernessX--;
                        }
                        if (newX == Level.CurWid - 1)
                        {
                            Player.MapX = 1;
                            Player.WildernessX++;
                        }
                        if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                        {
                            CurTown = Wilderness[Player.WildernessY][Player.WildernessX].Town;
                            MsgPrint($"You stumble into {CurTown.Name}.");
                            CurTown.Visited = true;
                        }
                        // We'll need a new level
                        NewLevelFlag = true;
                        CameFrom = LevelStart.StartWalk;
                        DoCmdSaveGame(true);
                    }
                    else if (tile.FeatureType.IsClosedDoor)
                    {
                        MsgPrint("You feel a closed door blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    else
                    {
                        MsgPrint($"You feel a {tile.FeatureType.Description} blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                }
                // We can see it, so give a different message
                else
                {
                    if (tile.FeatureType.Name == "Rubble")
                    {
                        MsgPrint("There is rubble blocking your way.");
                        if (!(Player.TimedConfusion != 0 || Player.TimedStun != 0 || Player.TimedHallucinations != 0))
                        {
                            EnergyUse = 0;
                        }
                    }
                    else if (tile.FeatureType.Category == FloorTileTypeCategory.Tree)
                    {
                        MsgPrint($"There is a {tile.FeatureType.Description} blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    else if (tile.FeatureType.Name == "Pillar")
                    {
                        MsgPrint("There is a pillar blocking your way.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    else if (tile.FeatureType.Name.Contains("Water"))
                    {
                        MsgPrint("You cannot swim.");
                        tile.TileFlags.Set(GridTile.PlayerMemorised);
                        Level.RedrawSingleLocation(newY, newX);
                    }
                    // Again, walking onto a border means a change of wilderness grid
                    else if (tile.FeatureType.Name.Contains("Border"))
                    {
                        if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                        {
                            CurTown = Wilderness[Player.WildernessY][Player.WildernessX].Town;
                            MsgPrint($"You leave {CurTown.Name}.");
                            CurTown.Visited = true;
                        }
                        if (newY == 0)
                        {
                            Player.MapY = Level.CurHgt - 2;
                            Player.WildernessY--;
                        }
                        if (newY == Level.CurHgt - 1)
                        {
                            Player.MapY = 1;
                            Player.WildernessY++;
                        }
                        if (newX == 0)
                        {
                            Player.MapX = Level.CurWid - 2;
                            Player.WildernessX--;
                        }
                        if (newX == Level.CurWid - 1)
                        {
                            Player.MapX = 1;
                            Player.WildernessX++;
                        }
                        if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                        {
                            CurTown = Wilderness[Player.WildernessY][Player.WildernessX].Town;
                            MsgPrint($"You enter {CurTown.Name}.");
                            CurTown.Visited = true;
                        }
                        // We need a new map
                        NewLevelFlag = true;
                        CameFrom = LevelStart.StartWalk;
                        DoCmdSaveGame(true);
                    }
                    // If we can see that we're walking into a closed door, try to open it
                    else if (tile.FeatureType.IsClosedDoor)
                    {
                        if (EasyOpenDoor(newY, newX))
                        {
                            return;
                        }
                    }
                    else
                    {
                        MsgPrint($"There is a {tile.FeatureType.Description} blocking your way.");
                        if (!(Player.TimedConfusion != 0 || Player.TimedStun != 0 || Player.TimedHallucinations != 0))
                        {
                            EnergyUse = 0;
                        }
                    }
                }
                PlaySound(SoundEffect.BumpWall);
                return;
            }
            // Assuming we didn't bump into anything, maybe we can actually move
            bool oldTrapsDetected = Level.Grid[Player.MapY][Player.MapX].TileFlags.IsSet(GridTile.TrapsDetected);
            bool newTrapsDetected = Level.Grid[newY][newX].TileFlags.IsSet(GridTile.TrapsDetected);
            // If we're moving into or out of an area where we've detected traps, remember to redraw
            // the notification
            if (oldTrapsDetected != newTrapsDetected)
            {
                Player.RedrawNeeded.Set(RedrawFlag.PrDtrap);
            }
            // If we're leaving an area where we've detected traps at a run, then stop running
            if (Running != 0 && oldTrapsDetected && !newTrapsDetected)
            {
                if (!(Player.TimedConfusion != 0 || Player.TimedStun != 0 || Player.TimedHallucinations != 0))
                {
                    EnergyUse = 0;
                }
                Disturb(false);
                return;
            }
            // We've run out of things that could prevent us moving, so do the move
            int oldY = Player.MapY;
            int oldX = Player.MapX;
            Player.MapY = newY;
            Player.MapX = newX;
            // Redraw our old and new locations
            Level.RedrawSingleLocation(Player.MapY, Player.MapX);
            Level.RedrawSingleLocation(oldY, oldX);
            // Recenter the screen if we have to
            TargetEngine targetEngine = new TargetEngine(this);
            targetEngine.RecenterScreenAroundPlayer();
            // We'll need to update and redraw various things
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
            // If we're not actively searching, then have a chance of doing it passively
            if (Player.SkillSearchFrequency >= 50 || 0 == Program.Rng.RandomLessThan(50 - Player.SkillSearchFrequency))
            {
                Search();
            }
            // If we're actively searching then always do it
            if (Player.IsSearching)
            {
                Search();
            }
            // Pick up an object on our tile if there is one
            PickUpItems(!dontPickup);
            // If we've just entered a shop tile, then enter the actual shop
            if (tile.FeatureType.IsShop)
            {
                Disturb(false);
                QueuedCommand = '_';
            }
            // If we've just stepped on an unknown trap then activate it
            else if (tile.FeatureType.Name == "Invis")
            {
                Disturb(false);
                MsgPrint("You found a trap!");
                Level.PickTrap(Player.MapY, Player.MapX);
                StepOnTrap();
            }
            // If it's a trap we couldn't (or didn't) disarm, then activate it
            else if (tile.FeatureType.IsTrap)
            {
                Disturb(false);
                StepOnTrap();
            }
        }


        /// <summary>
        /// Open a door at a given location
        /// </summary>
        /// <param name="y"> The y coordinate of the location </param>
        /// <param name="x"> The x coordinate of the location </param>
        /// <returns> True if opening the door should disturb the player </returns>
        public bool OpenDoor(int y, int x)
        {
            bool more = false;
            // Opening a door takes an action
            EnergyUse = 100;
            GridTile tile = Level.Grid[y][x];
            // Some doors are simply jammed
            if (tile.FeatureType.Name.Contains("Jammed"))
            {
                MsgPrint("The door appears to be stuck.");
            }
            // Some doors are locked
            else if (tile.FeatureType.Name != "LockedDoor0")
            {
                // Our disarm traps skill doubles up as a lockpicking skill
                int i = Player.SkillDisarmTraps;
                // Hard to pick locks when you can't see
                if (Player.TimedBlindness != 0 || Level.NoLight())
                {
                    i /= 10;
                }
                // Hard to pick locks when you're confused or hallucinating
                if (Player.TimedConfusion != 0 || Player.TimedHallucinations != 0)
                {
                    i /= 10;
                }
                // Work out the difficulty from the feature name
                int j = int.Parse(tile.FeatureType.Name.Substring(10));
                j = i - (j * 4);
                if (j < 2)
                {
                    j = 2;
                }
                // Check if we succeeded in opening it
                if (Program.Rng.RandomLessThan(100) < j)
                {
                    MsgPrint("You have picked the lock.");
                    Level.CaveSetFeat(y, x, "OpenDoor");
                    Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateMonsters);
                    PlaySound(SoundEffect.LockpickSuccess);
                    // Picking a lock gains you an experience point
                    Player.GainExperience(1);
                }
                else
                {
                    MsgPrint("You failed to pick the lock.");
                    more = true;
                }
            }
            // If the door wasn't locked, simply open it
            else
            {
                Level.CaveSetFeat(y, x, "OpenDoor");
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateMonsters);
                PlaySound(SoundEffect.OpenDoor);
            }
            return more;
        }

        /// <summary>
        /// Step onto a grid with an item, possibly picking it up and possibly stomping on it
        /// </summary>
        /// <param name="pickup">
        /// True if we should pick up the object, or false if we should leave it where it is
        /// </param>
        public void PickUpItems(bool pickup)
        {
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            int nextItemIndex;
            for (int thisItemIndex = tile.ItemIndex; thisItemIndex != 0; thisItemIndex = nextItemIndex)
            {
                Item item = Level.Items[thisItemIndex];
                string itemName = item.Description(true, 3);
                nextItemIndex = item.NextInStack;
                Disturb(false);
                // We always pick up gold
                if (item.Category == ItemCategory.Gold)
                {
                    MsgPrint($"You collect {item.TypeSpecificValue} gold pieces worth of {itemName}.");
                    Player.Gold += item.TypeSpecificValue;
                    Player.RedrawNeeded.Set(RedrawFlag.PrGold);
                    Level.DeleteObjectIdx(thisItemIndex);
                }
                else
                {
                    // If we're not interested, simply say that we see it
                    if (!pickup)
                    {
                        MsgPrint($"You see {itemName}.");
                    }
                    // If it's worthless, stomp on it
                    else if (item.Stompable())
                    {
                        Level.DeleteObjectIdx(thisItemIndex);
                        MsgPrint($"You stomp on {itemName}.");
                    }
                    // If we can't carry the item, let us know
                    else if (!Player.Inventory.InvenCarryOkay(item))
                    {
                        MsgPrint($"You have no room for {itemName}.");
                    }
                    else
                    {
                        // Actually pick up the item
                        int slot = Player.Inventory.InvenCarry(item, false);
                        item = Player.Inventory[slot];
                        itemName = item.Description(true, 3);
                        MsgPrint($"You have {itemName} ({slot.IndexToLabel()}).");
                        Level.DeleteObjectIdx(thisItemIndex);
                    }
                }
            }
        }

        /// <summary>
        /// Have the player attack a monster
        /// </summary>
        /// <param name="y"> The y coordinate of the location being attacked </param>
        /// <param name="x"> The x coordinate of the location being attacked </param>
        public void PlayerAttackMonster(int y, int x)
        {
            GridTile tile = Level.Grid[y][x];
            Monster monster = Level.Monsters[tile.MonsterIndex];
            MonsterRace race = monster.Race;
            bool fear = false;
            bool backstab = false;
            bool stabFleeing = false;
            bool doQuake = false;
            const bool drainMsg = true;
            int drainResult = 0;
            const int drainLeft = _maxVampiricDrain;
            bool noExtra = false;
            Disturb(false);
            // If we're a rogue then we can backstab monsters
            if (Player.ProfessionIndex == CharacterClass.Rogue)
            {
                if (monster.SleepLevel != 0 && monster.IsVisible)
                {
                    backstab = true;
                }
                else if (monster.FearLevel != 0 && monster.IsVisible)
                {
                    stabFleeing = true;
                }
            }
            Disturb(true);
            // Being attacked always wakes a monster
            monster.SleepLevel = 0;
            string monsterName = monster.MonsterDesc(0);
            // If we can see the monster, track its health
            if (monster.IsVisible)
            {
                HealthTrack(tile.MonsterIndex);
            }
            // if the monster is our friend and we're not confused, we can avoid hitting it
            if ((monster.Mind & Constants.SmFriendly) != 0 &&
                !(Player.TimedStun != 0 || Player.TimedConfusion != 0 || Player.TimedHallucinations != 0 || !monster.IsVisible))
            {
                MsgPrint($"You stop to avoid hitting {monsterName}.");
                return;
            }
            // Can't attack if we're afraid
            if (Player.TimedFear != 0)
            {
                MsgPrint(monster.IsVisible ? $"You are too afraid to attack {monsterName}!" : "There is something scary in your way!");
                return;
            }
            Item item = Player.Inventory[InventorySlot.MeleeWeapon];
            int bonus = Player.AttackBonus + item.BonusToHit;
            int chance = Player.SkillMelee + (bonus * Constants.BthPlusAdj);
            // Attacking uses a full turn
            EnergyUse = 100;
            int num = 0;
            // We have a number of attacks per round
            while (num++ < Player.MeleeAttacksPerRound)
            {
                // Check if we hit
                if (PlayerCheckHitOnMonster(chance, race.ArmourClass, monster.IsVisible))
                {
                    PlayerStatus playerStatus = new PlayerStatus(this);
                    PlaySound(SoundEffect.MeleeHit);
                    // Tell the player they hit it with the appropriate message
                    if (!(backstab || stabFleeing))
                    {
                        if (!((Player.ProfessionIndex == CharacterClass.Monk || Player.ProfessionIndex == CharacterClass.Mystic) && playerStatus.MartialArtistEmptyHands()))
                        {
                            MsgPrint($"You hit {monsterName}.");
                        }
                    }
                    else if (backstab)
                    {
                        MsgPrint(
                            $"You cruelly stab the helpless, sleeping {monster.Race.Name}!");
                    }
                    else
                    {
                        MsgPrint(
                            $"You backstab the fleeing {monster.Race.Name}!");
                    }
                    // Default to 1 damage for an unarmed hit
                    int totalDamage = 1;
                    // Get our weapon's flags to see if we need to do anything special
                    item.RefreshFlagBasedProperties();
                    bool chaosEffect = item.Characteristics.Chaotic && Program.Rng.DieRoll(2) == 1;
                    if (item.Characteristics.Vampiric || (chaosEffect && Program.Rng.DieRoll(5) < 3))
                    {
                        // Vampiric overrides chaotic
                        chaosEffect = false;
                        if (!((race.Flags3 & MonsterFlag3.Undead) != 0 || (race.Flags3 & MonsterFlag3.Nonliving) != 0))
                        {
                            drainResult = monster.Health;
                        }
                        else
                        {
                            drainResult = 0;
                        }
                    }
                    // Vorpal weapons have a chance of a deep cut
                    bool vorpalCut = item.Characteristics.Vorpal && Program.Rng.DieRoll(item.FixedArtifactIndex == FixedArtifactId.SwordVorpalBlade ? 3 : 6) == 1;
                    // If we're a martial artist then we have special attacks
                    if ((Player.ProfessionIndex == CharacterClass.Monk || Player.ProfessionIndex == CharacterClass.Mystic) && playerStatus.MartialArtistEmptyHands())
                    {
                        int specialEffect = 0;
                        int stunEffect = 0;
                        int times;
                        MartialArtsAttack martialArtsAttack = GlobalData.MaBlows[0];
                        MartialArtsAttack oldMartialArtsAttack = GlobalData.MaBlows[0];
                        // Monsters of various types resist being stunned by martial arts
                        int resistStun = 0;
                        if ((race.Flags1 & MonsterFlag1.Unique) != 0)
                        {
                            resistStun += 88;
                        }
                        if ((race.Flags3 & MonsterFlag3.ImmuneConfusion) != 0)
                        {
                            resistStun += 44;
                        }
                        if ((race.Flags3 & MonsterFlag3.ImmuneSleep) != 0)
                        {
                            resistStun += 44;
                        }
                        if ((race.Flags3 & MonsterFlag3.Undead) != 0 || (race.Flags3 & MonsterFlag3.Nonliving) != 0)
                        {
                            resistStun += 88;
                        }
                        // Have a number of attempts to choose a martial arts attack
                        for (times = 0; times < (Player.Level < 7 ? 1 : Player.Level / 7); times++)
                        {
                            // Choose an attack randomly, but reject it and re-choose if it's too
                            // high level or we fail a chance roll
                            do
                            {
                                martialArtsAttack = GlobalData.MaBlows[Program.Rng.DieRoll(Constants.MaxMa) - 1];
                            } while (martialArtsAttack.MinLevel > Player.Level || Program.Rng.DieRoll(Player.Level) < martialArtsAttack.Chance);
                            // We've chosen an attack, use it if it's better than the previous
                            // choice (unless we're stunned or confused in which case we're stuck
                            // with the weakest attack type
                            if (martialArtsAttack.MinLevel > oldMartialArtsAttack.MinLevel && !(Player.TimedStun != 0 || Player.TimedConfusion != 0))
                            {
                                oldMartialArtsAttack = martialArtsAttack;
                            }
                            else
                            {
                                martialArtsAttack = oldMartialArtsAttack;
                            }
                        }
                        // Get damage from the martial arts attack
                        totalDamage = Program.Rng.DiceRoll(martialArtsAttack.Dd, martialArtsAttack.Ds);
                        // If it was a knee attack and the monster is male, hit it in the groin
                        if (martialArtsAttack.Effect == Constants.MaKnee)
                        {
                            if ((race.Flags1 & MonsterFlag1.Male) != 0)
                            {
                                MsgPrint($"You hit {monsterName} in the groin with your knee!");
                                specialEffect = Constants.MaKnee;
                            }
                            else
                            {
                                MsgPrint(string.Format(martialArtsAttack.Desc, monsterName));
                            }
                        }
                        // If it was an ankle kick and the monster has legs, slow it
                        else if (martialArtsAttack.Effect == Constants.MaSlow)
                        {
                            if ((race.Flags1 & MonsterFlag1.NeverMove) == 0 ||
                                "UjmeEv$,DdsbBFIJQSXclnw!=?".Contains(race.Character.ToString()))
                            {
                                MsgPrint($"You kick {monsterName} in the ankle.");
                                specialEffect = Constants.MaSlow;
                            }
                            else
                            {
                                MsgPrint(string.Format(martialArtsAttack.Desc, monsterName));
                            }
                        }
                        // Have a chance of stunning based on the martial arts attack type chosen
                        else
                        {
                            if (martialArtsAttack.Effect != 0)
                            {
                                stunEffect = (martialArtsAttack.Effect / 2) + Program.Rng.DieRoll(martialArtsAttack.Effect / 2);
                            }
                            MsgPrint(string.Format(martialArtsAttack.Desc, monsterName));
                        }
                        // It might be a critical hit
                        totalDamage = PlayerCriticalMelee(Player.Level * Program.Rng.DieRoll(10), martialArtsAttack.MinLevel, totalDamage);
                        // Make a groin attack into a stunning attack
                        if (specialEffect == Constants.MaKnee && totalDamage + Player.DamageBonus < monster.Health)
                        {
                            MsgPrint($"{monsterName} moans in agony!");
                            stunEffect = 7 + Program.Rng.DieRoll(13);
                            resistStun /= 3;
                        }
                        // Slow if we had a knee attack
                        else if (specialEffect == Constants.MaSlow && totalDamage + Player.DamageBonus < monster.Health)
                        {
                            if ((race.Flags1 & MonsterFlag1.Unique) == 0 && Program.Rng.DieRoll(Player.Level) > race.Level &&
                                monster.Speed > 60)
                            {
                                MsgPrint($"{monsterName} starts limping slower.");
                                monster.Speed -= 10;
                            }
                        }
                        // Stun if we had a stunning attack
                        if (stunEffect != 0 && totalDamage + Player.DamageBonus < monster.Health)
                        {
                            if (Player.Level > Program.Rng.DieRoll(race.Level + resistStun + 10))
                            {
                                MsgPrint(monster.StunLevel != 0 ? $"{monsterName} is more stunned." : $"{monsterName} is stunned.");
                                monster.StunLevel += stunEffect;
                            }
                        }
                    }
                    // We have a weapon
                    else if (item.BaseItemCategory != null)
                    {
                        // Roll damage for the weapon
                        totalDamage = Program.Rng.DiceRoll(item.DamageDice, item.DamageDiceSides);
                        totalDamage = item.AdjustDamageForMonsterType(totalDamage, monster);
                        // Extra damage for backstabbing
                        if (backstab)
                        {
                            totalDamage *= 3 + (Player.Level / 40);
                        }
                        else if (stabFleeing)
                        {
                            totalDamage = 3 * totalDamage / 2;
                        }
                        // We might need to do an earthquake
                        if ((Player.HasQuakeWeapon && (totalDamage > 50 || Program.Rng.DieRoll(7) == 1)) ||
                            (chaosEffect && Program.Rng.DieRoll(250) == 1))
                        {
                            doQuake = true;
                            chaosEffect = false;
                        }
                        // Check if we did a critical
                        totalDamage = PlayerCriticalMelee(item.Weight, item.BonusToHit, totalDamage);
                        // If we did a vorpal cut, do extra damage
                        if (vorpalCut)
                        {
                            int stepK = totalDamage;
                            MsgPrint(item.FixedArtifactIndex == FixedArtifactId.SwordVorpalBlade ? "Your Vorpal Blade goes snicker-snack!" : $"Your weapon cuts deep into {monsterName}!");
                            do
                            {
                                totalDamage += stepK;
                            } while (Program.Rng.DieRoll(item.FixedArtifactIndex == FixedArtifactId.SwordVorpalBlade
                                         ? 2
                                         : 4) == 1);
                        }
                        // Add bonus damage for the weapon
                        totalDamage += item.BonusDamage;
                    }
                    // Add bonus damage for strength etc.
                    totalDamage += Player.DamageBonus;
                    // Can't do negative damage
                    if (totalDamage < 0)
                    {
                        totalDamage = 0;
                    }
                    // Apply damage to the monster
                    if (Level.Monsters.DamageMonster(tile.MonsterIndex, totalDamage, out fear, null))
                    {
                        // Can't have any more attacks because the monster's dead
                        noExtra = true;
                        break;
                    }
                    // Hitting a friend gets it angry
                    if ((monster.Mind & Constants.SmFriendly) != 0)
                    {
                        MsgPrint($"{monsterName} gets angry!");
                        monster.Mind &= ~Constants.SmFriendly;
                    }
                    // The monster might have an aura that hurts the player
                    TouchZapPlayer(monster);
                    // If we drain health, do so
                    if (drainResult != 0)
                    {
                        // drainResult was set to the monsters health before we hit it, so
                        // subtracting the monster's new health lets us know how much damage we've done
                        drainResult -= monster.Health;
                        if (drainResult > 0)
                        {
                            // Draining heals us
                            int drainHeal = Program.Rng.DiceRoll(4, drainResult / 6);
                            // We have a maximum drain per round to prevent it from getting out of
                            // hand if we have multiple attacks
                            if (drainLeft != 0)
                            {
                                if (drainHeal >= drainLeft)
                                {
                                    drainHeal = drainLeft;
                                }
                                if (drainMsg)
                                {
                                    MsgPrint($"Your weapon drains life from {monsterName}!");
                                }
                                Player.RestoreHealth(drainHeal);
                            }
                        }
                    }
                    // We might have a confusing touch (or have this effect from a chaos blade)
                    if (Player.HasConfusingTouch || (chaosEffect && Program.Rng.DieRoll(10) != 1))
                    {
                        // If it wasn't from a chaos blade, cancel the confusing touch and let us know
                        Player.HasConfusingTouch = false;
                        if (!chaosEffect)
                        {
                            MsgPrint("Your hands stop glowing.");
                        }
                        // Some monsters are immune
                        if ((race.Flags3 & MonsterFlag3.ImmuneConfusion) != 0)
                        {
                            if (monster.IsVisible)
                            {
                                race.Knowledge.RFlags3 |= MonsterFlag3.ImmuneConfusion;
                            }
                            MsgPrint($"{monsterName} is unaffected.");
                        }
                        // Even if not immune, the monster might resist
                        else if (Program.Rng.RandomLessThan(100) < race.Level)
                        {
                            MsgPrint($"{monsterName} is unaffected.");
                        }
                        // It didn't resist, so it's confused
                        else
                        {
                            MsgPrint($"{monsterName} appears confused.");
                            monster.ConfusionLevel += 10 + (Program.Rng.RandomLessThan(Player.Level) / 5);
                        }
                    }
                    // A chaos blade might teleport the monster away
                    else if (chaosEffect && Program.Rng.DieRoll(2) == 1)
                    {
                        MsgPrint($"{monsterName} disappears!");
                        monster.TeleportAway(this, 50);
                        // Can't have any more attacks because the monster isn't here any more
                        noExtra = true;
                        break;
                    }
                    // a chaos blade might polymorph the monsterf
                    else if (chaosEffect && Level.GridPassable(y, x) && Program.Rng.DieRoll(90) > race.Level)
                    {
                        // Can't polymorph a unique or a guardian
                        if (!((race.Flags1 & MonsterFlag1.Unique) != 0 || (race.Flags4 & MonsterFlag4.BreatheChaos) != 0 ||
                              (race.Flags1 & MonsterFlag1.Guardian) != 0))
                        {
                            int newRaceIndex = PolymorphMonster(monster.Race);
                            if (newRaceIndex != monster.Race.Index)
                            {
                                MsgPrint($"{monsterName} changes!");
                                Level.Monsters.DeleteMonsterByIndex(tile.MonsterIndex, true);
                                MonsterRace newRace = MonsterRaces[newRaceIndex];
                                Level.Monsters.PlaceMonsterAux(y, x, newRace, false, false, false);
                                monster = Level.Monsters[tile.MonsterIndex];
                                monsterName = monster.MonsterDesc(0);
                                fear = false;
                            }
                        }
                        // Monster was immune to polymorph
                        else
                        {
                            MsgPrint($"{monsterName} is unaffected.");
                        }
                    }
                }
                // We missed
                else
                {
                    PlaySound(SoundEffect.Miss);
                    MsgPrint($"You miss {monsterName}.");
                }
            }
            // Only make extra attacks if the monster is still there
            foreach (Mutation naturalAttack in Player.Dna.NaturalAttacks)
            {
                if (!noExtra)
                {
                    PlayerNaturalAttackOnMonster(tile.MonsterIndex, naturalAttack, out fear, out noExtra);
                }
            }
            if (fear && monster.IsVisible && !noExtra)
            {
                PlaySound(SoundEffect.MonsterFlees);
                MsgPrint($"{monsterName} flees in terror!");
            }
            if (doQuake)
            {
                Earthquake(Player.MapY, Player.MapX, 10);
            }
        }

        /// <summary>
        /// Check whether a ranged attack by the player hits a monster
        /// </summary>
        /// <param name="attackBonus"> The player's attack bonus </param>
        /// <param name="armourClass"> The monster's armour class </param>
        /// <param name="monsterIsVisible"> Whether or not the monster is visible </param>
        /// <returns> True if the player hit the monster, false otherwise </returns>
        public bool PlayerCheckRangedHitOnMonster(int attackBonus, int armourClass, bool monsterIsVisible)
        {
            int k = Program.Rng.RandomLessThan(100);
            // Always a 5% chance to hit and a 5% chance to miss
            if (k < 10)
            {
                return k < 5;
            }
            // If we have no chance of hitting don't bother checking
            if (attackBonus <= 0)
            {
                return false;
            }
            // Invisible monsters are hard to hit
            if (!monsterIsVisible)
            {
                attackBonus = (attackBonus + 1) / 2;
            }
            // Return the hit or miss
            return Program.Rng.RandomLessThan(attackBonus) >= armourClass * 3 / 4;
        }

        /// <summary>
        /// Work out whether the player's missile attack was a critical hit
        /// </summary>
        /// <param name="weight"> The weight of the player's weapon </param>
        /// <param name="plus"> The magical plusses on the weapon </param>
        /// <param name="damage"> The damage done </param>
        /// <returns> The modified damage based on the level of critical </returns>
        public int PlayerCriticalRanged(int weight, int plus, int damage)
        {
            // Chance of a critical is based on weight, level, and plusses
            int i = weight + ((Player.AttackBonus + plus) * 4) + (Player.Level * 2);
            if (Program.Rng.DieRoll(5000) <= i)
            {
                int k = weight + Program.Rng.DieRoll(500);
                if (k < 500)
                {
                    MsgPrint("It was a good hit!");
                    damage = (2 * damage) + 5;
                }
                else if (k < 1000)
                {
                    MsgPrint("It was a great hit!");
                    damage = (2 * damage) + 10;
                }
                else
                {
                    MsgPrint("It was a superb hit!");
                    damage = (3 * damage) + 15;
                }
            }
            return damage;
        }

        /// <summary>
        /// Invoke a random power from the Ring of Set
        /// </summary>
        /// <param name="direction"> The direction the player is aiming </param>
        public void RingOfSetPower(int direction)
        {
            switch (Program.Rng.DieRoll(10))
            {
                case 1:
                case 2:
                    {
                        // Decrease all the players ability scores, bypassing sustain and divine protection
                        MsgPrint("You are surrounded by a malignant aura.");
                        Player.DecreaseAbilityScore(Ability.Strength, 50, true);
                        Player.DecreaseAbilityScore(Ability.Intelligence, 50, true);
                        Player.DecreaseAbilityScore(Ability.Wisdom, 50, true);
                        Player.DecreaseAbilityScore(Ability.Dexterity, 50, true);
                        Player.DecreaseAbilityScore(Ability.Constitution, 50, true);
                        Player.DecreaseAbilityScore(Ability.Charisma, 50, true);
                        // Reduce both experience and maximum experience
                        Player.ExperiencePoints -= Player.ExperiencePoints / 4;
                        Player.MaxExperienceGained -= Player.ExperiencePoints / 4;
                        Player.CheckExperience();
                        break;
                    }
                case 3:
                    {
                        // Dispel monsters
                        MsgPrint("You are surrounded by a powerful aura.");
                        DispelMonsters(1000);
                        break;
                    }
                case 4:
                case 5:
                case 6:
                    {
                        // Do a 300 damage mana ball
                        FireBall(new ProjectMana(this), direction, 300, 3);
                        break;
                    }
                case 7:
                case 8:
                case 9:
                case 10:
                    {
                        // Do a 250 damage mana bolt
                        FireBolt(new ProjectMana(this), direction, 250);
                        break;
                    }
            }
        }

        /// <summary>
        /// Run a single step
        /// </summary>
        /// <param name="direction">
        /// The direction in which we wish to run, or 0 if we are already running
        /// </param>
        public void RunOneStep(int direction)
        {
            if (direction != 0)
            {
                // Check if we can actually run in that direction
                if (AutoNavigator.SeeWall(Level, direction, Player.MapY, Player.MapX))
                {
                    MsgPrint("You cannot run in that direction.");
                    Disturb(false);
                    return;
                }
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
                // Initialise our navigation state
                _autoNavigator = new AutoNavigator(this, direction); // TODO: This is aweful
            }
            else
            {
                // We're already running, so check if we have to stop
                if (_autoNavigator.NavigateNextStep())
                {
                    Disturb(false);
                    return;
                }
            }
            // Running has a limit, just in case, but in practice we'll never reach it
            if (--Running <= 0)
            {
                return;
            }
            // We can run, so use a move's worth of energy and actually make the move
            EnergyUse = 100;
            MovePlayer(_autoNavigator.CurrentRunDirection, false);
        }

        /// <summary>
        /// Make a piece of armour immune to acid damage, removing any penalty at the same time
        /// </summary>
        public void Rustproof()
        {
            // Get a piece of armour
            ItemFilter = ItemTesterHookArmour;
            if (!GetItem(out int itemIndex, "Rustproof which piece of armour? ", true, true, true))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing to rustproof.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            string itenName = item.Description(false, 0);
            // Set the ignore acid flag
            item.RandartItemCharacteristics.IgnoreAcid = true;
            // Make sure the grammar of the message is correct
            string your;
            string s;
            if (item.BonusArmourClass < 0 && item.IdentifyFlags.IsClear(Constants.IdentCursed))
            {
                your = itemIndex > 0 ? "Your" : "The";
                s = item.Count > 1 ? "" : "s";
                MsgPrint($"{your} {itenName} look{s} as good as new!");
                item.BonusArmourClass = 0;
            }
            your = itemIndex > 0 ? "Your" : "The";
            s = item.Count > 1 ? "are" : "is";
            MsgPrint($"{your} {itenName} {s} now protected against corrosion.");
        }

        /// <summary>
        /// Search around the player for secret doors and traps
        /// </summary>
        public void Search()
        {
            // The basic chance is equal to our searching skill
            int chance = Player.SkillSearching;
            // If we can't see it's hard to search
            if (Player.TimedBlindness != 0 || Level.NoLight())
            {
                chance /= 10;
            }
            // If we're confused it's hard to search
            if (Player.TimedConfusion != 0 || Player.TimedHallucinations != 0)
            {
                chance /= 10;
            }
            // Check the eight squares around us
            for (int y = Player.MapY - 1; y <= Player.MapY + 1; y++)
            {
                for (int x = Player.MapX - 1; x <= Player.MapX + 1; x++)
                {
                    // Check if we succeed
                    if (Program.Rng.RandomLessThan(100) < chance)
                    {
                        // If there's a trap, then find it
                        GridTile tile = Level.Grid[y][x];
                        if (tile.FeatureType.Name == "Invis")
                        {
                            // Pick a random trap to replace the undetected one with
                            Level.PickTrap(y, x);
                            MsgPrint("You have found a trap.");
                            Disturb(false);
                        }
                        if (tile.FeatureType.Name == "SecretDoor")
                        {
                            // Replace the secret door with a visible door
                            MsgPrint("You have found a secret door.");
                            Player.GainExperience(1);
                            Level.ReplaceSecretDoor(y, x);
                            Disturb(false);
                        }
                        int nextItemIndex;
                        // Check the items on the tile
                        for (int itemIndex = tile.ItemIndex; itemIndex != 0; itemIndex = nextItemIndex)
                        {
                            Item item = Level.Items[itemIndex];
                            nextItemIndex = item.NextInStack;
                            // If one of them is a chest, determine if it is trapped
                            if (item.Category != ItemCategory.Chest)
                            {
                                continue;
                            }
                            if (item.TypeSpecificValue <= 0)
                            {
                                continue;
                            }
                            if (GlobalData.ChestTraps[item.TypeSpecificValue] == Enumerations.ChestTrap.ChestNotTrapped)
                            {
                                continue;
                            }
                            // It was a trapped chest - if we didn't already know that then let us know
                            if (!item.IsKnown())
                            {
                                MsgPrint("You have discovered a trap on the chest!");
                                item.BecomeKnown();
                                Disturb(false);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Summon an item to the player via telekinesis
        /// </summary>
        /// <param name="dir"> The direction to check for items </param>
        /// <param name="maxWeight"> The maximum weight we can summon </param>
        /// <param name="requireLos"> Whether or not we require line of sight to the item </param>
        public void SummonItem(int dir, int maxWeight, bool requireLos)
        {
            int targetY;
            int targetX;
            GridTile tile;
            // Can't summon something if we're already standing on something
            if (Level.Grid[Player.MapY][Player.MapX].ItemIndex != 0)
            {
                MsgPrint("You can't fetch when you're already standing on something.");
                return;
            }
            TargetEngine targetEngine = new TargetEngine(this);
            // If we didn't have a direction, we might have an existing target
            if (dir == 5 && targetEngine.TargetOkay())
            {
                targetX = TargetCol;
                targetY = TargetRow;
                // Check the range
                if (Level.Distance(Player.MapY, Player.MapX, targetY, targetX) > Constants.MaxRange)
                {
                    MsgPrint("You can't fetch something that far away!");
                    return;
                }
                // Check the line of sight if needed
                tile = Level.Grid[targetY][targetX];
                if (requireLos && !Level.PlayerHasLosBold(targetY, targetX))
                {
                    MsgPrint("You have no direct line of sight to that location.");
                    return;
                }
            }
            else
            {
                // We have a direction, so move along it until we find an item
                targetY = Player.MapY;
                targetX = Player.MapX;
                do
                {
                    targetY += Level.KeypadDirectionYOffset[dir];
                    targetX += Level.KeypadDirectionXOffset[dir];
                    tile = Level.Grid[targetY][targetX];
                    // Stop if we hit max range or we're blocked by something
                    if (Level.Distance(Player.MapY, Player.MapX, targetY, targetX) > Constants.MaxRange ||
                        !Level.GridPassable(targetY, targetX))
                    {
                        return;
                    }
                } while (tile.ItemIndex == 0);
            }
            Item item = Level.Items[tile.ItemIndex];
            // Check the weight of the item
            if (item.Weight > maxWeight)
            {
                MsgPrint("The object is too heavy.");
                return;
            }
            // Remove the entire item stack from the tile and move it to the player's tile
            int itemIndex = tile.ItemIndex;
            tile.ItemIndex = 0;
            Level.Grid[Player.MapY][Player.MapX].ItemIndex = itemIndex;
            item.Y = Player.MapY;
            item.X = Player.MapX;
            Level.NoteSpot(Player.MapY, Player.MapX);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
        }

        /// <summary>
        /// Tunnel through a grid tile
        /// </summary>
        /// <param name="y"> The y coordinate of the tile to be tunneled through </param>
        /// <param name="x"> The x coordinate of the tile to be tunneled through </param>
        /// <returns> Whether or not the command can be repeated </returns>
        public bool TunnelThroughTile(int y, int x)
        {
            bool repeat = false;
            // Tunnelling uses an entire turn
            EnergyUse = 100;
            GridTile tile = Level.Grid[y][x];
            // Trees are easy to chop down
            if (tile.FeatureType.Category == FloorTileTypeCategory.Tree)
            {
                if (Player.SkillDigging > 40 + Program.Rng.RandomLessThan(100) && RemoveTileViaTunnelling(y, x))
                {
                    MsgPrint($"You have chopped down the {tile.FeatureType.Description}.");
                }
                else
                {
                    MsgPrint($"You hack away at the {tile.FeatureType.Description}.");
                    repeat = true;
                }
            }
            // Pillars are a bit easier than walls
            else if (tile.FeatureType.Name == "Pillar")
            {
                if (Player.SkillDigging > 40 + Program.Rng.RandomLessThan(300) && RemoveTileViaTunnelling(y, x))
                {
                    MsgPrint("You have broken down the pillar.");
                }
                else
                {
                    MsgPrint("You hack away at the pillar.");
                    repeat = true;
                }
            }
            // We can't tunnel through water
            else if (tile.FeatureType.Name == "Water")
            {
                MsgPrint("The water fills up your tunnel as quickly as you dig!");
            }
            // Permanent features resist being tunneled through
            else if (tile.FeatureType.IsPermanent)
            {
                MsgPrint($"The {tile.FeatureType.Description} resists your attempts to tunnel through it.");
            }
            // It's a wall, so we tunnel normally
            else if (tile.FeatureType.Name.Contains("Wall"))
            {
                if (Player.SkillDigging > 40 + Program.Rng.RandomLessThan(1600) && RemoveTileViaTunnelling(y, x))
                {
                    MsgPrint("You have finished the tunnel.");
                }
                else
                {
                    MsgPrint("You tunnel into the granite wall.");
                    repeat = true;
                }
            }
            // It's a rock seam, so it might have treasure
            else if (tile.FeatureType.Name.Contains("Magma") || tile.FeatureType.Name.Contains("Quartz"))
            {
                bool okay;
                bool hasValue = false;
                bool isMagma = false;
                if (tile.FeatureType.Name.Contains("Treas"))
                {
                    hasValue = true;
                }
                if (tile.FeatureType.Name.Contains("Magma"))
                {
                    isMagma = true;
                }
                // Magma needs a higher tunneling skill than quartz
                if (isMagma)
                {
                    okay = Player.SkillDigging > 20 + Program.Rng.RandomLessThan(800);
                }
                else
                {
                    okay = Player.SkillDigging > 10 + Program.Rng.RandomLessThan(400);
                }
                // Do the actual tunnelling
                if (okay && RemoveTileViaTunnelling(y, x))
                {
                    if (hasValue)
                    {
                        Level.PlaceGold(y, x);
                        MsgPrint("You have found something!");
                    }
                    else
                    {
                        MsgPrint("You have finished the tunnel.");
                    }
                }
                // Tunnelling failed, so let us know
                else if (isMagma)
                {
                    MsgPrint("You tunnel into the magma vein.");
                    repeat = true;
                }
                else
                {
                    MsgPrint("You tunnel into the quartz vein.");
                    repeat = true;
                }
            }
            // Rubble is easy to tunnel through
            else if (tile.FeatureType.Name == "Rubble")
            {
                if (Player.SkillDigging > Program.Rng.RandomLessThan(200) && RemoveTileViaTunnelling(y, x))
                {
                    MsgPrint("You have removed the rubble.");
                    // 10% chance of finding something
                    if (Program.Rng.RandomLessThan(100) < 10)
                    {
                        Level.PlaceObject(y, x, false, false);
                        if (Level.PlayerCanSeeBold(y, x))
                        {
                            MsgPrint("You have found something!");
                        }
                    }
                }
                else
                {
                    MsgPrint("You dig in the rubble.");
                    repeat = true;
                }
            }
            // We don't recognise what we're tunnelling into, so just assume it's permanent
            else
            {
                MsgPrint($"The {tile.FeatureType.Description} resists your attempts to tunnel through it.");
                repeat = true;
                Search();
            }
            // If we successfully made the tunnel,
            if (!Level.GridPassable(y, x))
            {
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateMonsters);
            }
            if (!repeat)
            {
                PlaySound(SoundEffect.Dig);
            }
            return repeat;
        }

        /// <summary>
        /// Use the player's racial power, if they have one
        /// </summary>
        public void UseRacialPower()
        {
            int playerLevel = Player.Level;
            int direction;
            Projectile projectile;
            string projectileDescription;
            // Default to being randomly fire (66% chance) or cold (33% chance)
            if (Program.Rng.DieRoll(3) == 1)
            {
                projectile = new ProjectCold(this);
                projectileDescription = "cold";
            }
            else
            {
                projectile = new ProjectFire(this);
                projectileDescription = "fire";
            }
            TargetEngine targetEngine = new TargetEngine(this);
            // Check the player's race to see what their power is
            switch (Player.RaceIndex)
            {
                // Dwarves can detect traps, doors, and stairs
                case RaceId.Dwarf:
                    if (CheckIfRacialPowerWorks(5, 5, Ability.Wisdom, 12))
                    {
                        MsgPrint("You examine your surroundings.");
                        DetectTraps();
                        DetectDoors();
                        DetectStairs();
                    }
                    break;
                // Hobbits can cook food
                case RaceId.Hobbit:
                    if (CheckIfRacialPowerWorks(15, 10, Ability.Intelligence, 10))
                    {
                        Item item = new Item(this);
                        item.AssignItemType(new FoodRation());
                        Level.DropNear(item, -1, Player.MapY, Player.MapX);
                        MsgPrint("You cook some food.");
                    }
                    break;
                // Gnomes can do a short-range teleport
                case RaceId.Gnome:
                    if (CheckIfRacialPowerWorks(5, 5 + (playerLevel / 5), Ability.Intelligence, 12))
                    {
                        MsgPrint("Blink!");
                        TeleportPlayer(10 + playerLevel);
                    }
                    break;
                // Half-orcs can remove fear
                case RaceId.HalfOrc:
                    if (CheckIfRacialPowerWorks(3, 5, Ability.Wisdom, Player.ProfessionIndex == CharacterClass.Warrior ? 5 : 10))
                    {
                        MsgPrint("You play tough.");
                        Player.SetTimedFear(0);
                    }
                    break;
                // Half-trolls can go berserk, which also heals them
                case RaceId.HalfTroll:
                    if (CheckIfRacialPowerWorks(10, 12, Ability.Wisdom, Player.ProfessionIndex == CharacterClass.Warrior ? 6 : 12))
                    {
                        MsgPrint("RAAAGH!");
                        Player.SetTimedFear(0);
                        Player.SetTimedSuperheroism(Player.TimedSuperheroism + 10 + Program.Rng.DieRoll(playerLevel));
                        Player.RestoreHealth(30);
                    }
                    break;
                // Great ones can heal themselves or swap to a new level
                case RaceId.Great:
                    int dreamPower;
                    while (true)
                    {
                        if (!GetCom("Use Dream [T]ravel or [D]reaming? ", out char ch))
                        {
                            dreamPower = 0;
                            break;
                        }
                        if (ch == 'D' || ch == 'd')
                        {
                            dreamPower = 1;
                            break;
                        }
                        if (ch == 'T' || ch == 't')
                        {
                            dreamPower = 2;
                            break;
                        }
                    }
                    if (dreamPower == 1)
                    {
                        if (CheckIfRacialPowerWorks(40, 75, Ability.Wisdom, 50))
                        {
                            MsgPrint("You dream of a time of health and peace...");
                            Player.SetTimedPoison(0);
                            Player.SetTimedHallucinations(0);
                            Player.SetTimedStun(0);
                            Player.SetTimedBleeding(0);
                            Player.SetTimedBlindness(0);
                            Player.SetTimedFear(0);
                            Player.TryRestoringAbilityScore(Ability.Strength);
                            Player.TryRestoringAbilityScore(Ability.Intelligence);
                            Player.TryRestoringAbilityScore(Ability.Wisdom);
                            Player.TryRestoringAbilityScore(Ability.Dexterity);
                            Player.TryRestoringAbilityScore(Ability.Constitution);
                            Player.TryRestoringAbilityScore(Ability.Charisma);
                            Player.RestoreLevel();
                        }
                    }
                    else if (dreamPower == 2)
                    {
                        if (CheckIfRacialPowerWorks(30, 50, Ability.Intelligence, 50))
                        {
                            MsgPrint("You start walking around. Your surroundings change.");
                            DoCmdSaveGame(true);
                            NewLevelFlag = true;
                            CameFrom = LevelStart.StartRandom;
                        }
                    }
                    break;
                // Tcho-Tcho can create The Yellow Sign
                case RaceId.TchoTcho:
                    if (CheckIfRacialPowerWorks(25, 35, Ability.Intelligence, 15))
                    {
                        MsgPrint("You carefully draw The Yellow Sign...");
                        YellowSign();
                    }
                    break;
                // Hlf-Ogres can go berserk
                case RaceId.HalfOgre:
                    if (CheckIfRacialPowerWorks(8, 10, Ability.Wisdom, Player.ProfessionIndex == CharacterClass.Warrior ? 6 : 12))
                    {
                        MsgPrint("Raaagh!");
                        Player.SetTimedFear(0);
                        Player.SetTimedSuperheroism(Player.TimedSuperheroism + 10 + Program.Rng.DieRoll(playerLevel));
                        Player.RestoreHealth(30);
                    }
                    break;
                // Half-giants can bash through stone walls
                case RaceId.HalfGiant:
                    if (CheckIfRacialPowerWorks(20, 10, Ability.Strength, 12))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You bash at a stone wall.");
                        WallToMud(direction);
                    }
                    break;
                // Half-Titans can probe enemies
                case RaceId.HalfTitan:
                    if (CheckIfRacialPowerWorks(35, 20, Ability.Intelligence, 12))
                    {
                        MsgPrint("You examine your foes...");
                        Probing();
                    }
                    break;
                // Cyclopes can throw boulders
                case RaceId.Cyclops:
                    if (CheckIfRacialPowerWorks(20, 15, Ability.Strength, 12))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You throw a huge boulder.");
                        FireBolt(new ProjectMissile(this), direction,
                            3 * Player.Level / 2);
                    }
                    break;
                // Yeeks can scream
                case RaceId.Yeek:
                    if (CheckIfRacialPowerWorks(15, 15, Ability.Wisdom, 10))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You make a horrible scream!");
                        FearMonster(direction, playerLevel);
                    }
                    break;
                // Klackons can spit acid
                case RaceId.Klackon:
                    if (CheckIfRacialPowerWorks(9, 9, Ability.Dexterity, 14))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You spit acid.");
                        if (Player.Level < 25)
                        {
                            FireBolt(new ProjectAcid(this), direction, playerLevel);
                        }
                        else
                        {
                            FireBall(new ProjectAcid(this), direction, playerLevel,
                                2);
                        }
                    }
                    break;
                // Kobolds can throw poison darts
                case RaceId.Kobold:
                    if (CheckIfRacialPowerWorks(12, 8, Ability.Dexterity, 14))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You throw a dart of poison.");
                        FireBolt(new ProjectPois(this), direction, playerLevel);
                    }
                    break;
                // Nibelungen can detect traps, doors, and stairs
                case RaceId.Nibelung:
                    if (CheckIfRacialPowerWorks(5, 5, Ability.Wisdom, 10))
                    {
                        MsgPrint("You examine your surroundings.");
                        DetectTraps();
                        DetectDoors();
                        DetectStairs();
                    }
                    break;
                // Dark elves can cast magic missile
                case RaceId.DarkElf:
                    if (CheckIfRacialPowerWorks(2, 2, Ability.Intelligence, 9))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You cast a magic missile.");
                        FireBoltOrBeam(10, new ProjectMissile(this),
                            direction, Program.Rng.DiceRoll(3 + ((playerLevel - 1) / 5), 4));
                    }
                    break;
                // Draconians can breathe an element based on their class and level
                case RaceId.Draconian:
                    // Chance of replacing the default fire/cold element with a special one
                    if (Program.Rng.DieRoll(100) < Player.Level)
                    {
                        switch (Player.ProfessionIndex)
                        {
                            case CharacterClass.Warrior:
                            case CharacterClass.Ranger:
                            case CharacterClass.Druid:
                            case CharacterClass.ChosenOne:
                                if (Program.Rng.DieRoll(3) == 1)
                                {
                                    projectile = new ProjectMissile(this);
                                    projectileDescription = "the elements";
                                }
                                else
                                {
                                    projectile = new ProjectExplode(this);
                                    projectileDescription = "shards";
                                }
                                break;

                            case CharacterClass.Mage:
                            case CharacterClass.WarriorMage:
                            case CharacterClass.HighMage:
                            case CharacterClass.Channeler:
                                if (Program.Rng.DieRoll(3) == 1)
                                {
                                    projectile = new ProjectMana(this);
                                    projectileDescription = "mana";
                                }
                                else
                                {
                                    projectile = new ProjectDisenchant(this);
                                    projectileDescription = "disenchantment";
                                }
                                break;

                            case CharacterClass.Fanatic:
                            case CharacterClass.Cultist:
                                if (Program.Rng.DieRoll(3) != 1)
                                {
                                    projectile = new ProjectConfusion(this);
                                    projectileDescription = "confusion";
                                }
                                else
                                {
                                    projectile = new ProjectChaos(this);
                                    projectileDescription = "chaos";
                                }
                                break;

                            case CharacterClass.Monk:
                                if (Program.Rng.DieRoll(3) != 1)
                                {
                                    projectile = new ProjectConfusion(this);
                                    projectileDescription = "confusion";
                                }
                                else
                                {
                                    projectile = new ProjectSound(this);
                                    projectileDescription = "sound";
                                }
                                break;

                            case CharacterClass.Mindcrafter:
                            case CharacterClass.Mystic:
                                if (Program.Rng.DieRoll(3) != 1)
                                {
                                    projectile = new ProjectConfusion(this);
                                    projectileDescription = "confusion";
                                }
                                else
                                {
                                    projectile = new ProjectPsi(this);
                                    projectileDescription = "mental energy";
                                }
                                break;

                            case CharacterClass.Priest:
                            case CharacterClass.Paladin:
                                if (Program.Rng.DieRoll(3) == 1)
                                {
                                    projectile = new ProjectHellFire(this);
                                    projectileDescription = "hellfire";
                                }
                                else
                                {
                                    projectile = new ProjectHolyFire(this);
                                    projectileDescription = "holy fire";
                                }
                                break;

                            case CharacterClass.Rogue:
                                if (Program.Rng.DieRoll(3) == 1)
                                {
                                    projectile = new ProjectDark(this);
                                    projectileDescription = "darkness";
                                }
                                else
                                {
                                    projectile = new ProjectPois(this);
                                    projectileDescription = "poison";
                                }
                                break;
                        }
                    }
                    if (CheckIfRacialPowerWorks(1, Player.Level, Ability.Constitution, 12))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint($"You breathe {projectileDescription}.");
                        FireBall(projectile, direction, Player.Level * 2, -(Player.Level / 15) + 1);
                    }
                    break;
                // Mind Flayers can shoot psychic bolts
                case RaceId.MindFlayer:
                    if (CheckIfRacialPowerWorks(15, 12, Ability.Intelligence, 14))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        MsgPrint("You concentrate and your eyes glow red...");
                        FireBolt(new ProjectPsi(this), direction, playerLevel);
                    }
                    break;
                // Imps can cast fire bolt/ball
                case RaceId.Imp:
                    if (CheckIfRacialPowerWorks(9, 15, Ability.Wisdom, 15))
                    {
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        if (Player.Level >= 30)
                        {
                            MsgPrint("You cast a ball of fire.");
                            FireBall(new ProjectFire(this), direction, playerLevel,
                                2);
                        }
                        else
                        {
                            MsgPrint("You cast a bolt of fire.");
                            FireBolt(new ProjectFire(this), direction, playerLevel);
                        }
                    }
                    break;
                // Golems can harden their skin
                case RaceId.Golem:
                    if (CheckIfRacialPowerWorks(20, 15, Ability.Constitution, 8))
                    {
                        Player.SetTimedStoneskin(Player.TimedStoneskin + Program.Rng.DieRoll(20) + 30);
                    }
                    break;
                // Skeletons and zombies can restore their life energy
                case RaceId.Skeleton:
                case RaceId.Zombie:
                    if (CheckIfRacialPowerWorks(30, 30, Ability.Wisdom, 18))
                    {
                        MsgPrint("You attempt to restore your lost energies.");
                        Player.RestoreLevel();
                    }
                    break;
                // Vampires can drain health
                case RaceId.Vampire:
                    if (CheckIfRacialPowerWorks(2, 1 + (playerLevel / 3), Ability.Constitution, 9))
                    {
                        if (!targetEngine.GetDirectionNoAim(out direction))
                        {
                            break;
                        }
                        int y = Player.MapY + Level.KeypadDirectionYOffset[direction];
                        int x = Player.MapX + Level.KeypadDirectionXOffset[direction];
                        GridTile tile = Level.Grid[y][x];
                        if (tile.MonsterIndex == 0)
                        {
                            MsgPrint("You bite into thin air!");
                            break;
                        }
                        MsgPrint("You grin and bare your fangs...");
                        int dummy = playerLevel + (Program.Rng.DieRoll(playerLevel) * Math.Max(1, playerLevel / 10));
                        if (DrainLife(direction, dummy))
                        {
                            if (Player.Food < Constants.PyFoodFull)
                            {
                                Player.RestoreHealth(dummy);
                            }
                            else
                            {
                                MsgPrint("You were not hungry.");
                            }
                            dummy = Player.Food + Math.Min(5000, 100 * dummy);
                            if (Player.Food < Constants.PyFoodMax)
                            {
                                Player.SetFood(dummy >= Constants.PyFoodMax ? Constants.PyFoodMax - 1 : dummy);
                            }
                        }
                        else
                        {
                            MsgPrint("Yechh. That tastes foul.");
                        }
                    }
                    break;
                // Spectres can howl
                case RaceId.Spectre:
                    if (CheckIfRacialPowerWorks(4, 6, Ability.Intelligence, 3))
                    {
                        MsgPrint("You emit an eldritch howl!");
                        if (!targetEngine.GetDirectionWithAim(out direction))
                        {
                            break;
                        }
                        FearMonster(direction, playerLevel);
                    }
                    break;
                // Sprites can sleep monsters
                case RaceId.Sprite:
                    if (CheckIfRacialPowerWorks(12, 12, Ability.Intelligence, 15))
                    {
                        MsgPrint("You throw some magic dust...");
                        if (Player.Level < 25)
                        {
                            SleepMonstersTouch();
                        }
                        else
                        {
                            SleepMonsters();
                        }
                    }
                    break;
                // Other races don't have powers
                default:
                    MsgPrint("This race has no bonus power.");
                    EnergyUse = 0;
                    break;
            }
            Player.RedrawNeeded.Set(RedrawFlag.PrHp | RedrawFlag.PrMana);
        }

        /// <summary>
        /// React to having walked into a door by trying to open it
        /// </summary>
        /// <param name="y"> The y coordinate of the door tile </param>
        /// <param name="x"> The x coordinate of the door tile </param>
        /// <returns> True if we opened it, false otherwise </returns>
        private bool EasyOpenDoor(int y, int x)
        {
            GridTile tile = Level.Grid[y][x];
            // If it isn't closed, we can't open it
            if (!tile.FeatureType.IsClosedDoor)
            {
                return false;
            }
            // If it's jammed we'll need to bash it
            if (tile.FeatureType.Name.Contains("Jammed"))
            {
                MsgPrint("The door appears to be stuck.");
            }
            // Most doors are locked, so try to pick the lock
            else if (!tile.FeatureType.Name.Contains("0"))
            {
                int skill = Player.SkillDisarmTraps;
                // Lockpicking is hard in the dark
                if (Player.TimedBlindness != 0 || Level.NoLight())
                {
                    skill /= 10;
                }
                // Lockpicking is hard when you're confused
                if (Player.TimedConfusion != 0 || Player.TimedHallucinations != 0)
                {
                    skill /= 10;
                }
                int chance = int.Parse(tile.FeatureType.Name.Substring(10));
                chance = skill - (chance * 4);
                if (chance < 2)
                {
                    chance = 2;
                }
                // See if we succeed
                if (Program.Rng.RandomLessThan(100) < chance)
                {
                    MsgPrint("You have picked the lock.");
                    Level.CaveSetFeat(y, x, "OpenDoor");
                    Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateMonsters);
                    PlaySound(SoundEffect.LockpickSuccess);
                    Player.GainExperience(1);
                }
                // If we failed, simply let us know
                else
                {
                    MsgPrint("You failed to pick the lock.");
                }
            }
            // It wasn't locked, so simply open it
            else
            {
                Level.CaveSetFeat(y, x, "OpenDoor");
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateMonsters);
                PlaySound(SoundEffect.OpenDoor);
            }
            return true;
        }

        /// <summary>
        /// Determine if a player's attack hits a monster
        /// </summary>
        /// <param name="power"> The strength of the attack </param>
        /// <param name="armourClass"> The monster's armour class </param>
        /// <param name="isVisible"> Whether or not the monster is visible </param>
        /// <returns> True if the attack hit, false if not </returns>
        private bool PlayerCheckHitOnMonster(int power, int armourClass, bool isVisible)
        {
            // Always have a 5% chance to hit or miss
            int roll = Program.Rng.RandomLessThan(100);
            if (roll < 10)
            {
                return roll < 5;
            }
            if (power <= 0)
            {
                return false;
            }
            // It's hard to hit invisible monsters
            if (!isVisible)
            {
                power = (power + 1) / 2;
            }
            // Work out whether we hit or not
            return Program.Rng.RandomLessThan(power) >= armourClass * 3 / 4;
        }

        /// <summary>
        /// Work out the level of critical hit the player did in melee
        /// </summary>
        /// <param name="weight"> The weight of the player's weapon </param>
        /// <param name="plus"> The bonuses to hit the player has </param>
        /// <param name="damage"> The amount of base damage that was done </param>
        /// <returns> The damage total modified for a critical hit </returns>
        private int PlayerCriticalMelee(int weight, int plus, int damage)
        {
            int i = weight + ((Player.AttackBonus + plus) * 5) + (Player.Level * 3);
            if (Program.Rng.DieRoll(5000) <= i)
            {
                int k = weight + Program.Rng.DieRoll(650);
                if (k < 400)
                {
                    MsgPrint("It was a good hit!");
                    damage = (2 * damage) + 5;
                }
                else if (k < 700)
                {
                    MsgPrint("It was a great hit!");
                    damage = (2 * damage) + 10;
                }
                else if (k < 900)
                {
                    MsgPrint("It was a superb hit!");
                    damage = (3 * damage) + 15;
                }
                else if (k < 1300)
                {
                    MsgPrint("It was a *GREAT* hit!");
                    damage = (3 * damage) + 20;
                }
                else
                {
                    MsgPrint("It was a *SUPERB* hit!");
                    damage = (7 * damage / 2) + 25;
                }
            }
            return damage;
        }

        /// <summary>
        /// Resolve a natural attack the player has from a mutation
        /// </summary>
        /// <param name="monsterIndex"> The monster being attacked </param>
        /// <param name="mutation"> The mutation being used to attack </param>
        /// <param name="fear"> Whether or not the monster is scared by the attack </param>
        /// <param name="monsterDies"> Whether or not the monster is killed by the attack </param>
        private void PlayerNaturalAttackOnMonster(int monsterIndex, Mutation mutation, out bool fear, out bool monsterDies)
        {
            fear = false;
            monsterDies = false;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            int damageSides = mutation.DamageDiceSize;
            int damageDice = mutation.DamageDiceNumber;
            int effectiveWeight = mutation.EquivalentWeaponWeight;
            string attackDescription = mutation.AttackDescription;
            string monsterName = monster.MonsterDesc(0);
            // See if the player hit the monster
            int bonus = Player.AttackBonus;
            int chance = Player.SkillMelee + (bonus * Constants.BthPlusAdj);
            if (PlayerCheckHitOnMonster(chance, race.ArmourClass, monster.IsVisible))
            {
                // It was a hit, so let the player know
                PlaySound(SoundEffect.MeleeHit);
                MsgPrint($"You hit {monsterName} with your {attackDescription}.");
                // Roll the damage, with possible critical damage
                int damage = Program.Rng.DiceRoll(damageDice, damageSides);
                damage = PlayerCriticalMelee(effectiveWeight, Player.AttackBonus, damage);
                damage += Player.DamageBonus;
                // Can't have negative damage
                if (damage < 0)
                {
                    damage = 0;
                }
                // If it's a friend, it will get angry
                if ((monster.Mind & Constants.SmFriendly) != 0)
                {
                    MsgPrint($"{monsterName} gets angry!");
                    monster.Mind &= ~Constants.SmFriendly;
                }
                // Apply damage of the correct type to the monster
                switch (mutation.MutationAttackType)
                {
                    case MutationAttackType.Physical:
                        monsterDies = Level.Monsters.DamageMonster(monsterIndex, damage, out fear, null);
                        break;

                    case MutationAttackType.Poison:
                        Project(0, 0, monster.MapY, monster.MapX, damage,
                            new ProjectPois(this), ProjectionFlag.ProjectKill);
                        break;

                    case MutationAttackType.Hellfire:
                        Project(0, 0, monster.MapY, monster.MapX, damage,
                            new ProjectHellFire(this), ProjectionFlag.ProjectKill);
                        break;
                }
                // The monster might hurt when we touch it
                TouchZapPlayer(monster);
            }
            else
            {
                // We missed, so just let us know
                PlaySound(SoundEffect.Miss);
                MsgPrint($"You miss {monsterName}.");
            }
        }

        /// <summary>
        /// Remove a tile by tunnelling through it
        /// </summary>
        /// <param name="y"> The y coordinate of the tile </param>
        /// <param name="x"> The x coordinate of the tile </param>
        /// <returns> True if the tunnel succeeded, false if not </returns>
        private bool RemoveTileViaTunnelling(int y, int x)
        {
            GridTile tile = Level.Grid[y][x];
            // If we can already get through it, we can't tunnel through it
            if (Level.GridPassable(y, x))
            {
                return false;
            }
            // Clear the tile
            tile.TileFlags.Clear(GridTile.PlayerMemorised);
            Level.RevertTileToBackground(y, x);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateMonsters);
            return true;
        }

        /// <summary>
        /// Handle the player stepping on a trap
        /// </summary>
        private void StepOnTrap()
        {
            int damage;
            string name = "a trap";
            Disturb(false);
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            // Check the type of trap
            switch (tile.FeatureType.Name)
            {
                case "TrapDoor":
                    {
                        // Trap doors can be flown over with feather fall
                        if (Player.HasFeatherFall)
                        {
                            MsgPrint("You fly over a trap door.");
                        }
                        else
                        {
                            MsgPrint("You fell through a trap door!");
                            // Trap doors do 2d8 fall damage
                            damage = Program.Rng.DiceRoll(2, 8);
                            name = "a trap door";
                            Player.TakeHit(damage, name);
                            // Even if we survived, we need a new level
                            if (Player.Health >= 0)
                            {
                                DoCmdSaveGame(true);
                            }
                            NewLevelFlag = true;
                            // In dungeons we fall to a deeper level, but in towers we fall to a
                            // shallower level because they go up instead of down
                            if (CurDungeon.Tower)
                            {
                                CurrentDepth--;
                            }
                            else
                            {
                                CurrentDepth++;
                            }
                        }
                        break;
                    }
                case "Pit":
                    {
                        // A pit can be flown over with feather fall
                        if (Player.HasFeatherFall)
                        {
                            MsgPrint("You fly over a pit trap.");
                        }
                        else
                        {
                            MsgPrint("You fell into a pit!");
                            // Pits do 2d6 fall damage
                            damage = Program.Rng.DiceRoll(2, 6);
                            name = "a pit trap";
                            Player.TakeHit(damage, name);
                        }
                        break;
                    }
                case "SpikedPit":
                    {
                        // A pit can be flown over with feather fall
                        if (Player.HasFeatherFall)
                        {
                            MsgPrint("You fly over a spiked pit.");
                        }
                        else
                        {
                            MsgPrint("You fall into a spiked pit!");
                            name = "a pit trap";
                            // A pit does 2d6 fall damage
                            damage = Program.Rng.DiceRoll(2, 6);
                            // 50% chance of doing double damage plus bleeding
                            if (Program.Rng.RandomLessThan(100) < 50)
                            {
                                MsgPrint("You are impaled!");
                                name = "a spiked pit";
                                damage *= 2;
                                Player.SetTimedBleeding(Player.TimedBleeding + Program.Rng.DieRoll(damage));
                            }
                            Player.TakeHit(damage, name);
                        }
                        break;
                    }
                case "PoisonPit":
                    {
                        // A pit can be flown over with feather fall
                        if (Player.HasFeatherFall)
                        {
                            MsgPrint("You fly over a spiked pit.");
                        }
                        else
                        {
                            MsgPrint("You fall into a spiked pit!");
                            // A pit does 2d6 fall damage
                            damage = Program.Rng.DiceRoll(2, 6);
                            name = "a pit trap";
                            // 50% chance of doing double damage plus bleeding plus poison
                            if (Program.Rng.RandomLessThan(100) < 50)
                            {
                                MsgPrint("You are impaled on poisonous spikes!");
                                name = "a spiked pit";
                                damage *= 2;
                                Player.SetTimedBleeding(Player.TimedBleeding + Program.Rng.DieRoll(damage));
                                // Hagarg Ryonis can save us from the poison
                                if (Player.HasPoisonResistance || Player.TimedPoisonResistance != 0)
                                {
                                    MsgPrint("The poison does not affect you!");
                                }
                                else if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    damage *= 2;
                                    Player.SetTimedPoison(Player.TimedPoison + Program.Rng.DieRoll(damage));
                                }
                            }
                            Player.TakeHit(damage, name);
                        }
                        break;
                    }
                case "SummonRune":
                    {
                        MsgPrint("There is a flash of shimmering light!");
                        // Trap disappears when triggered
                        tile.TileFlags.Clear(GridTile.PlayerMemorised);
                        Level.RevertTileToBackground(Player.MapY, Player.MapX);
                        // Summon 1d3+2 monsters
                        int num = 2 + Program.Rng.DieRoll(3);
                        for (int i = 0; i < num; i++)
                        {
                            Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, 0);
                        }
                        // Have a chance of also cursing the player
                        if (Difficulty > Program.Rng.DieRoll(100))
                        {
                            do
                            {
                                ActivateDreadCurse();
                            } while (Program.Rng.DieRoll(6) == 1);
                        }
                        break;
                    }
                case "TeleportRune":
                    {
                        // Teleport the player up to 100 squares
                        MsgPrint("You hit a teleport trap!");
                        TeleportPlayer(100);
                        break;
                    }
                case "FireTrap":
                    {
                        // Do 4d6 fire damage
                        MsgPrint("You are enveloped in flames!");
                        damage = Program.Rng.DiceRoll(4, 6);
                        FireDam(damage, "a fire trap");
                        break;
                    }
                case "AcidTrap":
                    {
                        // Do 4d6 acid damage
                        MsgPrint("You are splashed with acid!");
                        damage = Program.Rng.DiceRoll(4, 6);
                        AcidDam(damage, "an acid trap");
                        break;
                    }
                case "SlowDart":
                    {
                        // Dart traps need a to-hit roll
                        if (TrapCheckHitOnPlayer(125))
                        {
                            MsgPrint("A small dart hits you!");
                            // Do 1d4 damage plus slow
                            damage = Program.Rng.DiceRoll(1, 4);
                            Player.TakeHit(damage, name);
                            Player.SetTimedSlow(Player.TimedSlow + Program.Rng.RandomLessThan(20) + 20);
                        }
                        else
                        {
                            MsgPrint("A small dart barely misses you.");
                        }
                        break;
                    }
                case "StrDart":
                    {
                        // Dart traps need a to-hit roll
                        if (TrapCheckHitOnPlayer(125))
                        {
                            MsgPrint("A small dart hits you!");
                            // Do 1d4 damage plus strength drain
                            damage = Program.Rng.DiceRoll(1, 4);
                            Player.TakeHit(damage, "a dart trap");
                            Player.TryDecreasingAbilityScore(Ability.Strength);
                        }
                        else
                        {
                            MsgPrint("A small dart barely misses you.");
                        }
                        break;
                    }
                case "DexDart":
                    {
                        // Dart traps need a to-hit roll
                        if (TrapCheckHitOnPlayer(125))
                        {
                            MsgPrint("A small dart hits you!");
                            // Do 1d4 damage plus dexterity drain
                            damage = Program.Rng.DiceRoll(1, 4);
                            Player.TakeHit(damage, "a dart trap");
                            Player.TryDecreasingAbilityScore(Ability.Dexterity);
                        }
                        else
                        {
                            MsgPrint("A small dart barely misses you.");
                        }
                        break;
                    }
                case "ConDart":
                    {
                        // Dart traps need a to-hit roll
                        if (TrapCheckHitOnPlayer(125))
                        {
                            MsgPrint("A small dart hits you!");
                            // Do 1d4 damage plus constitution drain
                            damage = Program.Rng.DiceRoll(1, 4);
                            Player.TakeHit(damage, "a dart trap");
                            Player.TryDecreasingAbilityScore(Ability.Constitution);
                        }
                        else
                        {
                            MsgPrint("A small dart barely misses you.");
                        }
                        break;
                    }
                case "BlindGas":
                    {
                        // Blind the player
                        MsgPrint("A black gas surrounds you!");
                        if (!Player.HasBlindnessResistance)
                        {
                            Player.SetTimedBlindness(Player.TimedBlindness + Program.Rng.RandomLessThan(50) + 25);
                        }
                        break;
                    }
                case "ConfuseGas":
                    {
                        // Confuse the player
                        MsgPrint("A gas of scintillating colours surrounds you!");
                        if (!Player.HasConfusionResistance)
                        {
                            Player.SetTimedConfusion(Player.TimedConfusion + Program.Rng.RandomLessThan(20) + 10);
                        }
                        break;
                    }
                case "PoisonGas":
                    {
                        // Poison the player
                        MsgPrint("A pungent green gas surrounds you!");
                        if (!Player.HasPoisonResistance && Player.TimedPoisonResistance == 0)
                        {
                            // Hagarg Ryonis may save you from the poison
                            if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                            {
                                MsgPrint("Hagarg Ryonis's favour protects you!");
                            }
                            else
                            {
                                Player.SetTimedPoison(Player.TimedPoison + Program.Rng.RandomLessThan(20) + 10);
                            }
                        }
                        break;
                    }
                case "SleepGas":
                    {
                        // Paralyse the player
                        MsgPrint("A strange white mist surrounds you!");
                        if (!Player.HasFreeAction)
                        {
                            Player.SetTimedParalysis(Player.TimedParalysis + Program.Rng.RandomLessThan(10) + 5);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Check to see if a monster has damaging aura, and if so damage the player with it
        /// </summary>
        /// <param name="monster"> The monster to check </param>
        private void TouchZapPlayer(Monster monster)
        {
            int auraDamage;
            MonsterRace race = monster.Race;
            // If we have a fire aura, apply it
            if ((race.Flags2 & MonsterFlag2.FireAura) != 0)
            {
                if (!Player.HasFireImmunity)
                {
                    auraDamage = Program.Rng.DiceRoll(1 + (race.Level / 26), 1 + (race.Level / 17));
                    string auraDam = monster.MonsterDesc(0x88);
                    MsgPrint("You are suddenly very hot!");
                    if (Player.TimedFireResistance != 0)
                    {
                        auraDamage = (auraDamage + 2) / 3;
                    }
                    if (Player.HasFireResistance)
                    {
                        auraDamage = (auraDamage + 2) / 3;
                    }
                    Player.TakeHit(auraDamage, auraDam);
                    race.Knowledge.RFlags2 |= MonsterFlag2.FireAura;
                    HandleStuff();
                }
            }
            // If we have a lightning aura, apply it
            if ((race.Flags2 & MonsterFlag2.LightningAura) != 0 && !Player.HasLightningImmunity)
            {
                auraDamage = Program.Rng.DiceRoll(1 + (race.Level / 26), 1 + (race.Level / 17));
                string auraDam = monster.MonsterDesc(0x88);
                if (Player.TimedLightningResistance != 0)
                {
                    auraDamage = (auraDamage + 2) / 3;
                }
                if (Player.HasLightningResistance)
                {
                    auraDamage = (auraDamage + 2) / 3;
                }
                MsgPrint("You get zapped!");
                Player.TakeHit(auraDamage, auraDam);
                race.Knowledge.RFlags2 |= MonsterFlag2.LightningAura;
                HandleStuff();
            }
        }

        /// <summary>
        /// Check to see if a trap hits a player
        /// </summary>
        /// <param name="attackStrength"> The power of the trap's attack </param>
        /// <returns> True if the player was hit, false otherwise </returns>
        private bool TrapCheckHitOnPlayer(int attackStrength)
        {
            // Always a 5% chance to hit and 5% chance to miss
            int k = Program.Rng.RandomLessThan(100);
            if (k < 10)
            {
                return k < 5;
            }
            // If negative chance we miss
            if (attackStrength <= 0)
            {
                return false;
            }
            // Roll for the attack
            int armourClass = Player.BaseArmourClass + Player.ArmourClassBonus;
            return Program.Rng.DieRoll(attackStrength) > armourClass * 3 / 4;
        }

        // Artificial Intelligence
        /// <summary>
        /// Process all the monsters on the level
        /// </summary>
        public void ProcessAllMonsters()
        {
            // The noise the player is making is based on their stealth score
            uint noise = 1u << (30 - Player.SkillStealth);
            // Go through all the monster slots on the level
            for (int i = Level.MMax - 1; i >= 1; i--)
            {
                Monster monster = Level.Monsters[i];
                // If the monster slot is empty, skip it
                if (monster.Race == null)
                {
                    continue;
                }
                // Keep count of how many are our friends
                if ((monster.Mind & Constants.SmFriendly) != 0)
                {
                    TotalFriends++;
                    TotalFriendLevels += monster.Race.Level;
                }
                // Monsters that have just been spawned don't act in their first turn
                if ((monster.IndividualMonsterFlags & Constants.MflagBorn) != 0)
                {
                    monster.IndividualMonsterFlags &= ~Constants.MflagBorn;
                    continue;
                }
                // Check the monster's speed to see if it should get a turn
                monster.Energy += GlobalData.ExtractEnergy[monster.Speed];
                if (monster.Energy < 100)
                {
                    continue;
                }
                // The monster is going to take a turn, even if it does nothing
                monster.Energy -= 100;
                // If the monster is too far away, don't even bother
                if (monster.DistanceFromPlayer >= 100)
                {
                    continue;
                }
                MonsterRace race = monster.Race;
                int monsterX = monster.MapX;
                int monsterY = monster.MapY;
                bool test = false;
                // Check to see if the monster notices the player
                // 1) We're in range
                if (monster.DistanceFromPlayer <= race.NoticeRange)
                {
                    test = true;
                }
                // 2) We're aggravating
                else if (monster.DistanceFromPlayer <= Constants.MaxSight && (Level.PlayerHasLosBold(monsterY, monsterX) || Player.HasAggravation))
                {
                    test = true;
                }
                // 3) We've left scent where the monster is so it can smell us
                else if (Level.Grid[Player.MapY][Player.MapX].ScentAge == Level.Grid[monsterY][monsterX].ScentAge &&
                         Level.Grid[monsterY][monsterX].ScentStrength < Constants.MonsterFlowDepth &&
                         Level.Grid[monsterY][monsterX].ScentStrength < race.NoticeRange)
                {
                    test = true;
                }
                // If it didn't notice us, skip to the next monster
                if (!test)
                {
                    continue;
                }
                Level.Monsters.CurrentlyActingMonster = i;
                // Process the individual monster
                monster.ProcessMonster(this, noise);
                // If the monster killed the player or sent us to a new level, then stop processing
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
            }
            Level.Monsters.CurrentlyActingMonster = 0;
        }

        /// <summary>
        /// Use the same algorithm that we use for missiles to see if we have a clean shot between
        /// two locations, but without actually shooting anything
        /// </summary>
        /// <param name="startY"> The start Y </param>
        /// <param name="startX"> The start X </param>
        /// <param name="targetY"> The Target Y </param>
        /// <param name="targetX"> The Target X </param>
        /// <returns> </returns>
        public bool CleanShot(int startY, int startX, int targetY, int targetX)
        {
            int y = startY;
            int x = startX;
            // Loop from the start to the maximumm range allowed
            for (int distance = 0; distance <= Constants.MaxRange; distance++)
            {
                // If our location is blocked, give up
                if (distance != 0 && !Level.GridPassable(y, x))
                {
                    break;
                }
                // If there's another monster in the way and it is friendly, give up
                if (distance != 0 && Level.Grid[y][x].MonsterIndex > 0)
                {
                    if ((Level.Monsters[Level.Grid[y][x].MonsterIndex].Mind & Constants.SmFriendly) == 0)
                    {
                        break;
                    }
                }
                // If we've reached the target then we have a clean shot
                if (x == targetX && y == targetY)
                {
                    return true;
                }
                // Move closer
                Level.MoveOneStepTowards(out y, out x, y, x, startY, startX, targetY, targetX);
            }
            // If we gave up or ran out of distance we don't have a clean shot
            return false;
        }

        /// <summary>
        /// Check whether there's room to summon something next to a location
        /// </summary>
        /// <param name="targetY"> The target Y coordinate </param>
        /// <param name="targetX"> The target X coordinate </param>
        /// <returns> True if there is room, or false if there is not </returns>
        public bool SummonPossible(int targetY, int targetX)
        {
            int y;
            for (y = targetY - 2; y <= targetY + 2; y++)
            {
                int x;
                for (x = targetX - 2; x <= targetX + 2; x++)
                {
                    // Can't summon out of bounds
                    if (!Level.InBounds(y, x))
                    {
                        continue;
                    }
                    // Can't summon too far away from the target location
                    if (Level.Distance(targetY, targetX, y, x) > 2)
                    {
                        continue;
                    }
                    // Can't summon onto an Elder Sign
                    if (Level.Grid[y][x].FeatureType.Name == "ElderSign")
                    {
                        continue;
                    }
                    // Can't summon onto a Yellow Sign
                    if (Level.Grid[y][x].FeatureType.Name == "YellowSign")
                    {
                        continue;
                    }
                    // An empty tile in line of sight is acceptable
                    if (Level.GridPassableNoCreature(y, x) && Level.Los(targetY, targetX, y, x))
                    {
                        return true;
                    }
                }
            }
            // We didn't find anywhere and ran out of places to look
            return false;
        }

        /// GUI
        /// <summary>
        /// Sets or returns whether the cursor is visible
        /// </summary>
        public bool CursorVisible
        {
            get => Scr.CursorVisible;
            set => Scr.CursorVisible = value;
        }

        /// <summary>
        /// Prints a 'press any key' message and waits for a key press
        /// </summary>
        /// <param name="row"> The row on which to print the message </param>
        public void AnyKey(int row)
        {
            PrintLine("", row, 0);
            Print(Colour.Orange, "[Press any key to continue]", row, 27);
            Inkey();
            PrintLine("", row, 0);
        }

        public bool AskforAux(out string buf, string initial, int len)
        {
            buf = initial;
            char i = '\0';
            int k = 0;
            bool done = false;
            Locate(out int y, out int x);
            if (len < 1)
            {
                len = 1;
            }
            if (x < 0 || x >= Constants.ConsoleWidth)
            {
                x = 0;
            }
            if (x + len > Constants.ConsoleWidth)
            {
                len = Constants.ConsoleWidth - x;
            }
            Erase(y, x, len);
            Print(Colour.Grey, buf, y, x);
            while (!done)
            {
                Goto(y, x + k);
                i = Inkey();
                switch (i)
                {
                    case '\x1b':
                        k = 0;
                        done = true;
                        break;

                    case '\n':
                    case '\r':
                        k = buf.Length;
                        done = true;
                        break;

                    case (char)8:
                        if (k > 0)
                        {
                            k--;
                        }
                        buf = buf.Substring(0, k);
                        break;

                    default:
                        if (k < len && (char.IsLetterOrDigit(i) || i == ' ' || char.IsPunctuation(i)))
                        {
                            buf = buf.Substring(0, k) + i;
                            k++;
                        }
                        break;
                }
                Erase(y, x, len);
                Print(Colour.Black, buf, y, x);
            }
            return i != '\x1b';
        }

        /// <summary>
        /// Clears the screen from the specified row downwards
        /// </summary>
        /// <param name="row"> The first row to clear </param>
        public void Clear(int row)
        {
            for (int y = row; y < Height; y++)
            {
                Erase(y, 0, 255);
            }
        }

        /// <summary>
        /// Clears the entire screen
        /// </summary>
        public void Clear()
        {
            int w = Width;
            int h = Height;
            Colour na = AttrBlank;
            char nc = CharBlank;
            Scr.Cu = false;
            Scr.Cx = 0;
            Scr.Cy = 0;
            for (int y = 0; y < h; y++)
            {
                int scrAa = Scr.A[y];
                int scrCc = Scr.C[y];
                for (int x = 0; x < w; x++)
                {
                    Scr.Va[scrAa + x] = na;
                    Scr.Vc[scrCc + x] = nc;
                }
                X1[y] = 0;
                X2[y] = w - 1;
            }
            Y1 = 0;
            Y2 = h - 1;
            TotalErase = true;
        }

        /// <summary>
        /// Erases a number of characters on the screen
        /// </summary>
        /// <param name="row"> The row position of the first character </param>
        /// <param name="col"> The column position of the first character </param>
        /// <param name="length"> The number of characters to erase </param>
        public void Erase(int row, int col, int length)
        {
            int w = Width;
            int x1 = -1;
            int x2 = -1;
            Colour na = AttrBlank;
            char nc = CharBlank;
            Goto(row, col);
            if (col + length > w)
            {
                length = w - col;
            }
            int scrAa = Scr.A[row];
            int scrCc = Scr.C[row];
            for (int i = 0; i < length; i++, col++)
            {
                Colour oa = Scr.Va[scrAa + col];
                int oc = Scr.Vc[scrCc + col];
                if (oa == na && oc == nc)
                {
                    continue;
                }
                Scr.Va[scrAa + col] = na;
                Scr.Vc[scrCc + col] = nc;
                if (x1 < 0)
                {
                    x1 = col;
                }
                x2 = col;
            }
            if (x1 >= 0)
            {
                if (row < Y1)
                {
                    Y1 = row;
                }
                if (row > Y2)
                {
                    Y2 = row;
                }
                if (x1 < X1[row])
                {
                    X1[row] = x1;
                }
                if (x2 > X2[row])
                {
                    X2[row] = x2;
                }
            }
        }

        public bool GetCheck(string prompt)
        {
            int i;
            MsgPrint(null);
            string buf = $"{prompt}[Y/n]";
            PrintLine(buf, 0, 0);
            while (true)
            {
                i = Inkey();
                switch (i)
                {
                    case 'y':
                    case 'Y':
                    case 'n':
                    case 'N':
                    case 13:
                    case 27:
                        break;

                    default:
                        continue;
                }
                break;
            }
            PrintLine("", 0, 0);
            return i == 'Y' || i == 'y' || i == 13;
        }

        public bool GetCom(string prompt, out char command)
        {
            MsgPrint(null);
            if (prompt.Length > 1)
            {
                prompt = char.ToUpper(prompt[0]) + prompt.Substring(1);
            }
            PrintLine(prompt, 0, 0);
            command = Inkey();
            PrintLine("", 0, 0);
            return command != '\x1b';
        }

        public int GetKeymapDir(char ch)
        {
            int d = 0;
            string act = _keymapAct[Constants.KeymapModeOrig][ch];
            while (true)
            {
                if (act.Length == 0)
                {
                    return 0;
                }
                if (act[0] >= '1' && act[0] <= '9')
                {
                    break;
                }
                act = act.Remove(0, 1);
            }
            if (!string.IsNullOrEmpty(act))
            {
                if (!int.TryParse(act, out d))
                {
                    d = 0;
                }
            }
            return d;
        }

        public int GetQuantity(string prompt, int max, bool allbydefault)
        {
            int amt;
            if (CommandArgument != 0)
            {
                amt = CommandArgument;
                CommandArgument = 0;
                if (amt > max)
                {
                    amt = max;
                }
                return amt;
            }
            if (string.IsNullOrEmpty(prompt))
            {
                string tmp = $"Quantity (1-{max}): ";
                prompt = tmp;
            }
            amt = 1;
            if (allbydefault)
            {
                amt = max;
            }
            string def = amt.ToString();
            if (!GetString(prompt, out string buf, def, 6))
            {
                return 0;
            }
            if (int.TryParse(buf, out int test))
            {
                amt = test;
            }
            if (string.IsNullOrEmpty(buf))
            {
                amt = max;
            }
            else if (char.IsLetter(buf[0]))
            {
                amt = max;
            }
            if (amt > max)
            {
                amt = max;
            }
            if (amt < 0)
            {
                amt = 0;
            }
            return amt;
        }

        public bool GetString(string prompt, out string buf, string initial, int len)
        {
            MsgPrint(null);
            PrintLine(prompt, 0, 0);
            bool res = AskforAux(out buf, initial, len);
            PrintLine("", 0, 0);
            return res;
        }

        /// <summary>
        /// Moves the cursor and print location to a new position
        /// </summary>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void Goto(int row, int col)
        {
            int w = Width;
            int h = Height;
            if (col < 0 || col >= w)
            {
                return;
            }
            if (row < 0 || row >= h)
            {
                return;
            }
            Scr.Cx = col;
            Scr.Cy = row;
            Scr.Cu = false;
        }

        /// <summary>
        /// Returns the next keypress. The behaviour of this function is modified by other class properties
        /// </summary>
        /// <returns> The next key pressed </returns>
        public char Inkey()
        {
            char ch = '\0';
            bool done = false;
            if (!string.IsNullOrEmpty(_keyBuffer))
            {
                ch = _keyBuffer[0];
                _keyBuffer = _keyBuffer.Remove(0, 1);
                HideCursorOnFullScreenInkey = false;
                DoNotWaitOnInkey = false;
                return ch;
            }
            _keyBuffer = null;
            bool v = CursorVisible;
            if (!DoNotWaitOnInkey && (!HideCursorOnFullScreenInkey || FullScreenOverlay))
            {
                CursorVisible = true;
            }
            if (InPopupMenu)
            {
                CursorVisible = false;
            }
            while (ch == 0)
            {
                if (DoNotWaitOnInkey && GetKeypress(out char kk, false, false))
                {
                    ch = kk;
                    break;
                }
                if (!done && GetKeypress(out _, false, false))
                {
                    UpdateScreen();
                    done = true;
                }
                if (DoNotWaitOnInkey)
                {
                    break;
                }
                GetKeypress(out ch, true, true);
                if (ch == 29)
                {
                    ch = '\0';
                    continue;
                }
                if (ch == '`')
                {
                    ch = '\x1b';
                }
                if (ch == 30)
                {
                    ch = '\0';
                }
            }
            CursorVisible = v;
            HideCursorOnFullScreenInkey = false;
            DoNotWaitOnInkey = false;
            return ch;
        }

        /// <summary>
        /// Re-loads the saved screen to the GUI
        /// </summary>
        public void Load()
        {
            int w = Width;
            int h = Height;
            if (Mem == null)
            {
                Mem = new Screen(w, h);
            }
            Scr.Copy(Mem, w, h);
            for (int y = 0; y < h; y++)
            {
                X1[y] = 0;
                X2[y] = w - 1;
            }
            Y1 = 0;
            Y2 = h - 1;
        }

        /// <summary>
        /// Pauses for a duration
        /// </summary>
        /// <param name="duration"> The duration of the pause, in milliseconds </param>
        public void Pause(int duration)
        {
            Thread.Sleep(duration);
        }

        /// <summary>
        /// Places a character without moving the text position
        /// </summary>
        /// <param name="attr"> The colour to use for the character </param>
        /// <param name="ch"> The character to place </param>
        /// <param name="row"> The row at which to place the character </param>
        /// <param name="col"> The column at which to place the character </param>
        public void Place(Colour attr, char ch, int row, int col)
        {
            int w = Width;
            int h = Height;
            if (col < 0 || col >= w)
            {
                return;
            }
            if (row < 0 || row >= h)
            {
                return;
            }
            if (ch == 0)
            {
                return;
            }
            QueueCharacter(col, row, attr, ch);
        }

        /// <summary>
        /// Plays a sound
        /// </summary>
        /// <param name="val"> The sound to play </param>
        public void PlaySound(SoundEffect sound)
        {
            _console.PlaySound(sound);
        }

        /// <summary>
        /// Prints a character at the current cursor position
        /// </summary>
        /// <param name="attr"> The colour in which to print the character </param>
        /// <param name="ch"> The character to print </param>
        public void Print(Colour attr, char ch)
        {
            int w = Width;
            if (Scr.Cu)
            {
                return;
            }
            if (ch == 0)
            {
                return;
            }
            QueueCharacter(Scr.Cx, Scr.Cy, attr, ch);
            Scr.Cx++;
            if (Scr.Cx < w)
            {
                return;
            }
            Scr.Cu = true;
        }

        /// <summary>
        /// Prints a character at a given location
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="ch"> The character to print </param>
        /// <param name="row"> The y position at which to print </param>
        /// <param name="col"> The x position at which to print </param>
        public void Print(Colour attr, char ch, int row, int col)
        {
            Goto(row, col);
            Print(attr, ch);
        }

        /// <summary>
        /// Prints a string at the current location
        /// </summary>
        /// <param name="attr"> The colour in which to print the string </param>
        /// <param name="str"> The string to print </param>
        /// <param name="length"> The number of characters to print (-1 for all) </param>
        public void Print(Colour attr, string str, int length)
        {
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            int w = Width;
            int res = 0;
            int len = str.Length;
            if (Scr.Cu)
            {
                return;
            }
            int k = length < 0 ? w + 1 : length;
            for (length = 0; length < k && length < len; length++)
            {
            }
            if (Scr.Cx + length >= w)
            {
                res = w - Scr.Cx;
                length = w - Scr.Cx;
            }
            QueueCharacters(Scr.Cx, Scr.Cy, length, attr, str);
            Scr.Cx += length;
            if (res != 0)
            {
                Scr.Cu = true;
            }
        }

        /// <summary>
        /// Prints a string at a given location
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The y position at which to print the string </param>
        /// <param name="col"> The x position at which to print the string </param>
        /// <param name="length"> The number of characters to print (-1 for all) </param>
        public void Print(Colour attr, string str, int row, int col, int length)
        {
            Goto(row, col);
            Print(attr, str, length);
        }

        /// <summary>
        /// Prints a string at a given location
        /// </summary>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void Print(string str, int row, int col)
        {
            Goto(row, col);
            Print(Colour.White, str, -1);
        }

        /// <summary>
        /// Prints a string
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void Print(Colour attr, string str, int row, int col)
        {
            Goto(row, col);
            Print(attr, str, -1);
        }

        /// <summary>
        /// Print a string, wiping the rest of the line
        /// </summary>
        /// <param name="attr"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void PrintLine(Colour attr, string str, int row, int col)
        {
            Erase(row, col, 255);
            Print(attr, str, -1);
        }

        /// <summary>
        /// Print a string, wiping to the end of the line
        /// </summary>
        /// <param name="str"> The string to print </param>
        /// <param name="row"> The row at which to print </param>
        /// <param name="col"> The column at which to print </param>
        public void PrintLine(string str, int row, int col)
        {
            PrintLine(Colour.White, str, row, col);
        }

        /// <summary>
        /// Prints a string, word-wrapping it onto successive lines
        /// </summary>
        /// <param name="a"> The colour in which to print </param>
        /// <param name="str"> The string to print </param>
        public void PrintWrap(Colour a, string str)
        {
            GetSize(out int w, out _);
            Locate(out int y, out int x);
            string[] split = str.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                string s = split[i];
                if (i > 0)
                {
                    s = " " + s;
                }
                if (x + s.Length > w)
                {
                    x = 0;
                    y++;
                    if (y > 22)
                    {
                        return;
                    }
                    Erase(y, x, 255);
                }
                foreach (char c in s)
                {
                    if (c == ' ' && x == 0)
                    {
                    }
                    else if (c == '\n')
                    {
                        x = 0;
                        y++;
                        Erase(y, x, 255);
                    }
                    else if (c >= ' ')
                    {
                        Print(a, c, y, x);
                        x++;
                    }
                    else
                    {
                        Print(a, ' ', y, x);
                        x++;
                    }
                }
            }
        }

        /// <summary>
        /// Redraw the entire window
        /// </summary>
        public void Redraw()
        {
            TotalErase = true;
            UpdateScreen();
        }

        private string ToHex(Color c)
        {
            return $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";
        }

        /// <summary>
        /// Update the screen, drawing all queued print and erase requests.
        /// </summary>
        public void UpdateScreen()
        {
            List<PrintLine> batchPrintLines = new List<PrintLine>();
            int y;
            int w = Width;
            int h = Height;
            int y1 = Y1;
            int y2 = Y2;

            // Check to see if any updates are needed.
            if (y1 > y2 && Scr.Cu == Old.Cu && Scr.CursorVisible == Old.CursorVisible && Scr.Cx == Old.Cx && Scr.Cy == Old.Cy && !TotalErase)
            {
                // No updates are needed.
                return;
            }

            if (TotalErase)
            {
                // Clear the "old" screen 
                _console.Clear();
                Old.CursorVisible = false;
                Old.Cu = false;
                Old.Cx = 0;
                Old.Cy = 0;

                // For each row
                for (y = 0; y < h; y++)
                {
                    // aa and cc point to the same index reference into Va and Vc.
                    int aa = Old.A[y];
                    int cc = Old.C[y];
                    for (int x = 0; x < w; x++)
                    {
                        Old.Va[aa++] = AttrBlank; // Background color
                        Old.Vc[cc++] = CharBlank; // Space
                    }
                }
                // Reset the size of the display to be full height.
                Y1 = y1 = 0;
                Y2 = y2 = h - 1;

                // Reset the width of the display for each row to be full width.
                for (y = 0; y < h; y++)
                {
                    X1[y] = 0;
                    X2[y] = w - 1;
                }
                TotalErase = false;
            }
            if (Scr.Cu || !Scr.CursorVisible)
            {
                int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
            }

            // Loop through each row of the entire "defined" display.  It may be smaller than the full 45 rows.
            for (y = y1; y <= y2; ++y)
            {
                int x1 = X1[y];
                int x2 = X2[y];
                if (x1 <= x2)
                {
                    //RefreshTextRow(y, x1, x2);
                    /////// Start RefreshTextRow
                    int oldAa = Old.A[y];
                    int oldCc = Old.C[y];
                    int scrAa = Scr.A[y];
                    int scrCc = Scr.C[y];
                    int fn = 0;
                    int fx = 0;
                    Colour fa = AttrBlank;
                    for (int x = x1; x <= x2; x++)
                    {
                        Colour oa = Old.Va[oldAa + x];
                        char oc = Old.Vc[oldCc + x];
                        Colour na = Scr.Va[scrAa + x];
                        char nc = Scr.Vc[scrCc + x];
                        if (na == oa && nc == oc)
                        {
                            if (fn != 0)
                            {
                                batchPrintLines.Add(new PrintLine(y, fx, new string(Scr.Vc, scrCc + fx, fn), fa, Colour.Background));
                                fn = 0;
                            }
                            continue;
                        }
                        Old.Va[oldAa + x] = na;
                        Old.Vc[oldCc + x] = nc;
                        if (fa != na)
                        {
                            if (fn != 0)
                            {
                                batchPrintLines.Add(new PrintLine(y, fx, new string(Scr.Vc, scrCc + fx, fn), fa, Colour.Background));
                                fn = 0;
                            }
                            fa = na;
                        }
                        if (fn++ == 0)
                        {
                            fx = x;
                        }
                    }
                    if (fn != 0)
                    {
                        batchPrintLines.Add(new PrintLine(y, fx, new string(Scr.Vc, scrCc + fx, fn), fa, Colour.Background));
                    }

                    /////// end RefreshTextRow
                    X1[y] = w;
                    X2[y] = 0;
                }
            }
            Y1 = h;
            Y2 = 0;

            if (Scr.Cu)
            {
                int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
            }
            else if (!Scr.CursorVisible)
            {
                int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
            }
            else
            {
                int scrCc = Old.C[Old.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Old.Cy, Old.Cx, Old.Vc[scrCc + Old.Cx].ToString(), Old.Va[scrCc + Old.Cx], Colour.Background));
                scrCc = Scr.C[Scr.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(Scr.Cy, Scr.Cx, Scr.Vc[scrCc + Scr.Cx].ToString(), Scr.Va[scrCc + Scr.Cx], Colour.Purple));
            }
            Old.Cu = Scr.Cu;
            Old.CursorVisible = Scr.CursorVisible;
            Old.Cx = Scr.Cx;
            Old.Cy = Scr.Cy;

            if (batchPrintLines.Count > 0)
                _console.BatchPrint(batchPrintLines.ToArray());
        }

        /// <summary>
        /// Refresh the window, drawing all queued print and erase requests
        /// </summary>
        public void Refresh(IConsole console)
        {
            List<PrintLine> batchPrintLines = new List<PrintLine>();
            Screen scr = Scr; // This will always be the game screen contents.
            int y;
            int w = Width;
            int h = Height;
            int y1 = Y1;
            int y2 = Y2;

            console.Clear();

            // Loop through each row of the entire display.  It may be smaller than the full 45 rows.
            for (y = 0; y < Height; ++y)
            {
                int scrAa = scr.A[y];
                int scrCc = scr.C[y];
                int fn = 0;
                int fx = 0;
                Colour currentColor = AttrBlank;
                for (int x = 0; x < Width; x++)
                {
                    Colour na = scr.Va[scrAa + x];
                    char nc = scr.Vc[scrCc + x];
                    if (currentColor != na)
                    {
                        if (fn != 0)
                        {
                            batchPrintLines.Add(new PrintLine(y, fx, new string(scr.Vc, scrCc + fx, fn), currentColor, Colour.Background));
                            fn = 0;
                        }
                        currentColor = na;
                    }
                    if (fn++ == 0)
                    {
                        fx = x;
                    }
                }
                if (fn != 0)
                {
                    batchPrintLines.Add(new PrintLine(y, fx, new string(scr.Vc, scrCc + fx, fn), currentColor, Colour.Background));
                }
            }

            if (scr.CursorVisible)
            {
                int scrCc = scr.C[scr.Cy]; // This is the index to the row of characters in the screen array.
                batchPrintLines.Add(new PrintLine(scr.Cy, scr.Cx, scr.Vc[scrCc + scr.Cx].ToString(), scr.Va[scrCc + scr.Cx], Colour.Purple));
            }

            if (batchPrintLines.Count > 0)
                _console.BatchPrint(batchPrintLines.ToArray());
        }

        public void PlayMusic(MusicTrack musicTrack)
        {
            _console.PlayMusic(musicTrack);
        }

        public void RequestCommand(bool shopping)
        {
            const int mode = Constants.KeymapModeOrig;
            CurrentCommand = (char)0;
            CommandArgument = 0;
            CommandDirection = 0;
            while (true)
            {
                char cmd;
                if (QueuedCommand != 0)
                {
                    MsgPrint(null);
                    cmd = QueuedCommand;
                    QueuedCommand = (char)0;
                }
                else
                {
                    MsgFlag = false;
                    HideCursorOnFullScreenInkey = true;
                    cmd = Inkey();
                }
                PrintLine("", 0, 0);
                if (cmd == '0')
                {
                    int oldArg = CommandArgument;
                    CommandArgument = 0;
                    PrintLine("Count: ", 0, 0);
                    while (true)
                    {
                        cmd = Inkey();
                        if (cmd == 0x7F || cmd == 0x08)
                        {
                            CommandArgument /= 10;
                            PrintLine($"Count: {CommandArgument}", 0, 0);
                        }
                        else if (cmd >= '0' && cmd <= '9')
                        {
                            if (CommandArgument >= 1000)
                            {
                                CommandArgument = 9999;
                            }
                            else
                            {
                                CommandArgument = (CommandArgument * 10) + cmd.ToString().ToIntSafely();
                            }
                            PrintLine($"Count: {CommandArgument}", 0, 0);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (CommandArgument == 0)
                    {
                        CommandArgument = 99;
                        PrintLine($"Count: {CommandArgument}", 0, 0);
                    }
                    if (oldArg != 0)
                    {
                        CommandArgument = oldArg;
                        PrintLine($"Count: {CommandArgument}", 0, 0);
                    }
                    if (cmd == ' ' || cmd == '\n' || cmd == '\r')
                    {
                        if (!GetCom("Command: ", out cmd))
                        {
                            CommandArgument = 0;
                            continue;
                        }
                    }
                }
                if (cmd == '\\')
                {
                    GetCom("Command: ", out cmd);
                    if (string.IsNullOrEmpty(_keyBuffer))
                    {
                        _keyBuffer = "";
                    }
                }
                string act = _keymapAct[mode][cmd];
                if (!string.IsNullOrEmpty(act) && _keyBuffer == null)
                {
                    _requestCommandBuffer = act;
                    _keyBuffer = _requestCommandBuffer;
                    continue;
                }
                if (cmd == 0)
                {
                    continue;
                }
                CurrentCommand = cmd;
                break;
            }
            PrintLine("", 0, 0);
        }

        /// <summary>
        /// Save the screen to memory for later re-loading
        /// </summary>
        public void SaveScreen()
        {
            int w = Width;
            int h = Height;
            (Mem ?? (Mem = new Screen(w, h))).Copy(Scr, w, h);
        }

        public void ShowManual() // TODO: Needs to be deleted
        {
        }

        internal void SetBackground(BackgroundImage image)
        {
            _console.SetBackground(image);
        }

        /// <summary>
        /// Adds a keypress to the internal queue
        /// </summary>
        /// <param name="k"> The keypress to add </param>
        private void EnqueueKey(char k)
        {
            if (k == 0)
            {
                return;
            }
            KeyQueue[KeyHead++] = k;
            if (KeyHead == KeySize)
            {
                KeyHead = 0;
            }
        }

        /// <summary>
        /// Gets a keypress from the internal queue, waiting until one is added if necessary
        /// </summary>
        /// <param name="ch"> The next key from the queue </param>
        /// <param name="wait"> Whether to wait for a key if one isn't already available </param>
        /// <param name="take"> Whether to take the keypress out of the queue </param>
        /// <returns> True if a keypress was available, false otherwise </returns>
        private bool GetKeypress(out char ch, bool wait, bool take)
        {
            ch = '\0';
            if (wait)
            {
                UpdateScreen();
                while (KeyHead == KeyTail)
                {
                    EnqueueKey(_console.WaitForKey());
                    LastInputReceived = DateTime.Now;
                    UpdateNotifier?.InputReceived();
                }
            }
            if (KeyHead == KeyTail)
            {
                return false;
            }
            ch = KeyQueue[KeyTail];
            if (take && ++KeyTail == KeySize)
            {
                KeyTail = 0;
            }
            return true;
        }

        /// <summary>
        /// Gets the size of the GUI display
        /// </summary>
        /// <param name="w"> The width of the display </param>
        /// <param name="h"> The height of the display </param>
        private void GetSize(out int w, out int h)
        {
            w = Width;
            h = Height;
        }

        /// <summary>
        /// Retrieves the cursor location
        /// </summary>
        /// <param name="row"> The row of the cursor </param>
        /// <param name="col"> The column of the cursor </param>
        private void Locate(out int row, out int col)
        {
            col = Scr.Cx;
            row = Scr.Cy;
        }

        private void MapMovementKeys()
        {
            _keymapAct = new string[Constants.KeymapModes][];
            for (int i = 0; i < Constants.KeymapModes; i++)
            {
                _keymapAct[i] = new string[256];
                for (int j = 0; j < 256; j++)
                {
                    _keymapAct[i][j] = string.Empty;
                }
            }
            _keymapAct[0]['1'] = ";1";
            _keymapAct[0]['2'] = ";2";
            _keymapAct[0]['3'] = ";3";
            _keymapAct[0]['4'] = ";4";
            _keymapAct[0]['5'] = ",";
            _keymapAct[0]['6'] = ";6";
            _keymapAct[0]['7'] = ";7";
            _keymapAct[0]['8'] = ";8";
            _keymapAct[0]['9'] = ";9";
        }

        /// <summary>
        /// Queue up a printed character to be displayed when the screen is refreshed
        /// </summary>
        /// <param name="x"> The x location to display the character </param>
        /// <param name="y"> The y location to display the character </param>
        /// <param name="a"> The colour in which to display the character </param>
        /// <param name="c"> The character to display </param>
        private void QueueCharacter(int x, int y, Colour a, char c)
        {
            int scrAa = Scr.A[y];
            int scrCc = Scr.C[y];
            Colour oa = Scr.Va[scrAa + x];
            int oc = Scr.Vc[scrCc + x];
            if (oa == a && oc == c)
            {
                return;
            }
            Scr.Va[scrAa + x] = a;
            Scr.Vc[scrCc + x] = c;
            if (y < Y1)
            {
                Y1 = y;
            }
            if (y > Y2)
            {
                Y2 = y;
            }
            if (x < X1[y])
            {
                X1[y] = x;
            }
            if (x > X2[y])
            {
                X2[y] = x;
            }
        }

        /// <summary>
        /// Queue up a printed string to be displayed when the screen is refreshed
        /// </summary>
        /// <param name="x"> The x location to display the string </param>
        /// <param name="y"> The y location to display the string </param>
        /// <param name="n"> The number of characters to display (-1 for all) </param>
        /// <param name="a"> The colour in which to display the string </param>
        /// <param name="s"> The string to print </param>
        private void QueueCharacters(int x, int y, int n, Colour a, string s)
        {
            int x1 = -1;
            int x2 = -1;
            int scrAa = Scr.A[y];
            int scrCc = Scr.C[y];
            int index = 0;
            for (; n != 0 && index < s.Length; n--)
            {
                Colour oa = Scr.Va[scrAa + x];
                int oc = Scr.Vc[scrCc + x];
                if (oa == a && oc == s[index])
                {
                    x++;
                    index++;
                    continue;
                }
                Scr.Va[scrAa + x] = a;
                Scr.Vc[scrCc + x] = s[index];
                if (x1 < 0)
                {
                    x1 = x;
                }
                x2 = x;
                x++;
                index++;
            }
            if (x1 >= 0)
            {
                if (y < Y1)
                {
                    Y1 = y;
                }
                if (y > Y2)
                {
                    Y2 = y;
                }
                if (x1 < X1[y])
                {
                    X1[y] = x1;
                }
                if (x2 > X2[y])
                {
                    X2[y] = x2;
                }
            }
        }
    }
}