// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Interface;
using Cthangband.ActivationPowers;
using Cthangband.Commands;
using Cthangband.Debug;
using Cthangband.Enumerations;
using Cthangband.Mutations;
using Cthangband.Patrons;
using Cthangband.Projection;
using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Cthangband
{
    [Serializable]
    internal class SaveGame
    {
        /// <summary>
        /// Maximum amount of health that can be drained from an opponent in one turn
        /// </summary>
        private const int _maxVampiricDrain = 100;
        private AutoNavigator _autoNavigator;

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
        public List<AmuletFlavour> AmuletFlavours;
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
        public List<MushroomFlavour> MushroomFlavours;
        public bool NewLevelFlag;
        public Player Player;
        public bool Playing;
        public List<PotionFlavour> PotionFlavours;
        public int RecallDungeon;
        public int Resting;
        public List<RingFlavour> RingFlavours;
        public List<RodFlavour> RodFlavours;
        public int Running;
        public List<ScrollFlavour> ScrollFlavours;
        public List<StaffFlavour> StaffFlavours;
        public int TargetCol;
        public int TargetRow;
        public int TargetWho;
        public int TotalFriendLevels;
        public int TotalFriends;
        public int TrackedMonsterIndex;
        public bool ViewingEquipment;
        public bool ViewingItemList;
        public List<WandFlavour> WandFlavours;

        [NonSerialized]
        public Gui Gui;

        private List<Monster> _petList = new List<Monster>();
        private int _seedFlavor;
        public const int HurtChance = 16;

        [NonSerialized]
        private IPersistentStorage PersistentStorage;

        [NonSerialized]
        private IUpdateNotifier _updateNotifier;

        /// <summary>
        /// Creates a new game.
        /// </summary>
        public SaveGame()
        {
            Gui = new Gui(this);
            _autoNavigator = new AutoNavigator(this);
            Quests = new QuestArray(this);
            GlobalData.PopulateNewProfile(this);
            Towns = Town.NewTownList(this);
            Dungeons = Dungeon.NewDungeonList();
            PatronList = Patron.NewPatronList(this);
            InitialiseAllocationTables();
        }

        public void NotifyNow()
        {
            _updateNotifier.NotifyNow();
        }

        public void SetInjections(IPersistentStorage persistentStorage, IUpdateNotifier updateNotification)
        {
            PersistentStorage = persistentStorage;
            _updateNotifier = updateNotification;
        }

        public void Quit(string reason)
        {
            if (!string.IsNullOrEmpty(reason))
            {
                MessageBoxShow(reason);
            }
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
            PersistentStorage.WriteGame(gameDetails, memoryStream.ToArray());
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
                Gui.Print(Colour.White, t.Substring(0, split), 0, 0, split);
                MsgFlush(split + 1);
                t = t.Substring(split);
                n -= split;
            }
            Gui.Print(Colour.White, t, 0, _msgPrintP, n);
            MsgFlag = true;
            _msgPrintP += n + 1;
        }
        private void MsgFlush(int x)
        {
            const Colour a = Colour.BrightBlue;
            Gui.Print(a, "-more-", 0, x);
            while (true)
            {
                Gui.Inkey();
                break;
            }
            Gui.Erase(0, 0, 255);
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
                    Gui.Print(wildMapAttr, wildMapSymbol, y + 2, x + 2);
                }
            }
            Gui.Print(Colour.Purple, "+------------+", 1, 1);
            for (y = 0; y < 12; y++)
            {
                Gui.Print(Colour.Purple, "|", y + 2, 1);
                Gui.Print(Colour.Purple, "|", y + 2, 14);
            }
            Gui.Print(Colour.Purple, "+------------+", 14, 1);
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
                Gui.Print(keyAttr, buffer, y + 1, 19);
            }
            Gui.Print(Colour.Purple, "L:levels", 16, 1);
            Gui.Print(Colour.Purple, "D:difficulty", 17, 1);
            Gui.Print(Colour.Purple, "Q:quests", 18, 1);
            Gui.Print(Colour.Purple, "(Your position is marked with the cursor)", Constants.MaxCaves + 2, 19);
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
            Gui.Refresh();
            DiedFrom = "(saved)";
            SavePlayer(Player);
            Gui.Refresh();
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
                Gui.Save();
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
                Gui.PrintLine(tmpVal, 0, 0);
                char which = Gui.Inkey();
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
                                Gui.Save();
                                ViewingItemList = true;
                            }
                            else
                            {
                                Gui.Load();
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
                                Gui.Load();
                                Gui.Save();
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
                Gui.Load();
            }
            ViewingItemList = false;
            Inventory.ItemFilterCategory = 0;
            ItemFilter = null;
            Gui.PrintLine("", 0, 0);
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
                        if (!qPtr.MakeObject(good, great))
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (!qPtr.MakeObject(true, true))
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
            bool small = oPtr.ItemSubCategory < ItemSubCategory.SvChestMinLarge;
            int number = oPtr.ItemSubCategory % ItemSubCategory.SvChestMinLarge * 2;
            if (oPtr.TypeSpecificValue == 0)
            {
                number = 0;
            }
            Level.OpeningChest = true;
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
                    if (!qPtr.MakeObject(false, false))
                    {
                        continue;
                    }
                }
                Level.DropNear(qPtr, -1, y, x);
            }
            Level.ObjectLevel = Difficulty;
            Level.OpeningChest = false;
            oPtr.TypeSpecificValue = 0;
            oPtr.BecomeKnown();
        }

        public void Play()
        {
            Gui.FullScreenOverlay = true;
            Gui.SetBackground(BackgroundImage.Normal);
            Gui.CursorVisible = false;
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
            NotifyNow();
            MsgFlag = false;
            MsgPrint(null);
            Gui.Refresh();
            FlavorInit();
            ApplyFlavourVisuals();
            if (Level == null)
            {
                Level = new Level(this);
                LevelFactory factory = new LevelFactory(this);
                factory.GenerateNewLevel();
            }
            Gui.FullScreenOverlay = false;
            Gui.SetBackground(BackgroundImage.Overhead);
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
                    // Store the player info
                    ExPlayer = new ExPlayer(Player);
                    break;
                }
                Level = new Level(this);
                LevelFactory factory = new LevelFactory(this);
                factory.GenerateNewLevel();
                Level.ReplacePets(Player.MapY, Player.MapX, _petList);
            }
            CloseGame();
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
            if (Gui.FullScreenOverlay)
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

        private void ApplyFlavourVisuals()
        {
            int i;
            for (i = 0; i < ItemTypes.Count; i++)
            {
                ItemType kPtr = ItemTypes[i];
                EntityType visual = ObjectFlavourEntity(i);
                if (visual != null)
                {
                    kPtr.Character = visual.Character;
                    kPtr.Colour = visual.Colour;
                }
            }
        }

        private void CloseGame()
        {
            HandleStuff();
            MsgPrint(null);
            Gui.FullScreenOverlay = true;
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
                //    Gui.Terminal.PlayMusic(MusicTrack.Menu);
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
            Gui.CurrentCommand = (char)0;
            Gui.QueuedCommand = (char)0;
            CommandRepeat = 0;
            Gui.CommandArgument = 0;
            Gui.CommandDirection = 0;
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
            Gui.Refresh();
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
                    Gui.Terminal.PlayMusic(MusicTrack.Town);
                }
                else
                {
                    Gui.Terminal.PlayMusic(MusicTrack.Wilderness);
                }
            }
            else
            {
                if (Quests.IsQuest(CurrentDepth))
                {
                    Gui.Terminal.PlayMusic(MusicTrack.QuestLevel);
                }
                else
                {
                    Gui.Terminal.PlayMusic(MusicTrack.Dungeon);
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
            PotionFlavours = new List<PotionFlavour>();
            List<PotionFlavour> tempPotions = new List<PotionFlavour>();
            PotionFlavours.Add(StaticResources.Instance.PotionFlavours["Clear"]);
            PotionFlavours.Add(StaticResources.Instance.PotionFlavours["Light Brown"]);
            PotionFlavours.Add(StaticResources.Instance.PotionFlavours["Icky Green"]);
            foreach (KeyValuePair<string, PotionFlavour> pair in StaticResources.Instance.PotionFlavours)
            {
                if (pair.Key == "Clear")
                {
                    continue;
                }
                if (pair.Key == "Light Brown")
                {
                    continue;
                }
                if (pair.Key == "Icky Green")
                {
                    continue;
                }
                tempPotions.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempPotions.Count);
                PotionFlavours.Add(tempPotions[index]);
                tempPotions.RemoveAt(index);
            } while (tempPotions.Count > 0);
            MushroomFlavours = new List<MushroomFlavour>();
            List<MushroomFlavour> tempMushrooms = new List<MushroomFlavour>();
            foreach (KeyValuePair<string, MushroomFlavour> pair in StaticResources.Instance.MushroomFlavours)
            {
                tempMushrooms.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempMushrooms.Count);
                MushroomFlavours.Add(tempMushrooms[index]);
                tempMushrooms.RemoveAt(index);
            } while (tempMushrooms.Count > 0);
            AmuletFlavours = new List<AmuletFlavour>();
            List<AmuletFlavour> tempAmulets = new List<AmuletFlavour>();
            foreach (KeyValuePair<string, AmuletFlavour> pair in StaticResources.Instance.AmuletFlavours)
            {
                tempAmulets.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempAmulets.Count);
                AmuletFlavours.Add(tempAmulets[index]);
                tempAmulets.RemoveAt(index);
            } while (tempAmulets.Count > 0);
            WandFlavours = new List<WandFlavour>();
            List<WandFlavour> tempWands = new List<WandFlavour>();
            foreach (KeyValuePair<string, WandFlavour> pair in StaticResources.Instance.WandFlavours)
            {
                tempWands.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempWands.Count);
                WandFlavours.Add(tempWands[index]);
                tempWands.RemoveAt(index);
            } while (tempWands.Count > 0);
            RingFlavours = new List<RingFlavour>();
            List<RingFlavour> tempRings = new List<RingFlavour>();
            foreach (KeyValuePair<string, RingFlavour> pair in StaticResources.Instance.RingFlavours)
            {
                tempRings.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempRings.Count);
                RingFlavours.Add(tempRings[index]);
                tempRings.RemoveAt(index);
            } while (tempRings.Count > 0);
            RodFlavours = new List<RodFlavour>();
            List<RodFlavour> tempRods = new List<RodFlavour>();
            foreach (KeyValuePair<string, RodFlavour> pair in StaticResources.Instance.RodFlavours)
            {
                tempRods.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempRods.Count);
                RodFlavours.Add(tempRods[index]);
                tempRods.RemoveAt(index);
            } while (tempRods.Count > 0);
            StaffFlavours = new List<StaffFlavour>();
            List<StaffFlavour> tempStaffs = new List<StaffFlavour>();
            foreach (KeyValuePair<string, StaffFlavour> pair in StaticResources.Instance.StaffFlavours)
            {
                tempStaffs.Add(pair.Value);
            }
            do
            {
                int index = Program.Rng.RandomLessThan(tempStaffs.Count);
                StaffFlavours.Add(tempStaffs[index]);
                tempStaffs.RemoveAt(index);
            } while (tempStaffs.Count > 0);
            ScrollFlavours = new List<ScrollFlavour>();
            List<ScrollFlavour> tempScrolls = new List<ScrollFlavour>();
            foreach (KeyValuePair<string, ScrollFlavour> pair in StaticResources.Instance.ScrollFlavours)
            {
                tempScrolls.Add(pair.Value);
            }
            for (i = 0; i < Constants.MaxTitles; i++)
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
                            tmp += ScrollFlavour.Syllables[Program.Rng.RandomLessThan(ScrollFlavour.Syllables.Length)];
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
                ItemType kPtr = ItemTypes[i];
                if (string.IsNullOrEmpty(kPtr.Name))
                {
                    continue;
                }
                kPtr.HasFlavor = Inventory.ObjectHasFlavor(kPtr);
                if (!kPtr.HasFlavor)
                {
                    kPtr.FlavourAware = true;
                }
                kPtr.EasyKnow = Inventory.ObjectEasyKnow(this, i);
            }
        }

        private void InitialiseAllocationTables()
        {
            int i, j;
            ItemType kPtr;
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
            Gui.SetBackground(BackgroundImage.Crown);
            Gui.Clear();
            Gui.AnyKey(44);
        }

        private EntityType ObjectFlavourEntity(int i)
        {
            ItemType kPtr = ItemTypes[i];
            if (kPtr.HasFlavor)
            {
                int indexx = kPtr.SubCategory;
                switch (kPtr.Category)
                {
                    case ItemCategory.Food:
                        return MushroomFlavours[indexx];

                    case ItemCategory.Potion:
                        return PotionFlavours[indexx];

                    case ItemCategory.Scroll:
                        return ScrollFlavours[indexx];

                    case ItemCategory.Amulet:
                        return AmuletFlavours[indexx];

                    case ItemCategory.Ring:
                        return RingFlavours[indexx];

                    case ItemCategory.Staff:
                        return StaffFlavours[indexx];

                    case ItemCategory.Wand:
                        return WandFlavours[indexx];

                    case ItemCategory.Rod:
                        return RodFlavours[indexx];
                }
            }
            return null;
        }

        private void PrintTomb(Player corpse)
        {
            {
                DateTime ct = DateTime.Now;
                if (corpse.IsWinner)
                {
                    Gui.SetBackground(BackgroundImage.Sunset);
                    Gui.Terminal.PlayMusic(MusicTrack.Victory);
                }
                else
                {
                    Gui.SetBackground(BackgroundImage.Tomb);
                    Gui.Terminal.PlayMusic(MusicTrack.Death);
                }
                Gui.Clear();
                string buf = corpse.Name.Trim() + corpse.Generation.ToRoman(true);
                if (corpse.IsWinner || corpse.Level > Constants.PyMaxLevel)
                {
                    buf += " the Magnificent";
                }
                Gui.Print(buf, 39, 1);
                buf = $"Level {corpse.Level} {Profession.ClassSubName(corpse.ProfessionIndex, corpse.Realm1)}";
                Gui.Print(buf, 40, 1);
                string tmp = $"Killed on Level {CurrentDepth}".PadLeft(45);
                Gui.Print(tmp, 39, 34);
                tmp = $"by {DiedFrom}".PadLeft(45);
                Gui.Print(tmp, 40, 34);
                tmp = $"on {ct:dd MMM yyyy h.mm tt}".PadLeft(45);
                Gui.Print(tmp, 41, 34);
                Gui.AnyKey(44);
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
                Gui.DoNotWaitOnInkey = true;
                if (Gui.Inkey() != 0)
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
                Gui.Refresh();
                if (Player.Inventory[InventorySlot.Pack].ItemType != null)
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
                if (Gui.QueuedCommand == 0)
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
                    Gui.PrintLine("", 0, 0);
                    ProcessCommand(true);
                }
                else
                {
                    Level.MoveCursorRelative(Player.MapY, Player.MapX);
                    Gui.RequestCommand(false);
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
                if ((oPtr.ItemSubCategory == LightType.Torch || oPtr.ItemSubCategory == LightType.Lantern) &&
                    oPtr.TypeSpecificValue > 0)
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
                oPtr.GetMergedFlags(f1, f2, f3);
                if (f3.IsSet(ItemFlag3.DreadCurse) && Program.Rng.DieRoll(100) == 1)
                {
                    ActivateDreadCurse();
                }
                if (f3.IsSet(ItemFlag3.Teleport) && Program.Rng.RandomLessThan(100) < 1)
                {
                    if (oPtr.IdentifyFlags.IsSet(Constants.IdentCursed) && !Player.HasAntiTeleport)
                    {
                        Disturb(true);
                        TeleportPlayer(40);
                    }
                    else
                    {
                        if (Gui.GetCheck("Teleport? "))
                        {
                            Disturb(false);
                            TeleportPlayer(50);
                        }
                    }
                }
                Player.Dna.OnProcessWorld(this, Player, Level);
                if (oPtr.ItemType == null)
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
                if (oPtr.ItemType == null)
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
                if (oPtr.ItemType == null)
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
                    Gui.PlaySound(SoundEffect.TeleportLevel);
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
            if (Gui.FullScreenOverlay)
            {
                return;
            }
            PlayerStatus playerStatus = new PlayerStatus(this);
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrWipe))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrWipe);
                MsgPrint(null);
                Gui.Clear();
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
            return Gui.GetCheck(outVal);
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

        public void AggravateMonsters(int who)
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
                if (i == who)
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
            bool force = Gui.CommandArgument > 0;
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
                amt = Gui.GetQuantity(null, oPtr.Count, true);
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
                    if (!Gui.GetCheck(outVal))
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
            if (oPtr.ItemType == null)
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
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
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
            oPtr.GetMergedFlags(f1, f2, f3);
            if (oPtr.IdentifyFlags.IsSet(Constants.IdentCursed))
            {
                string your;
                if ((f3.IsSet(ItemFlag3.HeavyCurse) && Program.Rng.DieRoll(100) < 33) ||
                    f3.IsSet(ItemFlag3.PermaCurse))
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
            if (f3.IsSet(ItemFlag3.Blessed))
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
                oPtr.RandartFlags3.Set(ItemFlag3.Blessed);
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
            Gui.GetCom("Choose a monster race (by symbol) to carnage: ", out char typ);
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
                Gui.Refresh();
                Gui.Pause(msec);
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
                if (oPtr.ItemType == null)
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
                if (oPtr.ItemType == null)
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
                if (oPtr.ItemType == null)
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
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            oPtr.GetMergedFlags(f1, f2, f3);
            int prob = oPtr.Count * 100;
            if (oPtr.Category == ItemCategory.Bolt || oPtr.Category == ItemCategory.Arrow ||
                oPtr.Category == ItemCategory.Shot)
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
                        if (oPtr.IsCursed() && f3.IsClear(ItemFlag3.PermaCurse) && oPtr.BonusToHit >= 0 &&
                            Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                            oPtr.IdentifyFlags.Set(Constants.IdentSense);
                            if (oPtr.RandartFlags3.IsSet(ItemFlag3.Cursed))
                            {
                                oPtr.RandartFlags3.Clear(ItemFlag3.Cursed);
                            }
                            if (oPtr.RandartFlags3.IsSet(ItemFlag3.HeavyCurse))
                            {
                                oPtr.RandartFlags3.Clear(ItemFlag3.HeavyCurse);
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
                        if (oPtr.IsCursed() && f3.IsClear(ItemFlag3.PermaCurse) && oPtr.BonusDamage >= 0 &&
                            Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                            oPtr.IdentifyFlags.Set(Constants.IdentSense);
                            if (oPtr.RandartFlags3.IsSet(ItemFlag3.Cursed))
                            {
                                oPtr.RandartFlags3.Clear(ItemFlag3.Cursed);
                            }
                            if (oPtr.RandartFlags3.IsSet(ItemFlag3.HeavyCurse))
                            {
                                oPtr.RandartFlags3.Clear(ItemFlag3.HeavyCurse);
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
                        if (oPtr.IsCursed() && f3.IsClear(ItemFlag3.PermaCurse) && oPtr.BonusArmourClass >= 0 &&
                            Program.Rng.RandomLessThan(100) < 25)
                        {
                            MsgPrint("The curse is broken!");
                            oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                            oPtr.IdentifyFlags.Set(Constants.IdentSense);
                            if (oPtr.RandartFlags3.IsSet(ItemFlag3.Cursed))
                            {
                                oPtr.RandartFlags3.Clear(ItemFlag3.Cursed);
                            }
                            if (oPtr.RandartFlags3.IsSet(ItemFlag3.HeavyCurse))
                            {
                                oPtr.RandartFlags3.Clear(ItemFlag3.HeavyCurse);
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
                if (oPtr.ItemType == null)
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
                if (oPtr.ItemType == null)
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
                Gui.Refresh();
                Gui.Pause(msec);
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

        public bool PotionSmashEffect(int who, int y, int x, int oSval)
        {
            int radius = 2;
            Projectile dt = null;
            int dam = 0;
            bool angry = false;
            switch (oSval)
            {
                case PotionType.SaltWater:
                case PotionType.SlimeMold:
                case PotionType.LoseMemories:
                case PotionType.DecStr:
                case PotionType.DecInt:
                case PotionType.DecWis:
                case PotionType.DecDex:
                case PotionType.DecCon:
                case PotionType.DecCha:
                case PotionType.Water:
                case PotionType.AppleJuice:
                    return true;

                case PotionType.Infravision:
                case PotionType.DetectInvis:
                case PotionType.SlowPoison:
                case PotionType.CurePoison:
                case PotionType.Boldness:
                case PotionType.ResistHeat:
                case PotionType.ResistCold:
                case PotionType.Heroism:
                case PotionType.BeserkStrength:
                case PotionType.RestoreExp:
                case PotionType.ResStr:
                case PotionType.ResInt:
                case PotionType.ResWis:
                case PotionType.ResDex:
                case PotionType.ResCon:
                case PotionType.ResCha:
                case PotionType.IncStr:
                case PotionType.IncInt:
                case PotionType.IncWis:
                case PotionType.IncDex:
                case PotionType.IncCon:
                case PotionType.IncCha:
                case PotionType.Augmentation:
                case PotionType.Enlightenment:
                case PotionType.StarEnlightenment:
                case PotionType.SelfKnowledge:
                case PotionType.Experience:
                case PotionType.Resistance:
                case PotionType.Invulnerability:
                case PotionType.NewLife:
                    return false;

                case PotionType.Slowness:
                    dt = new ProjectOldSlow(this);
                    dam = 5;
                    angry = true;
                    break;

                case PotionType.Poison:
                    dt = new ProjectPois(this);
                    dam = 3;
                    angry = true;
                    break;

                case PotionType.Blindness:
                    dt = new ProjectDark(this);
                    angry = true;
                    break;

                case PotionType.Confusion:
                    dt = new ProjectOldConf(this);
                    angry = true;
                    break;

                case PotionType.Sleep:
                    dt = new ProjectOldSleep(this);
                    angry = true;
                    break;

                case PotionType.Ruination:
                case PotionType.Detonations:
                    dt = new ProjectExplode(this);
                    dam = Program.Rng.DiceRoll(25, 25);
                    angry = true;
                    break;

                case PotionType.Death:
                    dt = new ProjectDeathRay(this);
                    angry = true;
                    radius = 1;
                    break;

                case PotionType.Speed:
                    dt = new ProjectOldSpeed(this);
                    break;

                case PotionType.CureLight:
                    dt = new ProjectOldHeal(this);
                    dam = Program.Rng.DiceRoll(2, 3);
                    break;

                case PotionType.CureSerious:
                    dt = new ProjectOldHeal(this);
                    dam = Program.Rng.DiceRoll(4, 3);
                    break;

                case PotionType.CureCritical:
                case PotionType.Curing:
                    dt = new ProjectOldHeal(this);
                    dam = Program.Rng.DiceRoll(6, 3);
                    break;

                case PotionType.Healing:
                    dt = new ProjectOldHeal(this);
                    dam = Program.Rng.DiceRoll(10, 10);
                    break;

                case PotionType.StarHealing:
                case PotionType.Life:
                    dt = new ProjectOldHeal(this);
                    dam = Program.Rng.DiceRoll(50, 50);
                    radius = 1;
                    break;

                case PotionType.RestoreMana:
                    dt = new ProjectMana(this);
                    dam = Program.Rng.DiceRoll(10, 10);
                    radius = 1;
                    break;
            }
            Project(who, radius, y, x, dam, dt,
                ProjectionFlag.ProjectJump | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill);
            return angry;
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
            int lev = oPtr.ItemType.Level;
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
            Gui.Save();
            for (k = 1; k < 24; k++)
            {
                Gui.PrintLine("", k, 13);
            }
            Gui.PrintLine("     Your Current Magic:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                string dummy = $"{info[j]} {GlobalData.ReportMagicDurations[info2[j]]}.";
                Gui.PrintLine(dummy, k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    Gui.PrintLine("-- more --", k, 15);
                    Gui.Inkey();
                    for (; k > 2; k--)
                    {
                        Gui.PrintLine("", k, 15);
                    }
                }
            }
            Gui.PrintLine("[Press any key to continue]", k, 13);
            Gui.Inkey();
            Gui.Load();
        }

        public void SelfKnowledge()
        {
            int i = 0, j, k;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            Item oPtr;
            string[] info = new string[128];
            int plev = Player.Level;
            string dummy = "";
            for (k = InventorySlot.MeleeWeapon; k < InventorySlot.Total; k++)
            {
                FlagSet t1 = new FlagSet();
                FlagSet t2 = new FlagSet();
                FlagSet t3 = new FlagSet();
                oPtr = Player.Inventory[k];
                if (oPtr.ItemType != null)
                {
                    continue;
                }
                oPtr.GetMergedFlags(t1, t2, t3);
                f1.Set(t1);
                f2.Set(t2);
                f3.Set(t3);
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
            if (f1.IsSet(ItemFlag1.Str))
            {
                info[i++] = "Your strength is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Int))
            {
                info[i++] = "Your intelligence is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Wis))
            {
                info[i++] = "Your wisdom is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Dex))
            {
                info[i++] = "Your dexterity is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Con))
            {
                info[i++] = "Your constitution is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Cha))
            {
                info[i++] = "Your charisma is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Stealth))
            {
                info[i++] = "Your stealth is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Search))
            {
                info[i++] = "Your searching ability is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Infra))
            {
                info[i++] = "Your infravision is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Tunnel))
            {
                info[i++] = "Your digging ability is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Speed))
            {
                info[i++] = "Your speed is affected by your equipment.";
            }
            if (f1.IsSet(ItemFlag1.Blows))
            {
                info[i++] = "Your attack speed is affected by your equipment.";
            }
            oPtr = Player.Inventory[InventorySlot.MeleeWeapon];
            if (oPtr.ItemType != null)
            {
                if (f3.IsSet(ItemFlag3.Blessed))
                {
                    info[i++] = "Your weapon has been blessed by the gods.";
                }
                if (f1.IsSet(ItemFlag1.Chaotic))
                {
                    info[i++] = "Your weapon is branded with the Yellow Sign.";
                }
                if (f1.IsSet(ItemFlag1.Impact))
                {
                    info[i++] = "The impact of your weapon can cause earthquakes.";
                }
                if (f1.IsSet(ItemFlag1.Vorpal))
                {
                    info[i++] = "Your weapon is very sharp.";
                }
                if (f1.IsSet(ItemFlag1.Vampiric))
                {
                    info[i++] = "Your weapon drains life from your foes.";
                }
                if (f1.IsSet(ItemFlag1.BrandAcid))
                {
                    info[i++] = "Your weapon melts your foes.";
                }
                if (f1.IsSet(ItemFlag1.BrandElec))
                {
                    info[i++] = "Your weapon shocks your foes.";
                }
                if (f1.IsSet(ItemFlag1.BrandFire))
                {
                    info[i++] = "Your weapon burns your foes.";
                }
                if (f1.IsSet(ItemFlag1.BrandCold))
                {
                    info[i++] = "Your weapon freezes your foes.";
                }
                if (f1.IsSet(ItemFlag1.BrandPois))
                {
                    info[i++] = "Your weapon poisons your foes.";
                }
                if (f1.IsSet(ItemFlag1.SlayAnimal))
                {
                    info[i++] = "Your weapon strikes at animals with extra force.";
                }
                if (f1.IsSet(ItemFlag1.SlayEvil))
                {
                    info[i++] = "Your weapon strikes at evil with extra force.";
                }
                if (f1.IsSet(ItemFlag1.SlayUndead))
                {
                    info[i++] = "Your weapon strikes at undead with holy wrath.";
                }
                if (f1.IsSet(ItemFlag1.SlayDemon))
                {
                    info[i++] = "Your weapon strikes at demons with holy wrath.";
                }
                if (f1.IsSet(ItemFlag1.SlayOrc))
                {
                    info[i++] = "Your weapon is especially deadly against orcs.";
                }
                if (f1.IsSet(ItemFlag1.SlayTroll))
                {
                    info[i++] = "Your weapon is especially deadly against trolls.";
                }
                if (f1.IsSet(ItemFlag1.SlayGiant))
                {
                    info[i++] = "Your weapon is especially deadly against giants.";
                }
                if (f1.IsSet(ItemFlag1.SlayDragon))
                {
                    info[i++] = "Your weapon is especially deadly against dragons.";
                }
                if (f1.IsSet(ItemFlag1.KillDragon))
                {
                    info[i++] = "Your weapon is a great bane of dragons.";
                }
            }
            Gui.Save();
            for (k = 1; k < 24; k++)
            {
                Gui.PrintLine("", k, 13);
            }
            Gui.PrintLine("     Your Attributes:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                Gui.PrintLine(info[j], k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    Gui.PrintLine("-- more --", k, 15);
                    Gui.Inkey();
                    for (; k > 2; k--)
                    {
                        Gui.PrintLine("", k, 15);
                    }
                }
            }
            Gui.PrintLine("[Press any key to continue]", k, 13);
            Gui.Inkey();
            Gui.Load();
        }

        public bool SetAcidDestroy(Item oPtr)
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            if (!oPtr.HatesAcid())
            {
                return false;
            }
            oPtr.GetMergedFlags(f1, f2, f3);
            if (f3.IsSet(ItemFlag3.IgnoreAcid))
            {
                return false;
            }
            return true;
        }

        public bool SetColdDestroy(Item oPtr)
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            if (!oPtr.HatesCold())
            {
                return false;
            }
            oPtr.GetMergedFlags(f1, f2, f3);
            if (f3.IsSet(ItemFlag3.IgnoreCold))
            {
                return false;
            }
            return true;
        }

        public bool SetElecDestroy(Item oPtr)
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            if (!oPtr.HatesElec())
            {
                return false;
            }
            oPtr.GetMergedFlags(f1, f2, f3);
            if (f3.IsSet(ItemFlag3.IgnoreElec))
            {
                return false;
            }
            return true;
        }

        public bool SetFireDestroy(Item oPtr)
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            if (!oPtr.HatesFire())
            {
                return false;
            }
            oPtr.GetMergedFlags(f1, f2, f3);
            if (f3.IsSet(ItemFlag3.IgnoreFire))
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

        public void TeleportAway(int mIdx, int dis)
        {
            int ny = 0;
            int nx = 0;
            bool look = true;
            Monster mPtr = Level.Monsters[mIdx];
            if (mPtr.Race == null)
            {
                return;
            }
            int oy = mPtr.MapY;
            int ox = mPtr.MapX;
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
                        int d = Level.Distance(oy, ox, ny, nx);
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
            Gui.PlaySound(SoundEffect.Teleport);
            Level.Grid[ny][nx].MonsterIndex = mIdx;
            Level.Grid[oy][ox].MonsterIndex = 0;
            mPtr.MapY = ny;
            mPtr.MapX = nx;
            Level.Monsters.UpdateMonsterVisibility(mIdx, true);
            Level.RedrawSingleLocation(oy, ox);
            Level.RedrawSingleLocation(ny, nx);
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
            Gui.PlaySound(SoundEffect.Teleport);
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
            Gui.PlaySound(SoundEffect.TeleportLevel);
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
            Gui.PlaySound(SoundEffect.Teleport);
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
                    Gui.PlaySound(SoundEffect.Teleport);
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
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
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
            if (oPtr.ItemType == null)
            {
                return false;
            }
            if (oPtr.BaseArmourClass + oPtr.BonusArmourClass <= 0)
            {
                return false;
            }
            string oName = oPtr.Description(false, 0);
            oPtr.GetMergedFlags(f1, f2, f3);
            if (f3.IsSet(ItemFlag3.IgnoreAcid))
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
                FlagSet f1 = new FlagSet();
                FlagSet f2 = new FlagSet();
                FlagSet f3 = new FlagSet();
                Item oPtr = Player.Inventory[i];
                if (oPtr.ItemType == null)
                {
                    continue;
                }
                if (!oPtr.IsCursed())
                {
                    continue;
                }
                oPtr.GetMergedFlags(f1, f2, f3);
                if (!all && f3.IsSet(ItemFlag3.HeavyCurse))
                {
                    continue;
                }
                if (f3.IsSet(ItemFlag3.PermaCurse))
                {
                    continue;
                }
                oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                oPtr.IdentifyFlags.Set(Constants.IdentSense);
                if (oPtr.RandartFlags3.IsSet(ItemFlag3.Cursed))
                {
                    oPtr.RandartFlags3.Clear(ItemFlag3.Cursed);
                }
                if (oPtr.RandartFlags3.IsSet(ItemFlag3.HeavyCurse))
                {
                    oPtr.RandartFlags3.Clear(ItemFlag3.HeavyCurse);
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
            Gui.PlaySound(SoundEffect.Teleport);
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
            char c = Gui.CurrentCommand;

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
                        Gui.CommandArgument = command.Repeat.Value;
                    }

                    if (Gui.CommandArgument > 0)
                    {
                        CommandRepeat = Gui.CommandArgument - 1;
                        Player.RedrawNeeded.Set(RedrawFlag.PrState);
                        Gui.CommandArgument = 0;
                    }

                    // The command was processed.  Skip the SWITCH statement.
                    return;
                }
            }
            Gui.PrintLine("Type '?' for a list of commands.", 0, 0);
        }

        // Combat Engine
        /// <summary>
        /// Have a monster make an attack on the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster making the attack </param>
        public void MonsterAttackPlayer(int monsterIndex)
        {
            Player player = Player;
            Level level = Level;
            Monster monster = level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            int attackNumber;
            bool touched = false;
            bool fear = false;
            bool alive = true;
            // If the monster never attacks, then it shouldn't be attacking us now
            if ((race.Flags1 & MonsterFlag1.NeverAttack) != 0)
            {
                return;
            }
            // Friends don't hit friends
            if ((monster.Mind & Constants.SmFriendly) != 0)
            {
                return;
            }

            int armourClass = player.BaseArmourClass + player.ArmourClassBonus;
            int monsterLevel = race.Level >= 1 ? race.Level : 1;
            string monsterName = monster.MonsterDesc(0);
            string monsterDescription = monster.MonsterDesc(0x88);
            bool blinked = false;
            // Monsters get up to four attacks
            for (attackNumber = 0; attackNumber < 4; attackNumber++)
            {
                bool visible = false;
                bool obvious = false;
                int power = 0;
                int damage = 0;
                string act = null;
                AttackEffect effect = race.Attack[attackNumber].Effect;
                AttackType method = race.Attack[attackNumber].Method;
                int damageDice = race.Attack[attackNumber].DDice;
                int damageSides = race.Attack[attackNumber].DSide;
                // If the monster doesn't have an attack in this slot, stop looping
                if (method == AttackType.Nothing)
                {
                    break;
                }
                // Stop if player is dead or gone
                if (!alive || player.IsDead || NewLevelFlag)
                {
                    break;
                }
                if (monster.IsVisible)
                {
                    visible = true;
                }
                // Get the basic attack power from the attack type
                switch (effect)
                {
                    case AttackEffect.Hurt:
                        power = 60;
                        break;

                    case AttackEffect.Poison:
                        power = 5;
                        break;

                    case AttackEffect.UnBonus:
                        power = 20;
                        break;

                    case AttackEffect.UnPower:
                        power = 15;
                        break;

                    case AttackEffect.EatGold:
                        power = 5;
                        break;

                    case AttackEffect.EatItem:
                        power = 5;
                        break;

                    case AttackEffect.EatFood:
                        power = 5;
                        break;

                    case AttackEffect.EatLight:
                        power = 5;
                        break;

                    case AttackEffect.Acid:
                        power = 0;
                        break;

                    case AttackEffect.Electricity:
                        power = 10;
                        break;

                    case AttackEffect.Fire:
                        power = 10;
                        break;

                    case AttackEffect.Cold:
                        power = 10;
                        break;

                    case AttackEffect.Blind:
                        power = 2;
                        break;

                    case AttackEffect.Confuse:
                        power = 10;
                        break;

                    case AttackEffect.Terrify:
                        power = 10;
                        break;

                    case AttackEffect.Paralyze:
                        power = 2;
                        break;

                    case AttackEffect.LoseStr:
                        power = 0;
                        break;

                    case AttackEffect.LoseDex:
                        power = 0;
                        break;

                    case AttackEffect.LoseCon:
                        power = 0;
                        break;

                    case AttackEffect.LoseInt:
                        power = 0;
                        break;

                    case AttackEffect.LoseWis:
                        power = 0;
                        break;

                    case AttackEffect.LoseCha:
                        power = 0;
                        break;

                    case AttackEffect.LoseAll:
                        power = 2;
                        break;

                    case AttackEffect.Shatter:
                        power = 60;
                        break;

                    case AttackEffect.Exp10:
                        power = 5;
                        break;

                    case AttackEffect.Exp20:
                        power = 5;
                        break;

                    case AttackEffect.Exp40:
                        power = 5;
                        break;

                    case AttackEffect.Exp80:
                        power = 5;
                        break;
                }
                // Check if the monster actually hits us
                if (effect == 0 || MonsterCheckHitOnPlayer(power, monsterLevel))
                {
                    Disturb(true);
                    // Protection From Evil might repel the attack
                    if (player.TimedProtectionFromEvil > 0 && (race.Flags3 & MonsterFlag3.Evil) != 0 && player.Level >= monsterLevel &&
                        Program.Rng.RandomLessThan(100) + player.Level > 50)
                    {
                        if (monster.IsVisible)
                        {
                            // If it does, then they player knows the monster is evil
                            race.Knowledge.RFlags3 |= MonsterFlag3.Evil;
                        }
                        MsgPrint($"{monsterName} is repelled.");
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
                                act = Program.Rng.DieRoll(3) == 1
                                    ? "sings 'We are a happy family.'"
                                    : "sings 'I love you, you love me.'";
                                break;
                            }
                    }
                    // Print the message
                    if (!string.IsNullOrEmpty(act))
                    {
                        MsgPrint($"{monsterName} {act}");
                    }
                    obvious = true;
                    // Work out base damage done by the attack
                    damage = Program.Rng.DiceRoll(damageDice, damageSides);
                    int i;
                    int k;
                    Item item;
                    string itemName;
                    // Apply any modifiers to the damage
                    switch (effect)
                    {
                        case 0:
                            {
                                obvious = true;
                                damage = 0;
                                break;
                            }
                        case AttackEffect.Hurt:
                            {
                                // Normal damage is reduced by armour
                                obvious = true;
                                damage -= damage * (armourClass < 150 ? armourClass : 150) / 250;
                                player.TakeHit(damage, monsterDescription);
                                break;
                            }
                        case AttackEffect.Poison:
                            {
                                // Poison does additional damage
                                player.TakeHit(damage, monsterDescription);
                                if (!(player.HasPoisonResistance || player.TimedPoisonResistance != 0))
                                {
                                    // Hagarg Ryonis might save us from the additional damage
                                    if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                    {
                                        MsgPrint("Hagarg Ryonis's favour protects you!");
                                    }
                                    else if (player.SetTimedPoison(player.TimedPoison + Program.Rng.DieRoll(monsterLevel) + 5))
                                    {
                                        obvious = true;
                                    }
                                }
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsPois);
                                break;
                            }
                        case AttackEffect.UnBonus:
                            {
                                // Disenchantment might ruin our items
                                player.TakeHit(damage, monsterDescription);
                                if (!player.HasDisenchantResistance)
                                {
                                    if (ApplyDisenchant())
                                    {
                                        obvious = true;
                                    }
                                }
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsDisen);
                                break;
                            }
                        case AttackEffect.UnPower:
                            {
                                // Unpower might drain charges from our items
                                player.TakeHit(damage, monsterDescription);
                                for (k = 0; k < 10; k++)
                                {
                                    i = Program.Rng.RandomLessThan(InventorySlot.Pack);
                                    item = player.Inventory[i];
                                    if (item.ItemType != null)
                                    {
                                        continue;
                                    }
                                    if ((item.Category == ItemCategory.Staff ||
                                         item.Category == ItemCategory.Wand) && item.TypeSpecificValue != 0)
                                    {
                                        MsgPrint("Energy drains from your pack!");
                                        obvious = true;
                                        int j = monsterLevel;
                                        monster.Health += j * item.TypeSpecificValue * item.Count;
                                        if (monster.Health > monster.MaxHealth)
                                        {
                                            monster.Health = monster.MaxHealth;
                                        }
                                        if (TrackedMonsterIndex == monsterIndex)
                                        {
                                            player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                                        }
                                        item.TypeSpecificValue = 0;
                                        player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
                                        break;
                                    }
                                }
                                break;
                            }
                        case AttackEffect.EatGold:
                            {
                                // Steal some money
                                player.TakeHit(damage, monsterDescription);
                                obvious = true;
                                if ((player.TimedParalysis == 0 && Program.Rng.RandomLessThan(100) <
                                    player.AbilityScores[Ability.Dexterity].DexTheftAvoidance + player.Level) || player.HasAntiTheft)
                                {
                                    MsgPrint("You quickly protect your money pouch!");
                                    if (Program.Rng.RandomLessThan(3) != 0)
                                    {
                                        blinked = true;
                                    }
                                }
                                else
                                {
                                    // The amount of gold taken depends on how much you're carrying
                                    int gold = (player.Gold / 10) + Program.Rng.DieRoll(25);
                                    if (gold < 2)
                                    {
                                        gold = 2;
                                    }
                                    if (gold > 5000)
                                    {
                                        gold = (player.Gold / 20) + Program.Rng.DieRoll(3000);
                                    }
                                    if (gold > player.Gold)
                                    {
                                        gold = player.Gold;
                                    }
                                    player.Gold -= gold;
                                    // The monster gets the gold it stole, in case you kill it
                                    // before leaving the level
                                    monster.StolenGold += gold;
                                    // Inform the player what happened
                                    if (gold <= 0)
                                    {
                                        MsgPrint("Nothing was stolen.");
                                    }
                                    else if (player.Gold != 0)
                                    {
                                        MsgPrint("Your purse feels lighter.");
                                        MsgPrint($"{gold} coins were stolen!");
                                    }
                                    else
                                    {
                                        MsgPrint("Your purse feels lighter.");
                                        MsgPrint("All of your coins were stolen!");
                                    }
                                    player.RedrawNeeded.Set(RedrawFlag.PrGold);
                                    blinked = true;
                                }
                                break;
                            }
                        case AttackEffect.EatItem:
                            {
                                // Steal an item
                                player.TakeHit(damage, monsterDescription);
                                if ((player.TimedParalysis == 0 && Program.Rng.RandomLessThan(100) <
                                    player.AbilityScores[Ability.Dexterity].DexTheftAvoidance + player.Level) || player.HasAntiTheft)
                                {
                                    MsgPrint("You grab hold of your backpack!");
                                    blinked = true;
                                    obvious = true;
                                    break;
                                }
                                // Have ten tries at picking a suitable item to steal
                                for (k = 0; k < 10; k++)
                                {
                                    i = Program.Rng.RandomLessThan(InventorySlot.Pack);
                                    item = player.Inventory[i];
                                    if (item.ItemType == null)
                                    {
                                        continue;
                                    }
                                    if (item.IsFixedArtifact() || !string.IsNullOrEmpty(item.RandartName))
                                    {
                                        continue;
                                    }
                                    itemName = item.Description(false, 3);
                                    string y = item.Count > 1 ? "One of y" : "Y";
                                    MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was stolen!");
                                    int nextObjectIndex = Level.OPop();
                                    if (nextObjectIndex != 0)
                                    {
                                        // Give the item to the thief so it can later drop it
                                        Item stolenItem = new Item(this, item);
                                        level.Items[nextObjectIndex] = stolenItem;
                                        stolenItem.Count = 1;
                                        stolenItem.Marked = false;
                                        stolenItem.HoldingMonsterIndex = monsterIndex;
                                        stolenItem.NextInStack = monster.FirstHeldItemIndex;
                                        monster.FirstHeldItemIndex = nextObjectIndex;
                                    }
                                    player.Inventory.InvenItemIncrease(i, -1);
                                    player.Inventory.InvenItemOptimize(i);
                                    obvious = true;
                                    blinked = true;
                                    break;
                                }
                                break;
                            }
                        case AttackEffect.EatFood:
                            {
                                player.TakeHit(damage, monsterDescription);
                                // Have ten tries at grabbing a food item from the player
                                for (k = 0; k < 10; k++)
                                {
                                    i = Program.Rng.RandomLessThan(InventorySlot.Pack);
                                    item = player.Inventory[i];
                                    if (item.ItemType != null)
                                    {
                                        continue;
                                    }
                                    if (item.Category != ItemCategory.Food)
                                    {
                                        continue;
                                    }
                                    // Note that the monster doesn't actually get the food item -
                                    // it's gone
                                    itemName = item.Description(false, 0);
                                    string y = item.Count > 1 ? "One of y" : "Y";
                                    MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was eaten!");
                                    player.Inventory.InvenItemIncrease(i, -1);
                                    player.Inventory.InvenItemOptimize(i);
                                    obvious = true;
                                    break;
                                }
                                break;
                            }
                        case AttackEffect.EatLight:
                            {
                                player.TakeHit(damage, monsterDescription);
                                item = player.Inventory[InventorySlot.Lightsource];
                                // Only dim lights that consume fuel
                                if (item.TypeSpecificValue > 0 && !item.IsFixedArtifact())
                                {
                                    item.TypeSpecificValue -= 250 + Program.Rng.DieRoll(250);
                                    if (item.TypeSpecificValue < 1)
                                    {
                                        item.TypeSpecificValue = 1;
                                    }
                                    if (player.TimedBlindness == 0)
                                    {
                                        MsgPrint("Your light dims.");
                                        obvious = true;
                                    }
                                }
                                break;
                            }
                        case AttackEffect.Acid:
                            {
                                obvious = true;
                                MsgPrint("You are covered in acid!");
                                AcidDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsAcid);
                                break;
                            }
                        case AttackEffect.Electricity:
                            {
                                obvious = true;
                                MsgPrint("You are struck by electricity!");
                                ElecDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsElec);
                                break;
                            }
                        case AttackEffect.Fire:
                            {
                                obvious = true;
                                MsgPrint("You are enveloped in flames!");
                                FireDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFire);
                                break;
                            }
                        case AttackEffect.Cold:
                            {
                                obvious = true;
                                MsgPrint("You are covered with frost!");
                                ColdDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsCold);
                                break;
                            }
                        case AttackEffect.Blind:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (!player.HasBlindnessResistance)
                                {
                                    if (player.SetTimedBlindness(player.TimedBlindness + 10 + Program.Rng.DieRoll(monsterLevel)))
                                    {
                                        obvious = true;
                                    }
                                }
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsBlind);
                                break;
                            }
                        case AttackEffect.Confuse:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (!player.HasConfusionResistance)
                                {
                                    if (player.SetTimedConfusion(player.TimedConfusion + 3 + Program.Rng.DieRoll(monsterLevel)))
                                    {
                                        obvious = true;
                                    }
                                }
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsConf);
                                break;
                            }
                        case AttackEffect.Terrify:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.HasFearResistance)
                                {
                                    MsgPrint("You stand your ground!");
                                    obvious = true;
                                }
                                else if (Program.Rng.RandomLessThan(100) < player.SkillSavingThrow)
                                {
                                    MsgPrint("You stand your ground!");
                                    obvious = true;
                                }
                                else
                                {
                                    if (player.SetTimedFear(player.TimedFear + 3 + Program.Rng.DieRoll(monsterLevel)))
                                    {
                                        obvious = true;
                                    }
                                }
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFear);
                                break;
                            }
                        case AttackEffect.Paralyze:
                            {
                                if (damage == 0)
                                {
                                    damage = 1;
                                }
                                player.TakeHit(damage, monsterDescription);
                                if (player.HasFreeAction)
                                {
                                    MsgPrint("You are unaffected!");
                                    obvious = true;
                                }
                                else if (Program.Rng.RandomLessThan(100) < player.SkillSavingThrow)
                                {
                                    MsgPrint("You resist the effects!");
                                    obvious = true;
                                }
                                else
                                {
                                    if (player.SetTimedParalysis(player.TimedParalysis + 3 + Program.Rng.DieRoll(monsterLevel)))
                                    {
                                        obvious = true;
                                    }
                                }
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFree);
                                break;
                            }
                        case AttackEffect.LoseStr:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Strength))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.LoseInt:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Intelligence))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.LoseWis:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Wisdom))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.LoseDex:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Dexterity))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.LoseCon:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Constitution))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.LoseCha:
                            {
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Charisma))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.LoseAll:
                            {
                                // Try to decrease all six ability scores
                                player.TakeHit(damage, monsterDescription);
                                if (player.TryDecreasingAbilityScore(Ability.Strength))
                                {
                                    obvious = true;
                                }
                                if (player.TryDecreasingAbilityScore(Ability.Dexterity))
                                {
                                    obvious = true;
                                }
                                if (player.TryDecreasingAbilityScore(Ability.Constitution))
                                {
                                    obvious = true;
                                }
                                if (player.TryDecreasingAbilityScore(Ability.Intelligence))
                                {
                                    obvious = true;
                                }
                                if (player.TryDecreasingAbilityScore(Ability.Wisdom))
                                {
                                    obvious = true;
                                }
                                if (player.TryDecreasingAbilityScore(Ability.Charisma))
                                {
                                    obvious = true;
                                }
                                break;
                            }
                        case AttackEffect.Shatter:
                            {
                                obvious = true;
                                damage -= damage * (armourClass < 150 ? armourClass : 150) / 250;
                                player.TakeHit(damage, monsterDescription);
                                // Do an earthquake only if we did enough damage on the hit
                                if (damage > 23)
                                {
                                    Earthquake(monster.MapY, monster.MapX, 8);
                                }
                                break;
                            }
                        case AttackEffect.Exp10:
                            {
                                obvious = true;
                                player.TakeHit(damage, monsterDescription);
                                if (player.HasHoldLife && Program.Rng.RandomLessThan(100) < 95)
                                {
                                    MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(10, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        MsgPrint("You feel your life draining away!");
                                        player.LoseExperience(d);
                                    }
                                }
                                break;
                            }
                        case AttackEffect.Exp20:
                            {
                                obvious = true;
                                player.TakeHit(damage, monsterDescription);
                                if (player.HasHoldLife && Program.Rng.RandomLessThan(100) < 90)
                                {
                                    MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(20, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        MsgPrint("You feel your life draining away!");
                                        player.LoseExperience(d);
                                    }
                                }
                                break;
                            }
                        case AttackEffect.Exp40:
                            {
                                obvious = true;
                                player.TakeHit(damage, monsterDescription);
                                if (player.HasHoldLife && Program.Rng.RandomLessThan(100) < 75)
                                {
                                    MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(40, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        MsgPrint("You feel your life draining away!");
                                        player.LoseExperience(d);
                                    }
                                }
                                break;
                            }
                        case AttackEffect.Exp80:
                            {
                                obvious = true;
                                player.TakeHit(damage, monsterDescription);
                                if (player.HasHoldLife && Program.Rng.RandomLessThan(100) < 50)
                                {
                                    MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(80, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        MsgPrint("You feel your life draining away!");
                                        player.LoseExperience(d);
                                    }
                                }
                                break;
                            }
                    }
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
                            player.SetTimedBleeding(player.TimedBleeding + k);
                        }
                    }
                    if (doStun)
                    {
                        // Get how bad the hit was based on the actual damage out of the possible damage
                        critLevel = MonsterCritical(damageDice, damageSides, damage);
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
                            player.SetTimedStun(player.TimedStun + k);
                        }
                    }
                    // If the monster touched us then it may take damage from our defensive abilities
                    if (touched)
                    {
                        if (player.HasFireShield && alive)
                        {
                            if ((race.Flags3 & MonsterFlag3.ImmuneFire) == 0)
                            {
                                MsgPrint($"{monsterName} is suddenly very hot!");
                                if (level.Monsters.DamageMonster(monsterIndex, Program.Rng.DiceRoll(2, 6), out fear,
                                    " turns into a pile of ash."))
                                {
                                    blinked = false;
                                    alive = false;
                                }
                            }
                            else
                            {
                                // The player noticed that the monster took no fire damage
                                if (monster.IsVisible)
                                {
                                    race.Knowledge.RFlags3 |= MonsterFlag3.ImmuneFire;
                                }
                            }
                        }
                        if (player.HasLightningShield && alive)
                        {
                            if ((race.Flags3 & MonsterFlag3.ImmuneLightning) == 0)
                            {
                                MsgPrint($"{monsterName} gets zapped!");
                                if (level.Monsters.DamageMonster(monsterIndex, Program.Rng.DiceRoll(2, 6), out fear,
                                    " turns into a pile of cinder."))
                                {
                                    blinked = false;
                                    alive = false;
                                }
                            }
                            else
                            {
                                // The player noticed that the monster took no lightning damage
                                if (monster.IsVisible)
                                {
                                    race.Knowledge.RFlags3 |= MonsterFlag3.ImmuneLightning;
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
                            if (monster.IsVisible)
                            {
                                Disturb(true);
                                MsgPrint($"{monsterName} misses you.");
                            }
                            break;
                    }
                }
                // If the player saw the monster, they now know more about what attacks it can do
                if (visible)
                {
                    if (obvious || damage != 0 || race.Knowledge.RBlows[attackNumber] > 10)
                    {
                        if (race.Knowledge.RBlows[attackNumber] < Constants.MaxUchar)
                        {
                            race.Knowledge.RBlows[attackNumber]++;
                        }
                    }
                }
            }
            // If the monster teleported away after stealing, let the player know and do the actual teleport
            if (blinked)
            {
                MsgPrint("The thief flees laughing!");
                TeleportAway(monsterIndex, (Constants.MaxSight * 2) + 5);
            }
            // If the attack just killed the player, let future generations remember what killed
            // their ancestor
            if (player.IsDead && race.Knowledge.RDeaths < Constants.MaxShort)
            {
                race.Knowledge.RDeaths++;
            }
            // If the monster just got scared, let the player know
            if (monster.IsVisible && fear)
            {
                Gui.PlaySound(SoundEffect.MonsterFlees);
                MsgPrint($"{monsterName} flees in terror!");
            }
        }

        /// <summary>
        /// Check whether an attack hits the player.
        /// </summary>
        /// <param name="attackPower"> The power of the attack </param>
        /// <param name="monsterLevel"> The level of the monster making the attack </param>
        /// <returns> True if the attack hit, false if not </returns>
        private bool MonsterCheckHitOnPlayer(int attackPower, int monsterLevel)
        {
            // Straight five percent chance of hit or miss
            int k = Program.Rng.RandomLessThan(100);
            if (k < 10)
            {
                return k < 5;
            }
            // Otherwise, compare the power and level to the player's armour class
            int i = attackPower + (monsterLevel * 3);
            int ac = Player.BaseArmourClass + Player.ArmourClassBonus;
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
            IActivationPower artifactPower = item.BonusPowerSubType;

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
                Gui.PlaySound(SoundEffect.OpenDoor);
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
            if (item.ItemType != null && !item.IsFixedArtifact() && !item.IsRare() &&
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
                if (!Gui.GetCheck("Really use the power in your weakened state? "))
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
                Gui.PlaySound(SoundEffect.ShutDoor);
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
                if (trappedOnly && (!item.IsKnown() || GlobalData.ChestTraps[item.TypeSpecificValue] == 0))
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
            if (item.ItemType == null)
            {
                return false;
            }
            // Artifacts can't be cursed, and normal armour has a chance to save
            string itemName = item.Description(false, 3);
            if ((!string.IsNullOrEmpty(item.RandartName) || item.IsFixedArtifact()) &&
                Program.Rng.RandomLessThan(100) < 50)
            {
                MsgPrint(
                    $"A terrible black aura tries to surround your armour, but your {itemName} resists the effects!");
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
                item.RandartFlags1.Clear();
                item.RandartFlags2.Clear();
                item.RandartFlags3.Clear();
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
            if (item.ItemType == null)
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
                item.RandartFlags1.Clear();
                item.RandartFlags2.Clear();
                item.RandartFlags3.Clear();
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
        /// <returns> True if the player should be disturbed by the aciton </returns>
        public bool DisarmChest(int y, int x, int itemIndex)
        {
            bool more = false;
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
            else if (GlobalData.ChestTraps[item.TypeSpecificValue] == 0)
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
                more = true;
                MsgPrint("You failed to disarm the chest.");
            }
            else
            {
                MsgPrint("You set off a trap!");
                ChestTrap(y, x, itemIndex);
            }
            return more;
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
            int price = item.ItemType.Cost;
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
                if (item.ItemType == null)
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
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            if (!item.IsKnown())
            {
                return false;
            }
            item.GetMergedFlags(f1, f2, f3);
            return f3.IsSet(ItemFlag3.Activate);
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
                Gui.PlaySound(SoundEffect.BumpWall);
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
                Gui.QueuedCommand = '_';
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
        /// Open a chest at a given location
        /// </summary>
        /// <param name="y"> The y coordinate of the location </param>
        /// <param name="x"> The x coordinate of the location </param>
        /// <param name="itemIndex"> The index of the chest item </param>
        /// <returns> Whether or not the player should be disturbed by the action </returns>
        public bool OpenChestAtGivenLocation(int y, int x, int itemIndex)
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
                if (Player.TimedBlindness != 0 || Level.NoLight())
                {
                    i /= 10;
                }
                // Hard to pick locks when you're confused or hallucinating
                if (Player.TimedConfusion != 0 || Player.TimedHallucinations != 0)
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
                    Gui.PlaySound(SoundEffect.LockpickSuccess);
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
                Gui.PlaySound(SoundEffect.OpenDoor);
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
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
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
                MsgPrint(monster.IsVisible
                    ? $"You are too afraid to attack {monsterName}!"
                    : "There is something scary in your way!");
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
                    Gui.PlaySound(SoundEffect.MeleeHit);
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
                    item.GetMergedFlags(f1, f2, f3);
                    bool chaosEffect = f1.IsSet(ItemFlag1.Chaotic) && Program.Rng.DieRoll(2) == 1;
                    if (f1.IsSet(ItemFlag1.Vampiric) || (chaosEffect && Program.Rng.DieRoll(5) < 3))
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
                    bool vorpalCut = f1.IsSet(ItemFlag1.Vorpal) &&
                        Program.Rng.DieRoll(item.FixedArtifactIndex == FixedArtifactId.SwordVorpalBlade ? 3 : 6) == 1;
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
                                MsgPrint(monster.StunLevel != 0
                                    ? $"{monsterName} is more stunned."
                                    : $"{monsterName} is stunned.");
                                monster.StunLevel += stunEffect;
                            }
                        }
                    }
                    // We have a weapon
                    else if (item.ItemType != null)
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
                            MsgPrint(item.FixedArtifactIndex == FixedArtifactId.SwordVorpalBlade
                                ? "Your Vorpal Blade goes snicker-snack!"
                                : $"Your weapon cuts deep into {monsterName}!");
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
                        TeleportAway(tile.MonsterIndex, 50);
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
                    Gui.PlaySound(SoundEffect.Miss);
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
                Gui.PlaySound(SoundEffect.MonsterFlees);
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
        /// Have a potion affect the player
        /// </summary>
        /// <param name="itemSubCategory"> The sub-category of potion we're drinking </param>
        /// <returns> True if drinking the potion identified it </returns>
        public bool PotionEffect(int itemSubCategory)
        {
            bool identified = false;
            switch (itemSubCategory)
            {
                // Water or apple juice has no effect
                case PotionType.Water:
                case PotionType.AppleJuice:
                    {
                        MsgPrint("You feel less thirsty.");
                        identified = true;
                        break;
                    }
                // Slime mold juice has a random effect (calling this function again recusively)
                case PotionType.SlimeMold:
                    {
                        MsgPrint("That tastes awful.");
                        PotionEffect(RandomPotion());
                        identified = true;
                        break;
                    }
                // Slowness slows you down
                case PotionType.Slowness:
                    {
                        if (Player.SetTimedSlow(Player.TimedSlow + Program.Rng.DieRoll(25) + 15))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Salt water makes you vomit, but gets rid of poison
                case PotionType.SaltWater:
                    {
                        MsgPrint("The saltiness makes you vomit!");
                        Player.SetFood(Constants.PyFoodStarve - 1);
                        Player.SetTimedPoison(0);
                        Player.SetTimedParalysis(Player.TimedParalysis + 4);
                        identified = true;
                        break;
                    }
                // Poison simply poisons you
                case PotionType.Poison:
                    {
                        if (!(Player.HasPoisonResistance || Player.TimedPoisonResistance != 0))
                        {
                            // Hagarg Ryonis can protect you against poison
                            if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                            {
                                MsgPrint("Hagarg Ryonis's favour protects you!");
                            }
                            else if (Player.SetTimedPoison(Player.TimedPoison + Program.Rng.RandomLessThan(15) + 10))
                            {
                                identified = true;
                            }
                        }
                        break;
                    }
                // Blindness makes you blind
                case PotionType.Blindness:
                    {
                        if (!Player.HasBlindnessResistance)
                        {
                            if (Player.SetTimedBlindness(Player.TimedBlindness + Program.Rng.RandomLessThan(100) + 100))
                            {
                                identified = true;
                            }
                        }
                        break;
                    }
                // Confusion makes you confused and possibly other effects
                case PotionType.Confusion:
                    {
                        if (!(Player.HasConfusionResistance || Player.HasChaosResistance))
                        {
                            if (Player.SetTimedConfusion(Player.TimedConfusion + Program.Rng.RandomLessThan(20) + 15))
                            {
                                identified = true;
                            }
                            // 50% chance of having hallucinations
                            if (Program.Rng.DieRoll(2) == 1)
                            {
                                if (Player.SetTimedHallucinations(Player.TimedHallucinations + Program.Rng.RandomLessThan(150) + 150))
                                {
                                    identified = true;
                                }
                            }
                            // 1 in 13 chance of blacking out and waking up somewhere else
                            if (Program.Rng.DieRoll(13) == 1)
                            {
                                identified = true;
                                // 1 in 3 chance of losing your memories after blacking out
                                if (Program.Rng.DieRoll(3) == 1)
                                {
                                    LoseAllInfo();
                                }
                                else
                                {
                                    Level.WizDark();
                                }
                                TeleportPlayer(100);
                                Level.WizDark();
                                MsgPrint("You wake up somewhere with a sore head...");
                                MsgPrint("You can't remember a thing, or how you got here!");
                            }
                        }
                        break;
                    }
                // Sleep paralyses you
                case PotionType.Sleep:
                    {
                        if (!Player.HasFreeAction)
                        {
                            if (Player.SetTimedParalysis(Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4))
                            {
                                identified = true;
                            }
                        }
                        break;
                    }
                // Lose Memories reduces your experience
                case PotionType.LoseMemories:
                    {
                        if (!Player.HasHoldLife && Player.ExperiencePoints > 0)
                        {
                            MsgPrint("You feel your memories fade.");
                            Player.LoseExperience(Player.ExperiencePoints / 4);
                            identified = true;
                        }
                        break;
                    }
                // Ruination does 10d10 damage and reduces all your ability scores, bypassing
                // sustains and divine protection
                case PotionType.Ruination:
                    {
                        MsgPrint("Your nerves and muscles feel weak and lifeless!");
                        Player.TakeHit(Program.Rng.DiceRoll(10, 10), "a potion of Ruination");
                        Player.DecreaseAbilityScore(Ability.Dexterity, 25, true);
                        Player.DecreaseAbilityScore(Ability.Wisdom, 25, true);
                        Player.DecreaseAbilityScore(Ability.Constitution, 25, true);
                        Player.DecreaseAbilityScore(Ability.Strength, 25, true);
                        Player.DecreaseAbilityScore(Ability.Charisma, 25, true);
                        Player.DecreaseAbilityScore(Ability.Intelligence, 25, true);
                        identified = true;
                        break;
                    }
                // Weakness tries to reduce your strength
                case PotionType.DecStr:
                    {
                        if (Player.TryDecreasingAbilityScore(Ability.Strength))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Stupidity tries to reduce your intelligence
                case PotionType.DecInt:
                    {
                        if (Player.TryDecreasingAbilityScore(Ability.Intelligence))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Naivety tries to reduce your wisdom
                case PotionType.DecWis:
                    {
                        if (Player.TryDecreasingAbilityScore(Ability.Wisdom))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Clumsiness tries to reduce your dexterity
                case PotionType.DecDex:
                    {
                        if (Player.TryDecreasingAbilityScore(Ability.Dexterity))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Sickliness tries to reduce your constitution
                case PotionType.DecCon:
                    {
                        if (Player.TryDecreasingAbilityScore(Ability.Constitution))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Ugliness tries to reduce your charisma
                case PotionType.DecCha:
                    {
                        if (Player.TryDecreasingAbilityScore(Ability.Charisma))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Detonations does 50d20 damage, stuns you, and gives you a stupid amount of bleeding
                case PotionType.Detonations:
                    {
                        MsgPrint("Massive explosions rupture your body!");
                        Player.TakeHit(Program.Rng.DiceRoll(50, 20), "a potion of Detonation");
                        Player.SetTimedStun(Player.TimedStun + 75);
                        Player.SetTimedBleeding(Player.TimedBleeding + 5000);
                        identified = true;
                        break;
                    }
                // Iocaine simply does 5000 damage
                case PotionType.Death:
                    {
                        MsgPrint("A feeling of Death flows through your body.");
                        Player.TakeHit(5000, "a potion of Death");
                        identified = true;
                        break;
                    }
                // Infravision gives you timed infravision
                case PotionType.Infravision:
                    {
                        if (Player.SetTimedInfravision(Player.TimedInfravision + 100 + Program.Rng.DieRoll(100)))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Detect invisible gives you times see invisibility
                case PotionType.DetectInvis:
                    {
                        if (Player.SetTimedSeeInvisibility(Player.TimedSeeInvisibility + 12 + Program.Rng.DieRoll(12)))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Slow poison halves the remaining duration of any poison you have
                case PotionType.SlowPoison:
                    {
                        if (Player.SetTimedPoison(Player.TimedPoison / 2))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Cure poison removes any poison you have
                case PotionType.CurePoison:
                    {
                        if (Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Boldness stops you being afraid
                case PotionType.Boldness:
                    {
                        if (Player.SetTimedFear(0))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Speed temporarily hastes you
                case PotionType.Speed:
                    {
                        if (Player.TimedHaste == 0)
                        {
                            if (Player.SetTimedHaste(Program.Rng.DieRoll(25) + 15))
                            {
                                identified = true;
                            }
                        }
                        else
                        {
                            Player.SetTimedHaste(Player.TimedHaste + 5);
                        }
                        break;
                    }
                // Resist heat gives you timed fire resistance
                case PotionType.ResistHeat:
                    {
                        if (Player.SetTimedFireResistance(Player.TimedFireResistance + Program.Rng.DieRoll(10) + 10))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Resist cold gives you timed frost resistance
                case PotionType.ResistCold:
                    {
                        if (Player.SetTimedColdResistance(Player.TimedColdResistance + Program.Rng.DieRoll(10) + 10))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Heroism removes fear, cures 10 health, and gives you timed heroism
                case PotionType.Heroism:
                    {
                        if (Player.SetTimedFear(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedHeroism(Player.TimedHeroism + Program.Rng.DieRoll(25) + 25))
                        {
                            identified = true;
                        }
                        if (Player.RestoreHealth(10))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Berserk strength removes fear, heals 30 health, and gives you timed super heroism
                case PotionType.BeserkStrength:
                    {
                        if (Player.SetTimedFear(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedSuperheroism(Player.TimedSuperheroism + Program.Rng.DieRoll(25) + 25))
                        {
                            identified = true;
                        }
                        if (Player.RestoreHealth(30))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Cure light wounds heals you 2d8 health and reduces bleeding
                case PotionType.CureLight:
                    {
                        if (Player.RestoreHealth(Program.Rng.DiceRoll(2, 8)))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBleeding(Player.TimedBleeding - 10))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Cure serious wounds heals you 4d8 health, cures blindness and confusion, and
                // reduces bleeding
                case PotionType.CureSerious:
                    {
                        if (Player.RestoreHealth(Program.Rng.DiceRoll(4, 8)))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBlindness(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedConfusion(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBleeding((Player.TimedBleeding / 2) - 50))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Cure critical wounds heals you 6d8 health, and cures blindness, confusion, stun,
                // poison, and bleeding
                case PotionType.CureCritical:
                    {
                        if (Player.RestoreHealth(Program.Rng.DiceRoll(6, 8)))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBlindness(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedConfusion(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedStun(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBleeding(0))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Healing heals you 300 health, and cures blindness, confusion, stun, poison, and bleeding
                case PotionType.Healing:
                    {
                        if (Player.RestoreHealth(300))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBlindness(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedConfusion(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedStun(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBleeding(0))
                        {
                            identified = true;
                        }
                        break;
                    }
                // *Healing* heals you 1200 health, and cures blindness, confusion, stun, poison,
                // and bleeding
                case PotionType.StarHealing:
                    {
                        if (Player.RestoreHealth(1200))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBlindness(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedConfusion(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedStun(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBleeding(0))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Life heals you 5000 health, removes experience and ability score drains, and
                // cures blindness, confusion, stun, poison, and bleeding
                case PotionType.Life:
                    {
                        MsgPrint("You feel life flow through your body!");
                        Player.RestoreLevel();
                        Player.RestoreHealth(5000);
                        Player.SetTimedPoison(0);
                        Player.SetTimedBlindness(0);
                        Player.SetTimedConfusion(0);
                        Player.SetTimedHallucinations(0);
                        Player.SetTimedStun(0);
                        Player.SetTimedBleeding(0);
                        Player.TryRestoringAbilityScore(Ability.Strength);
                        Player.TryRestoringAbilityScore(Ability.Constitution);
                        Player.TryRestoringAbilityScore(Ability.Dexterity);
                        Player.TryRestoringAbilityScore(Ability.Wisdom);
                        Player.TryRestoringAbilityScore(Ability.Intelligence);
                        Player.TryRestoringAbilityScore(Ability.Charisma);
                        identified = true;
                        break;
                    }
                // Restore mana restores your to maximum mana
                case PotionType.RestoreMana:
                    {
                        if (Player.Mana < Player.MaxMana)
                        {
                            Player.Mana = Player.MaxMana;
                            Player.FractionalMana = 0;
                            MsgPrint("Your feel your head clear.");
                            Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                            identified = true;
                        }
                        break;
                    }
                // Restore life levels restores any lost experience
                case PotionType.RestoreExp:
                    {
                        if (Player.RestoreLevel())
                        {
                            identified = true;
                        }
                        break;
                    }
                // Restore strength restores your strength
                case PotionType.ResStr:
                    {
                        if (Player.TryRestoringAbilityScore(Ability.Strength))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Restore intelligence restores your intelligence
                case PotionType.ResInt:
                    {
                        if (Player.TryRestoringAbilityScore(Ability.Intelligence))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Restore wisdom restores your wisdom
                case PotionType.ResWis:
                    {
                        if (Player.TryRestoringAbilityScore(Ability.Wisdom))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Restore dexterity restores your dexterity
                case PotionType.ResDex:
                    {
                        if (Player.TryRestoringAbilityScore(Ability.Dexterity))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Restore constitution restores your constitution
                case PotionType.ResCon:
                    {
                        if (Player.TryRestoringAbilityScore(Ability.Constitution))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Restore charisma restores your charisma
                case PotionType.ResCha:
                    {
                        if (Player.TryRestoringAbilityScore(Ability.Charisma))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Strength increases your strength
                case PotionType.IncStr:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Strength))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Intelligence increases your intelligence
                case PotionType.IncInt:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Intelligence))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Wisdom increases your wisdom
                case PotionType.IncWis:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Wisdom))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Dexterity increases your dexterity
                case PotionType.IncDex:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Dexterity))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Constitution increases your constitution
                case PotionType.IncCon:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Constitution))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Charisma increases your charisma
                case PotionType.IncCha:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Charisma))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Augmentation increases all ability scores
                case PotionType.Augmentation:
                    {
                        if (Player.TryIncreasingAbilityScore(Ability.Strength))
                        {
                            identified = true;
                        }
                        if (Player.TryIncreasingAbilityScore(Ability.Intelligence))
                        {
                            identified = true;
                        }
                        if (Player.TryIncreasingAbilityScore(Ability.Wisdom))
                        {
                            identified = true;
                        }
                        if (Player.TryIncreasingAbilityScore(Ability.Dexterity))
                        {
                            identified = true;
                        }
                        if (Player.TryIncreasingAbilityScore(Ability.Constitution))
                        {
                            identified = true;
                        }
                        if (Player.TryIncreasingAbilityScore(Ability.Charisma))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Enlightenment shows you the whole level
                case PotionType.Enlightenment:
                    {
                        MsgPrint("An image of your surroundings forms in your mind...");
                        Level.WizLight();
                        identified = true;
                        break;
                    }
                // *Enlightenment* shows you the whole level, increases your intelligence and
                // wisdom, identifies all your items, and detects everything
                case PotionType.StarEnlightenment:
                    {
                        MsgPrint("You begin to feel more enlightened...");
                        MsgPrint(null);
                        Level.WizLight();
                        Player.TryIncreasingAbilityScore(Ability.Intelligence);
                        Player.TryIncreasingAbilityScore(Ability.Wisdom);
                        DetectTraps();
                        DetectDoors();
                        DetectStairs();
                        DetectTreasure();
                        DetectObjectsGold();
                        DetectObjectsNormal();
                        IdentifyPack();
                        SelfKnowledge();
                        identified = true;
                        break;
                    }
                // Self knowledge gives you information about yourself
                case PotionType.SelfKnowledge:
                    {
                        MsgPrint("You begin to know yourself a little better...");
                        MsgPrint(null);
                        SelfKnowledge();
                        identified = true;
                        break;
                    }
                // Experience increases your experience points by 50%, with a minimum of +10 and
                // maximuum of +10,000
                case PotionType.Experience:
                    {
                        if (Player.ExperiencePoints < Constants.PyMaxExp)
                        {
                            int ee = (Player.ExperiencePoints / 2) + 10;
                            if (ee > 100000)
                            {
                                ee = 100000;
                            }
                            MsgPrint("You feel more experienced.");
                            Player.GainExperience(ee);
                            identified = true;
                        }
                        break;
                    }
                // Resistance gives you all timed resistances
                case PotionType.Resistance:
                    {
                        Player.SetTimedAcidResistance(Player.TimedAcidResistance + Program.Rng.DieRoll(20) + 20);
                        Player.SetTimedLightningResistance(Player.TimedLightningResistance + Program.Rng.DieRoll(20) + 20);
                        Player.SetTimedFireResistance(Player.TimedFireResistance + Program.Rng.DieRoll(20) + 20);
                        Player.SetTimedColdResistance(Player.TimedColdResistance + Program.Rng.DieRoll(20) + 20);
                        Player.SetTimedPoisonResistance(Player.TimedPoisonResistance + Program.Rng.DieRoll(20) + 20);
                        identified = true;
                        break;
                    }
                // Curing heals you 50 health, and cures blindness, confusion, stun, poison,
                // bleeding, and hallucinations
                case PotionType.Curing:
                    {
                        if (Player.RestoreHealth(50))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBlindness(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedPoison(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedConfusion(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedStun(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedBleeding(0))
                        {
                            identified = true;
                        }
                        if (Player.SetTimedHallucinations(0))
                        {
                            identified = true;
                        }
                        break;
                    }
                // Invulnerability gives you temporary invulnerability
                case PotionType.Invulnerability:
                    {
                        Player.SetTimedInvulnerability(Player.TimedInvulnerability + Program.Rng.DieRoll(7) + 7);
                        identified = true;
                        break;
                    }
                // New life rerolls your health, cures all mutations, and restores you to your birth race
                case PotionType.NewLife:
                    {
                        Player.RerollHitPoints();
                        if (Player.Dna.HasMutations)
                        {
                            MsgPrint("You are cured of all mutations.");
                            Player.Dna.LoseAllMutations();
                            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                            HandleStuff();
                        }
                        if (Player.RaceIndex != Player.RaceIndexAtBirth)
                        {
                            var oldRaceName = Race.RaceInfo[Player.RaceIndexAtBirth].Title;
                            MsgPrint($"You feel more {oldRaceName} again.");
                            Player.ChangeRace(Player.RaceIndexAtBirth);
                            Level.RedrawSingleLocation(Player.MapY, Player.MapX);
                        }
                        identified = true;
                        break;
                    }
            }
            return identified;
        }

        /// <summary>
        /// Pick a random potion to use from a selection that won't kill us
        /// </summary>
        /// <returns> The item sub-category of the potion to use </returns>
        public int RandomPotion()
        {
            var itemSubCategory = 0;
            switch (Program.Rng.DieRoll(48))
            {
                case 1:
                    itemSubCategory = PotionType.Water;
                    break;

                case 2:
                    itemSubCategory = PotionType.AppleJuice;
                    break;

                case 3:
                    itemSubCategory = PotionType.Slowness;
                    break;

                case 4:
                    itemSubCategory = PotionType.SaltWater;
                    break;

                case 5:
                    itemSubCategory = PotionType.Poison;
                    break;

                case 6:
                    itemSubCategory = PotionType.Blindness;
                    break;

                case 7:
                    itemSubCategory = PotionType.Confusion;
                    break;

                case 8:
                    itemSubCategory = PotionType.Sleep;
                    break;

                case 9:
                    itemSubCategory = PotionType.Infravision;
                    break;

                case 10:
                    itemSubCategory = PotionType.DetectInvis;
                    break;

                case 11:
                    itemSubCategory = PotionType.SlowPoison;
                    break;

                case 12:
                    itemSubCategory = PotionType.CurePoison;
                    break;

                case 13:
                    itemSubCategory = PotionType.Boldness;
                    break;

                case 14:
                    itemSubCategory = PotionType.Speed;
                    break;

                case 15:
                    itemSubCategory = PotionType.ResistHeat;
                    break;

                case 16:
                    itemSubCategory = PotionType.ResistCold;
                    break;

                case 17:
                    itemSubCategory = PotionType.Heroism;
                    break;

                case 18:
                    itemSubCategory = PotionType.BeserkStrength;
                    break;

                case 19:
                    itemSubCategory = PotionType.CureLight;
                    break;

                case 20:
                    itemSubCategory = PotionType.CureSerious;
                    break;

                case 21:
                    itemSubCategory = PotionType.CureCritical;
                    break;

                case 22:
                    itemSubCategory = PotionType.Healing;
                    break;

                case 23:
                    itemSubCategory = PotionType.StarHealing;
                    break;

                case 24:
                    itemSubCategory = PotionType.Life;
                    break;

                case 25:
                    itemSubCategory = PotionType.RestoreMana;
                    break;

                case 26:
                    itemSubCategory = PotionType.RestoreExp;
                    break;

                case 27:
                    itemSubCategory = PotionType.ResStr;
                    break;

                case 28:
                    itemSubCategory = PotionType.ResInt;
                    break;

                case 29:
                    itemSubCategory = PotionType.ResWis;
                    break;

                case 30:
                    itemSubCategory = PotionType.ResDex;
                    break;

                case 31:
                    itemSubCategory = PotionType.ResCon;
                    break;

                case 32:
                    itemSubCategory = PotionType.ResCha;
                    break;

                case 33:
                    itemSubCategory = PotionType.IncStr;
                    break;

                case 34:
                    itemSubCategory = PotionType.IncInt;
                    break;

                case 35:
                    itemSubCategory = PotionType.IncWis;
                    break;

                case 36:
                    itemSubCategory = PotionType.IncDex;
                    break;

                case 38:
                    itemSubCategory = PotionType.IncCon;
                    break;

                case 39:
                    itemSubCategory = PotionType.IncCha;
                    break;

                case 40:
                    itemSubCategory = PotionType.Augmentation;
                    break;

                case 41:
                    itemSubCategory = PotionType.Enlightenment;
                    break;

                case 42:
                    itemSubCategory = PotionType.StarEnlightenment;
                    break;

                case 43:
                    itemSubCategory = PotionType.SelfKnowledge;
                    break;

                case 44:
                    itemSubCategory = PotionType.Experience;
                    break;

                case 45:
                    itemSubCategory = PotionType.Resistance;
                    break;

                case 46:
                    itemSubCategory = PotionType.Curing;
                    break;

                case 47:
                    itemSubCategory = PotionType.Invulnerability;
                    break;

                case 48:
                    itemSubCategory = PotionType.NewLife;
                    break;
            }
            return itemSubCategory;
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
            item.RandartFlags3.Set(ItemFlag3.IgnoreAcid);
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
                            if (GlobalData.ChestTraps[item.TypeSpecificValue] == 0)
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
                Gui.PlaySound(SoundEffect.Dig);
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
                        item.AssignItemType(ItemTypes.LookupKind(ItemCategory.Food, FoodType.Ration));
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
                        if (!Gui.GetCom("Use Dream [T]ravel or [D]reaming? ", out char ch))
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
                    Gui.PlaySound(SoundEffect.LockpickSuccess);
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
                Gui.PlaySound(SoundEffect.OpenDoor);
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
                Gui.PlaySound(SoundEffect.MeleeHit);
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
                Gui.PlaySound(SoundEffect.Miss);
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
                ProcessMonster(i, noise);
                // If the monster killed the player or sent us to a new level, then stop processing
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    break;
                }
            }
            Level.Monsters.CurrentlyActingMonster = 0;
        }

        /// <summary>
        /// Make a set of attacks on another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster making the attack </param>
        /// <param name="targetIndex"> The index of the target monster </param>
        /// <returns> True if the attack happened, false if not </returns>
        private bool AttackAnotherMonster(int monsterIndex, int targetIndex)
        {
            Monster monster = Level.Monsters[monsterIndex];
            Monster target = Level.Monsters[targetIndex];
            MonsterRace race = monster.Race;
            MonsterRace targetRace = target.Race;
            bool touched = false;
            int ySaver = target.MapY;
            int xSaver = target.MapX;
            // If we never attack then we shouldn't this time
            if ((race.Flags1 & MonsterFlag1.NeverAttack) != 0)
            {
                return false;
            }
            int armourClass = targetRace.ArmourClass;
            int monsterLevel = race.Level >= 1 ? race.Level : 1;
            string monsterName = monster.MonsterDesc(0);
            string targetName = target.MonsterDesc(0);
            monster.MonsterDesc(0x88);
            bool blinked = false;
            // If the player can't see either monster, they just hear noise
            if (!(monster.IsVisible || target.IsVisible))
            {
                MsgPrint("You hear noise.");
            }
            // We have up to four attacks
            for (int attackNumber = 0; attackNumber < 4; attackNumber++)
            {
                bool visible = false;
                bool obvious = false;
                int power = 0;
                int damage = 0;
                string act = null;
                AttackEffect effect = race.Attack[attackNumber].Effect;
                AttackType method = race.Attack[attackNumber].Method;
                int dDice = race.Attack[attackNumber].DDice;
                int dSide = race.Attack[attackNumber].DSide;
                // Can't attack ourselves
                if (target == monster)
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
                if (monster.IsVisible)
                {
                    visible = true;
                }
                // Get the power of the attack based on the attack type
                switch (effect)
                {
                    case AttackEffect.Hurt:
                        power = 60;
                        break;

                    case AttackEffect.Poison:
                        power = 5;
                        break;

                    case AttackEffect.UnBonus:
                        power = 20;
                        break;

                    case AttackEffect.UnPower:
                        power = 15;
                        break;

                    case AttackEffect.EatGold:
                        power = 5;
                        break;

                    case AttackEffect.EatItem:
                        power = 5;
                        break;

                    case AttackEffect.EatFood:
                        power = 5;
                        break;

                    case AttackEffect.EatLight:
                        power = 5;
                        break;

                    case AttackEffect.Acid:
                        power = 0;
                        break;

                    case AttackEffect.Electricity:
                        power = 10;
                        break;

                    case AttackEffect.Fire:
                        power = 10;
                        break;

                    case AttackEffect.Cold:
                        power = 10;
                        break;

                    case AttackEffect.Blind:
                        power = 2;
                        break;

                    case AttackEffect.Confuse:
                        power = 10;
                        break;

                    case AttackEffect.Terrify:
                        power = 10;
                        break;

                    case AttackEffect.Paralyze:
                        power = 2;
                        break;

                    case AttackEffect.LoseStr:
                        power = 0;
                        break;

                    case AttackEffect.LoseDex:
                        power = 0;
                        break;

                    case AttackEffect.LoseCon:
                        power = 0;
                        break;

                    case AttackEffect.LoseInt:
                        power = 0;
                        break;

                    case AttackEffect.LoseWis:
                        power = 0;
                        break;

                    case AttackEffect.LoseCha:
                        power = 0;
                        break;

                    case AttackEffect.LoseAll:
                        power = 2;
                        break;

                    case AttackEffect.Shatter:
                        power = 60;
                        break;

                    case AttackEffect.Exp10:
                        power = 5;
                        break;

                    case AttackEffect.Exp20:
                        power = 5;
                        break;

                    case AttackEffect.Exp40:
                        power = 5;
                        break;

                    case AttackEffect.Exp80:
                        power = 5;
                        break;
                }
                // If we hit the monster, describe the type of hit
                if (effect == 0 || CheckHitMonsterVersusMonster(power, monsterLevel, armourClass))
                {
                    Disturb(true);
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
                        if (monster.IsVisible || target.IsVisible)
                        {
                            MsgPrint($"{monsterName} {temp}");
                        }
                    }
                    obvious = true;
                    damage = Program.Rng.DiceRoll(dDice, dSide);
                    // Default to a missile attack
                    Projectile pt = new ProjectMissile(this);
                    // Choose the correct type of attack to display, as well as any other special
                    // effects for the attack
                    switch (effect)
                    {
                        case 0:
                            damage = 0;
                            pt = null;
                            break;

                        case AttackEffect.Hurt:
                            damage -= damage * (armourClass < 150 ? armourClass : 150) / 250;
                            break;

                        case AttackEffect.Poison:
                            pt = new ProjectPois(this);
                            break;

                        case AttackEffect.UnBonus:
                        case AttackEffect.UnPower:
                            pt = new ProjectDisenchant(this);
                            break;

                        case AttackEffect.EatFood:
                        case AttackEffect.EatLight:
                            pt = null;
                            damage = 0;
                            break;

                        case AttackEffect.EatItem:
                        case AttackEffect.EatGold:
                            // Monsters don't actually steal from other monsters
                            pt = null;
                            damage = 0;
                            if (Program.Rng.DieRoll(2) == 1)
                            {
                                blinked = true;
                            }
                            break;

                        case AttackEffect.Acid:
                            pt = new ProjectAcid(this);
                            break;

                        case AttackEffect.Electricity:
                            pt = new ProjectElec(this);
                            break;

                        case AttackEffect.Fire:
                            pt = new ProjectFire(this);
                            break;

                        case AttackEffect.Cold:
                            pt = new ProjectCold(this);
                            break;

                        case AttackEffect.Blind:
                            break;

                        case AttackEffect.Confuse:
                            pt = new ProjectConfusion(this);
                            break;

                        case AttackEffect.Terrify:
                            pt = new ProjectTurnAll(this);
                            break;

                        case AttackEffect.Paralyze:
                            pt = new ProjectOldSleep(this);
                            damage = race.Level;
                            break;

                        case AttackEffect.LoseStr:
                        case AttackEffect.LoseInt:
                        case AttackEffect.LoseWis:
                        case AttackEffect.LoseDex:
                        case AttackEffect.LoseCon:
                        case AttackEffect.LoseCha:
                        case AttackEffect.LoseAll:
                            break;

                        case AttackEffect.Shatter:
                            if (damage > 23)
                            {
                                Earthquake(monster.MapY, monster.MapX, 8);
                            }
                            break;

                        case AttackEffect.Exp10:
                        case AttackEffect.Exp20:
                        case AttackEffect.Exp40:
                        case AttackEffect.Exp80:
                            pt = new ProjectNether(this);
                            break;

                        default:
                            pt = null;
                            break;
                    }
                    // Implement the attack as a projectile
                    if (pt != null)
                    {
                        Project(monsterIndex, 0, target.MapY, target.MapX, damage, pt,
                            ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                        // If we touched the target we might get burned or zapped
                        if (touched)
                        {
                            if ((targetRace.Flags2 & MonsterFlag2.FireAura) != 0 && (race.Flags3 & MonsterFlag3.ImmuneFire) == 0)
                            {
                                if (monster.IsVisible || target.IsVisible)
                                {
                                    // Auras prevent us blinking away
                                    blinked = false;
                                    // The player may see and learn that the target has the aura
                                    MsgPrint($"{monsterName} is suddenly very hot!");
                                    if (target.IsVisible)
                                    {
                                        targetRace.Knowledge.RFlags2 |= MonsterFlag2.FireAura;
                                    }
                                }
                                Project(targetIndex, 0, monster.MapY, monster.MapX,
                                    Program.Rng.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)),
                                    new ProjectFire(this), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
                            }
                            if ((targetRace.Flags2 & MonsterFlag2.LightningAura) != 0 && (race.Flags3 & MonsterFlag3.ImmuneLightning) == 0)
                            {
                                if (monster.IsVisible || target.IsVisible)
                                {
                                    // Auras prevent us blinking away
                                    blinked = false;
                                    // The player may see and learn that the target has the aura
                                    MsgPrint($"{monsterName} gets zapped!");
                                    if (target.IsVisible)
                                    {
                                        targetRace.Knowledge.RFlags2 |= MonsterFlag2.LightningAura;
                                    }
                                }
                                Project(targetIndex, 0, monster.MapY, monster.MapX,
                                    Program.Rng.DiceRoll(1 + (targetRace.Level / 26), 1 + (targetRace.Level / 17)),
                                    new ProjectElec(this), ProjectionFlag.ProjectKill | ProjectionFlag.ProjectStop);
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
                            if (monster.IsVisible)
                            {
                                Disturb(false);
                                MsgPrint($"{monsterName} misses {targetName}.");
                            }
                            break;
                    }
                }
                // If the player saw what happened, they know more abouyt what attacks we have
                if (visible)
                {
                    if (obvious || damage != 0 || race.Knowledge.RBlows[attackNumber] > 10)
                    {
                        if (race.Knowledge.RBlows[attackNumber] < Constants.MaxUchar)
                        {
                            race.Knowledge.RBlows[attackNumber]++;
                        }
                    }
                }
            }
            // If we stole and should therefore blink away, then do so.
            if (blinked)
            {
                MsgPrint(monster.IsVisible ? "The thief flees laughing!" : "You hear laughter!");
                TeleportAway(monsterIndex, (Constants.MaxSight * 2) + 5);
            }
            // We made the attack
            return true;
        }

        /// <summary>
        /// Modify a monster's move away from the player based on where their scent is coming from
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <param name="coord"> The location we're moving to </param>
        private void AvoidPlayersScent(int monsterIndex, MapCoordinate coord)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            int monsterY = monster.MapY;
            int monsterX = monster.MapX;
            int dY = monsterY - coord.Y;
            int dX = monsterX - coord.X;
            // If the scent too strong, keep going where we were going
            if (Level.Grid[monsterY][monsterX].ScentAge < Level.Grid[Player.MapY][Player.MapX].ScentAge)
            {
                return;
            }
            if (Level.Grid[monsterY][monsterX].ScentStrength > Constants.MonsterFlowDepth)
            {
                return;
            }
            if (Level.Grid[monsterY][monsterX].ScentStrength > race.NoticeRange)
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
                int y = monsterY + Level.OrderedDirectionYOffset[i];
                int x = monsterX + Level.OrderedDirectionXOffset[i];
                // If we have no scent there, or the scent is too recent, ignore it
                if (Level.Grid[y][x].ScentAge == 0)
                {
                    continue;
                }
                if (Level.Grid[y][x].ScentAge < when)
                {
                    continue;
                }
                // If the scent is weaker than in the other directions, go that way
                int dis = Level.Distance(y, x, dY, dX);
                int s = (5000 / (dis + 3)) - (500 / (Level.Grid[y][x].ScentStrength + 1));
                if (s < 0)
                {
                    s = 0;
                }
                if (s < score)
                {
                    continue;
                }
                when = Level.Grid[y][x].ScentAge;
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
        /// Use a breath weapon on another monster
        /// </summary>
        /// <param name="monsterIndex"> The monster doing the breathing </param>
        /// <param name="targetY"> The y coordinate of the target </param>
        /// <param name="targetX"> The x coordinate of the target </param>
        /// <param name="projectile"> The type of breath being used </param>
        /// <param name="damage"> The damage the breath will do </param>
        /// <param name="radius"> The radius of the attack, or zero for the default radius </param>
        private void BreatheAtMonster(int monsterIndex, int targetY, int targetX, Projectile projectile, int damage, int radius)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // Radius 0 means use the default radius
            if (radius < 1)
            {
                radius = (race.Flags2 & MonsterFlag2.Powerful) != 0 ? 3 : 2;
            }
            // Make the radius negative to indicate we need a cone instead of a ball
            radius = 0 - radius;
            Project(monsterIndex, radius, targetY, targetX, damage, projectile, projectionFlags);
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
        private void BreatheAtPlayer(int monsterIndex, Projectile projectile, int damage, int radius)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // Radius 0 means use the default radius
            if (radius < 1)
            {
                radius = (race.Flags2 & MonsterFlag2.Powerful) != 0 ? 3 : 2;
            }
            // Make the radius negative to indicate we need a cone instead of a ball
            radius = 0 - radius;
            Project(monsterIndex, radius, Player.MapY, Player.MapX, damage, projectile, projectionFlags);
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
        /// <param name="spells">
        /// A list of the 'magic numbers' of the spells the monster can cast
        /// </param>
        /// <param name="listSize"> The number of spells in the spell list </param>
        /// <returns> The 'magic number' of the spell the monster will cast </returns>
        private int ChooseSpellAgainstPlayer(int monsterIndex, int[] spells, int listSize)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // If the monster is stupid, cast a random spell
            if ((race.Flags2 & MonsterFlag2.Stupid) != 0)
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
            if (monster.Health < monster.MaxHealth / 3 || monster.FearLevel != 0)
            {
                if (escapeNum != 0)
                {
                    return escape[Program.Rng.RandomLessThan(escapeNum)];
                }
            }
            // Priority Two: If we're hurt, always use a random healing spell if we have one
            if (monster.Health < monster.MaxHealth / 3)
            {
                if (healNum != 0)
                {
                    return heal[Program.Rng.RandomLessThan(healNum)];
                }
            }
            // Priority Three: If we're near the player and have no attack spells, probably use a
            // tactical spell
            if (Level.Distance(Player.MapY, Player.MapX, monster.MapY, monster.MapX) < 4 && attackNum != 0 &&
                Program.Rng.RandomLessThan(100) < 75)
            {
                if (tacticNum != 0)
                {
                    return tactic[Program.Rng.RandomLessThan(tacticNum)];
                }
            }
            // Priority Four: If we're at less than full health, probably use a healing spell
            if (monster.Health < monster.MaxHealth * 3 / 4 && Program.Rng.RandomLessThan(100) < 75)
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
            if (hasteNum != 0 && Program.Rng.RandomLessThan(100) < 20 + race.Speed - monster.Speed)
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
        /// Use the same algorithm that we use for missiles to see if we have a clean shot between
        /// two locations, but without actually shooting anything
        /// </summary>
        /// <param name="startY"> The start Y </param>
        /// <param name="startX"> The start X </param>
        /// <param name="targetY"> The Target Y </param>
        /// <param name="targetX"> The Target X </param>
        /// <returns> </returns>
        private bool CleanShot(int startY, int startX, int targetY, int targetX)
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
        /// Try to find a position where the player can't see you from which to ambush them
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster that is trying to hide </param>
        /// <param name="relativeTarget">
        /// A map location, which will be amended to contain the hiding spot
        /// </param>
        /// <returns> True if a hiding spot was found, or false if it wasn't </returns>
        private bool FindAmbushSpot(int monsterIndex, MapCoordinate relativeTarget)
        {
            Monster monster = Level.Monsters[monsterIndex];
            int fy = monster.MapY;
            int fx = monster.MapX;
            int hidingSpotY = 0;
            int hidingSpotX = 0;
            int shortestDistance = 999;
            int tooCloseToPlayer = (Level.Distance(Player.MapY, Player.MapX, fy, fx) * 3 / 4) + 2;
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
                        if (!Level.InBounds(y, x))
                        {
                            continue;
                        }
                        if (!Level.GridPassable(y, x))
                        {
                            continue;
                        }
                        // Make sure the spot is the right distance
                        if (Level.Distance(y, x, fy, fx) != d)
                        {
                            continue;
                        }
                        // Make sure the spot is actually hidden
                        if (!Level.PlayerCanSeeBold(y, x) && CleanShot(fy, fx, y, x))
                        {
                            // If the spot is closer to the player than any previously found spot
                            // (but not too close), remember it
                            int dis = Level.Distance(y, x, Player.MapY, Player.MapX);
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
        /// Find a spot that as far from the player as possible an safe from attack
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster trying to find safety </param>
        /// <param name="relativeTarget">
        /// A map location, which will be amended to contain the safe spot
        /// </param>
        /// <returns> True if a safe spot was found, or false if it wasn't </returns>
        private bool FindSafeSpot(int monsterIndex, MapCoordinate relativeTarget)
        {
            Monster monster = Level.Monsters[monsterIndex];
            int fy = monster.MapY;
            int fx = monster.MapX;
            int safeSpotY = 0;
            int safeSpotX = 0;
            int longestDistance = 0;
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
                        if (!Level.InBounds(y, x))
                        {
                            continue;
                        }
                        if (!Level.GridPassable(y, x))
                        {
                            continue;
                        }
                        // Make sure the spot is the right distance
                        if (Level.Distance(y, x, fy, fx) != d)
                        {
                            continue;
                        }
                        // Reject spots that smell too strongly of the player
                        if (Level.Grid[y][x].ScentAge < Level.Grid[Player.MapY][Player.MapX].ScentAge)
                        {
                            continue;
                        }
                        if (Level.Grid[y][x].ScentStrength > Level.Grid[fy][fx].ScentStrength + (2 * d))
                        {
                            continue;
                        }
                        // Make sure the spot is actually hidden
                        if (!Level.Projectable(y, x, Player.MapY, Player.MapX))
                        {
                            // If the spot is further from the player than any previously found
                            // spot, remember it
                            int dis = Level.Distance(y, x, Player.MapY, Player.MapX);
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
                    relativeTarget.Y = fy - safeSpotY;
                    relativeTarget.X = fx - safeSpotX;
                    return true;
                }
            }
            // We found nowhere suitable
            return false;
        }

        /// <summary>
        /// Fire some kind of ball attack at the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster firing the attack </param>
        /// <param name="projectile"> The type of effect the ball has </param>
        /// <param name="damage"> The damage done by the ball </param>
        /// <param name="radius"> The radius of the ball, or zero to use the default radius </param>
        private void FireBallAtPlayer(int monsterIndex, Projectile projectile, int damage, int radius)
        {
            const ProjectionFlag projectionFlag = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectKill;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            if (radius < 1)
            {
                radius = (race.Flags2 & MonsterFlag2.Powerful) != 0 ? 3 : 2;
            }
            Project(monsterIndex, radius, Player.MapY, Player.MapX, damage, projectile, projectionFlag);
        }

        /// <summary>
        /// Fire a bolt of some kind at another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster doing the firing </param>
        /// <param name="targetY"> The y coordinate of the target </param>
        /// <param name="targetX"> The x coordinate of the target </param>
        /// <param name="projectile"> The projectile to be fired </param>
        /// <param name="damage"> The damage the projectile should do </param>
        private void FireBoltAtMonster(int monsterIndex, int targetY, int targetX, Projectile projectile, int damage)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            Project(monsterIndex, 0, targetY, targetX, damage, projectile, projectionFlags);
        }

        /// <summary>
        /// Cast a bolt spell at the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster casting the bolt </param>
        /// <param name="projectile"> The projectile being used for the bolt </param>
        /// <param name="damage"> The damage that the bolt will do </param>
        private void FireBoltAtPlayer(int monsterIndex, Projectile projectile, int damage)
        {
            const ProjectionFlag projectionFlags = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            Project(monsterIndex, 0, Player.MapY, Player.MapX, damage, projectile, projectionFlags);
        }

        /// <summary>
        /// Get a list of potential moves towards an enemy monster if there is one
        /// </summary>
        /// <param name="monster"> The monster making the moves </param>
        /// <param name="movesList"> The list in which to insert the moves </param>
        private void GetMovesTowardsEnemyMonsters(Monster monster, PotentialMovesList movesList)
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
                int y = monster.MapY + spiralGridOffsets[i][0];
                int x = monster.MapX + spiralGridOffsets[i][1];
                // Check if we're in bounds and have a monster
                if (Level.InBounds(y, x))
                {
                    if (Level.Grid[y][x].MonsterIndex != 0)
                    {
                        Monster enemy = Level.Monsters[Level.Grid[y][x].MonsterIndex];
                        // Only go for monsters who are awake and on the opposing side
                        if ((enemy.Mind & Constants.SmFriendly) != (monster.Mind & Constants.SmFriendly) &&
                            enemy.SleepLevel == 0)
                        {
                            // Add moves directly towards and either side of the enemy based on its
                            // relative location
                            x -= monster.MapX;
                            y -= monster.MapY;
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
        /// Populate a list with possible moves towards the player. Note that we won't always move
        /// directly towards the player, based on factors such as if we're in a group in a room or
        /// if we're afraid of the player.
        /// </summary>
        /// <param name="monsterIndex"> the index of the monster who is moving </param>
        /// <param name="movesList"> The list to be populated with moves </param>
        /// <returns> True if we have potential moves or false if we don't </returns>
        private bool GetMovesTowardsPlayer(int monsterIndex, PotentialMovesList movesList)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            int moveVal = 0;
            bool done = false;
            // Default to moving towards the player's exact location
            MapCoordinate targetLocation = new MapCoordinate(Player.MapX, Player.MapY);
            // Adjust our target based on the player's scent if we can't move in a straight line to them
            TrackPlayerByScent(monsterIndex, targetLocation);
            // Get the relative move needed to reach our target location
            MapCoordinate desiredRelativeMovement = new MapCoordinate();
            desiredRelativeMovement.Y = monster.MapY - targetLocation.Y;
            desiredRelativeMovement.X = monster.MapX - targetLocation.X;
            if ((monster.Mind & Constants.SmFriendly) == 0)
            {
                // If we're a pack animal that can't go through walls
                if ((race.Flags1 & MonsterFlag1.Friends) != 0 && (race.Flags3 & MonsterFlag3.Animal) != 0 &&
                    (race.Flags2 & MonsterFlag2.PassWall) == 0 && (race.Flags2 & MonsterFlag2.KillWall) == 0)
                {
                    int room = 0;
                    // Check if the player is in a room by counting the room tiles around them
                    for (int i = 0; i < 8; i++)
                    {
                        if (Level.Grid[Player.MapY + Level.OrderedDirectionYOffset[i]][Player.MapX + Level.OrderedDirectionXOffset[i]].TileFlags
                            .IsSet(GridTile.InRoom))
                        {
                            room++;
                        }
                    }
                    // If the player isn't in a room and they're healthy, wait to ambush them rather
                    // than running headlong into the corridor after them and queueing up to get hit
                    if (room < 8 && Player.Health > Player.MaxHealth * 3 / 4)
                    {
                        if (FindAmbushSpot(monsterIndex, desiredRelativeMovement))
                        {
                            done = true;
                        }
                    }
                }
                // If we're not done and we have friends make our movement slightly depend on our
                // index so we spread out and don't block each other
                if (!done && (race.Flags1 & MonsterFlag1.Friends) != 0)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        targetLocation.Y = Player.MapY + Level.OrderedDirectionYOffset[(monsterIndex + i) & 7];
                        targetLocation.X = Player.MapX + Level.OrderedDirectionXOffset[(monsterIndex + i) & 7];
                        // We might have got a '5' meaning stay where we are, so replace that with
                        // moving towards the player
                        if (monster.MapY == targetLocation.Y && monster.MapX == targetLocation.X)
                        {
                            targetLocation.Y = Player.MapY;
                            targetLocation.X = Player.MapX;
                            break;
                        }
                        // Repeat till we get a direction we can move in
                        if (!Level.GridPassableNoCreature(targetLocation.Y, targetLocation.X))
                        {
                            continue;
                        }
                        break;
                    }
                    desiredRelativeMovement.Y = monster.MapY - targetLocation.Y;
                    desiredRelativeMovement.X = monster.MapX - targetLocation.X;
                    done = true;
                }
            }
            // If we're an ally then check if we should retreat
            if ((monster.Mind & Constants.SmFriendly) != 0)
            {
                if (MonsterShouldRetreat(monsterIndex))
                {
                    // If we should be scared, simply move the opposite way to the player
                    desiredRelativeMovement.Y = -desiredRelativeMovement.Y;
                    desiredRelativeMovement.X = -desiredRelativeMovement.X;
                }
            }
            else
            {
                // If we're not an ally then check if we should retreat
                if (!done && MonsterShouldRetreat(monsterIndex))
                {
                    // If we should retreat, then try to find a safe spot where the player can't
                    // shoot or see us
                    if (!FindSafeSpot(monsterIndex, desiredRelativeMovement))
                    {
                        // If we failed to find one, just back off
                        desiredRelativeMovement.Y = -desiredRelativeMovement.Y;
                        desiredRelativeMovement.X = -desiredRelativeMovement.X;
                    }
                    else
                    {
                        // We found a safe spot, so head there, but prioritise avoiding the player's scent
                        AvoidPlayersScent(monsterIndex, desiredRelativeMovement);
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
        /// Check if a monster will decide to run away from the player. Note that this doesn't
        /// decide whether the monster should become scared, only whether or not it will move away
        /// (if it is scared this is likely)
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <returns> True if the monster should run away, false if not </returns>
        private bool MonsterShouldRetreat(int monsterIndex)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // Don't move away if we're already too far away to see the player
            if (monster.DistanceFromPlayer > Constants.MaxSight + 5)
            {
                return false;
            }
            // If we're the player's friend then don't move away from them
            if ((monster.Mind & Constants.SmFriendly) != 0)
            {
                return false;
            }
            // If we're scared then definitely move away
            if (monster.FearLevel != 0)
            {
                return true;
            }
            // If we're very close, stay close for potential melee
            if (monster.DistanceFromPlayer <= 5)
            {
                return false;
            }
            int playerLevel = Player.Level;
            int monsterLevel = race.Level + (monsterIndex & 0x08) + 25;
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
            int playerHealth = Player.Health;
            int playerMaxHealth = Player.MaxHealth;
            int monsterHealth = monster.Health;
            int monsterMaxHealth = monster.MaxHealth;
            int playerHealthFactor = (playerLevel * playerMaxHealth) + (playerHealth << 2);
            int monsterHealthFactor = (monsterLevel * monsterMaxHealth) + (monsterHealth << 2);
            return playerHealthFactor * monsterMaxHealth > monsterHealthFactor * playerMaxHealth;
        }

        /// <summary>
        /// Have an individual monster take its turn
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <param name="noise"> The amount of noise the player is making </param>
        private void ProcessMonster(int monsterIndex, uint noise)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // Is the monster asleep?
            if (monster.SleepLevel != 0)
            {
                // if the player aggravates, notice them more
                uint notice = 0;
                if (!Player.HasAggravation)
                {
                    notice = (uint)Program.Rng.RandomLessThan(1024);
                }
                // If the player makes too much noise (or aggravates)
                if (notice * notice * notice <= noise)
                {
                    int wakeAmount = 1;
                    if (monster.DistanceFromPlayer < 50)
                    {
                        wakeAmount = 100 / monster.DistanceFromPlayer;
                    }
                    // Aggravate wakes the monster fully, if it notices at all
                    if (Player.HasAggravation)
                    {
                        wakeAmount = monster.SleepLevel;
                    }
                    // If we're not awake yet, just sleep less deeply
                    if (monster.SleepLevel > wakeAmount)
                    {
                        monster.SleepLevel -= wakeAmount;
                        // The player may notice
                        if (monster.IsVisible && race.Knowledge.RIgnore < Constants.MaxUchar)
                        {
                            race.Knowledge.RIgnore++;
                        }
                    }
                    else
                    {
                        // Wake us up
                        monster.SleepLevel = 0;
                        // If the player sees us wake up, let them know
                        if (monster.IsVisible)
                        {
                            string monsterName = monster.MonsterDesc(0);
                            MsgPrint($"{monsterName} wakes up.");
                            // And let the player notice how easily we wake
                            if (race.Knowledge.RWake < Constants.MaxUchar)
                            {
                                race.Knowledge.RWake++;
                            }
                        }
                    }
                }
                // If we're still asleep after all that, do nothing else for our turn
                if (monster.SleepLevel != 0)
                {
                    return;
                }
            }
            // If we're stunned, then reduce our stun level
            if (monster.StunLevel != 0)
            {
                int stunRelief = 1;
                // We have a level-based chance of shaking off the stun completely
                if (Program.Rng.RandomLessThan(5000) <= race.Level * race.Level)
                {
                    stunRelief = monster.StunLevel;
                }
                // Reduce our stun if the relief is not enough to get rid of it
                if (monster.StunLevel > stunRelief)
                {
                    monster.StunLevel -= stunRelief;
                }
                else
                {
                    // Get rid of all of our stun
                    monster.StunLevel = 0;
                    // If the player sees us, let them know we're no longer stunned
                    if (monster.IsVisible)
                    {
                        string monsterName = monster.MonsterDesc(0);
                        MsgPrint($"{monsterName} is no longer stunned.");
                    }
                }
                // If we are still stunned, don't take a turn
                if (monster.StunLevel != 0)
                {
                    return;
                }
            }
            // If we're confused
            if (monster.ConfusionLevel != 0)
            {
                // Reduce our confusion by an amount based on our level
                int confusionRelief = Program.Rng.DieRoll((race.Level / 10) + 1);
                if (monster.ConfusionLevel > confusionRelief)
                {
                    monster.ConfusionLevel -= confusionRelief;
                }
                else
                {
                    // If we're no longer confused, the player will see this
                    monster.ConfusionLevel = 0;
                    if (monster.IsVisible)
                    {
                        string monsterName = monster.MonsterDesc(0);
                        MsgPrint($"{monsterName} is no longer confused.");
                    }
                }
            }
            // If we're curently friendly and the player aggravates, then stop being friendly
            bool getsAngry = false;
            if ((monster.Mind & Constants.SmFriendly) != 0 && Player.HasAggravation)
            {
                getsAngry = true;
            }
            // If we're unique, don't stay friendly
            if ((monster.Mind & Constants.SmFriendly) != 0 && !Player.IsWizard && (race.Flags1 & MonsterFlag1.Unique) != 0)
            {
                getsAngry = true;
            }
            // If we got angry, let the player see that
            if (getsAngry)
            {
                string monsterName = monster.MonsterDesc(0);
                MsgPrint($"{monsterName} suddenly becomes hostile!");
                monster.Mind &= ~Constants.SmFriendly;
            }
            // Are we afraid?
            if (monster.FearLevel != 0)
            {
                // Reduce our fear by an amount based on our level
                int fearRelief = Program.Rng.DieRoll((race.Level / 10) + 1);
                if (monster.FearLevel > fearRelief)
                {
                    monster.FearLevel -= fearRelief;
                }
                else
                {
                    monster.FearLevel = 0;
                    // If the player can see us, they can see we're no longer afraid
                    if (monster.IsVisible)
                    {
                        string monsterName = monster.MonsterDesc(0);
                        string monsterPossessive = monster.MonsterDesc(0x22);
                        MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                    }
                }
            }
            int oldY = monster.MapY;
            int oldX = monster.MapX;
            // If it's suitable for us to reproduce
            if ((race.Flags2 & MonsterFlag2.Multiply) != 0 && Level.Monsters.NumRepro < Constants.MaxRepro &&
                monster.Generation < 10)
            {
                // Find how many spaces we've got near us
                int k;
                int y;
                for (k = 0, y = oldY - 1; y <= oldY + 1; y++)
                {
                    for (int x = oldX - 1; x <= oldX + 1; x++)
                    {
                        if (Level.Grid[y][x].MonsterIndex != 0)
                        {
                            k++;
                        }
                    }
                }
                // If we're friendly, then our babies are friendly too
                bool isFriend = (monster.Mind & Constants.SmFriendly) != 0;
                // If there's lots of space, then pop out a baby
                if (k < 4 && (k == 0 || Program.Rng.RandomLessThan(k * Constants.MonMultAdj) == 0))
                {
                    if (Level.Monsters.MultiplyMonster(monsterIndex, isFriend, false))
                    {
                        // If the player saw this, they now know we can multiply
                        if (monster.IsVisible)
                        {
                            race.Knowledge.RFlags2 |= MonsterFlag2.Multiply;
                        }
                        // Having a baby takes our entire turn
                        return;
                    }
                }
            }
            // If we can usefully cast a spell against the player, then that's our turn
            if (TryCastingASpellAgainstPlayer(monsterIndex))
            {
                return;
            }
            // If we can usefully cast a spell against another monster, then that's our turn
            if (TryCastingASpellAgainstAnotherMonster(monsterIndex))
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
            if (monster.ConfusionLevel != 0)
            {
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we move randomly most of the time, have a high chance of putting four random moves
            // in the matrix
            else if ((race.Flags1 & MonsterFlag1.RandomMove50) != 0 && (race.Flags1 & MonsterFlag1.RandomMove25) != 0 &&
                     Program.Rng.RandomLessThan(100) < 75)
            {
                // If the player sees us, then they learn about our random movement
                if (monster.IsVisible)
                {
                    race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove50;
                    race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove25;
                }
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we have a moderate chance of moving randomly, maybe put four random moves in our matrix
            else if ((race.Flags1 & MonsterFlag1.RandomMove50) != 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                // If the player sees us, then they learn about our random movement
                if (monster.IsVisible)
                {
                    race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove50;
                }
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we have a low chance of moving randomly, maybe put four random moves in our matrix
            else if ((race.Flags1 & MonsterFlag1.RandomMove25) != 0 && Program.Rng.RandomLessThan(100) < 25)
            {
                // If the player sees us, then they learn about our random movement
                if (monster.IsVisible)
                {
                    race.Knowledge.RFlags1 |= MonsterFlag1.RandomMove25;
                }
                potentialMoves[0] = 5;
                potentialMoves[1] = 5;
                potentialMoves[2] = 5;
                potentialMoves[3] = 5;
            }
            // If we're the player's friend and we're too far away, add sensible moves to our matrix
            else if ((monster.Mind & Constants.SmFriendly) != 0)
            {
                if (monster.DistanceFromPlayer > Constants.FollowDistance)
                {
                    GetMovesTowardsPlayer(monsterIndex, potentialMoves);
                }
                else
                {
                    // If we're close to the player (and friendly) just use random moves
                    potentialMoves[0] = 5;
                    potentialMoves[1] = 5;
                    potentialMoves[2] = 5;
                    potentialMoves[3] = 5;
                    // Possibly override these random moves with attacks on enemies
                    GetMovesTowardsEnemyMonsters(monster, potentialMoves);
                }
            }
            // If all the above fail, we must be a hostile monster who wants to move towards the player
            else
            {
                // If we fail to get sensible moves, give up on our turn
                if (!GetMovesTowardsPlayer(monsterIndex, potentialMoves))
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
                    d = Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
                }
                // Work out where the move will take us
                int newY = oldY + Level.KeypadDirectionYOffset[d];
                int newX = oldX + Level.KeypadDirectionXOffset[d];
                GridTile tile = Level.Grid[newY][newX];
                Monster monsterInTargetTile = Level.Monsters[tile.MonsterIndex];
                // If we can simply move there, then we will do so
                if (Level.GridPassable(newY, newX))
                {
                    doMove = true;
                }
                // Bushes don't actually block us, so we can move there too
                else if (Level.Grid[newY][newX].FeatureType.Name == "Bush")
                {
                    doMove = true;
                }
                // We can always attack the player, even if the move would otherwse not be allowed
                else if (newY == Player.MapY && newX == Player.MapX)
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
                else if ((race.Flags2 & MonsterFlag2.PassWall) != 0)
                {
                    doMove = true;
                    didPassWall = true;
                }
                // If we can tunnel through walls then they don't block us
                else if ((race.Flags2 & MonsterFlag2.KillWall) != 0)
                {
                    doMove = true;
                    didKillWall = true;
                    // Occasionally make a noise if we're going to tunnel
                    if (Program.Rng.DieRoll(20) == 1)
                    {
                        MsgPrint("There is a grinding sound.");
                    }
                    // Remove the wall (and the player's memory of it) and remind ourselves to
                    // update the view if the player can see it
                    tile.TileFlags.Clear(GridTile.PlayerMemorised);
                    Level.RevertTileToBackground(newY, newX);
                    if (Level.PlayerHasLosBold(newY, newX))
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
                    if ((race.Flags2 & MonsterFlag2.OpenDoor) != 0)
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
                            if (Program.Rng.RandomLessThan(monster.Health / 10) > k)
                            {
                                Level.CaveSetFeat(newY, newX, "LockedDoor0");
                                mayBash = false;
                            }
                        }
                    }
                    // If we can't open doors (or failed to unlock the door), then we can bash it down
                    if (mayBash && (race.Flags2 & MonsterFlag2.BashDoor) != 0)
                    {
                        int k = int.Parse(tile.FeatureType.Name.Substring(10));
                        // If we succeeded, let the player hear it
                        if (Program.Rng.RandomLessThan(monster.Health / 10) > k)
                        {
                            MsgPrint("You hear a door burst open!");
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
                            Level.CaveSetFeat(newY, newX, "BrokenDoor");
                        }
                        else
                        {
                            Level.CaveSetFeat(newY, newX, "OpenDoor");
                        }
                        // If the player can see, remind ourselves to update the view later
                        if (Level.PlayerHasLosBold(newY, newX))
                        {
                            doView = true;
                        }
                    }
                }
                // If we're going to move onto an Elder Sign and we're capable of doing attacks
                if (doMove && tile.FeatureType.Name == "ElderSign" && (race.Flags1 & MonsterFlag1.NeverAttack) == 0)
                {
                    // Assume we're not moving
                    doMove = false;
                    // We have a chance of breaking the sign based on our level
                    if (Program.Rng.DieRoll(Constants.BreakElderSign) < race.Level)
                    {
                        // If the player knows the sign is there, let them know it was broken
                        if (tile.TileFlags.IsSet(GridTile.PlayerMemorised))
                        {
                            MsgPrint("The Elder Sign is broken!");
                        }
                        tile.TileFlags.Clear(GridTile.PlayerMemorised);
                        Level.RevertTileToBackground(newY, newX);
                        // Breaking the sign means we can move after all
                        doMove = true;
                    }
                }
                // If we're going to move onto a Yellow Sign and we can attack
                else if (doMove && tile.FeatureType.Name == "YellowSign" &&
                         (race.Flags1 & MonsterFlag1.NeverAttack) == 0)
                {
                    // Assume we're not moving
                    doMove = false;
                    // We have a chance to break the sign
                    if (Program.Rng.DieRoll(Constants.BreakYellowSign) < race.Level)
                    {
                        // If the player knows about the sign, let them know it was broken
                        if (tile.TileFlags.IsSet(GridTile.PlayerMemorised))
                        {
                            // If the player was on the sign, hurt them
                            if (newY == Player.MapY && newX == Player.MapX)
                            {
                                MsgPrint("The rune explodes!");
                                FireBall(new ProjectMana(this), 0,
                                    2 * ((Player.Level / 2) + Program.Rng.DiceRoll(7, 7)), 2);
                            }
                            else
                            {
                                MsgPrint("An Yellow Sign was disarmed.");
                            }
                        }
                        tile.TileFlags.Clear(GridTile.PlayerMemorised);
                        Level.RevertTileToBackground(newY, newX);
                        // We can do the move after all
                        doMove = true;
                    }
                }
                // If we're going to attack the player, but our race never attacks, then cancel the move
                if (doMove && newY == Player.MapY && newX == Player.MapX && (race.Flags1 & MonsterFlag1.NeverAttack) != 0)
                {
                    doMove = false;
                }
                // If we're trying to move onto the player, then attack them instead
                if (doMove && newY == Player.MapY && newX == Player.MapX)
                {
                    MonsterAttackPlayer(monsterIndex);
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
                    if ((race.Flags2 & MonsterFlag2.KillBody) != 0 && race.Mexp > targetMonsterRace.Mexp &&
                        Level.GridPassable(newY, newX) &&
                        !((monster.Mind & Constants.SmFriendly) != 0 && (monsterInTargetTile.Mind & Constants.SmFriendly) != 0))
                    {
                        // Remove the other monster and replace it
                        doMove = true;
                        didKillBody = true;
                        Level.DeleteMonster(newY, newX);
                        monsterInTargetTile = Level.Monsters[tile.MonsterIndex];
                    }
                    // If we're not on the same team as the other monster or we're confused
                    else if ((monster.Mind & Constants.SmFriendly) != (monsterInTargetTile.Mind & Constants.SmFriendly) || monster.ConfusionLevel != 0)
                    {
                        doMove = false;
                        // Attack the monster in the target tile
                        if (monsterInTargetTile.Race != null && monsterInTargetTile.Health >= 0)
                        {
                            if (AttackAnotherMonster(monsterIndex, tile.MonsterIndex))
                            {
                                return;
                            }
                        }
                    }
                    // If the other monster is on our team and we can't trample it, maybe we can
                    // push past
                    else if ((race.Flags2 & MonsterFlag2.MoveBody) != 0 && race.Mexp > targetMonsterRace.Mexp &&
                             Level.GridPassable(newY, newX) && Level.GridPassable(monster.MapY, monster.MapX))
                    {
                        doMove = true;
                        didMoveBody = true;
                    }
                }
                // If we're going to do a move but we can't move, cancel it
                if (doMove && (race.Flags1 & MonsterFlag1.NeverMove) != 0)
                {
                    doMove = false;
                }
                // If we're going to do a move
                if (doMove)
                {
                    int nextItemIndex;
                    doTurn = true;
                    // Swap positions with the monster that is in the tile we're aiming for
                    Level.Grid[oldY][oldX].MonsterIndex = tile.MonsterIndex;
                    // If it was actually a monster then update it accordingly
                    if (tile.MonsterIndex != 0)
                    {
                        monsterInTargetTile.MapY = oldY;
                        monsterInTargetTile.MapX = oldX;
                        Level.Monsters.UpdateMonsterVisibility(tile.MonsterIndex, true);
                        // Pushing past something wakes it up
                        Level.Monsters[tile.MonsterIndex].SleepLevel = 0;
                    }
                    // Update our position
                    tile.MonsterIndex = monsterIndex;
                    monster.MapY = newY;
                    monster.MapX = newX;
                    Level.Monsters.UpdateMonsterVisibility(monsterIndex, true);
                    Level.RedrawSingleLocation(oldY, oldX);
                    Level.RedrawSingleLocation(newY, newX);
                    // If we are hostile and the player saw us move, then disturb them
                    if (monster.IsVisible && (monster.IndividualMonsterFlags & Constants.MflagView) != 0)
                    {
                        if ((monster.Mind & Constants.SmFriendly) == 0)
                        {
                            Disturb(false);
                        }
                    }
                    // Check through the items in the tile we just entered
                    for (int thisItemIndex = tile.ItemIndex; thisItemIndex != 0; thisItemIndex = nextItemIndex)
                    {
                        Item item = Level.Items[thisItemIndex];
                        nextItemIndex = item.NextInStack;
                        // We ignore gold
                        if (item.Category == ItemCategory.Gold)
                        {
                            continue;
                        }
                        // If we pick up or stomp on items, check the item type
                        if (((race.Flags2 & MonsterFlag2.TakeItem) != 0 ||
                             (race.Flags2 & MonsterFlag2.KillItem) != 0) && (monster.Mind & Constants.SmFriendly) == 0)
                        {
                            FlagSet f1 = new FlagSet();
                            FlagSet f2 = new FlagSet();
                            FlagSet f3 = new FlagSet();
                            uint flg3 = 0;
                            item.GetMergedFlags(f1, f2, f3);
                            string itemName = item.Description(true, 3);
                            string monsterName = monster.MonsterDesc(0x04);
                            if (f1.IsSet(ItemFlag1.KillDragon))
                            {
                                flg3 |= MonsterFlag3.Dragon;
                            }
                            if (f1.IsSet(ItemFlag1.SlayDragon))
                            {
                                flg3 |= MonsterFlag3.Dragon;
                            }
                            if (f1.IsSet(ItemFlag1.SlayTroll))
                            {
                                flg3 |= MonsterFlag3.Troll;
                            }
                            if (f1.IsSet(ItemFlag1.SlayGiant))
                            {
                                flg3 |= MonsterFlag3.Giant;
                            }
                            if (f1.IsSet(ItemFlag1.SlayOrc))
                            {
                                flg3 |= MonsterFlag3.Orc;
                            }
                            if (f1.IsSet(ItemFlag1.SlayDemon))
                            {
                                flg3 |= MonsterFlag3.Demon;
                            }
                            if (f1.IsSet(ItemFlag1.SlayUndead))
                            {
                                flg3 |= MonsterFlag3.Undead;
                            }
                            if (f1.IsSet(ItemFlag1.SlayAnimal))
                            {
                                flg3 |= MonsterFlag3.Animal;
                            }
                            if (f1.IsSet(ItemFlag1.SlayEvil))
                            {
                                flg3 |= MonsterFlag3.Evil;
                            }
                            // Monsters won't pick up artifacts or items that hurt them
                            if (item.IsFixedArtifact() || (race.Flags3 & flg3) != 0 ||
                                !string.IsNullOrEmpty(item.RandartName))
                            {
                                if ((race.Flags2 & MonsterFlag2.TakeItem) != 0)
                                {
                                    didTakeItem = true;
                                    if (monster.IsVisible && Level.PlayerHasLosBold(newY, newX))
                                    {
                                        MsgPrint($"{monsterName} tries to pick up {itemName}, but fails.");
                                    }
                                }
                            }
                            // If we picked up the item and the player saw, let them know
                            else if ((race.Flags2 & MonsterFlag2.TakeItem) != 0)
                            {
                                didTakeItem = true;
                                if (Level.PlayerHasLosBold(newY, newX))
                                {
                                    MsgPrint($"{monsterName} picks up {itemName}.");
                                }
                                // And pick up the actual item
                                Level.ExciseObjectIdx(thisItemIndex);
                                item.Marked = false;
                                item.Y = 0;
                                item.X = 0;
                                item.HoldingMonsterIndex = monsterIndex;
                                item.NextInStack = monster.FirstHeldItemIndex;
                                monster.FirstHeldItemIndex = thisItemIndex;
                            }
                            else
                            {
                                // We can't pick up the item, so just stomp on it
                                didKillItem = true;
                                // If the player saw us, let them know
                                if (Level.PlayerHasLosBold(newY, newX))
                                {
                                    MsgPrint($"{monsterName} crushes {itemName}.");
                                }
                                Level.DeleteObjectIdx(thisItemIndex);
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
            if (!doTurn && !doMove && monster.FearLevel == 0 && (monster.Mind & Constants.SmFriendly) == 0)
            {
                if (TryCastingASpellAgainstPlayer(monsterIndex))
                {
                    return;
                }
            }
            // Update the view if necessary
            if (doView)
            {
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent | UpdateFlags.UpdateMonsters);
            }
            // If we did something unusual and the player saw, let them remember we can do that
            if (monster.IsVisible)
            {
                if (didOpenDoor)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.OpenDoor;
                }
                if (didBashDoor)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.BashDoor;
                }
                if (didTakeItem)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.TakeItem;
                }
                if (didKillItem)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.KillItem;
                }
                if (didMoveBody)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.MoveBody;
                }
                if (didKillBody)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.KillBody;
                }
                if (didPassWall)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.PassWall;
                }
                if (didKillWall)
                {
                    race.Knowledge.RFlags2 |= MonsterFlag2.KillWall;
                }
            }
            // If we couldn't do anything because we were afraid and cornered, lose our fear
            if (!doTurn && !doMove && monster.FearLevel != 0)
            {
                monster.FearLevel = 0;
                if (monster.IsVisible)
                {
                    string monsterName = monster.MonsterDesc(0);
                    MsgPrint($"{monsterName} turns to fight!");
                }
            }
        }

        /// <summary>
        /// Roll a percentage change of a monster realising it shouldn't do something because the
        /// player resisted it last time. Monsters that are not smart have half the passed chance.
        /// </summary>
        /// <param name="race"> The monster's race </param>
        /// <param name="percentage"> The chance of it happening </param>
        /// <returns> True if it should happen, or false if it should not </returns>
        private bool RealiseSpellIsUseless(MonsterRace race, int percentage)
        {
            if ((race.Flags2 & MonsterFlag2.Smart) == 0)
            {
                percentage /= 2;
            }
            return Program.Rng.RandomLessThan(100) < percentage;
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
        private void RemoveIneffectiveSpells(int monsterIndex, out uint modifiedFlags4, uint initialFlags4,
            out uint modifiedFlags5, uint initialFlags5, out uint modifiedFlags6, uint initialFlags6)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            uint flags4 = initialFlags4;
            uint flags5 = initialFlags5;
            uint flags6 = initialFlags6;
            modifiedFlags4 = initialFlags4;
            modifiedFlags5 = initialFlags5;
            modifiedFlags6 = initialFlags6;
            // If we're stupid, we won't realise how ineffective things are
            if ((race.Flags2 & MonsterFlag2.Stupid) != 0)
            {
                return;
            }
            // Tiny chance of forgetting what we've seen, clearing all smart flags except for ally
            // and clone
            if (monster.Mind != 0 && Program.Rng.RandomLessThan(100) < 1)
            {
                monster.Mind &= (Constants.SmFriendly | Constants.SmCloned);
            }
            uint mindFlags = monster.Mind;
            // If we're not aware of any of the player's resistances, don't bother going through them
            if (mindFlags == 0)
            {
                return;
            }
            // If we know the player is immune to acid, don't do acid spells
            if ((mindFlags & Constants.SmImmAcid) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.BreatheAcid;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.AcidBall;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
            }
            // If we know the player resists acid both temporarily and permanently, probably don't
            // do acid spells
            else if ((mindFlags & Constants.SmOppAcid) != 0 && (mindFlags & Constants.SmResAcid) != 0)
            {
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags4 &= ~MonsterFlag4.BreatheAcid;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.AcidBall;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
            }
            // If we know the player resists acid at all, maybe don't do acid spells
            else if ((mindFlags & Constants.SmOppAcid) != 0 || (mindFlags & Constants.SmResAcid) != 0)
            {
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags4 &= ~MonsterFlag4.BreatheAcid;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.AcidBall;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
            }
            // If we know the player is immune to lightning, don't do lightning spells
            if ((mindFlags & Constants.SmImmElec) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.BreatheLightning;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.LightningBall;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
            }
            // If we know the player resists lightning both temporarily and permanently, probably
            // don't do lightning spells
            else if ((mindFlags & Constants.SmOppElec) != 0 && (mindFlags & Constants.SmResElec) != 0)
            {
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags4 &= ~MonsterFlag4.BreatheLightning;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.LightningBall;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
            }
            // If we know the player resists lightning at all, maybe don't do lightning spells
            else if ((mindFlags & Constants.SmOppElec) != 0 || (mindFlags & Constants.SmResElec) != 0)
            {
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags4 &= ~MonsterFlag4.BreatheLightning;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.LightningBall;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
            }
            // If we know the player is immune to fire, don't do fire spells
            if ((mindFlags & Constants.SmImmFire) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.BreatheFire;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.FireBall;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
            }
            // If we know the player resists fire both temporarily and permanently, probably don't
            // do fire spells
            else if ((mindFlags & Constants.SmOppFire) != 0 && (mindFlags & Constants.SmResFire) != 0)
            {
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags4 &= ~MonsterFlag4.BreatheFire;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.FireBall;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
            }
            // If we know the player resists fire at all, maybe don't do fire spells
            else if ((mindFlags & Constants.SmOppFire) != 0 || (mindFlags & Constants.SmResFire) != 0)
            {
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags4 &= ~MonsterFlag4.BreatheFire;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.FireBall;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
            }
            // If we know the player is immune to cold, don't do fire spells
            if ((mindFlags & Constants.SmImmCold) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.BreatheCold;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.ColdBall;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
            }
            // If we know the player resists cold both temporarily and permanently, probably don't
            // do cold spells
            else if ((mindFlags & Constants.SmOppCold) != 0 && (mindFlags & Constants.SmResCold) != 0)
            {
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags4 &= ~MonsterFlag4.BreatheCold;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.ColdBall;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
            }
            // If we know the player resists cold at all, maybe don't do cold spells
            else if ((mindFlags & Constants.SmOppCold) != 0 || (mindFlags & Constants.SmResCold) != 0)
            {
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags4 &= ~MonsterFlag4.BreatheCold;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.ColdBall;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
            }
            // If we know the player resists poison both temporarily and permanently, probably don't
            // do poison spells
            if ((mindFlags & Constants.SmOppPois) != 0 && (mindFlags & Constants.SmResPois) != 0)
            {
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags4 &= ~MonsterFlag4.BreathePoison;
                }
                if (RealiseSpellIsUseless(race, 80))
                {
                    flags5 &= ~MonsterFlag5.PoisonBall;
                }
                if (RealiseSpellIsUseless(race, 40))
                {
                    flags4 &= ~MonsterFlag4.RadiationBall;
                }
                if (RealiseSpellIsUseless(race, 40))
                {
                    flags4 &= ~MonsterFlag4.BreatheRadiation;
                }
            }
            // If we know the player resists poison at all, maybe don't do cold spells
            else if ((mindFlags & Constants.SmOppPois) != 0 || (mindFlags & Constants.SmResPois) != 0)
            {
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags4 &= ~MonsterFlag4.BreathePoison;
                }
                if (RealiseSpellIsUseless(race, 30))
                {
                    flags5 &= ~MonsterFlag5.PoisonBall;
                }
            }
            // If we know the player resists nether, maybe don't do nether spells
            if ((mindFlags & Constants.SmResNeth) != 0)
            {
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheNether;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags5 &= ~MonsterFlag5.NetherBall;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags5 &= ~MonsterFlag5.NetherBolt;
                }
            }
            // If we know the player resists light, maybe don't do light spells
            if ((mindFlags & Constants.SmResLight) != 0)
            {
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheLight;
                }
            }
            // If we know the player resists darkness, maybe don't do darkness spells
            if ((mindFlags & Constants.SmResDark) != 0)
            {
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheDark;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags5 &= ~MonsterFlag5.DarkBall;
                }
            }
            // If we know the player resists fear, don't do fear spells
            if ((mindFlags & Constants.SmResFear) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.Scare;
                }
            }
            // If we know the player resists confiusion, maybe don't do confusion spells
            if ((mindFlags & Constants.SmResConf) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.Confuse;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheConfusion;
                }
            }
            // If we know the player resists chaos, maybe don't do chaos or confusion spells
            if ((mindFlags & Constants.SmResChaos) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.Confuse;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheConfusion;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheChaos;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.ChaosBall;
                }
            }
            // If we know the player resists disenchantment, don't do disenchantment spells
            if ((mindFlags & Constants.SmResDisen) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.BreatheDisenchant;
                }
            }
            // If we know the player resists blindness, don't do blindness spells
            if ((mindFlags & Constants.SmResBlind) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.Blindness;
                }
            }
            // If we know the player resists nexus, maybe don't do nexus or teleport spells
            if ((mindFlags & Constants.SmResNexus) != 0)
            {
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheNexus;
                }
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags6 &= ~MonsterFlag6.TeleportLevel;
                }
            }
            // If we know the player resists sound, maybe don't do sound spells
            if ((mindFlags & Constants.SmResSound) != 0)
            {
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheSound;
                }
            }
            // If we know the player resists shards, maybe don't do shard spells
            if ((mindFlags & Constants.SmResShard) != 0)
            {
                if (RealiseSpellIsUseless(race, 50))
                {
                    flags4 &= ~MonsterFlag4.BreatheShards;
                }
                if (RealiseSpellIsUseless(race, 20))
                {
                    flags4 &= ~MonsterFlag4.ShardBall;
                }
            }
            // If we know the player reflects bolts, don't do bolt spells
            if ((mindFlags & Constants.SmImmReflect) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.ColdBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.FireBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.AcidBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.LightningBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.PoisonBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.NetherBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.WaterBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.ManaBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.PlasmaBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.IceBolt;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.MagicMissile;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.Arrow1D6;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.Arrow3D6;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.Arrow5D6;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags4 &= ~MonsterFlag4.Arrow7D6;
                }
            }
            // If we know the player has free action, don't do slow or hold spells
            if ((mindFlags & Constants.SmImmFree) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.Hold;
                }
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.Slow;
                }
            }
            // If we know the player has no mana, don't do mana drain
            if ((mindFlags & Constants.SmImmMana) != 0)
            {
                if (RealiseSpellIsUseless(race, 100))
                {
                    flags5 &= ~MonsterFlag5.DrainMana;
                }
            }
            modifiedFlags4 = flags4;
            modifiedFlags5 = flags5;
            modifiedFlags6 = flags6;
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
        /// Check whether there's room to summon something next to a location
        /// </summary>
        /// <param name="targetY"> The target Y coordinate </param>
        /// <param name="targetX"> The target X coordinate </param>
        /// <returns> True if there is room, or false if there is not </returns>
        private bool SummonPossible(int targetY, int targetX)
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

        /// <summary>
        /// Take damage after being hit by another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster taking the damage </param>
        /// <param name="damage"> The damage taken </param>
        /// <param name="fear"> Whether the damage makes us afraid </param>
        /// <param name="note"> A special descriptive note that replaces the normal death message </param>
        private void TakeDamageFromAnotherMonster(int monsterIndex, int damage, out bool fear, string note)
        {
            fear = false;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // Track the monster that has just taken damage
            if (TrackedMonsterIndex == monsterIndex)
            {
                Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
            }
            monster.SleepLevel = 0;
            // Take the damage
            monster.Health -= damage;
            // Did it kill us?
            if (monster.Health < 0)
            {
                // Uniques and guardians can never be killed by other monsters
                if ((race.Flags1 & MonsterFlag1.Unique) != 0 || (race.Flags1 & MonsterFlag1.Guardian) != 0)
                {
                    monster.Health = 1;
                }
                else
                {
                    // Construct a message telling the player what happened
                    string monsterName = monster.MonsterDesc(0);
                    Gui.PlaySound(SoundEffect.MonsterDies);
                    // Append the note if there is one
                    if (!string.IsNullOrEmpty(note))
                    {
                        MsgPrint(monsterName + note);
                    }
                    // Don't tell the player if the monster is not visible
                    else if (!monster.IsVisible)
                    {
                    }
                    // Some non-living things are destroyed rather than dying
                    else if ((race.Flags3 & MonsterFlag3.Demon) != 0 || (race.Flags3 & MonsterFlag3.Undead) != 0 ||
                             (race.Flags3 & MonsterFlag3.Cthuloid) != 0 || (race.Flags2 & MonsterFlag2.Stupid) != 0 ||
                             (race.Flags3 & MonsterFlag3.Nonliving) != 0 || "Evg".Contains(race.Character.ToString()))
                    {
                        MsgPrint($"{monsterName} is destroyed.");
                    }
                    else
                    {
                        MsgPrint($"{monsterName} is killed.");
                    }
                    // Let the save game know we've died
                    MonsterDeath(monsterIndex);
                    // Delete us from the monster list
                    Level.Monsters.DeleteMonsterByIndex(monsterIndex, true);
                    fear = false;
                    return;
                }
            }
            // Assuming we survived, check if the attack made us afraid
            if (monster.FearLevel != 0 && damage > 0)
            {
                // If we're already afraid, we might get desperate and overcome our fear
                int tmp = Program.Rng.DieRoll(damage);
                if (tmp < monster.FearLevel)
                {
                    monster.FearLevel -= tmp;
                }
                else
                {
                    monster.FearLevel = 0;
                    fear = false;
                }
            }
            // If we weren't already afraid, this attack might make us afraid
            if (monster.FearLevel == 0 && (race.Flags3 & MonsterFlag3.ImmuneFear) == 0)
            {
                int percentage = 100 * monster.Health / monster.MaxHealth;
                if ((percentage <= 10 && Program.Rng.RandomLessThan(10) < percentage) ||
                    (damage >= monster.Health && Program.Rng.RandomLessThan(100) < 80))
                {
                    fear = true;
                    monster.FearLevel = Program.Rng.DieRoll(10) +
                                   (damage >= monster.Health && percentage > 7 ? 20 : (11 - percentage) * 5);
                }
            }
        }

        /// <summary>
        /// Adjust the coordinates we're trying to move to if we can't get directly there for some reason
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster trying to move </param>
        /// <param name="target"> The target location we're moving to </param>
        private void TrackPlayerByScent(int monsterIndex, MapCoordinate target)
        {
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            // If we can move through walls then we don't need to adjust anything
            if ((race.Flags2 & MonsterFlag2.PassWall) != 0)
            {
                return;
            }
            if ((race.Flags2 & MonsterFlag2.KillWall) != 0)
            {
                return;
            }
            int y1 = monster.MapY;
            int x1 = monster.MapX;
            GridTile cPtr = Level.Grid[y1][x1];
            // If we have no scent of the player then don't change where we were going
            if (cPtr.ScentAge < Level.Grid[Player.MapY][Player.MapX].ScentAge)
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
            if (cPtr.ScentStrength > race.NoticeRange)
            {
                return;
            }
            // If we can actually see the player then don't change where we are going
            if (Level.PlayerHasLosBold(y1, x1))
            {
                return;
            }
            int when = 0;
            int cost = 999;
            // Check the eight directions we can move to see which has the most recent or strongest scent
            for (int i = 7; i >= 0; i--)
            {
                int y = y1 + Level.OrderedDirectionYOffset[i];
                int x = x1 + Level.OrderedDirectionXOffset[i];
                if (Level.Grid[y][x].ScentAge == 0)
                {
                    continue;
                }
                if (Level.Grid[y][x].ScentAge < when)
                {
                    continue;
                }
                if (Level.Grid[y][x].ScentStrength > cost)
                {
                    continue;
                }
                when = Level.Grid[y][x].ScentAge;
                cost = Level.Grid[y][x].ScentStrength;
                // Give us a target in the general direction of the strongest scent
                target.Y = Player.MapY + (16 * Level.OrderedDirectionYOffset[i]);
                target.X = Player.MapX + (16 * Level.OrderedDirectionXOffset[i]);
            }
        }

        /// <summary>
        /// Try to cast a spell on another monster
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster casting the spell </param>
        /// <returns> True if we cast a spell, false otherwise </returns>
        private bool TryCastingASpellAgainstAnotherMonster(int monsterIndex)
        {
            int count = 0;
            int[] spell = new int[96];
            int num = 0;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            bool wakeUp = false;
            bool blind = Player.TimedBlindness != 0;
            bool seen = !blind && monster.IsVisible;
            bool friendly = (monster.Mind & Constants.SmFriendly) != 0;
            // Can't cast a spell if we're confused
            if (monster.ConfusionLevel != 0)
            {
                return false;
            }
            // We have a chance to cast a spell based on our race
            int chance = (race.FreqInate + race.FreqSpell) / 2;
            if (chance == 0)
            {
                return false;
            }
            if (Program.Rng.RandomLessThan(100) >= chance)
            {
                return false;
            }
            // Look through the monster list to find a potential target
            for (int i = 1; i < Level.MMax; i++)
            {
                int targetIndex = i;
                Monster target = Level.Monsters[targetIndex];
                MonsterRace targetRace = target.Race;
                // Can't cast spells on ourself
                if (target == monster)
                {
                    continue;
                }
                // Can't cast spells on empty monster slots
                if (target.Race == null)
                {
                    continue;
                }
                // Don't cast spells on monsters from the same team
                if ((monster.Mind & Constants.SmFriendly) == (target.Mind & Constants.SmFriendly))
                {
                    continue;
                }
                // If the target is too far away from the player, don't cast a spell
                if (target.DistanceFromPlayer > Constants.MaxRange)
                {
                    continue;
                }
                // If we don't have line of sight to the target, don't cast a spell
                if (!Level.Projectable(monster.MapY, monster.MapX, target.MapY, target.MapX))
                {
                    continue;
                }
                int y = target.MapY;
                int x = target.MapX;
                int rlev = race.Level >= 1 ? race.Level : 1;
                uint f4 = race.Flags4;
                uint f5 = race.Flags5;
                uint f6 = race.Flags6;
                // If we're smart and badly injured, we may want to prioritise spells that disable
                // the target, summon help, or let us escape over spells that do direct damage
                if ((race.Flags2 & MonsterFlag2.Smart) != 0 && monster.Health < monster.MaxHealth / 10 &&
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
                if (((f4 & MonsterFlag4.SummonMask) != 0 || (f5 & MonsterFlag5.SummonMask) != 0 ||
                     (f6 & MonsterFlag6.SummonMask) != 0) && (race.Flags2 & MonsterFlag2.Stupid) == 0 &&
                    !SummonPossible(target.MapY, target.MapX))
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
                if (!Playing || Player.IsDead || NewLevelFlag)
                {
                    return false;
                }
                string monsterName = monster.MonsterDesc(0x00);
                string monsterPossessive = monster.MonsterDesc(0x22);
                string targetName = target.MonsterDesc(0x00);
                monster.MonsterDesc(0x88);
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
                        Disturb(true);
                        MsgPrint(!seeMonster ? "You hear a shriek." : $"{monsterName} shrieks at {targetName}.");
                        wakeUp = true;
                        break;

                    // MonsterFlag4.Xxx2
                    case 96 + 1:
                    // MonsterFlag4.Xxx3
                    case 96 + 2:
                        break;

                    // MonsterFlag4.ShardBall
                    case 96 + 3:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a shard ball at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectShard(this), monster.Health / 4 > 800 ? 800 : monster.Health / 4, 2);
                        break;

                    // MonsterFlag4.Arrow1D6
                    case 96 + 4:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear a strange noise."
                            : $"{monsterName} fires an arrow at {targetName}");
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectArrow(this), Program.Rng.DiceRoll(1, 6));
                        break;

                    // MonsterFlag4.Arrow3D6
                    case 96 + 5:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear a strange noise."
                            : $"{monsterName} fires an arrow at {targetName}");
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectArrow(this), Program.Rng.DiceRoll(3, 6));
                        break;

                    // MonsterFlag4.Arrow5D6
                    case 96 + 6:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear a strange noise."
                            : $"{monsterName} fires a missile at {targetName}");
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectArrow(this), Program.Rng.DiceRoll(5, 6));
                        break;

                    // MonsterFlag4.Arrow7D6
                    case 96 + 7:
                        if (!seeEither)
                        {
                            MsgPrint("You hear a strange noise.");
                        }
                        else
                        {
                            Disturb(true);
                        }
                        MsgPrint(blind
                            ? $"{monsterName} makes a strange noise."
                            : $"{monsterName} fires a missile at {targetName}");
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectArrow(this), Program.Rng.DiceRoll(7, 6));
                        break;

                    // MonsterFlag4.BreatheAcid
                    case 96 + 8:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes acid at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectAcid(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheLightning
                    case 96 + 9:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes lightning at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectElec(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheFire
                    case 96 + 10:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes fire at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectFire(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheCold
                    case 96 + 11:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes frost at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectCold(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreathePoison
                    case 96 + 12:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes gas at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectPois(this), monster.Health / 3 > 800 ? 800 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheNether
                    case 96 + 13:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes nether at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectNether(this), monster.Health / 6 > 550 ? 550 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheLight
                    case 96 + 14:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes light at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectLight(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheDark
                    case 96 + 15:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes darkness at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectDark(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheConfusion
                    case 96 + 16:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes confusion at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectConfusion(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6,
                            0);
                        break;

                    // MonsterFlag4.BreatheSound
                    case 96 + 17:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes sound at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectSound(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheChaos
                    case 96 + 18:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes chaos at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectChaos(this), monster.Health / 6 > 600 ? 600 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheDisenchant
                    case 96 + 19:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes disenchantment at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectDisenchant(this), monster.Health / 6 > 500 ? 500 : monster.Health / 6,
                            0);
                        break;

                    // MonsterFlag4.BreatheNexus
                    case 96 + 20:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes nexus at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectNexus(this), monster.Health / 3 > 250 ? 250 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheTime
                    case 96 + 21:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes time at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectTime(this), monster.Health / 3 > 150 ? 150 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.BreatheInertia
                    case 96 + 22:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes inertia at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectInertia(this), monster.Health / 6 > 200 ? 200 : monster.Health / 6,
                            0);
                        break;

                    // MonsterFlag4.BreatheGravity
                    case 96 + 23:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes gravity at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectGravity(this), monster.Health / 3 > 200 ? 200 : monster.Health / 3,
                            0);
                        break;

                    // MonsterFlag4.BreatheShards
                    case 96 + 24:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes shards at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectExplode(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreathePlasma
                    case 96 + 25:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes plasma at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectPlasma(this), monster.Health / 6 > 150 ? 150 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheForce
                    case 96 + 26:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes force at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectForce(this), monster.Health / 6 > 200 ? 200 : monster.Health / 6, 0);
                        break;

                    // MonsterFlag4.BreatheMana
                    case 96 + 27:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes magical energy at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectMana(this), monster.Health / 3 > 250 ? 250 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.RadiationBall
                    case 96 + 28:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a ball of radiation at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectNuke(this), rlev + Program.Rng.DiceRoll(10, 6), 2);
                        break;

                    // MonsterFlag4.BreatheRadiation
                    case 96 + 29:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes toxic waste at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectNuke(this), monster.Health / 3 > 800 ? 800 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag4.ChaosBall
                    case 96 + 30:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble frighteningly."
                            : $"{monsterName} invokes raw chaos upon {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectChaos(this), (rlev * 2) + Program.Rng.DiceRoll(10, 10),
                            4);
                        break;

                    // MonsterFlag4.BreatheDisintegration
                    case 96 + 31:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear breathing noise."
                            : $"{monsterName} breathes disintegration at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectDisintegrate(this),
                            monster.Health / 3 > 300 ? 300 : monster.Health / 3, 0);
                        break;

                    // MonsterFlag5.AcidBall
                    case 128 + 0:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts an acid ball at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectAcid(this), Program.Rng.DieRoll(rlev * 3) + 15, 2);
                        break;

                    // MonsterFlag5.LightningBall
                    case 128 + 1:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a lightning ball at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectElec(this), Program.Rng.DieRoll(rlev * 3 / 2) + 8, 2);
                        break;

                    // MonsterFlag5.FireBall
                    case 128 + 2:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a fire ball at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectFire(this), Program.Rng.DieRoll(rlev * 7 / 2) + 10, 2);
                        break;

                    // MonsterFlag5.ColdBall
                    case 128 + 3:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a frost ball at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectCold(this), Program.Rng.DieRoll(rlev * 3 / 2) + 10, 2);
                        break;

                    // MonsterFlag5.PoisonBall
                    case 128 + 4:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a stinking cloud at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectPois(this), Program.Rng.DiceRoll(12, 2), 2);
                        break;

                    // MonsterFlag5.NetherBall
                    case 128 + 5:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} casts a nether ball at {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectNether(this), 50 + Program.Rng.DiceRoll(10, 10) + rlev,
                            2);
                        break;

                    // MonsterFlag5.WaterBall
                    case 128 + 6:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble."
                            : $"{monsterName} gestures fluidly at {targetName}");
                        MsgPrint($"{targetName} is engulfed in a whirlpool.");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectWater(this), Program.Rng.DieRoll(rlev * 5 / 2) + 50, 4);
                        break;

                    // MonsterFlag5.ManaBall
                    case 128 + 7:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble powerfully."
                            : $"{monsterName} invokes a mana storm upon {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectMana(this), (rlev * 5) + Program.Rng.DiceRoll(10, 10), 4);
                        break;

                    // MonsterFlag5.DarkBall
                    case 128 + 8:
                        Disturb(true);
                        MsgPrint(!seeEither
                            ? "You hear someone mumble powerfully."
                            : $"{monsterName} invokes a darkness storm upon {targetName}");
                        BreatheAtMonster(monsterIndex, y, x, new ProjectDark(this), (rlev * 5) + Program.Rng.DiceRoll(10, 10), 4);
                        break;

                    // MonsterFlag5.DrainMana
                    case 128 + 9:
                        int r1 = (Program.Rng.DieRoll(rlev) / 2) + 1;
                        if (seeMonster)
                        {
                            MsgPrint($"{monsterName} draws psychic energy from {targetName}");
                        }
                        if (monster.Health < monster.MaxHealth)
                        {
                            if (!(targetRace.Flags4 != 0 || targetRace.Flags5 != 0 || targetRace.Flags6 != 0))
                            {
                                if (seeBoth)
                                {
                                    MsgPrint($"{targetName} is unaffected!");
                                }
                            }
                            else
                            {
                                monster.Health += 6 * r1;
                                if (monster.Health > monster.MaxHealth)
                                {
                                    monster.Health = monster.MaxHealth;
                                }
                                if (TrackedMonsterIndex == monsterIndex)
                                {
                                    Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                                }
                                if (seen)
                                {
                                    MsgPrint($"{monsterName} appears healthier.");
                                }
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.MindBlast
                    case 128 + 10:
                        Disturb(true);
                        if (seen)
                        {
                            MsgPrint($"{monsterName} gazes intently at {targetName}");
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
                                MsgPrint($"{targetName} is unaffected!");
                            }
                        }
                        else
                        {
                            MsgPrint($"{targetName} is blasted by psionic energy.");
                            target.ConfusionLevel += Program.Rng.RandomLessThan(4) + 4;
                            TakeDamageFromAnotherMonster(targetIndex, Program.Rng.DiceRoll(8, 8), out _, " collapses, a mindless husk.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.BrainSmash
                    case 128 + 11:
                        Disturb(true);
                        if (seen)
                        {
                            MsgPrint($"{monsterName} gazes intently at {targetName}");
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
                                MsgPrint($"{targetName} is unaffected!");
                            }
                        }
                        else
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is blasted by psionic energy.");
                            }
                            target.ConfusionLevel += Program.Rng.RandomLessThan(4) + 4;
                            target.Speed -= Program.Rng.RandomLessThan(4) + 4;
                            target.StunLevel += Program.Rng.RandomLessThan(4) + 4;
                            TakeDamageFromAnotherMonster(targetIndex, Program.Rng.DiceRoll(12, 15), out _, " collapses, a mindless husk.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseLightWounds
                    case 128 + 12:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} points at {targetName} and curses.");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            TakeDamageFromAnotherMonster(targetIndex, Program.Rng.DiceRoll(3, 8), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseSeriousWounds
                    case 128 + 13:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} points at {targetName} and curses horribly.");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            TakeDamageFromAnotherMonster(targetIndex, Program.Rng.DiceRoll(8, 8), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseCriticalWounds
                    case 128 + 14:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} points at {targetName}, incanting terribly!");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            TakeDamageFromAnotherMonster(targetIndex, Program.Rng.DiceRoll(10, 15), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.CauseMortalWounds
                    case 128 + 15:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} points at {targetName}, screaming the word 'DIE!'");
                        }
                        if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} resists!");
                            }
                        }
                        else
                        {
                            TakeDamageFromAnotherMonster(targetIndex, Program.Rng.DiceRoll(15, 15), out _, " is destroyed.");
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.AcidBolt
                    case 128 + 16:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a acid bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectAcid(this), Program.Rng.DiceRoll(7, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.LightningBolt
                    case 128 + 17:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a lightning bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectElec(this), Program.Rng.DiceRoll(4, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.FireBolt
                    case 128 + 18:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a fire bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectFire(this), Program.Rng.DiceRoll(9, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.ColdBolt
                    case 128 + 19:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a frost bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectCold(this), Program.Rng.DiceRoll(6, 8) + (rlev / 3));
                        break;

                    // MonsterFlag5.PoisonBolt
                    case 128 + 20:
                        break;

                    // MonsterFlag5.NetherBolt
                    case 128 + 21:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a nether bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectNether(this),
                            30 + Program.Rng.DiceRoll(5, 5) + (rlev * 3 / 2));
                        break;

                    // MonsterFlag5.WaterBolt
                    case 128 + 22:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a water bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectWater(this), Program.Rng.DiceRoll(10, 10) + rlev);
                        break;

                    // MonsterFlag5.ManaBolt
                    case 128 + 23:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a mana bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectMana(this), Program.Rng.DieRoll(rlev * 7 / 2) + 50);
                        break;

                    // MonsterFlag5.PlasmaBolt
                    case 128 + 24:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a plasma bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectPlasma(this), 10 + Program.Rng.DiceRoll(8, 7) + rlev);
                        break;

                    // MonsterFlag5.IceBolt
                    case 128 + 25:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts an ice bolt at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectIce(this), Program.Rng.DiceRoll(6, 6) + rlev);
                        break;

                    // MonsterFlag5.MagicMissile
                    case 128 + 26:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a magic missile at {targetName}");
                        }
                        FireBoltAtMonster(monsterIndex, y, x, new ProjectMissile(this), Program.Rng.DiceRoll(2, 6) + (rlev / 3));
                        break;

                    // MonsterFlag5.Scare
                    case 128 + 27:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles, and you hear scary noises.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} casts a fearful illusion at {targetName}");
                        }
                        if ((targetRace.Flags3 & MonsterFlag3.ImmuneFear) != 0)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} refuses to be frightened.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} refuses to be frightened.");
                            }
                        }
                        else
                        {
                            if (target.FearLevel == 0 && seeTarget)
                            {
                                MsgPrint($"{targetName} flees in terror!");
                            }
                            target.FearLevel += Program.Rng.RandomLessThan(4) + 4;
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Blindness
                    case 128 + 28:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            string it = targetName != "it" ? "s" : "'s";
                            MsgPrint($"{monsterName} casts a spell, burning {targetName}{it} eyes.");
                        }
                        if ((targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is blinded!");
                            }
                            target.ConfusionLevel += 12 + Program.Rng.RandomLessThan(4);
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Confuse
                    case 128 + 29:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles, and you hear puzzling noises.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} creates a mesmerising illusion in front of {targetName}");
                        }
                        if ((targetRace.Flags3 & MonsterFlag3.ImmuneConfusion) != 0)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} disbelieves the feeble spell.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} disbelieves the feeble spell.");
                            }
                        }
                        else
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} seems confused.");
                            }
                            target.ConfusionLevel += 12 + Program.Rng.RandomLessThan(4);
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Slow
                    case 128 + 30:
                        Disturb(true);
                        if (!blind && seeEither)
                        {
                            string it = targetName == "it" ? "s" : "'s";
                            MsgPrint($"{monsterName} drains power from {targetName}{it} muscles.");
                        }
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else
                        {
                            target.Speed -= 10;
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} starts moving slower.");
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag5.Hold
                    case 128 + 31:
                        Disturb(true);
                        if (!blind && seeMonster)
                        {
                            MsgPrint($"{monsterName} stares intently at {targetName}");
                        }
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0 || (targetRace.Flags3 & MonsterFlag3.ImmuneStun) != 0)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else if (targetRace.Level > Program.Rng.DieRoll(rlev - 10 < 1 ? 1 : rlev - 10) + 10)
                        {
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected.");
                            }
                        }
                        else
                        {
                            target.StunLevel += Program.Rng.DieRoll(4) + 4;
                            if (seeTarget)
                            {
                                MsgPrint($"{targetName} is paralyzed!");
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag6.Haste
                    case 160 + 0:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} concentrates on {monsterPossessive} body.");
                        }
                        if (monster.Speed < race.Speed + 10)
                        {
                            if (seeMonster)
                            {
                                MsgPrint($"{monsterName} starts moving faster.");
                            }
                            monster.Speed += 10;
                        }
                        else if (monster.Speed < race.Speed + 20)
                        {
                            if (seeMonster)
                            {
                                MsgPrint($"{monsterName} starts moving faster.");
                            }
                            monster.Speed += 2;
                        }
                        break;

                    // MonsterFlag6.DreadCurse
                    case 160 + 1:
                        Disturb(false);
                        MsgPrint(!seeMonster
                            ? "You hear someone invoke the Dread Curse of Azathoth!"
                            : $"{monsterName} invokes the Dread Curse of Azathoth on {targetName}");
                        if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0)
                        {
                            if (!blind && seeTarget)
                            {
                                MsgPrint($"{targetName} is unaffected!");
                            }
                        }
                        else
                        {
                            if (race.Level + Program.Rng.DieRoll(20) > targetRace.Level + 10 + Program.Rng.DieRoll(20))
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
                                    MsgPrint($"{targetName} resists!");
                                }
                            }
                        }
                        wakeUp = true;
                        break;

                    // MonsterFlag6.Heal
                    case 160 + 2:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} concentrates on {monsterPossessive} wounds.");
                        }
                        monster.Health += rlev * 6;
                        if (monster.Health >= monster.MaxHealth)
                        {
                            monster.Health = monster.MaxHealth;
                            MsgPrint(seen
                                ? $"{monsterName} looks completely healed!"
                                : $"{monsterName} sounds completely healed!");
                        }
                        else
                        {
                            MsgPrint(seen
                                ? $"{monsterName} looks healthier."
                                : $"{monsterName} sounds healthier.");
                        }
                        if (TrackedMonsterIndex == monsterIndex)
                        {
                            Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                        }
                        if (monster.FearLevel != 0)
                        {
                            monster.FearLevel = 0;
                            if (seeMonster)
                            {
                                MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                            }
                        }
                        break;

                    // MonsterFlag6.Xxx2
                    case 160 + 3:
                        break;

                    // MonsterFlag6.Blink
                    case 160 + 4:
                        Disturb(true);
                        if (seeMonster)
                        {
                            MsgPrint($"{monsterName} blinks away.");
                        }
                        TeleportAway(monsterIndex, 10);
                        break;

                    // MonsterFlag6.TeleportSelf
                    case 160 + 5:
                        Disturb(true);
                        if (seeMonster)
                        {
                            MsgPrint($"{monsterName} teleports away.");
                        }
                        TeleportAway(monsterIndex, (Constants.MaxSight * 2) + 5);
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
                        Disturb(true);
                        MsgPrint($"{monsterName} teleports {targetName} away.");
                        if ((targetRace.Flags3 & MonsterFlag3.ResistTeleport) != 0)
                        {
                            if ((targetRace.Flags1 & MonsterFlag1.Unique) != 0)
                            {
                                if (seeTarget)
                                {
                                    targetRace.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                                    MsgPrint($"{targetName} is unaffected!");
                                }
                                resistsTele = true;
                            }
                            else if (targetRace.Level > Program.Rng.DieRoll(100))
                            {
                                if (seeTarget)
                                {
                                    targetRace.Knowledge.RFlags3 |= MonsterFlag3.ResistTeleport;
                                    MsgPrint($"{targetName} resists!");
                                }
                                resistsTele = true;
                            }
                        }
                        if (!resistsTele)
                        {
                            TeleportAway(targetIndex, (Constants.MaxSight * 2) + 5);
                        }
                        break;

                    // MonsterFlag6.TeleportLevel
                    case 160 + 10:
                    // MonsterFlag6.Xxx5
                    case 160 + 11:
                        break;

                    // MonsterFlag6.Darkness
                    case 160 + 12:
                        Disturb(true);
                        MsgPrint(blind ? $"{monsterName} mumbles." : $"{monsterName} gestures in shadow.");
                        if (seen)
                        {
                            MsgPrint($"{targetName} is surrounded by darkness.");
                        }
                        Project(monsterIndex, 3, y, x, 0, new ProjectDarkWeak(this),
                            ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill);
                        UnlightRoom(y, x);
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
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            string kin = (race.Flags1 & MonsterFlag1.Unique) != 0 ? "minions" : "kin";
                            MsgPrint($"{monsterName} magically summons {monsterPossessive} {kin}.");
                        }
                        Level.Monsters.SummonKinType = race.Character;
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonKin, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonKin))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonReaver
                    case 160 + 17:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons Black Reavers!");
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear heavy steps nearby.");
                        }
                        if (friendly)
                        {
                            Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonReaver, true);
                        }
                        else
                        {
                            SummonReaver();
                        }
                        break;

                    // MonsterFlag6.SummonMonster
                    case 160 + 18:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons help!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, 0))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonMonsters
                    case 160 + 19:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons monsters!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, 0))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonAnt
                    case 160 + 20:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons ants.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonAnt, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonAnt))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonSpider
                    case 160 + 21:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons spiders.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonSpider, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonSpider))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHound
                    case 160 + 22:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons hounds.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonHound, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHound))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHydra
                    case 160 + 23:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons hydras.");
                        }
                        for (k = 0; k < 6; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonHydra, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHydra))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonCthuloid
                    case 160 + 24:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons a Cthuloid entity!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonCthuloid, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonCthuloid))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonDemon
                    case 160 + 25:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons a demon!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonDemon, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonDemon))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonUndead
                    case 160 + 26:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons an undead adversary!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonUndead, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonUndead))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonDragon
                    case 160 + 27:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons a dragon!");
                        }
                        for (k = 0; k < 1; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev, Constants.SummonDragon, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonDragon))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear something appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHiUndead
                    case 160 + 28:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons greater undead!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev,
                                    Constants.SummonHiUndeadNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHiUndead))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many creepy things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonHiDragon
                    case 160 + 29:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons ancient dragons!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev,
                                    Constants.SummonHiDragonNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHiDragon))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many powerful things appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonGreatOldOne
                    case 160 + 30:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons Great Old Ones!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonGoo))
                            {
                                count++;
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear immortal beings appear nearby.");
                        }
                        break;

                    // MonsterFlag6.SummonUnique
                    case 160 + 31:
                        Disturb(true);
                        if (blind || !seeMonster)
                        {
                            MsgPrint($"{monsterName} mumbles.");
                        }
                        else
                        {
                            MsgPrint($"{monsterName} magically summons special opponents!");
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (!friendly)
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonUnique))
                                {
                                    count++;
                                }
                            }
                        }
                        for (k = 0; k < 8; k++)
                        {
                            if (friendly)
                            {
                                if (Level.Monsters.SummonSpecificFriendly(y, x, rlev,
                                    Constants.SummonHiUndeadNoUniques, true))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (Level.Monsters.SummonSpecific(y, x, rlev, Constants.SummonHiUndead))
                                {
                                    count++;
                                }
                            }
                        }
                        if (blind && count != 0)
                        {
                            MsgPrint("You hear many powerful things appear nearby.");
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
                        race.Knowledge.RFlags4 |= 1u << (thrownSpell - (32 * 3));
                        if (race.Knowledge.RCastInate < Constants.MaxUchar)
                        {
                            race.Knowledge.RCastInate++;
                        }
                    }
                    else if (thrownSpell < 32 * 5)
                    {
                        race.Knowledge.RFlags5 |= 1u << (thrownSpell - (32 * 4));
                        if (race.Knowledge.RCastSpell < Constants.MaxUchar)
                        {
                            race.Knowledge.RCastSpell++;
                        }
                    }
                    else if (thrownSpell < 32 * 6)
                    {
                        race.Knowledge.RFlags6 |= 1u << (thrownSpell - (32 * 5));
                        if (race.Knowledge.RCastSpell < Constants.MaxUchar)
                        {
                            race.Knowledge.RCastSpell++;
                        }
                    }
                }
                // If we killed the player, let their descendants remember that
                if (Player.IsDead && race.Knowledge.RDeaths < Constants.MaxShort)
                {
                    race.Knowledge.RDeaths++;
                }
                // We did cast a spell
                return true;
            }
            return false;
        }

        /// <summary>
        /// Choose and use an attack spell to cast when in combat with the player
        /// </summary>
        /// <param name="monsterIndex"> The index of the monster </param>
        /// <returns> True if a spell was cast, false if not </returns>
        private bool TryCastingASpellAgainstPlayer(int monsterIndex)
        {
            int k;
            int[] spell = new int[96];
            int num = 0;
            Monster monster = Level.Monsters[monsterIndex];
            MonsterRace race = monster.Race;
            bool noInnate = false;
            int playerX = Player.MapX;
            int playerY = Player.MapY;
            int count = 0;
            bool playerIsBlind = Player.TimedBlindness != 0;
            bool seenByPlayer = !playerIsBlind && monster.IsVisible;
            // No spells if we're confused
            if (monster.ConfusionLevel != 0)
            {
                return false;
            }
            // No spells if we're being nice because we've just been summoned
            if ((monster.IndividualMonsterFlags & Constants.MflagNice) != 0)
            {
                return false;
            }
            // No spells on the player if they're our friend
            if ((monster.Mind & Constants.SmFriendly) != 0)
            {
                return false;
            }
            // We aren't guaranteed to cast a spell even if we can
            int chance = (race.FreqInate + race.FreqSpell) / 2;
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
            if (monster.DistanceFromPlayer > Constants.MaxRange)
            {
                return false;
            }
            // If we have no line of sight to the player, don't cast a spell
            if (!Level.Projectable(monster.MapY, monster.MapX, Player.MapY, Player.MapX))
            {
                return false;
            }
            // Gather together the abilities we have
            int monsterLevel = race.Level >= 1 ? race.Level : 1;
            uint f4 = race.Flags4;
            uint f5 = race.Flags5;
            uint f6 = race.Flags6;
            // If we're not allowed innate abilities, then things on Flags4 can't be used
            if (noInnate)
            {
                f4 = 0;
            }
            // If we're smart and badly injured, we may want to prioritise spells that disable the
            // player, summon help, or let us escape over spells that do direct damage
            if ((race.Flags2 & MonsterFlag2.Smart) != 0 && monster.Health < monster.MaxHealth / 10 &&
                Program.Rng.RandomLessThan(100) < 50)
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
            RemoveIneffectiveSpells(monsterIndex, out f4, f4, out f5, f5, out f6, f6);
            // If we just got rid of all our spells then don't cast
            if (f4 == 0 && f5 == 0 && f6 == 0)
            {
                return false;
            }
            // If we don't have a clean shot, and we're stupid, remove bolt spells
            if (((f4 & MonsterFlag4.BoltMask) != 0 || (f5 & MonsterFlag5.BoltMask) != 0 ||
                 (f6 & MonsterFlag6.BoltMask) != 0) && (race.Flags2 & MonsterFlag2.Stupid) == 0 &&
                !CleanShot(monster.MapY, monster.MapX, Player.MapY, Player.MapX))
            {
                f4 &= ~MonsterFlag4.BoltMask;
                f5 &= ~MonsterFlag5.BoltMask;
                f6 &= ~MonsterFlag6.BoltMask;
            }
            // If there's nowhere around the player to put a summoned creature, then remove
            // summoning spells
            if (((f4 & MonsterFlag4.SummonMask) != 0 || (f5 & MonsterFlag5.SummonMask) != 0 ||
                 (f6 & MonsterFlag6.SummonMask) != 0) && (race.Flags2 & MonsterFlag2.Stupid) == 0 &&
                !SummonPossible(Player.MapY, Player.MapX))
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
            // If the player's already dead or off the level, don't cast
            if (!Playing || Player.IsDead || NewLevelFlag)
            {
                return false;
            }
            string monsterName = monster.MonsterDesc(0x00);
            string monsterPossessive = monster.MonsterDesc(0x22);
            string monsterDescription = monster.MonsterDesc(0x88);
            // Pick one of our spells to cast, based on our priorities
            int thrownSpell = ChooseSpellAgainstPlayer(monsterIndex, spell, num);
            // If we decided not to cast, don't
            if (thrownSpell == 0)
            {
                return false;
            }
            // Stupid monsters may fail spells
            int failrate = 25 - ((monsterLevel + 3) / 4);
            if ((race.Flags2 & MonsterFlag2.Stupid) != 0)
            {
                failrate = 0;
            }
            // Only check for actual spells - nothing is so stupid it fails to breathe
            if (thrownSpell >= 128 && Program.Rng.RandomLessThan(100) < failrate)
            {
                MsgPrint($"{monsterName} tries to cast a spell, but fails.");
                return true;
            }
            // Now do whatever the actual spell does
            switch (thrownSpell)
            {
                // MonsterFlag4.Shriek
                case 96 + 0:
                    Disturb(true);
                    MsgPrint($"{monsterName} makes a high pitched shriek.");
                    AggravateMonsters(monsterIndex);
                    break;

                // MonsterFlag4.Xxx2
                case 96 + 1:
                // MonsterFlag4.Xxx3
                case 96 + 2:
                    break;

                // MonsterFlag4.ShardBall
                case 96 + 3:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles something." : $"{monsterName} fires a shard ball.");
                    FireBallAtPlayer(monsterIndex, new ProjectShard(this), monster.Health / 4 > 800 ? 800 : monster.Health / 4, 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsShard);
                    break;

                // MonsterFlag4.Arrow1D6
                case 96 + 4:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires an arrow.");
                    FireBoltAtPlayer(monsterIndex, new ProjectArrow(this), Program.Rng.DiceRoll(1, 6));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag4.Arrow3D6
                case 96 + 5:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires an arrow!");
                    FireBoltAtPlayer(monsterIndex, new ProjectArrow(this), Program.Rng.DiceRoll(3, 6));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag4.Arrow5D6
                case 96 + 6:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName}s makes a strange noise." : $"{monsterName} fires a missile.");
                    FireBoltAtPlayer(monsterIndex, new ProjectArrow(this), Program.Rng.DiceRoll(5, 6));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag4.Arrow7D6
                case 96 + 7:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} makes a strange noise." : $"{monsterName} fires a missile!");
                    FireBoltAtPlayer(monsterIndex, new ProjectArrow(this), Program.Rng.DiceRoll(7, 6));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag4.BreatheAcid
                case 96 + 8:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes acid.");
                    BreatheAtPlayer(monsterIndex, new ProjectAcid(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsAcid);
                    break;

                // MonsterFlag4.BreatheLightning
                case 96 + 9:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes lightning.");
                    BreatheAtPlayer(monsterIndex, new ProjectElec(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsElec);
                    break;

                // MonsterFlag4.BreatheFire
                case 96 + 10:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes fire.");
                    BreatheAtPlayer(monsterIndex, new ProjectFire(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFire);
                    break;

                // MonsterFlag4.BreatheCold
                case 96 + 11:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes frost.");
                    BreatheAtPlayer(monsterIndex, new ProjectCold(this), monster.Health / 3 > 1600 ? 1600 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsCold);
                    break;

                // MonsterFlag4.BreathePoison
                case 96 + 12:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes gas.");
                    BreatheAtPlayer(monsterIndex, new ProjectPois(this), monster.Health / 3 > 800 ? 800 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsPois);
                    break;

                // MonsterFlag4.BreatheNether
                case 96 + 13:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes nether.");
                    BreatheAtPlayer(monsterIndex, new ProjectNether(this), monster.Health / 6 > 550 ? 550 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsNeth);
                    break;

                // MonsterFlag4.BreatheLight
                case 96 + 14:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes light.");
                    BreatheAtPlayer(monsterIndex, new ProjectLight(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsLight);
                    break;

                // MonsterFlag4.BreatheDark
                case 96 + 15:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes darkness.");
                    BreatheAtPlayer(monsterIndex, new ProjectDark(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsDark);
                    break;

                // MonsterFlag4.BreatheConfusion
                case 96 + 16:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes confusion.");
                    BreatheAtPlayer(monsterIndex, new ProjectConfusion(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsConf);
                    break;

                // MonsterFlag4.BreatheSound
                case 96 + 17:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes sound.");
                    BreatheAtPlayer(monsterIndex, new ProjectSound(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsSound);
                    break;

                // MonsterFlag4.BreatheChaos
                case 96 + 18:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes chaos.");
                    BreatheAtPlayer(monsterIndex, new ProjectChaos(this), monster.Health / 6 > 600 ? 600 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsChaos);
                    break;

                // MonsterFlag4.BreatheDisenchant
                case 96 + 19:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes disenchantment.");
                    BreatheAtPlayer(monsterIndex, new ProjectDisenchant(this), monster.Health / 6 > 500 ? 500 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsDisen);
                    break;

                // MonsterFlag4.BreatheNexus
                case 96 + 20:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes nexus.");
                    BreatheAtPlayer(monsterIndex, new ProjectNexus(this), monster.Health / 3 > 250 ? 250 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsNexus);
                    break;

                // MonsterFlag4.BreatheTime
                case 96 + 21:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes time.");
                    BreatheAtPlayer(monsterIndex, new ProjectTime(this), monster.Health / 3 > 150 ? 150 : monster.Health / 3, 0);
                    break;

                // MonsterFlag4.BreatheInertia
                case 96 + 22:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes inertia.");
                    BreatheAtPlayer(monsterIndex, new ProjectInertia(this), monster.Health / 6 > 200 ? 200 : monster.Health / 6, 0);
                    break;

                // MonsterFlag4.BreatheGravity
                case 96 + 23:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes gravity.");
                    BreatheAtPlayer(monsterIndex, new ProjectGravity(this), monster.Health / 3 > 200 ? 200 : monster.Health / 3, 0);
                    break;

                // MonsterFlag4.BreatheShards
                case 96 + 24:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes shards.");
                    BreatheAtPlayer(monsterIndex, new ProjectExplode(this), monster.Health / 6 > 400 ? 400 : monster.Health / 6, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsShard);
                    break;

                // MonsterFlag4.BreathePlasma
                case 96 + 25:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes plasma.");
                    BreatheAtPlayer(monsterIndex, new ProjectPlasma(this), monster.Health / 6 > 150 ? 150 : monster.Health / 6, 0);
                    break;

                // MonsterFlag4.BreatheForce
                case 96 + 26:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes force.");
                    BreatheAtPlayer(monsterIndex, new ProjectForce(this), monster.Health / 6 > 200 ? 200 : monster.Health / 6, 0);
                    break;

                // MonsterFlag4.BreatheMana
                case 96 + 27:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes magical energy.");
                    BreatheAtPlayer(monsterIndex, new ProjectMana(this), monster.Health / 3 > 250 ? 250 : monster.Health / 3, 0);
                    break;

                // MonsterFlag4.RadiationBall
                case 96 + 28:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a ball of radiation.");
                    FireBallAtPlayer(monsterIndex, new ProjectNuke(this), monsterLevel + Program.Rng.DiceRoll(10, 6), 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsPois);
                    break;

                // MonsterFlag4.BreatheRadiation
                case 96 + 29:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes toxic waste.");
                    BreatheAtPlayer(monsterIndex, new ProjectNuke(this), monster.Health / 3 > 800 ? 800 : monster.Health / 3, 0);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsPois);
                    break;

                // MonsterFlag4.ChaosBall
                case 96 + 30:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles frighteningly."
                        : $"{monsterName} invokes raw chaos.");
                    FireBallAtPlayer(monsterIndex, new ProjectChaos(this), (monsterLevel * 2) + Program.Rng.DiceRoll(10, 10), 4);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsChaos);
                    break;

                // MonsterFlag4.BreatheDisintegration
                case 96 + 31:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} breathes." : $"{monsterName} breathes disintegration.");
                    BreatheAtPlayer(monsterIndex, new ProjectDisintegrate(this), monster.Health / 3 > 300 ? 300 : monster.Health / 3, 0);
                    break;

                // MonsterFlag5.AcidBall
                case 128 + 0:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts an acid ball.");
                    FireBallAtPlayer(monsterIndex, new ProjectAcid(this), Program.Rng.DieRoll(monsterLevel * 3) + 15, 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsAcid);
                    break;

                // MonsterFlag5.LightningBall
                case 128 + 1:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a lightning ball.");
                    FireBallAtPlayer(monsterIndex, new ProjectElec(this), Program.Rng.DieRoll(monsterLevel * 3 / 2) + 8, 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsElec);
                    break;

                // MonsterFlag5.FireBall
                case 128 + 2:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a fire ball.");
                    FireBallAtPlayer(monsterIndex, new ProjectFire(this), Program.Rng.DieRoll(monsterLevel * 7 / 2) + 10, 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFire);
                    break;

                // MonsterFlag5.ColdBall
                case 128 + 3:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a frost ball.");
                    FireBallAtPlayer(monsterIndex, new ProjectCold(this), Program.Rng.DieRoll(monsterLevel * 3 / 2) + 10, 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsCold);
                    break;

                // MonsterFlag5.PoisonBall
                case 128 + 4:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a stinking cloud.");
                    FireBallAtPlayer(monsterIndex, new ProjectPois(this), Program.Rng.DiceRoll(12, 2), 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsPois);
                    break;

                // MonsterFlag5.NetherBall
                case 128 + 5:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a nether ball.");
                    FireBallAtPlayer(monsterIndex, new ProjectNether(this), 50 + Program.Rng.DiceRoll(10, 10) + monsterLevel, 2);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsNeth);
                    break;

                // MonsterFlag5.WaterBall
                case 128 + 6:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} gestures fluidly.");
                    MsgPrint("You are engulfed in a whirlpool.");
                    FireBallAtPlayer(monsterIndex, new ProjectWater(this), Program.Rng.DieRoll(monsterLevel * 5 / 2) + 50, 4);
                    break;

                // MonsterFlag5.ManaBall
                case 128 + 7:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles powerfully."
                        : $"{monsterName} invokes a mana storm.");
                    FireBallAtPlayer(monsterIndex, new ProjectMana(this), (monsterLevel * 5) + Program.Rng.DiceRoll(10, 10), 4);
                    break;

                // MonsterFlag5.DarkBall
                case 128 + 8:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles powerfully."
                        : $"{monsterName} invokes a darkness storm.");
                    FireBallAtPlayer(monsterIndex, new ProjectDark(this), (monsterLevel * 5) + Program.Rng.DiceRoll(10, 10), 4);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsDark);
                    break;

                // MonsterFlag5.DrainMana
                case 128 + 9:
                    if (Player.Mana != 0)
                    {
                        Disturb(true);
                        MsgPrint($"{monsterName} draws psychic energy from you!");
                        int r1 = (Program.Rng.DieRoll(monsterLevel) / 2) + 1;
                        if (r1 >= Player.Mana)
                        {
                            r1 = Player.Mana;
                            Player.Mana = 0;
                            Player.FractionalMana = 0;
                        }
                        else
                        {
                            Player.Mana -= r1;
                        }
                        Player.RedrawNeeded.Set(RedrawFlag.PrMana);
                        if (monster.Health < monster.MaxHealth)
                        {
                            monster.Health += 6 * r1;
                            if (monster.Health > monster.MaxHealth)
                            {
                                monster.Health = monster.MaxHealth;
                            }
                            if (TrackedMonsterIndex == monsterIndex)
                            {
                                Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                            }
                            if (seenByPlayer)
                            {
                                MsgPrint($"{monsterName} appears healthier.");
                            }
                        }
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsMana);
                    break;

                // MonsterFlag5.MindBlast
                case 128 + 10:
                    Disturb(true);
                    MsgPrint(!seenByPlayer
                        ? "You feel something focusing on your mind."
                        : $"{monsterName} gazes deep into your eyes.");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        MsgPrint("Your mind is blasted by psionic energy.");
                        if (!Player.HasConfusionResistance)
                        {
                            Player.SetTimedConfusion(Player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                        }
                        if (!Player.HasChaosResistance && Program.Rng.DieRoll(3) == 1)
                        {
                            Player.SetTimedHallucinations(Player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 150);
                        }
                        Player.TakeHit(Program.Rng.DiceRoll(8, 8), monsterDescription);
                    }
                    break;

                // MonsterFlag5.BrainSmash
                case 128 + 11:
                    Disturb(true);
                    MsgPrint(!seenByPlayer
                        ? "You feel something focusing on your mind."
                        : $"{monsterName} looks deep into your eyes.");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        MsgPrint("Your mind is blasted by psionic energy.");
                        Player.TakeHit(Program.Rng.DiceRoll(12, 15), monsterDescription);
                        if (!Player.HasBlindnessResistance)
                        {
                            Player.SetTimedBlindness(Player.TimedBlindness + 8 + Program.Rng.RandomLessThan(8));
                        }
                        if (!Player.HasConfusionResistance)
                        {
                            Player.SetTimedConfusion(Player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                        }
                        if (!Player.HasFreeAction)
                        {
                            Player.SetTimedParalysis(Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4);
                        }
                        Player.SetTimedSlow(Player.TimedSlow + Program.Rng.RandomLessThan(4) + 4);
                        while (Program.Rng.RandomLessThan(100) > Player.SkillSavingThrow)
                        {
                            Player.TryDecreasingAbilityScore(Ability.Intelligence);
                        }
                        while (Program.Rng.RandomLessThan(100) > Player.SkillSavingThrow)
                        {
                            Player.TryDecreasingAbilityScore(Ability.Wisdom);
                        }
                        if (!Player.HasChaosResistance)
                        {
                            Player.SetTimedHallucinations(Player.TimedHallucinations + Program.Rng.RandomLessThan(250) + 150);
                        }
                    }
                    break;

                // MonsterFlag5.CauseLightWounds
                case 128 + 12:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} points at you and curses.");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.CurseEquipment(33, 0);
                        Player.TakeHit(Program.Rng.DiceRoll(3, 8), monsterDescription);
                    }
                    break;

                // MonsterFlag5.CauseSeriousWounds
                case 128 + 13:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} points at you and curses horribly.");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.CurseEquipment(50, 5);
                        Player.TakeHit(Program.Rng.DiceRoll(8, 8), monsterDescription);
                    }
                    break;

                // MonsterFlag5.CauseCriticalWounds
                case 128 + 14:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles loudly."
                        : $"{monsterName} points at you, incanting terribly!");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.CurseEquipment(80, 15);
                        Player.TakeHit(Program.Rng.DiceRoll(10, 15), monsterDescription);
                    }
                    break;

                // MonsterFlag5.CauseMortalWounds
                case 128 + 15:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} screams the word 'DIE!'"
                        : $"{monsterName} points at you, screaming the word DIE!");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.TakeHit(Program.Rng.DiceRoll(15, 15), monsterDescription);
                        Player.SetTimedBleeding(Player.TimedBleeding + Program.Rng.DiceRoll(10, 10));
                    }
                    break;

                // MonsterFlag5.AcidBolt
                case 128 + 16:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a acid bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectAcid(this), Program.Rng.DiceRoll(7, 8) + (monsterLevel / 3));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsAcid);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.LightningBolt
                case 128 + 17:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a lightning bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectElec(this), Program.Rng.DiceRoll(4, 8) + (monsterLevel / 3));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsElec);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.FireBolt
                case 128 + 18:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a fire bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectFire(this), Program.Rng.DiceRoll(9, 8) + (monsterLevel / 3));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFire);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.ColdBolt
                case 128 + 19:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a frost bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectCold(this), Program.Rng.DiceRoll(6, 8) + (monsterLevel / 3));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsCold);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.PoisonBolt
                case 128 + 20:
                    break;

                // MonsterFlag5.NetherBolt
                case 128 + 21:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a nether bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectNether(this), 30 + Program.Rng.DiceRoll(5, 5) + (monsterLevel * 3 / 2));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsNeth);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.WaterBolt
                case 128 + 22:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a water bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectWater(this), Program.Rng.DiceRoll(10, 10) + monsterLevel);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.ManaBolt
                case 128 + 23:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a mana bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectMana(this), Program.Rng.DieRoll(monsterLevel * 7 / 2) + 50);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.PlasmaBolt
                case 128 + 24:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a plasma bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectPlasma(this), 10 + Program.Rng.DiceRoll(8, 7) + monsterLevel);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.IceBolt
                case 128 + 25:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts an ice bolt.");
                    FireBoltAtPlayer(monsterIndex, new ProjectIce(this), Program.Rng.DiceRoll(6, 6) + monsterLevel);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsCold);
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.MagicMissile
                case 128 + 26:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a magic missile.");
                    FireBoltAtPlayer(monsterIndex, new ProjectMissile(this), Program.Rng.DiceRoll(2, 6) + (monsterLevel / 3));
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsReflect);
                    break;

                // MonsterFlag5.Scare
                case 128 + 27:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles, and you hear scary noises."
                        : $"{monsterName} casts a fearful illusion.");
                    if (Player.HasFearResistance)
                    {
                        MsgPrint("You refuse to be frightened.");
                    }
                    else if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You refuse to be frightened.");
                    }
                    else
                    {
                        Player.SetTimedFear(Player.TimedFear + Program.Rng.RandomLessThan(4) + 4);
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFear);
                    break;

                // MonsterFlag5.Blindness
                case 128 + 28:
                    Disturb(true);
                    MsgPrint(
                        playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} casts a spell, burning your eyes!");
                    if (Player.HasBlindnessResistance)
                    {
                        MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.SetTimedBlindness(12 + Program.Rng.RandomLessThan(4));
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsBlind);
                    break;

                // MonsterFlag5.Confuse
                case 128 + 29:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles, and you hear puzzling noises."
                        : $"{monsterName} creates a mesmerising illusion.");
                    if (Player.HasConfusionResistance)
                    {
                        MsgPrint("You disbelieve the feeble spell.");
                    }
                    else if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You disbelieve the feeble spell.");
                    }
                    else
                    {
                        Player.SetTimedConfusion(Player.TimedConfusion + Program.Rng.RandomLessThan(4) + 4);
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsConf);
                    break;

                // MonsterFlag5.Slow
                case 128 + 30:
                    Disturb(true);
                    MsgPrint($"{monsterName} drains power from your muscles!");
                    if (Player.HasFreeAction)
                    {
                        MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.SetTimedSlow(Player.TimedSlow + Program.Rng.RandomLessThan(4) + 4);
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFree);
                    break;

                // MonsterFlag5.Hold
                case 128 + 31:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} stares deep into your eyes!");
                    if (Player.HasFreeAction)
                    {
                        MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        Player.SetTimedParalysis(Player.TimedParalysis + Program.Rng.RandomLessThan(4) + 4);
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFree);
                    break;

                // MonsterFlag6.Haste
                case 160 + 0:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} concentrates on {monsterPossessive} body.");
                    if (monster.Speed < race.Speed + 10)
                    {
                        MsgPrint($"{monsterName} starts moving faster.");
                        monster.Speed += 10;
                    }
                    else if (monster.Speed < race.Speed + 20)
                    {
                        MsgPrint($"{monsterName} starts moving faster.");
                        monster.Speed += 2;
                    }
                    break;

                // MonsterFlag6.DreadCurse
                case 160 + 1:
                    Disturb(true);
                    MsgPrint($"{monsterName} invokes the Dread Curse of Azathoth!");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        int dummy = (65 + Program.Rng.DieRoll(25)) * Player.Health / 100;
                        MsgPrint("Your feel your life fade away!");
                        Player.TakeHit(dummy, monsterName);
                        Player.CurseEquipment(100, 20);
                        if (Player.Health < 1)
                        {
                            Player.Health = 1;
                        }
                    }
                    break;

                // MonsterFlag6.Heal
                case 160 + 2:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} concentrates on {monsterPossessive} wounds.");
                    monster.Health += monsterLevel * 6;
                    if (monster.Health >= monster.MaxHealth)
                    {
                        monster.Health = monster.MaxHealth;
                        MsgPrint(seenByPlayer
                            ? $"{monsterName} looks completely healed!"
                            : $"{monsterName} sounds completely healed!");
                    }
                    else
                    {
                        MsgPrint(seenByPlayer ? $"{monsterName} looks healthier." : $"{monsterName} sounds healthier.");
                    }
                    if (TrackedMonsterIndex == monsterIndex)
                    {
                        Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                    if (monster.FearLevel != 0)
                    {
                        monster.FearLevel = 0;
                        MsgPrint($"{monsterName} recovers {monsterPossessive} courage.");
                    }
                    break;

                // MonsterFlag6.Xxx2
                case 160 + 3:
                    break;

                // MonsterFlag6.Blink
                case 160 + 4:
                    Disturb(true);
                    MsgPrint($"{monsterName} blinks away.");
                    TeleportAway(monsterIndex, 10);
                    break;

                // MonsterFlag6.TeleportSelf
                case 160 + 5:
                    Disturb(true);
                    MsgPrint($"{monsterName} teleports away.");
                    TeleportAway(monsterIndex, (Constants.MaxSight * 2) + 5);
                    break;

                // MonsterFlag6.Xxx3
                case 160 + 6:
                // MonsterFlag6.Xxx4
                case 160 + 7:
                    break;

                // MonsterFlag6.TeleportTo
                case 160 + 8:
                    Disturb(true);
                    MsgPrint($"{monsterName} commands you to return.");
                    TeleportPlayerTo(monster.MapY, monster.MapX);
                    break;

                // MonsterFlag6.TeleportAway
                case 160 + 9:
                    Disturb(true);
                    MsgPrint($"{monsterName} teleports you away.");
                    TeleportPlayer(100);
                    break;

                // MonsterFlag6.TeleportLevel
                case 160 + 10:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles strangely."
                        : $"{monsterName} gestures at your feet.");
                    if (Player.HasNexusResistance)
                    {
                        MsgPrint("You are unaffected!");
                    }
                    else if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else
                    {
                        TeleportPlayerLevel();
                    }
                    Level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsNexus);
                    break;

                // MonsterFlag6.Xxx5
                case 160 + 11:
                    break;

                // MonsterFlag6.Darkness
                case 160 + 12:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} gestures in shadow.");
                    UnlightArea(0, 3);
                    break;

                // MonsterFlag6.CreateTraps
                case 160 + 13:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles, and then cackles evilly."
                        : $"{monsterName} casts a spell and cackles evilly.");
                    TrapCreation();
                    break;

                // MonsterFlag6.Forget
                case 160 + 14:
                    Disturb(true);
                    MsgPrint($"{monsterName} tries to blank your mind.");
                    if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                    {
                        MsgPrint("You resist the effects!");
                    }
                    else if (LoseAllInfo())
                    {
                        MsgPrint("Your memories fade away.");
                    }
                    break;

                // MonsterFlag6.Xxx6
                case 160 + 15:
                    break;

                // MonsterFlag6.SummonKin
                case 160 + 16:
                    Disturb(true);
                    if (playerIsBlind)
                    {
                        MsgPrint($"{monsterName} mumbles.");
                    }
                    else
                    {
                        string kin = (race.Flags1 & MonsterFlag1.Unique) != 0 ? "minions" : "kin";
                        MsgPrint($"{monsterName} magically summons {monsterPossessive} {kin}.");
                    }
                    Level.Monsters.SummonKinType = race.Character;
                    for (k = 0; k < 6; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonKin))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonReaver
                case 160 + 17:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons Black Reavers!");
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear heavy steps nearby.");
                    }
                    SummonReaver();
                    break;

                // MonsterFlag6.SummonMonster
                case 160 + 18:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons help!");
                    for (k = 0; k < 1; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, 0))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonMonsters
                case 160 + 19:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons monsters!");
                    for (k = 0; k < 8; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, 0))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonAnt
                case 160 + 20:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons ants.");
                    for (k = 0; k < 6; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonAnt))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonSpider
                case 160 + 21:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons spiders.");
                    for (k = 0; k < 6; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonSpider))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHound
                case 160 + 22:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons hounds.");
                    for (k = 0; k < 6; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHound))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHydra
                case 160 + 23:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons hydras.");
                    for (k = 0; k < 6; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHydra))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonCthuloid
                case 160 + 24:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons a Cthuloid entity!");
                    for (k = 0; k < 1; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonCthuloid))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonDemon
                case 160 + 25:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons a demon!");
                    for (k = 0; k < 1; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonDemon))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonUndead
                case 160 + 26:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons an undead adversary!");
                    for (k = 0; k < 1; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonUndead))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonDragon
                case 160 + 27:
                    Disturb(true);
                    MsgPrint(playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons a dragon!");
                    for (k = 0; k < 1; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonDragon))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear something appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHiUndead
                case 160 + 28:
                    Disturb(true);
                    MsgPrint(
                        playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons greater undead!");
                    for (k = 0; k < 8; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHiUndead))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many creepy things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonHiDragon
                case 160 + 29:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons ancient dragons!");
                    for (k = 0; k < 8; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHiDragon))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many powerful things appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonGreatOldOne
                case 160 + 30:
                    Disturb(true);
                    MsgPrint(
                        playerIsBlind ? $"{monsterName} mumbles." : $"{monsterName} magically summons Great Old Ones!");
                    for (k = 0; k < 8; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonGoo))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear immortal beings appear nearby.");
                    }
                    break;

                // MonsterFlag6.SummonUnique
                case 160 + 31:
                    Disturb(true);
                    MsgPrint(playerIsBlind
                        ? $"{monsterName} mumbles."
                        : $"{monsterName} magically summons special opponents!");
                    for (k = 0; k < 8; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonUnique))
                        {
                            count++;
                        }
                    }
                    for (k = 0; k < 8; k++)
                    {
                        if (Level.Monsters.SummonSpecific(playerY, playerX, monsterLevel, Constants.SummonHiUndead))
                        {
                            count++;
                        }
                    }
                    if (playerIsBlind && count != 0)
                    {
                        MsgPrint("You hear many powerful things appear nearby.");
                    }
                    break;
            }
            // If the player saw us cast the spell, let them learn we can do that
            if (seenByPlayer)
            {
                if (thrownSpell < 32 * 4)
                {
                    race.Knowledge.RFlags4 |= 1u << (thrownSpell - (32 * 3));
                    if (race.Knowledge.RCastInate < Constants.MaxUchar)
                    {
                        race.Knowledge.RCastInate++;
                    }
                }
                else if (thrownSpell < 32 * 5)
                {
                    race.Knowledge.RFlags5 |= 1u << (thrownSpell - (32 * 4));
                    if (race.Knowledge.RCastSpell < Constants.MaxUchar)
                    {
                        race.Knowledge.RCastSpell++;
                    }
                }
                else if (thrownSpell < 32 * 6)
                {
                    race.Knowledge.RFlags6 |= 1u << (thrownSpell - (32 * 5));
                    if (race.Knowledge.RCastSpell < Constants.MaxUchar)
                    {
                        race.Knowledge.RCastSpell++;
                    }
                }
            }
            // If we killed the player, let their descendants remember that
            if (Player.IsDead && race.Knowledge.RDeaths < Constants.MaxShort)
            {
                race.Knowledge.RDeaths++;
            }
            // We did cast a spell
            return true;
        }
    }
}