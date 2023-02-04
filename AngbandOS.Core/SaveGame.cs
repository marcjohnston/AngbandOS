using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace AngbandOS
{
    [Serializable]
    internal class SaveGame
    {
        public FlaggedAction RedrawMapFlaggedAction { get; }
        public FlaggedAction RedrawEquippyFlaggedAction { get; }
        public FlaggedAction RedrawTitleFlaggedAction { get; }
        public FlaggedAction RedrawLevelFlaggedAction { get; }
        public FlaggedAction RedrawArmorFlaggedAction { get; }
        public FlaggedAction RedrawHpFlaggedAction { get; }
        public FlaggedAction RedrawExpFlaggedAction { get; }
        public FlaggedAction RedrawCutFlaggedAction { get; }
        public FlaggedAction RedrawHealthFlaggedAction { get; }
        public FlaggedAction RedrawManaFlaggedAction { get; }
        public FlaggedAction RedrawGoldFlaggedAction { get; }
        public FlaggedAction RedrawDepthFlaggedAction { get; }
        public FlaggedAction RedrawStunFlaggedAction { get; }
        public FlaggedAction RedrawHungerFlaggedAction { get; }
        public FlaggedAction RedrawDTrapFlaggedAction { get; }
        public FlaggedAction RedrawBlindFlaggedAction { get; }
        public FlaggedAction RedrawConfusedFlaggedAction { get; }
        public FlaggedAction RedrawAfraidFlaggedAction { get; }
        public FlaggedAction RedrawPoisonedFlaggedAction { get; }
        public FlaggedAction RedrawStateFlaggedAction { get; }
        public FlaggedAction RedrawSpeedFlaggedAction { get; }
        public FlaggedAction RedrawStatsFlaggedAction { get; }
        public FlaggedAction RedrawStudyFlaggedAction { get; }
        public FlaggedAction RedrawTimeFlaggedAction { get; }
        public FlaggedAction RedrawPlayerFlaggedAction { get; }

        public FlaggedAction PrExtraRedrawAction { get; }
        public FlaggedAction PrBasicRedrawAction { get; }
        public FlaggedAction RedrawAllFlaggedAction { get; }

        public FlaggedAction UpdateBonusesFlaggedAction { get; }
        public FlaggedAction UpdateDistancesFlaggedAction { get; }
        public FlaggedAction UpdateHealthFlaggedAction { get; }
        public FlaggedAction UpdateLightFlaggedAction { get; }
        public FlaggedAction UpdateManaFlaggedAction { get; }
        public FlaggedAction UpdateMonstersFlaggedAction { get; }
        public FlaggedAction RemoveLightFlaggedAction { get; }
        public FlaggedAction RemoveViewFlaggedAction { get; }
        public FlaggedAction UpdateScentFlaggedAction { get; }
        public FlaggedAction UpdateSpellsFlaggedAction { get; }
        public FlaggedAction UpdateTorchRadiusFlaggedAction { get; }
        public FlaggedAction UpdateViewFlaggedAction { get; }
        public FlaggedAction NoticeCombineFlaggedAction { get; }
        public FlaggedAction NoticeReorderFlaggedAction { get; }
        public FlaggedAction NoticeCombineAndReorderFlaggedAction { get; }

        public SingletonRepository SingletonRepository = new SingletonRepository();

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
        public bool CharacterXtra; // TODO: This global can be removed when actions are updated
        public bool CreateDownStair;
        public bool CreateUpStair;
        public Dungeon CurDungeon;
        public int CurrentDepth;
        public Town CurTown;
        public string DiedFrom;
        public int DungeonDifficulty;
        public int EnergyUse;
        public bool HackMind;
        public Level Level;
        public bool NewLevelFlag;
        public Player Player;
        public bool Playing;
        public int RecallDungeon;
        public int Resting;
        public int Running;
        public List<AmuletFlavour> AmuletFlavours; // This is the randomized list for the game.
        public List<MushroomFlavour> MushroomFlavours; // TODO: Move these to the singletons repository
        public List<PotionFlavour> PotionFlavours; // TODO: Move these to the singletons repository
        public List<RingFlavour> RingFlavours; // TODO: Move these to the singletons repository
        public List<RodFlavour> RodFlavours; // TODO: Move these to the singletons repository
        public List<ScrollFlavour> ScrollFlavours; // These are generated from the available base scrolls.
        public List<StaffFlavour> StaffFlavours; // TODO: Move these to the singletons repository
        public List<WandFlavour> WandFlavours; // This is a list of all of the wand flavors.  They are randomized for each game.
        public int TargetCol;
        public int TargetRow;
        public int TargetWho;
        public int TotalFriendLevels;
        public int TotalFriends;
        public int TrackedMonsterIndex;
        public bool ViewingEquipment; // TODO: Convert to parameter
        public bool ViewingItemList;

        private List<Monster> _petList = new List<Monster>();
        private int _seedFlavor;
        public const int HurtChance = 16;

        public ExPlayer ExPlayer;
        public RareItemTypeArray RareItemTypes;
        public VaultTypeArray VaultTypes;
        private readonly List<string> _messageBuf = new List<string>();
        private readonly List<int> _messageCounts = new List<int>();
        private int _msgPrintP;
        public bool MsgFlag;

        public int SpellFirst;
        public readonly int[] SpellOrder = new int[64];
        public readonly SpellList[] Spells = new SpellList[2];
        public TalentList Talents;

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
        public char[] KeyQueue;
        public int KeySize;

        /// <summary>
        /// The current contents of the game screen.
        /// </summary>
        public Screen Screen;

        public int KeyHead = 0;
        public int KeyTail = 0;
        /// DISPLAY

        /// <summary>
        /// A buffer of artificial keypresses
        /// </summary>
        private string _keyBuffer;

        private string[][] _keymapAct;
        private string _requestCommandBuffer;

        /// <summary>
        /// Returns true, if the parent is requesting the game to shut down immediately.  Returns false, by default.
        /// </summary>
        public bool Shutdown = false;

        /// GUI
        public const int CentMax = 100;
        public const int DoorMax = 200;
        public const int MaxRoomsCol = Level.MaxWid / _blockWid;
        public const int MaxRoomsRow = Level.MaxHgt / _blockHgt;
        public const int SafeMaxAttempts = 5000;
        public const int TunnMax = 900;
        public const int WallMax = 500;

        private const int _allocSetBoth = 3;
        private const int _allocSetCorr = 1;
        private const int _allocSetRoom = 2;
        private const int _allocTypGold = 4;
        private const int _allocTypObject = 5;
        private const int _allocTypRubble = 1;
        private const int _allocTypTrap = 3;
        private const int _blockHgt = 21;
        private const int _blockWid = 11;
        private const int _darkEmpty = 5;
        private const int _dunAmtGold = 3;
        private const int _dunAmtItem = 3;
        private const int _dunAmtRoom = 9;
        private const int _dunDest = 18;
        private const int _dunRooms = 50;
        private const int _dunStrDen = 5;
        private const int _dunStrMag = 3;
        private const int _dunStrMc = 90;
        private const int _dunStrQc = 40;
        private const int _dunStrQua = 2;
        private const int _dunStrRng = 2;
        private const int _dunTunChg = 30;
        private const int _dunTunCon = 15;
        private const int _dunTunJct = 90;
        private const int _dunTunPen = 25;
        private const int _dunTunRnd = 10;
        private const int _dunUnusual = 194;
        private const int _emptyLevel = 15;
        private const int _smallLevel = 3;

        private readonly Room[] _room =
        {
            new Room(0, 0, 0, 0, 0), new Room(0, 0, -1, 1, 1), new Room(0, 0, -1, 1, 1), new Room(0, 0, -1, 1, 3),
            new Room(0, 0, -1, 1, 3), new Room(0, 0, -1, 1, 5), new Room(0, 0, -1, 1, 5), new Room(0, 1, -1, 1, 5),
            new Room(-1, 2, -2, 3, 10), new Room(0, 1, -1, 1, 1)
        };

        private GridCoordinate[] Cent;
        private GridCoordinate[] Door;
        private bool[][] RoomMap;
        private GridCoordinate[] Tunn;
        private GridCoordinate[] Wall;
        private int CentN;
        private int ColRooms;
        private bool Crowded;
        private int DoorN;
        private int RowRooms;
        private int TunnN;
        private int WallN;

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public SaveGame()
        {
            RedrawMapFlaggedAction = new RedrawMapFlaggedAction(this);
            RedrawEquippyFlaggedAction = new RedrawEquippyFlaggedAction(this);
            RedrawTitleFlaggedAction = new RedrawTitleFlaggedAction(this);
            RedrawLevelFlaggedAction = new RedrawLevelFlaggedAction(this);
            RedrawArmorFlaggedAction = new RedrawArmorFlaggedAction(this);
            RedrawHpFlaggedAction = new RedrawHpFlaggedAction(this);
            RedrawExpFlaggedAction = new RedrawExpFlaggedAction(this);
            RedrawCutFlaggedAction = new RedrawCutFlaggedAction(this);
            RedrawHealthFlaggedAction = new RedrawHealthFlaggedAction(this);
            RedrawManaFlaggedAction = new RedrawManaFlaggedAction(this);
            RedrawGoldFlaggedAction = new RedrawGoldFlaggedAction(this);
            RedrawDepthFlaggedAction = new RedrawDepthFlaggedAction(this);
            RedrawStunFlaggedAction = new RedrawStunFlaggedAction(this);
            RedrawHungerFlaggedAction = new RedrawHungerFlaggedAction(this);
            RedrawDTrapFlaggedAction = new RedrawDTrapFlaggedAction(this);
            RedrawBlindFlaggedAction = new RedrawBlindFlaggedAction(this);
            RedrawConfusedFlaggedAction = new RedrawConfusedFlaggedAction(this);
            RedrawAfraidFlaggedAction = new RedrawAfraidFlaggedAction(this);
            RedrawPoisonedFlaggedAction = new RedrawPoisonedFlaggedAction(this);
            RedrawStateFlaggedAction = new RedrawStateFlaggedAction(this);
            RedrawSpeedFlaggedAction = new RedrawSpeedFlaggedAction(this);
            RedrawStatsFlaggedAction = new RedrawStatsFlaggedAction(this);
            RedrawStudyFlaggedAction = new RedrawStudyFlaggedAction(this);
            RedrawTimeFlaggedAction = new RedrawTimeFlaggedAction(this);
            RedrawPlayerFlaggedAction = new RedrawPlayerFlaggedAction(this);
            RedrawAllFlaggedAction = new RedrawAllFlaggedAction(this);

            UpdateBonusesFlaggedAction = new UpdateBonusesFlaggedAction(this);
            UpdateDistancesFlaggedAction = new UpdateDistancesFlaggedAction(this);
            UpdateHealthFlaggedAction = new UpdateHealthFlaggedAction(this);
            UpdateLightFlaggedAction = new UpdateLightFlaggedAction(this);
            UpdateManaFlaggedAction = new UpdateManaFlaggedAction(this);
            UpdateMonstersFlaggedAction = new UpdateMonstersFlaggedAction(this);
            RemoveLightFlaggedAction = new RemoveLightFlaggedAction(this);
            RemoveViewFlaggedAction = new RemoveViewFlaggedAction(this);
            UpdateScentFlaggedAction = new UpdateScentFlaggedAction(this);
            UpdateSpellsFlaggedAction = new UpdateSpellsFlaggedAction(this);
            UpdateTorchRadiusFlaggedAction = new UpdateTorchRadiusFlaggedAction(this);
            UpdateViewFlaggedAction = new UpdateViewFlaggedAction(this);

            NoticeCombineFlaggedAction = new NoticeCombineFlaggedAction(this);
            NoticeReorderFlaggedAction = new NoticeReorderFlaggedAction(this);

            NoticeCombineAndReorderFlaggedAction = new GroupSetFlaggedAction(this, NoticeCombineFlaggedAction, NoticeReorderFlaggedAction);
            PrExtraRedrawAction = new GroupSetFlaggedAction(this, 
                RedrawCutFlaggedAction, RedrawHungerFlaggedAction, RedrawDTrapFlaggedAction, RedrawBlindFlaggedAction, RedrawConfusedFlaggedAction, 
                RedrawAfraidFlaggedAction, RedrawPoisonedFlaggedAction, RedrawStateFlaggedAction, RedrawSpeedFlaggedAction, RedrawStudyFlaggedAction);
            PrBasicRedrawAction = new GroupSetFlaggedAction(this,
                RedrawPlayerFlaggedAction, RedrawTitleFlaggedAction, RedrawStatsFlaggedAction, RedrawLevelFlaggedAction, RedrawExpFlaggedAction, RedrawGoldFlaggedAction,
                RedrawArmorFlaggedAction, RedrawHpFlaggedAction, RedrawManaFlaggedAction, RedrawDepthFlaggedAction, RedrawHealthFlaggedAction, RedrawSpeedFlaggedAction);

            SingletonRepository.Initialize(this);
            _autoNavigator = new AutoNavigator(this);
            Quests = new QuestArray(this);
            PopulateNewProfile();
            Towns = Town.NewTownList(this);
            Dungeons = Dungeon.NewDungeonList();
            PatronList = Patron.NewPatronList(this);
            InitializeAllocationTables();
        }

        private void PopulateNewProfile()
        {
            RareItemTypes = new RareItemTypeArray(this);
            VaultTypes = new VaultTypeArray(this);
        }

        public int GetMonsterIndexFromName(string name)
        {
            foreach (MonsterRace race in SingletonRepository.MonsterRaces)
            {
                if (race.Name == name)
                {
                    return race.Index;
                }
            }
            return 0;
        }

        public void ResetGuardians()
        {
            foreach (MonsterRace race in SingletonRepository.MonsterRaces)
            {
                race.Guardian = false;
            }
        }

        public void ResetUniqueOnlyGuardianStatus()
        {
            foreach (MonsterRace race in SingletonRepository.MonsterRaces)
            {
                race.OnlyGuardian = false;
            }
        }

        public void Quit(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                MessageBoxShow(reason);
            }
        }

        public ItemClass RandomItemType(int level, bool doNotAllowChestToBeCreated, bool good)
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
                ItemClass kPtr = SingletonRepository.ItemCategories[kIdx];
                if (doNotAllowChestToBeCreated && kPtr.CategoryEnum == ItemTypeEnum.Chest)
                {
                    continue;
                }

                // Determine the final probability.  If only good objects are requested and the object is not good, then set it to 0.
                table[i].FinalProbability = good && !kPtr.KindIsGood ? 0 : table[i].BaseProbability;

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
            return SingletonRepository.ItemCategories[table[i].Index];
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

        private void ResetStompability()
        {
            foreach (ItemClass item in SingletonRepository.ItemCategories)
            {
                if (item.HasQuality)
                {
                    item.Stompable[0] = true;
                    item.Stompable[1] = false;
                    item.Stompable[2] = false;
                    item.Stompable[3] = false;
                }
                else
                {
                    item.Stompable[0] = item.Cost <= 0;
                    item.Stompable[1] = false;
                    item.Stompable[2] = false;
                    item.Stompable[3] = false;
                }
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
            Screen.CursorVisible = false;
            if (Program.Rng.UseFixed)
            {
                Program.Rng.UseFixed = false;
            }
            if (Player == null)
            {
                if (!CharacterGeneration(ExPlayer))
                {
                    return;
                }
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
                ResetStompability();
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
                GenerateNewLevel();
            }
            FullScreenOverlay = false;
            SetBackground(BackgroundImage.Overhead);
            Playing = true;
            if (Player.Health < 0)
            {
                Player.IsDead = true;
            }

            // Repeat the dungeon loop until normal game ends or the shutdown flag is raised.
            while (!Shutdown)
            {
                // Play the current dungeon level.
                DungeonLoop();

                // The dungeon level is changing.
                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
                TargetWho = 0;
                HealthTrack(0);
                RemoveLightFlaggedAction.Check(true);
                RemoveViewFlaggedAction.Check(true);
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
                GenerateNewLevel();
                Level.ReplacePets(Player.MapY, Player.MapX, _petList);
            }
            UpdateNotifier?.GameStopped();
            CloseGame();
        }

        // PROFILE MESSAGING START
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
                Screen.Print(Colour.White, t.Substring(0, split), 0, 0);
                MsgFlush(split + 1);
                t = t.Substring(split);
                n -= split;
            }
            Screen.Print(Colour.White, t.Substring(0, n), 0, _msgPrintP);
            MsgFlag = true;
            _msgPrintP += n + 1;
        }
        private void MsgFlush(int x)
        {
            const Colour a = Colour.BrightBlue;
            Screen.Print(a, "-more-", 0, x);
            while (true && !Shutdown)
            {
                Inkey();
                break;
            }
            Screen.Erase(0, 0);
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
                        AggravateMonsters();
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
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, null);
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
                                Player.TimedParalysis.AddTimer(Program.Rng.DieRoll(3));
                            }
                            else
                            {
                                Player.TimedParalysis.AddTimer(Program.Rng.DieRoll(13));
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
            ChestTrapConfiguration trap = ObjectRepository.ChestTrapConfigurations[oPtr.TypeSpecificValue];
            trap.Activate(this, oPtr);
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
                    Screen.Print(wildMapAttr, wildMapSymbol, y + 2, x + 2);
                }
            }
            Screen.Print(Colour.Purple, "+------------+", 1, 1);
            for (y = 0; y < 12; y++)
            {
                Screen.Print(Colour.Purple, "|", y + 2, 1);
                Screen.Print(Colour.Purple, "|", y + 2, 14);
            }
            Screen.Print(Colour.Purple, "+------------+", 14, 1);
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
                Screen.Print(keyAttr, buffer, y + 1, 19);
            }
            Screen.Print(Colour.Purple, "L:levels", 16, 1);
            Screen.Print(Colour.Purple, "D:difficulty", 17, 1);
            Screen.Print(Colour.Purple, "Q:quests", 18, 1);
            Screen.Print(Colour.Purple, "(Your position is marked with the cursor)", Constants.MaxCaves + 2, 19);
        }

        /// <summary>
        /// Interrupts a repeat command.  This is known as disturbing the player.
        /// </summary>
        /// <param name="stopSearch"></param>
        public void Disturb(bool stopSearch)
        {
            if (CommandRepeat != 0)
            {
                CommandRepeat = 0;
                RedrawStateFlaggedAction.Set();
            }
            if (Resting != 0)
            {
                Resting = 0;
                RedrawStateFlaggedAction.Set();
            }
            if (Running != 0)
            {
                Running = 0;
                UpdateTorchRadiusFlaggedAction.Set();
            }
            if (stopSearch && Player.IsSearching)
            {
                Player.IsSearching = false;
                UpdateBonusesFlaggedAction.Set();
                RedrawStateFlaggedAction.Set();
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

        /// <summary>
        /// Returns a list of labels and label ranges to represent inventory slot selections.  Example: a,c-g
        /// </summary>
        /// <param name="inventorySlots"></param>
        /// <returns></returns>
        private string GetLabelRanges(IEnumerable<int> inventorySlots)
        {
            int[] inventorySlotsArray = inventorySlots.ToArray();
            string ranges = "";
            int? last = null;
            int? current = null;
            for (int i = 0; i < inventorySlotsArray.Length; i++)
            {
                int inventorySlot = inventorySlotsArray[i];
                bool finish = false;
                if (last == null)
                {
                    last = inventorySlot;
                    current = inventorySlot;
                }
                else if (current + 1 == inventorySlot)
                {
                    current = inventorySlot;
                }
                else
                {
                    finish = true;
                }
                if (finish || i + 1 == inventorySlotsArray.Length)
                { 
                    if (ranges.Length > 0)
                    {
                        ranges += ",";
                    } 
                        
                    if (last == current)
                    {
                        ranges += $"{last.Value.IndexToLabel()}";
                    }
                    else
                    {
                        ranges += $"{last.Value.IndexToLabel()}-{current.Value.IndexToLabel()}";
                    }
                    last = inventorySlot;
                    current = inventorySlot;
                }
            }
            return ranges;
        }

        public bool GetItem(out int itemIndex, string prompt, bool canChooseFromEquipment, bool canChooseFromInventory, bool canChooseFromFloor, IItemFilter? itemFilter)
        {
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            int currentItemIndex;
            int nextItemIndex;
            bool allowFloor = false;
            MsgPrint(null);
            bool done = false;
            bool item = false;
            itemIndex = -1;
            List<int> inventory = new List<int>();
            List<int> equipment = new List<int>();
            if (canChooseFromInventory)
            {
                for (int ii = 0; ii < InventorySlot.PackCount; ii++)
                {
                    Item oPtr = Player.Inventory[ii];
                    if (oPtr.BaseItemCategory != null && (itemFilter == null || itemFilter.ItemMatches(oPtr)))
                    {
                        inventory.Add(ii);
                    }
                }
            }
            if (canChooseFromEquipment)
            {
                for (int ii = InventorySlot.MeleeWeapon; ii < InventorySlot.Total; ii++)
                {
                    Item oPtr = Player.Inventory[ii];
                    if (oPtr.BaseItemCategory != null && (itemFilter == null || itemFilter.ItemMatches(oPtr)))
                    {
                        equipment.Add(ii);
                    }
                }
            }
            if (canChooseFromFloor)
            {
                for (currentItemIndex = tile.ItemIndex; currentItemIndex != 0; currentItemIndex = nextItemIndex)
                {
                    Item oPtr = Level.Items[currentItemIndex];
                    nextItemIndex = oPtr.NextInStack;
                    if (Player.ItemMatchesFilter(oPtr, itemFilter))
                    {
                        allowFloor = true;
                    }
                }
            }
            if (!allowFloor && inventory.Count == 0 && equipment.Count == 0)
            {
                ViewingItemList = false;
                itemIndex = -2;
                done = true;
            }
            else
            {
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
            ScreenBuffer? savedScreen = null;
            if (ViewingItemList)
            {
                savedScreen = Screen.Clone();
            }
            while (!done && !Shutdown)
            {
                if (!ViewingEquipment)
                {
                    if (ViewingItemList)
                    {
                        Player.ShowInven(_inventorySlot => !_inventorySlot.IsEquipment, itemFilter);
                    }
                }
                else
                {
                    if (ViewingItemList)
                    {
                        Player.ShowEquip(itemFilter);
                    }
                }
                string tmpVal;
                string outVal;
                if (!ViewingEquipment)
                {
                    outVal = "Inven:";
                    if (inventory.Count > 0)
                    {
                        tmpVal = $" {GetLabelRanges(inventory)},";
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
                    if (equipment.Count > 0)
                    {
                        tmpVal = $" {GetLabelRanges(equipment)}";
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
                Screen.PrintLine(tmpVal, 0, 0);
                char which = Inkey();
                int k;
                switch (which)
                {
                    case '\x1b':
                        {
                            done = true;
                            break;
                        }
                    case '*':
                    case '?':
                    case ' ':
                        {
                            if (!ViewingItemList)
                            {
                                savedScreen = Screen.Clone();
                                ViewingItemList = true;
                            }
                            else
                            {
                                Screen.Restore(savedScreen);
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
                                Screen.Restore(savedScreen);
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
                                    if (!Player.ItemMatchesFilter(oPtr, itemFilter))
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
                                k = inventory.Count == 1 ? inventory[0] : -1;
                            }
                            else
                            {
                                k = equipment.Count == 1 ? equipment[0] : -1;
                            }
                            if (!Player.GetItemOkay(k, itemFilter))
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
                            k = !ViewingEquipment ? Player.LabelToInven(which) : Player.LabelToEquip(which);
                            if (!Player.GetItemOkay(k, itemFilter))
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
            if (savedScreen != null)
            {
                Screen.Restore(savedScreen);
            }
            ViewingItemList = false;
            Screen.PrintLine("", 0, 0);
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
            UpdateStuff();
            RedrawStuff();
        }

        public void HealthTrack(int mIdx)
        {
            TrackedMonsterIndex = mIdx;
            RedrawHealthFlaggedAction.Set();
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
            bool visible = mPtr.IsVisible || rPtr.Unique;
            bool good = rPtr.DropGood;
            bool great = rPtr.DropGreat;
            bool doGold = !rPtr.OnlyDropItem;
            bool doItem = !rPtr.OnlyDropGold;
            bool cloned = false;
            int forceCoin = rPtr.GetCoinType();
            Item qPtr;
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if (mPtr.SmCloned)
            {
                cloned = true;
            }
            for (int thisOIdx = mPtr.FirstHeldItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item oPtr = Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                oPtr.HoldingMonsterIndex = 0;
                qPtr = Level.Items[thisOIdx].Clone();
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
            if (rPtr.Drop60 && Program.Rng.RandomLessThan(100) < 60)
            {
                number++;
            }
            if (rPtr.Drop90 && Program.Rng.RandomLessThan(100) < 90)
            {
                number++;
            }
            if (rPtr.Drop_1D2)
            {
                number += Program.Rng.DiceRoll(1, 2);
            }
            if (rPtr.Drop_2D2)
            {
                number += Program.Rng.DiceRoll(2, 2);
            }
            if (rPtr.Drop_3D2)
            {
                number += Program.Rng.DiceRoll(3, 2);
            }
            if (rPtr.Drop_4D2)
            {
                number += Program.Rng.DiceRoll(4, 2);
            }
            if (cloned)
            {
                number = 0;
            }
            if (Quests.IsQuest(CurrentDepth) && rPtr.Guardian)
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
            if (!rPtr.Guardian)
            {
                return;
            }
            if (Quests[qIdx].Killed != Quests[qIdx].ToKill)
            {
                return;
            }
            rPtr.Guardian = !rPtr.Guardian;
            if (Quests.ActiveQuests == 0)
            {
                Player.IsWinner = true;
                RedrawTitleFlaggedAction.Set();
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
                    UpdateScentFlaggedAction.Set();
                    UpdateMonstersFlaggedAction.Set();
                    UpdateLightFlaggedAction.Set();
                    UpdateViewFlaggedAction.Set();
                }
            }
        }

        public void NoticeStuff()
        {
            NoticeCombineFlaggedAction.Check();
            NoticeReorderFlaggedAction.Check();
        }

        public void OpenChest(int y, int x, int oIdx)
        {
            Item oPtr = Level.Items[oIdx];
            ChestItemClass chest = (ChestItemClass)oPtr.BaseItemCategory;
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
                    if (!qPtr.MakeGold())
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
            Screen = new Screen(w, h);
        }

        public void UpdateStuff()
        {
            UpdateBonusesFlaggedAction.Check();
            UpdateTorchRadiusFlaggedAction.Check();
            UpdateHealthFlaggedAction.Check();
            UpdateManaFlaggedAction.Check();
            UpdateSpellsFlaggedAction.Check();
            if (FullScreenOverlay)
            {
                return;
            }
            RemoveLightFlaggedAction.Check();
            RemoveViewFlaggedAction.Check();
            UpdateViewFlaggedAction.Check();
            UpdateLightFlaggedAction.Check();
            UpdateScentFlaggedAction.Check();
            UpdateDistancesFlaggedAction.Check();
            UpdateMonstersFlaggedAction.Check();
        }

        private void ApplyFlavourVisuals()
        {
            foreach (ItemClass kPtr in SingletonRepository.ItemCategories)
            {
                if (kPtr.HasFlavor)
                {
                    int indexx = kPtr.SubCategory ?? 0;
                    switch (kPtr.CategoryEnum)
                    {
                        case ItemTypeEnum.Food:
                            kPtr.FlavorCharacter = MushroomFlavours[indexx].Character;
                            kPtr.FlavorColour = MushroomFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Potion:
                            kPtr.FlavorCharacter = PotionFlavours[indexx].Character;
                            kPtr.FlavorColour = PotionFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Scroll:
                            kPtr.FlavorCharacter = ScrollFlavours[indexx].Character;
                            kPtr.FlavorColour = ScrollFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Amulet:
                            kPtr.FlavorCharacter = AmuletFlavours[indexx].Character;
                            kPtr.FlavorColour = AmuletFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Ring:
                            kPtr.FlavorCharacter = RingFlavours[indexx].Character;
                            kPtr.FlavorColour = RingFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Staff:
                            kPtr.FlavorCharacter = StaffFlavours[indexx].Character;
                            kPtr.FlavorColour = StaffFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Wand:
                            kPtr.FlavorCharacter = WandFlavours[indexx].Character;
                            kPtr.FlavorColour = WandFlavours[indexx].Colour;
                            break;

                        case ItemTypeEnum.Rod:
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
                //HighScore score = new HighScore(this);
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

        private void CreateWorld()  // TODO: This method participated in a hang during startup
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
            Player.RecenterScreenAroundPlayer();
            Level.PanelBoundsCenter();
            MsgPrint(null);
            CharacterXtra = true;
            RedrawEquippyFlaggedAction.Set();
            PrExtraRedrawAction.Set();
            PrBasicRedrawAction.Set();
            RedrawAllFlaggedAction.Set(); // TODO: special case ... should be some form of invalidateclient
            RedrawMapFlaggedAction.Set();
            UpdateHealthFlaggedAction.Set();
            UpdateManaFlaggedAction.Set();
            UpdateSpellsFlaggedAction.Set();
            UpdateBonusesFlaggedAction.Set();
            UpdateTorchRadiusFlaggedAction.Set();
            UpdateStuff();
            RedrawStuff();
            UpdateScentFlaggedAction.Set();
            UpdateDistancesFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateStuff();
            RedrawStuff();
            CharacterXtra = false;
            UpdateHealthFlaggedAction.Set();
            UpdateManaFlaggedAction.Set();
            UpdateSpellsFlaggedAction.Set();
            UpdateBonusesFlaggedAction.Set();
            NoticeCombineAndReorderFlaggedAction.Set();
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
                DoCmdStore();
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
            while (!Shutdown)
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

                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
                TotalFriends = 0;
                TotalFriendLevels = 0;
                ProcessAllMonsters();
                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
                ProcessWorld();
                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
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
                    DoCmdFeeling(true);
                }
            }
        }

        private void FlavorInit()
        {
            int i, j;
            Program.Rng.UseFixed = true;
            Program.Rng.FixedSeed = _seedFlavor;
            PotionFlavours = new List<PotionFlavour>();
            List<PotionFlavour> tempPotions = new List<PotionFlavour>();
            PotionFlavours.Add(new ClearPotionFlavour());
            PotionFlavours.Add(new LightBrownPotionFlavour());
            PotionFlavours.Add(new IckyGreenPotionFlavour());
            foreach (PotionFlavour potionFlavour in ObjectRepository.PotionFlavours)
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
            MushroomFlavours = new List<MushroomFlavour>();
            List<MushroomFlavour> tempMushrooms = new List<MushroomFlavour>();
            foreach (MushroomFlavour mushroomFlavour in ObjectRepository.MushroomFlavours)
            {
                tempMushrooms.Add(mushroomFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempMushrooms.Count);
                MushroomFlavours.Add(tempMushrooms[index]);
                tempMushrooms.RemoveAt(index);
            } while (tempMushrooms.Count > 0);
            AmuletFlavours = new List<AmuletFlavour>();
            List<AmuletFlavour> tempAmulets = new List<AmuletFlavour>();
            foreach (AmuletFlavour amuletFlavour in ObjectRepository.AmuletFlavours)
            {
                tempAmulets.Add(amuletFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempAmulets.Count);
                AmuletFlavours.Add(tempAmulets[index]);
                tempAmulets.RemoveAt(index);
            } while (tempAmulets.Count > 0);
            WandFlavours = new List<WandFlavour>();
            List<WandFlavour> tempWands = new List<WandFlavour>();
            foreach (WandFlavour wandFlavour in ObjectRepository.WandFlavours)
            {
                tempWands.Add(wandFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempWands.Count);
                WandFlavours.Add(tempWands[index]);
                tempWands.RemoveAt(index);
            } while (tempWands.Count > 0);
            RingFlavours = new List<RingFlavour>();
            List<RingFlavour> tempRings = new List<RingFlavour>();
            foreach (RingFlavour ringFlavour in ObjectRepository.RingFlavours)
            {
                tempRings.Add(ringFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempRings.Count);
                RingFlavours.Add(tempRings[index]);
                tempRings.RemoveAt(index);
            } while (tempRings.Count > 0);
            RodFlavours = new List<RodFlavour>();
            List<RodFlavour> tempRods = new List<RodFlavour>();
            foreach (RodFlavour rodFlavour in ObjectRepository.RodFlavours)
            {
                tempRods.Add(rodFlavour);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempRods.Count);
                RodFlavours.Add(tempRods[index]);
                tempRods.RemoveAt(index);
            } while (tempRods.Count > 0);
            StaffFlavours = new List<StaffFlavour>();
            List<StaffFlavour> tempStaffs = new List<StaffFlavour>();
            foreach (StaffFlavour staffFlavour in ObjectRepository.StaffFlavours)
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
            foreach (BaseScrollFlavour scrollFlavour in ObjectRepository.ScrollFlavours)
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
            foreach (ItemClass kPtr in SingletonRepository.ItemCategories)
            {
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
            ItemClass kPtr;
            MonsterRace rPtr;
            int[] num = new int[Constants.MaxDepth];
            int[] aux = new int[Constants.MaxDepth];
            AllocKindSize = 0;
            for (i = 1; i < SingletonRepository.ItemCategories.Count; i++)
            {
                kPtr = SingletonRepository.ItemCategories[i];
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
            for (i = 1; i < SingletonRepository.ItemCategories.Count; i++)
            {
                kPtr = SingletonRepository.ItemCategories[i];
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
            for (i = 1; i < SingletonRepository.MonsterRaces.Count - 1; i++)
            {
                rPtr = SingletonRepository.MonsterRaces[i];
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
            for (i = 1; i < SingletonRepository.MonsterRaces.Count - 1; i++)
            {
                rPtr = SingletonRepository.MonsterRaces[i];
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
            Screen.Clear();
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
                Screen.Clear();
                string buf = corpse.Name.Trim() + corpse.Generation.ToRoman(true);
                if (corpse.IsWinner || corpse.Level > Constants.PyMaxLevel)
                {
                    buf += " the Magnificent";
                }
                Screen.Print(buf, 39, 1);
                buf = $"Level {corpse.Level} {corpse.BaseCharacterClass.ClassSubName(corpse.PrimaryRealm)}";
                Screen.Print(buf, 40, 1);
                string tmp = $"Killed on Level {CurrentDepth}".PadLeft(45);
                Screen.Print(tmp, 39, 34);
                tmp = $"by {DiedFrom}".PadLeft(45);
                Screen.Print(tmp, 40, 34);
                tmp = $"on {ct:dd MMM yyyy h.mm tt}".PadLeft(45);
                Screen.Print(tmp, 41, 34);
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
            Player.Energy += Constants.ExtractEnergy[Player.Speed];
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
                    if (Player.Health == Player.MaxHealth && Player.Mana == Player.MaxMana && Player.TimedBlindness.TurnsRemaining == 0 &&
                        Player.TimedConfusion.TurnsRemaining == 0 && Player.TimedPoison.TurnsRemaining == 0 && Player.TimedFear.TurnsRemaining == 0 && Player.TimedStun.TurnsRemaining == 0 &&
                        Player.TimedBleeding.TurnsRemaining == 0 && Player.TimedSlow.TurnsRemaining == 0 && Player.TimedParalysis.TurnsRemaining == 0 && Player.TimedHallucinations.TurnsRemaining == 0 &&
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
            while (Player.Energy >= 100 && !Shutdown)
            {
                RedrawDTrapFlaggedAction.Set();
                NoticeStuff();
                UpdateStuff();
                RedrawStuff();
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                UpdateScreen();
                if (Player.Inventory[InventorySlot.PackCount].BaseItemCategory != null)
                {
                    const int item = InventorySlot.PackCount;
                    Item oPtr = Player.Inventory[item];
                    Disturb(false);
                    MsgPrint("Your pack overflows!");
                    string oName = oPtr.Description(true, 3);
                    MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
                    Level.DropNear(oPtr, 0, Player.MapY, Player.MapX);
                    Player.InvenItemIncrease(item, -255);
                    Player.InvenItemDescribe(item);
                    Player.InvenItemOptimize(item);
                    NoticeStuff();
                    UpdateStuff();
                    RedrawStuff();
                }
                if (QueuedCommand == 0)
                {
                    ViewingItemList = false;
                }
                EnergyUse = 0;
                if (Player.TimedParalysis.TurnsRemaining != 0 || Player.TimedStun.TurnsRemaining >= 100)
                {
                    EnergyUse = 100;
                }
                else if (Resting != 0)
                {
                    if (Resting > 0)
                    {
                        Resting--;
                        RedrawStateFlaggedAction.Set();
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
                    RedrawStateFlaggedAction.Set();
                    RedrawStuff();
                    MsgFlag = false;
                    Screen.PrintLine("", 0, 0);
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
                            if (!rPtr.AttrMulti)
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
                Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new UndeadMonsterSelector());
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
                UpdateMonstersFlaggedAction.Set();
                RedrawMapFlaggedAction.Set();
            }
            if (Player.GameTime.IsMidnight)
            {
                Player.Religion.DecayFavour();
                UpdateHealthFlaggedAction.Set();
                UpdateManaFlaggedAction.Set();
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
            if (Player.TimedPoison.TurnsRemaining != 0 && Player.TimedInvulnerability.TurnsRemaining == 0)
            {
                Player.TakeHit(1, "poison");
            }
            Item oPtr;
            bool caveNoRegen = false;

            // Allow all inventory slots access to the process world.
            foreach (BaseInventorySlot inventorySlot in SingletonRepository.InventorySlots)
            {
                ProcessWorldEventArgs inventorySlotProcessWorldEventArgs = new ProcessWorldEventArgs(this);
                inventorySlot.ProcessWorldHook(inventorySlotProcessWorldEventArgs);
                if (inventorySlotProcessWorldEventArgs.DisableRegeneration)
                {
                    caveNoRegen = true;
                }
            }

            // Allow the race access to the process world.
            ProcessWorldEventArgs processWorldEventArgs = new ProcessWorldEventArgs(this);
            Player.Race.ProcessWorld(processWorldEventArgs);
            if (processWorldEventArgs.DisableRegeneration)
            {
                caveNoRegen = true;
            }

            if (!Level.GridPassable(Player.MapY, Player.MapX))
            {
                caveNoRegen = true;
                if (Player.TimedInvulnerability.TurnsRemaining == 0 && Player.TimedEtherealness.TurnsRemaining == 0 && (Player.Health > Player.Level / 5 || Player.Race.IsEthereal))
                {
                    string damDesc;
                    if (Player.Race.IsEthereal)
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
            if (Player.TimedBleeding.TurnsRemaining != 0 && Player.TimedInvulnerability.TurnsRemaining == 0)
            {
                if (Player.TimedBleeding.TurnsRemaining > 200)
                {
                    i = 3;
                }
                else if (Player.TimedBleeding.TurnsRemaining > 100)
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
                    i = Constants.ExtractEnergy[Player.Speed] * 2;
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
                if (Player.TimedInvulnerability.TurnsRemaining == 0)
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
                    if (Player.TimedParalysis.TurnsRemaining == 0 && Program.Rng.RandomLessThan(100) < 10)
                    {
                        MsgPrint("You faint from the lack of food.");
                        Disturb(true);
                        Player.TimedParalysis.AddTimer(1 + Program.Rng.RandomLessThan(5));
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
                if (Player.BaseCharacterClass.ID == CharacterClass.Mage)
                {
                    upkeepDivider = 15;
                }
                else if (Player.BaseCharacterClass.ID == CharacterClass.HighMage)
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
            if (Player.TimedPoison.TurnsRemaining != 0)
            {
                regenAmount = 0;
            }
            if (Player.TimedBleeding.TurnsRemaining != 0)
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
            if (Player.GooPatron.MultiRew)
            {
                Player.GooPatron.MultiRew = false;
            }
            //foreach (TimedAction timedAction in SingletonRepository.TimedActions)
            //{
            //    timedAction.ProcessWorld();
            //}
            Player.TimedBlindness.ProcessWorld();
            Player.TimedSeeInvisibility.ProcessWorld();
            Player.TimedTelepathy.ProcessWorld();
            Player.TimedInfravision.ProcessWorld();
            Player.TimedParalysis.ProcessWorld();
            Player.TimedConfusion.ProcessWorld();
            Player.TimedFear.ProcessWorld();
            Player.TimedHaste.ProcessWorld();
            Player.TimedSlow.ProcessWorld();
            Player.TimedProtectionFromEvil.ProcessWorld();
            Player.TimedInvulnerability.ProcessWorld();
            Player.TimedEtherealness.ProcessWorld();
            Player.TimedHeroism.ProcessWorld();
            Player.TimedSuperheroism.ProcessWorld();
            Player.TimedBlessing.ProcessWorld();
            Player.TimedStoneskin.ProcessWorld();
            Player.TimedAcidResistance.ProcessWorld();
            Player.TimedLightningResistance.ProcessWorld();
            Player.TimedFireResistance.ProcessWorld();
            Player.TimedColdResistance.ProcessWorld();
            Player.TimedPoisonResistance.ProcessWorld();
            Player.TimedPoison.ProcessWorld();
            Player.TimedStun.ProcessWorld();
            Player.TimedBleeding.ProcessWorld();
            Player.TimedHallucinations.ProcessWorld();

            UpdateTorchRadiusFlaggedAction.Set();
            if (Player.HasExperienceDrain)
            {
                if (Program.Rng.RandomLessThan(100) < 10 && Player.ExperiencePoints > 0)
                {
                    Player.ExperiencePoints--;
                    Player.MaxExperienceGained--;
                    Player.CheckExperience();
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
                    if (oPtr.IdentCursed && !Player.HasAntiTeleport)
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
            for (j = 0, i = 0; i < InventorySlot.PackCount; i++)
            {
                oPtr = Player.Inventory[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.Category == ItemTypeEnum.Rod && oPtr.TypeSpecificValue != 0)
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
                NoticeCombineFlaggedAction.Set();
            }
            Player.SenseInventory();
            for (i = 1; i < Level.OMax; i++)
            {
                oPtr = Level.Items[i];
                if (oPtr.BaseItemCategory == null)
                {
                    continue;
                }
                if (oPtr.Category == ItemTypeEnum.Rod && oPtr.TypeSpecificValue != 0)
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
            if (FullScreenOverlay)
            {
                return;
            }

            // The Wipe refresh is a special RedrawAction that occurs before all other RedrawActions.
            RedrawAllFlaggedAction.Check();

            RedrawMapFlaggedAction.Check();
            RedrawPlayerFlaggedAction.Check();
            RedrawEquippyFlaggedAction.Check();
            RedrawTitleFlaggedAction.Check();
            RedrawLevelFlaggedAction.Check();
            RedrawExpFlaggedAction.Check();
            RedrawStatsFlaggedAction.Check();
            RedrawArmorFlaggedAction.Check();
            RedrawHpFlaggedAction.Check();
            RedrawManaFlaggedAction.Check();
            RedrawGoldFlaggedAction.Check();
            RedrawDepthFlaggedAction.Check();
            RedrawHealthFlaggedAction.Check();
            RedrawCutFlaggedAction.Check();
            RedrawStunFlaggedAction.Check();
            RedrawHungerFlaggedAction.Check();
            RedrawDTrapFlaggedAction.Check();
            RedrawBlindFlaggedAction.Check();
            RedrawConfusedFlaggedAction.Check();
            RedrawAfraidFlaggedAction.Check();
            RedrawPoisonedFlaggedAction.Check();
            RedrawStateFlaggedAction.Check();
            RedrawSpeedFlaggedAction.Check();
            RedrawStudyFlaggedAction.Check();
            RedrawTimeFlaggedAction.Check(true); // TODO: Trigger this from GameTime
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
                    if (rPtr.Regenerate)
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
                        RedrawHealthFlaggedAction.Set();
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
            if (Player.TimedAcidResistance.TurnsRemaining != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedAcidResistance.TurnsRemaining != 0 || Player.HasAcidResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Charisma);
            }
            if (MinusAc())
            {
                dam = (dam + 1) / 2;
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.TimedAcidResistance.TurnsRemaining != 0 && Player.HasAcidResistance))
            {
                Player.InvenDamage(SetAcidDestroy, inv);
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
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new AntMonsterSelector());
                        break;

                    case 3:
                    case 4:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new SpiderMonsterSelector());
                        break;

                    case 5:
                    case 6:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new HoundMonsterSelector());
                        break;

                    case 7:
                    case 8:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new HydraMonsterSelector());
                        break;

                    case 9:
                    case 10:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new CthuloidMonsterSelector());
                        break;

                    case 11:
                    case 12:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new UndeadMonsterSelector());
                        break;

                    case 13:
                    case 14:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new DragonMonsterSelector());
                        break;

                    case 15:
                    case 16:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new DemonMonsterSelector());
                        break;

                    case 17:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new GooMonsterSelector());
                        break;

                    case 18:
                    case 19:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new UniqueMonsterSelector());
                        break;

                    case 20:
                    case 21:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new HiUndeadMonsterSelector());
                        break;

                    case 22:
                    case 23:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, new HiDragonMonsterSelector());
                        break;

                    case 24:
                    case 25:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, 100, new ReaverMonsterSelector());
                        break;

                    default:
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, (Difficulty * 3 / 2) + 5, null);
                        break;
                }
            }
        }

        public void AggravateMonsters(Monster? excludeMonster = null)
        {
            bool sleep = false;
            bool speed = false;
            for (int i = 0; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (excludeMonster != null && mPtr == excludeMonster)
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
                    if (mPtr.SmFriendly)
                    {
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            mPtr.SmFriendly = false;
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
            if (!GetItem(out int item, "Turn which item to gold? ", false, true, true, null))
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
                oPtr.IdentSense = true;
                NoticeCombineFlaggedAction.Set();
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
                RedrawGoldFlaggedAction.Set();
            }
            if (item >= 0)
            {
                Player.InvenItemIncrease(item, -amt);
                Player.InvenItemDescribe(item);
                Player.InvenItemOptimize(item);
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
            // Select an inventory slot where items can be disenchanted.
            BaseInventorySlot? inventorySlot = SingletonRepository.InventorySlots.WeightedRandom(_inventorySlot => _inventorySlot.CanBeDisenchanted).Choose();
            if (inventorySlot == null)
            {
                // There are no inventory slots capable of being disenchanted.
                return false;
            }

            // Select an item in the inventory slot to be disenchanted.
            int i = inventorySlot.WeightedRandom.Choose();
            Item oPtr = Player.Inventory[i];

            // The chosen slot does not have an item to disenchant.
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
            if ((oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false) && Program.Rng.RandomLessThan(100) < 71)
            {
                s = oPtr.Count != 1 ? "" : "s";
                MsgPrint($"Your {oName} ({i.IndexToLabel()}) resist{s} disenchantment!");
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
            MsgPrint($"Your {oName} ({i.IndexToLabel()}) {s} disenchanted!");
            UpdateBonusesFlaggedAction.Set();
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
            if (!GetItem(out int item, "Enchant which item? ", true, true, true, new WeaponItemFilter()))
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
            if (!GetItem(out int item, "Bless which weapon? ", true, true, true, new WeaponItemFilter()))
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
            if (oPtr.IdentCursed)
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
                oPtr.IdentCursed = false;
                oPtr.IdentSense = true;
                oPtr.Inscription = "uncursed";
                UpdateBonusesFlaggedAction.Set();
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
            UpdateBonusesFlaggedAction.Set();
        }

        public void CallChaos()
        {
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
                if (!GetDirectionWithAim(out int dir))
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
            int msec = Constants.DelayFactorInMilliseconds;
            GetCom("Choose a monster race (by symbol) to carnage: ", out char typ);
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (rPtr.Unique)
                {
                    continue;
                }
                if (rPtr.Character != typ)
                {
                    continue;
                }
                if (rPtr.Guardian)
                {
                    continue;
                }
                Level.Monsters.DeleteMonsterByIndex(i, true);
                if (playerCast)
                {
                    Player.TakeHit(Program.Rng.DieRoll(4), "the strain of casting Carnage");
                }
                Level.MoveCursorRelative(Player.MapY, Player.MapX);
                RedrawHpFlaggedAction.Set();
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
            if (Player.TimedColdResistance.TurnsRemaining != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedColdResistance.TurnsRemaining != 0 || Player.HasColdResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Strength);
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.HasColdResistance && Player.TimedColdResistance.TurnsRemaining != 0))
            {
                Player.InvenDamage(SetColdDestroy, inv);
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
                    Player.TimedBlindness.AddTimer(10 + Program.Rng.DieRoll(10));
                }
            }
            RemoveLightFlaggedAction.Set();
            RemoveViewFlaggedAction.Set();
            UpdateScentFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateMonstersFlaggedAction.Set();
            RedrawMapFlaggedAction.Set();
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
                if (rPtr.Evil)
                {
                    rPtr.Knowledge.Characteristics.Evil = true;
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
                if (rPtr.Invisible)
                {
                    rPtr.Knowledge.Characteristics.Invisible = true;
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
                if (rPtr.Nonliving || rPtr.Undead ||
                    rPtr.Cthuloid || rPtr.Demon)
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
                if (!rPtr.Invisible || Player.HasSeeInvisibility || Player.TimedSeeInvisibility.TurnsRemaining != 0)
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
                if (oPtr.Category == ItemTypeEnum.Gold)
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
                ItemTypeEnum tv = oPtr.Category;
                if (oPtr.IsFixedArtifact() || oPtr.IsRare() || string.IsNullOrEmpty(oPtr.RandartName) == false ||
                    tv == ItemTypeEnum.Amulet || tv == ItemTypeEnum.Ring || tv == ItemTypeEnum.Staff ||
                    tv == ItemTypeEnum.Wand || tv == ItemTypeEnum.Rod || tv == ItemTypeEnum.Scroll ||
                    tv == ItemTypeEnum.Potion || tv == ItemTypeEnum.LifeBook || tv == ItemTypeEnum.SorceryBook ||
                    tv == ItemTypeEnum.NatureBook || tv == ItemTypeEnum.ChaosBook || tv == ItemTypeEnum.DeathBook ||
                    tv == ItemTypeEnum.CorporealBook || tv == ItemTypeEnum.TarotBook || tv == ItemTypeEnum.FolkBook ||
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
                if (oPtr.Category != ItemTypeEnum.Gold)
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
            RedrawDTrapFlaggedAction.Set();
            RedrawMapFlaggedAction.Set();
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
                                Player.TimedStun.AddTimer(Program.Rng.DieRoll(50));
                                break;
                            }
                        case 3:
                            {
                                MsgPrint("You are crushed between the floor and ceiling!");
                                damage = Program.Rng.DiceRoll(10, 4);
                                Player.TimedStun.AddTimer(Program.Rng.DieRoll(50));
                                break;
                            }
                    }
                    int oy = Player.MapY;
                    int ox = Player.MapX;
                    Player.MapY = sy;
                    Player.MapX = sx;
                    Level.RedrawSingleLocation(oy, ox);
                    Level.RedrawSingleLocation(Player.MapY, Player.MapX);
                    Player.RecenterScreenAroundPlayer();
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
                        if (!rPtr.KillWall && !rPtr.PassWall)
                        {
                            sn = 0;
                            if (!rPtr.NeverMove)
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
                            string mName = mPtr.Name;
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
            RemoveLightFlaggedAction.Set();
            RemoveViewFlaggedAction.Set();
            UpdateScentFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateDistancesFlaggedAction.Set();
            RedrawHealthFlaggedAction.Set();
            RedrawMapFlaggedAction.Set();
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
            if (Player.TimedLightningResistance.TurnsRemaining != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (Player.HasLightningResistance)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedLightningResistance.TurnsRemaining != 0 || Player.HasLightningResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Dexterity);
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.TimedLightningResistance.TurnsRemaining != 0 && Player.HasLightningResistance))
            {
                Player.InvenDamage(SetElecDestroy, inv);
            }
        }

        public bool Enchant(Item oPtr, int n, int eflag)
        {
            int[] EnchantTable = {0, 10, 50, 100, 200, 300, 400, 500, 650, 800, 950, 987, 993, 995, 998, 1000};

            bool res = false;
            bool a = oPtr.IsFixedArtifact() || string.IsNullOrEmpty(oPtr.RandartName) == false;
            oPtr.RefreshFlagBasedProperties();
            int prob = oPtr.Count * 100;
            if (oPtr.Category == ItemTypeEnum.Bolt || oPtr.Category == ItemTypeEnum.Arrow || oPtr.Category == ItemTypeEnum.Shot)
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
                        chance = EnchantTable[oPtr.BonusToHit];
                    }
                    if (Program.Rng.DieRoll(1000) > chance && (!a || Program.Rng.RandomLessThan(100) < 50))
                    {
                        oPtr.BonusToHit++;
                        res = true;
                        if (oPtr.IsCursed() && !oPtr.Characteristics.PermaCurse && oPtr.BonusToHit >= 0 && Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentCursed = false;
                            oPtr.IdentSense = true;
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
                        chance = EnchantTable[oPtr.BonusDamage];
                    }
                    if (Program.Rng.DieRoll(1000) > chance && (!a || Program.Rng.RandomLessThan(100) < 50))
                    {
                        oPtr.BonusDamage++;
                        res = true;
                        if (oPtr.IsCursed() && !oPtr.Characteristics.PermaCurse && oPtr.BonusDamage >= 0 && Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentCursed = false;
                            oPtr.IdentSense = true;
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
                        chance = EnchantTable[oPtr.BonusArmourClass];
                    }
                    if (Program.Rng.DieRoll(1000) > chance && (!a || Program.Rng.RandomLessThan(100) < 50))
                    {
                        oPtr.BonusArmourClass++;
                        res = true;
                        if (oPtr.IsCursed() && !oPtr.Characteristics.PermaCurse && oPtr.BonusArmourClass >= 0 &&
                            Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentCursed = false;
                            oPtr.IdentSense = true;
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
            UpdateBonusesFlaggedAction.Set();
            NoticeCombineAndReorderFlaggedAction.Set();
            return true;
        }

        public bool EnchantSpell(int numHit, int numDam, int numAc)
        {
            bool okay = false;
            if (!GetItem(out int item, "Enchant which item? ", true, true, true, numAc != 0 ? new ArmourItemFilter() : new WeaponItemFilter()))
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
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            int tx = Player.MapX + (99 * Level.KeypadDirectionXOffset[dir]);
            int ty = Player.MapY + (99 * Level.KeypadDirectionYOffset[dir]);
            if (dir == 5 && TargetOkay())
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
            if (Player.TimedFireResistance.TurnsRemaining != 0)
            {
                dam = (dam + 2) / 3;
            }
            if (!(Player.TimedFireResistance.TurnsRemaining != 0 || Player.HasFireResistance) && Program.Rng.DieRoll(HurtChance) == 1)
            {
                Player.TryDecreasingAbilityScore(Ability.Strength);
            }
            Player.TakeHit(dam, kbStr);
            if (!(Player.HasFireResistance && Player.TimedFireResistance.TurnsRemaining != 0))
            {
                Player.InvenDamage(SetFireDestroy, inv);
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
            if (!GetItem(out int item, "Identify which item? ", true, true, true, null))
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
            oPtr.IdentMental = true;
            UpdateBonusesFlaggedAction.Set();
            NoticeCombineAndReorderFlaggedAction.Set();
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
                    Player.InvenItemIncrease(item, -amount);
                    Player.InvenItemOptimize(item);
                }
            }
            else if (item >= 0)
            {
                MsgPrint($"In your pack: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.InvenItemIncrease(item, -amount);
                    Player.InvenItemOptimize(item);
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
            if (!GetItem(out int item, "Identify which item? ", true, true, true, null))
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
            UpdateBonusesFlaggedAction.Set();
            NoticeCombineAndReorderFlaggedAction.Set();
            string oName = oPtr.Description(true, 3);
            if (item >= InventorySlot.MeleeWeapon)
            {
                MsgPrint($"{Player.DescribeWieldLocation(item)}: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.InvenItemIncrease(item, -amount);
                    Player.InvenItemOptimize(item);
                }
            }
            else if (item >= 0)
            {
                MsgPrint($"In your pack: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.InvenItemIncrease(item, -amount);
                    Player.InvenItemOptimize(item);
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
                    Player.InvenItemIncrease(i, -amount);
                    Player.InvenItemOptimize(i);
                    i--;
                }
            }
        }

        public bool LightArea(int dam, int rad)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;
            if (Player.TimedBlindness.TurnsRemaining == 0)
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
                if (oPtr.IdentMental)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(oPtr.Inscription) == false && oPtr.IdentSense)
                {
                    string q = oPtr.Inscription;
                    if (q == "cursed" || q == "broken" || q == "good" || q == "average" || q == "excellent" ||
                        q == "worthless" || q == "special" || q == "terrible")
                    {
                        oPtr.Inscription = string.Empty;
                    }
                }
                oPtr.IdentEmpty = false;
                oPtr.IdentKnown = false;
                oPtr.IdentSense = false;
            }
            UpdateBonusesFlaggedAction.Set();
            NoticeCombineAndReorderFlaggedAction.Set();
            Level.WizDark();
            return true;
        }

        public void MassCarnage(bool playerCast)
        {
            int msec = Constants.DelayFactorInMilliseconds;
            for (int i = 1; i < Level.MMax; i++)
            {
                Monster mPtr = Level.Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (rPtr.Unique)
                {
                    continue;
                }
                if (rPtr.Guardian)
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
                RedrawHpFlaggedAction.Set();
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
            if (rPtr.Unique || rPtr.Guardian)
            {
                return rPtr.Index;
            }
            int lev1 = rPtr.Level - ((Program.Rng.DieRoll(20) / Program.Rng.DieRoll(9)) + 1);
            int lev2 = rPtr.Level + (Program.Rng.DieRoll(20) / Program.Rng.DieRoll(9)) + 1;
            for (int i = 0; i < 1000; i++)
            {
                int r = Level.Monsters.GetMonNum(((Difficulty + rPtr.Level) / 2) + 5, null);
                if (r == 0)
                {
                    break;
                }
                rPtr = SingletonRepository.MonsterRaces[r];
                if (rPtr.Unique)
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
                    string mName = mPtr.IndefiniteWhenHiddenName;
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
            if (!GetItem(out int item, "Recharge which item? ", false, true, true, new RechargableItemFilter()))
            {
                if (item == -2)
                {
                    MsgPrint("You have nothing to recharge.");
                }
                return false;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            int lev = oPtr.BaseItemCategory.Level;
            if (oPtr.Category == ItemTypeEnum.Rod)
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
                        Player.InvenItemIncrease(item, -999);
                        Player.InvenItemDescribe(item);
                        Player.InvenItemOptimize(item);
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
                    oPtr.IdentKnown = false;
                    oPtr.IdentEmpty = false;
                }
            }
            NoticeCombineAndReorderFlaggedAction.Set();
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
            string[] ReportMagicDurations =
            {
                "for a short time", "for a little while", "for a while", "for a long while", "for a long time",
                "for a very long time", "for an incredibly long time", "until you hit a monster"
            };

            int i = 0, j, k;
            string[] info = new string[128];
            int[] info2 = new int[128];
            if (Player.TimedBlindness.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedBlindness.TurnsRemaining);
                info[i++] = "You cannot see";
            }
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedConfusion.TurnsRemaining);
                info[i++] = "You are confused";
            }
            if (Player.TimedFear.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedFear.TurnsRemaining);
                info[i++] = "You are terrified";
            }
            if (Player.TimedPoison.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedPoison.TurnsRemaining);
                info[i++] = "You are poisoned";
            }
            if (Player.TimedHallucinations.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedHallucinations.TurnsRemaining);
                info[i++] = "You are hallucinating";
            }
            if (Player.TimedBlessing.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedBlessing.TurnsRemaining);
                info[i++] = "You feel rightous";
            }
            if (Player.TimedHeroism.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedHeroism.TurnsRemaining);
                info[i++] = "You feel heroic";
            }
            if (Player.TimedSuperheroism.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedSuperheroism.TurnsRemaining);
                info[i++] = "You are in a battle rage";
            }
            if (Player.TimedProtectionFromEvil.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedProtectionFromEvil.TurnsRemaining);
                info[i++] = "You are protected from evil";
            }
            if (Player.TimedStoneskin.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedStoneskin.TurnsRemaining);
                info[i++] = "You are protected by a mystic shield";
            }
            if (Player.TimedInvulnerability.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedInvulnerability.TurnsRemaining);
                info[i++] = "You are invulnerable";
            }
            if (Player.TimedEtherealness.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedEtherealness.TurnsRemaining);
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
            if (Player.TimedAcidResistance.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedAcidResistance.TurnsRemaining);
                info[i++] = "You are resistant to acid";
            }
            if (Player.TimedLightningResistance.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedLightningResistance.TurnsRemaining);
                info[i++] = "You are resistant to lightning";
            }
            if (Player.TimedFireResistance.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedFireResistance.TurnsRemaining);
                info[i++] = "You are resistant to fire";
            }
            if (Player.TimedColdResistance.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedColdResistance.TurnsRemaining);
                info[i++] = "You are resistant to cold";
            }
            if (Player.TimedPoisonResistance.TurnsRemaining != 0)
            {
                info2[i] = ReportMagicsAux(Player.TimedPoisonResistance.TurnsRemaining);
                info[i++] = "You are resistant to poison";
            }
            ScreenBuffer savedScreen = Screen.Clone();
            for (k = 1; k < 24; k++)
            {
                Screen.PrintLine("", k, 13);
            }
            Screen.PrintLine("     Your Current Magic:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                string dummy = $"{info[j]} {ReportMagicDurations[info2[j]]}.";
                Screen.PrintLine(dummy, k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    Screen.PrintLine("-- more --", k, 15);
                    Inkey();
                    for (; k > 2; k--)
                    {
                        Screen.PrintLine("", k, 15);
                    }
                }
            }
            Screen.PrintLine("[Press any key to continue]", k, 13);
            Inkey();
            Screen.Restore(savedScreen);
        }

        public void SelfKnowledge()
        {
            int i = 0, j, k;
            Item oPtr;
            string[] info = new string[128];
            //int plev = Player.Level;
            //string dummy = "";
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
            string[]? selfKnowledgeInfo = Player.Race.SelfKnowledge(Player.Level);
            if (selfKnowledgeInfo != null)
            {
                foreach (string infoLine in selfKnowledgeInfo)
                {
                    info[i++] = infoLine;
                }
            }
            string[] mutations = Player.Dna.GetMutationList();
            if (mutations.Length > 0)
            {
                foreach (string m in mutations)
                {
                    info[i++] = m;
                }
            }
            if (Player.TimedBlindness.TurnsRemaining != 0)
            {
                info[i++] = "You cannot see.";
            }
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                info[i++] = "You are confused.";
            }
            if (Player.TimedFear.TurnsRemaining != 0)
            {
                info[i++] = "You are terrified.";
            }
            if (Player.TimedBleeding.TurnsRemaining != 0)
            {
                info[i++] = "You are bleeding.";
            }
            if (Player.TimedStun.TurnsRemaining != 0)
            {
                info[i++] = "You are stunned.";
            }
            if (Player.TimedPoison.TurnsRemaining != 0)
            {
                info[i++] = "You are poisoned.";
            }
            if (Player.TimedHallucinations.TurnsRemaining != 0)
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
            if (Player.TimedBlessing.TurnsRemaining != 0)
            {
                info[i++] = "You feel rightous.";
            }
            if (Player.TimedHeroism.TurnsRemaining != 0)
            {
                info[i++] = "You feel heroic.";
            }
            if (Player.TimedSuperheroism.TurnsRemaining != 0)
            {
                info[i++] = "You are in a battle rage.";
            }
            if (Player.TimedProtectionFromEvil.TurnsRemaining != 0)
            {
                info[i++] = "You are protected from evil.";
            }
            if (Player.TimedStoneskin.TurnsRemaining != 0)
            {
                info[i++] = "You are protected by a mystic shield.";
            }
            if (Player.TimedInvulnerability.TurnsRemaining != 0)
            {
                info[i++] = "You are temporarily invulnerable.";
            }
            if (Player.TimedEtherealness.TurnsRemaining != 0)
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
            else if (Player.HasAcidResistance && Player.TimedAcidResistance.TurnsRemaining != 0)
            {
                info[i++] = "You resist acid exceptionally well.";
            }
            else if (Player.HasAcidResistance || Player.TimedAcidResistance.TurnsRemaining != 0)
            {
                info[i++] = "You are resistant to acid.";
            }
            if (Player.HasLightningImmunity)
            {
                info[i++] = "You are completely immune to lightning.";
            }
            else if (Player.HasLightningResistance && Player.TimedLightningResistance.TurnsRemaining != 0)
            {
                info[i++] = "You resist lightning exceptionally well.";
            }
            else if (Player.HasLightningResistance || Player.TimedLightningResistance.TurnsRemaining != 0)
            {
                info[i++] = "You are resistant to lightning.";
            }
            if (Player.HasFireImmunity)
            {
                info[i++] = "You are completely immune to fire.";
            }
            else if (Player.HasFireResistance && Player.TimedFireResistance.TurnsRemaining != 0)
            {
                info[i++] = "You resist fire exceptionally well.";
            }
            else if (Player.HasFireResistance || Player.TimedFireResistance.TurnsRemaining != 0)
            {
                info[i++] = "You are resistant to fire.";
            }
            if (Player.HasColdImmunity)
            {
                info[i++] = "You are completely immune to cold.";
            }
            else if (Player.HasColdResistance && Player.TimedColdResistance.TurnsRemaining != 0)
            {
                info[i++] = "You resist cold exceptionally well.";
            }
            else if (Player.HasColdResistance || Player.TimedColdResistance.TurnsRemaining != 0)
            {
                info[i++] = "You are resistant to cold.";
            }
            if (Player.HasPoisonResistance && Player.TimedPoisonResistance.TurnsRemaining != 0)
            {
                info[i++] = "You resist poison exceptionally well.";
            }
            else if (Player.HasPoisonResistance || Player.TimedPoisonResistance.TurnsRemaining != 0)
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
            ScreenBuffer savedScreen = Screen.Clone();
            for (k = 1; k < 24; k++)
            {
                Screen.PrintLine("", k, 13);
            }
            Screen.PrintLine("     Your Attributes:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                Screen.PrintLine(info[j], k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    Screen.PrintLine("-- more --", k, 15);
                    Inkey();
                    for (; k > 2; k--)
                    {
                        Screen.PrintLine("", k, 15);
                    }
                }
            }
            Screen.PrintLine("[Press any key to continue]", k, 13);
            Inkey();
            Screen.Restore(savedScreen);
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
            int maxReaver = (Difficulty / 50) + Program.Rng.DieRoll(6);
            for (int i = 0; i < maxReaver; i++)
            {
                Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, 100, new ReaverMonsterSelector());
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
                            if (Level.Monsters[Level.Grid[oy + yy][ox + xx].MonsterIndex].Race.TeleportSelf &&
                                !Level.Monsters[Level.Grid[oy + yy][ox + xx].MonsterIndex].Race.ResistTeleport)
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
            Player.RecenterScreenAroundPlayer();
            UpdateScentFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateDistancesFlaggedAction.Set();
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
            Player.RecenterScreenAroundPlayer();
            UpdateScentFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateDistancesFlaggedAction.Set();
            HandleStuff();
        }

        public void TeleportSwap(int dir)
        {
            int tx, ty;
            if (dir == 5 && TargetOkay())
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
                if (rPtr.ResistTeleport)
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
                    Player.RecenterScreenAroundPlayer();
                    UpdateScentFlaggedAction.Set();
                    UpdateLightFlaggedAction.Set();
                    UpdateViewFlaggedAction.Set();
                    UpdateDistancesFlaggedAction.Set();
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
            if (Player.TimedBlindness.TurnsRemaining == 0)
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
            UpdateScentFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateMonstersFlaggedAction.Set();
            RedrawMapFlaggedAction.Set();
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
                    if (rPtr.Stupid)
                    {
                        chance = 10;
                    }
                    if (rPtr.Smart)
                    {
                        chance = 100;
                    }
                    if (mPtr.SleepLevel != 0 && Program.Rng.RandomLessThan(100) < chance)
                    {
                        mPtr.SleepLevel = 0;
                        if (mPtr.IsVisible)
                        {
                            string mName = mPtr.Name;
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
            BaseInventorySlot? inventorySlot = new ArmourInventorySlotWeightedRandom(this).Choose();
            if (inventorySlot == null)
            {
                // No inventory slots are affected by acid or the slot is empty.
                return false;
            }
            Item oPtr = Player.Inventory[inventorySlot.WeightedRandom.Choose()];
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
            UpdateBonusesFlaggedAction.Set();
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
                oPtr.IdentCursed = false;
                oPtr.IdentSense = true;
                if (oPtr.RandartItemCharacteristics.Cursed)
                {
                    oPtr.RandartItemCharacteristics.Cursed = false;
                }
                if (oPtr.RandartItemCharacteristics.HeavyCurse)
                {
                    oPtr.RandartItemCharacteristics.HeavyCurse = false;
                }
                oPtr.Inscription = "uncursed";
                UpdateBonusesFlaggedAction.Set();
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
            flg |= ProjectionFlag.ProjectThru;
            int tx = Player.MapX + Level.KeypadDirectionXOffset[dir];
            int ty = Player.MapY + Level.KeypadDirectionYOffset[dir];
            if (dir == 5 && TargetOkay())
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

        public void DoCmdEquip()
        {
            // We're viewing equipment
            ViewingEquipment = true;
            ScreenBuffer savedScreen = Screen.Clone();
            // We're interested in seeing everything
            Player.ShowEquip(null);
            // Get a command
            string outVal = $"Equipment: carrying {Player.WeightCarried / 10}.{Player.WeightCarried % 10} pounds ({Player.WeightCarried * 100 / (Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
            Screen.PrintLine(outVal, 0, 0);
            QueuedCommand = Inkey();
            Screen.Restore(savedScreen);
            // Display details if the player wants
            if (QueuedCommand == '\x1b')
            {
                QueuedCommand = (char)0;
            }
            else
            {
                // If the player selects a command that uses getitem, it will automatically show the
                // inventory
                ViewingItemList = true;
            }
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
            foreach (Command command in SingletonRepository.GameCommands)
            {
                // TODO: The IF statement below can be converted into a dictionary with the applicable object 
                // attached for improved performance.
                if (command.IsEnabled && command.Key == c)
                {
                    bool more = command.Execute();

                    if (!more)
                    {
                        Disturb(false);
                    }
                    else if (!isRepeated && command.Repeat.HasValue)
                    {
                        // Apply the default repeat value.  This handles the 0, for no repeat and default repeat count (TBDocs+ ... count = 99).
                        // Only apply the default once.
                        CommandArgument = command.Repeat.Value;
                    }

                    if (CommandArgument > 0)
                    {
                        CommandRepeat = CommandArgument - 1;
                        RedrawStateFlaggedAction.Set();
                        CommandArgument = 0;
                    }

                    // The command was processed.  Skip the SWITCH statement.
                    return;
                }
            }
            Screen.PrintLine("Type '?' for a list of commands.", 0, 0);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns>Returns true, if the command can be repeated; false, if the command succeeds or is futile.</returns>
        public bool BashClosedDoor(int y, int x)
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
                MovePlayer(y, x, false);
                UpdateLightFlaggedAction.Set();
                UpdateViewFlaggedAction.Set();
                UpdateDistancesFlaggedAction.Set();
            }
            else if (Program.Rng.RandomLessThan(100) < Player.AbilityScores[Ability.Dexterity].DexTheftAvoidance + Player.Level)
            {
                MsgPrint("The door holds firm.");
                more = true;
            }
            else
            {
                MsgPrint("You are off-balance.");
                Player.TimedParalysis.AddTimer(2 + Program.Rng.RandomLessThan(2));
            }
            return more;
        }

        /// <summary>
        /// Give a fire brand to a set of bolts we're carrying
        /// </summary>
        public void BrandBolts()
        {
            for (int i = 0; i < InventorySlot.PackCount; i++)
            {
                // Find a set of non-artifact bolts in our inventory
                Item item = Player.Inventory[i];
                if (item.Category != ItemTypeEnum.Bolt)
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
                string cast = Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? "recite" : "cast";
                string spell = Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? "prayer" : "spell";
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
            if (Player.TimedConfusion.TurnsRemaining != 0)
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
            if (Player.TimedStun.TurnsRemaining != 0)
            {
                difficulty += Player.TimedStun.TurnsRemaining;
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
            RedrawHpFlaggedAction.Set();
            RedrawManaFlaggedAction.Set();
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
        /// <returns>True if the command can be repeated; false, if the command succeeds or is futile.</returns>
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
                UpdateMonstersFlaggedAction.Set();
                UpdateLightFlaggedAction.Set();
                UpdateViewFlaggedAction.Set();
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
        public int CountChests(out GridCoordinate? mapCoordinate, bool trappedOnly)
        {
            int count = 0;
            mapCoordinate = null;
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
                if (trappedOnly && (!item.IsKnown() || ObjectRepository.ChestTrapConfigurations[item.TypeSpecificValue].NotTrapped))
                {
                    continue;
                }
                count++;
                // Remember the coordinate
                mapCoordinate = new GridCoordinate(xx, yy);
            }
            return count;
        }

        /// <summary>
        /// Count the number of closed doors around the player, filling in a map coordinate with the
        /// location of the last one found
        /// </summary>
        /// <param name="mapCoordinate"> The location around which to search </param>
        /// <returns> The number of closed doors </returns>
        public int CountClosedDoors(out GridCoordinate? mapCoordinate)
        {
            int count = 0;
            mapCoordinate = null;
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
                mapCoordinate = new GridCoordinate(xx, yy);
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
        public int CountKnownTraps(out GridCoordinate? mapCoordinate)
        {
            int count = 0;
            mapCoordinate = null;
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
                mapCoordinate = new GridCoordinate(xx, yy);
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
        public int CountOpenDoors(out GridCoordinate? mapCoordinate)
        {
            int count = 0;
            mapCoordinate = null;
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
                mapCoordinate = new GridCoordinate(xx, yy);
            }
            return count;
        }

        /// <summary>
        /// Create phlogiston to refill a lantern or torch with
        /// </summary>
        public void CreatePhlogiston()
        {
            int maxPhlogiston;
            LightsourceInventorySlot lightsourceInventorySlot = SingletonRepository.InventorySlots.Get<LightsourceInventorySlot>();
            Item item = Player.Inventory[lightsourceInventorySlot.WeightedRandom.Choose()];
            // Maximum phlogiston is the capacity of the light source
            if (item.Category == ItemTypeEnum.Light && item.ItemSubCategory == LightType.Lantern)
            {
                maxPhlogiston = Constants.FuelLamp;
            }
            else if (item.Category == ItemTypeEnum.Light && item.ItemSubCategory == LightType.Torch)
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
            UpdateTorchRadiusFlaggedAction.Set();
        }

        /// <summary>
        /// Heavily curse the players armour
        /// </summary>
        /// <returns> true if there was armour to curse, false otherwise </returns>
        public bool CurseArmour()
        {
            BaseInventorySlot? inventorySlot = SingletonRepository.InventorySlots.WeightedRandom(_inventorySlot => _inventorySlot.CanBeCursed).Choose();

            // Check to see if there are any slots capable of cursing.
            if (inventorySlot == null)
            {
                return false;
            }

            // Choose an item from the slot.
            Item item = Player.Inventory[inventorySlot.WeightedRandom.Choose()];

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
                item.FixedArtifact = null;
                item.RareItemTypeIndex = Enumerations.RareItemType.ArmourBlasted;
                item.BonusArmourClass = 0 - Program.Rng.DieRoll(5) - Program.Rng.DieRoll(5);
                item.BonusToHit = 0;
                item.BonusDamage = 0;
                item.BaseArmourClass = 0;
                item.DamageDice = 0;
                item.DamageDiceSides = 0;
                item.RandartItemCharacteristics.Clear();
                item.IdentCursed = true;
                item.IdentBroken = true;
                UpdateBonusesFlaggedAction.Set();
                UpdateManaFlaggedAction.Set();
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
                item.FixedArtifact = null;
                item.RareItemTypeIndex = Enumerations.RareItemType.WeaponShattered;
                item.BonusToHit = 0 - Program.Rng.DieRoll(5) - Program.Rng.DieRoll(5);
                item.BonusDamage = 0 - Program.Rng.DieRoll(5) - Program.Rng.DieRoll(5);
                item.BonusArmourClass = 0;
                item.BaseArmourClass = 0;
                item.DamageDice = 0;
                item.DamageDiceSides = 0;
                item.RandartItemCharacteristics.Clear();
                item.IdentCursed = true;
                item.IdentBroken = true;
                UpdateBonusesFlaggedAction.Set();
                UpdateManaFlaggedAction.Set();
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
            if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
            {
                i /= 10;
            }
            // Disarming is tricky when confused
            if (Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0)
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
            else if (ObjectRepository.ChestTrapConfigurations[item.TypeSpecificValue].NotTrapped)
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
        /// <returns>True, if the command can be repeated; false if the disarm succeeds or is futile.</returns>
        public bool DisarmTrap(int y, int x)
        {
            bool more = false;
            // Disarming a trap costs a turn
            EnergyUse = 100;
            GridTile tile = Level.Grid[y][x];
            string trapName = tile.FeatureType.Description;
            int i = Player.SkillDisarmTraps;
            // Difficult, but possible, to disarm by feel
            if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
            {
                i /= 10;
            }
            // Difficult to disarm when we're confused
            if (Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0)
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
                MovePlayer(y, x, true);
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
                MovePlayer(y, x, true);
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
                case ItemTypeEnum.Wand:
                    cost = price / 150;
                    break;

                case ItemTypeEnum.Scroll:
                    cost = price / 10;
                    break;

                case ItemTypeEnum.Potion:
                    cost = price / 20;
                    break;

                case ItemTypeEnum.Rod:
                    cost = price / 250;
                    break;

                case ItemTypeEnum.Staff:
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
                RedrawManaFlaggedAction.Set();
                return true;
            }
            // Use some mana in the attempt, even if we failed
            MsgPrint("You mana is insufficient to power the effect.");
            Player.Mana -= Program.Rng.RandomLessThan(Player.Mana / 2);
            RedrawManaFlaggedAction.Set();
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
            for (int i = 0; i < InventorySlot.PackCount; i++)
            {
                Item item = Player.Inventory[i];
                if (item.BaseItemCategory == null)
                {
                    continue;
                }
                // If the item is a spike, return it
                if (item.Category == ItemTypeEnum.Spike)
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
            if (item.Category == ItemTypeEnum.LifeBook || item.Category == ItemTypeEnum.SorceryBook ||
                item.Category == ItemTypeEnum.NatureBook || item.Category == ItemTypeEnum.ChaosBook ||
                item.Category == ItemTypeEnum.DeathBook || item.Category == ItemTypeEnum.TarotBook)
            {
                return item.ItemSubCategory > 1;
            }
            return false;
        }

        /// <summary>
        /// Attempt to move the player in the given direction
        /// </summary>
        /// <param name="direction"> The direction in which to move </param>
        /// <param name="dontPickup"> Whether or not to skip picking up any objects we step on </param>
        public void MovePlayer(int direction, bool dontPickup)
        {
            int newY = Player.MapY + Level.KeypadDirectionYOffset[direction];
            int newX = Player.MapX + Level.KeypadDirectionXOffset[direction];
            MovePlayer(newY, newX, dontPickup);
        }

        public void MovePlayer(int newY, int newX, bool dontPickup)
        { 
            bool canPassWalls = false;
            GridTile tile = Level.Grid[newY][newX];
            Monster monster = Level.Monsters[tile.MonsterIndex];
            // Check if we can pass through walls
            if (Player.TimedEtherealness.TurnsRemaining != 0 || Player.Race.IsEthereal)
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
                if (monster.SmFriendly && !(Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0 || !monster.IsVisible || Player.TimedStun.TurnsRemaining != 0) &&
                    (Level.GridPassable(newY, newX) || canPassWalls))
                {
                    // Wake up the monster, and track it
                    monster.SleepLevel = 0;
                    string monsterName = monster.Name;
                    // If we can see it, no need to mention it
                    if (monster.IsVisible)
                    {
                        HealthTrack(tile.MonsterIndex);
                    }
                    // If we can't see it then let us push past it and tell us what happened
                    else if (Level.GridPassable(Player.MapY, Player.MapX) || monster.Race.PassWall)
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
                DisarmTrap(newY, newX);
                return;
            }
            // If the tile we're moving onto isn't passable then we can't move onto it
            if (!Level.GridPassable(newY, newX) && !canPassWalls)
            {
                Disturb(false);
                // If we can't see it and haven't memories it, tell us what we bumped into
                if (tile.TileFlags.IsClear(GridTile.PlayerMemorised) &&
                    (Player.TimedBlindness.TurnsRemaining != 0 || tile.TileFlags.IsClear(GridTile.PlayerLit)))
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
                        if (!(Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedStun.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0))
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
                        if (!(Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedStun.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0))
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
                RedrawDTrapFlaggedAction.Set();
            }
            // If we're leaving an area where we've detected traps at a run, then stop running
            if (Running != 0 && oldTrapsDetected && !newTrapsDetected)
            {
                if (!(Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedStun.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0))
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
            Player.RecenterScreenAroundPlayer();
            // We'll need to update and redraw various things
            UpdateScentFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
            UpdateDistancesFlaggedAction.Set();
            RedrawMapFlaggedAction.Set();
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
        /// <returns>True if the command can be repeated; false, if the command succeeds or is futile.</returns>
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
                if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
                {
                    i /= 10;
                }
                // Hard to pick locks when you're confused or hallucinating
                if (Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0)
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
                    UpdateMonstersFlaggedAction.Set();
                    UpdateLightFlaggedAction.Set();
                    UpdateViewFlaggedAction.Set();
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
                UpdateMonstersFlaggedAction.Set();
                UpdateLightFlaggedAction.Set();
                UpdateViewFlaggedAction.Set();
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
                if (item.Category == ItemTypeEnum.Gold)
                {
                    MsgPrint($"You collect {item.TypeSpecificValue} gold pieces worth of {itemName}.");
                    Player.Gold += item.TypeSpecificValue;
                    RedrawGoldFlaggedAction.Set();
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
                    else if (!Player.InvenCarryOkay(item))
                    {
                        MsgPrint($"You have no room for {itemName}.");
                    }
                    else
                    {
                        // Actually pick up the item
                        int slot = Player.InvenCarry(item, false);
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
            MartialArtsAttack[] MaBlows =
            {
                new MartialArtsAttack("You punch {0}.", 1, 0, 1, 4, 0),
                new MartialArtsAttack("You kick {0}.", 2, 0, 1, 6, 0),
                new MartialArtsAttack("You strike {0}.", 3, 0, 1, 7, 0),
                new MartialArtsAttack("You hit {0} with your knee.", 5, 5, 2, 3, Constants.MaKnee),
                new MartialArtsAttack("You hit {0} with your elbow.", 7, 5, 1, 8, 0),
                new MartialArtsAttack("You butt {0}.", 9, 10, 2, 5, 0),
                new MartialArtsAttack("You kick {0}.", 11, 10, 3, 4, Constants.MaSlow),
                new MartialArtsAttack("You uppercut {0}.", 13, 12, 4, 4, 6),
                new MartialArtsAttack("You double-kick {0}.", 16, 15, 5, 4, 8),
                new MartialArtsAttack("You hit {0} with a Cat's Claw.", 20, 20, 5, 5, 0),
                new MartialArtsAttack("You hit {0} with a jump kick.", 25, 25, 5, 6, 10),
                new MartialArtsAttack("You hit {0} with an Eagle's Claw.", 29, 25, 6, 6, 0),
                new MartialArtsAttack("You hit {0} with a circle kick.", 33, 30, 6, 8, 10),
                new MartialArtsAttack("You hit {0} with an Iron Fist.", 37, 35, 8, 8, 10),
                new MartialArtsAttack("You hit {0} with a flying kick.", 41, 35, 8, 10, 12),
                new MartialArtsAttack("You hit {0} with a Dragon Fist.", 45, 35, 10, 10, 16),
                new MartialArtsAttack("You hit {0} with a Crushing Blow.", 48, 35, 10, 12, 18)
            };


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
            if (Player.BaseCharacterClass.ID == CharacterClass.Rogue)
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
            string monsterName = monster.Name;
            // If we can see the monster, track its health
            if (monster.IsVisible)
            {
                HealthTrack(tile.MonsterIndex);
            }
            // if the monster is our friend and we're not confused, we can avoid hitting it
            if (monster.SmFriendly && !(Player.TimedStun.TurnsRemaining != 0 || Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0 || !monster.IsVisible))
            {
                MsgPrint($"You stop to avoid hitting {monsterName}.");
                return;
            }
            // Can't attack if we're afraid
            if (Player.TimedFear.TurnsRemaining != 0)
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
                    PlaySound(SoundEffect.MeleeHit);
                    // Tell the player they hit it with the appropriate message
                    if (!(backstab || stabFleeing))
                    {
                        if (!((Player.BaseCharacterClass.ID == CharacterClass.Monk || Player.BaseCharacterClass.ID == CharacterClass.Mystic) && MartialArtistEmptyHands()))
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
                        if (!(race.Undead || race.Nonliving))
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
                    if ((Player.BaseCharacterClass.ID == CharacterClass.Monk || Player.BaseCharacterClass.ID == CharacterClass.Mystic) && MartialArtistEmptyHands())
                    {
                        int specialEffect = 0;
                        int stunEffect = 0;
                        int times;
                        MartialArtsAttack martialArtsAttack = MaBlows[0];
                        MartialArtsAttack oldMartialArtsAttack = MaBlows[0];
                        // Monsters of various types resist being stunned by martial arts
                        int resistStun = 0;
                        if (race.Unique)
                        {
                            resistStun += 88;
                        }
                        if (race.ImmuneConfusion)
                        {
                            resistStun += 44;
                        }
                        if (race.ImmuneSleep)
                        {
                            resistStun += 44;
                        }
                        if (race.Undead || race.Nonliving)
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
                                martialArtsAttack = MaBlows[Program.Rng.DieRoll(Constants.MaxMa) - 1];
                            } while (martialArtsAttack.MinLevel > Player.Level || Program.Rng.DieRoll(Player.Level) < martialArtsAttack.Chance);
                            // We've chosen an attack, use it if it's better than the previous
                            // choice (unless we're stunned or confused in which case we're stuck
                            // with the weakest attack type
                            if (martialArtsAttack.MinLevel > oldMartialArtsAttack.MinLevel && !(Player.TimedStun.TurnsRemaining != 0 || Player.TimedConfusion.TurnsRemaining != 0))
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
                            if (race.Male)
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
                            if (!race.NeverMove ||
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
                            if (!race.Unique && Program.Rng.DieRoll(Player.Level) > race.Level &&
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
                            } while (Program.Rng.DieRoll(item.FixedArtifactIndex == FixedArtifactId.SwordVorpalBlade ? 2 : 4) == 1);
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
                    if (monster.SmFriendly)
                    {
                        MsgPrint($"{monsterName} gets angry!");
                        monster.SmFriendly = false;
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
                        if (race.ImmuneConfusion)
                        {
                            if (monster.IsVisible)
                            {
                                race.Knowledge.Characteristics.ImmuneConfusion = true;
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
                        if (!(race.Unique || race.BreatheChaos ||
                              race.Guardian))
                        {
                            int newRaceIndex = PolymorphMonster(monster.Race);
                            if (newRaceIndex != monster.Race.Index)
                            {
                                MsgPrint($"{monsterName} changes!");
                                Level.Monsters.DeleteMonsterByIndex(tile.MonsterIndex, true);
                                MonsterRace newRace = SingletonRepository.MonsterRaces[newRaceIndex];
                                Level.Monsters.PlaceMonsterAux(y, x, newRace, false, false, false);
                                monster = Level.Monsters[tile.MonsterIndex];
                                monsterName = monster.Name;
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
                UpdateTorchRadiusFlaggedAction.Set();
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
            if (!GetItem(out int itemIndex, "Rustproof which piece of armour? ", true, true, true, new ArmourItemFilter()))
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
            if (item.BonusArmourClass < 0 && !item.IdentCursed)
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

        public void DoActivate()
        {
            int itemIndex = -999;
            if (itemIndex == -999)
            {
                // No item passed in, so get one; filtering to activatable items only
                if (!GetItem(out itemIndex, "Activate which item? ", true, false, false, new ActivatableItemFilter()))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have nothing to activate.");
                    }
                    return;
                }
            }
            // Get the item from the index
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Check if the item is activatable
            if (!Player.ItemMatchesFilter(item, new ActivatableItemFilter()))
            {
                MsgPrint("You can't activate that!");
                return;
            }
            // Activating an item uses 100 energy
            EnergyUse = 100;
            // Get the level of the item
            int itemLevel = item.BaseItemCategory.Level;
            if (item.FixedArtifact != null && item.IsFixedArtifact())
            {
                itemLevel = item.FixedArtifact.Level;
            }
            // Work out the chance of using the item successfully based on its level and the
            // player's skill
            int chance = Player.SkillUseDevice;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always give a slight chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // If we fail our use item roll just tell us and quit
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                MsgPrint("You failed to activate it properly.");
                return;
            }
            // If the item is still recharging, then just tell us and quit
            if (item.RechargeTimeLeft != 0)
            {
                MsgPrint("It whines, glows and fades...");
                return;
            }
            // We passed the checks, so the item is activated
            MsgPrint("You activate it...");
            PlaySound(SoundEffect.ActivateArtifact);
            // If it is a random artifact then use its ability and quit
            if (string.IsNullOrEmpty(item.RandartName) == false)
            {
                ActivateRandomArtifact(item);
                return;
            }
            // If it's a fixed artifact then use its ability
            if (item.FixedArtifact != null && typeof(IActivatible).IsAssignableFrom(item.FixedArtifact.BaseFixedArtifact.GetType()))
            {
                IActivatible activatibleFixedArtifact = (IActivatible)item.FixedArtifact.BaseFixedArtifact;
                activatibleFixedArtifact.ActivateItem(this, item);
                return;
            }
            // If it wasn't an artifact, then check the other types of activatable item Planar
            // weapon teleports you
            if (item.RareItemTypeIndex == Enumerations.RareItemType.WeaponPlanarWeapon)
            {
                TeleportPlayer(100);
                item.RechargeTimeLeft = 50 + Program.Rng.DieRoll(50);
                return;
            }
            // Dragon armour gives you a ball of the relevant damage type
            if (item.Category == ItemTypeEnum.DragArmor)
            {
                if (!GetDirectionWithAim(out int dir))
                {
                    return;
                }
                switch (item.ItemSubCategory) // TODO: Move to ItemCategories
                {
                    case DragonArmour.SvDragonBlue:
                        {
                            MsgPrint("You breathe lightning.");
                            FireBall(new ProjectElec(this), dir, 100, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonWhite:
                        {
                            MsgPrint("You breathe frost.");
                            FireBall(new ProjectCold(this), dir, 110, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonBlack:
                        {
                            MsgPrint("You breathe acid.");
                            FireBall(new ProjectAcid(this), dir, 130, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonGreen:
                        {
                            MsgPrint("You breathe poison gas.");
                            FireBall(new ProjectPois(this), dir, 150, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonRed:
                        {
                            MsgPrint("You breathe fire.");
                            FireBall(new ProjectFire(this), dir, 200, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonMultihued:
                        {
                            chance = Program.Rng.RandomLessThan(5);
                            string element = chance == 1 ? "lightning" : (chance == 2 ? "frost" : (chance == 3 ? "acid" : (chance == 4 ? "poison gas" : "fire")));
                            MsgPrint($"You breathe {element}.");
                            switch (chance)
                            {
                                case 0:
                                    FireBall(new ProjectFire(this),
                                        dir, 250, -2);
                                    break;

                                case 1:
                                    FireBall(new ProjectElec(this),
                                        dir, 250, -2);
                                    break;

                                case 2:
                                    FireBall(new ProjectCold(this),
                                        dir, 250, -2);
                                    break;

                                case 3:
                                    FireBall(new ProjectAcid(this),
                                        dir, 250, -2);
                                    break;

                                case 4:
                                    FireBall(new ProjectPois(this),
                                        dir, 250, -2);
                                    break;
                            }
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(225) + 225;
                            break;
                        }
                    case DragonArmour.SvDragonBronze:
                        {
                            MsgPrint("You breathe confusion.");
                            FireBall(new ProjectConfusion(this), dir, 120, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonGold:
                        {
                            MsgPrint("You breathe sound.");
                            FireBall(new ProjectSound(this), dir, 130, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(450) + 450;
                            break;
                        }
                    case DragonArmour.SvDragonChaos:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 1 ? "chaos" : "disenchantment";
                            MsgPrint($"You breathe {element}.");
                            FireBall(projectile: chance == 1 ? (Projectile)new ProjectChaos(this) : new ProjectDisenchant(this), dir: dir, dam: 220, rad: -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonLaw:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 1 ? "sound" : "shards";
                            MsgPrint($"You breathe {element}.");
                            FireBall(chance == 1 ? (Projectile)new ProjectSound(this) : new ProjectExplode(this), dir, 230, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonBalance:
                        {
                            chance = Program.Rng.RandomLessThan(4);
                            string element = chance == 1
                                ? "chaos"
                                : (chance == 2 ? "disenchantment" : (chance == 3 ? "sound" : "shards"));
                            MsgPrint($"You breathe {element}.");
                            FireBall(chance == 1 ? new ProjectChaos(this) : (chance == 2 ? new ProjectDisenchant(this) : (chance == 3 ? (Projectile)new ProjectSound(this) : new ProjectExplode(this))), dir, 250, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonShining:
                        {
                            chance = Program.Rng.RandomLessThan(2);
                            string element = chance == 0 ? "light" : "darkness";
                            MsgPrint($"You breathe {element}.");
                            FireBall(chance == 0 ? (Projectile)new ProjectLight(this) : new ProjectDark(this), dir, 200, -2);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                    case DragonArmour.SvDragonPower:
                        {
                            MsgPrint("You breathe the elements.");
                            FireBall(new ProjectMissile(this), dir, 300, -3);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(300) + 300;
                            break;
                        }
                }
                return;
            }
            // Elemental rings give you a ball of the appropriate element
            if (item.Category == ItemTypeEnum.Ring)
            {
                if (!GetDirectionWithAim(out int dir))
                {
                    return;
                }
                switch (item.ItemSubCategory)
                {
                    case RingType.Acid:
                        {
                            FireBall(new ProjectAcid(this), dir, 50, 2);
                            Player.TimedAcidResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    case RingType.Ice:
                        {
                            FireBall(new ProjectCold(this), dir, 50, 2);
                            Player.TimedColdResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                    case RingType.Flames:
                        {
                            FireBall(new ProjectFire(this), dir, 50, 2);
                            Player.TimedFireResistance.AddTimer(Program.Rng.DieRoll(20) + 20);
                            item.RechargeTimeLeft = Program.Rng.RandomLessThan(50) + 50;
                            break;
                        }
                }
            }
            // We ran out of item types
            MsgPrint("Oops. That object cannot be activated.");
        }

        public bool GetSpell(out int sn, string prompt, int sval, bool known, bool realm2, Player player)
        {
            int i;
            int spell;
            int num = 0;
            int[] spells = new int[64];
            Realm? useRealm = realm2 ? player.Realm2 : player.Realm1;
            string p = player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? "prayer" : "spell";
            for (spell = 0; spell < 32; spell++)
            {
                if ((Constants.BookSpellFlags[sval] & (1u << spell)) != 0)
                {
                    spells[num++] = spell;
                }
            }
            bool okay = false;
            sn = -2;
            for (i = 0; i < num; i++)
            {
                if (player.SpellOkay(spells[i], known, realm2))
                {
                    okay = true;
                }
            }
            if (!okay)
            {
                return false;
            }
            sn = -1;
            bool flag = false;
            ScreenBuffer? savedScreen = null;
            string outVal = $"({p}s {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) {prompt} which {p}? ";
            while (!flag && GetCom(outVal, out char choice) && !Shutdown)
            {
                if (choice == ' ' || choice == '*' || choice == '?')
                {
                    if (savedScreen == null)
                    {
                        savedScreen = Screen.Clone();
                        player.PrintSpells(spells, num, 1, 20, useRealm);
                    }
                    else
                    {
                        Screen.Restore(savedScreen);
                        savedScreen = null;
                    }
                    continue;
                }
                bool ask = char.IsUpper(choice);
                if (ask)
                {
                    choice = char.ToLower(choice);
                }
                i = char.IsLower(choice) ? choice.LetterToNumber() : -1;
                if (i < 0 || i >= num)
                {
                    continue;
                }
                spell = spells[i];
                if (!player.SpellOkay(spell, known, realm2))
                {
                    MsgPrint($"You may not {prompt} that {p}.");
                    continue;
                }
                if (ask)
                {
                    Spell sPtr = Spells[realm2 ? 1 : 0][spell % 32];
                    string tmpVal = $"{prompt} {sPtr.Name} ({sPtr.ManaCost} mana, {sPtr.FailureChance(player)}% fail)? ";
                    if (!GetCheck(tmpVal))
                    {
                        continue;
                    }
                }
                flag = true;
            }
            if (savedScreen != null)
            {
                Screen.Restore(savedScreen);
            }
            if (!flag)
            {
                return false;
            }
            sn = spell;
            return true;
        }

        public bool DoBash()
        {
            // Assume it won't disturb us
            bool more = false;

            // Get the direction to bash
            if (GetDirectionNoAim(out int dir))
            {
                int y = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int x = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[y][x];
                // Can only bash closed doors
                if (!tile.FeatureType.IsClosedDoor)
                {
                    MsgPrint("You see nothing there to bash.");
                }
                else if (tile.MonsterIndex != 0)
                {
                    // Oops - a montser got in the way
                    EnergyUse = 100;
                    MsgPrint("There is a monster in the way!");
                    PlayerAttackMonster(y, x);
                }
                else
                {
                    // Bash the door
                    more = BashClosedDoor(y, x);
                }
            }
            return more;
        }

        public void DoCmdDestroyAll()
        {
            int count = 0;
            // Look for worthless items
            for (int i = InventorySlot.PackCount - 1; i >= 0; i--)
            {
                Item item = Player.Inventory[i];
                if (item.BaseItemCategory == null)
                {
                    continue;
                }
                // Only destroy if it's stompable (i.e. worthless or marked as unwanted)
                if (!item.Stompable())
                {
                    continue;
                }
                string itemName = item.Description(true, 3);
                MsgPrint($"You destroy {itemName}.");
                count++;
                int amount = item.Count;
                Player.InvenItemIncrease(i, -amount);
                Player.InvenItemOptimize(i);
            }
            if (count == 0)
            {
                MsgPrint("You are carrying nothing worth destroying.");
                EnergyUse = 0;
            }
            else
            {
                // If we destroyed at least one thing, take a turn
                EnergyUse = 100;
            }
        }

        public void DoCmdDestroy()
        {
            int amount = 1;
            bool force = CommandArgument > 0;
            // Get an item to destroy
            if (!GetItem(out int itemIndex, "Destroy which item? ", false, true, true, null))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing to destroy.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // If we have more than one we might not want to destroy all of them
            if (item.Count > 1)
            {
                amount = GetQuantity(null, item.Count, true);
                if (amount <= 0)
                {
                    return;
                }
            }
            int oldNumber = item.Count;
            item.Count = amount;
            string itemName = item.Description(true, 3);
            item.Count = oldNumber;
            //Only confirm if it's not a worthless item
            if (!force)
            {
                if (!item.Stompable())
                {
                    string outVal = $"Really destroy {itemName}? ";
                    if (!GetCheck(outVal))
                    {
                        return;
                    }
                    // If it was something we might want to destroy again, ask
                    if (!item.BaseItemCategory.HasQuality && item.BaseItemCategory.CategoryEnum != ItemTypeEnum.Chest)
                    {
                        if (item.IsKnown())
                        {
                            if (GetCheck($"Always destroy {itemName}?"))
                            {
                                item.BaseItemCategory.Stompable[0] = true;
                            }
                        }
                    }
                }
            }
            // Destroying something takes a turn
            EnergyUse = 100;
            // Can't destroy an artifact artifact
            if (item.IsFixedArtifact() || !string.IsNullOrEmpty(item.RandartName))
            {
                string feel = "special";
                EnergyUse = 0;
                MsgPrint($"You cannot destroy {itemName}.");
                if (item.IsCursed() || item.IsBroken())
                {
                    feel = "terrible";
                }
                item.Inscription = feel;
                item.IdentSense = true;
                NoticeCombineFlaggedAction.Set();
                RedrawEquippyFlaggedAction.Set();
                return;
            }
            MsgPrint($"You destroy {itemName}.");
            // Warriors and paladins get experience for destroying magic books
            if (ItemFilterHighLevelBook(item))
            {
                bool gainExpr = false;
                if (Player.BaseCharacterClass.ID == CharacterClass.Warrior)
                {
                    gainExpr = true;
                }
                else if (Player.BaseCharacterClass.ID == CharacterClass.Paladin)
                {
                    if (Player.Realm1 == Realm.Life)
                    {
                        if (item.Category == ItemTypeEnum.DeathBook)
                        {
                            gainExpr = true;
                        }
                    }
                    else
                    {
                        if (item.Category == ItemTypeEnum.LifeBook)
                        {
                            gainExpr = true;
                        }
                    }
                }
                if (gainExpr && Player.ExperiencePoints < Constants.PyMaxExp)
                {
                    int testerExp = Player.MaxExperienceGained / 20;
                    if (testerExp > 10000)
                    {
                        testerExp = 10000;
                    }
                    if (item.ItemSubCategory < 3)
                    {
                        testerExp /= 4;
                    }
                    if (testerExp < 1)
                    {
                        testerExp = 1;
                    }
                    MsgPrint("You feel more experienced.");
                    Player.GainExperience(testerExp * amount);
                }
            }
            // Tidy up the player's inventory
            if (itemIndex >= 0)
            {
                Player.InvenItemIncrease(itemIndex, -amount);
                Player.InvenItemDescribe(itemIndex);
                Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                Level.FloorItemIncrease(0 - itemIndex, -amount);
                Level.FloorItemDescribe(0 - itemIndex);
                Level.FloorItemOptimize(0 - itemIndex);
            }
        }

        public void DoCmdInventory()
        {
            // We're not viewing equipment
            ViewingEquipment = false;
            ScreenBuffer savedScreen = Screen.Clone();
            // We want to see everything
            Player.ShowInven(_inventorySlot => !_inventorySlot.IsEquipment, null);
            // Get a new command
            string outVal = $"Inventory: carrying {Player.WeightCarried / 10}.{Player.WeightCarried % 10} pounds ({Player.WeightCarried * 100 / (Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
            Screen.PrintLine(outVal, 0, 0);
            QueuedCommand = Inkey();
            Screen.Restore(savedScreen);
            // Display details if the player wants
            if (QueuedCommand == '\x1b')
            {
                QueuedCommand = (char)0;
            }
            else
            {
                // If the player selected a command that needs to select an item, it will automatically
                // show the inventory
                ViewingItemList = true;
            }
        }

        public void DoCmdQuerySymbol()
        {
            int index;
            // Get the symbol
            if (!GetCom("Enter character to be identified: ", out char symbol))
            {
                return;
            }
            // Run through the identification array till we find the symbol
            for (index = 0; Constants.SymbolIdentification[index] != null; ++index)
            {
                if (symbol == Constants.SymbolIdentification[index][0])
                {
                    break;
                }
            }
            // Display the symbol and its idenfitication
            string buf = Constants.SymbolIdentification[index] != null
                ? $"{symbol} - {Constants.SymbolIdentification[index].Substring(2)}."
                : $"{symbol} - Unknown Symbol";
            MsgPrint(buf);
        }

        public void DoCmdListCommands()
        {
            FullScreenOverlay = true;
            ScreenBuffer savedScreen = Screen.Clone();
            UpdateScreen();
            Screen.Clear();
            SetBackground(BackgroundImage.Normal);
            Screen.Print(Colour.Yellow, "Numpad", 1, 1);
            Screen.Print("7 8 9", 3, 1);
            Screen.Print(" \\|/", 4, 1);
            Screen.Print("4- -6 = Move", 5, 1);
            Screen.Print(" /|\\    (+Shift = run)", 6, 1);
            Screen.Print("1 2 3", 7, 1);
            Screen.Print("5 = Stand still", 8, 1);
            Screen.Print(Colour.Yellow, "Other Symbols", 10, 1);
            Screen.Print(". = Run", 12, 1);
            Screen.Print("< = Go up stairs", 13, 1);
            Screen.Print("> = Go down stairs", 14, 1);
            Screen.Print("+ = Auto-alter a space", 15, 1);
            Screen.Print("* = Target a creature", 16, 1);
            Screen.Print("/ = Identify a symbol", 17, 1);
            Screen.Print("? = Command list", 18, 1);
            Screen.Print("Esc = Save and quit", 20, 1);
            Screen.Print(Colour.Yellow, "Without Shift", 1, 25);
            Screen.Print("a = Aim a wand", 3, 25);
            Screen.Print("b = Browse a book", 4, 25);
            Screen.Print("c = Close a door", 5, 25);
            Screen.Print("d = Drop object", 6, 25);
            Screen.Print("e = Show equipment", 7, 25);
            Screen.Print("f = Fire a missile weapon", 8, 25);
            Screen.Print("g = Get (pick up) object", 9, 25);
            Screen.Print("h = View game help", 10, 25);
            Screen.Print("i = Show Inventory", 11, 25);
            Screen.Print("j = Jam spike in a door", 12, 25);
            Screen.Print("k = Destroy an item", 13, 25);
            Screen.Print("l = Look around", 14, 25);
            Screen.Print("m = Cast spell/Use talent", 15, 25);
            Screen.Print("n =", 16, 25);
            Screen.Print("o = Open a door/chest", 17, 25);
            Screen.Print("p = Mutant/Racial power", 18, 25);
            Screen.Print("q = Quaff a potion", 19, 25);
            Screen.Print("r = Read a scroll", 20, 25);
            Screen.Print("s = Search for traps", 21, 25);
            Screen.Print("t = Take off an item", 22, 25);
            Screen.Print("u = Use a staff", 23, 25);
            Screen.Print("v = Throw object", 24, 25);
            Screen.Print("w = Wield/wear an item", 25, 25);
            Screen.Print("x = Examine an object", 26, 25);
            Screen.Print("y =", 27, 25);
            Screen.Print("z = Zap a rod", 28, 25);
            Screen.Print(Colour.Yellow, "With Shift", 1, 52);
            Screen.Print("A = Activate an artifact", 3, 52);
            Screen.Print("B = Bash a stuck door", 4, 52);
            Screen.Print("C = View your character", 5, 52);
            Screen.Print("D = Disarm a trap", 6, 52);
            Screen.Print("E = Eat some food", 7, 52);
            Screen.Print("F = Fuel a light source", 8, 52);
            Screen.Print("H = How you feel here", 10, 52);
            Screen.Print("J = View your journal", 12, 52);
            Screen.Print("K = Destroy trash objects", 13, 52);
            Screen.Print("L = Locate player", 14, 52);
            Screen.Print("M = View the map", 15, 52);
            Screen.Print("O = Show last message", 17, 52);
            Screen.Print("P = Show previous messages", 18, 52);
            Screen.Print("Q = Quit (Retire character)", 19, 52);
            Screen.Print("R = Rest", 20, 52);
            Screen.Print("S = Auto-search on/off", 21, 52);
            Screen.Print("T = Tunnel", 22, 52);
            Screen.Print("V = Version info", 24, 52);
            if (Player.IsWizard)
            {
                Screen.Print("W = Wizard command", 25, 52);
            }
            AnyKey(44);
            Screen.Restore(savedScreen);
            SetBackground(BackgroundImage.Overhead);
            FullScreenOverlay = false;
        }

        public void DoCmdZapRod()
        {
            int itemIndex = -999;

            // Get the item if we weren't passed it
            if (itemIndex == -999)
            {
                if (!GetItem(out itemIndex, "Zap which rod? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Rod)))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have no rod to zap.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Make sure the item is actually a rod
            if (!Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Rod)))
            {
                MsgPrint("That is not a rod!");
                return;
            }
            // Rods can't be used from the floor
            if (itemIndex < 0 && item.Count > 1)
            {
                MsgPrint("You must first pick up the rods.");
                return;
            }
            // We may need to aim the rod.  If we know that the rod requires aiming, we get a direction from the player.  Otherwise, if we do not know what
            // the rod is going to do, we will get a direction from the player.  This helps prevent the player from learning what the rod does because the game
            // would ask for a direction.
            RodItemClass rodItemCategory = (RodItemClass)item.BaseItemCategory;
            int? dir = 5;
            if (rodItemCategory.RequiresAiming || !item.IsFlavourAware()) 
            {
                if (!GetDirectionWithAim(out int direction))
                {
                    return;
                }
                dir = direction;
            }

            // Using a rod takes a whole turn
            EnergyUse = 100;
            bool identified = false;
            int itemLevel = item.BaseItemCategory.Level;
            // Chance to successfully use it is skill (halved if confused) - rod level (capped at 50)
            int chance = Player.SkillUseDevice;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // There's always a small chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // Do the actual check
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                MsgPrint("You failed to use the rod properly.");
                return;
            }
            // Rods only have a single charge but recharge over time
            if (item.TypeSpecificValue != 0)
            {
                MsgPrint("The rod is still charging.");
                return;
            }
            PlaySound(SoundEffect.ZapRod);
            // Do the rod-specific effect
            bool useCharge = true;
            RodItemClass rodItem = (RodItemClass)item.BaseItemCategory;
            ZapRodEvent zapRodEvent = new ZapRodEvent(item, dir);
            rodItem.Execute(zapRodEvent);
            NoticeCombineAndReorderFlaggedAction.Set();
            // We may have just discovered what the rod does
            item.ObjectTried();
            if (identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                Player.GainExperience((itemLevel + (Player.Level >> 1)) / Player.Level);
            }
            // We may not have actually used a charge
            if (!useCharge)
            {
                item.TypeSpecificValue = 0;
                return;
            }
            // Channelers can spend mana instead of a charge
            bool channeled = false;
            if (Player.BaseCharacterClass.SpellCastingType == CastingType.Channeling)
            {
                channeled = DoCmdChannel(item);
                if (channeled)
                {
                    item.TypeSpecificValue = 0;
                }
            }
            if (!channeled)
            {
                // If the rod was part of a stack, remove it
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item singleRod = item.Clone(1);
                    item.TypeSpecificValue = 0;
                    item.Count--;
                    Player.WeightCarried -= singleRod.Weight;
                    Player.InvenCarry(singleRod, false);
                    MsgPrint("You unstack your rod.");
                }
            }
        }

        public void DoViewMap()
        {
            int cy = -1;
            int cx = -1;
            FullScreenOverlay = true;
            ScreenBuffer savedScreen = Screen.Clone();
            Screen.Clear();
            // If we're on the surface, display the island map
            if (CurrentDepth == 0)
            {
                SetBackground(BackgroundImage.WildMap);
                DisplayWildMap();
            }
            else
            {
                // We're not on the surface, so draw the level map
                SetBackground(BackgroundImage.Map);
                Level.DisplayMap(out cy, out cx);
            }
            // Give us a prompt, and display the cursor in the player's location
            Screen.Print(Colour.Orange, "[Press any key to continue]", 43, 26);
            if (CurrentDepth == 0)
            {
                Screen.Goto(Player.WildernessY + 2, Player.WildernessX + 2);
            }
            else
            {
                Screen.Goto(cy, cx);
            }
            // Wait for a keypress, and restore the screen (looking at the map takes no time)
            Inkey();
            Screen.Restore(savedScreen);
            FullScreenOverlay = false;
            SetBackground(BackgroundImage.Overhead);
        }

        public bool DoDisarm()
        {
            bool more = false;
            int numTraps = CountKnownTraps(out GridCoordinate? trapCoord);
            int numChests = CountChests(out GridCoordinate? chestCoord, true);
            // Count the possible traps and chests we might want to disarm
            if (numTraps != 0 || numChests != 0)
            {
                bool tooMany = (numTraps != 0 && numChests != 0) || numTraps > 1 || numChests > 1;
                // If only one then we have our target
                if (!tooMany)
                {
                    GridCoordinate coord = numTraps == 1 ? trapCoord : chestCoord;
                    CommandDirection = Level.CoordsToDir(coord.Y, coord.X);
                }
            }
            // Get a direction if we don't already have one
            if (GetDirectionNoAim(out int dir))
            {
                int y = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int x = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[y][x];
                // Check for a chest
                int itemIndex = Level.ChestCheck(y, x);
                if (!tile.FeatureType.IsTrap &&
                    itemIndex == 0)
                {
                    MsgPrint("You see nothing there to disarm.");
                }
                // Can't disarm with a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    MsgPrint("There is a monster in the way!");
                    PlayerAttackMonster(y, x);
                }
                // Disarm the chest or trap
                else if (itemIndex != 0)
                {
                    more = DisarmChest(y, x, itemIndex);
                }
                else
                {
                    more = DisarmTrap(y, x);
                }
            }
            return more;
        }

        public bool DoCmdOpen()
        {
            bool more = false;
            // Check if there's only one thing we can open
            int numDoors = CountClosedDoors(out GridCoordinate? doorCoord);
            int numChests = CountChests(out GridCoordinate? chestCoord, false);
            if (numDoors != 0 || numChests != 0)
            {
                bool tooMany = (numDoors != 0 && numChests != 0) || numDoors > 1 || numChests > 1;
                if (!tooMany)
                {
                    // There's only one thing we can open, so assume we mean that thing
                    GridCoordinate coord = numDoors == 1 ? doorCoord : chestCoord;
                    CommandDirection = Level.CoordsToDir(coord.Y, coord.X);
                }
            }
            // If we don't already have a direction, prompt for one
            if (GetDirectionNoAim(out int dir))
            {
                int y = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int x = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[y][x];
                int itemIndex = Level.ChestCheck(y, x);
                // Make sure there is something to open in the direction we chose
                if (!tile.FeatureType.IsClosedDoor &&
                    itemIndex == 0)
                {
                    MsgPrint("You see nothing there to open.");
                }
                // Can't open something if there's a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    EnergyUse = 100;
                    MsgPrint("There is a monster in the way!");
                    PlayerAttackMonster(y, x);
                }
                // Open the chest or door
                else if (itemIndex != 0)
                {
                    more = OpenChestAtGivenLocation(y, x, itemIndex);
                }
                else
                {
                    more = OpenDoor(y, x);
                }
            }
            return more;
        }

        public void DoCmdQuaff()
        {
            int itemIndex = -999;

            // Get an item if we didn't already have one
            if (itemIndex == -999)
            {
                if (!GetItem(out itemIndex, "Quaff which potion? ", true, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Potion)))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have no potions to quaff.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Make sure the item is a potion
            if (!Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Potion)))
            {
                MsgPrint("That is not a potion!");
                return;
            }
            PlaySound(SoundEffect.Quaff);
            // Drinking a potion costs a whole turn
            EnergyUse = 100;
            int itemLevel = item.BaseItemCategory.Level;
            // Do the actual potion effect
            PotionItemClass potion = (PotionItemClass)item.BaseItemCategory; // The item will be a potion.
            bool identified = potion.Quaff(this);

            // Skeletons are messy drinkers
            Player.Race.Quaff(this, potion);
            NoticeCombineAndReorderFlaggedAction.Set();
            // We may now know the potion's type
            item.ObjectTried();
            if (identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                Player.GainExperience((itemLevel + (Player.Level >> 1)) / Player.Level);
            }
            // Most potions give us a bit of food too
            Player.SetFood(Player.Food + item.TypeSpecificValue);
            bool channeled = false;
            // If we're a channeler, we might be able to spend mana instead of using it up
            if (Player.BaseCharacterClass.SpellCastingType == CastingType.Channeling)
            {
                channeled = DoCmdChannel(item);
            }
            if (!channeled)
            {
                // We didn't channel it, so use up one potion from the stack
                if (itemIndex >= 0)
                {
                    Player.InvenItemIncrease(itemIndex, -1);
                    Player.InvenItemDescribe(itemIndex);
                    Player.InvenItemOptimize(itemIndex);
                }
                else
                {
                    Level.FloorItemIncrease(0 - itemIndex, -1);
                    Level.FloorItemDescribe(0 - itemIndex);
                    Level.FloorItemOptimize(0 - itemIndex);
                }
            }
        }

        public void DoToggleSearch()
        {
            if (Player.IsSearching)
            {
                Player.IsSearching = false;
                UpdateBonusesFlaggedAction.Set();
                RedrawStateFlaggedAction.Set();
            }
            else
            {
                Player.IsSearching = true;
                UpdateBonusesFlaggedAction.Set();
                RedrawStateFlaggedAction.Set();
                RedrawSpeedFlaggedAction.Set();
            }
        }

        public void DoCmdTarget()
        {
            if (TargetSet(Constants.TargetKill))
            {
                MsgPrint(TargetWho > 0 ? "Target Selected." : "Location Targeted.");
            }
            else
            {
                MsgPrint("Target Aborted.");
            }
        }

        public void DoCmdThrow(int damageMultiplier)
        {
            // Get an item to throw
            if (!GetItem(out int itemIndex, "Throw which item? ", false, true, true, null))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing to throw.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            if (!GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Copy a single item from the item stack as the thrown item
            Item missile = item.Clone(1);
            if (itemIndex >= 0)
            {
                Player.InvenItemIncrease(itemIndex, -1);
                Player.InvenItemDescribe(itemIndex);
                Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                Level.FloorItemIncrease(0 - itemIndex, -1);
                Level.FloorItemOptimize(0 - itemIndex);
            }
            string missileName = missile.Description(false, 3);
            Colour missileColour = missile.BaseItemCategory.FlavorColour;
            char missileCharacter = missile.BaseItemCategory.FlavorCharacter;
            // Thrown distance is based on the weight of the missile
            int multiplier = 10 + (2 * (damageMultiplier - 1));
            int divider = missile.Weight > 10 ? missile.Weight : 10;
            int throwDistance = (Player.AbilityScores[Ability.Strength].StrAttackSpeedComponent + 20) * multiplier / divider;
            if (throwDistance > 10)
            {
                throwDistance = 10;
            }
            // Work out the damage done
            int damage = Program.Rng.DiceRoll(missile.DamageDice, missile.DamageDiceSides) + missile.BonusDamage;
            damage *= damageMultiplier;
            int chance = Player.SkillThrowing + (Player.AttackBonus * Constants.BthPlusAdj);
            // Throwing something always uses a full turn, even if you can make multiple missile attacks
            EnergyUse = 100;
            int y = Player.MapY;
            int x = Player.MapX;
            int targetX = Player.MapX + (99 * Level.KeypadDirectionXOffset[dir]);
            int targetY = Player.MapY + (99 * Level.KeypadDirectionYOffset[dir]);
            if (dir == 5 && TargetOkay())
            {
                targetX = TargetCol;
                targetY = TargetRow;
            }
            HandleStuff();
            int newY = Player.MapY;
            int newX = Player.MapX;
            bool hitBody = false;
            // Send the thrown object in the right direction one square at a time
            for (int curDis = 0; curDis <= throwDistance;)
            {
                // If we reach our limit, stop the object moving
                if (y == targetY && x == targetX)
                {
                    break;
                }
                Level.MoveOneStepTowards(out newY, out newX, y, x, Player.MapY, Player.MapX, targetY, targetX);
                // If we hit a wall or something stop moving
                if (!Level.GridPassable(newY, newX))
                {
                    break;
                }
                curDis++;
                x = newX;
                y = newY;
                const int msec = Constants.DelayFactorInMilliseconds;
                // If we can see, display the thrown item with a suitable delay
                if (Level.PanelContains(y, x) && Level.PlayerCanSeeBold(y, x))
                {
                    Level.PrintCharacterAtMapLocation(missileCharacter, missileColour, y, x);
                    Level.MoveCursorRelative(y, x);
                    UpdateScreen();
                    Pause(msec);
                    Level.RedrawSingleLocation(y, x);
                    UpdateScreen();
                }
                else
                {
                    // Delay even if we don't see it, so it doesn't look weird when it passes behind something
                    Pause(msec);
                }
                // If there's a monster in the way, we might hit it regardless of whether or not it
                // is our intended target
                if (Level.Grid[y][x].MonsterIndex != 0)
                {
                    GridTile tile = Level.Grid[y][x];
                    Monster monster = Level.Monsters[tile.MonsterIndex];
                    MonsterRace race = monster.Race;
                    bool visible = monster.IsVisible;
                    hitBody = true;
                    // See if it actually hit the monster
                    if (PlayerCheckRangedHitOnMonster(chance - curDis, race.ArmourClass, monster.IsVisible))
                    {
                        string noteDies = " dies.";
                        if (race.Demon || race.Undead ||
                            race.Cthuloid || race.Stupid ||
                            "Evg".Contains(race.Character.ToString()))
                        {
                            noteDies = " is destroyed.";
                        }
                        // Let the player know what happened
                        if (!visible)
                        {
                            MsgPrint($"The {missileName} finds a mark.");
                        }
                        else
                        {
                            string mName = monster.Name;
                            MsgPrint($"The {missileName} hits {mName}.");
                            if (monster.IsVisible)
                            {
                                HealthTrack(tile.MonsterIndex);
                            }
                        }
                        // Adjust the damage for the particular monster type
                        damage = missile.AdjustDamageForMonsterType(damage, monster);
                        damage = PlayerCriticalRanged(missile.Weight, missile.BonusToHit, damage);
                        if (damage < 0)
                        {
                            damage = 0;
                        }
                        if (Level.Monsters.DamageMonster(tile.MonsterIndex, damage, out bool fear, noteDies))
                        {
                            // The monster is dead, so don't add further statuses or messages
                        }
                        else
                        {
                            // Let the player know what happens to the monster
                            Level.Monsters.MessagePain(tile.MonsterIndex, damage);
                            if (monster.SmFriendly && missile.BaseItemCategory.CategoryEnum != ItemTypeEnum.Potion)
                            {
                                string mName = monster.Name;
                                MsgPrint($"{mName} gets angry!");
                                monster.SmFriendly = false;
                            }
                            if (fear && monster.IsVisible)
                            {
                                PlaySound(SoundEffect.MonsterFlees);
                                string mName = monster.Name;
                                MsgPrint($"{mName} flees in terror!");
                            }
                        }
                    }
                    break;
                }
            }
            // There's a chance of breakage if we hit a creature
            int chanceToBreak = hitBody ? missile.BreakageChance() : 0;
            // If we hit with a potion, the potion might affect the creature
            if (missile.BaseItemCategory.CategoryEnum == ItemTypeEnum.Potion)
            {
                if (hitBody || !Level.GridPassable(newY, newX) || Program.Rng.DieRoll(100) < chanceToBreak)
                {
                    PotionItemClass potion = (PotionItemClass)missile.BaseItemCategory;
                    MsgPrint($"The {missileName} shatters!");
                    if (potion.Smash(this, 1, y, x))
                    {
                        if (Level.Grid[y][x].MonsterIndex != 0 && Level.Monsters[Level.Grid[y][x].MonsterIndex].SmFriendly)
                        {
                            string mName = Level.Monsters[Level.Grid[y][x].MonsterIndex].Name;
                            MsgPrint($"{mName} gets angry!");
                            Level.Monsters[Level.Grid[y][x].MonsterIndex].SmFriendly = false;
                        }
                    }
                    return;
                }
                chanceToBreak = 0;
            }
            // Drop the item on the floor
            Level.DropNear(missile, chanceToBreak, y, x);
        }

        public bool DoCmdWalk(bool dontPickup)
        {
            bool more = false;
            // If we don't already have a direction, get one
            if (GetDirectionNoAim(out int dir))
            {
                // Walking takes a full turn
                EnergyUse = 100;
                MovePlayer(dir, dontPickup);
                more = true;
            }
            return more;
        }

        public void DoCmdVersion()
        {
            AssemblyName assembly = Assembly.GetExecutingAssembly().GetName();
            Version version = assembly.Version;
            DateTime CompileTime = new DateTime(2000, 1, 1).AddDays(Assembly.GetExecutingAssembly().GetName().Version.Build).AddSeconds(Assembly.GetExecutingAssembly().GetName().Version.Revision * 2);
            MsgPrint($"You are playing {Constants.VersionName} {version}.");
            MsgPrint($"(Build time: {CompileTime})");
        }

        public void DoCmdStore() // TODO: Move content
        {
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            // Make sure we're actually on a shop tile
            if (!tile.FeatureType.IsShop)
            {
                MsgPrint("You see no Stores here.");
                return;
            }
            Store which = GetWhichStore();
            // We can't enter a house unless we own it
            if (which.DoorsLocked(this))
            {
                MsgPrint("The door is locked.");
                return;
            }
            // Switch from the normal game interface to the store interface
            RemoveLightFlaggedAction.Check(true);
            RemoveViewFlaggedAction.Check(true);
            FullScreenOverlay = true;
            CommandArgument = 0;
            //            CommandRepeat = 0; TODO: Confirm this is not needed
            QueuedCommand = '\0';
            which.EnterStore();
        }

        /// <param name="pickup"> Whether or not we should pick up an object in our location </param>
        public void DoCmdStay(bool pickup) // TODO: Move to SaveGame or Commands
        {
            // Standing still takes a turn
            EnergyUse = 100;
            // Periodically search if we're not actively in search mode
            if (Player.SkillSearchFrequency >= 50 || 0 == Program.Rng.RandomLessThan(50 - Player.SkillSearchFrequency))
            {
                Search();
            }
            // Always search if we are actively in search mode
            if (Player.IsSearching)
            {
                Search();
            }
            // Pick up items if we should
            PickUpItems(pickup);
            // If we're in a shop doorway, enter the shop
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            if (tile.FeatureType.IsShop)
            {
                Disturb(false);
                QueuedCommand = '_';
            }
        }

        public void DoCmdPopup()
        {
            List<string> menuItems = new List<string>() { "Resume Game", "Save and Quit" };
            PopupMenu menu = new PopupMenu(menuItems);
            int result = menu.Show(this);
            switch (result)
            {
                // Escape or Resume Game
                case -1:
                case 0:
                    break;
                // Save and Quit
                case 1:
                    Playing = false; // TODO: Need to use event arguments
                    break;
            }
        }

        public void DoCmdSearch()
        {
            EnergyUse = 100;
            Search();
        }

        public void DoCmdMutantPower()
        {
            int i = 0;
            int num;
            int[] powers = new int[36];
            string[] powerDesc = new string[36];
            int pets = 0;
            int petCtr;
            bool allPets = false;
            Monster monster;
            bool hasRacial = Player.Race.HasRacialPowers;
            string racialPowersDescription = Player.Race.RacialPowersDescription(Player.Level);
            for (num = 0; num < 36; num++)
            {
                powers[num] = 0;
                powerDesc[num] = "";
            }
            num = 0;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                MsgPrint("You are too confused to use any powers!");
                EnergyUse = 0;
                return;
            }
            for (petCtr = Level.MMax - 1; petCtr >= 1; petCtr--)
            {
                monster = Level.Monsters[petCtr];
                if (monster.SmFriendly)
                {
                    pets++;
                }
            }
            List<Mutations.Mutation> activeMutations = Player.Dna.ActivatableMutations(Player);
            if (!hasRacial && activeMutations.Count == 0 && pets == 0)
            {
                MsgPrint("You have no powers to activate.");
                EnergyUse = 0;
                return;
            }
            if (hasRacial)
            {
                powers[0] = int.MaxValue;
                powerDesc[0] = racialPowersDescription;
                num++;
            }
            for (int j = 0; j < activeMutations.Count; j++)
            {
                powers[num] = j + 100;
                powerDesc[num] = activeMutations[j].ActivationSummary(Player.Level);
                num++;
            }
            if (pets > 0)
            {
                powerDesc[num] = "dismiss pets";
                powers[num++] = 3;
            }
            bool flag = false;
            ScreenBuffer? savedScreen = null;
            string outVal = $"(Powers {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which power? ";
            while (!flag && GetCom(outVal, out char choice))
            {
                if (choice == ' ' || choice == '*' || choice == '?')
                {
                    if (savedScreen == null)
                    {
                        int y = 1, x = 13;
                        int ctr = 0;
                        savedScreen = Screen.Clone();
                        Screen.PrintLine("", y++, x);
                        while (ctr < num)
                        {
                            string dummy = $"{ctr.IndexToLetter()}) {powerDesc[ctr]}";
                            Screen.PrintLine(dummy, y + ctr, x);
                            ctr++;
                        }
                        Screen.PrintLine("", y + ctr, x);
                    }
                    else
                    {
                        Screen.Restore(savedScreen);
                        savedScreen = null;
                    }
                    continue;
                }
                if (choice == '\r' && num == 1)
                {
                    choice = 'a';
                }
                bool ask = char.IsUpper(choice);
                if (ask)
                {
                    choice = char.ToLower(choice);
                }
                i = char.IsLower(choice) ? choice.LetterToNumber() : -1;
                if (i < 0 || i >= num)
                {
                    continue;
                }
                if (ask)
                {
                    string tmpVal = $"Use {powerDesc[i]}? ";
                    if (!GetCheck(tmpVal))
                    {
                        continue;
                    }
                }
                flag = true;
            }
            if (savedScreen != null)
            {
                Screen.Restore(savedScreen);
            }
            if (!flag)
            {
                EnergyUse = 0;
                return;
            }
            if (powers[i] == int.MaxValue)
            {
                UseRacialPower();
            }
            else if (powers[i] == 3)
            {
                int dismissed = 0;
                if (GetCheck("Dismiss all pets? "))
                {
                    allPets = true;
                }
                for (petCtr = Level.MMax - 1; petCtr >= 1; petCtr--)
                {
                    monster = Level.Monsters[petCtr];
                    if (monster.SmFriendly)
                    {
                        bool deleteThis = false;
                        if (allPets)
                        {
                            deleteThis = true;
                        }
                        else
                        {
                            string friendName = monster.VisibleName;
                            string checkFriend = $"Dismiss {friendName}? ";
                            if (GetCheck(checkFriend))
                            {
                                deleteThis = true;
                            }
                        }
                        if (deleteThis)
                        {
                            Level.Monsters.DeleteMonsterByIndex(petCtr, true);
                            dismissed++;
                        }
                    }
                }
                string s = dismissed == 1 ? "" : "s";
                MsgPrint($"You have dismissed {dismissed} pet{s}.");
            }
            else
            {
                EnergyUse = 100;
                activeMutations[powers[i] - 100].Activate(this, Player, Level);
            }
        }

        public void DoCmdLook()
        {
            if (TargetSet(Constants.TargetLook))
            {
                MsgPrint(TargetWho > 0 ? "Target Selected." : "Location Targeted.");
            }
        }

        public void DoCmdLocate()
        {
            int startRow = Level.PanelRow;
            int startCol = Level.PanelCol;
            int currentRow = startRow;
            int currentCol = startCol;
            // Enter a loop so the player can browse the level
            while (true)
            {
                // Describe the location being viewed
                string offsetText;
                if (currentRow == startRow && currentCol == startCol)
                {
                    offsetText = "";
                }
                else
                {
                    string northSouth = currentRow < startRow ? " North" : currentRow > startRow ? " South" : "";
                    string eastWest = currentCol < startCol ? " West" : currentCol > startCol ? " East" : "";
                    offsetText = $"{northSouth}{eastWest} of";
                }
                string message = $"Map sector [{currentRow},{currentCol}], which is{offsetText} your sector. Direction?";
                // Get a direction command or escape
                int dir = 0;
                while (dir == 0)
                {
                    if (!GetCom(message, out char command))
                    {
                        break;
                    }
                    dir = GetKeymapDir(command);
                }
                if (dir == 0)
                {
                    break;
                }
                // Move the view based on the direction
                currentRow += Level.KeypadDirectionYOffset[dir];
                currentCol += Level.KeypadDirectionXOffset[dir];
                if (currentRow > Level.MaxPanelRows)
                {
                    currentRow = Level.MaxPanelRows;
                }
                else if (currentRow < 0)
                {
                    currentRow = 0;
                }
                if (currentCol > Level.MaxPanelCols)
                {
                    currentCol = Level.MaxPanelCols;
                }
                else if (currentCol < 0)
                {
                    currentCol = 0;
                }
                // Update the view if necessary
                if (currentRow != Level.PanelRow || currentCol != Level.PanelCol)
                {
                    Level.PanelRow = currentRow;
                    Level.PanelCol = currentCol;
                    Level.PanelBounds();
                    UpdateMonstersFlaggedAction.Set();
                    RedrawMapFlaggedAction.Set();
                    HandleStuff();
                }
            }
            // We've finished, so snap back to the player's location
            Player.RecenterScreenAroundPlayer();
            UpdateMonstersFlaggedAction.Set();
            RedrawMapFlaggedAction.Set();
            HandleStuff();
        }

        public void DoGoDown()
        {
            bool isTrapDoor = false;
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            if (tile.FeatureType.Category == FloorTileTypeCategory.TrapDoor)
            {
                isTrapDoor = true;
            }
            // Need to be on a staircase or trapdoor
            if (tile.FeatureType.Name != "DownStair" && !isTrapDoor)
            {
                MsgPrint("I see no down staircase here.");
                EnergyUse = 0;
                return;
            }
            // Going onto a new level takes no energy, so the monsters on that level don't get to
            // move before us
            EnergyUse = 0;
            if (isTrapDoor)
            {
                MsgPrint("You deliberately jump through the trap door.");
            }
            else
            {
                // If we're on the surface, enter the relevant dungeon
                if (CurrentDepth == 0)
                {
                    CurDungeon = Wilderness[Player.WildernessY][Player.WildernessX].Dungeon;
                    MsgPrint($"You enter {CurDungeon.Name}");
                }
                else
                {
                    MsgPrint("You enter a maze of down staircases.");
                }
                // Save the game, just in case
                DoCmdSaveGame(true);
            }
            // If we're in a tower, a down staircase reduces our level number
            if (CurDungeon.Tower)
            {
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > CurrentDepth)
                {
                    stairLength = 1;
                }
                CurrentDepth -= stairLength;
                if (CurrentDepth < 0)
                {
                    CurrentDepth = 0;
                }
                // If we left the dungeon, remember where we are
                if (CurrentDepth == 0)
                {
                    Player.WildernessX = CurDungeon.X;
                    Player.WildernessY = CurDungeon.Y;
                    CameFrom = LevelStart.StartStairs;
                }
            }
            else
            {
                // We're not in a tower, so a down staircase increases our level number
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > CurrentDepth)
                {
                    stairLength = 1;
                }
                // Check if we're about to go past a quest level
                for (int i = 0; i < stairLength; i++)
                {
                    CurrentDepth++;
                    if (Quests.IsQuest(CurrentDepth))
                    {
                        // Stop on the quest level
                        break;
                    }
                }
                // Don't go past the max dungeon level
                if (CurrentDepth > CurDungeon.MaxLevel)
                {
                    CurrentDepth = CurDungeon.MaxLevel;
                }
                // From the surface we always go to the first level
                if (CurrentDepth == 0)
                {
                    CurrentDepth++;
                }
            }
            // We need a new level
            NewLevelFlag = true;
            if (!isTrapDoor)
            {
                // Create an up staircase if we went down a staircase
                CreateUpStair = true;
            }
        }

        public void DoGoUp()
        {
            // We need to actually be on an up staircase
            GridTile tile = Level.Grid[Player.MapY][Player.MapX];
            if (tile.FeatureType.Name != "UpStair")
            {
                MsgPrint("I see no up staircase here.");
                EnergyUse = 0;
                return;
            }
            // Use no energy, so monsters in the new level don't get to go first
            EnergyUse = 0;
            // If we're outside then we must be entering a tower
            if (CurrentDepth == 0)
            {
                CurDungeon = Wilderness[Player.WildernessY][Player.WildernessX].Dungeon;
                MsgPrint($"You enter {CurDungeon.Name}");
            }
            else
            {
                MsgPrint("You enter a maze of up staircases.");
            }
            // Autosave, just in case
            DoCmdSaveGame(true);
            // In a tower, going up increases our level number
            if (CurDungeon.Tower)
            {
                int stairLength = Program.Rng.DieRoll(5);
                if (stairLength > CurrentDepth)
                {
                    stairLength = 1;
                }
                // Make sure we don't go past a quest level
                for (int i = 0; i < stairLength; i++)
                {
                    CurrentDepth++;
                    if (Quests.IsQuest(CurrentDepth))
                    {
                        break;
                    }
                }
                // Make sure we don't go deeper than the dungeon depth
                if (CurrentDepth > CurDungeon.MaxLevel)
                {
                    CurrentDepth = CurDungeon.MaxLevel;
                }
            }
            else
            {
                // We're not in a tower, so going up decreases our level number
                int j = Program.Rng.DieRoll(5);
                if (j > CurrentDepth)
                {
                    j = 1;
                }
                CurrentDepth -= j;
                if (CurrentDepth < 0)
                {
                    CurrentDepth = 0;
                }
                if (CurrentDepth == 0)
                {
                    Player.WildernessX = CurDungeon.X;
                    Player.WildernessY = CurDungeon.Y;
                    CameFrom = LevelStart.StartStairs;
                }
            }
            NewLevelFlag = true;
            CreateDownStair = true;
        }

        public void DoDropCmd()
        {
            int amount = 1;
            // Get an item from the inventory/equipment
            if (!GetItem(out int itemIndex, "Drop which item? ", true, true, false, null))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing to drop.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Can't drop a cursed item
            if (itemIndex >= InventorySlot.MeleeWeapon && item.IsCursed())
            {
                MsgPrint("Hmmm, it seems to be cursed.");
                return;
            }
            // It's a stack, so find out how many to drop
            if (item.Count > 1)
            {
                amount = GetQuantity(null, item.Count, true);
                if (amount <= 0)
                {
                    return;
                }
            }
            // Dropping things takes half a turn
            EnergyUse = 50;
            // Drop it
            Player.InvenDrop(itemIndex, amount);
            RedrawEquippyFlaggedAction.Set();
        }

        public void DoCmdRun()
        {
            // Can't run if we're confused
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                MsgPrint("You are too confused!");
                return;
            }
            // Get a direction if we don't already have one
            if (GetDirectionNoAim(out int dir))
            {
                // If we don't have a distance, assume we'll run for 1,000 steps
                Running = CommandArgument != 0 ? CommandArgument : 1000;
                // Run one step in the chosen direction
                RunOneStep(dir);
            }
        }

        public void DoUseStaff()
        {
            int itemIndex = -999;

            // Get an item if we weren't passed one
            if (itemIndex == -999)
            {
                if (!GetItem(out itemIndex, "Use which staff? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Staff)))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have no staff to use.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Make sure the item is actually a staff
            if (!Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Staff)))
            {
                MsgPrint("That is not a staff!");
                return;
            }

            StaffItemClass staffItem = (StaffItemClass)item.BaseItemCategory;

            // We can't use a staff from the floor
            if (itemIndex < 0 && item.Count > 1)
            {
                MsgPrint("You must first pick up the staff.");
                return;
            }
            // Using a staff costs a full turn
            EnergyUse = 100;
            int itemLevel = item.BaseItemCategory.Level;
            // We have a chance of the device working equal to skill (halved if confused) - item
            // level (capped at 50)
            int chance = Player.SkillUseDevice;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always a small chance of it working
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            // Check to see if we use it properly
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                MsgPrint("You failed to use the staff properly.");
                return;
            }
            // Make sure it has charges left
            if (item.TypeSpecificValue <= 0)
            {
                MsgPrint("The staff has no charges left.");
                item.IdentEmpty = true;
                return;
            }
            PlaySound(SoundEffect.UseStaff);
            UseStaffEvent useStaffEventArgs = new UseStaffEvent(this);

            // Do the specific effect for the type of staff
            staffItem.UseStaff(useStaffEventArgs);

            NoticeCombineAndReorderFlaggedAction.Set();
            // We might now know what the staff does
            item.ObjectTried();
            if (useStaffEventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                Player.GainExperience((itemLevel + (Player.Level >> 1)) / Player.Level);
            }
            // We may not have used up a charge
            if (!useStaffEventArgs.ChargeUsed)
            {
                return;
            }
            // Channelers can use mana instead of a charge
            bool channeled = false;
            if (Player.BaseCharacterClass.SpellCastingType == CastingType.Channeling)
            {
                channeled = DoCmdChannel(item);
            }
            if (!channeled)
            {
                // Use the actual charge
                item.TypeSpecificValue--;
                // If the staff was part of a stack, separate it from the rest
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item singleStaff = item.Clone(1);
                    item.TypeSpecificValue++;
                    item.Count--;
                    Player.WeightCarried -= singleStaff.Weight;
                    itemIndex = Player.InvenCarry(singleStaff, false);
                    MsgPrint("You unstack your staff.");
                }
                // Let the player know what happened
                if (itemIndex >= 0)
                {
                    Player.ReportChargeUsageFromInventory(itemIndex);
                }
                else
                {
                    Level.ReportChargeUsageFromFloor(0 - itemIndex);
                }
            }
        }

        public void DoCmdRetire()
        {
            // If we're a winner it's a simple question with a more positive connotation
            if (Player.IsWinner)
            {
                if (!GetCheck("Do you want to retire? "))
                {
                    return;
                }
            }
            else
            {
                // If we're not a winner, only ask if we're not also a wizard - giving up a wizard
                // character doesn't need a prompt/confirmation
                if (!Player.IsWizard)
                {
                    if (!GetCheck("Do you really want to give up? "))
                    {
                        return;
                    }
                    // Require a confirmation to make sure the player doesn't accidentally give up a
                    // long-running character
                    Screen.PrintLine("Type the '@' sign to give up (this character will no longer be playable): ", 0, 0);
                    int i = Inkey();
                    Screen.PrintLine("", 0, 0);
                    if (i != '@')
                    {
                        return;
                    }
                }
            }
            // Assuming whe player didn't give up, "kill" the character by quitting
            Playing = false;
            Player.IsDead = true;
            DiedFrom = "quitting";
        }

        public void DoCmdRest()
        {
            if (CommandArgument <= 0)
            {
                const string prompt = "Rest (0-9999, '*' for HP/SP, '&' as needed): ";
                if (!GetString(prompt, out string choice, "&", 4))
                {
                    return;
                }
                // Default to resting until we're fine
                if (string.IsNullOrEmpty(choice))
                {
                    choice = "&";
                }
                // -2 means rest until we're fine
                if (choice[0] == '&')
                {
                    CommandArgument = -2;
                }
                // -1 means rest until we're at full health, but don't worry about waiting for other
                // status effects to go away
                else if (choice[0] == '*')
                {
                    CommandArgument = -1;
                }
                else
                {
                    // A number means rest for that many turns
                    if (int.TryParse(choice, out int i))
                    {
                        CommandArgument = i;
                    }
                    // The player might not have put a number in - so abandon if they didn't
                    if (CommandArgument <= 0)
                    {
                        return;
                    }
                }
            }
            // Can't rest for more than 9999 turns
            if (CommandArgument > 9999)
            {
                CommandArgument = 9999;
            }
            // Resting takes at least one turn (we'll also be skipping future turns)
            EnergyUse = 100;
            Resting = CommandArgument;
            Player.IsSearching = false;
            UpdateBonusesFlaggedAction.Set();
            RedrawStateFlaggedAction.Set();
            HandleStuff();
            UpdateScreen();
        }

        public void DoCmdReadScroll()
        {
            int itemIndex = -999;

            int i;
            // Make sure we're in a situation where we can read
            if (Player.TimedBlindness.TurnsRemaining != 0)
            {
                MsgPrint("You can't see anything.");
                return;
            }
            if (Level.NoLight())
            {
                MsgPrint("You have no light to read by.");
                return;
            }
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                MsgPrint("You are too confused!");
                return;
            }
            // If we weren't passed in an item, prompt for one
            if (itemIndex == -999)
            {
                if (!GetItem(out itemIndex, "Read which scroll? ", true, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Scroll)))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have no scrolls to read.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Make sure the item is actually a scroll
            if (!Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Scroll)))
            {
                MsgPrint("That is not a scroll!");
                return;
            }
            // Scrolls use a full turn
            EnergyUse = 100;
            //bool identified = false;
            //bool usedUp = true;

            ScrollItemClass scrollItem = (ScrollItemClass)item.BaseItemCategory;
            ReadScrollEvent readScrollEventArgs = new ReadScrollEvent(this);
            scrollItem.Read(readScrollEventArgs);

            NoticeCombineAndReorderFlaggedAction.Set();
            // We might have just identified the scroll
            item.ObjectTried();
            if (readScrollEventArgs.Identified && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                int itemLevel = item.BaseItemCategory.Level;
                Player.GainExperience((itemLevel + (Player.Level >> 1)) / Player.Level);
            }
            bool channeled = false;
            // Channelers can use mana instead of the scroll being used up
            if (Player.BaseCharacterClass.SpellCastingType == CastingType.Channeling)
            {
                channeled = DoCmdChannel(item);
            }
            if (!channeled)
            {
                if (!readScrollEventArgs.UsedUp)
                {
                    return;
                }
                // If it wasn't used up then decrease the amount in the stack
                if (itemIndex >= 0)
                {
                    Player.InvenItemIncrease(itemIndex, -1);
                    Player.InvenItemDescribe(itemIndex);
                    Player.InvenItemOptimize(itemIndex);
                }
                else
                {
                    Level.FloorItemIncrease(0 - itemIndex, -1);
                    Level.FloorItemDescribe(0 - itemIndex);
                    Level.FloorItemOptimize(0 - itemIndex);
                }
            }
        }

        public void DoCmdRefill()
        {
            // Make sure we actually have a light source to refuel.           
            BaseInventorySlot? chosenLightSourceInventorySlot = SingletonRepository.InventorySlots.WeightedRandom(inventorySlot => inventorySlot.ProvidesLight).Choose();

            // Check to ensure there is an inventory slot for light sources.
            if (chosenLightSourceInventorySlot == null)
            {
                MsgPrint("You are not wielding a light.");
                return;
            }

            // Now choose a light source item.
            int? i = chosenLightSourceInventorySlot.WeightedRandom.Choose();
            if (i == null)
            {
                MsgPrint("You are not wielding a light.");
                return;
            }

            Item lightSource = Player.Inventory[i.Value];
            if (lightSource.BaseItemCategory == null)
            {
                MsgPrint("You are not wielding a light.");
                return;
            }

            LightSourceItemClass lightSourceItem = (LightSourceItemClass)lightSource.BaseItemCategory;
            lightSourceItem.Refill(this, lightSource);
        }

        /// <summary>
        /// Open a chest at a given location
        /// </summary>
        /// <param name="y"> The y coordinate of the location </param>
        /// <param name="x"> The x coordinate of the location </param>
        /// <param name="itemIndex"> The index of the chest item </param>
        /// <returns> Whether or not the player should be disturbed by the action </returns>
        private bool OpenChestAtGivenLocation(int y, int x, int itemIndex)
        {
            bool openedSuccessfully = true;
            bool more = false;
            Item item = Level.Items[itemIndex];
            // Opening a chest takes an action
            EnergyUse = 100;
            // If the chest is locked, we may need to pick it
            if (item.TypeSpecificValue > 0)
            {
                openedSuccessfully = false;
                // Our disable traps skill also doubles up as a lockpicking skill
                int i = Player.SkillDisarmTraps;
                // Hard to pick locks in the dark
                if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
                {
                    i /= 10;
                }
                // Hard to pick locks when you're confused or hallucinating
                if (Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0)
                {
                    i /= 10;
                }
                // Some locks are harder to pick than others
                int j = i - item.TypeSpecificValue;
                if (j < 2)
                {
                    j = 2;
                }
                // See if we succeeded
                if (Program.Rng.RandomLessThan(100) < j)
                {
                    MsgPrint("You have picked the lock.");
                    Player.GainExperience(1);
                    openedSuccessfully = true;
                }
                else
                {
                    more = true;
                    MsgPrint("You failed to pick the lock.");
                }
            }
            // If we successfully opened it, set of any traps and then actually open the chest
            if (openedSuccessfully)
            {
                ChestTrap(y, x, itemIndex);
                OpenChest(y, x, itemIndex);
            }
            return more;
        }

        public void DoCmdFire()
        {
            // Check that we're actually wielding a ranged weapon
            Item missileWeapon = Player.Inventory[InventorySlot.RangedWeapon];
            if (missileWeapon.Category == 0)
            {
                MsgPrint("You have nothing to fire with.");
                return;
            }
            // Get the ammunition to fire
            if (!GetItem(out int itemIndex, "Fire which item? ", false, true, true, new ItemCategoryItemFilter(Player.AmmunitionItemCategory)))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing to fire.");
                }
                return;
            }
            Item ammunitionStack = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Find out where we're aiming at
            if (!GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Copy an ammunition piece from the stack...
            Item individualAmmunition = ammunitionStack.Clone(1);
            // ...and reduced the amount in the stack
            if (itemIndex >= 0)
            {
                Player.InvenItemIncrease(itemIndex, -1);
                Player.InvenItemDescribe(itemIndex);
                Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                Level.FloorItemIncrease(0 - itemIndex, -1);
                Level.FloorItemOptimize(0 - itemIndex);
            }
            PlaySound(SoundEffect.Shoot);
            // Get the details of the shot
            string missileName = individualAmmunition.Description(false, 3);
            Colour missileColour = individualAmmunition.BaseItemCategory.FlavorColour;
            char missileCharacter = individualAmmunition.BaseItemCategory.FlavorCharacter;
            int shotSpeed = Player.MissileAttacksPerRound;
            int shotDamage = Program.Rng.DiceRoll(individualAmmunition.DamageDice, individualAmmunition.DamageDiceSides) + individualAmmunition.BonusDamage + missileWeapon.BonusDamage;
            int attackBonus = Player.AttackBonus + individualAmmunition.BonusToHit + missileWeapon.BonusToHit;
            int chanceToHit = Player.SkillRanged + (attackBonus * Constants.BthPlusAdj);
            // Damage multiplier depends on weapon
            BowWeaponItemClass missileWeaponItemCategory = (BowWeaponItemClass)missileWeapon.BaseItemCategory;
            int damageMultiplier = missileWeaponItemCategory.MissileDamageMultiplier;
            // Extra might gives us an increased multiplier
            if (Player.HasExtraMight)
            {
                damageMultiplier++;
            }
            shotDamage *= damageMultiplier;
            // We're actually going to track the shot and draw it square by square
            int shotDistance = 10 + (5 * damageMultiplier);
            // Divide by our shot speed to give the equivalent of x shots per turn
            EnergyUse = 100 / shotSpeed;
            int y = Player.MapY;
            int x = Player.MapX;
            int targetX = Player.MapX + (99 * Level.KeypadDirectionXOffset[dir]);
            int targetY = Player.MapY + (99 * Level.KeypadDirectionYOffset[dir]);
            // Special case for if we're hitting our own square
            if (dir == 5 && TargetOkay())
            {
                targetX = TargetCol;
                targetY = TargetRow;
            }
            HandleStuff();
            bool hitBody = false;
            // Loop until we've reached our distance or hit something
            for (int curDis = 0; curDis <= shotDistance;)
            {
                if (y == targetY && x == targetX)
                {
                    break;
                }
                // Move a step towards the target
                Level.MoveOneStepTowards(out int newY, out int newX, y, x, Player.MapY, Player.MapX, targetY, targetX);
                // If we were blocked by a wall or something then stop short
                if (!Level.GridPassable(newY, newX))
                {
                    break;
                }
                curDis++;
                x = newX;
                y = newY;
                int msec = Constants.DelayFactorInMilliseconds;
                // If we can see the current projectile location, show it briefly
                if (Level.PanelContains(y, x) && Level.PlayerCanSeeBold(y, x))
                {
                    Level.PrintCharacterAtMapLocation(missileCharacter, missileColour, y, x);
                    Level.MoveCursorRelative(y, x);
                    UpdateScreen();
                    Pause(msec);
                    Level.RedrawSingleLocation(y, x);
                    UpdateScreen();
                }
                else
                {
                    // Pause even if we can't see it so it doesn't look weird if it goes in and out
                    // of sight
                    Pause(msec);
                }
                // Check if we might hit a monster (not necessarily the one we were aiming at)
                if (Level.Grid[y][x].MonsterIndex != 0)
                {
                    GridTile tile = Level.Grid[y][x];
                    Monster monster = Level.Monsters[tile.MonsterIndex];
                    MonsterRace race = monster.Race;
                    bool visible = monster.IsVisible;
                    hitBody = true;
                    // Check if we actually hit it
                    if (PlayerCheckRangedHitOnMonster(chanceToHit - curDis, race.ArmourClass, monster.IsVisible))
                    {
                        string noteDies = " dies.";
                        if (race.Demon || race.Undead ||
                            race.Cthuloid || race.Stupid ||
                            "Evg".Contains(race.Character.ToString()))
                        {
                            noteDies = " is destroyed.";
                        }
                        if (!visible)
                        {
                            MsgPrint($"The {missileName} finds a mark.");
                        }
                        else
                        {
                            string monsterName = monster.Name;
                            MsgPrint($"The {missileName} hits {monsterName}.");
                            if (monster.IsVisible)
                            {
                                HealthTrack(tile.MonsterIndex);
                            }
                            // Note that pets only get angry if they see us and we see them
                            if (monster.SmFriendly)
                            {
                                monsterName = monster.Name;
                                MsgPrint($"{monsterName} gets angry!");
                                monster.SmFriendly = false;
                            }
                        }
                        // Work out the damage done
                        shotDamage = individualAmmunition.AdjustDamageForMonsterType(shotDamage, monster);
                        shotDamage = PlayerCriticalRanged(individualAmmunition.Weight, individualAmmunition.BonusToHit, shotDamage);
                        if (shotDamage < 0)
                        {
                            shotDamage = 0;
                        }
                        if (Level.Monsters.DamageMonster(tile.MonsterIndex, shotDamage, out bool fear, noteDies))
                        {
                            // The monster is dead, so don't add further statuses or messages
                        }
                        else
                        {
                            Level.Monsters.MessagePain(tile.MonsterIndex, shotDamage);
                            if (fear && monster.IsVisible)
                            {
                                PlaySound(SoundEffect.MonsterFlees);
                                string mName = monster.Name;
                                MsgPrint($"{mName} flees in terror!");
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
            Level.DropNear(individualAmmunition, j, y, x);
        }

        public void DoEatCmd()
        {
            int itemIndex = -999;
            // Get a food item from the inventory if one wasn't already specified
            if (itemIndex == -999)
            {
                if (!GetItem(out itemIndex, "Eat which item? ", false, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Food)))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have nothing to eat.");
                    }
                    return;
                }
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            // Make sure the item is edible
            if (!Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Food)))
            {
                MsgPrint("You can't eat that!");
                return;
            }
            // We don't actually eat dwarf bread
            if (item.ItemSubCategory != FoodType.Dwarfbread)
            {
                PlaySound(SoundEffect.Eat);
            }
            // Eating costs 100 energy
            EnergyUse = 100;
            bool ident = false;
            int itemLevel = item.BaseItemCategory.Level;
            FoodItemClass foodItem = (FoodItemClass)item.BaseItemCategory;

            // Allow the food item to process the consumption.
            ident = foodItem.Eat(this);

            NoticeCombineAndReorderFlaggedAction.Set();
            // We've tried this type of object
            item.ObjectTried();
            // Learn its flavour if necessary
            if (ident && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                Player.GainExperience((itemLevel + (Player.Level >> 1)) / Player.Level);
            }

            // Now races process the sustenance.
            Player.Race.Eat(this, item);

            // Dwarf bread isn't actually eaten so return early
            if (item.ItemSubCategory == FoodType.Dwarfbread)
            {
                return;
            }

            // Use up the item (if it fell to the floor this will have already been dealt with)
            if (itemIndex >= 0)
            {
                Player.InvenItemIncrease(itemIndex, -1);
                Player.InvenItemDescribe(itemIndex);
                Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                Level.FloorItemIncrease(0 - itemIndex, -1);
                Level.FloorItemDescribe(0 - itemIndex);
                Level.FloorItemOptimize(0 - itemIndex);
            }
        }

        public bool DoCmdTunnel()
        {
            bool more = false;
            // Get the direction in which we wish to tunnel
            if (GetDirectionNoAim(out int dir))
            {
                // Pick up the tile that the player wishes to tunnel through
                int tileY = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int tileX = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[tileY][tileX];
                // Check if it can be tunneled through
                if (tile.FeatureType.IsPassable || tile.FeatureType.Name == "YellowSign")
                {
                    MsgPrint("You cannot tunnel through air.");
                }
                else if (tile.FeatureType.IsClosedDoor)
                {
                    MsgPrint("You cannot tunnel through doors.");
                }
                // Can't tunnel if there's a monster there - so attack the monster instead
                else if (tile.MonsterIndex != 0)
                {
                    EnergyUse = 100;
                    MsgPrint("There is a monster in the way!");
                    PlayerAttackMonster(tileY, tileX);
                }
                else
                {
                    // Tunnel through the tile
                    more = TunnelThroughTile(tileY, tileX);
                }
            }
            return more;
        }

        public void DoCmdSpike()
        {
            // Get the location to be spiked
            if (GetDirectionNoAim(out int dir))
            {
                int y = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int x = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[y][x];
                // Make sure it can be spiked and we have spikes to do it with
                if (!tile.FeatureType.IsClosedDoor)
                {
                    MsgPrint("You see nothing there to spike.");
                }
                else
                {
                    if (!GetSpike(out int itemIndex))
                    {
                        MsgPrint("You have no spikes!");
                    }
                    // Can't close a door if there's someone in the way
                    else if (tile.MonsterIndex != 0)
                    {
                        // Attempting costs a turn anyway
                        EnergyUse = 100;
                        MsgPrint("There is a monster in the way!");
                        PlayerAttackMonster(y, x);
                    }
                    else
                    {
                        // Spiking a door costs a turn
                        EnergyUse = 100;
                        MsgPrint("You jam the door with a spike.");
                        // Replace the door feature with a jammed door
                        if (tile.FeatureType.Category == FloorTileTypeCategory.LockedDoor)
                        {
                            tile.SetFeature(tile.FeatureType.Name.Replace("Locked", "Jammed"));
                        }
                        // If it's already jammed, strengthen it
                        if (tile.FeatureType.Category == FloorTileTypeCategory.JammedDoor)
                        {
                            int strength = int.Parse(tile.FeatureType.Name.Substring(10));
                            if (strength < 7)
                            {
                                tile.SetFeature($"JammedDoor{strength + 1}");
                            }
                        }
                        // Use up the spike from the player's inventory
                        Player.InvenItemIncrease(itemIndex, -1);
                        Player.InvenItemDescribe(itemIndex);
                        Player.InvenItemOptimize(itemIndex);
                    }
                }
            }
        }

        public void DoCmdFeeling(bool feelingOnly)
        {
            string[] DangerFeelingText =
            {
                "You're not sure about this level yet", "You feel there is something special about this level.",
                "You nearly faint as horrible visions of death fill your mind", "This level looks very dangerous",
                "You have a very bad feeling", "You have a bad feeling", "You feel nervous",
                "You feel unsafe", "You don't like the look of this place",
                "This level looks reasonably safe", "What a boring place"
            };


            string[] TreasureFeelingText = {
                "You're not sure about this level yet.", "you feel it contains something special",
                "treasure galore!", "with a veritable hoard.",
                "powerful magic can be found here.", "there's magic in the air.", "there's wealth to be found.",
                "with significant treasure.", "there's not much of value here.",
                "with nothing of worth.", "what meagre pickings..."
            };
    
            // Some sanity checks
            if (Level.DangerFeeling < 0)
            {
                Level.DangerFeeling = 0;
            }
            if (Level.DangerFeeling > 10)
            {
                Level.DangerFeeling = 10;
            }
            if (Level.TreasureFeeling < 0)
            {
                Level.TreasureFeeling = 0;
            }
            if (Level.TreasureFeeling > 10)
            {
                Level.TreasureFeeling = 10;
            }
            if (CurrentDepth <= 0)
            {
                // If we need to say where we are, do so
                if (!feelingOnly)
                {
                    if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                    {
                        MsgPrint($"You are in {CurTown.Name}.");
                    }
                    else if (Wilderness[Player.WildernessY][Player.WildernessX].Dungeon != null)
                    {
                        MsgPrint($"You are outside {Wilderness[Player.WildernessY][Player.WildernessX].Dungeon.Name}.");
                    }
                    else
                    {
                        MsgPrint("You are wandering around outside.");
                    }
                }
                // If we're not in a dungeon, there's no feeling to be had
                return;
            }
            // If we need to say where we are, do so
            if (!feelingOnly)
            {
                MsgPrint($"You are in {CurDungeon.Name}.");
                if (Quests.IsQuest(CurrentDepth))
                {
                    Quests.PrintQuestMessage();
                }
            }
            // Special feeling overrides the normal two-part feeling
            if (Level.DangerFeeling == 1 || Level.TreasureFeeling == 1)
            {
                string message = DangerFeelingText[1];
                MsgPrint(Player.GameTime.LevelFeel ? message : DangerFeelingText[0]);
            }
            else
            {
                // Make the two-part feeling make a bit more sense by using the correct conjunction
                string conjunction = ", and ";
                if ((Level.DangerFeeling > 5 && Level.TreasureFeeling < 6) || (Level.DangerFeeling < 6 && Level.TreasureFeeling > 5))
                {
                    conjunction = ", but ";
                }
                string message = DangerFeelingText[Level.DangerFeeling] + conjunction + TreasureFeelingText[Level.TreasureFeeling];
                MsgPrint(Player.GameTime.LevelFeel ? message : DangerFeelingText[0]);
            }
        }

        public bool DoCmdClose()
        {
            bool more = false;
            // If there's only one door, assume we mean that one and don't ask for a direction
            if (CountOpenDoors(out GridCoordinate? coord) == 1)
            {
                CommandDirection = Level.CoordsToDir(coord.Y, coord.X);
            }
            // Get the location to close
            if (GetDirectionNoAim(out int dir))
            {
                int y = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int x = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[y][x];
                // Can only close actual open doors
                if (tile.FeatureType.Category != FloorTileTypeCategory.OpenDoorway)
                {
                    MsgPrint("You see nothing there to close.");
                }
                // Can't close if there's a monster in the way
                else if (tile.MonsterIndex != 0)
                {
                    EnergyUse = 100;
                    MsgPrint("There is a monster in the way!");
                    PlayerAttackMonster(y, x);
                }
                // Actually close the door
                else
                {
                    more = CloseDoor(y, x);
                }
            }
            return more;
        }

        public void DoCmdWield()
        {
            // Only interested in wearable items
            if (!GetItem(out int itemIndex, "Wear/Wield which item? ", false, true, true, new WearableItemFilter()))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing you can wear or wield.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];

            // Find the inventory slot where the item is to be wielded.
            int slot = item.BaseItemCategory.WieldSlot;


            // Can't replace a cursed item
            if (Player.Inventory[slot].IsCursed())
            {
                string cursedItemName = Player.Inventory[slot].Description(false, 0);
                MsgPrint($"The {cursedItemName} you are {Player.DescribeWieldLocation(slot)} appears to be cursed.");
                return;
            }

            // If we know the item to be cursed, confirm its wearing
            if (item.IsCursed() && (item.IsKnown() || item.IdentSense))
            {
                string cursedItemName = item.Description(false, 0);
                string dummy = $"Really use the {cursedItemName} {{cursed}}? ";
                if (!GetCheck(dummy))
                {
                    return;
                }
            }

            // Use some energy
            EnergyUse = 100;

            // Pull one item out of the item stack
            Item wornItem = item.Clone(1);

            // Reduce the count of the item stack accordingly
            if (itemIndex >= 0)
            {
                Player.InvenItemIncrease(itemIndex, -1);
                Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                Level.FloorItemIncrease(0 - itemIndex, -1);
                Level.FloorItemOptimize(0 - itemIndex);
            }
            // Take off the old item
            item = Player.Inventory[slot];
            if (item.BaseItemCategory != null)
            {
                Player.InvenTakeoff(slot, 255);
            }
            // Put the item into the wield slot
            Player.Inventory[slot] = wornItem;
            // Add the weight of the item
            Player.WeightCarried += wornItem.Weight;

            // Inform us what we did
            BaseInventorySlot inventorySlot = SingletonRepository.InventorySlots.Single(_inventorySlot => _inventorySlot.InventorySlots.Contains(slot));
            string wieldPhrase = inventorySlot.WieldPhrase;
            string itemName = wornItem.Description(true, 3);
            MsgPrint($"{wieldPhrase} {itemName} ({slot.IndexToLabel()}).");
            // Let us know if it's cursed
            if (wornItem.IsCursed())
            {
                MsgPrint("Oops! It feels deathly cold!");
                wornItem.IdentSense = true;
            }
            UpdateBonusesFlaggedAction.Set();
            UpdateTorchRadiusFlaggedAction.Set();
            UpdateManaFlaggedAction.Set();
            RedrawEquippyFlaggedAction.Set();
        }

        public void DoCmdViewCharacter()
        {
            // Save the current screen
            FullScreenOverlay = true;
            ScreenBuffer savedScreen = Screen.Clone();
            SetBackground(BackgroundImage.Paper);
            // Load the character viewer
            CharacterViewer characterViewer = new CharacterViewer(this);
            while (true && !Shutdown)
            {
                characterViewer.DisplayPlayer();
                Screen.Print(Colour.Orange, "[Press 'c' to change name, or ESC]", 43, 23);
                char keyPress = Inkey();
                // Escape breaks us out of the loop
                if (keyPress == '\x1b')
                {
                    break;
                }
                // 'c' changes name
                if (keyPress == 'c' || keyPress == 'C')
                {
                    Player.InputPlayerName();
                }
                MsgPrint(null);
            }
            // Restore the screen
            SetBackground(BackgroundImage.Overhead);
            Screen.Restore(savedScreen);
            FullScreenOverlay = false;
            RedrawMapFlaggedAction.Set();
            RedrawEquippyFlaggedAction.Set();
            PrExtraRedrawAction.Set();
            PrBasicRedrawAction.Set();
            RedrawAllFlaggedAction.Set(); // TODO: special case ... should be some form of invalidate
            HandleStuff();
        }

        public void DoCmdTakeOff()
        {
            // Get the item to take off
            if (!GetItem(out int itemIndex, "Take off which item? ", true, false, false, null))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You are not wearing anything to take off.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Can't take of cursed items
            if (item.IsCursed())
            {
                MsgPrint("Hmmm, it seems to be cursed.");
                return;
            }
            // Take off the item
            EnergyUse = 50;
            Player.InvenTakeoff(itemIndex, 255);
            RedrawEquippyFlaggedAction.Set();
        }

        public void DoCmdMessages()
        {
            int messageNumber = MessageNum();
            int index = 0;
            int horizontalOffset = 0;
            FullScreenOverlay = true;
            ScreenBuffer savedScreen = Screen.Clone();
            SetBackground(BackgroundImage.Normal);
            // Infinite loop showing a page of messages from the index
            while (true && !Shutdown)
            {
                // Clear the screen
                Screen.Clear();
                int row;
                // Print the messages
                for (row = 0; row < 40 && index + row < messageNumber; row++)
                {
                    string msg = MessageStr((short)(index + row));
                    msg = msg.Length >= horizontalOffset ? msg.Substring(horizontalOffset) : "";
                    Screen.Print(Colour.White, msg, 41 - row, 0);
                }
                // Get a command
                Screen.PrintLine($"Message Recall ({index}-{index + row - 1} of {messageNumber}), Offset {horizontalOffset}", 0, 0);
                Screen.PrintLine("[Press 'p' for older, 'n' for newer, <dir> to scroll, or ESCAPE]", 43, 0);
                int keyCode = Inkey();
                if (keyCode == '\x1b')
                {
                    // Break out of the infinite loop
                    break;
                }
                if (keyCode == '4')
                {
                    horizontalOffset = horizontalOffset >= 40 ? horizontalOffset - 40 : 0;
                    continue;
                }
                if (keyCode == '6')
                {
                    horizontalOffset += 40;
                    continue;
                }
                if (keyCode == '8' || keyCode == '\n' || keyCode == '\r')
                {
                    if (index + 1 < messageNumber)
                    {
                        index++;
                    }
                }
                if (keyCode == 'p' || keyCode == ' ')
                {
                    if (index + 40 < messageNumber)
                    {
                        index += 40;
                    }
                }
                if (keyCode == 'n')
                {
                    index = index >= 40 ? index - 40 : 0;
                }
                if (keyCode == '2')
                {
                    index = index >= 1 ? index - 1 : 0;
                }
            }
            // Tidy up after ourselves
            Screen.Restore(savedScreen);
            FullScreenOverlay = false;
        }

        public void DoCmdMessageOne()
        {
            Screen.PrintLine($"> {MessageStr(0)}", 0, 0);
        }

        public void DoCmdManual()
        {
            ShowManual();
        }

        public void DoCmdJournal()
        {
            // Let the journal itself handle it from here
            Journal journal = new Journal(this);
            journal.ShowMenu();
        }

        public void DoCmdExamine()
        {
            // Get the item to examine
            if (!GetItem(out int itemIndex, "Examine which item? ", true, true, true, null))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have nothing to examine.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Do we know anything about it?
            if (!item.IdentMental)
            {
                MsgPrint("You have no special knowledge about that item.");
                return;
            }
            string itemName = item.Description(true, 3);
            MsgPrint($"Examining {itemName}...");
            // We're not actually identifying it, because it's already itentified, but we want to
            // repeat the identification text
            if (!item.IdentifyFully())
            {
                MsgPrint("You see nothing special.");
            }
        }

        public void DoCmdBrowse()
        {
            int spell;
            int spellIndex = 0;
            int[] spells = new int[64];
            // Make sure we can read
            if (Player.Realm1 == 0 && Player.Realm2 == 0)
            {
                MsgPrint("You cannot read books!");
                return;
            }
            // Get a book to read if we don't already have one
            if (!GetItem(out int itemIndex, "Browse which book? ", false, true, true, new UsableSpellBookItemFilter(this)))
            {
                if (itemIndex == -2)
                {
                    MsgPrint("You have no books that you can read.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Check that the book is useable by the player
            if (!Player.ItemMatchesFilter(item, new UsableSpellBookItemFilter(this)))
            {
                MsgPrint("You can't read that.");
                return;
            }
            int bookSubCategory = item.ItemSubCategory;
            HandleStuff();
            // Find all spells in the book and add them to the array
            for (spell = 0; spell < 32; spell++)
            {
                if ((Constants.BookSpellFlags[bookSubCategory] & (1u << spell)) != 0)
                {
                    spells[spellIndex++] = spell;
                }
            }
            // Save the screen and overprint the spells in the book
            ScreenBuffer savedScreen = Screen.Clone();
            Player.PrintSpells(spells, spellIndex, 1, 20, item.BaseItemCategory.SpellBookToToRealm);
            Screen.PrintLine("", 0, 0);
            // Wait for a keypress and re-load the screen
            Screen.Print("[Press any key to continue]", 0, 23);
            Inkey();
            Screen.Restore(savedScreen);
        }

        public bool DoAlter()
        {
            // Assume we won't disturb the player
            bool more = false;

            // Get the direction in which to alter something
            if (GetDirectionNoAim(out int dir))
            {
                int y = Player.MapY + Level.KeypadDirectionYOffset[dir];
                int x = Player.MapX + Level.KeypadDirectionXOffset[dir];
                GridTile tile = Level.Grid[y][x];
                // Altering a tile will take a turn
                EnergyUse = 100;
                // We 'alter' a tile by attacking it
                if (tile.MonsterIndex != 0)
                {
                    PlayerAttackMonster(y, x);
                }
                else
                {
                    // Check the action based on the type of tile
                    AlterAction? alterAction = tile.FeatureType.AlterAction;
                    if (alterAction == null)
                    {
                        MsgPrint("You're not sure what you can do with that...");
                    }
                    else
                    {
                        AlterEventArgs alterEventArgs = new AlterEventArgs(this, y, x);
                        alterAction.Execute(alterEventArgs);
                        more = alterEventArgs.More;
                    }
                }
            }
            return more;
        }

        public void DoCast()
        {
            if (Player.HasAntiMagic)
            {
                string whichMagicType = "magic";
                if (Player.BaseCharacterClass.ID == CharacterClass.Mindcrafter || Player.BaseCharacterClass.ID == CharacterClass.Mystic)
                {
                    whichMagicType = "psychic talents";
                }
                else if (Player.BaseCharacterClass.SpellCastingType == CastingType.Divine)
                {
                    whichMagicType = "prayer";
                }
                MsgPrint($"An anti-magic shell disrupts your {whichMagicType}!");
                EnergyUse = 5;
            }
            else
            {
                if (Player.BaseCharacterClass.SpellCastingType == CastingType.Mentalism)
                {
                    DoCmdMentalism();
                }
                else
                {
                    DoCmdCast();
                }
            }
        }

        private void DoCmdCast()
        {
            string prayer = Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? "prayer" : "spell";
            if (Player.Realm1 == 0)
            {
                MsgPrint("You cannot cast spells!");
                return;
            }
            if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
            {
                MsgPrint("You cannot see!");
                return;
            }
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                MsgPrint("You are too confused!");
                return;
            }
            if (!GetItem(out int item, "Use which book? ", false, true, true, new UsableSpellBookItemFilter(this)))
            {
                if (item == -2)
                {
                    MsgPrint($"You have no {prayer} books!");
                }
                return;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            int sval = oPtr.ItemSubCategory;
            bool useSetTwo = oPtr.Category == Player.Realm2.ToSpellBookItemCategory();
            HandleStuff();
            if (!GetSpell(out int spell, Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? "recite" : "cast", sval, true, useSetTwo, Player))
            {
                if (spell == -2)
                {
                    MsgPrint($"You don't know any {prayer}s in that book.");
                }
                return;
            }
            Spell sPtr = useSetTwo ? Spells[1][spell] : Spells[0][spell];
            if (sPtr.ManaCost > Player.Mana)
            {
                string cast = Player.BaseCharacterClass.SpellCastingType == CastingType.Divine ? "recite" : "cast";
                MsgPrint($"You do not have enough mana to {cast} this {prayer}.");
                if (!GetCheck("Attempt it anyway? "))
                {
                    return;
                }
            }
            int chance = sPtr.FailureChance(Player);
            if (Program.Rng.RandomLessThan(100) < chance)
            {
                MsgPrint($"You failed to get the {prayer} off!");
                if (oPtr.Category == ItemTypeEnum.ChaosBook && Program.Rng.DieRoll(100) < spell)
                {
                    MsgPrint("You produce a chaotic effect!");
                    WildMagic(spell);
                }
                else if (oPtr.Category == ItemTypeEnum.DeathBook && Program.Rng.DieRoll(100) < spell)
                {
                    if (sval == 3 && Program.Rng.DieRoll(2) == 1)
                    {
                        Level.Monsters[0].SanityBlast(this, true);
                    }
                    else
                    {
                        MsgPrint("It hurts!");
                        Player.TakeHit(Program.Rng.DiceRoll(oPtr.ItemSubCategory + 1, 6), "a miscast Death spell");
                        if (spell > 15 && Program.Rng.DieRoll(6) == 1 && !Player.HasHoldLife)
                        {
                            Player.LoseExperience(spell * 250);
                        }
                    }
                }
            }
            else
            {
                sPtr.Cast(this);
                if (!sPtr.Worked)
                {
                    int e = sPtr.FirstCastExperience;
                    sPtr.Worked = true;
                    Player.GainExperience(e * sPtr.Level);
                }
            }
            EnergyUse = 100;
            if (sPtr.ManaCost <= Player.Mana)
            {
                Player.Mana -= sPtr.ManaCost;
            }
            else
            {
                int oops = sPtr.ManaCost - Player.Mana;
                Player.Mana = 0;
                Player.FractionalMana = 0;
                MsgPrint("You faint from the effort!");
                Player.TimedParalysis.AddTimer(Program.Rng.DieRoll((5 * oops) + 1));
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    bool perm = Program.Rng.RandomLessThan(100) < 25;
                    MsgPrint("You have damaged your health!");
                    Player.DecreaseAbilityScore(Ability.Constitution, 15 + Program.Rng.DieRoll(10), perm);
                }
            }
            RedrawManaFlaggedAction.Set();
        }

        public void DoCmdMentalism()
        {
            int plev = Player.Level;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                MsgPrint("You are too confused!");
                return;
            }
            if (!GetMentalismTalent(out int n))
            {
                return;
            }
            Talents.Talent talent = Talents[n];
            if (talent.ManaCost > Player.Mana)
            {
                MsgPrint("You do not have enough mana to use this talent.");
                if (!GetCheck("Attempt it anyway? "))
                {
                    return;
                }
            }
            int chance = talent.FailureChance(Player);
            if (Program.Rng.RandomLessThan(100) < chance)
            {
                MsgPrint("You failed to concentrate hard enough!");
                if (Program.Rng.DieRoll(100) < chance / 2)
                {
                    int i = Program.Rng.DieRoll(100);
                    if (i < 5)
                    {
                        MsgPrint("Oh, no! Your mind has gone blank!");
                        LoseAllInfo();
                    }
                    else if (i < 15)
                    {
                        MsgPrint("Weird visions seem to dance before your eyes...");
                        Player.TimedHallucinations.AddTimer(5 + Program.Rng.DieRoll(10));
                    }
                    else if (i < 45)
                    {
                        MsgPrint("Your brain is addled!");
                        Player.TimedConfusion.AddTimer(Program.Rng.DieRoll(8));
                    }
                    else if (i < 90)
                    {
                        Player.TimedStun.AddTimer(Program.Rng.DieRoll(8));
                    }
                    else
                    {
                        MsgPrint("Your mind unleashes its power in an uncontrollable storm!");
                        Project(1, 2 + (plev / 10), Player.MapY, Player.MapX, plev * 2, new ProjectMana(this), ProjectionFlag.ProjectJump | ProjectionFlag.ProjectKill | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem);
                        Player.Mana = Math.Max(0, Player.Mana - (plev * Math.Max(1, plev / 10)));
                    }
                }
            }
            else
            {
                talent.Use(this);
            }
            EnergyUse = 100;
            if (talent.ManaCost <= Player.Mana)
            {
                Player.Mana -= talent.ManaCost;
            }
            else
            {
                int oops = talent.ManaCost - Player.Mana;
                Player.Mana = 0;
                Player.FractionalMana = 0;
                MsgPrint("You faint from the effort!");
                Player.TimedParalysis.AddTimer(Program.Rng.DieRoll((5 * oops) + 1));
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    bool perm = Program.Rng.RandomLessThan(100) < 25;
                    MsgPrint("You have damaged your mind!");
                    Player.DecreaseAbilityScore(Ability.Wisdom, 15 + Program.Rng.DieRoll(10), perm);
                }
            }
            RedrawManaFlaggedAction.Set();
        }

        private bool GetMentalismTalent(out int sn)
        {
            int i;
            int num = 0;
            int y = 1;
            int x = 20;
            int plev = Player.Level;
            string p = "talent";
            sn = -1;
            bool flag = false;
            ScreenBuffer? savedScreen = null;
            TalentList talents = Talents;
            for (i = 0; i < talents.Count; i++)
            {
                if (talents[i].Level <= plev)
                {
                    num++;
                }
            }
            string outVal = $"({p}s {0.IndexToLetter()}-{(num - 1).IndexToLetter()}, *=List, ESC=exit) Use which {p}? ";
            while (!flag && GetCom(outVal, out char choice))
            {
                if (choice == ' ' || choice == '*' || choice == '?')
                {
                    if (savedScreen == null)
                    {
                        savedScreen = Screen.Clone();
                        Screen.PrintLine("", y, x);
                        Screen.Print("Name", y, x + 5);
                        Screen.Print("Lv Mana Fail Info", y, x + 35);
                        for (i = 0; i < talents.Count; i++)
                        {
                            Talents.Talent talent = talents[i];
                            if (talent.Level > plev)
                            {
                                break;
                            }
                            string psiDesc = $"  {i.IndexToLetter()}) {talent.SummaryLine(Player)}";
                            Screen.PrintLine(psiDesc, y + i + 1, x);
                        }
                        Screen.PrintLine("", y + i + 1, x);
                    }
                    else
                    {
                        Screen.Restore(savedScreen);
                        savedScreen = null;
                    }
                    continue;
                }
                bool ask = char.IsUpper(choice);
                if (ask)
                {
                    choice = char.ToLower(choice);
                }
                i = char.IsLower(choice) ? choice.LetterToNumber() : -1;
                if (i < 0 || i >= num)
                {
                    continue;
                }
                if (ask)
                {
                    string tmpVal = $"Use {talents[i].Name}? ";
                    if (!GetCheck(tmpVal))
                    {
                        continue;
                    }
                }
                flag = true;
            }
            if (savedScreen != null)
            {
                Screen.Restore(savedScreen);
            }
            if (!flag)
            {
                return false;
            }
            sn = i;
            return true;
        }

        private void WildMagic(int spell)
        {
            switch (Program.Rng.DieRoll(spell) + Program.Rng.DieRoll(8) + 1) // TODO: Convert this to WeightedRandom
            {
                case 1:
                case 2:
                case 3:
                    TeleportPlayer(10);
                    break;

                case 4:
                case 5:
                case 6:
                    TeleportPlayer(100);
                    break;

                case 7:
                case 8:
                    TeleportPlayer(200);
                    break;

                case 9:
                case 10:
                case 11:
                    UnlightArea(10, 3);
                    break;

                case 12:
                case 13:
                case 14:
                    LightArea(Program.Rng.DiceRoll(2, 3), 2);
                    break;

                case 15:
                    DestroyDoorsTouch();
                    break;

                case 16:
                case 17:
                    WallBreaker();
                    break;

                case 18:
                    SleepMonstersTouch();
                    break;

                case 19:
                case 20:
                    TrapCreation();
                    break;

                case 21:
                case 22:
                    DoorCreation();
                    break;

                case 23:
                case 24:
                case 25:
                    AggravateMonsters();
                    break;

                case 26:
                    Earthquake(Player.MapY, Player.MapX, 5);
                    break;

                case 27:
                case 28:
                    Player.Dna.GainMutation(this);
                    break;

                case 29:
                case 30:
                    ApplyDisenchant();
                    break;

                case 31:
                    LoseAllInfo();
                    break;

                case 32:
                    FireBall(new ProjectChaos(this), 0, spell + 5, 1 + (spell / 10));
                    break;

                case 33:
                    WallStone();
                    break;

                case 34:
                case 35:
                    int counter = 0;
                    while (counter++ < 8)
                    {
                        Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty * 3 / 2, MonsterSelector.RandomBizarre());
                    }
                    break;

                case 36:
                case 37:
                    ActivateHiSummon();
                    break;

                case 38:
                    SummonReaver();
                    break;

                default:
                    ActivateDreadCurse();
                    break;
            }
        }

        public void DoAimWand()
        {
            int itemIndex = -999;
            if (itemIndex == -999)
            {
                // Prompt for an item, showing only wands
                if (!GetItem(out itemIndex, "Aim which wand? ", true, true, true, new ItemCategoryItemFilter(ItemTypeEnum.Wand)))
                {
                    if (itemIndex == -2)
                    {
                        MsgPrint("You have no wand to aim.");
                    }
                    return;
                }
            }
            // Get the item and check if it is really a wand
            Item item = itemIndex >= 0 ? Player.Inventory[itemIndex] : Level.Items[0 - itemIndex];
            if (!Player.ItemMatchesFilter(item, new ItemCategoryItemFilter(ItemTypeEnum.Wand)))
            {
                MsgPrint("That is not a wand!");
                return;
            }
            // We can't use wands directly from the floor, since we need to aim them
            if (itemIndex < 0 && item.Count > 1)
            {
                MsgPrint("You must first pick up the wand.");
                return;
            }
            // Aim the wand
            if (!GetDirectionWithAim(out int dir))
            {
                return;
            }
            // Using a wand takes 100 energy
            EnergyUse = 100;
            bool ident = false;
            int itemLevel = item.BaseItemCategory.Level;
            // Chance of success is your skill - item level, with item level capped at 50 and your
            // skill halved if you're confused
            int chance = Player.SkillUseDevice;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                chance /= 2;
            }
            chance -= itemLevel > 50 ? 50 : itemLevel;
            // Always a small chance of success
            if (chance < Constants.UseDevice && Program.Rng.RandomLessThan(Constants.UseDevice - chance + 1) == 0)
            {
                chance = Constants.UseDevice;
            }
            if (chance < Constants.UseDevice || Program.Rng.DieRoll(chance) < Constants.UseDevice)
            {
                MsgPrint("You failed to use the wand properly.");
                return;
            }
            // Make sure we have charges
            if (item.TypeSpecificValue <= 0)
            {
                MsgPrint("The wand has no charges left.");
                item.IdentEmpty = true;
                return;
            }
            PlaySound(SoundEffect.ZapRod);
            WandItemClass activateableItem = (WandItemClass)item.BaseItemCategory;
            if (activateableItem.ExecuteActivation(this, dir))
            {
                ident = true;
            }

            NoticeCombineAndReorderFlaggedAction.Set();
            // Mark the wand as having been tried
            item.ObjectTried();
            // If we just discovered the item's flavour, mark it as so
            if (ident && !item.IsFlavourAware())
            {
                item.BecomeFlavourAware();
                Player.GainExperience((itemLevel + (Player.Level >> 1)) / Player.Level);
            }
            // If we're a channeler then we should be using mana instead of charges
            bool channeled = false;
            if (Player.BaseCharacterClass.SpellCastingType == CastingType.Channeling)
            {
                channeled = DoCmdChannel(item);
            }
            // We didn't use mana, so decrease the wand's charges
            if (!channeled)
            {
                item.TypeSpecificValue--;
                // If the wand is part of a stack, split it off from the others
                if (itemIndex >= 0 && item.Count > 1)
                {
                    Item splitItem = item.Clone(1);
                    item.TypeSpecificValue++;
                    item.Count--;
                    Player.WeightCarried -= splitItem.Weight;
                    itemIndex = Player.InvenCarry(splitItem, false);
                    MsgPrint("You unstack your wand.");
                }
                // Let us know we have used a charge
                if (itemIndex >= 0)
                {
                    Player.ReportChargeUsageFromInventory(itemIndex);
                }
                else
                {
                    Level.ReportChargeUsageFromFloor(0 - itemIndex);
                }
            }
        }

        /// <summary>
        /// Search around the player for secret doors and traps
        /// </summary>
        public void Search()
        {
            // The basic chance is equal to our searching skill
            int chance = Player.SkillSearching;
            // If we can't see it's hard to search
            if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
            {
                chance /= 10;
            }
            // If we're confused it's hard to search
            if (Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0)
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
                            if (item.Category != ItemTypeEnum.Chest)
                            {
                                continue;
                            }
                            if (item.TypeSpecificValue <= 0)
                            {
                                continue;
                            }
                            if (ObjectRepository.ChestTrapConfigurations[item.TypeSpecificValue].NotTrapped)
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
            // If we didn't have a direction, we might have an existing target
            if (dir == 5 && TargetOkay())
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
            RedrawMapFlaggedAction.Set();
        }

        /// <summary>
        /// Tunnel through a grid tile
        /// </summary>
        /// <param name="y"> The y coordinate of the tile to be tunneled through </param>
        /// <param name="x"> The x coordinate of the tile to be tunneled through </param>
        /// <returns>True, if the command should be allowed to be continued; false, if the command succeeded, or is futile.</returns>
        public bool TunnelThroughTile(int y, int x)
        {
            bool more = false;
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
                    more = true;
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
                    more = true;
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
                    more = true;
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
                    more = true;
                }
                else
                {
                    MsgPrint("You tunnel into the quartz vein.");
                    more = true;
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
                    more = true;
                }
            }
            // We don't recognise what we're tunnelling into, so just assume it's permanent
            else
            {
                MsgPrint($"The {tile.FeatureType.Description} resists your attempts to tunnel through it.");
                more = true;
                Search();
            }
            // If we successfully made the tunnel,
            if (!Level.GridPassable(y, x))
            {
                UpdateScentFlaggedAction.Set();
                UpdateMonstersFlaggedAction.Set();
                UpdateLightFlaggedAction.Set();
                UpdateViewFlaggedAction.Set();
            }
            if (!more)
            {
                PlaySound(SoundEffect.Dig);
            }
            return more;
        }

        /// <summary>
        /// Use the player's racial power, if they have one
        /// </summary>
        public void UseRacialPower()
        {
            // Check the player's race to see what their power is
            Player.Race.UseRacialPower(this);
            RedrawHpFlaggedAction.Set();
            RedrawManaFlaggedAction.Set();
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
                if (Player.TimedBlindness.TurnsRemaining != 0 || Level.NoLight())
                {
                    skill /= 10;
                }
                // Lockpicking is hard when you're confused
                if (Player.TimedConfusion.TurnsRemaining != 0 || Player.TimedHallucinations.TurnsRemaining != 0)
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
                    UpdateMonstersFlaggedAction.Set();
                    UpdateLightFlaggedAction.Set();
                    UpdateViewFlaggedAction.Set();
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
                UpdateMonstersFlaggedAction.Set();
                UpdateLightFlaggedAction.Set();
                UpdateViewFlaggedAction.Set();
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
            string monsterName = monster.Name;
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
                if (monster.SmFriendly)
                {
                    MsgPrint($"{monsterName} gets angry!");
                    monster.SmFriendly = false;
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
            UpdateScentFlaggedAction.Set();
            UpdateMonstersFlaggedAction.Set();
            UpdateLightFlaggedAction.Set();
            UpdateViewFlaggedAction.Set();
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
                                Player.TimedBleeding.AddTimer(Program.Rng.DieRoll(damage));
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
                                Player.TimedBleeding.AddTimer(Program.Rng.DieRoll(damage));
                                // Hagarg Ryonis can save us from the poison
                                if (Player.HasPoisonResistance || Player.TimedPoisonResistance.TurnsRemaining != 0)
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
                                    Player.TimedPoison.AddTimer(Program.Rng.DieRoll(damage));
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
                            Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, null);
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
                            Player.TimedSlow.AddTimer(Program.Rng.RandomLessThan(20) + 20);
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
                            Player.TimedBlindness.AddTimer(Program.Rng.RandomLessThan(50) + 25);
                        }
                        break;
                    }
                case "ConfuseGas":
                    {
                        // Confuse the player
                        MsgPrint("A gas of scintillating colours surrounds you!");
                        if (!Player.HasConfusionResistance)
                        {
                            Player.TimedConfusion.AddTimer(Program.Rng.RandomLessThan(20) + 10);
                        }
                        break;
                    }
                case "PoisonGas":
                    {
                        // Poison the player
                        MsgPrint("A pungent green gas surrounds you!");
                        if (!Player.HasPoisonResistance && Player.TimedPoisonResistance.TurnsRemaining == 0)
                        {
                            // Hagarg Ryonis may save you from the poison
                            if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                            {
                                MsgPrint("Hagarg Ryonis's favour protects you!");
                            }
                            else
                            {
                                Player.TimedPoison.AddTimer(Program.Rng.RandomLessThan(20) + 10);
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
                            Player.TimedParalysis.AddTimer(Program.Rng.RandomLessThan(10) + 5);
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
            if (race.FireAura)
            {
                if (!Player.HasFireImmunity)
                {
                    auraDamage = Program.Rng.DiceRoll(1 + (race.Level / 26), 1 + (race.Level / 17));
                    string auraDam = monster.IndefiniteVisibleName;
                    MsgPrint("You are suddenly very hot!");
                    if (Player.TimedFireResistance.TurnsRemaining != 0)
                    {
                        auraDamage = (auraDamage + 2) / 3;
                    }
                    if (Player.HasFireResistance)
                    {
                        auraDamage = (auraDamage + 2) / 3;
                    }
                    Player.TakeHit(auraDamage, auraDam);
                    race.Knowledge.Characteristics.FireAura = true;
                    HandleStuff();
                }
            }
            // If we have a lightning aura, apply it
            if (race.LightningAura && !Player.HasLightningImmunity)
            {
                auraDamage = Program.Rng.DiceRoll(1 + (race.Level / 26), 1 + (race.Level / 17));
                string auraDam = monster.IndefiniteVisibleName;
                if (Player.TimedLightningResistance.TurnsRemaining != 0)
                {
                    auraDamage = (auraDamage + 2) / 3;
                }
                if (Player.HasLightningResistance)
                {
                    auraDamage = (auraDamage + 2) / 3;
                }
                MsgPrint("You get zapped!");
                Player.TakeHit(auraDamage, auraDam);
                race.Knowledge.Characteristics.LightningAura = true;
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
                if (monster.SmFriendly)
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
                monster.Energy += Constants.ExtractEnergy[monster.Speed];
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
                    if (!Level.Monsters[Level.Grid[y][x].MonsterIndex].SmFriendly)
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
        /// Prints a 'press any key' message and waits for a key press
        /// </summary>
        /// <param name="row"> The row on which to print the message </param>
        public void AnyKey(int row)
        {
            Screen.PrintLine("", row, 0);
            Screen.Print(Colour.Orange, "[Press any key to continue]", row, 27);
            Inkey();
            Screen.PrintLine("", row, 0);
        }

        public bool AskforAux(out string buf, string initial, int len)
        {
            buf = initial;
            char i = '\0';
            int k = 0;
            bool done = false;
            GridCoordinate cursorPosition = Screen.CursorPosition;
            if (len < 1)
            {
                len = 1;
            }
            if (cursorPosition.X < 0 || cursorPosition.X >= Constants.ConsoleWidth)
            {
                cursorPosition = new GridCoordinate(0, cursorPosition.Y);
            }
            if (cursorPosition.X + len > Constants.ConsoleWidth)
            {
                len = Constants.ConsoleWidth - cursorPosition.X;
            }
            Screen.Erase(cursorPosition.Y, cursorPosition.X, len);
            Screen.Print(Colour.Grey, buf, cursorPosition.Y, cursorPosition.X);
            while (!done && !Shutdown)
            {
                Screen.Goto(cursorPosition.Y, cursorPosition.X + k);
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
                Screen.Erase(cursorPosition.Y, cursorPosition.X, len);
                Screen.Print(Colour.Black, buf, cursorPosition.Y, cursorPosition.X);
            }
            return i != '\x1b';
        }

        public bool GetCheck(string prompt)
        {
            int i = 0;
            MsgPrint(null);
            string buf = $"{prompt}[Y/n]";
            Screen.PrintLine(buf, 0, 0);
            while (true && !Shutdown)
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
            Screen.PrintLine("", 0, 0);
            return i == 'Y' || i == 'y' || i == 13;
        }

        public bool GetCom(string prompt, out char command)
        {
            MsgPrint(null);
            if (prompt.Length > 1)
            {
                prompt = char.ToUpper(prompt[0]) + prompt.Substring(1);
            }
            Screen.PrintLine(prompt, 0, 0);
            command = Inkey();
            Screen.PrintLine("", 0, 0);
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
            Screen.PrintLine(prompt, 0, 0);
            bool res = AskforAux(out buf, initial, len);
            Screen.PrintLine("", 0, 0);
            return res;
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
            bool v = Screen.CursorVisible;
            if (!DoNotWaitOnInkey && (!HideCursorOnFullScreenInkey || FullScreenOverlay))
            {
                Screen.CursorVisible = true;
            }
            if (InPopupMenu)
            {
                Screen.CursorVisible = false;
            }
            while (ch == 0 && !Shutdown)
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
            Screen.CursorVisible = v;
            HideCursorOnFullScreenInkey = false;
            DoNotWaitOnInkey = false;
            return ch;
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
        /// Plays a sound
        /// </summary>
        /// <param name="val"> The sound to play </param>
        public void PlaySound(SoundEffect sound)
        {
        //    _console.PlaySound(sound);
        }

        /// <summary>
        /// Update the screen using a double buffer, drawing all queued print and erase requests.
        /// </summary>
        public void UpdateScreen()
        {
            Screen.UpdateScreen(_console);
        }

        public void PlayMusic(MusicTrack musicTrack)
        {
        //    _console.PlayMusic(musicTrack);
        }

        public void RequestCommand(bool shopping)
        {
            const int mode = Constants.KeymapModeOrig;
            CurrentCommand = (char)0;
            CommandArgument = 0;
            CommandDirection = 0;
            while (true && !Shutdown)
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
                Screen.PrintLine("", 0, 0);
                if (cmd == '0')
                {
                    int oldArg = CommandArgument;
                    CommandArgument = 0;
                    Screen.PrintLine("Count: ", 0, 0);
                    while (true && !Shutdown)
                    {
                        cmd = Inkey();
                        if (cmd == 0x7F || cmd == 0x08)
                        {
                            CommandArgument /= 10;
                            Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
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
                            Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (CommandArgument == 0)
                    {
                        CommandArgument = 99;
                        Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
                    }
                    if (oldArg != 0)
                    {
                        CommandArgument = oldArg;
                        Screen.PrintLine($"Count: {CommandArgument}", 0, 0);
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
            Screen.PrintLine("", 0, 0);
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
                while (KeyHead == KeyTail && !Shutdown)
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

        ////////////////// PLAYER FACTORY
        private readonly string[] _menuItem = new string[32];

        private readonly Gender[] _sexInfo = { new Gender("Female", "Queen"), new Gender("Male", "King"), new Gender("Other", "Monarch") };
        private int _menuLength;

        /// <summary>
        /// Represents the previous character class.
        /// </summary>
        private BaseCharacterClass _prevCharacterClass;

        private int _prevGeneration;
        private string _prevName;

        /// <summary>
        /// Returns the race of the previous character.  Used as a default during the birthing process.  Set to HumanRace if there is no previous character.  Returns
        /// null, before the birthing process is started.
        /// </summary>
        private Race? _prevRace = null;

        private Realm? _prevRealm1 => _prevPrimaryRealm?.ID;
        private BaseRealm? _prevPrimaryRealm;
        private Realm? _prevRealm2 => _prevSecondaryRealm?.ID;
        private BaseRealm? _prevSecondaryRealm;
        private int _prevSex;

        public bool CharacterGeneration(ExPlayer ex)
        {
            SetBackground(BackgroundImage.Paper);
            PlayMusic(MusicTrack.Chargen);
            Player = new Player(this);
            if (PlayerBirth(ex))
            {
                return true;
            }
            return false;
        }

        private void DisplayAPlusB(int x, int y, int initial, int bonus)
        {
            string buf = $"{initial:00}% + {bonus / 10}.{bonus % 10}%/lv";
            Screen.Print(Colour.Black, buf, y, x);
        }

        private void DisplayClassInfo(BaseCharacterClass characterClass)
        {
            Screen.Print(Colour.Purple, "STR:", 36, 21);
            Screen.Print(Colour.Purple, "INT:", 37, 21);
            Screen.Print(Colour.Purple, "WIS:", 38, 21);
            Screen.Print(Colour.Purple, "DEX:", 39, 21);
            Screen.Print(Colour.Purple, "CON:", 40, 21);
            Screen.Print(Colour.Purple, "CHA:", 41, 21);
            for (int i = 0; i < 6; i++)
            {
                int bonus = characterClass.AbilityBonus[i];
                DisplayStatBonus(26, 36 + i, bonus);
            }
            Screen.Print(Colour.Purple, "Disarming   :", 36, 53);
            Screen.Print(Colour.Purple, "Magic Device:", 37, 53);
            Screen.Print(Colour.Purple, "Saving Throw:", 38, 53);
            Screen.Print(Colour.Purple, "Stealth     :", 39, 53);
            Screen.Print(Colour.Purple, "Fighting    :", 40, 53);
            Screen.Print(Colour.Purple, "Shooting    :", 41, 53);
            Screen.Print(Colour.Purple, "Experience  :", 36, 31);
            Screen.Print(Colour.Purple, "Hit Dice    :", 37, 31);
            Screen.Print(Colour.Purple, "Infravision :", 38, 31);
            Screen.Print(Colour.Purple, "Searching   :", 39, 31);
            Screen.Print(Colour.Purple, "Perception  :", 40, 31);
            DisplayAPlusB(67, 36, characterClass.BaseDisarmBonus, characterClass.DisarmBonusPerLevel);
            DisplayAPlusB(67, 37, characterClass.BaseDeviceBonus, characterClass.DeviceBonusPerLevel);
            DisplayAPlusB(67, 38, characterClass.BaseSaveBonus, characterClass.SaveBonusPerLevel);
            DisplayAPlusB(67, 39, characterClass.BaseStealthBonus * 4, characterClass.StealthBonusPerLevel * 4);
            DisplayAPlusB(67, 40, characterClass.BaseMeleeAttackBonus, characterClass.MeleeAttackBonusPerLevel);
            DisplayAPlusB(67, 41, characterClass.BaseRangedAttackBonus, characterClass.RangedAttackBonusPerLevel);
            string buf = "+" + characterClass.ExperienceFactor + "%";
            Screen.Print(Colour.Black, buf, 36, 45);
            buf = "1d" + characterClass.HitDieBonus;
            Screen.Print(Colour.Black, buf, 37, 45);
            Screen.Print(Colour.Black, "-", 38, 45);
            buf = $"{characterClass.BaseSearchBonus:00}%";
            Screen.Print(Colour.Black, buf, 39, 45);
            buf = $"{characterClass.BaseSearchFrequency:00}%";
            Screen.Print(Colour.Black, buf, 40, 45);

            int y = 30;
            foreach (string classInfo in characterClass.Info)
            {
                Screen.Print(Colour.Purple, classInfo, y, 20);
                y++;
            }
        }

        private void DisplayPartialCharacter(int stage)
        {
            int i;
            string str;
            const string spaces = "                 ";
            Screen.Clear(0);
            Screen.Print(Colour.Blue, "Name        :", 2, 1);
            Screen.Print(Colour.Brown, stage == 0 ? _prevName : spaces, 2, 15);
            Screen.Print(Colour.Blue, "Gender      :", 3, 1);
            if (stage == 0)
            {
                Player.Gender = _sexInfo[_prevSex];
                str = Player.Gender.Title;
            }
            else if (stage < 6)
            {
                str = spaces;
            }
            else
            {
                Player.Gender = _sexInfo[Player.GenderIndex];
                str = Player.Gender.Title;
            }
            Screen.Print(Colour.Brown, str, 3, 15);
            Screen.Print(Colour.Blue, "Race        :", 4, 1);
            if (stage == 0)
            {
                Player.Race = _prevRace;
                str = Player.Race.Title;
            }
            else if (stage < 3)
            {
                str = spaces;
            }
            else
            {
                str = Player.Race.Title;
            }
            Screen.Print(Colour.Brown, str, 4, 15);
            Screen.Print(Colour.Blue, "Class       :", 5, 1);
            if (stage == 0)
            {
                Player.BaseCharacterClass = SingletonRepository.CharacterClasses.Single(_characterClass => _characterClass.ID == _prevCharacterClass.ID);
                str = Player.BaseCharacterClass.Title;
            }
            else if (stage < 2)
            {
                str = spaces;
            }
            else
            {
                Player.BaseCharacterClass = SingletonRepository.CharacterClasses.Single(_characterClass => _characterClass.ID == Player.BaseCharacterClass.ID);
                str = Player.BaseCharacterClass.Title;
            }
            Screen.Print(Colour.Brown, str, 5, 15);
            if (stage == 0)
            {
                if (_prevPrimaryRealm != null || _prevSecondaryRealm != null)
                {
                    Screen.Print(Colour.Blue, "Magic       :", 6, 1);
                }
                if (_prevPrimaryRealm != null)
                {
                    Screen.Print(Colour.Brown, RealmNames(_prevPrimaryRealm, _prevSecondaryRealm), 6, 15);
                }
            }
            else if (stage < 4)
            {
                str = spaces;
                Screen.Print(Colour.Blue, str, 6, 0);
                Screen.Print(Colour.Brown, str, 6, 15);
            }
            else
            {
                if (Player.Realm1 != null || Player.Realm2 != null)
                {
                    Screen.Print(Colour.Blue, "Magic       :", 6, 1);
                }
                if (Player.Realm1 != null)
                {
                    Screen.Print(Colour.Brown, RealmNames(Player.PrimaryRealm, Player.SecondaryRealm), 6, 15);
                }
            }
            Screen.Print(Colour.Blue, "Birthday", 2, 32);
            Screen.Print(Colour.Blue, "Age          ", 3, 32);
            Screen.Print(Colour.Blue, "Height       ", 4, 32);
            Screen.Print(Colour.Blue, "Weight       ", 5, 32);
            Screen.Print(Colour.Blue, "Social Class ", 6, 32);
            Screen.Print(Colour.Blue, "STR:", 2 + Ability.Strength, 61);
            Screen.Print(Colour.Blue, "INT:", 2 + Ability.Intelligence, 61);
            Screen.Print(Colour.Blue, "WIS:", 2 + Ability.Wisdom, 61);
            Screen.Print(Colour.Blue, "DEX:", 2 + Ability.Dexterity, 61);
            Screen.Print(Colour.Blue, "CON:", 2 + Ability.Constitution, 61);
            Screen.Print(Colour.Blue, "CHA:", 2 + Ability.Charisma, 61);
            Screen.Print(Colour.Blue, "STR:", 14 + Ability.Strength, 1);
            Screen.Print(Colour.Blue, "INT:", 14 + Ability.Intelligence, 1);
            Screen.Print(Colour.Blue, "WIS:", 14 + Ability.Wisdom, 1);
            Screen.Print(Colour.Blue, "DEX:", 14 + Ability.Dexterity, 1);
            Screen.Print(Colour.Blue, "CON:", 14 + Ability.Constitution, 1);
            Screen.Print(Colour.Blue, "CHA:", 14 + Ability.Charisma, 1);
            Screen.Print(Colour.Blue, "STR:", 22 + Ability.Strength, 1);
            Screen.Print(Colour.Blue, "INT:", 22 + Ability.Intelligence, 1);
            Screen.Print(Colour.Blue, "WIS:", 22 + Ability.Wisdom, 1);
            Screen.Print(Colour.Blue, "DEX:", 22 + Ability.Dexterity, 1);
            Screen.Print(Colour.Blue, "CON:", 22 + Ability.Constitution, 1);
            Screen.Print(Colour.Blue, "CHA:", 22 + Ability.Charisma, 1);
            Screen.Print(Colour.Purple, "Initial", 21, 6);
            Screen.Print(Colour.Brown, "Race Class Mods", 21, 14);
            Screen.Print(Colour.Green, "Actual", 21, 30);
            Screen.Print(Colour.Red, "Reduced", 21, 37);
            Screen.Print(Colour.Blue, "abcdefghijklm@", 21, 45);
            Screen.Print(Colour.Grey, "..............", 22, 45);
            Screen.Print(Colour.Grey, "..............", 23, 45);
            Screen.Print(Colour.Grey, "..............", 24, 45);
            Screen.Print(Colour.Grey, "..............", 25, 45);
            Screen.Print(Colour.Grey, "..............", 26, 45);
            Screen.Print(Colour.Grey, "..............", 27, 45);
            Screen.Print(Colour.Blue, "Modifications", 28, 45);

            if (stage < 2)
            {
                for (i = 0; i < 6; i++)
                {
                    Screen.Print(Colour.Brown, "   ", 22 + i, 20);
                }
            }
            else
            {
                for (i = 0; i < 6; i++)
                {
                    string buf = Player.BaseCharacterClass.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3);
                    Screen.Print(Colour.Brown, buf, 22 + i, 20);
                }
            }
            if (stage < 3)
            {
                for (i = 0; i < 6; i++)
                {
                    Screen.Print(Colour.Brown, "   ", 22 + i, 14);
                }
            }
            else
            {
                for (i = 0; i < 6; i++)
                {
                    string buf = (Player.Race.AbilityBonus[i]).ToString("+0;-0;+0").PadLeft(3);
                    Screen.Print(Colour.Brown, buf, 22 + i, 14);
                }
            }
        }

        private void DisplayRaceInfo(Race race)
        {
            Screen.Print(Colour.Purple, "STR:", 36, 21);
            Screen.Print(Colour.Purple, "INT:", 37, 21);
            Screen.Print(Colour.Purple, "WIS:", 38, 21);
            Screen.Print(Colour.Purple, "DEX:", 39, 21);
            Screen.Print(Colour.Purple, "CON:", 40, 21);
            Screen.Print(Colour.Purple, "CHA:", 41, 21);
            for (int i = 0; i < 6; i++)
            {
                int bonus = race.AbilityBonus[i] + Player.BaseCharacterClass.AbilityBonus[i];
                DisplayStatBonus(26, 36 + i, bonus);
            }
            Screen.Print(Colour.Purple, "Disarming   :", 36, 53);
            Screen.Print(Colour.Purple, "Magic Device:", 37, 53);
            Screen.Print(Colour.Purple, "Saving Throw:", 38, 53);
            Screen.Print(Colour.Purple, "Stealth     :", 39, 53);
            Screen.Print(Colour.Purple, "Fighting    :", 40, 53);
            Screen.Print(Colour.Purple, "Shooting    :", 41, 53);
            Screen.Print(Colour.Purple, "Experience  :", 36, 31);
            Screen.Print(Colour.Purple, "Hit Dice    :", 37, 31);
            Screen.Print(Colour.Purple, "Infravision :", 38, 31);
            Screen.Print(Colour.Purple, "Searching   :", 39, 31);
            Screen.Print(Colour.Purple, "Perception  :", 40, 31);
            DisplayAPlusB(67, 36, Player.BaseCharacterClass.BaseDisarmBonus + race.BaseDisarmBonus, Player.BaseCharacterClass.DisarmBonusPerLevel);
            DisplayAPlusB(67, 37, Player.BaseCharacterClass.BaseDeviceBonus + race.BaseDeviceBonus, Player.BaseCharacterClass.DeviceBonusPerLevel);
            DisplayAPlusB(67, 38, Player.BaseCharacterClass.BaseSaveBonus + race.BaseSaveBonus, Player.BaseCharacterClass.SaveBonusPerLevel);
            DisplayAPlusB(67, 39, (Player.BaseCharacterClass.BaseStealthBonus * 4) + (race.BaseStealthBonus * 4), Player.BaseCharacterClass.StealthBonusPerLevel * 4);
            DisplayAPlusB(67, 40, Player.BaseCharacterClass.BaseMeleeAttackBonus + race.BaseMeleeAttackBonus, Player.BaseCharacterClass.MeleeAttackBonusPerLevel);
            DisplayAPlusB(67, 41, Player.BaseCharacterClass.BaseRangedAttackBonus + race.BaseRangedAttackBonus, Player.BaseCharacterClass.RangedAttackBonusPerLevel);
            Screen.Print(Colour.Black, race.ExperienceFactor + Player.BaseCharacterClass.ExperienceFactor + "%", 36, 45);
            Screen.Print(Colour.Black, "1d" + (race.HitDieBonus + Player.BaseCharacterClass.HitDieBonus), 37, 45);
            if (race.Infravision == 0)
            {
                Screen.Print(Colour.Black, "nil", 38, 45);
            }
            else
            {
                Screen.Print(Colour.Green, race.Infravision + "0 feet", 38, 45);
            }
            Screen.Print(Colour.Black, $"{race.BaseSearchBonus + Player.BaseCharacterClass.BaseSearchBonus:00}%", 39, 45);
            Screen.Print(Colour.Black, $"{race.BaseSearchFrequency + Player.BaseCharacterClass.BaseSearchFrequency:00}%", 40, 45);

            // Retrieve the description for the race and split the description into lines.
            string[] description = race.Description.Split("\n");

            // Render the description, center justified into row 32.
            int descriptionRow = 32 - (int)Math.Floor((double)description.Length / 2);
            foreach (string descriptionLine in description)
            {
                Screen.Print(Colour.Purple, descriptionLine, descriptionRow++, 21);
            }
        }

        private void DisplayRealmInfo(BaseRealm prealm)
        {
            int y = 30;
            foreach (string info in prealm.Info)
            {
                Screen.Print(Colour.Purple, info, y, 20);
                y++;
            }
        }

        private void DisplayStatBonus(int x, int y, int bonus)
        {
            string buf;
            if (bonus == 0)
            {
                Screen.Print(Colour.Black, "+0", y, x);
            }
            else if (bonus < 0)
            {
                buf = bonus.ToString();
                Screen.Print(Colour.BrightRed, buf, y, x);
            }
            else
            {
                buf = "+" + bonus;
                Screen.Print(Colour.Green, buf, y, x);
            }
        }

        private void GetAhw()
        {
            Player.Age = Player.Race.BaseAge + Program.Rng.DieRoll(Player.Race.AgeRange);
            bool startAtDusk = Player.Race.RestsTillDuskInsteadOfDawn;
            Player.GameTime = new GameTime(this, Program.Rng.DieRoll(365), startAtDusk);

            if (Player.GenderIndex == Constants.SexMale)
            {
                Player.Height = Program.Rng.RandomNormal(Player.Race.MaleBaseHeight, Player.Race.MaleHeightRange);
                Player.Weight = Program.Rng.RandomNormal(Player.Race.MaleBaseWeight, Player.Race.MaleWeightRange);
            }
            else if (Player.GenderIndex == Constants.SexFemale)
            {
                Player.Height = Program.Rng.RandomNormal(Player.Race.FemaleBaseHeight, Player.Race.FemaleHeightRange);
                Player.Weight = Program.Rng.RandomNormal(Player.Race.FemaleBaseWeight, Player.Race.FemaleWeightRange);
            }
            else
            {
                if (Program.Rng.DieRoll(2) == 1)
                {
                    Player.Height = Program.Rng.RandomNormal(Player.Race.MaleBaseHeight, Player.Race.MaleHeightRange);
                    Player.Weight = Program.Rng.RandomNormal(Player.Race.MaleBaseWeight, Player.Race.MaleWeightRange);
                }
                else
                {
                    Player.Height = Program.Rng.RandomNormal(Player.Race.FemaleBaseHeight, Player.Race.FemaleHeightRange);
                    Player.Weight = Program.Rng.RandomNormal(Player.Race.FemaleBaseWeight, Player.Race.FemaleWeightRange);
                }
            }
        }

        private void GetExtra()
        {
            int i;
            Player.MaxLevelGained = 1;
            Player.Level = 1;
            Player.ExperienceMultiplier = Player.Race.ExperienceFactor + Player.BaseCharacterClass.ExperienceFactor;
            Player.HitDie = Player.Race.HitDieBonus + Player.BaseCharacterClass.HitDieBonus;
            Player.MaxHealth = Player.HitDie;
            Player.PlayerHp[0] = Player.HitDie;
            int lastroll = Player.HitDie;
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                Player.PlayerHp[i] = lastroll;
                lastroll--;
                if (lastroll < 1)
                {
                    lastroll = Player.HitDie;
                }
            }
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                int j = Program.Rng.DieRoll(Constants.PyMaxLevel - 1);
                lastroll = Player.PlayerHp[i];
                Player.PlayerHp[i] = Player.PlayerHp[j];
                Player.PlayerHp[j] = lastroll;
            }
            for (i = 1; i < Constants.PyMaxLevel; i++)
            {
                Player.PlayerHp[i] = Player.PlayerHp[i - 1] + Player.PlayerHp[i];
            }
        }

        private void GetMoney()
        {
            int gold = (Player.SocialClass * 6) + Program.Rng.DieRoll(100) + 300;
            for (int i = 0; i < 6; i++)
            {
                if (Player.AbilityScores[i].Adjusted >= 18 + 50)
                {
                    gold -= 300;
                }
                else if (Player.AbilityScores[i].Adjusted >= 18 + 20)
                {
                    gold -= 200;
                }
                else if (Player.AbilityScores[i].Adjusted > 18)
                {
                    gold -= 150;
                }
                else
                {
                    gold -= (Player.AbilityScores[i].Adjusted - 8) * 10;
                }
            }
            if (gold < 100)
            {
                gold = 100;
            }
            Player.Gold = gold;
        }

        private void GetRealmsRandomly()
        {
            Player.PrimaryRealm = new WeightedRandom<BaseRealm>(Player.BaseCharacterClass.AvailablePrimaryRealms).Choose();
            Player.SecondaryRealm = new WeightedRandom<BaseRealm>(Player.BaseCharacterClass.AvailableSecondaryRealms).Choose();
            if (!Player.BaseCharacterClass.WorshipsADeity)
            {
                return;
            }
            if (Player.BaseCharacterClass.ID == CharacterClass.Priest)
            {
                switch (Player.Realm2)
                {
                    case Realm.Nature:
                        Player.Religion.Deity = GodName.Hagarg_Ryonis;
                        break;

                    case Realm.Folk:
                        Player.Religion.Deity = GodName.Zo_Kalar;
                        break;

                    case Realm.Chaos:
                        Player.Religion.Deity = GodName.Nath_Horthah;
                        break;

                    case Realm.Corporeal:
                        Player.Religion.Deity = GodName.Lobon;
                        break;

                    case Realm.Tarot:
                        Player.Religion.Deity = GodName.Tamash;
                        break;

                    default:
                        Player.Religion.Deity = GodName.None;
                        break;
                }
            }
            else
            {
                Player.Religion.Deity = GodName.None;
            }
        }

        private void GetStats()
        {
            int i, j;
            while (true)
            {
                List<int> dice = new List<int>() { 17, 16, 14, 12, 11, 10 };
                for (i = 0; i < 6; i++)
                {
                    int index = Program.Rng.DieRoll(dice.Count) - 1;
                    j = dice[index];
                    dice.RemoveAt(index);
                    Player.AbilityScores[i].InnateMax = j;
                    int bonus = Player.Race.AbilityBonus[i] + Player.BaseCharacterClass.AbilityBonus[i];
                    Player.AbilityScores[i].Innate = Player.AbilityScores[i].InnateMax;
                    Player.AbilityScores[i].Adjusted = Player.AbilityScores[i].ModifyStatValue(Player.AbilityScores[i].InnateMax, bonus);
                }
                if (Player.AbilityScores[Player.BaseCharacterClass.PrimeStat].InnateMax > 13)
                {
                    break;
                }
            }
        }

        private void MenuDisplay(int current)
        {
            Screen.Clear(30);
            Screen.Print(Colour.Orange, "=>", 35, 0);
            for (int i = 0; i < _menuLength; i++)
            {
                int row = 35 + i - current;
                if (row >= 30 && row <= 40)
                {
                    Colour a = Colour.Purple;
                    if (i == current)
                    {
                        a = Colour.Pink;
                    }
                    Screen.Print(a, _menuItem[i], row, 2);
                }
            }
        }

        private bool PlayerBirth(ExPlayer ex)
        {
            if (ex == null)
            {
                _prevSex = Constants.SexFemale;
                _prevRace = SingletonRepository.Races.Get<HumanRace>();
                _prevCharacterClass = SingletonRepository.CharacterClasses.Get<WarriorCharacterClass>();
                _prevPrimaryRealm = null;
                _prevSecondaryRealm = null;
                _prevName = "Xena";
                _prevGeneration = 0;
            }
            else
            {
                _prevSex = ex.GenderIndex;
                _prevRace = ex.RaceAtBirth;
                _prevCharacterClass = SingletonRepository.CharacterClasses.Get(ex.CharacterClassName);
                _prevPrimaryRealm = ex.PrimaryRealm;
                _prevSecondaryRealm = ex.SecondaryRealm;
                _prevName = ex.Name;
                _prevGeneration = ex.Generation;
            }
            if (!PlayerBirthAux())
            {
                return false;
            }
            Player.RaceAtBirth = Player.Race;
            Quests.PlayerBirthQuests();
            MessageAdd(" ");
            MessageAdd("  ");
            MessageAdd("====================");
            MessageAdd("  ");
            MessageAdd(" ");
            Player.IsDead = false;
            PlayerOutfit();
            return true;
        }

        private bool PlayerBirthAux()
        {
            MenuItem<BaseCharacterClass>[] _classMenu = SingletonRepository.CharacterClasses
                .OrderBy(_characterClass => _characterClass.Title)
                .Select(_characterClass => new MenuItem<BaseCharacterClass>(_characterClass.Title, _characterClass))
                .ToArray();

            int i;
            int stage = 0;
            int[] menu = new int[9];
            bool[] autoChose = new bool[8];
            Realm[] realmChoice = new Realm[8];
            for (i = 0; i < 8; i++)
            {
                menu[i] = 0;
            }
            menu[BirthStage.ClassSelection] = 14;
            menu[BirthStage.RaceSelection] = 16;
            Screen.Clear();
            int viewMode = 1;
            while (true && !Shutdown)
            {
                char c;
                switch (stage)
                {
                    case BirthStage.Introduction:
                        Player.Religion.Deity = GodName.None;
                        for (i = 0; i < 8; i++)
                        {
                            autoChose[i] = false;
                        }
                        _menuItem[0] = "Choose";
                        _menuItem[1] = "Random";
                        _menuItem[2] = "Re-use";
                        _menuLength = 3;
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        switch (menu[stage])
                        {
                            case 0:
                                Screen.Print(Colour.Purple, "Choose your character's race, sex, and class; and select", 35, 20);
                                Screen.Print(Colour.Purple, "which realms of magic your character will use.", 36, 20);
                                break;

                            case 1:
                                Screen.Print(Colour.Purple, "Let the game generate a character for you randomly.", 35, 20);
                                break;

                            case 2:
                                Screen.Print(Colour.Purple, "Re-play with a character similar to the one you played", 35, 20);
                                Screen.Print(Colour.Purple, "last time.", 36, 20);
                                break;
                        }
                        Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true & !Shutdown)
                        {
                            c = Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                return false;
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        break;

                    case BirthStage.ClassSelection:
                        Player.Religion.Deity = GodName.None;
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            Player.BaseCharacterClass = _prevCharacterClass;
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            Player.BaseCharacterClass = SingletonRepository.CharacterClasses.WeightedRandom().Choose();
                            stage++;
                            break;
                        }
                        autoChose[stage] = false;
                        _menuLength = Constants.MaxClass;
                        for (i = 0; i < Constants.MaxClass; i++)
                        {
                            _menuItem[i] = _classMenu[i].Text;
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayClassInfo(_classMenu[menu[stage]].Item);
                        Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true && !Shutdown)
                        {
                            c = Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        if (stage > BirthStage.ClassSelection)
                        {
                            Player.BaseCharacterClass = _classMenu[menu[BirthStage.ClassSelection]].Item;
                        }
                        break;

                    case BirthStage.RaceSelection:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            Player.Race = _prevRace;
                            Player.GetFirstLevelMutation = Player.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            do
                            {
                                int raceIndex = Program.Rng.RandomLessThan(SingletonRepository.Races.Count);
                                Player.Race = SingletonRepository.Races[raceIndex];
                                Player.GetFirstLevelMutation = Player.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
                            }
                            while ((Player.Race.Choice & (1L << Player.BaseCharacterClass.ID)) == 0);
                            stage++;
                            break;
                        }
                        autoChose[stage] = false;
                        _menuLength = SingletonRepository.Races.Count;

                        // Create the menu for the races.
                        MenuItem<Race>[] _raceMenu = SingletonRepository.Races.OrderBy((Race race) => race.Title).Select((Race race) => new MenuItem<Race>(race.Title, race)).ToArray();

                        for (i = 0; i < SingletonRepository.Races.Count; i++)
                        {
                            _menuItem[i] = _raceMenu[i].Text;
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);

                        DisplayRaceInfo(_raceMenu[menu[stage]].Item);
                        Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true && !Shutdown)
                        {
                            c = Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        if (stage > BirthStage.RaceSelection)
                        {
                            Player.Race = _raceMenu[menu[BirthStage.RaceSelection]].Item;
                            Player.GetFirstLevelMutation = Player.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
                        }
                        break;

                    case BirthStage.RealmSelection1:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            Player.PrimaryRealm = _prevPrimaryRealm;
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            GetRealmsRandomly();
                            stage++;
                            break;
                        }
                        if (Player.BaseCharacterClass.AvailablePrimaryRealms.Length == 0) 
                        {
                            autoChose[stage] = true;
                            Player.PrimaryRealm = null;
                            stage++;
                            break;
                        }
                        else if (Player.BaseCharacterClass.AvailablePrimaryRealms.Length == 1)
                        {
                            autoChose[stage] = true;
                            Player.PrimaryRealm = Player.BaseCharacterClass.AvailablePrimaryRealms[0];
                            stage++;
                            break;
                        }
                        else
                        {
                            _menuLength = 0;
                            foreach (BaseRealm realm in Player.BaseCharacterClass.AvailablePrimaryRealms)
                            {
                                realmChoice[_menuLength] = realm.ID;
                                _menuLength++;
                            }
                        }
                        autoChose[stage] = false;
                        for (i = 0; i < _menuLength; i++)
                        {
                            _menuItem[i] = SingletonRepository.Realms.Single(_realm => _realm.ID == realmChoice[i]).Name;
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayRealmInfo(SingletonRepository.Realms.Single(_realm => _realm.ID == realmChoice[menu[stage]]));
                        Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true && !Shutdown)
                        {
                            c = Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        if (stage > BirthStage.RealmSelection1)
                        {
                            Player.PrimaryRealm = SingletonRepository.Realms.Single(_realm => _realm.ID == realmChoice[menu[BirthStage.RealmSelection1]]);
                        }
                        break;

                    case BirthStage.RealmSelection2:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            Player.SecondaryRealm = _prevSecondaryRealm;
                            if (Player.BaseCharacterClass.ID == CharacterClass.Priest)
                            {
                                switch (Player.Realm2)
                                {
                                    case Realm.Nature:
                                        Player.Religion.Deity = GodName.Hagarg_Ryonis;
                                        break;

                                    case Realm.Folk:
                                        Player.Religion.Deity = GodName.Zo_Kalar;
                                        break;

                                    case Realm.Chaos:
                                        Player.Religion.Deity = GodName.Nath_Horthah;
                                        break;

                                    case Realm.Corporeal:
                                        Player.Religion.Deity = GodName.Lobon;
                                        break;

                                    case Realm.Tarot:
                                        Player.Religion.Deity = GodName.Tamash;
                                        break;

                                    default:
                                        Player.Religion.Deity = GodName.None;
                                        break;
                                }
                            }
                            else
                            {
                                Player.Religion.Deity = GodName.None;
                            }
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            stage++;
                            break;
                        }
                        Player.SecondaryRealm = null;
                        if (Player.BaseCharacterClass.AvailableSecondaryRealms.Length == 0)
                        {
                            autoChose[stage] = true;
                            Player.SecondaryRealm = null;
                            stage++;
                            break;
                        }
                        else if (Player.BaseCharacterClass.AvailableSecondaryRealms.Length == 1)
                        {
                            autoChose[stage] = true;
                            Player.SecondaryRealm = Player.BaseCharacterClass.AvailableSecondaryRealms[0];
                            stage++;
                            break;
                        }
                        else
                        {
                            _menuLength = 0;
                            BaseRealm[] remainingRealms = Player.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm.ID != Player.Realm1).ToArray();
                            foreach (BaseRealm realm in remainingRealms)
                            {
                                realmChoice[_menuLength] = realm.ID;
                                _menuLength++;
                            }
                        }
                        autoChose[stage] = false;
                        for (i = 0; i < _menuLength; i++)
                        {
                            _menuItem[i] = SingletonRepository.Realms.Single(_realm => _realm.ID == realmChoice[i]).Name;
                        }
                        DisplayPartialCharacter(stage);
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        DisplayRealmInfo(SingletonRepository.Realms.Single(_realm => _realm.ID == realmChoice[menu[stage]]));
                        Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true && !Shutdown)
                        {
                            c = Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        if (stage > BirthStage.RealmSelection2)
                        {
                            Player.SecondaryRealm = SingletonRepository.Realms.Single(_realm => _realm.ID == realmChoice[menu[BirthStage.RealmSelection2]]);
                            if (Player.BaseCharacterClass.ID == CharacterClass.Priest)
                            {
                                switch (Player.Realm2)
                                {
                                    case Realm.Nature:
                                        Player.Religion.Deity = GodName.Hagarg_Ryonis;
                                        break;

                                    case Realm.Folk:
                                        Player.Religion.Deity = GodName.Zo_Kalar;
                                        break;

                                    case Realm.Chaos:
                                        Player.Religion.Deity = GodName.Nath_Horthah;
                                        break;

                                    case Realm.Corporeal:
                                        Player.Religion.Deity = GodName.Lobon;
                                        break;

                                    case Realm.Tarot:
                                        Player.Religion.Deity = GodName.Tamash;
                                        break;

                                    default:
                                        Player.Religion.Deity = GodName.None;
                                        break;
                                }
                            }
                            else
                            {
                                Player.Religion.Deity = GodName.None;
                            }
                        }
                        break;

                    case BirthStage.GenderSelection:
                        if (menu[0] == Constants.GenerateReplay)
                        {
                            autoChose[stage] = true;
                            Player.GenderIndex = _prevSex;
                            Player.Gender = _sexInfo[Player.GenderIndex];
                            stage++;
                            break;
                        }
                        if (menu[0] == Constants.GenerateRandom)
                        {
                            autoChose[stage] = true;
                            Player.GenderIndex = Program.Rng.RandomBetween(0, 1);
                            Player.Gender = _sexInfo[Player.GenderIndex];
                            stage++;
                            break;
                        }
                        _menuLength = Constants.MaxGenders;
                        for (i = 0; i < Constants.MaxGenders; i++)
                        {
                            _menuItem[i] = _sexInfo[i].Title;
                        }
                        DisplayPartialCharacter(stage);
                        autoChose[stage] = false;
                        if (menu[stage] >= _menuLength)
                        {
                            menu[stage] = 0;
                        }
                        MenuDisplay(menu[stage]);
                        Screen.Print(Colour.Purple, "Your sex has no effect on gameplay.", 35, 21);
                        Screen.Print(Colour.Orange,
                            "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
                        while (true && !Shutdown)
                        {
                            c = Inkey();
                            if (c == '8')
                            {
                                if (menu[stage] > 0)
                                {
                                    menu[stage]--;
                                    break;
                                }
                            }
                            if (c == '2')
                            {
                                if (menu[stage] < _menuLength - 1)
                                {
                                    menu[stage]++;
                                    break;
                                }
                            }
                            if (c == '6')
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        if (stage > BirthStage.GenderSelection)
                        {
                            Player.GenderIndex = menu[BirthStage.GenderSelection];
                            Player.Gender = _sexInfo[Player.GenderIndex];
                        }
                        break;

                    case BirthStage.Confirmation:
                        if (menu[0] != Constants.GenerateReplay)
                        {
                            Player.Name = Player.Race.CreateRandomName();
                            Player.Generation = 1;
                        }
                        else
                        {
                            Player.Name = string.IsNullOrEmpty(_prevName) ? Player.Race.CreateRandomName() : _prevName;
                            Player.Generation = _prevGeneration + 1;
                        }
                        GetStats();
                        GetExtra();
                        GetAhw();
                        GetHistory(Player);
                        GetMoney();

                        Spells[0] = new SpellList(Player.Realm1, Player.BaseCharacterClass.ID);
                        Spells[1] = new SpellList(Player.Realm2, Player.BaseCharacterClass.ID);
                        Talents = new TalentList(Player.BaseCharacterClass.ID);
                        SpellFirst = 100;
                        foreach (SpellList bookset in Spells)
                        {
                            foreach (Spell spell in bookset)
                            {
                                if (spell.Level < SpellFirst)
                                {
                                    SpellFirst = spell.Level;
                                }
                            }
                        }
                        for (int ii = 0; ii < 64; ii++)
                        {
                            SpellOrder[ii] = 99;
                        }

                        Player.GooPatron = PatronList[Program.Rng.DieRoll(PatronList.Length) - 1];
                        UpdateHealthFlaggedAction.Set();
                        UpdateBonusesFlaggedAction.Set();
                        UpdateStuff();
                        Player.Health = Player.MaxHealth;
                        Player.Mana = Player.MaxMana;
                        Player.Energy = 150;
                        CharacterViewer characterViewer = new CharacterViewer(this);
                        while (true && !Shutdown)
                        {
                            characterViewer.DisplayPlayer();
                            Screen.Print(Colour.Orange,
                                "[Use return to confirm, or left to go back.]", 43, 1);
                            c = Inkey();
                            if (c == 13)
                            {
                                stage++;
                                break;
                            }
                            if (c == '4')
                            {
                                do
                                {
                                    stage--;
                                }
                                while (autoChose[stage]);
                                break;
                            }
                            if (c == '8')
                            {
                                viewMode++;
                                if (viewMode > 1)
                                {
                                    viewMode = 0;
                                }
                            }
                            if (c == '2')
                            {
                                viewMode--;
                                if (viewMode < 0)
                                {
                                    viewMode = 1;
                                }
                            }
                            if (c == 'h')
                            {
                                ShowManual();
                            }
                        }
                        break;

                    case BirthStage.Naming:
                        Player.InputPlayerName();
                        return true;
                }
            }
            return false;
        }

        private void PlayerOutfit()
        {
            Item item = new Item(this);

            if (Player.Race.OutfitsWithScrollsOfSatisfyHunger)
            {
                item.AssignItemType(SingletonRepository.ItemCategories.Get<ScrollSatisfyHunger>());
                item.Count = (char)Program.Rng.RandomBetween(2, 5);
                item.BecomeFlavourAware();
                item.BecomeKnown();
                item.IdentStoreb = true;
                Player.InvenCarry(item, false);
                item = new Item(this);
            }
            else
            {
                item.AssignItemType(SingletonRepository.ItemCategories.Get<FoodRation>());
                item.Count = Program.Rng.RandomBetween(3, 7);
                item.BecomeFlavourAware();
                item.BecomeKnown();
                Player.InvenCarry(item, false);
                item = new Item(this);
            }
            if (Player.Race.OutfitsWithScrollsOfLight || Player.BaseCharacterClass.ID == CharacterClass.ChosenOne)
            {
                item.AssignItemType(SingletonRepository.ItemCategories.Get<ScrollLight>());
                item.Count = Program.Rng.RandomBetween(3, 7);
                item.BecomeFlavourAware();
                item.BecomeKnown();
                item.IdentStoreb = true;
                Player.InvenCarry(item, false);
            }
            else
            {
                item.AssignItemType(SingletonRepository.ItemCategories.Get<LightWoodenTorch>());
                item.Count = Program.Rng.RandomBetween(3, 7);
                item.TypeSpecificValue = Program.Rng.RandomBetween(3, 7) * 500;
                item.BecomeFlavourAware();
                item.BecomeKnown();
                Player.InvenCarry(item, false);
                Item carried = item.Clone(1);
                LightsourceInventorySlot lightsourceInventorySlot = SingletonRepository.InventorySlots.Get<LightsourceInventorySlot>();
                Player.Inventory[lightsourceInventorySlot.WeightedRandom.Choose()] = carried;
                Player.WeightCarried += carried.Weight;
            }

            ItemClass[][] _playerInit = new ItemClass[16][];
            _playerInit[CharacterClass.Warrior] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<RingFearResistance>(),
                SingletonRepository.ItemCategories.Get<SwordBroadSword>(),
                SingletonRepository.ItemCategories.Get<HardArmorChainMail>()
            };
            _playerInit[CharacterClass.Mage] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<SwordDagger>(),
                SingletonRepository.ItemCategories.Get<DeathBookBlackPrayers>()
            };
            _playerInit[CharacterClass.Priest] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<HaftedMace>(),
                SingletonRepository.ItemCategories.Get<DeathBookBlackPrayers>()
            };
            _playerInit[CharacterClass.Rogue] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<SwordDagger>(),
                SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>()
            };
            _playerInit[CharacterClass.Ranger] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<NatureBookCallOfTheWild>(),
                SingletonRepository.ItemCategories.Get<SwordBroadSword>(),
                SingletonRepository.ItemCategories.Get<DeathBookBlackPrayers>()
            };
            _playerInit[CharacterClass.Paladin] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<SwordBroadSword>(),
                SingletonRepository.ItemCategories.Get<ScrollProtectionFromEvil>()
            };
            _playerInit[CharacterClass.WarriorMage] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<SwordShortSword>(),
                SingletonRepository.ItemCategories.Get<DeathBookBlackPrayers>()
            };
            _playerInit[CharacterClass.Fanatic] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<SwordBroadSword>(),
                SingletonRepository.ItemCategories.Get<HardArmorMetalScaleMail>()
            };
            _playerInit[CharacterClass.Monk] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<PotionHealing>(),
                SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>()
            };
            _playerInit[CharacterClass.Mindcrafter] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SwordSmallSword>(),
                SingletonRepository.ItemCategories.Get<PotionRestoreMana>(),
                SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>()
            };
            _playerInit[CharacterClass.HighMage] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<SwordDagger>(),
                SingletonRepository.ItemCategories.Get<RingSustainIntelligence>()
            };
            _playerInit[CharacterClass.Druid] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<HaftedQuarterstaff>(),
                SingletonRepository.ItemCategories.Get<RingSustainWisdom>()
            };
            _playerInit[CharacterClass.Cultist] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SorceryBookBeginnersHandbook>(),
                SingletonRepository.ItemCategories.Get<RingSustainIntelligence>(),
                SingletonRepository.ItemCategories.Get<DeathBookBlackPrayers>()
            };
            _playerInit[CharacterClass.Channeler] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<WandMagicMissile>(),
                SingletonRepository.ItemCategories.Get<SwordDagger>(),
                SingletonRepository.ItemCategories.Get<RingSustainCharisma>()
            };
            _playerInit[CharacterClass.ChosenOne] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<SwordSmallSword>(),
                SingletonRepository.ItemCategories.Get<PotionHealing>(),
                SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>()
            };
            _playerInit[CharacterClass.Mystic] = new ItemClass[]
            {
                SingletonRepository.ItemCategories.Get<RingSustainWisdom>(),
                SingletonRepository.ItemCategories.Get<PotionHealing>(),
                SingletonRepository.ItemCategories.Get<SoftArmorSoftLeatherArmour>()
            };

            ItemClass[] startingItems = _playerInit[Player.BaseCharacterClass.ID];
            for (int i = 0; i < startingItems.Length; i++)
            {
                ItemClass itemClass = startingItems[i];

                itemClass = Player.Race.OutfitItem(this, itemClass);
                item = new Item(this);
                item.AssignItemType(itemClass);
                if (itemClass.CategoryEnum == ItemTypeEnum.Sword && Player.BaseCharacterClass.ID == CharacterClass.Rogue && Player.Realm1 == Realm.Death)
                {
                    item.RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                }
                if (itemClass.CategoryEnum == ItemTypeEnum.Wand)
                {
                    item.TypeSpecificValue = 1;
                }
                item.IdentStoreb = true;
                item.BecomeFlavourAware();
                item.BecomeKnown();
                int slot = item.BaseItemCategory.WieldSlot;
                if (slot == -1)
                {
                    Player.InvenCarry(item, false);
                }
                else
                {
                    Player.Inventory[slot] = item;
                    Player.WeightCarried += item.Weight;
                }
            }
        }

        /// <summary>
        /// List of backstory fragments joined together on character generation
        /// </summary>
        private readonly PlayerHistory[] _backgroundTable =
        {
            // Group 1: Human start /Half-Elf legitimacy 1->2->3->50->51->52->53->End
            new PlayerHistory("You are the illegitimate and unacknowledged child ", 10, 1, 2, 25),
            new PlayerHistory("You are the illegitimate but acknowledged child ", 20, 1, 2, 35),
            new PlayerHistory("You are one of several children ", 95, 1, 2, 45),
            new PlayerHistory("You are the first child ", 100, 1, 2, 50),
            // Group 2: Human/Half-Elf/Half-Orc/Half-Ogre/Half-Giant/Half-Titan parent 2->3->50->51->52->53->End
            new PlayerHistory("of a Serf. ", 40, 2, 3, 65),
            new PlayerHistory("of a Yeoman. ", 65, 2, 3, 80),
            new PlayerHistory("of a Townsman. ", 80, 2, 3, 90),
            new PlayerHistory("of a Guildsman. ", 90, 2, 3, 105),
            new PlayerHistory("of a Landed Knight. ", 96, 2, 3, 120),
            new PlayerHistory("of a Noble Family. ", 99, 2, 3, 130),
            new PlayerHistory("of the Royal Blood Line. ", 100, 2, 3, 140),
            // Group 3: Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan
            // childhood 3->50->51->52->53->End
            new PlayerHistory("You are the black sheep of the family. ", 20, 3, 50, 20),
            new PlayerHistory("You are a credit to the family. ", 80, 3, 50, 55),
            new PlayerHistory("You are a well liked child. ", 100, 3, 50, 60),
            // Group 4: Half-Elf start 4->1->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was of the Teleri. ", 40, 4, 1, 50),
            new PlayerHistory("Your father was of the Teleri. ", 75, 4, 1, 55),
            new PlayerHistory("Your mother was of the Noldor. ", 90, 4, 1, 55),
            new PlayerHistory("Your father was of the Noldor. ", 95, 4, 1, 60),
            new PlayerHistory("Your mother was of the Vanyar. ", 98, 4, 1, 65),
            new PlayerHistory("Your father was of the Vanyar. ", 100, 4, 1, 70),
            // Group 7: Elf/High-Elf start 7->8->9->54->55->56->End
            new PlayerHistory("You are one of several children ", 60, 7, 8, 50),
            new PlayerHistory("You are the only child ", 100, 7, 8, 55),
            // Group 8: Elf/High-Elf ancestry 8->9->54->55->56->End
            new PlayerHistory("of a Teleri ", 75, 8, 9, 50),
            new PlayerHistory("of a Noldor ", 95, 8, 9, 55),
            new PlayerHistory("of a Vanyar ", 100, 8, 9, 60),
            // Group 9: Elf/High-Elf parent 9->54->55->56->End
            new PlayerHistory("Ranger. ", 40, 9, 54, 80),
            new PlayerHistory("Archer. ", 70, 9, 54, 90),
            new PlayerHistory("Warrior. ", 87, 9, 54, 110),
            new PlayerHistory("Mage. ", 95, 9, 54, 125),
            new PlayerHistory("Prince. ", 99, 9, 54, 140),
            new PlayerHistory("King. ", 100, 9, 54, 145),
            // Group 10: Hobbit start 10->11->3->50->51->52->53->End
            new PlayerHistory("You are one of several children of a Hobbit ", 85, 10, 11, 45),
            new PlayerHistory("You are the only child of a Hobbit ", 100, 10, 11, 55),
            // Group 11: Hobbit parent 11->3->50->51->52->53->End
            new PlayerHistory("Bum. ", 20, 11, 3, 55),
            new PlayerHistory("Tavern Owner. ", 30, 11, 3, 80),
            new PlayerHistory("Miller. ", 40, 11, 3, 90),
            new PlayerHistory("Home Owner. ", 50, 11, 3, 100),
            new PlayerHistory("Burglar. ", 80, 11, 3, 110),
            new PlayerHistory("Warrior. ", 95, 11, 3, 115),
            new PlayerHistory("Mage. ", 99, 11, 3, 125),
            new PlayerHistory("Clan Elder. ", 100, 11, 3, 140),
            // Group 13: Gnome start 13->14->3->50->51->52->53->End
            new PlayerHistory("You are one of several children of a Gnome ", 85, 13, 14, 45),
            new PlayerHistory("You are the only child of a Gnome ", 100, 13, 14, 55),
            // Group 14: Gnome parent 14->3->50->51->52->53->End
            new PlayerHistory("Beggar. ", 20, 14, 3, 55),
            new PlayerHistory("Braggart. ", 50, 14, 3, 70),
            new PlayerHistory("Prankster. ", 75, 14, 3, 85),
            new PlayerHistory("Warrior. ", 95, 14, 3, 100),
            new PlayerHistory("Mage. ", 100, 14, 3, 125),
            // Group 16: Dwarf start 16->17->18->57->58->59->60->61->End
            new PlayerHistory("You are one of two children of a Dwarven ", 25, 16, 17, 40),
            new PlayerHistory("You are the only child of a Dwarven ", 100, 16, 17, 50),
            // Group 17: Dwarf parent 17->18->57->58->59->60->61->End
            new PlayerHistory("Thief. ", 10, 17, 18, 60),
            new PlayerHistory("Prison Guard. ", 25, 17, 18, 75),
            new PlayerHistory("Miner. ", 75, 17, 18, 90),
            new PlayerHistory("Warrior. ", 90, 17, 18, 110),
            new PlayerHistory("Priest. ", 99, 17, 18, 130),
            new PlayerHistory("King. ", 100, 17, 18, 150),
            // Group 18: Dwarf/Nibelung childhood 18->57->58->59->60->61->End
            new PlayerHistory("You are the black sheep of the family. ", 15, 18, 57, 10),
            new PlayerHistory("You are a credit to the family. ", 85, 18, 57, 50),
            new PlayerHistory("You are a well liked child. ", 100, 18, 57, 55),
            // Group 19: Half-Orc start 19->20->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was an Orc, but it is unacknowledged. ", 25, 19, 20, 25),
            new PlayerHistory("Your mother was an Orc. ", 50, 19, 20, 25),
            new PlayerHistory("Your father was an Orc. ", 75, 19, 20, 25),
            new PlayerHistory("Your father was an Orc, but it is unacknowledged. ", 100, 19, 20, 25),
            // Group 20: Half-Orc/Half-Ogre/Half-Giant/Half-Titan adoption 20->2->3->50->51->52->53->End
            new PlayerHistory("You are the child ", 80, 20, 2, 50),
            new PlayerHistory("You are the adopted child ", 100, 20, 2, 50),
            // Group 22: Half-Troll start 22->23->62->63->64->65->66->End
            new PlayerHistory("Your mother was a Cave-Troll ", 30, 22, 23, 20),
            new PlayerHistory("Your father was a Cave-Troll ", 60, 22, 23, 25),
            new PlayerHistory("Your mother was a Hill-Troll ", 75, 22, 23, 30),
            new PlayerHistory("Your father was a Hill-Troll ", 90, 22, 23, 35),
            new PlayerHistory("Your mother was a Water-Troll ", 95, 22, 23, 40),
            new PlayerHistory("Your father was a Water-Troll ", 100, 22, 23, 45),
            // Group 23: Half-Troll parent 23->62->63->64->65->66->End
            new PlayerHistory("Cook. ", 5, 23, 62, 60),
            new PlayerHistory("Warrior. ", 95, 23, 62, 55),
            new PlayerHistory("Priest. ", 99, 23, 62, 65),
            new PlayerHistory("Clan Chief. ", 100, 23, 62, 80),
            // Group 24: Kobold scales 24->25->26->End
            new PlayerHistory("You have green scales, ", 25, 24, 25, 50),
            new PlayerHistory("You have dark green scales, ", 50, 24, 25, 50),
            new PlayerHistory("You have yellow scales, ", 75, 24, 25, 50),
            new PlayerHistory("You have green scales, a yellow belly, ", 100, 24, 25, 50),
            // Group 25: Kobold eyes 25->26->End
            new PlayerHistory("bright eyes, ", 25, 25, 26, 50),
            new PlayerHistory("yellow eyes, ", 50, 25, 26, 50),
            new PlayerHistory("red eyes, ", 75, 25, 26, 50),
            new PlayerHistory("snake-like eyes, ", 100, 25, 26, 50),
            // Group 26: Kobold tail 26->End
            new PlayerHistory("and a long sinuous tail.", 20, 26, 0, 50),
            new PlayerHistory("and a short tail.", 40, 26, 0, 50),
            new PlayerHistory("and a muscular tail.", 60, 26, 0, 50),
            new PlayerHistory("and a long tail.", 80, 26, 0, 50),
            new PlayerHistory("and a sinuous tail.", 100, 26, 0, 50),
            // Group 50: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan eyes 50->51->52->53->End
            new PlayerHistory("You have dark brown eyes, ", 20, 50, 51, 50),
            new PlayerHistory("You have brown eyes, ", 60, 50, 51, 50),
            new PlayerHistory("You have hazel eyes, ", 70, 50, 51, 50),
            new PlayerHistory("You have green eyes, ", 80, 50, 51, 50),
            new PlayerHistory("You have blue eyes, ", 90, 50, 51, 50),
            new PlayerHistory("You have blue-gray eyes, ", 100, 50, 51, 50),
            // Group 51: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan hairstyle 51->52->53->End
            new PlayerHistory("straight ", 70, 51, 52, 50),
            new PlayerHistory("wavy ", 90, 51, 52, 50),
            new PlayerHistory("curly ", 100, 51, 52, 50),
            // Group 52: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan hair colour 52->53->End
            new PlayerHistory("black hair, ", 30, 52, 53, 50),
            new PlayerHistory("brown hair, ", 70, 52, 53, 50),
            new PlayerHistory("auburn hair, ", 80, 52, 53, 50),
            new PlayerHistory("red hair, ", 90, 52, 53, 50),
            new PlayerHistory("blond hair, ", 100, 52, 53, 50),
            // Group 53: Great
            // One/Human/Half-Elf/Hobbit/Gnome/Half-Orc/Half-Ogre/Half-Giant/Half-Titan complexion 53->End
            new PlayerHistory("and a very dark complexion.", 10, 53, 0, 50),
            new PlayerHistory("and a dark complexion.", 30, 53, 0, 50),
            new PlayerHistory("and an olive complexion.", 80, 53, 0, 50),
            new PlayerHistory("and a pale complexion.", 90, 53, 0, 50),
            new PlayerHistory("and a very pale complexion.", 100, 53, 0, 50),
            // Group 54: Elf/High-Elf eyes 54->55->56->End
            new PlayerHistory("You have light grey eyes, ", 85, 54, 55, 50),
            new PlayerHistory("You have light blue eyes, ", 95, 54, 55, 50),
            new PlayerHistory("You have light green eyes, ", 100, 54, 55, 50),
            // Group 55: Elf/High-Elf hairstyle 55->56->End
            new PlayerHistory("straight ", 75, 55, 56, 50),
            new PlayerHistory("wavy ", 100, 55, 56, 50),
            // Group 56: Elf/High-Elf colour 56->End
            new PlayerHistory("black hair, and a pale complexion.", 75, 56, 0, 50),
            new PlayerHistory("brown hair, and a pale complexion.", 85, 56, 0, 50),
            new PlayerHistory("blond hair, and a pale complexion.", 95, 56, 0, 50),
            new PlayerHistory("silver hair, and a pale complexion.", 100, 56, 0, 50),
            // Group 57: Dwarf/Nibelung eyes 57->58->59->60->61->End
            new PlayerHistory("You have dark brown eyes, ", 99, 57, 58, 50),
            new PlayerHistory("You have glowing red eyes, ", 100, 57, 58, 60),
            // Group 58: Dwarf/Nibelung hairstyle 58->59->60->61->End
            new PlayerHistory("straight ", 90, 58, 59, 50),
            new PlayerHistory("wavy ", 100, 58, 59, 50),
            // Group 59: Dwarf/Nibelung hair colour 59->60->61->End
            new PlayerHistory("black hair, ", 75, 59, 60, 50),
            new PlayerHistory("brown hair, ", 100, 59, 60, 50),
            // Group 60: Dwarf/Nibelung beard 60->61->End
            new PlayerHistory("a one foot beard, ", 25, 60, 61, 50),
            new PlayerHistory("a two foot beard, ", 60, 60, 61, 51),
            new PlayerHistory("a three foot beard, ", 90, 60, 61, 53),
            new PlayerHistory("a four foot beard, ", 100, 60, 61, 55),
            // Group 61: Dwarf/Nibelung complexion 61->End
            new PlayerHistory("and a dark complexion.", 100, 61, 0, 50),
            // Group 62: Half-Troll/Zombie eyes 62->63->64->65->66->End
            new PlayerHistory("You have slime green eyes, ", 60, 62, 63, 50),
            new PlayerHistory("You have puke yellow eyes, ", 85, 62, 63, 50),
            new PlayerHistory("You have blue-bloodshot eyes, ", 99, 62, 63, 50),
            new PlayerHistory("You have glowing red eyes, ", 100, 62, 63, 55),
            // Group 63: Half-Troll/Zombie hairstyle 63->64->65->66->End
            new PlayerHistory("dirty ", 33, 63, 64, 50),
            new PlayerHistory("mangy ", 66, 63, 64, 50),
            new PlayerHistory("oily ", 100, 63, 64, 50),
            // Group 64: Half-Troll/Zombie hair 64->65->66->End
            new PlayerHistory("sea-weed green hair, ", 33, 64, 65, 50),
            new PlayerHistory("bright red hair, ", 66, 64, 65, 50),
            new PlayerHistory("dark purple hair, ", 100, 64, 65, 50),
            // Group 65: Half-Troll/Zombie skin colour 65->66->End
            new PlayerHistory("and green ", 25, 65, 66, 50),
            new PlayerHistory("and blue ", 50, 65, 66, 50),
            new PlayerHistory("and white ", 75, 65, 66, 50),
            new PlayerHistory("and black ", 100, 65, 66, 50),
            // Group 66: Half-Troll/Zombie skin texture 66->End
            new PlayerHistory("ulcerous skin.", 33, 66, 0, 50),
            new PlayerHistory("scabby skin.", 66, 66, 0, 50),
            new PlayerHistory("leprous skin.", 100, 66, 0, 50),
            // Group 67: Great One start 67->68->50->51->52->53->End
            new PlayerHistory("You are an unacknowledged child of ", 50, 67, 68, 45),
            new PlayerHistory("You are a rebel child of ", 80, 67, 68, 65),
            new PlayerHistory("You are a long lost child of ", 100, 67, 68, 55),
            // Group 68: Great One parent 68->50->51->52->53->End
            new PlayerHistory("someone with Great One blood. ", 50, 68, 50, 80),
            new PlayerHistory("an unknown child of a Great One. ", 65, 68, 50, 90),
            new PlayerHistory("an unknown Great One. ", 79, 68, 50, 100),
            new PlayerHistory("Karakal. ", 80, 68, 50, 130),
            new PlayerHistory("Hagarg Ryonis. ", 83, 68, 50, 105),
            new PlayerHistory("Lobon. ", 84, 68, 50, 105),
            new PlayerHistory("Nath-Horthath. ", 85, 68, 50, 90),
            new PlayerHistory("Tamash. ", 87, 68, 50, 100),
            new PlayerHistory("Zo-Kalar. ", 88, 68, 50, 125),
            new PlayerHistory("Karakal. ", 89, 68, 50, 120),
            new PlayerHistory("Hagarg Ryonis. ", 90, 68, 50, 140),
            new PlayerHistory("Lobon. ", 91, 68, 50, 115),
            new PlayerHistory("Nath-Horthath. ", 92, 68, 50, 110),
            new PlayerHistory("Tamash. ", 93, 68, 50, 105),
            new PlayerHistory("Zo-Kalar. ", 94, 68, 50, 95),
            new PlayerHistory("Karakal. ", 95, 68, 50, 115),
            new PlayerHistory("Hagarg Ryonis. ", 96, 68, 50, 110),
            new PlayerHistory("Lobon. ", 97, 68, 50, 135),
            new PlayerHistory("Nath-Horthath. ", 98, 68, 50, 90),
            new PlayerHistory("Tamash. ", 99, 68, 50, 105),
            new PlayerHistory("Zo-Kalar. ", 100, 68, 50, 80),
            // Group 69: Dark-Elf start 68->70->71->72->73->End
            new PlayerHistory("You are one of several children of a Dark Elven ", 85, 69, 70, 45),
            new PlayerHistory("You are the only child of a Dark Elven ", 100, 69, 70, 55),
            // Group 70: Dark-Elf parent 70->71->72->73->End
            new PlayerHistory("Warrior. ", 50, 70, 71, 60),
            new PlayerHistory("Warlock. ", 80, 70, 71, 75),
            new PlayerHistory("Noble. ", 100, 70, 71, 95),
            // Group 71: Dark-Elf eyes 71->72->73->End
            new PlayerHistory("You have black eyes, ", 100, 71, 72, 50),
            // Group 72: Dark-Elf hair style 72->73->End
            new PlayerHistory("straight ", 70, 72, 73, 50),
            new PlayerHistory("wavy ", 90, 72, 73, 50),
            new PlayerHistory("curly ", 100, 72, 73, 50),
            // Group 73: Dark-Elf complexion 73->End
            new PlayerHistory("black hair and a very dark complexion.", 100, 73, 0, 50),
            // Group 74: Half-Ogre start 74->20->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was an Ogre, but it is unacknowledged. ", 25, 74, 20, 25),
            new PlayerHistory("Your father was an Ogre. ", 50, 74, 20, 25),
            new PlayerHistory("Your mother was an Ogre. ", 75, 74, 20, 25),
            new PlayerHistory("Your father was an Ogre, but it is unacknowledged. ", 100, 74, 20, 25),
            // Group 75: Half-Giant start 75->20->2->3->50->51->52->53->End
            new PlayerHistory("Your mother was a Hill Giant. ", 10, 75, 20, 50),
            new PlayerHistory("Your mother was a Fire Giant. ", 12, 75, 20, 55),
            new PlayerHistory("Your mother was a Frost Giant. ", 20, 75, 20, 60),
            new PlayerHistory("Your mother was a Cloud Giant. ", 23, 75, 20, 65),
            new PlayerHistory("Your mother was a Storm Giant. ", 25, 75, 20, 70),
            new PlayerHistory("Your father was a Hill Giant. ", 60, 75, 20, 50),
            new PlayerHistory("Your father was a Fire Giant. ", 70, 75, 20, 55),
            new PlayerHistory("Your father was a Frost Giant. ", 80, 75, 20, 60),
            new PlayerHistory("Your father was a Cloud Giant. ", 90, 75, 20, 65),
            new PlayerHistory("Your father was a Storm Giant. ", 100, 75, 20, 70),
            // Group 76: Half-Titan start 75->20->2->3->50->51->52->53->End
            new PlayerHistory("Your father was an unknown Titan. ", 75, 76, 20, 50),
            new PlayerHistory("Your mother was Themis. ", 80, 76, 20, 100),
            new PlayerHistory("Your mother was Mnemosyne. ", 85, 76, 20, 100),
            new PlayerHistory("Your father was Okeanoas. ", 90, 76, 20, 100),
            new PlayerHistory("Your father was Crius. ", 95, 76, 20, 100),
            new PlayerHistory("Your father was Hyperion. ", 98, 76, 20, 125),
            new PlayerHistory("Your father was Kronos. ", 100, 76, 20, 150),
            // Group 77: Cyclops start 77->109->110->111->112->End
            new PlayerHistory("You are the offspring of an unknown Cyclops. ", 90, 77, 109, 50),
            new PlayerHistory("You are Polyphemos's child. ", 98, 77, 109, 80),
            new PlayerHistory("You are Uranos's child. ", 100, 77, 109, 135),
            // Group 78: Yeek start 78->79->80->81->135->136->137->End
            new PlayerHistory("You are the runt of ", 20, 78, 79, 40),
            new PlayerHistory("You come from ", 80, 78, 79, 50),
            new PlayerHistory("You are the largest of ", 100, 78, 79, 55),
            // Group 79: Yeek litter size 79->80->81->135->136->137->End
            new PlayerHistory("a litter of 3 pups. ", 15, 79, 80, 55),
            new PlayerHistory("a litter of 4 pups. ", 40, 79, 80, 55),
            new PlayerHistory("a litter of 5 pups. ", 70, 79, 80, 50),
            new PlayerHistory("a litter of 6 pups. ", 85, 79, 80, 50),
            new PlayerHistory("a litter of 7 pups. ", 95, 79, 80, 45),
            new PlayerHistory("a litter of 8 pups. ", 100, 79, 80, 45),
            // Group 80: Yeek parent 80->81->135->136->137->End
            new PlayerHistory("Your mother was a scavenger. ", 25, 80, 81, 40),
            new PlayerHistory("Your mother was a sneak. ", 50, 80, 81, 45),
            new PlayerHistory("Your mother was a warrior. ", 75, 80, 81, 50),
            new PlayerHistory("Your mother was a master yeek. ", 95, 80, 81, 55),
            new PlayerHistory("Your father was a yeek king. ", 100, 80, 81, 60),
            // Group 81: Yeek fur style 81->135->136->137->End
            new PlayerHistory("You have mangy ", 33, 81, 135, 50),
            new PlayerHistory("You have short ", 66, 81, 135, 50),
            new PlayerHistory("You have long ", 100, 81, 135, 50),
            // Group 82: Kobold start 82->83->24->25->26->End
            new PlayerHistory("You are one of several children of ", 100, 82, 83, 50),
            // Group 83: Kobold parent 83->24->25->26->End
            new PlayerHistory("a Small Kobold. ", 40, 83, 24, 50),
            new PlayerHistory("a Kobold. ", 75, 83, 24, 55),
            new PlayerHistory("a Large Kobold. ", 95, 83, 24, 65),
            new PlayerHistory("Vort, the Kobold Queen. ", 100, 83, 24, 100),
            // Group 84: Klackon start 84->85->86->End
            new PlayerHistory("You are one of several children of a Klackon hive queen. ", 100, 84, 85, 50),
            // Group 85: Klackon skin 85->86->End
            new PlayerHistory("You have red chitin, ", 40, 85, 86, 50),
            new PlayerHistory("You have black chitin, ", 90, 85, 86, 50),
            new PlayerHistory("You have yellow chitin, ", 100, 85, 86, 50),
            // Group 86: Klackon antennae 86->End
            new PlayerHistory("long antennae, and black eyes.", 50, 86, 0, 50),
            new PlayerHistory("short antennae, and black eyes.", 80, 86, 0, 50),
            new PlayerHistory("feathered antennae, and black eyes.", 100, 86, 0, 50),
            // Group 87: Nibelung start 87->88->18->57->58->59->60->61->End
            new PlayerHistory("You are one of several children of ", 100, 87, 88, 89),
            // Group 88: Nibelung parent 88->18->57->58->59->60->61->End
            new PlayerHistory("a Nibelung Slave. ", 30, 88, 18, 20),
            new PlayerHistory("a Nibelung Thief. ", 50, 88, 18, 40),
            new PlayerHistory("a Nibelung Smith. ", 70, 88, 18, 60),
            new PlayerHistory("a Nibelung Miner. ", 90, 88, 18, 75),
            new PlayerHistory("a Nibelung Priest. ", 95, 88, 18, 100),
            new PlayerHistory("Mime, the Nibelung. ", 100, 88, 18, 100),
            // Group 89: Draconian start 89->90->91->End
            new PlayerHistory("You are one of several children of a Draconian ", 85, 89, 90, 50),
            new PlayerHistory("You are the only child of a Draconian ", 100, 89, 90, 55),
            // Group 90: Draconian parent 90->91->End
            new PlayerHistory("Warrior. ", 50, 90, 91, 50),
            new PlayerHistory("Priest. ", 65, 90, 91, 65),
            new PlayerHistory("Mage. ", 85, 90, 91, 70),
            new PlayerHistory("Noble. ", 100, 90, 91, 100),
            // Group 91: Draconian colour 91->End
            new PlayerHistory("You have green wings, green skin and yellow belly.", 30, 91, 0, 50),
            new PlayerHistory("You have green wings, and green skin.", 55, 91, 0, 50),
            new PlayerHistory("You have red wings, and red skin.", 80, 91, 0, 50),
            new PlayerHistory("You have black wings, and black skin.", 90, 91, 0, 50),
            new PlayerHistory("You have metallic skin, and shining wings.", 100, 91, 0, 50),
            // Group 92: Mind-Flayer start 93->93->End
            new PlayerHistory("You have slimy skin, empty glowing eyes, and ", 100, 92, 93, 80),
            // Group 93: Mind-Flayer tentacles 93->End
            new PlayerHistory("three tentacles around your mouth.", 20, 93, 0, 45),
            new PlayerHistory("four tentacles around your mouth.", 80, 93, 0, 50),
            new PlayerHistory("five tentacles around your mouth.", 100, 93, 0, 55),
            // Group 94: Imp start 94->95->96->97->End
            new PlayerHistory("You ancestor was ", 100, 94, 95, 50),
            // Group 95: Imp ancestor 95->96->97->End
            new PlayerHistory("a mindless demonic spawn. ", 30, 95, 96, 20),
            new PlayerHistory("a minor demon. ", 60, 95, 96, 50),
            new PlayerHistory("a major demon. ", 90, 95, 96, 75),
            new PlayerHistory("a demon lord. ", 100, 95, 96, 99),
            // Group 96: Imp skin 96->97->End
            new PlayerHistory("You have red skin, ", 50, 96, 97, 50),
            new PlayerHistory("You have brown skin, ", 100, 96, 97, 50),
            // Group 97: Imp eyes 97->End
            new PlayerHistory("claws, fangs, spikes, and glowing red eyes.", 40, 97, 0, 50),
            new PlayerHistory("claws, fangs, and glowing red eyes.", 70, 97, 0, 50),
            new PlayerHistory("claws, and glowing red eyes.", 100, 97, 0, 50),
            // Group 98: Golem start 98->99->100->101->End
            new PlayerHistory("You were shaped from ", 100, 98, 99, 50),
            // Group 99: Golem material 99->100->101->End
            new PlayerHistory("clay ", 40, 99, 100, 50),
            new PlayerHistory("stone ", 80, 99, 100, 50),
            new PlayerHistory("wood ", 85, 99, 100, 40),
            new PlayerHistory("iron ", 99, 99, 100, 50),
            new PlayerHistory("pure gold ", 100, 99, 100, 100),
            // Group 100: Golem creator 100->101->End
            new PlayerHistory("by a Kabbalist", 40, 100, 101, 50),
            new PlayerHistory("by a Wizard", 65, 100, 101, 50),
            new PlayerHistory("by an Alchemist", 90, 100, 101, 50),
            new PlayerHistory("by a Priest", 100, 100, 101, 60),
            // Group 101: Golem purpose 101->End
            new PlayerHistory(" to fight evil.", 10, 101, 0, 65),
            new PlayerHistory(".", 100, 101, 0, 50),
            // Group 102: Skeleton start 102->103->104->105->106->End
            new PlayerHistory("You were created by ", 100, 102, 103, 50),
            // Group 103: Skeleton creator 103->104->105->106->End
            new PlayerHistory("a Necromancer. ", 30, 103, 104, 50),
            new PlayerHistory("a magical experiment. ", 50, 103, 104, 50),
            new PlayerHistory("an Evil Priest. ", 70, 103, 104, 50),
            new PlayerHistory("a pact with the demons. ", 75, 103, 104, 50),
            new PlayerHistory("a restless spirit. ", 85, 103, 104, 50),
            new PlayerHistory("a curse. ", 95, 103, 104, 30),
            new PlayerHistory("an oath. ", 100, 103, 104, 50),
            // Group 104: Skeleton join 104->105->106->End
            new PlayerHistory("You have ", 100, 104, 105, 50),
            // Group 105: Skeleton bones 105->106->End
            new PlayerHistory("dirty, dry bones, ", 40, 105, 106, 50),
            new PlayerHistory("rotten black bones, ", 60, 105, 106, 50),
            new PlayerHistory("filthy, brown bones, ", 80, 105, 106, 50),
            new PlayerHistory("shining white bones, ", 100, 105, 106, 50),
            // Group 106: Skeleton eyes 106->End
            new PlayerHistory("and glowing eyes.", 30, 106, 0, 50),
            new PlayerHistory("and eyes which burn with hellfire.", 50, 106, 0, 50),
            new PlayerHistory("and empty eyesockets.", 100, 106, 0, 50),
            // Group 107: Zombie start 107->108->62->63->64->65->66->End
            new PlayerHistory("You were created by ", 100, 107, 108, 50),
            // Group 108: Zombie creator 108->62->63->64->65->66->End
            new PlayerHistory("a Necromancer. ", 30, 108, 62, 50),
            new PlayerHistory("a Wizard. ", 50, 108, 62, 50),
            new PlayerHistory("a restless spirit. ", 60, 108, 62, 50),
            new PlayerHistory("an Evil Priest. ", 70, 108, 62, 50),
            new PlayerHistory("a pact with the demons. ", 80, 108, 62, 50),
            new PlayerHistory("a curse. ", 95, 108, 62, 30),
            new PlayerHistory("an oath. ", 100, 108, 62, 50),
            // Group 109: Cyclops eye 109->110->111->112->End
            new PlayerHistory("You have a dark brown eye, ", 20, 109, 110, 50),
            new PlayerHistory("You have a brown eye, ", 60, 109, 110, 50),
            new PlayerHistory("You have a hazel eye, ", 70, 109, 110, 50),
            new PlayerHistory("You have a green eye, ", 80, 109, 110, 50),
            new PlayerHistory("You have a blue eye, ", 90, 109, 110, 50),
            new PlayerHistory("You have a blue-gray eye, ", 100, 109, 110, 50),
            // Group 110: Cyclops hair style 110->111->112->End
            new PlayerHistory("straight ", 70, 110, 111, 50),
            new PlayerHistory("wavy ", 90, 110, 111, 50),
            new PlayerHistory("curly ", 100, 110, 111, 50),
            // Group 111: Cyclops hair colour 111->112->End
            new PlayerHistory("black hair, ", 30, 111, 112, 50),
            new PlayerHistory("brown hair, ", 70, 111, 112, 50),
            new PlayerHistory("auburn hair, ", 80, 111, 112, 50),
            new PlayerHistory("red hair, ", 90, 111, 112, 50),
            new PlayerHistory("blond hair, ", 100, 111, 112, 50),
            // Group 112: Cyclops complexion 112->End
            new PlayerHistory("and a very dark complexion.", 10, 112, 0, 50),
            new PlayerHistory("and a dark complexion.", 30, 112, 0, 50),
            new PlayerHistory("and an olive complexion.", 80, 112, 0, 50),
            new PlayerHistory("and a pale complexion.", 90, 112, 0, 50),
            new PlayerHistory("and a very pale complexion.", 100, 112, 0, 50),
            // Group 113: Vampire start 113->114->115->116->117->End
            new PlayerHistory("You arose from an unmarked grave. ", 20, 113, 114, 50),
            new PlayerHistory("In life you were a simple peasant, the victim of a powerful Vampire Lord. ", 40, 113, 114, 50),
            new PlayerHistory("In life you were a Vampire Hunter, but they got you. ", 60, 113, 114, 50),
            new PlayerHistory("In life you were a Necromancer. ", 80, 113, 114, 50),
            new PlayerHistory("In life you were a powerful noble. ", 95, 113, 114, 50),
            new PlayerHistory("In life you were a powerful and cruel tyrant. ", 100, 113, 114, 50),
            // Group 114: Vampire join 114->115->116->117->End
            new PlayerHistory("You have ", 100, 114, 115, 50),
            // Group 115: Vampire hair 115->116->117->End
            new PlayerHistory("jet-black hair, ", 25, 115, 116, 50),
            new PlayerHistory("matted brown hair, ", 50, 115, 116, 50),
            new PlayerHistory("white hair, ", 75, 115, 116, 50),
            new PlayerHistory("a hairless head, ", 100, 115, 116, 50),
            // Group 116: Vampire eyes 116->117->End
            new PlayerHistory("eyes like red coals, ", 25, 116, 117, 50),
            new PlayerHistory("blank white eyes, ", 50, 116, 117, 50),
            new PlayerHistory("feral yellow eyes, ", 75, 116, 117, 50),
            new PlayerHistory("bloodshot red eyes, ", 100, 116, 117, 50),
            // Group 117: Vampire complexion 117->End
            new PlayerHistory("and a deathly pale complexion.", 100, 117, 0, 50),
            // Group 118: Spectre start 118->119->134->120->121->122->123->End
            new PlayerHistory("You were created by ", 100, 118, 119, 50),
            // Group 119: Spectre origin 119->134->120->121->122->123->End
            new PlayerHistory("a Necromancer. ", 30, 119, 134, 50),
            new PlayerHistory("a magical experiment. ", 50, 119, 134, 50),
            new PlayerHistory("an Evil Priest. ", 70, 119, 134, 50),
            new PlayerHistory("a pact with the demons. ", 75, 119, 134, 50),
            new PlayerHistory("a restless spirit. ", 85, 119, 134, 50),
            new PlayerHistory("a curse. ", 95, 119, 134, 30),
            new PlayerHistory("an oath. ", 100, 119, 134, 50),
            // Group 120: Spectre hair 120->121->122->123->End
            new PlayerHistory("jet-black hair, ", 25, 120, 121, 50),
            new PlayerHistory("matted brown hair, ", 50, 120, 121, 50),
            new PlayerHistory("white hair, ", 75, 120, 121, 50),
            new PlayerHistory("a hairless head, ", 100, 120, 121, 50),
            // Group 121: Spectre eyes 121->122->123->End
            new PlayerHistory("eyes like red coals, ", 25, 121, 122, 50),
            new PlayerHistory("blank white eyes, ", 50, 121, 122, 50),
            new PlayerHistory("feral yellow eyes, ", 75, 121, 122, 50),
            new PlayerHistory("bloodshot red eyes, ", 100, 121, 122, 50),
            // Group 122: Spectre complexion 122->123->End
            new PlayerHistory(" and a deathly gray complexion. ", 100, 122, 123, 50),
            // Group 123: Spectre aura 123->End
            new PlayerHistory("An eerie green aura surrounds you.", 100, 123, 0, 50),
            // Group 124: Sprite start 124->125->126->127->128->End
            new PlayerHistory("Your parents were ", 100, 124, 125, 50),
            // Group 125: Sprite parents 125->126->127->128->End
            new PlayerHistory("pixies. ", 20, 125, 126, 35),
            new PlayerHistory("nixies. ", 30, 125, 126, 25),
            new PlayerHistory("wood sprites. ", 75, 125, 126, 50),
            new PlayerHistory("wood spirits. ", 90, 125, 126, 75),
            new PlayerHistory("noble faerie folk. ", 100, 125, 126, 85),
            // Group 126: Sprite wings 126->127->128->End
            new PlayerHistory("You have dragonfly wings attached to your back, ", 45, 126, 127, 50),
            new PlayerHistory("You have butterfly wings attached to your back, ", 90, 126, 127, 50),
            new PlayerHistory("You have beetle wings attached to your back, ", 100, 126, 127, 50),
            // Group 127: Sprite hair 127->128->End
            new PlayerHistory("straight blond hair, ", 80, 127, 128, 50),
            new PlayerHistory("wavy blond hair, ", 100, 127, 128, 50),
            // Group 128: Sprite eyes 128->End
            new PlayerHistory("blue eyes, and skin the colour of pine.", 25, 128, 0, 50),
            new PlayerHistory("blue eyes, and skin the colour of ash.", 50, 128, 0, 50),
            new PlayerHistory("blue eyes, and skin the colour of oak.", 75, 128, 0, 50),
            new PlayerHistory("blue eyes, and skin the colour of mahogany.", 100, 128, 0, 50),
            // Group 129: Miri-Nigri start 129->130->131->132->133->End
            new PlayerHistory("You were summoned by a cult. ", 30, 129, 130, 40),
            new PlayerHistory("You crawled out from a fissure in the ground. ", 50, 129, 130, 50),
            new PlayerHistory("You were summoned by a lone wizard. ", 60, 129, 130, 60),
            new PlayerHistory("You squeezed into the world through a crack between dimensions. ", 75, 129, 130, 50),
            new PlayerHistory("You are the blasphemous crossbreed of unspeakable creatures of chaos. ", 100, 129, 130, 30),
            // Group 130: Miri-Nigri eyes 130->131->132->133->End
            new PlayerHistory("You have green reptilian eyes, ", 60, 130, 131, 50),
            new PlayerHistory("You have unblinking eyes, ", 85, 130, 131, 50),
            new PlayerHistory("You have fathomless black eyes, ", 99, 130, 131, 50),
            new PlayerHistory("You have altogether too many eyes, ", 100, 130, 131, 55),
            // Group 131: Miri-Nigri skin texture 131->132->133->End
            new PlayerHistory("slimy ", 10, 131, 132, 50),
            new PlayerHistory("smooth ", 33, 131, 132, 50),
            new PlayerHistory("slippery ", 66, 131, 132, 50),
            new PlayerHistory("oily ", 100, 131, 132, 50),
            // Group 132: Miri-Nigri skin colour 132->133->End
            new PlayerHistory("green skin, ", 33, 132, 133, 50),
            new PlayerHistory("black skin, ", 66, 132, 133, 50),
            new PlayerHistory("pale skin, ", 100, 132, 133, 50),
            // Group 133: Miri-Nigri mutation 133->End
            new PlayerHistory("and tentacles.", 50, 133, 0, 50),
            new PlayerHistory("and webbed feet.", 75, 133, 0, 50),
            new PlayerHistory("and suckers on your fingers.", 85, 133, 0, 50),
            new PlayerHistory("and no toes.", 90, 133, 0, 50),
            new PlayerHistory("and no nose.", 95, 133, 0, 50),
            new PlayerHistory("and no teeth.", 97, 133, 0, 50),
            new PlayerHistory("and no ears.", 100, 133, 0, 50),
            // Group 134: Spectre join 134->120->121->122->123->End
            new PlayerHistory("You have ", 100, 134, 120, 50),
            // Group 135: Yeek fur colour 135->136->137->End
            new PlayerHistory("blue fur, ", 40, 135, 136, 50),
            new PlayerHistory("brown fur, ", 60, 135, 136, 50),
            new PlayerHistory("striped fur, ", 95, 135, 136, 50),
            new PlayerHistory("spotted fur, ", 100, 135, 136, 50),
            // Group 136: Yeek ears 136->137->End
            new PlayerHistory("rounded ears, ", 10, 136, 137, 50),
            new PlayerHistory("pointed ears, ", 90, 136, 137, 50),
            new PlayerHistory("lop ears, ", 100, 136, 137, 50),
            // Group 137: Yeek eyes 137->End
            new PlayerHistory("and glowing yellow eyes.", 10, 137, 0, 50),
            new PlayerHistory("and glowing red eyes.", 90, 137, 0, 50),
            new PlayerHistory("and glowing orange eyes.", 100, 137, 0, 50),
            // Group 138: Tcho-Tcho start 138->139->140->141->142->End
            new PlayerHistory("You are the only child of ", 10, 138, 139, 50),
            new PlayerHistory("You are one of the children of ", 90, 138, 139, 50),
            new PlayerHistory("You don't know who your parents were. ", 100, 138, 140, 10),
            // Group 139: Tcho-Tcho parent 139->140->141->142->End
            new PlayerHistory("a hunter. ", 40, 139, 140, 20),
            new PlayerHistory("a warrior. ", 75, 139, 140, 30),
            new PlayerHistory("a cultist. ", 95, 139, 140, 50),
            new PlayerHistory("a warlock. ", 100, 139, 140, 60),
            new PlayerHistory("a high priest. ", 10, 139, 140, 80),
            // Group 140: Tcho-Tcho eyes 140->141->142->End
            new PlayerHistory("You have deep-set eyes, ", 30, 140, 141, 50),
            new PlayerHistory("You have a missing eye, ", 40, 140, 141, 50),
            new PlayerHistory("You have dark eyes, ", 90, 140, 141, 50),
            new PlayerHistory("You have bloodshot eyes, ", 100, 140, 141, 50),
            // Group 141: Tcho-Tcho body 141->142->End
            new PlayerHistory("many scars, and ", 30, 141, 142, 50),
            new PlayerHistory("obscene tattoos, and ", 50, 141, 142, 50),
            new PlayerHistory("ritual scarification, and ", 70, 141, 142, 50),
            new PlayerHistory("an extra toe, and ", 82, 141, 142, 50),
            new PlayerHistory("a vestigial tail, and ", 87, 141, 142, 50),
            new PlayerHistory("unmistakable signs of inbreeding, and ", 90, 141, 142, 50),
            new PlayerHistory("a missing nose, and ", 100, 141, 142, 50),
            // Group 142: Tcho-Tcho teeth 142->End
            new PlayerHistory("missing teeth.", 30, 142, 0, 50),
            new PlayerHistory("sharpened teeth.", 50, 142, 0, 50),
            new PlayerHistory("rotten teeth.", 70, 142, 0, 50),
            new PlayerHistory("filed-down teeth.", 90, 142, 0, 50),
            new PlayerHistory("no teeth.", 100, 142, 0, 50)
        };

        /// <summary>
        /// Create a background for a character by stringing together randomised text fragments
        /// based on their race
        /// </summary>
        /// <param name="player"> The player that needs a background </param>
        private void GetHistory(Player player)
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                player.History[i] = string.Empty;
            }
            string fullHistory = string.Empty;
            int socialClass = Program.Rng.DieRoll(4);
            // Start on a chart based on the character's race
            int chart = player.Race.Chart;

            // Keep going till we get to an end
            while (chart != 0)
            {
                i = 0;
                // Roll percentile for which background to use within each chart
                int roll = Program.Rng.DieRoll(100);
                // Find the correct chart and background
                while (chart != _backgroundTable[i].Chart || roll > _backgroundTable[i].Roll)
                {
                    i++;
                }
                // Add the text to our buffer
                fullHistory += _backgroundTable[i].Info;
                // Adjust our social class by the bonus or penalty for that fragment
                socialClass += _backgroundTable[i].Bonus - 50;
                chart = _backgroundTable[i].Next;
            }
            // Make sure our social class didn't go out of bounds
            if (socialClass > 100)
            {
                socialClass = 100;
            }
            else if (socialClass < 1)
            {
                socialClass = 1;
            }
            player.SocialClass = socialClass;
            // Split the buffer into four strings to fit on four lines of the screen
            string s = fullHistory.Trim();
            i = 0;
            while (true)
            {
                int n = s.Length;
                if (n < 60)
                {
                    player.History[i] = s;
                    break;
                }
                for (n = 60; n > 0 && s[n - 1] != ' '; n--)
                {
                }
                player.History[i++] = s.Substring(0, n).Trim();
                s = s.Substring(n).Trim();
            }
        }
        ////////////////// PLAYER FACTORY

        /// LEVEL FACTORY

        public void GenerateNewLevel()
        {
            // Loop until we are able to build the level.  Keep track of the number of attempts.
            for (int generateAttemptNumber = 0; ; generateAttemptNumber++)
            {
                bool okay = true;
                Level.OMax = 1;

                // Allocate and reset the grid tiles.
                for (int i = 0; i < Level.MaxHgt; i++)
                {
                    Level.Grid[i] = new GridTile[Level.MaxWid];
                    for (int j = 0; j < Level.MaxWid; j++)
                    {
                        Level.Grid[i][j] = new GridTile();
                        if (CurrentDepth == 0)
                        {
                            Level.Grid[i][j].SetBackgroundFeature("Grass");
                        }
                        else if (Wilderness[Player.WildernessY][Player.WildernessX].Dungeon.Tower)
                        {
                            Level.Grid[i][j].SetBackgroundFeature("TowerFloor");
                        }
                        else
                        {
                            Level.Grid[i][j].SetBackgroundFeature("DungeonFloor");
                        }
                    }
                }

                Level.PanelRowMin = 0;
                Level.PanelRowMax = 0;
                Level.PanelColMin = 0;
                Level.PanelColMax = 0;
                if (CurrentDepth == 0)
                {
                    if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                    {
                        CurTown = Wilderness[Player.WildernessY][Player.WildernessX].Town;
                        DungeonDifficulty = 0;
                        Level.Monsters.DunBias = null;
                        if (Wilderness[Player.WildernessY][Player.WildernessX].Town.Char == 'K')
                        {
                            DungeonDifficulty = 35;
                            Level.Monsters.DunBias = new CthuloidMonsterSelector();
                        }
                    }
                    else if (Wilderness[Player.WildernessY][Player.WildernessX].Dungeon != null)
                    {
                        DungeonDifficulty = Wilderness[Player.WildernessY][Player.WildernessX].Dungeon.Offset / 2;
                        if (DungeonDifficulty < 4)
                        {
                            DungeonDifficulty = 4;
                        }
                        Level.Monsters.DunBias = Wilderness[Player.WildernessY][Player.WildernessX].Dungeon.Bias;
                    }
                    else
                    {
                        DungeonDifficulty = 2;
                        Level.Monsters.DunBias = new AnimalMonsterSelector();
                    }
                }
                else
                {
                    DungeonDifficulty = CurDungeon.Offset;
                    Level.Monsters.DunBias = CurDungeon.Bias;
                }
                Level.MonsterLevel = Difficulty;
                Level.ObjectLevel = Difficulty;
                Level.SpecialTreasure = false;
                Level.SpecialDanger = false;
                Level.TreasureRating = 0;
                Level.DangerRating = 0;
                if (CurrentDepth == 0)
                {
                    Level.CurHgt = Constants.ScreenHgt;
                    Level.CurWid = Constants.ScreenWid;
                    Level.MaxPanelRows = (Level.CurHgt / Constants.ScreenHgt * 2) - 2;
                    Level.MaxPanelCols = (Level.CurWid / Constants.ScreenWid * 2) - 2;
                    Level.PanelRow = Level.MaxPanelRows;
                    Level.PanelCol = Level.MaxPanelCols;
                    if (Wilderness[Player.WildernessY][Player.WildernessX].Town != null)
                    {
                        TownGen();
                    }
                    else
                    {
                        WildernessGen();
                    }
                }
                else
                {
                    if (CurDungeon.Tower)
                    {
                        Level.CurHgt = Constants.ScreenHgt;
                        Level.CurWid = Constants.ScreenWid;
                        Level.MaxPanelRows = 0;
                        Level.MaxPanelCols = 0;
                        Level.PanelRow = 0;
                        Level.PanelCol = 0;
                    }
                    else
                    {
                        if (Program.Rng.DieRoll(_smallLevel) == 1)
                        {
                            int tester1 = Program.Rng.DieRoll(Level.MaxHgt / Constants.ScreenHgt);
                            int tester2 = Program.Rng.DieRoll(Level.MaxWid / Constants.ScreenWid);
                            Level.CurHgt = tester1 * Constants.ScreenHgt;
                            Level.CurWid = tester2 * Constants.ScreenWid;
                            Level.MaxPanelRows = (Level.CurHgt / Constants.ScreenHgt * 2) - 2;
                            Level.MaxPanelCols = (Level.CurWid / Constants.ScreenWid * 2) - 2;
                            Level.PanelRow = Level.MaxPanelRows;
                            Level.PanelCol = Level.MaxPanelCols;
                        }
                        else
                        {
                            Level.CurHgt = Level.MaxHgt;
                            Level.CurWid = Level.MaxWid;
                            Level.MaxPanelRows = (Level.CurHgt / Constants.ScreenHgt * 2) - 2;
                            Level.MaxPanelCols = (Level.CurWid / Constants.ScreenWid * 2) - 2;
                            Level.PanelRow = Level.MaxPanelRows;
                            Level.PanelCol = Level.MaxPanelCols;
                        }
                    }
                    if (!UndergroundGen())
                    {
                        okay = false;
                    }
                }
                if (Level.TreasureRating > 100)
                {
                    Level.TreasureFeeling = 2;
                }
                else if (Level.TreasureRating > 80)
                {
                    Level.TreasureFeeling = 3;
                }
                else if (Level.TreasureRating > 60)
                {
                    Level.TreasureFeeling = 4;
                }
                else if (Level.TreasureRating > 40)
                {
                    Level.TreasureFeeling = 5;
                }
                else if (Level.TreasureRating > 30)
                {
                    Level.TreasureFeeling = 6;
                }
                else if (Level.TreasureRating > 20)
                {
                    Level.TreasureFeeling = 7;
                }
                else if (Level.TreasureRating > 10)
                {
                    Level.TreasureFeeling = 8;
                }
                else if (Level.TreasureRating > 0)
                {
                    Level.TreasureFeeling = 9;
                }
                else
                {
                    Level.TreasureFeeling = 10;
                }
                if (Level.SpecialTreasure)
                {
                    Level.TreasureRating = 1;
                }
                if (Level.DangerRating > 100)
                {
                    Level.DangerFeeling = 2;
                }
                else if (Level.DangerRating > 80)
                {
                    Level.DangerFeeling = 3;
                }
                else if (Level.DangerRating > 60)
                {
                    Level.DangerFeeling = 4;
                }
                else if (Level.DangerRating > 40)
                {
                    Level.DangerFeeling = 5;
                }
                else if (Level.DangerRating > 30)
                {
                    Level.DangerFeeling = 6;
                }
                else if (Level.DangerRating > 20)
                {
                    Level.DangerFeeling = 7;
                }
                else if (Level.DangerRating > 10)
                {
                    Level.DangerFeeling = 8;
                }
                else if (Level.DangerRating > 0)
                {
                    Level.DangerFeeling = 9;
                }
                else
                {
                    Level.DangerFeeling = 10;
                }
                if (Level.SpecialDanger)
                {
                    Level.DangerFeeling = 1;
                }
                if (CurrentDepth <= 0)
                {
                    Level.TreasureFeeling = 0;
                    Level.DangerFeeling = 0;
                }
                if (Level.OMax >= Constants.MaxOIdx)
                {
                    okay = false;
                }
                if (Level.MMax >= Constants.MaxMIdx)
                {
                    okay = false;
                }
                if (generateAttemptNumber < 100)
                {
                    int totalFeeling = Level.TreasureFeeling + Level.DangerFeeling;
                    if (totalFeeling > 18 ||
                        (Difficulty >= 5 && totalFeeling > 16) ||
                        (Difficulty >= 10 && totalFeeling > 14) ||
                        (Difficulty >= 20 && totalFeeling > 12) ||
                        (Difficulty >= 40 && totalFeeling > 10))
                    {
                        okay = false;
                    }
                }
                if (okay)
                {
                    break;
                }

                // Reset the level so that we can attempt again.
                Level.WipeOList();
                Level.Monsters.WipeMList();
            }
            Player.GameTime.MarkLevelEntry();
        }

        private void AllocObject(int set, int typ, int num)
        {
            int y = 0;
            int x = 0;
            int dummy = 0;
            for (int k = 0; k < num; k++)
            {
                while (dummy < SafeMaxAttempts)
                {
                    dummy++;
                    y = Program.Rng.RandomLessThan(Level.CurHgt);
                    x = Program.Rng.RandomLessThan(Level.CurWid);
                    if (!Level.GridOpenNoItemOrCreature(y, x))
                    {
                        continue;
                    }
                    bool isRoom = Level.Grid[y][x].TileFlags.IsSet(GridTile.InRoom);
                    if (set == _allocSetCorr && isRoom)
                    {
                        continue;
                    }
                    if (set == _allocSetRoom && !isRoom)
                    {
                        continue;
                    }
                    break;
                }
                if (dummy >= SafeMaxAttempts)
                {
                    return;
                }
                switch (typ)
                {
                    case _allocTypRubble:
                        {
                            PlaceRubble(y, x);
                            break;
                        }
                    case _allocTypTrap:
                        {
                            Level.PlaceTrap(y, x);
                            break;
                        }
                    case _allocTypGold:
                        {
                            Level.PlaceGold(y, x);
                            break;
                        }
                    case _allocTypObject:
                        {
                            Level.PlaceObject(y, x, false, false);
                            break;
                        }
                }
            }
        }

        private void AllocStairs(string feat, int num, int walls)
        {
            for (int i = 0; i < num; i++)
            {
                for (bool flag = false; !flag;)
                {
                    for (int j = 0; !flag && j <= 3000; j++)
                    {
                        int y = Program.Rng.RandomLessThan(Level.CurHgt);
                        int x = Program.Rng.RandomLessThan(Level.CurWid);
                        if (!Level.GridOpenNoItemOrCreature(y, x))
                        {
                            continue;
                        }
                        if (NextToWalls(y, x) < walls)
                        {
                            continue;
                        }
                        GridTile cPtr = Level.Grid[y][x];
                        if (CurrentDepth <= 0)
                        {
                            cPtr.SetFeature("DownStair");
                        }
                        else if (Quests.IsQuest(CurrentDepth) ||
                                 CurrentDepth == CurDungeon.MaxLevel)
                        {
                            cPtr.SetFeature(CurDungeon.Tower ? "DownStair" : "UpStair");
                        }
                        else
                        {
                            cPtr.SetFeature(feat);
                        }
                        flag = true;
                    }
                    if (walls != 0)
                    {
                        walls--;
                    }
                }
            }
        }

        private void BuildField(int yy, int xx)
        {
            int y0 = (yy * 9) + 8;
            int x0 = (xx * 15) + 10;
            int y1 = y0 - Program.Rng.DieRoll(2) - 1;
            int y2 = y0 + Program.Rng.DieRoll(2) + 1;
            int x1 = x0 - Program.Rng.DieRoll(3) - 2;
            int x2 = x0 + Program.Rng.DieRoll(3) + 2;
            const string feature = "Field";
            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    Level.Grid[y][x].SetFeature(feature);
                    Level.Grid[y][x].SetBackgroundFeature(feature);
                }
            }
            if (Program.Rng.DieRoll(5) == 4)
            {
                int x = Program.Rng.RandomBetween(x1, x2);
                int y = Program.Rng.RandomBetween(y1, y2);
                Level.Grid[y][x].SetFeature("Scarecrow");
            }
        }

        private void BuildGraveyard(int yy, int xx)
        {
            int y0 = (yy * 9) + 8;
            int x0 = (xx * 15) + 10;
            int y1 = y0 - Program.Rng.DieRoll(2) - 1;
            int y2 = y0 + Program.Rng.DieRoll(2) + 1;
            int x1 = x0 - Program.Rng.DieRoll(3) - 2;
            int x2 = x0 + Program.Rng.DieRoll(3) + 2;
            for (int i = 0; i < Program.Rng.RandomBetween(10, 20); i++)
            {
                int x = (Program.Rng.RandomBetween(x1, x2) / 2 * 2) + 1;
                int y = (Program.Rng.RandomBetween(y1, y2) / 2 * 2) + 1;
                Level.Grid[y][x].SetFeature("Grave");
            }
        }

        private void BuildStore(Store store, int yy, int xx)
        {
            int y, x;
            GridTile cPtr;
            if (CurTown.Char != 'K')
            {
                if (store.StoreType == StoreType.StoreEmptyLot)
                {
                    switch (Program.Rng.DieRoll(10))
                    {
                        case 3:
                        case 7:
                        case 9:
                            break;

                        case 6:
                            BuildGraveyard(yy, xx);
                            break;

                        default:
                            BuildField(yy, xx);
                            break;
                    }
                    return;
                }
            }
            int y0 = (yy * 9) + 6;
            int x0 = (xx * 15) + 10;
            int y1 = y0 - Program.Rng.DieRoll(2);
            int y2 = y0 + Program.Rng.DieRoll(2) + 1;
            int x1 = x0 - Program.Rng.DieRoll(3) - 2;
            int x2 = x0 + Program.Rng.DieRoll(3) + 2;
            if ((y2 - y1) % 2 == 0)
            {
                y2++;
            }
            for (y = y1; y <= y2; y++)
            {
                for (x = x1; x <= x2; x++)
                {
                    cPtr = Level.Grid[y][x];
                    if (CurTown.Char == 'K')
                    {
                        switch (Program.Rng.DieRoll(6))
                        {
                            case 1:
                                cPtr.SetFeature("WallInner");
                                break;

                            case 2:
                            case 3:
                            case 4:
                                cPtr.SetFeature("Rubble");
                                break;
                        }
                    }
                    else
                    {
                        if (y == y2)
                        {
                            cPtr.SetFeature("WallPermBuilding");
                        }
                        else
                        {
                            cPtr.SetFeature("Roof");
                        }
                    }
                    cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
            }
            y = y2;
            x = Program.Rng.RandomBetween(x1 + 1, x2 - 2);
            cPtr = Level.Grid[y][x];
            if (CurTown.Char == 'K')
            {
                if (Program.Rng.DieRoll(8) == 6)
                {
                    PlaceRandomDoor(y, x);
                }
            }
            else
            {
                cPtr.SetFeature(store.FeatureType);
            }
            store.SetLocation(x, y);
            for (++y; y < y0 + 7; y++)
            {
                cPtr = Level.Grid[y][x];
                cPtr.SetFeature("PathBase");
            }
            y--;
            int dX = Math.Sign((Level.CurWid / 2) - x);
            for (x += dX; x != Level.CurWid / 2; x += dX)
            {
                cPtr = Level.Grid[y][x];
                cPtr.SetFeature("PathBase");
            }
        }

        private void BuildStreamer(string feat, int chance)
        {
            int dummy = 0;
            int y = Program.Rng.RandomSpread(Level.CurHgt / 2, 10);
            int x = Program.Rng.RandomSpread(Level.CurWid / 2, 15);
            int dir = Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
            while (dummy < SafeMaxAttempts)
            {
                dummy++;
                for (int i = 0; i < _dunStrDen; i++)
                {
                    const int d = _dunStrRng;
                    int tx;
                    int ty;
                    while (true)
                    {
                        ty = Program.Rng.RandomSpread(y, d);
                        tx = Program.Rng.RandomSpread(x, d);
                        if (!Level.InBounds2(ty, tx))
                        {
                            continue;
                        }
                        break;
                    }
                    GridTile cPtr = Level.Grid[ty][tx];

                    if (!cPtr.FeatureType.IsBasicWall)
                    {
                        continue;
                    }
                    cPtr.SetFeature(feat);
                    if (Program.Rng.RandomLessThan(chance) == 0)
                    {
                        cPtr.SetFeature(cPtr.FeatureType.Name + "VisTreas");
                    }
                }
                if (dummy >= SafeMaxAttempts)
                {
                    return;
                }
                y += Level.KeypadDirectionYOffset[dir];
                x += Level.KeypadDirectionXOffset[dir];
                if (!Level.InBounds(y, x))
                {
                    break;
                }
            }
        }

        private void BuildTunnel(int row1, int col1, int row2, int col2)
        {
            int i, y, x;
            int mainLoopCount = 0;
            bool doorFlag = false;
            GridTile cPtr;
            TunnN = 0;
            WallN = 0;
            int startRow = row1;
            int startCol = col1;
            CorrectDir(out int rowDir, out int colDir, row1, col1, row2, col2);
            while (row1 != row2 || col1 != col2)
            {
                if (mainLoopCount++ > 2000)
                {
                    break;
                }
                if (Program.Rng.RandomLessThan(100) < _dunTunChg)
                {
                    CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                    if (Program.Rng.RandomLessThan(100) < _dunTunRnd)
                    {
                        RandDir(out rowDir, out colDir);
                    }
                }
                int tmpRow = row1 + rowDir;
                int tmpCol = col1 + colDir;
                while (!Level.InBounds(tmpRow, tmpCol))
                {
                    CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                    if (Program.Rng.RandomLessThan(100) < _dunTunRnd)
                    {
                        RandDir(out rowDir, out colDir);
                    }
                    tmpRow = row1 + rowDir;
                    tmpCol = col1 + colDir;
                }
                cPtr = Level.Grid[tmpRow][tmpCol];
                if (cPtr.FeatureType.Name == "WallPermSolid")
                {
                    continue;
                }
                if (cPtr.FeatureType.Name == "WallPermOuter")
                {
                    continue;
                }
                if (cPtr.FeatureType.Name == "WallSolid")
                {
                    continue;
                }
                if (cPtr.FeatureType.Name == "WallOuter")
                {
                    y = tmpRow + rowDir;
                    x = tmpCol + colDir;
                    if (Level.Grid[y][x].FeatureType.Name == "WallPermSolid")
                    {
                        continue;
                    }
                    if (Level.Grid[y][x].FeatureType.Name == "WallPermOuter")
                    {
                        continue;
                    }
                    if (Level.Grid[y][x].FeatureType.Name == "WallOuter")
                    {
                        continue;
                    }
                    if (Level.Grid[y][x].FeatureType.Name == "WallSolid")
                    {
                        continue;
                    }
                    row1 = tmpRow;
                    col1 = tmpCol;
                    if (WallN < WallMax)
                    {
                        Wall[WallN] = new GridCoordinate(col1, row1);
                        WallN++;
                    }
                    for (y = row1 - 1; y <= row1 + 1; y++)
                    {
                        for (x = col1 - 1; x <= col1 + 1; x++)
                        {
                            if (Level.Grid[y][x].FeatureType.Name == "WallOuter")
                            {
                                Level.Grid[y][x].SetFeature("WallSolid");
                            }
                        }
                    }
                }
                else if (cPtr.TileFlags.IsSet(GridTile.InRoom))
                {
                    row1 = tmpRow;
                    col1 = tmpCol;
                }
                else if (cPtr.FeatureType.IsWall)
                {
                    row1 = tmpRow;
                    col1 = tmpCol;
                    if (TunnN < TunnMax)
                    {
                        Tunn[TunnN] = new GridCoordinate(col1, row1);
                        TunnN++;
                    }
                    doorFlag = false;
                }
                else
                {
                    row1 = tmpRow;
                    col1 = tmpCol;
                    if (!doorFlag)
                    {
                        if (DoorN < DoorMax)
                        {
                            Door[DoorN] = new GridCoordinate(col1, row1);
                            DoorN++;
                        }
                        doorFlag = true;
                    }
                    if (Program.Rng.RandomLessThan(100) >= _dunTunCon)
                    {
                        tmpRow = row1 - startRow;
                        if (tmpRow < 0)
                        {
                            tmpRow = -tmpRow;
                        }
                        tmpCol = col1 - startCol;
                        if (tmpCol < 0)
                        {
                            tmpCol = -tmpCol;
                        }
                        if (tmpRow > 10 || tmpCol > 10)
                        {
                            break;
                        }
                    }
                }
            }
            for (i = 0; i < TunnN; i++)
            {
                y = Tunn[i].Y;
                x = Tunn[i].X;
                cPtr = Level.Grid[y][x];
                cPtr.RevertToBackground();
            }
            for (i = 0; i < WallN; i++)
            {
                y = Wall[i].Y;
                x = Wall[i].X;
                cPtr = Level.Grid[y][x];
                cPtr.RevertToBackground();
                if (Program.Rng.RandomLessThan(100) < _dunTunPen)
                {
                    PlaceRandomDoor(y, x);
                }
            }
        }

        private void CorrectDir(out int rdir, out int cdir, int y1, int x1, int y2, int x2)
        {
            rdir = y1 == y2 ? 0 : y1 < y2 ? 1 : -1;
            cdir = x1 == x2 ? 0 : x1 < x2 ? 1 : -1;
            if (rdir != 0 && cdir != 0)
            {
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    rdir = 0;
                }
                else
                {
                    cdir = 0;
                }
            }
        }

        private void DestroyLevel()
        {
            for (int n = 0; n < Program.Rng.DieRoll(5); n++)
            {
                int x1 = Program.Rng.RandomBetween(5, Level.CurWid - 1 - 5);
                int y1 = Program.Rng.RandomBetween(5, Level.CurHgt - 1 - 5);
                int y;
                for (y = y1 - 15; y <= y1 + 15; y++)
                {
                    int x;
                    for (x = x1 - 15; x <= x1 + 15; x++)
                    {
                        if (!Level.InBounds(y, x))
                        {
                            continue;
                        }
                        int k = Level.Distance(y1, x1, y, x);
                        if (k >= 16)
                        {
                            continue;
                        }
                        Level.DeleteMonster(y, x);
                        if (Level.CaveValidBold(y, x))
                        {
                            Level.DeleteObject(y, x);
                            GridTile cPtr = Level.Grid[y][x];
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
                            cPtr.TileFlags.Clear(GridTile.InRoom | GridTile.InVault);
                            cPtr.TileFlags.Clear(GridTile.PlayerMemorised | GridTile.SelfLit);
                        }
                    }
                }
            }
        }

        private void MakeCavernLevel()
        {
            PerlinNoise perlinNoise = new PerlinNoise(Program.Rng.RandomBetween(0, int.MaxValue - 1));
            double widthDivisor = 1 / (double)Level.CurWid;
            double heightDivisor = 1 / (double)Level.CurHgt;
            for (int y = 0; y < Level.CurHgt; y++)
            {
                for (int x = 0; x < Level.CurWid; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                    v = (v + 1) / 2;
                    double dX = Math.Abs(x - (Level.CurWid / 2)) * widthDivisor;
                    double dY = Math.Abs(y - (Level.CurHgt / 2)) * heightDivisor;
                    double d = Math.Max(dX, dY);
                    const double elevation = 0.05;
                    const double steepness = 6.0;
                    const double dropoff = 50.0;
                    v += elevation - (dropoff * Math.Pow(d, steepness));
                    v = Math.Min(1, Math.Max(0, v));
                    int rounded = (int)(v * 10);
                    if (rounded < 2 || rounded > 5)
                    {
                        cPtr.SetFeature("WallBasic");
                    }
                    else
                    {
                        cPtr.SetFeature("DungeonFloor");
                    }
                }
            }
            for (int i = 0; i < _dunStrMag; i++)
            {
                BuildStreamer("Magma", _dunStrMc);
            }
            for (int i = 0; i < _dunStrQua; i++)
            {
                BuildStreamer("Quartz", _dunStrQc);
            }
            for (int x = 0; x < Level.CurWid; x++)
            {
                GridTile cPtr = Level.Grid[0][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int x = 0; x < Level.CurWid; x++)
            {
                GridTile cPtr = Level.Grid[Level.CurHgt - 1][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int y = 0; y < Level.CurHgt; y++)
            {
                GridTile cPtr = Level.Grid[y][0];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int y = 0; y < Level.CurHgt; y++)
            {
                GridTile cPtr = Level.Grid[y][Level.CurWid - 1];
                cPtr.SetFeature("WallPermSolid");
            }
            if (Program.Rng.DieRoll(_darkEmpty) != 1 || Program.Rng.DieRoll(100) > Difficulty)
            {
                Level.WizLight();
            }
        }

        private void MakeCornerTowers(int wildX, int wildY)
        {
            Island wilderness = Wilderness;
            int height = Level.CurHgt;
            int width = Level.CurWid;
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY - 1][wildX].Town != null) ||
                (wilderness[wildY][wildX - 1].Town != null) || (wilderness[wildY - 1][wildX - 1].Town != null))
            {
                Level.Grid[0][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][0].RevertToBackground();
                Level.Grid[0][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][0].SetFeature("TownWall");
                Level.Grid[1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][1].SetFeature("TownWall");
                Level.Grid[1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][1].SetFeature("TownWall");
                Level.Grid[0][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY - 1][wildX].Town != null) ||
                (wilderness[wildY][wildX + 1].Town != null) || (wilderness[wildY - 1][wildX + 1].Town != null))
            {
                Level.Grid[0][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][width - 1].RevertToBackground();
                Level.Grid[0][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][width - 1].SetFeature("TownWall");
                Level.Grid[1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][width - 2].SetFeature("TownWall");
                Level.Grid[1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][width - 2].SetFeature("TownWall");
                Level.Grid[0][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY + 1][wildX].Town != null) ||
                (wilderness[wildY][wildX + 1].Town != null) || (wilderness[wildY + 1][wildX + 1].Town != null))
            {
                Level.Grid[height - 1][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][width - 1].RevertToBackground();
                Level.Grid[height - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][width - 1].SetFeature("TownWall");
                Level.Grid[height - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][width - 2].SetFeature("TownWall");
                Level.Grid[height - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][width - 2].SetFeature("TownWall");
                Level.Grid[height - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY + 1][wildX].Town != null) ||
                (wilderness[wildY][wildX - 1].Town != null) || (wilderness[wildY + 1][wildX - 1].Town != null))
            {
                Level.Grid[height - 1][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][0].RevertToBackground();
                Level.Grid[height - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][0].SetFeature("TownWall");
                Level.Grid[height - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][1].SetFeature("TownWall");
                Level.Grid[height - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][1].SetFeature("TownWall");
                Level.Grid[height - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
        }

        private void MakeDungeonEntrance(int left, int top, int width, int height, out int stairX, out int stairY)
        {
            int dummy = 0;
            int x = 1;
            int y = 1;
            while (dummy < SafeMaxAttempts)
            {
                dummy++;
                y = Program.Rng.RandomBetween(top, top + height);
                x = Program.Rng.RandomBetween(left, left + width);
                if (Level.GridOpenNoItemOrCreature(y, x))
                {
                    break;
                }
            }
            Level.Grid[y - 2][x].RevertToBackground();
            Level.Grid[y - 1][x - 1].RevertToBackground();
            Level.Grid[y - 1][x].RevertToBackground();
            Level.Grid[y - 1][x + 1].RevertToBackground();
            Level.Grid[y][x - 2].RevertToBackground();
            Level.Grid[y][x - 1].RevertToBackground();
            Level.Grid[y][x].SetFeature("DownStair");
            stairX = x;
            stairY = y;
            Level.Grid[y][x + 1].RevertToBackground();
            Level.Grid[y][x + 2].RevertToBackground();
            Level.Grid[y + 1][x - 1].RevertToBackground();
            Level.Grid[y + 1][x].RevertToBackground();
            Level.Grid[y + 1][x + 1].RevertToBackground();
            Level.Grid[y + 2][x].RevertToBackground();
        }

        private void MakeDungeonLevel()
        {
            int k;
            int y;
            int x;
            int maxVaultOk = 2;
            bool destroyed = false;
            bool emptyLevel = false;

            Cent = new GridCoordinate[CentMax];
            //for (int i = 0; i < CentMax; i++)
            //{
            //    Cent[i] = new MapCoordinate();
            //}
            Door = new GridCoordinate[DoorMax];
            //for (int i = 0; i < DoorMax; i++)
            //{
            //    Door[i] = new MapCoordinate();
            //}
            Wall = new GridCoordinate[WallMax];
            //for (int i = 0; i < WallMax; i++)
            //{
            //    Wall[i] = new MapCoordinate();
            //}
            Tunn = new GridCoordinate[TunnMax];
            //for (int i = 0; i < TunnMax; i++)
            //{
            //    Tunn[i] = new MapCoordinate();
            //}
            RoomMap = new bool[MaxRoomsRow][];
            for (int i = 0; i < MaxRoomsRow; i++)
            {
                RoomMap[i] = new bool[MaxRoomsCol];
            }

            if (Level.MaxPanelRows == 0)
            {
                maxVaultOk--;
            }
            if (Level.MaxPanelCols == 0)
            {
                maxVaultOk--;
            }
            if (Program.Rng.DieRoll(_emptyLevel) == 1)
            {
                emptyLevel = true;
            }
            for (y = 0; y < Level.CurHgt; y++)
            {
                for (x = 0; x < Level.CurWid; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    if (emptyLevel)
                    {
                        cPtr.RevertToBackground();
                    }
                    else
                    {
                        cPtr.SetFeature("WallBasic");
                    }
                }
            }
            if (Difficulty > 10 && Program.Rng.RandomLessThan(_dunDest) == 0)
            {
                destroyed = true;
            }
            if (Quests.IsQuest(CurrentDepth))
            {
                destroyed = false;
            }
            RowRooms = Level.CurHgt / _blockHgt;
            ColRooms = Level.CurWid / _blockWid;
            for (y = 0; y < RowRooms; y++)
            {
                for (x = 0; x < ColRooms; x++)
                {
                    RoomMap[y][x] = false;
                }
            }
            Crowded = false;
            CentN = 0;
            for (int i = 0; i < _dunRooms; i++)
            {
                y = Program.Rng.RandomLessThan(RowRooms);
                x = Program.Rng.RandomLessThan(ColRooms);
                if (x % 3 == 0)
                {
                    x++;
                }
                if (x % 3 == 2)
                {
                    x--;
                }
                if (destroyed)
                {
                    if (RoomBuild(y, x, new RoomType1()))
                    {
                    }
                    continue;
                }
                if (Program.Rng.RandomLessThan(_dunUnusual) < Difficulty)
                {
                    k = Program.Rng.RandomLessThan(100);
                    if (Program.Rng.RandomLessThan(_dunUnusual) < Difficulty)
                    {
                        if (k < 10)
                        {
                            if (maxVaultOk > 1)
                            {
                                if (RoomBuild(y, x, new RoomType8()))
                                {
                                    continue;
                                }
                            }
                        }
                        if (k < 25)
                        {
                            if (maxVaultOk > 0)
                            {
                                if (RoomBuild(y, x, new RoomType7()))
                                {
                                    continue;
                                }
                            }
                        }
                        if (k < 40 && RoomBuild(y, x, new RoomType5()))
                        {
                            continue;
                        }
                        if (k < 55 && RoomBuild(y, x, new RoomType6()))
                        {
                            continue;
                        }
                    }
                    if (k < 25 && RoomBuild(y, x, new RoomType4()))
                    {
                        continue;
                    }
                    if (k < 50 && RoomBuild(y, x, new RoomType3()))
                    {
                        continue;
                    }
                    if (k < 100 && RoomBuild(y, x, new RoomType2()))
                    {
                        continue;
                    }
                }
                if (RoomBuild(y, x, new RoomType1()))
                {
                }
            }
            for (x = 0; x < Level.CurWid; x++)
            {
                GridTile cPtr = Level.Grid[0][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (x = 0; x < Level.CurWid; x++)
            {
                GridTile cPtr = Level.Grid[Level.CurHgt - 1][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (y = 0; y < Level.CurHgt; y++)
            {
                GridTile cPtr = Level.Grid[y][0];
                cPtr.SetFeature("WallPermSolid");
            }
            for (y = 0; y < Level.CurHgt; y++)
            {
                GridTile cPtr = Level.Grid[y][Level.CurWid - 1];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int i = 0; i < CentN; i++)
            {
                int pick1 = Program.Rng.RandomLessThan(CentN);
                int pick2 = Program.Rng.RandomLessThan(CentN);
                int y1 = Cent[pick1].Y;
                int x1 = Cent[pick1].X;
                Cent[pick1] = Cent[pick2].Clone();
                Cent[pick2] = new GridCoordinate(x1, y1);
            }
            DoorN = 0;
            y = Cent[CentN - 1].Y;
            x = Cent[CentN - 1].X;
            for (int i = 0; i < CentN; i++)
            {
                BuildTunnel(Cent[i].Y, Cent[i].X, y, x);
                y = Cent[i].Y;
                x = Cent[i].X;
            }
            for (int i = 0; i < DoorN; i++)
            {
                y = Door[i].Y;
                x = Door[i].X;
                TryDoor(y, x - 1);
                TryDoor(y, x + 1);
                TryDoor(y - 1, x);
                TryDoor(y + 1, x);
            }
            for (int i = 0; i < _dunStrMag; i++)
            {
                BuildStreamer("Magma", _dunStrMc);
            }
            for (int i = 0; i < _dunStrQua; i++)
            {
                BuildStreamer("Quartz", _dunStrQc);
            }
            if (destroyed)
            {
                DestroyLevel();
            }
            if (emptyLevel && (Program.Rng.DieRoll(_darkEmpty) != 1 ||
                               Program.Rng.DieRoll(100) > Difficulty))
            {
                Level.WizLight();
            }
        }

        private void MakeHenge(int left, int top, int width, int height)
        {
            int midX = left + (width / 2);
            int midY = top + (height / 2);
            for (int y = midY - 3; y < midY + 3; y++)
            {
                Level.Grid[y][midX - 7].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 7].SetFeature("Grass");
            }
            for (int y = midY - 5; y < midY + 5; y++)
            {
                Level.Grid[y][midX - 6].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 6].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                Level.Grid[y][midX - 5].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 5].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                Level.Grid[y][midX - 4].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 4].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                Level.Grid[y][midX - 3].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 3].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                Level.Grid[y][midX - 2].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 2].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                Level.Grid[y][midX - 1].SetBackgroundFeature("Grass");
                Level.Grid[y][midX - 1].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                Level.Grid[y][midX].SetBackgroundFeature("Grass");
                Level.Grid[y][midX].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                Level.Grid[y][midX + 1].SetBackgroundFeature("Grass");
                Level.Grid[y][midX + 1].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                Level.Grid[y][midX + 2].SetBackgroundFeature("Grass");
                Level.Grid[y][midX + 2].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                Level.Grid[y][midX + 3].SetBackgroundFeature("Grass");
                Level.Grid[y][midX + 3].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                Level.Grid[y][midX + 4].SetBackgroundFeature("Grass");
                Level.Grid[y][midX + 4].SetFeature("Grass");
            }
            for (int y = midY - 5; y < midY + 5; y++)
            {
                Level.Grid[y][midX + 5].SetBackgroundFeature("Grass");
                Level.Grid[y][midX + 5].SetFeature("Grass");
            }
            for (int y = midY - 3; y < midY + 3; y++)
            {
                Level.Grid[y][midX + 6].SetBackgroundFeature("Grass");
                Level.Grid[y][midX + 6].SetFeature("Grass");
            }
            Level.Grid[midY - 6][midX].SetFeature("Rock");
            Level.Grid[midY - 6][midX - 1].SetFeature("Rock");
            Level.Grid[midY - 5][midX - 4].SetFeature("Rock");
            Level.Grid[midY - 4][midX - 5].SetFeature("Rock");
            Level.Grid[midY - 1][midX - 6].SetFeature("Rock");
            Level.Grid[midY][midX - 6].SetFeature("Rock");
            Level.Grid[midY + 3][midX - 5].SetFeature("Rock");
            Level.Grid[midY + 4][midX - 4].SetFeature("Rock");
            Level.Grid[midY + 5][midX - 1].SetFeature("Rock");
            Level.Grid[midY + 5][midX].SetFeature("Rock");
            Level.Grid[midY + 4][midX + 3].SetFeature("Rock");
            Level.Grid[midY + 3][midX + 4].SetFeature("Rock");
            Level.Grid[midY][midX + 5].SetFeature("Rock");
            Level.Grid[midY - 1][midX + 5].SetFeature("Rock");
            Level.Grid[midY - 4][midX + 4].SetFeature("Rock");
            Level.Grid[midY - 5][midX + 3].SetFeature("Rock");
        }

        private void MakeLake(int minX, int minY, int width, int height)
        {
            PerlinNoise perlinNoise = new PerlinNoise(Program.Rng.RandomBetween(0, int.MaxValue - 1));
            double widthDivisor = 1 / (double)width;
            double heightDivisor = 1 / (double)height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    GridTile cPtr = Level.Grid[minY + y][minX + x];
                    double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                    v = (v + 1) / 2;
                    double dX = Math.Abs(x - (width / 2)) * widthDivisor;
                    double dY = Math.Abs(y - (height / 2)) * heightDivisor;
                    double d = Math.Max(dX, dY);
                    const double elevation = 0.05;
                    const double steepness = 6.0;
                    const double dropoff = 50.0;
                    v += elevation - (dropoff * Math.Pow(d, steepness));
                    v = Math.Min(1, Math.Max(0, v));
                    int rounded = (int)(v * 10);
                    if (rounded > 3)
                    {
                        cPtr.SetBackgroundFeature("Water");
                        cPtr.SetFeature("Water");
                    }
                    else if (rounded == 3)
                    {
                        cPtr.SetBackgroundFeature("Grass");
                        cPtr.SetFeature("Grass");
                    }
                }
            }
        }

        private void MakeTower(int left, int top, int width, int height, out int stairX, out int stairY)
        {
            int i;
            int y = top + height;
            int x = left + (width / 2);
            stairX = x;
            stairY = y;
            for (i = -2; i < 3; i++)
            {
                Level.Grid[y][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -4; i < 5; i++)
            {
                Level.Grid[y - 1][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 1][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -5; i < 6; i++)
            {
                Level.Grid[y - 2][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 2][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                Level.Grid[y - 3][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 3][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                Level.Grid[y - 4][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 4][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                Level.Grid[y - 5][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 5][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                Level.Grid[y - 6][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 6][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                Level.Grid[y - 7][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 7][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                Level.Grid[y - 8][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 8][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                Level.Grid[y - 9][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 9][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                Level.Grid[y - 10][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 10][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                Level.Grid[y - 11][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 11][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -5; i < 6; i++)
            {
                Level.Grid[y - 12][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 12][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -4; i < 5; i++)
            {
                Level.Grid[y - 13][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 13][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -2; i < 4; i++)
            {
                Level.Grid[y - 14][x + i].SetFeature("WallPermBuilding");
                Level.Grid[y - 14][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            Level.Grid[y][x].SetFeature("UpStair");
            Level.Grid[y][x].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            for (i = -3; i < 4; i++)
            {
                if (Level.Grid[y + 1][x + i].FeatureType.Category == FloorTileTypeCategory.Tree)
                {
                    Level.Grid[y + 1][x + i].RevertToBackground();
                }
            }
            for (i = -2; i < 3; i++)
            {
                if (Level.Grid[y + 2][x + i].FeatureType.Category == FloorTileTypeCategory.Tree)
                {
                    Level.Grid[y + 2][x + i].RevertToBackground();
                }
            }
        }

        private void MakeTownCentre()
        {
            int xx = Level.CurWid / 2;
            int yy = Level.CurHgt / 2;
            switch (Program.Rng.DieRoll(12))
            {
                case 1:
                case 3:
                    Level.Grid[yy - 1][xx - 1].SetFeature("PathBase");
                    Level.Grid[yy][xx - 1].SetFeature("PathBase");
                    Level.Grid[yy + 1][xx - 1].SetFeature("PathBase");
                    Level.Grid[yy - 1][xx].SetFeature("PathBase");
                    Level.Grid[yy + 1][xx].SetFeature("PathBase");
                    Level.Grid[yy - 1][xx + 1].SetFeature("PathBase");
                    Level.Grid[yy][xx + 1].SetFeature("PathBase");
                    Level.Grid[yy + 1][xx + 1].SetFeature("PathBase");
                    switch (Program.Rng.DieRoll(6))
                    {
                        case 4:
                        case 1:
                            Level.Grid[yy][xx].RevertToBackground();
                            break;

                        case 2:
                            Level.Grid[yy][xx].SetFeature("Statue");
                            break;

                        default:
                            Level.Grid[yy][xx].SetFeature("Fountain");
                            break;
                    }
                    return;

                case 2:
                case 8:
                case 9:
                case 12:
                    int x = xx - 1;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        x = xx + 1;
                    }
                    int y = yy - 1;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        y = yy + 1;
                    }
                    Level.Grid[y][x].SetFeature("Signpost");
                    break;

                default:
                    return;
            }
        }

        private void MakeTownContents()
        {
            int x, n;
            int dummy = 0;
            GridTile cPtr;
            int[] rooms = new int[12];
            Program.Rng.UseFixed = true;
            Program.Rng.FixedSeed = CurTown.Seed;
            for (n = 0; n < 12; n++)
            {
                rooms[n] = n;
            }
            int y = Level.CurHgt / 2;
            for (x = 1; x < Level.CurWid - 1; x++)
            {
                Level.Grid[y][x].SetFeature("PathBase");
            }
            x = Level.CurWid / 2;
            for (y = 1; y < Level.CurHgt - 1; y++)
            {
                Level.Grid[y][x].SetFeature("PathBase");
            }
            for (y = 0; y < 4; y++)
            {
                for (x = 0; x < 4; x++)
                {
                    if (x == 1 || x == 2 || y == 1 || y == 2)
                    {
                        int k = Program.Rng.RandomLessThan(n);
                        BuildStore(CurTown.Stores[rooms[k]], y, x);
                        rooms[k] = rooms[--n];
                    }
                    else
                    {
                        switch (Program.Rng.DieRoll(10))
                        {
                            case 3:
                            case 7:
                            case 9:
                                break;

                            default:
                                if (CurTown.Char == 'K')
                                {
                                    BuildGraveyard(y, x);
                                }
                                else
                                {
                                    BuildField(y, x);
                                }
                                break;
                        }
                    }
                }
            }
            for (n = 0; n < Program.Rng.RandomBetween(1, 10) - 6; n++)
            {
                x = Program.Rng.RandomBetween(1, Level.CurWid - 2);
                y = Program.Rng.RandomBetween(1, Level.CurHgt - 2);
                cPtr = Level.Grid[y][x];
                if (cPtr.FeatureType.Name == cPtr.BackgroundFeature.Name)
                {
                    cPtr.SetFeature("Rock");
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
            }
            for (n = 0; n < Program.Rng.RandomBetween(5, 10); n++)
            {
                x = Program.Rng.RandomBetween(1, Level.CurWid - 2);
                y = Program.Rng.RandomBetween(1, Level.CurHgt - 2);
                cPtr = Level.Grid[y][x];
                if (cPtr.FeatureType.Name == cPtr.BackgroundFeature.Name)
                {
                    cPtr.SetFeature("Tree");
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
            }
            for (n = 0; n < Program.Rng.RandomBetween(5, 10); n++)
            {
                x = Program.Rng.RandomBetween(1, Level.CurWid - 2);
                y = Program.Rng.RandomBetween(1, Level.CurHgt - 2);
                cPtr = Level.Grid[y][x];
                if (cPtr.FeatureType.Name == cPtr.BackgroundFeature.Name)
                {
                    cPtr.SetFeature("Bush");
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
            }
            MakeTownCentre();
            x = Level.CurWid / 2;
            cPtr = Level.Grid[0][x];
            cPtr.SetFeature("PathBorderNS");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            x = Level.CurWid - 2;
            y = Level.CurHgt / 2;
            cPtr = Level.Grid[y][x + 1];
            cPtr.SetFeature("PathBorderEW");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            x = Level.CurWid / 2;
            y = Level.CurHgt - 2;
            cPtr = Level.Grid[y + 1][x];
            cPtr.SetFeature("PathBorderNS");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            x = 1;
            y = Level.CurHgt / 2;
            cPtr = Level.Grid[y][0];
            cPtr.SetFeature("PathBorderEW");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            while (dummy < SafeMaxAttempts)
            {
                dummy++;
                y = Program.Rng.RandomBetween(12, 29);
                x = Program.Rng.RandomBetween(17, 46);
                if (Level.GridOpenNoItemOrCreature(y, x))
                {
                    break;
                }
            }
            cPtr = Level.Grid[y][x];
            cPtr.SetFeature("DownStair");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            Program.Rng.UseFixed = false;
            switch (CameFrom)
            {
                case LevelStart.StartRandom:
                    NewPlayerSpot();
                    break;

                case LevelStart.StartStairs:
                    Player.MapY = y;
                    Player.MapX = x;
                    break;

                case LevelStart.StartWalk:
                    break;

                case LevelStart.StartHouse:
                    foreach (Store store in CurTown.Stores)
                    {
                        if (store.StoreType != StoreType.StoreHome)
                        {
                            continue;
                        }
                        Player.MapY = store.Y;
                        Player.MapX = store.X;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MakeTownWalls()
        {
            int x;
            int y;
            GridTile cPtr;
            for (x = 0; x < Level.CurWid; x++)
            {
                cPtr = Level.Grid[0][x];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                cPtr = Level.Grid[Level.CurHgt - 1][x];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            for (y = 0; y < Level.CurHgt; y++)
            {
                cPtr = Level.Grid[y][0];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                cPtr = Level.Grid[y][Level.CurWid - 1];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            Level.Grid[0][(Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[0][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[0][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[0][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[0][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[1][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[1][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[1][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[1][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) - 2].SetFeature("TownWall");
            Level.Grid[0][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) - 1].SetFeature("TownWall");
            Level.Grid[0][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][Level.CurWid / 2].SetFeature("PathBorderNS");
            Level.Grid[0][Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) + 1].SetFeature("TownWall");
            Level.Grid[0][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[0][(Level.CurWid / 2) + 2].SetFeature("TownWall");
            Level.Grid[0][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) - 2].SetFeature("TownWall");
            Level.Grid[1][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) - 1].SetFeature("TownWall");
            Level.Grid[1][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][Level.CurWid / 2].SetFeature("PathBase");
            Level.Grid[1][Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) + 1].SetFeature("TownWall");
            Level.Grid[1][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[1][(Level.CurWid / 2) + 2].SetFeature("TownWall");
            Level.Grid[1][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 2].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 1].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][Level.CurWid / 2].SetFeature("PathBorderNS");
            Level.Grid[Level.CurHgt - 1][Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 1].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 2].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 1][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 2].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 1].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][Level.CurWid / 2].SetFeature("PathBase");
            Level.Grid[Level.CurHgt - 2][Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 1].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 2].SetFeature("TownWall");
            Level.Grid[Level.CurHgt - 2][(Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][0].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][0].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][0].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][0].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][0].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][0].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt / 2][0].SetFeature("PathBorderEW");
            Level.Grid[Level.CurHgt / 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][0].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][0].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt / 2][1].SetFeature("PathBase");
            Level.Grid[Level.CurHgt / 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt / 2][Level.CurWid - 1].SetFeature("PathBorderEW");
            Level.Grid[Level.CurHgt / 2][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 1].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 2].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 2][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 2].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) - 1][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[Level.CurHgt / 2][Level.CurWid - 2].SetFeature("PathBase");
            Level.Grid[Level.CurHgt / 2][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 2].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 1][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 2].SetFeature("TownWall");
            Level.Grid[(Level.CurHgt / 2) + 2][Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
        }

        private void MakeWildernessFeatures(int wildx, int wildy, out int stairX, out int stairY)
        {
            stairX = Level.CurWid / 2;
            stairY = Level.CurHgt / 2;
            if (wildx == 1 || wildx == 10 || wildy == 1 || wildy == 10)
            {
                return;
            }
            int dungeonX = 0;
            int dungeonY = 0;
            switch (Program.Rng.DieRoll(4))
            {
                case 1:
                    dungeonX = 0;
                    dungeonY = 0;
                    break;

                case 2:
                    dungeonX = Level.CurWid / 2;
                    dungeonY = 0;
                    break;

                case 3:
                    dungeonX = 0;
                    dungeonY = Level.CurHgt / 2;
                    break;

                case 4:
                    dungeonX = Level.CurWid / 2;
                    dungeonY = Level.CurHgt / 2;
                    break;
            }
            for (int offsetX = 0; offsetX < Level.CurWid - 1; offsetX += Level.CurWid / 2)
            {
                for (int offsetY = 0; offsetY < Level.CurHgt - 1; offsetY += Level.CurHgt / 2)
                {
                    if (offsetX == dungeonX && offsetY == dungeonY)
                    {
                        if (Wilderness[wildy][wildx].Dungeon != null)
                        {
                            if (Wilderness[wildy][wildx].Dungeon.Tower)
                            {
                                MakeTower(offsetX + 4, offsetY + 4, (Level.CurWid / 2) - 8, (Level.CurHgt / 2) - 8, out int x, out int y);
                                stairX = x;
                                stairY = y;
                            }
                            else
                            {
                                MakeDungeonEntrance(offsetX + 4, offsetY + 4, (Level.CurWid / 2) - 8, (Level.CurHgt / 2) - 8, out int x, out int y);
                                stairX = x;
                                stairY = y;
                            }
                        }
                    }
                    else
                    {
                        switch (Program.Rng.DieRoll(30))
                        {
                            case 7:
                            case 22:
                                MakeLake(offsetX + 4, offsetY + 4, (Level.CurWid / 2) - 8, (Level.CurHgt / 2) - 8);
                                break;

                            case 15:
                                MakeHenge(offsetX + 4, offsetY + 4, (Level.CurWid / 2) - 8, (Level.CurHgt / 2) - 8);
                                break;
                        }
                    }
                }
            }
        }

        private void MakeWildernessPaths(int wildx, int wildy)
        {
            int x;
            int y;

            int midX = Level.CurWid / 2;
            int midY = Level.CurHgt / 2;
            if (Wilderness[wildy][wildx].RoadMap == 0)
            {
                return;
            }
            Level.Grid[midY - 1][midX - 1].SetFeature("Grass");
            Level.Grid[midY - 1][midX].SetFeature("Grass");
            Level.Grid[midY - 1][midX + 1].SetFeature("Grass");
            Level.Grid[midY][midX - 1].SetFeature("Grass");
            Level.Grid[midY][midX].SetFeature("PathBase");
            Level.Grid[midY][midX + 1].SetFeature("Grass");
            Level.Grid[midY + 1][midX - 1].SetFeature("Grass");
            Level.Grid[midY + 1][midX].SetFeature("Grass");
            Level.Grid[midY + 1][midX + 1].SetFeature("Grass");
            if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadUp) != 0)
            {
                x = 0;
                Level.Grid[0][midX].SetFeature("PathBorderNS");
                Level.Grid[1][midX].SetFeature("PathBase");
                Level.Grid[midY - 1][midX].SetFeature("PathBase");
                for (y = 2; y < midY - 1; y++)
                {
                    x += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (x > midY - 1 - y)
                    {
                        x = midY - 1 - y;
                    }
                    if (x < -(midY - 1 - y))
                    {
                        x = -(midY - 1 - y);
                    }
                    if (!Level.Grid[y][midX - 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[y][midX - 1 + x].SetFeature("Grass");
                    }
                    Level.Grid[y][midX + x].SetFeature("WildPathNS");
                    if (!Level.Grid[y][midX + 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[y][midX + 1 + x].SetFeature("Grass");
                    }
                }
            }
            if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadDown) != 0)
            {
                x = 0;
                Level.Grid[Level.CurHgt - 1][midX].SetFeature("PathBorderNS");
                Level.Grid[Level.CurHgt - 2][midX].SetFeature("PathBase");
                Level.Grid[midY + 1][midX].SetFeature("PathBase");
                for (y = Level.CurHgt - 3; y > midY + 1; y--)
                {
                    x += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (x > y - (midY + 1))
                    {
                        x = y - (midY + 1);
                    }
                    if (x < -(y - (midY + 1)))
                    {
                        x = -(y - (midY + 1));
                    }
                    if (!Level.Grid[y][midX - 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[y][midX - 1 + x].SetFeature("Grass");
                    }
                    Level.Grid[y][midX + x].SetFeature("WildPathNS");
                    if (!Level.Grid[y][midX + 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[y][midX + 1 + x].SetFeature("Grass");
                    }
                }
            }
            if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadLeft) != 0)
            {
                y = 0;
                Level.Grid[midY][0].SetFeature("PathBorderEW");
                Level.Grid[midY][1].SetFeature("PathBase");
                Level.Grid[midY][midX - 1].SetFeature("PathBase");
                for (x = 2; x < midX - 1; x++)
                {
                    y += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (y > midX - 1 - x)
                    {
                        y = midX - 1 - x;
                    }
                    if (y < -(midX - 1 - x))
                    {
                        y = -(midX - 1 - x);
                    }
                    if (!Level.Grid[midY - 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[midY - 1 + y][x].SetFeature("Grass");
                    }
                    Level.Grid[midY + y][x].SetFeature("WildPathEW");
                    if (!Level.Grid[midY + 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[midY + 1 + y][x].SetFeature("Grass");
                    }
                }
            }
            if ((Wilderness[wildy][wildx].RoadMap & Constants.RoadRight) != 0)
            {
                y = 0;
                Level.Grid[midY][Level.CurWid - 1].SetFeature("PathBorderEW");
                Level.Grid[midY][Level.CurWid - 2].SetFeature("PathBase");
                Level.Grid[midY][midX + 1].SetFeature("PathBase");
                for (x = Level.CurWid - 3; x > midX + 1; x--)
                {
                    y += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (y > x - (midX + 1))
                    {
                        y = x - (midX + 1);
                    }
                    if (y < -(x - (midX + 1)))
                    {
                        y = -(x - (midX + 1));
                    }
                    if (!Level.Grid[midY - 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[midY - 1 + y][x].SetFeature("Grass");
                    }
                    Level.Grid[midY + y][x].SetFeature("WildPathEW");
                    if (!Level.Grid[midY + 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        Level.Grid[midY + 1 + y][x].SetFeature("Grass");
                    }
                }
            }
        }

        private void MakeWildernessWalls(int wildX, int wildY)
        {
            Island wilderness = Wilderness;
            int height = Level.CurHgt;
            int width = Level.CurWid;
            if (wilderness[wildY - 1][wildX].Town != null)
            {
                for (int x = 0; x < width; x++)
                {
                    Level.Grid[0][x].SetFeature("TownWall");
                    Level.Grid[0][x].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                Level.Grid[0][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[0][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) - 2].SetFeature("TownWall");
                Level.Grid[0][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) - 1].SetFeature("TownWall");
                Level.Grid[0][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][width / 2].SetFeature("PathBorderNS");
                Level.Grid[0][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) + 1].SetFeature("TownWall");
                Level.Grid[0][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[0][(width / 2) + 2].SetFeature("TownWall");
                Level.Grid[0][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) - 2].SetFeature("TownWall");
                Level.Grid[1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) - 1].SetFeature("TownWall");
                Level.Grid[1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][width / 2].SetFeature("PathBase");
                Level.Grid[1][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) + 1].SetFeature("TownWall");
                Level.Grid[1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[1][(width / 2) + 2].SetFeature("TownWall");
                Level.Grid[1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if (wilderness[wildY + 1][wildX].Town != null)
            {
                for (int x = 0; x < width; x++)
                {
                    Level.Grid[height - 1][x].SetFeature("TownWall");
                    Level.Grid[height - 1][x].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                Level.Grid[height - 1][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[height - 2][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) - 2].SetFeature("TownWall");
                Level.Grid[height - 1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) - 1].SetFeature("TownWall");
                Level.Grid[height - 1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][width / 2].SetFeature("PathBorderNS");
                Level.Grid[height - 1][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) + 1].SetFeature("TownWall");
                Level.Grid[height - 1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 1][(width / 2) + 2].SetFeature("TownWall");
                Level.Grid[height - 1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) - 2].SetFeature("TownWall");
                Level.Grid[height - 2][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) - 1].SetFeature("TownWall");
                Level.Grid[height - 2][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][width / 2].SetFeature("PathBase");
                Level.Grid[height - 2][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) + 1].SetFeature("TownWall");
                Level.Grid[height - 2][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height - 2][(width / 2) + 2].SetFeature("TownWall");
                Level.Grid[height - 2][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if (wilderness[wildY][wildX - 1].Town != null)
            {
                for (int y = 0; y < height; y++)
                {
                    Level.Grid[y][0].SetFeature("TownWall");
                    Level.Grid[y][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                Level.Grid[(height / 2) - 2][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][0].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 2][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 2][0].SetFeature("TownWall");
                Level.Grid[(height / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][0].SetFeature("TownWall");
                Level.Grid[(height / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height / 2][0].SetFeature("PathBorderEW");
                Level.Grid[height / 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][0].SetFeature("TownWall");
                Level.Grid[(height / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][0].SetFeature("TownWall");
                Level.Grid[(height / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 2][1].SetFeature("TownWall");
                Level.Grid[(height / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][1].SetFeature("TownWall");
                Level.Grid[(height / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height / 2][1].SetFeature("PathBase");
                Level.Grid[height / 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][1].SetFeature("TownWall");
                Level.Grid[(height / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][1].SetFeature("TownWall");
                Level.Grid[(height / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if (wilderness[wildY][wildX + 1].Town != null)
            {
                for (int y = 0; y < height; y++)
                {
                    Level.Grid[y][width - 1].SetFeature("TownWall");
                    Level.Grid[y][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                Level.Grid[(height / 2) - 2][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][width - 1].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 2][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][width - 2].SetBackgroundFeature("InsideGatehouse");
                Level.Grid[(height / 2) + 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 2][width - 1].SetFeature("TownWall");
                Level.Grid[(height / 2) - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][width - 1].SetFeature("TownWall");
                Level.Grid[(height / 2) - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height / 2][width - 1].SetFeature("PathBorderEW");
                Level.Grid[height / 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][width - 1].SetFeature("TownWall");
                Level.Grid[(height / 2) + 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][width - 1].SetFeature("TownWall");
                Level.Grid[(height / 2) + 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 2][width - 2].SetFeature("TownWall");
                Level.Grid[(height / 2) - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) - 1][width - 2].SetFeature("TownWall");
                Level.Grid[(height / 2) - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[height / 2][width - 2].SetFeature("PathBase");
                Level.Grid[height / 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 1][width - 2].SetFeature("TownWall");
                Level.Grid[(height / 2) + 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                Level.Grid[(height / 2) + 2][width - 2].SetFeature("TownWall");
                Level.Grid[(height / 2) + 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
        }

        private bool NewPlayerSpot()
        {
            int y = 0;
            int x = 0;
            int maxAttempts = 5000;
            while (maxAttempts-- != 0)
            {
                y = Program.Rng.RandomBetween(1, Level.CurHgt - 2);
                x = Program.Rng.RandomBetween(1, Level.CurWid - 2);
                if (!Level.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (Level.Grid[y][x].TileFlags.IsSet(GridTile.InVault))
                {
                    continue;
                }
                break;
            }
            if (maxAttempts < 1)
            {
                return false;
            }
            Player.MapY = y;
            Player.MapX = x;
            return true;
        }

        private int NextToCorr(int y1, int x1)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                int y = y1 + Level.OrderedDirectionYOffset[i];
                int x = x1 + Level.OrderedDirectionXOffset[i];
                if (!Level.GridPassable(y, x))
                {
                    continue;
                }
                GridTile cPtr = Level.Grid[y][x];
                if (!cPtr.FeatureType.IsOpenFloor)
                {
                    continue;
                }
                if (cPtr.TileFlags.IsSet(GridTile.InRoom))
                {
                    continue;
                }
                k++;
            }
            return k;
        }

        private int NextToWalls(int y, int x)
        {
            int k = 0;
            if (Level.Grid[y + 1][x].FeatureType.IsWall)
            {
                k++;
            }
            if (Level.Grid[y - 1][x].FeatureType.IsWall)
            {
                k++;
            }
            if (Level.Grid[y][x + 1].FeatureType.IsWall)
            {
                k++;
            }
            if (Level.Grid[y][x - 1].FeatureType.IsWall)
            {
                k++;
            }
            return k;
        }

        private void PlaceRandomDoor(int y, int x)
        {
            GridTile cPtr = Level.Grid[y][x];
            int tmp = Program.Rng.RandomLessThan(1000);
            if (tmp < 300)
            {
                cPtr.SetFeature("OpenDoor");
            }
            else if (tmp < 400)
            {
                cPtr.SetFeature("BrokenDoor");
            }
            else if (tmp < 600)
            {
                cPtr.SetFeature("SecretDoor");
            }
            else if (tmp < 900)
            {
                cPtr.SetFeature("LockedDoor0");
            }
            else if (tmp < 999)
            {
                cPtr.SetFeature($"LockedDoor{Program.Rng.DieRoll(7)}");
            }
            else
            {
                cPtr.SetFeature($"JammedDoor{Program.Rng.RandomLessThan(8)}");
            }
        }

        private void PlaceRubble(int y, int x)
        {
            GridTile cPtr = Level.Grid[y][x];
            cPtr.SetFeature("Rubble");
        }

        private bool PossibleDoorway(int y, int x)
        {
            if (NextToCorr(y, x) >= 2)
            {
                if (Level.Grid[y - 1][x].FeatureType.IsWall &&
                    Level.Grid[y + 1][x].FeatureType.IsWall)
                {
                    return true;
                }
                if (Level.Grid[y][x - 1].FeatureType.IsWall &&
                    Level.Grid[y][x + 1].FeatureType.IsWall)
                {
                    return true;
                }
            }
            return false;
        }

        private void RandDir(out int rdir, out int cdir)
        {
            int i = Program.Rng.RandomLessThan(4);
            rdir = Level.OrderedDirectionYOffset[i];
            cdir = Level.OrderedDirectionXOffset[i];
        }

        private void ResolvePaths()
        {
            for (int x = 1; x < Level.CurWid - 1; x++)
            {
                for (int y = 1; y < Level.CurHgt - 1; y++)
                {
                    if (Level.Grid[y][x].FeatureType.Name != "PathBase")
                    {
                        continue;
                    }
                    int map = 0;
                    if (Level.Grid[y - 1][x].FeatureType.Name.StartsWith("Path"))
                    {
                        map++;
                    }
                    if (Level.Grid[y][x + 1].FeatureType.Name.StartsWith("Path"))
                    {
                        map += 2;
                    }
                    if (Level.Grid[y + 1][x].FeatureType.Name.StartsWith("Path"))
                    {
                        map += 4;
                    }
                    if (Level.Grid[y][x - 1].FeatureType.Name.StartsWith("Path"))
                    {
                        map += 8;
                    }
                    switch (map)
                    {
                        case 1:
                        case 4:
                        case 5:
                            Level.Grid[y][x].SetFeature("PathNS");
                            break;

                        case 2:
                        case 8:
                        case 10:
                            Level.Grid[y][x].SetFeature("PathEW");
                            break;

                        default:
                            Level.Grid[y][x].SetFeature("PathJunction");
                            break;
                    }
                }
            }
        }

        private bool RoomBuild(int y0, int x0, RoomType roomType)
        {
            if (Difficulty < _room[roomType.Type].Level)
            {
                return false;
            }
            if (Crowded && (roomType.Type == 5 || roomType.Type == 6))
            {
                return false;
            }
            int y1 = y0 + _room[roomType.Type].Dy1;
            int y2 = y0 + _room[roomType.Type].Dy2;
            int x1 = x0 + _room[roomType.Type].Dx1;
            int x2 = x0 + _room[roomType.Type].Dx2;
            if (y1 < 0 || y2 >= RowRooms)
            {
                return false;
            }
            if (x1 < 0 || x2 >= ColRooms)
            {
                return false;
            }
            int y;
            int x;
            for (y = y1; y <= y2; y++)
            {
                for (x = x1; x <= x2; x++)
                {
                    if (RoomMap[y][x])
                    {
                        return false;
                    }
                }
            }
            y = (y1 + y2 + 1) * _blockHgt / 2;
            x = (x1 + x2 + 1) * _blockWid / 2;
            roomType.Build(this, y, x);
            if (CentN < CentMax)
            {
                Cent[CentN] = new GridCoordinate(x, y);
                CentN++;
            }
            for (y = y1; y <= y2; y++)
            {
                for (x = x1; x <= x2; x++)
                {
                    RoomMap[y][x] = true;
                }
            }
            if (roomType.Type == 5 || roomType.Type == 6)
            {
                Crowded = true;
            }
            return true;
        }

        private void TownGen()
        {
            int i, y, x;
            GridTile cPtr;
            for (y = 0; y < Level.CurHgt; y++)
            {
                for (x = 0; x < Level.CurWid; x++)
                {
                    cPtr = Level.Grid[y][x];
                    cPtr.RevertToBackground();
                }
            }
            MakeTownWalls();
            MakeCornerTowers(Player.WildernessX, Player.WildernessY);
            MakeTownContents();
            ResolvePaths();
            if (Player.GameTime.IsLight)
            {
                for (y = 0; y < Level.CurHgt; y++)
                {
                    for (x = 0; x < Level.CurWid; x++)
                    {
                        cPtr = Level.Grid[y][x];
                        cPtr.TileFlags.Set(GridTile.SelfLit);
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                    }
                }
                for (i = 0; i < Constants.MinMAllocTd; i++)
                {
                    Level.Monsters.AllocMonster(3, true);
                }
            }
            else
            {
                for (i = 0; i < Constants.MinMAllocTn; i++)
                {
                    Level.Monsters.AllocMonster(3, true);
                }
            }
        }

        private void TryDoor(int y, int x)
        {
            if (!Level.InBounds(y, x))
            {
                return;
            }
            if (Level.Grid[y][x].FeatureType.IsWall)
            {
                return;
            }
            if (Level.Grid[y][x].TileFlags.IsSet(GridTile.InRoom))
            {
                return;
            }
            if (Program.Rng.RandomLessThan(100) < _dunTunJct && PossibleDoorway(y, x))
            {
                PlaceRandomDoor(y, x);
            }
        }

        private bool UndergroundGen()
        {
            int i;
            int k;
            ResetGuardians();
            if (Quests.IsQuest(CurrentDepth))
            {
                SingletonRepository.MonsterRaces[Quests.GetQuestMonster()].Guardian = true;
            }
            if (Program.Rng.PercentileRoll(4) && !CurDungeon.Tower)
            {
                MakeCavernLevel();
            }
            else
            {
                MakeDungeonLevel();
            }
            AllocStairs("DownStair", Program.Rng.RandomBetween(3, 4), 3);
            AllocStairs("UpStair", Program.Rng.RandomBetween(1, 2), 3);
            if (!NewPlayerSpot())
            {
                return false;
            }
            k = Difficulty / 3;
            if (k > 10)
            {
                k = 10;
            }
            if (k < 2)
            {
                k = 2;
            }
            if (Quests.IsQuest(CurrentDepth))
            {
                int rIdx = Quests.GetQuestMonster();
                int qIdx = Quests.GetQuestNumber();
                while (SingletonRepository.MonsterRaces[rIdx].CurNum < (Quests[qIdx].ToKill - Quests[qIdx].Killed))
                {
                    Level.PutQuestMonster(Quests[qIdx].RIdx);
                }
            }
            i = Constants.MinMAllocLevel;
            if (Level.CurHgt < Level.MaxHgt || Level.CurWid < Level.MaxWid)
            {
                int smallTester = i;
                i = i * Level.CurHgt / Level.MaxHgt;
                i = i * Level.CurWid / Level.MaxWid;
                i++;
                if (i > smallTester)
                {
                    i = smallTester;
                }
            }
            i += Program.Rng.DieRoll(8);
            for (i += k; i > 0; i--)
            {
                Level.Monsters.AllocMonster(0, true);
            }
            AllocObject(_allocSetBoth, _allocTypTrap, Program.Rng.DieRoll(k));
            AllocObject(_allocSetCorr, _allocTypRubble, Program.Rng.DieRoll(k));
            AllocObject(_allocSetRoom, _allocTypObject, Program.Rng.RandomNormal(_dunAmtRoom, 3));
            AllocObject(_allocSetBoth, _allocTypObject, Program.Rng.RandomNormal(_dunAmtItem, 3));
            AllocObject(_allocSetBoth, _allocTypGold, Program.Rng.RandomNormal(_dunAmtGold, 3));
            return true;
        }

        private void WildernessGen()
        {
            Program.Rng.UseFixed = true;
            Program.Rng.FixedSeed = Wilderness[Player.WildernessY][Player.WildernessX].Seed;
            Island island = Wilderness;
            Player player = Player;
            int x;
            int y;
            for (y = 0; y < Level.CurHgt; y++)
            {
                for (x = 0; x < Level.CurWid; x++)
                {
                    byte elevation = island.Elevation(player.WildernessY, player.WildernessX, y, x);
                    string floorName = "Water";
                    string featureName = "Water";
                    if (elevation > 0)
                    {
                        floorName = "Grass";
                        if (Program.Rng.DieRoll(10) < elevation)
                        {
                            if (Program.Rng.DieRoll(10) < elevation)
                            {
                                featureName = "Tree";
                            }
                            else
                            {
                                featureName = "Bush";
                            }
                        }
                        else
                        {
                            featureName = "Grass";
                        }
                    }
                    Level.Grid[y][x].SetFeature(featureName);
                    Level.Grid[y][x].SetBackgroundFeature(floorName);
                }
            }
            for (x = 0; x < Level.CurWid; x++)
            {
                GridTile cPtr = Level.Grid[0][x];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
                cPtr = Level.Grid[Level.CurHgt - 1][x];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
            }
            for (y = 0; y < Level.CurHgt; y++)
            {
                GridTile cPtr = Level.Grid[y][0];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
                cPtr = Level.Grid[y][Level.CurWid - 1];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
            }
            MakeWildernessWalls(Player.WildernessX, Player.WildernessY);
            MakeCornerTowers(Player.WildernessX, Player.WildernessY);
            MakeWildernessPaths(Player.WildernessX, Player.WildernessY);
            MakeWildernessFeatures(Player.WildernessX, Player.WildernessY, out int stairX, out int stairY);
            int rocks = Program.Rng.RandomBetween(1, 10);
            for (int i = 0; i < rocks; i++)
            {
                x = Program.Rng.DieRoll(Level.CurWid - 2);
                y = Program.Rng.DieRoll(Level.CurHgt - 2);
                if (Level.Grid[y][x].FeatureType.Name != "Grass")
                {
                    continue;
                }
                Level.Grid[y][x].SetFeature("Rock");
            }
            Program.Rng.UseFixed = false;
            if (CameFrom == LevelStart.StartRandom)
            {
                NewPlayerSpot();
            }
            else if (CameFrom == LevelStart.StartStairs)
            {
                Player.MapY = stairY;
                Player.MapX = stairX;
            }
            else if (CameFrom == LevelStart.StartWalk)
            {
                if (Level.Grid[Player.MapY][Player.MapX].FeatureType.Category == FloorTileTypeCategory.Tree ||
                    Level.Grid[Player.MapY][Player.MapX].FeatureType.Name == "Water")
                {
                    Level.Grid[Player.MapY][Player.MapX].RevertToBackground();
                }
            }
            ResolvePaths();
            for (y = 1; y < Level.CurHgt - 1; y++)
            {
                for (x = 1; x < Level.CurWid - 1; x++)
                {
                    if (Level.Grid[y][x].FeatureType.IsOpenFloor)
                    {
                        Level.Grid[y][x].TileFlags.Set(GridTile.InRoom);
                    }
                }
            }
            if (Player.GameTime.IsLight)
            {
                for (y = 0; y < Level.CurHgt; y++)
                {
                    for (x = 0; x < Level.CurWid; x++)
                    {
                        Level.Grid[y][x].TileFlags.Set(GridTile.SelfLit);
                        Level.Grid[y][x].TileFlags.Set(GridTile.PlayerMemorised);
                    }
                }
            }
            for (x = 0; x < Constants.MinMAllocLevel; x++)
            {
                Level.Monsters.AllocMonster(3, true);
            }
            ///LEVEL FACTORY
        }

        public bool GetDirectionNoAim(out int dp)
        {
            dp = 0;
            int dir = CommandDirection;
            while (dir == 0)
            {
                if (!GetCom("Direction (Escape to cancel)? ", out char ch))
                {
                    break;
                }
                dir = GetKeymapDir(ch);
            }
            if (dir == 5)
            {
                dir = 0;
            }
            if (dir == 0)
            {
                return false;
            }
            CommandDirection = dir;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                if (Program.Rng.RandomLessThan(100) < 75)
                {
                    dir = Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
                }
            }
            if (CommandDirection != dir)
            {
                MsgPrint("You are confused.");
            }
            dp = dir;
            return true;
        }

        public void GetDirectionNoAutoAim(out int dp)
        {
            dp = 0;
            int dir = 0;
            while (dir == 0)
            {
                string p = !TargetOkay()
                    ? "Direction ('*' to choose a target, Escape to cancel)? "
                    : "Direction ('5' for target, '*' to re-target, Escape to cancel)? ";
                if (!GetCom(p, out char command))
                {
                    break;
                }
                switch (command)
                {
                    case 'T':
                    case 't':
                    case '.':
                    case '5':
                    case '0':
                        {
                            dir = 5;
                            break;
                        }
                    case '*':
                        {
                            if (TargetSet(Constants.TargetKill))
                            {
                                dir = 5;
                            }
                            break;
                        }
                    default:
                        {
                            dir = GetKeymapDir(command);
                            break;
                        }
                }
                if (dir == 5 && !TargetOkay())
                {
                    dir = 0;
                }
            }
            if (dir == 0)
            {
                return;
            }
            CommandDirection = dir;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                dir = Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
            }
            if (CommandDirection != dir)
            {
                MsgPrint("You are confused.");
            }
            dp = dir;
        }

        public bool GetDirectionWithAim(out int dp)
        {
            dp = 0;
            int dir = CommandDirection;
            if (TargetOkay())
            {
                dir = 5;
            }
            while (dir == 0)
            {
                string p = !TargetOkay()
                    ? "Direction ('*' to choose a target, Escape to cancel)? "
                    : "Direction ('5' for target, '*' to re-target, Escape to cancel)? ";
                if (!GetCom(p, out char command))
                {
                    break;
                }
                switch (command)
                {
                    case 'T':
                    case 't':
                    case '.':
                    case '5':
                    case '0':
                        {
                            dir = 5;
                            break;
                        }
                    case '*':
                        {
                            if (TargetSet(Constants.TargetKill))
                            {
                                dir = 5;
                            }
                            break;
                        }
                    default:
                        {
                            dir = GetKeymapDir(command);
                            break;
                        }
                }
                if (dir == 5 && !TargetOkay())
                {
                    dir = 0;
                }
            }
            if (dir == 0)
            {
                return false;
            }
            CommandDirection = dir;
            if (Player.TimedConfusion.TurnsRemaining != 0)
            {
                dir = Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
            }
            if (CommandDirection != dir)
            {
                MsgPrint("You are confused.");
            }
            dp = dir;
            return true;
        }

        public bool TargetOkay()
        {
            if (TargetWho < 0)
            {
                return true;
            }
            if (TargetWho <= 0)
            {
                return false;
            }
            if (!TargetAble(TargetWho))
            {
                return false;
            }
            Monster mPtr = Level.Monsters[TargetWho];
            TargetRow = mPtr.MapY;
            TargetCol = mPtr.MapX;
            return true;
        }

        public bool TargetSet(int mode)
        {
            int y = Player.MapY;
            int x = Player.MapX;
            bool done = false;
            TargetWho = 0;
            TargetSetPrepare(mode);
            int m = 0;
            if (Level.TempN != 0)
            {
                y = Level.TempY[m];
                x = Level.TempX[m];
            }
            while (!done)
            {
                GridTile cPtr = Level.Grid[y][x];
                string info = TargetAble(cPtr.MonsterIndex) ? "t,T,*" : "T,*";
                char query = TargetSetAux(y, x, mode | Constants.TargetLook, info);
                switch (query)
                {
                    case '\x1b':
                        {
                            done = true;
                            break;
                        }
                    case 't':
                        {
                            if (TargetAble(cPtr.MonsterIndex))
                            {
                                HealthTrack(cPtr.MonsterIndex);
                                TargetWho = cPtr.MonsterIndex;
                                TargetRow = y;
                                TargetCol = x;
                                done = true;
                            }
                            break;
                        }
                    case 'T':
                        TargetWho = -1;
                        TargetRow = y;
                        TargetCol = x;
                        done = true;
                        break;

                    case '*':
                        {
                            if (x == Level.TempX[m] && y == Level.TempY[m])
                            {
                                if (++m >= Level.TempN)
                                {
                                    m = 0;
                                    done = true;
                                }
                                else
                                {
                                    y = Level.TempY[m];
                                    x = Level.TempX[m];
                                }
                            }
                            else
                            {
                                y = Level.TempY[m];
                                x = Level.TempX[m];
                            }
                            break;
                        }
                    default:
                        {
                            int d = GetKeymapDir(query);
                            if (d != 0)
                            {
                                x += Level.KeypadDirectionXOffset[d];
                                y += Level.KeypadDirectionYOffset[d];
                                if (x >= Level.CurWid - 1 || x > Level.PanelColMax)
                                {
                                    x--;
                                }
                                else if (x <= 0 || x < Level.PanelColMin)
                                {
                                    x++;
                                }
                                if (y >= Level.CurHgt - 1 || y > Level.PanelRowMax)
                                {
                                    y--;
                                }
                                else if (y <= 0 || y < Level.PanelRowMin)
                                {
                                    y++;
                                }
                            }
                            break;
                        }
                }
            }
            Level.TempN = 0;
            Screen.PrintLine("", 0, 0);
            return TargetWho != 0;
        }

        public bool TgtPt(out int x, out int y)
        {
            char ch = '\0';
            bool success = false;
            x = Player.MapX;
            y = Player.MapY;
            bool cv = Screen.CursorVisible;
            Screen.CursorVisible = true;
            MsgPrint("Select a point and press space.");
            while (ch != 27 && ch != ' ' && !Shutdown)
            {
                Level.MoveCursorRelative(y, x);
                ch = Inkey();
                switch (ch)
                {
                    case '\x1b':
                        break;

                    case ' ':
                        success = true;
                        break;

                    default:
                        {
                            int d = GetKeymapDir(ch);
                            if (d == 0)
                            {
                                break;
                            }
                            x += Level.KeypadDirectionXOffset[d];
                            y += Level.KeypadDirectionYOffset[d];
                            if (x >= Level.CurWid - 1 || x >= Level.PanelColMin + Constants.ScreenWid)
                            {
                                x--;
                            }
                            else if (x <= 0 || x <= Level.PanelColMin)
                            {
                                x++;
                            }
                            if (y >= Level.CurHgt - 1 || y >= Level.PanelRowMin + Constants.ScreenHgt)
                            {
                                y--;
                            }
                            else if (y <= 0 || y <= Level.PanelRowMin)
                            {
                                y++;
                            }
                            break;
                        }
                }
            }
            Screen.CursorVisible = cv;
            UpdateScreen();
            return success;
        }

        private string LookMonDesc(int mIdx)
        {
            Monster mPtr = Level.Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            bool living = !rPtr.Undead;
            if (rPtr.Demon)
            {
                living = false;
            }
            if (rPtr.Cthuloid)
            {
                living = false;
            }
            if (rPtr.Nonliving)
            {
                living = false;
            }
            if ("Egv".Contains(rPtr.Character.ToString()))
            {
                living = false;
            }
            if (mPtr.Health >= mPtr.MaxHealth)
            {
                return living ? "unhurt" : "undamaged";
            }
            int perc = 100 * mPtr.Health / mPtr.MaxHealth;
            if (perc >= 60)
            {
                return living ? "somewhat wounded" : "somewhat damaged";
            }
            if (perc >= 25)
            {
                return living ? "wounded" : "damaged";
            }
            if (perc >= 10)
            {
                return living ? "badly wounded" : "badly damaged";
            }
            return living ? "almost dead" : "almost destroyed";
        }

        private bool TargetAble(int mIdx)
        {
            Monster mPtr = Level.Monsters[mIdx];
            if (mPtr.Race == null)
            {
                return false;
            }
            if (!mPtr.IsVisible)
            {
                return false;
            }
            if (!Level.Projectable(Player.MapY, Player.MapX, mPtr.MapY, mPtr.MapX))
            {
                return false;
            }
            if (Player.TimedHallucinations.TurnsRemaining != 0)
            {
                return false;
            }
            return true;
        }

        private bool TargetSetAccept(int y, int x)
        {
            int nextOIdx;
            if (y == Player.MapY && x == Player.MapX)
            {
                return true;
            }
            if (Player.TimedHallucinations.TurnsRemaining != 0)
            {
                return false;
            }
            GridTile cPtr = Level.Grid[y][x];
            if (cPtr.MonsterIndex != 0)
            {
                Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
                if (mPtr.IsVisible)
                {
                    return true;
                }
            }
            for (int thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item oPtr = Level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                if (oPtr.Marked)
                {
                    return true;
                }
            }
            if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
            {
                return cPtr.FeatureType.IsInteresting;
            }
            return false;
        }

        private char TargetSetAux(int y, int x, int mode, string info)
        {
            GridTile cPtr = Level.Grid[y][x];
            char query;
            do
            {
                query = ' ';
                bool boring = true;
                string s1 = "You see ";
                string s2 = "";
                string s3 = "";
                if (y == Player.MapY && x == Player.MapX)
                {
                    s1 = "You are ";
                    s2 = "on ";
                }
                string outVal;
                if (Player.TimedHallucinations.TurnsRemaining != 0)
                {
                    const string name = "something strange";
                    outVal = $"{s1}{s2}{s3}{name} [{info}]";
                    Screen.PrintLine(outVal, 0, 0);
                    Level.MoveCursorRelative(y, x);
                    query = Inkey();
                    if (!Shutdown)
                    {
                        break;
                    }

                    if (query != '\r' && query != '\n')
                    {
                        break;
                    }
                    continue;
                }
                int thisOIdx;
                int nextOIdx;
                if (cPtr.MonsterIndex != 0)
                {
                    Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
                    MonsterRace rPtr = mPtr.Race;
                    if (mPtr.IsVisible)
                    {
                        bool recall = false;
                        boring = false;
                        string mName = mPtr.IndefinitionWhenVisibleName;
                        HealthTrack(cPtr.MonsterIndex);
                        HandleStuff();
                        while (true && !Shutdown)
                        {
                            if (recall)
                            {
                                ScreenBuffer savedScreen = Screen.Clone();
                                rPtr.Knowledge.Display();
                                Screen.Print(Colour.White, $"  [r,{info}]");
                                query = Inkey();
                                Screen.Restore(savedScreen);
                            }
                            else
                            {
                                string c = mPtr.SmCloned ? " (clone)" : "";
                                string a = mPtr.SmFriendly ? " (allied) " : " ";
                                outVal = $"{s1}{s2}{s3}{mName} ({LookMonDesc(cPtr.MonsterIndex)}){c}{a}[r,{info}]";
                                Screen.PrintLine(outVal, 0, 0);
                                Level.MoveCursorRelative(y, x);
                                query = Inkey();
                            }
                            if (query != 'r')
                            {
                                break;
                            }
                            recall = !recall;
                        }
                        if (query != '\r' && query != '\n' && query != ' ')
                        {
                            break;
                        }
                        if (query == ' ' && (mode & Constants.TargetLook) == 0)
                        {
                            break;
                        }
                        s1 = "It is ";
                        if (rPtr.Female)
                        {
                            s1 = "She is ";
                        }
                        else if (rPtr.Male)
                        {
                            s1 = "He is ";
                        }
                        s2 = "carrying ";
                        for (thisOIdx = mPtr.FirstHeldItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
                        {
                            Item oPtr = Level.Items[thisOIdx];
                            nextOIdx = oPtr.NextInStack;
                            string oName = oPtr.Description(true, 3);
                            outVal = $"{s1}{s2}{s3}{oName} [{info}]";
                            Screen.PrintLine(outVal, 0, 0);
                            Level.MoveCursorRelative(y, x);
                            query = Inkey();
                            if (query != '\r' && query != '\n' && query != ' ')
                            {
                                break;
                            }
                            if (query == ' ' && (mode & Constants.TargetLook) == 0)
                            {
                                break;
                            }
                            s2 = "also carrying ";
                        }
                        if (thisOIdx != 0)
                        {
                            break;
                        }
                        s2 = "on ";
                    }
                }
                for (thisOIdx = cPtr.ItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
                {
                    Item oPtr = Level.Items[thisOIdx];
                    nextOIdx = oPtr.NextInStack;
                    if (oPtr.Marked)
                    {
                        boring = false;
                        string oName = oPtr.Description(true, 3);
                        outVal = $"{s1}{s2}{s3}{oName} [{info}]";
                        Screen.PrintLine(outVal, 0, 0);
                        Level.MoveCursorRelative(y, x);
                        query = Inkey();
                        if (query != '\r' && query != '\n' && query != ' ')
                        {
                            break;
                        }
                        if (query == ' ' && (mode & Constants.TargetLook) == 0)
                        {
                            break;
                        }
                        s1 = "It is ";
                        if (oPtr.Count != 1)
                        {
                            s1 = "They are ";
                        }
                        s2 = "on ";
                    }
                }
                if (thisOIdx != 0)
                {
                    break;
                }
                string feat = string.IsNullOrEmpty(cPtr.FeatureType.AppearAs)
                    ? ObjectRepository.FloorTileTypes[cPtr.BackgroundFeature.AppearAs].Name
                    : ObjectRepository.FloorTileTypes[cPtr.FeatureType.AppearAs].Name;
                if (cPtr.TileFlags.IsClear(GridTile.PlayerMemorised) && !Level.PlayerCanSeeBold(y, x))
                {
                    feat = string.Empty;
                }
                if (boring || (!cPtr.FeatureType.IsOpenFloor))
                {
                    string name = "unknown grid";
                    if (feat != string.Empty)
                    {
                        name = ObjectRepository.FloorTileTypes[feat].Description;
                        if (s2 != "" && cPtr.FeatureType.BlocksLos)
                        {
                            s2 = "in ";
                        }
                    }
                    s3 = name[0].IsVowel() ? "an " : "a ";
                    if (cPtr.FeatureType.IsShop)
                    {
                        s3 = name[0].IsVowel() ? "the entrance to an " : "the entrance to a ";
                    }
                    outVal = $"{s1}{s2}{s3}{name} [{info}]";
                    Screen.PrintLine(outVal, 0, 0);
                    Level.MoveCursorRelative(y, x);
                    query = Inkey();
                    if (query != '\r' && query != '\n' && query != ' ')
                    {
                        break;
                    }
                }
            }
            while (query == '\r' || query == '\n');
            return query;
        }

        private void TargetSetPrepare(int mode)
        {
            int y;
            Level.TempN = 0;
            for (y = Level.PanelRowMin; y <= Level.PanelRowMax; y++)
            {
                int x;
                for (x = Level.PanelColMin; x <= Level.PanelColMax; x++)
                {
                    GridTile cPtr = Level.Grid[y][x];
                    if (!Level.PlayerHasLosBold(y, x))
                    {
                        continue;
                    }
                    if (!TargetSetAccept(y, x))
                    {
                        continue;
                    }
                    if ((mode & Constants.TargetKill) != 0 && !TargetAble(cPtr.MonsterIndex))
                    {
                        continue;
                    }
                    Level.TempX[Level.TempN] = x;
                    Level.TempY[Level.TempN] = y;
                    Level.TempN++;
                }
            }
            List<TargetLocation> list = new List<TargetLocation>();
            for (int i = 0; i < Level.TempN; i++)
            {
                list.Add(new TargetLocation(Level.TempY[i], Level.TempX[i],
                    Level.Distance(Level.TempY[i], Level.TempX[i], Player.MapY, Player.MapX)));
            }
            list.Sort();
            for (int i = 0; i < Level.TempN; i++)
            {
                Level.TempX[i] = list[i].X;
                Level.TempY[i] = list[i].Y;
            }
        }

        public bool MartialArtistEmptyHands()
        {
            if (Player.BaseCharacterClass.ID != CharacterClass.Monk && Player.BaseCharacterClass.ID != CharacterClass.Mystic)
            {
                return false;
            }
            return Player.Inventory[InventorySlot.MeleeWeapon].BaseItemCategory == null;
        }

        public bool MartialArtistHeavyArmour()
        {
            int martialArtistArmWgt = 0;
            if (Player.BaseCharacterClass.ID != CharacterClass.Monk && Player.BaseCharacterClass.ID != CharacterClass.Mystic)
            {
                return false;
            }
            foreach (BaseInventorySlot inventorySlot in SingletonRepository.InventorySlots)
            {
                if (inventorySlot.IsArmour)
                {
                    foreach (int index in inventorySlot)
                    {
                        Item item = Player.Inventory[index];
                        if (item.BaseItemCategory != null)
                        {
                            martialArtistArmWgt += item.Weight;
                        }
                        //foreach (Item item in inventorySlot)
                        //{
                        //    martialArtistArmWgt += item.Weight;
                        //}
                    }
                }
            }
            return martialArtistArmWgt > 100 + (Player.Level * 4);
        }

        public string RealmNames(BaseRealm? primaryRealm, BaseRealm? secondaryRealm)
        {
            if (primaryRealm != null && secondaryRealm != null)
            {
                return primaryRealm.Name + "/" + secondaryRealm.Name;
            }
            else if (primaryRealm != null)
            {
                return primaryRealm.Name;
            }
            else
            {
                return "None";
            }
        }
    }
}