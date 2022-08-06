// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.Commands;
using Cthangband.Debug;
using Cthangband.Enumerations;
using Cthangband.Patrons;
using Cthangband.Projection;
using Cthangband.Spells;
using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.Collections.Generic;

namespace Cthangband
{
    [Serializable]
    internal class SaveGame
    {
        public int CommandRepeat;
        public readonly CommandEngine CommandEngine;
        public readonly Dungeon[] Dungeons;
        public readonly Patron[] PatronList;
        public readonly QuestArray Quests = new QuestArray();
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
        public bool IsAutosave;
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

        private List<Monster> _petList = new List<Monster>();
        private int _seedFlavor;
        public const int HurtChance = 16;

        public SaveGame()
        {
            CommandEngine = new CommandEngine(this);
            Towns = Town.NewTownList();
            Dungeons = Dungeon.NewDungeonList();
            PatronList = Patron.NewPatronList();
        }

        internal delegate bool ItemFilterDelegate(Item item);

        public static SaveGame Instance
        {
            get; set;
        }

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
                        Profile.Instance.MsgPrint("You feel your life draining away...");
                        Player.LoseExperience(Player.ExperiencePoints / 16);
                        break;

                    case 13:
                    case 14:
                    case 15:
                    case 19:
                    case 20:
                        if (!Player.HasFreeAction || Program.Rng.DieRoll(100) >= Player.SkillSavingThrow)
                        {
                            Profile.Instance.MsgPrint("You feel like a statue!");
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
                        Profile.Instance.MsgPrint("Huh? Who am I? What am I doing here?");
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
                Profile.Instance.MsgPrint("A small needle has pricked you!");
                Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
                Player.TryDecreasingAbilityScore(Ability.Strength);
            }
            if ((trap & Enumerations.ChestTrap.ChestLoseCon) != 0)
            {
                Profile.Instance.MsgPrint("A small needle has pricked you!");
                Player.TakeHit(Program.Rng.DiceRoll(1, 4), "a poison needle");
                Player.TryDecreasingAbilityScore(Ability.Constitution);
            }
            if ((trap & Enumerations.ChestTrap.ChestPoison) != 0)
            {
                Profile.Instance.MsgPrint("A puff of green gas surrounds you!");
                if (!(Player.HasPoisonResistance || Player.TimedPoisonResistance != 0))
                {
                    if (Program.Rng.DieRoll(10) <= Player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                    {
                        Profile.Instance.MsgPrint("Hagarg Ryonis's favour protects you!");
                    }
                    else
                    {
                        Player.SetTimedPoison(Player.TimedPoison + 10 + Program.Rng.DieRoll(20));
                    }
                }
            }
            if ((trap & Enumerations.ChestTrap.ChestParalyze) != 0)
            {
                Profile.Instance.MsgPrint("A puff of yellow gas surrounds you!");
                if (!Player.HasFreeAction)
                {
                    Player.SetTimedParalysis(Player.TimedParalysis + 10 + Program.Rng.DieRoll(20));
                }
            }
            if ((trap & Enumerations.ChestTrap.ChestSummon) != 0)
            {
                int num = 2 + Program.Rng.DieRoll(3);
                Profile.Instance.MsgPrint("You are enveloped in a cloud of smoke!");
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
                Profile.Instance.MsgPrint("There is a sudden explosion!");
                Profile.Instance.MsgPrint("Everything inside the chest is destroyed!");
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
                    buffer = y < Instance.Towns.Length
                        ? $"{Dungeons[y].MapSymbol} = {Towns[y].Name} (L:{depth}, D:{difficulty}, Q:{dungeonGuardians[y]})"
                        : $"{Dungeons[y].MapSymbol} = {Dungeons[y].Name} (L:{depth}, D:{difficulty}, Q:{dungeonGuardians[y]})";
                }
                else
                {
                    buffer = $"? = {Dungeons[y].Name} (L:{depth}, D:{difficulty}, Q:{dungeonGuardians[y]})";
                }
                Colour keyAttr = Colour.Brown;
                if (y < Instance.Towns.Length)
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

        public void DoCmdSaveGame()
        {
            if (!IsAutosave)
            {
                Disturb(true);
            }
            Profile.Instance.MsgPrint(null);
            HandleStuff();
            Gui.Refresh();
            DiedFrom = "(saved)";
            SavePlayer();
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
            Profile.Instance.MsgPrint(null);
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

        public void Initialise()
        {
            InitialiseAllocationTables();
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
                qPtr = new Item(Level.Items[thisOIdx]);
                Level.DeleteObjectIdx(thisOIdx);
                Level.DropNear(qPtr, -1, y, x);
            }
            if (mPtr.StolenGold > 0)
            {
                Item oPtr = new Item();
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
                qPtr = new Item();
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
                Profile.Instance.MsgPrint("*** CONGRATULATIONS ***");
                Profile.Instance.MsgPrint("You have won the game!");
                Profile.Instance.MsgPrint("You may retire ('Q') when you are ready.");
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
                    Profile.Instance.MsgPrint("A magical stairway appears...");
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
                Item qPtr = new Item();
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
            Gui.SetBackground(Terminal.BackgroundImage.Normal);
            Gui.CursorVisible = false;
            if (Program.Rng.UseFixed)
            {
                Program.Rng.UseFixed = false;
            }
            if (Player == null)
            {
                PlayerFactory factory = new PlayerFactory();
                Player newPlayer = factory.CharacterGeneration(Profile.Instance.ExPlayer);
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
                Profile.Instance.ItemTypes.ResetStompability();
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
            Profile.Instance.MsgFlag = false;
            Profile.Instance.MsgPrint(null);
            Gui.Refresh();
            FlavorInit();
            ApplyFlavourVisuals();
            if (Level == null)
            {
                Level = new Level();
                LevelFactory factory = new LevelFactory(Level);
                factory.GenerateNewLevel();
            }
            Gui.FullScreenOverlay = false;
            Gui.SetBackground(Terminal.BackgroundImage.Overhead);
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
                Profile.Instance.MsgPrint(null);
                if (Player.IsDead)
                {
                    // Store the player info
                    Profile.Instance.ExPlayer = new ExPlayer(Player);
                    break;
                }
                Level = new Level();
                LevelFactory factory = new LevelFactory(Level);
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
            PlayerStatus playerStatus = new PlayerStatus(Player, Level);
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
            for (i = 0; i < Profile.Instance.ItemTypes.Count; i++)
            {
                ItemType kPtr = Profile.Instance.ItemTypes[i];
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
            Profile.Instance.MsgPrint(null);
            Gui.FullScreenOverlay = true;
            if (Player.IsDead)
            {
                if (Player.IsWinner)
                {
                    Kingly();
                }
                Player corpse = Player;
                HighScore score = new HighScore(Player);
                Player = null;
                SavePlayer();
                PrintTomb(corpse);
                if (corpse.IsWizard)
                {
                    return;
                }
                Program.HiScores.InsertNewScore(score);
                Program.HiScores.DisplayScores(score.Pts);
            }
            else
            {
                IsAutosave = false;
                DoCmdSaveGame();
                if (!Program.ExitToDesktop)
                {
                    Gui.Mixer.Play(MusicTrack.Menu);
                    Program.HiScores.DisplayScores(new HighScore(Player));
                }
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
            TargetEngine targetEngine = new TargetEngine(Player, Level);
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
            Profile.Instance.MsgPrint(null);
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
                StoreCommand.DoCmdStore(Player, SaveGame.Instance.Level);
                CameFrom = LevelStart.StartRandom;
            }
            if (CurrentDepth == 0)
            {
                if (Difficulty == 0)
                {
                    Gui.Mixer.Play(MusicTrack.Town);
                }
                else
                {
                    Gui.Mixer.Play(MusicTrack.Wilderness);
                }
            }
            else
            {
                if (Quests.IsQuest(CurrentDepth))
                {
                    Gui.Mixer.Play(MusicTrack.QuestLevel);
                }
                else
                {
                    Gui.Mixer.Play(MusicTrack.Dungeon);
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
                ArtificialIntelligence ai = new ArtificialIntelligence(Player, Level);
                ai.ProcessAllMonsters();
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
                    Commands.FeelingAndLocationCommand.DoCmdFeeling(Player, Level, true);
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
            for (i = 1; i < Profile.Instance.ItemTypes.Count; i++)
            {
                ItemType kPtr = Profile.Instance.ItemTypes[i];
                if (string.IsNullOrEmpty(kPtr.Name))
                {
                    continue;
                }
                kPtr.HasFlavor = Inventory.ObjectHasFlavor(kPtr);
                if (!kPtr.HasFlavor)
                {
                    kPtr.FlavourAware = true;
                }
                kPtr.EasyKnow = Inventory.ObjectEasyKnow(i);
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
            for (i = 1; i < Profile.Instance.ItemTypes.Count; i++)
            {
                kPtr = Profile.Instance.ItemTypes[i];
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
                Program.Quit("No town objects!");
            }
            AllocKindTable = new AllocationEntry[AllocKindSize];
            for (int k = 0; k < AllocKindSize; k++)
            {
                AllocKindTable[k] = new AllocationEntry();
            }
            AllocationEntry[] table = AllocKindTable;
            for (i = 1; i < Profile.Instance.ItemTypes.Count; i++)
            {
                kPtr = Profile.Instance.ItemTypes[i];
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
            for (i = 1; i < Profile.Instance.MonsterRaces.Count - 1; i++)
            {
                rPtr = Profile.Instance.MonsterRaces[i];
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
                Program.Quit("No town monsters!");
            }
            AllocRaceTable = new AllocationEntry[AllocRaceSize];
            for (int k = 0; k < AllocRaceSize; k++)
            {
                AllocRaceTable[k] = new AllocationEntry();
            }
            table = AllocRaceTable;
            for (i = 1; i < Profile.Instance.MonsterRaces.Count - 1; i++)
            {
                rPtr = Profile.Instance.MonsterRaces[i];
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
            Gui.SetBackground(Terminal.BackgroundImage.Crown);
            Gui.Clear();
            Gui.AnyKey(44);
        }

        private EntityType ObjectFlavourEntity(int i)
        {
            ItemType kPtr = Profile.Instance.ItemTypes[i];
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
                    Gui.SetBackground(Terminal.BackgroundImage.Sunset);
                    Gui.Mixer.Play(MusicTrack.Victory);
                }
                else
                {
                    Gui.SetBackground(Terminal.BackgroundImage.Tomb);
                    Gui.Mixer.Play(MusicTrack.Death);
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
                Profile.Instance.MsgPrint("You feel different!");
                Player.Dna.GainMutation();
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
                    Profile.Instance.MsgPrint("Cancelled.");
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
                    Profile.Instance.MsgPrint("Your pack overflows!");
                    string oName = oPtr.Description(true, 3);
                    Profile.Instance.MsgPrint($"You drop {oName} ({item.IndexToLabel()}).");
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
                    CommandEngine.RunOneStep(0);
                }
                else if (CommandRepeat != 0)
                {
                    CommandRepeat--;
                    Player.RedrawNeeded.Set(RedrawFlag.PrState);
                    RedrawStuff();
                    Profile.Instance.MsgFlag = false;
                    Gui.PrintLine("", 0, 0);
                    ProcessCommand(Player, Level, true);
                }
                else
                {
                    Level.MoveCursorRelative(Player.MapY, Player.MapX);
                    Gui.RequestCommand(false);
                    ProcessCommand(Player, Level, false);
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
                Profile.Instance.MsgPrint("Happy Birthday!");
                Level.Acquirement(Player.MapY, Player.MapX, Program.Rng.DieRoll(2) + 1, true);
                Player.Age++;
            }
            if (Player.GameTime.IsNewYear)
            {
                Profile.Instance.MsgPrint("Happy New Year!");
                Level.Acquirement(Player.MapY, Player.MapX, Program.Rng.DieRoll(2) + 1, true);
            }
            if (Player.GameTime.IsHalloween)
            {
                Profile.Instance.MsgPrint("All Hallows Eve and the ghouls come out to play...");
                Level.Monsters.SummonSpecific(Player.MapY, Player.MapX, Difficulty, Constants.SummonUndead);
            }
            if (CurrentDepth <= 0)
            {
                if (Player.GameTime.IsDawn)
                {
                    GridTile cPtr;
                    int x;
                    int y;
                    Profile.Instance.MsgPrint("The sun has risen.");
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
                    Profile.Instance.MsgPrint("The sun has fallen.");
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
                        Profile.Instance.MsgPrint("The sun's rays scorch your undead flesh!");
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
                    Profile.Instance.MsgPrint($"The {oName} scorches your undead flesh!");
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
                        Profile.Instance.MsgPrint("Your body feels disrupted!");
                        damDesc = "density";
                    }
                    else
                    {
                        Profile.Instance.MsgPrint("You are being crushed!");
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
                        Profile.Instance.MsgPrint("You faint from the lack of food.");
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
                        Profile.Instance.MsgPrint("Your light has gone out!");
                    }
                    else if (oPtr.TypeSpecificValue < 100 && oPtr.TypeSpecificValue % 10 == 0)
                    {
                        Profile.Instance.MsgPrint("Your light is growing faint.");
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
                    Profile.Instance.MsgPrint("The Jewel of Judgement drains life from you!");
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
                        Profile.Instance.MsgPrint(CurDungeon.Tower
                            ? "You feel yourself yanked downwards!"
                            : "You feel yourself yanked upwards!");
                        IsAutosave = true;
                        DoCmdSaveGame();
                        IsAutosave = false;
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
                        Profile.Instance.MsgPrint(Dungeons[RecallDungeon].Tower
                            ? "You feel yourself yanked upwards!"
                            : "You feel yourself yanked downwards!");
                        IsAutosave = true;
                        DoCmdSaveGame();
                        IsAutosave = false;
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
            PlayerStatus playerStatus = new PlayerStatus(Player, Level);
            if (Player.RedrawNeeded.IsSet(RedrawFlag.PrWipe))
            {
                Player.RedrawNeeded.Clear(RedrawFlag.PrWipe);
                Profile.Instance.MsgPrint(null);
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
                CharacterViewer.PrintEquippy(Player);
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

        private void SavePlayer()
        {
            Program.SerializeToSaveFolder(Profile.Instance, Program.ActiveSaveSlot);
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
                Profile.Instance.MsgPrint("You feel a sudden stirring nearby!");
            }
            else if (sleep)
            {
                Profile.Instance.MsgPrint("You hear a sudden stirring in the distance!");
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
                    Profile.Instance.MsgPrint("You have nothing to turn to gold.");
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
                Profile.Instance.MsgPrint($"You fail to turn {oName} to gold!");
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
                Profile.Instance.MsgPrint($"You turn {oName} to fool's gold.");
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
                Profile.Instance.MsgPrint($"You turn {oName} to {price} coins worth of gold.");
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
            Profile.Instance.MsgPrint("The world changes!");
            IsAutosave = true;
            DoCmdSaveGame();
            IsAutosave = false;
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
                Profile.Instance.MsgPrint($"Your {oName} ({t.IndexToLabel()}) resist{s} disenchantment!");
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
            Profile.Instance.MsgPrint($"Your {oName} ({t.IndexToLabel()}) {s} disenchanted!");
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
                            Profile.Instance.MsgPrint("You resist the effects!");
                            break;
                        }
                        TeleportPlayerLevel();
                        break;
                    }
                case 7:
                    {
                        if (Program.Rng.RandomLessThan(100) < Player.SkillSavingThrow)
                        {
                            Profile.Instance.MsgPrint("You resist the effects!");
                            break;
                        }
                        Profile.Instance.MsgPrint("Your body starts to scramble...");
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
                    Profile.Instance.MsgPrint("You have nothing to enchant.");
                }
                return;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            string oName = oPtr.Description(false, 0);
            string your = item >= 0 ? "Your" : "The";
            string s = oPtr.Count > 1 ? "" : "s";
            Profile.Instance.MsgPrint($"{your} {oName} radiate{s} a blinding light!");
            if (oPtr.FixedArtifactIndex != 0 || string.IsNullOrEmpty(oPtr.RandartName) == false)
            {
                string are = oPtr.Count > 1 ? "are" : "is";
                s = oPtr.Count > 1 ? "artifacts" : "an artifact";
                Profile.Instance.MsgPrint($"The {oName} {are} already {s}!");
                okay = false;
            }
            else if (oPtr.RareItemTypeIndex != 0)
            {
                string are = oPtr.Count > 1 ? "are" : "is";
                s = oPtr.Count > 1 ? "rare items" : "a rare item";
                Profile.Instance.MsgPrint($"The {oName} {are} already {s}!");
                okay = false;
            }
            else
            {
                if (oPtr.Count > 1)
                {
                    Profile.Instance.MsgPrint("Not enough enough energy to enchant more than one object!");
                    s = oPtr.Count > 2 ? "were" : "was";
                    Profile.Instance.MsgPrint($"{oPtr.Count - 1} of your oName {s} destroyed!");
                    oPtr.Count = 1;
                }
                okay = oPtr.CreateRandart(true);
            }
            if (!okay)
            {
                Profile.Instance.MsgPrint("The enchantment failed.");
            }
        }

        public bool BanishEvil(int dist)
        {
            return ProjectAtAllInLos(new ProjectAwayEvil(), dist);
        }

        public void BanishMonsters(int dist)
        {
            ProjectAtAllInLos(new ProjectAwayAll(), dist);
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
                    Profile.Instance.MsgPrint("You have weapon to bless.");
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
                    Profile.Instance.MsgPrint($"The black aura on {your} {oName} disrupts the blessing!");
                    return;
                }
                your = item >= 0 ? "your" : "the";
                Profile.Instance.MsgPrint($"A malignant aura leaves {your} {oName}.");
                oPtr.IdentifyFlags.Clear(Constants.IdentCursed);
                oPtr.IdentifyFlags.Set(Constants.IdentSense);
                oPtr.Inscription = "uncursed";
                Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            }
            if (f3.IsSet(ItemFlag3.Blessed))
            {
                string your = item >= 0 ? "your" : "the";
                string s = oPtr.Count > 1 ? "were" : "was";
                Profile.Instance.MsgPrint($"{your} {oName} {s} blessed already.");
                return;
            }
            if (!(string.IsNullOrEmpty(oPtr.RandartName) == false || oPtr.FixedArtifactIndex != 0) ||
                Program.Rng.DieRoll(3) == 1)
            {
                string your = item >= 0 ? "your" : "the";
                string s = oPtr.Count > 1 ? "" : "s";
                Profile.Instance.MsgPrint($"{your} {oName} shine{s}!");
                oPtr.RandartFlags3.Set(ItemFlag3.Blessed);
            }
            else
            {
                bool disHappened = false;
                Profile.Instance.MsgPrint("The artifact resists your blessing!");
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
                    Profile.Instance.MsgPrint("There is a  feeling in the air...");
                    string your = item >= 0 ? "your" : "the";
                    string s = oPtr.Count > 1 ? "were" : "was";
                    Profile.Instance.MsgPrint($"{your} {oName} {s} disenchanted!");
                }
            }
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
        }

        public void CallChaos()
        {
            TargetEngine targetEngine = new TargetEngine(Player, Level);
            int plev = Player.Level;
            bool lineChaos = false;
            Projectile[] hurtTypes =
            {
                new ProjectElec(), new ProjectPois(), new ProjectAcid(), new ProjectCold(),
                new ProjectFire(), new ProjectMissile(), new ProjectArrow(), new ProjectPlasma(),
                new ProjectHolyFire(), new ProjectWater(), new ProjectLight(), new ProjectDark(),
                new ProjectForce(), new ProjectInertia(), new ProjectMana(), new ProjectMeteor(),
                new ProjectIce(), new ProjectChaos(), new ProjectNether(), new ProjectDisenchant(),
                new ProjectExplode(), new ProjectSound(), new ProjectNexus(), new ProjectConfusion(),
                new ProjectTime(), new ProjectGravity(), new ProjectShard(), new ProjectNuke(),
                new ProjectHellFire(), new ProjectDisintegrate()
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
            TargetedProject(new ProjectControlAnimal(), dir, plev, flg);
        }

        public void CharmAnimals(int dam)
        {
            ProjectAtAllInLos(new ProjectControlAnimal(), dam);
        }

        public bool CharmMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectCharm(), dir, plev, flg);
        }

        public void CharmMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectCharm(), dam);
        }

        public bool CloneMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldClone(), dir, 0, flg);
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
            return TargetedProject(new ProjectOldConf(), dir, plev, flg);
        }

        public void ConfuseMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectOldConf(), dam);
        }

        public void ControlOneUndead(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectControlUndead(), dir, plev, flg);
        }

        public void DeathRay(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectDeathRay(), dir, plev, flg);
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
                Profile.Instance.MsgPrint("There is a searing blast of light!");
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
            return TargetedProject(new ProjectKillDoor(), dir, 0, flg);
        }

        public bool DestroyDoorsTouch()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            return Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectKillDoor(), flg);
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
                Profile.Instance.MsgPrint("You sense the presence of doors!");
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
                Profile.Instance.MsgPrint("You sense the presence of evil creatures!");
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
                Profile.Instance.MsgPrint("You sense the presence of invisible creatures!");
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
                Profile.Instance.MsgPrint("You sense the presence of unnatural beings!");
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
                Profile.Instance.MsgPrint("You sense the presence of monsters!");
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
                Profile.Instance.MsgPrint("You sense the presence of treasure!");
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
                Profile.Instance.MsgPrint("You sense the presence of magic objects!");
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
                Profile.Instance.MsgPrint("You sense the presence of objects!");
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
                Profile.Instance.MsgPrint("You sense the presence of stairs!");
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
                Profile.Instance.MsgPrint("You sense the presence of traps!");
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
                Profile.Instance.MsgPrint("You sense the presence of buried treasure!");
            }
            return detect;
        }

        public bool DisarmTrap(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
            return TargetedProject(new ProjectKillTrap(), dir, 0, flg);
        }

        public void DispelDemons(int dam)
        {
            ProjectAtAllInLos(new ProjectDispDemon(), dam);
        }

        public bool DispelEvil(int dam)
        {
            return ProjectAtAllInLos(new ProjectDispEvil(), dam);
        }

        public void DispelGood(int dam)
        {
            ProjectAtAllInLos(new ProjectDispGood(), dam);
        }

        public void DispelLiving(int dam)
        {
            ProjectAtAllInLos(new ProjectDispLiving(), dam);
        }

        public bool DispelMonsters(int dam)
        {
            return ProjectAtAllInLos(new ProjectDispAll(), dam);
        }

        public bool DispelUndead(int dam)
        {
            return ProjectAtAllInLos(new ProjectDispUndead(), dam);
        }

        public void DoorCreation()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem | ProjectionFlag.ProjectHide;
            Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectMakeDoor(), flg);
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
            return TargetedProject(new ProjectOldDrain(), dir, dam, flg);
        }

        public void Earthquake(int cy, int cx, int r)
        {
            TargetEngine targetEngine = new TargetEngine(Player, Level);
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
                            Profile.Instance.MsgPrint("The Level.Grid ceiling collapses!");
                            break;
                        }
                    case 2:
                        {
                            Profile.Instance.MsgPrint("The Level.Grid floor twists in an unnatural way!");
                            break;
                        }
                    default:
                        {
                            Profile.Instance.MsgPrint("The Level.Grid quakes!  You are pummeled with debris!");
                            break;
                        }
                }
                if (sn == 0)
                {
                    Profile.Instance.MsgPrint("You are severely crushed!");
                    damage = 300;
                }
                else
                {
                    switch (Program.Rng.DieRoll(3))
                    {
                        case 1:
                            {
                                Profile.Instance.MsgPrint("You nimbly dodge the blast!");
                                damage = 0;
                                break;
                            }
                        case 2:
                            {
                                Profile.Instance.MsgPrint("You are bashed by rubble!");
                                damage = Program.Rng.DiceRoll(10, 4);
                                Player.SetTimedStun(Player.TimedStun + Program.Rng.DieRoll(50));
                                break;
                            }
                        case 3:
                            {
                                Profile.Instance.MsgPrint("You are crushed between the floor and ceiling!");
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
                            Profile.Instance.MsgPrint($"{mName} wails out in pain!");
                            damage = sn != 0 ? Program.Rng.DiceRoll(4, 8) : 200;
                            mPtr.SleepLevel = 0;
                            mPtr.Health -= damage;
                            if (mPtr.Health < 0)
                            {
                                Profile.Instance.MsgPrint($"{mName} is embedded in the rock!");
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
                Profile.Instance.MsgPrint("The object resists the spell.");
                return;
            }
            Level.CaveSetFeat(Player.MapY, Player.MapX, "ElderSign");
        }

        public void ElderSignCreation()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem;
            Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectMakeElderSign(), flg);
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
                            Profile.Instance.MsgPrint("The curse is broken!");
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
                            Profile.Instance.MsgPrint("The curse is broken!");
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
                            Profile.Instance.MsgPrint("The curse is broken!");
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
                    Profile.Instance.MsgPrint("You have nothing to enchant.");
                }
                return false;
            }
            Item oPtr = item >= 0 ? Player.Inventory[item] : Level.Items[0 - item];
            string oName = oPtr.Description(false, 0);
            string your = item >= 0 ? "Your" : "The";
            string s = oPtr.Count > 1 ? "" : "s";
            Profile.Instance.MsgPrint($"{your} {oName} glow{s} brightly!");
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
                Profile.Instance.MsgPrint("The enchantment failed.");
            }
            return true;
        }

        public bool FearMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectTurnAll(), dir, plev, flg);
        }

        public bool FireBall(Projectile projectile, int dir, int dam, int rad)
        {
            TargetEngine targetEngine = new TargetEngine(Player, Level);
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
            return ProjectAtAllInLos(new ProjectOldSpeed(), Player.Level);
        }

        public bool HealMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldHeal(), dir, Program.Rng.DiceRoll(4, 6), flg);
        }

        public bool IdentifyFully()
        {
            if (!GetItem(out int item, "Identify which item? ", true, true, true))
            {
                if (item == -2)
                {
                    Profile.Instance.MsgPrint("You have nothing to identify.");
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
                Profile.Instance.MsgPrint($"{Player.DescribeWieldLocation(item)}: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    string itemName = oPtr.Description(true, 3);
                    Profile.Instance.MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else if (item >= 0)
            {
                Profile.Instance.MsgPrint($"In your pack: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    Profile.Instance.MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else
            {
                Profile.Instance.MsgPrint($"On the ground: {oName}.");
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
                    Profile.Instance.MsgPrint("You have nothing to identify.");
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
                Profile.Instance.MsgPrint($"{Player.DescribeWieldLocation(item)}: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    Profile.Instance.MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else if (item >= 0)
            {
                Profile.Instance.MsgPrint($"In your pack: {oName} ({item.IndexToLabel()}).");
                if (oPtr.Stompable())
                {
                    Profile.Instance.MsgPrint($"You destroy {oName}.");
                    int amount = oPtr.Count;
                    Player.Inventory.InvenItemIncrease(item, -amount);
                    Player.Inventory.InvenItemOptimize(item);
                }
            }
            else
            {
                Profile.Instance.MsgPrint($"On the ground: {oName}.");
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
                    Profile.Instance.MsgPrint($"You destroy {itemName}.");
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
                Profile.Instance.MsgPrint("You are surrounded by a white light.");
            }
            Project(0, rad, Player.MapY, Player.MapX, dam, new ProjectLightWeak(), flg);
            LightRoom(Player.MapY, Player.MapX);
            return true;
        }

        public void LightLine(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectLightWeak(), dir, Program.Rng.DiceRoll(6, 8), flg);
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
            ProjectAtAllInLos(new ProjectPsi(), dam);
        }

        public bool PolyMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldPoly(), dir, Player.Level, flg);
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
                rPtr = Profile.Instance.MonsterRaces[r];
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
                    dt = new ProjectOldSlow();
                    dam = 5;
                    angry = true;
                    break;

                case PotionType.Poison:
                    dt = new ProjectPois();
                    dam = 3;
                    angry = true;
                    break;

                case PotionType.Blindness:
                    dt = new ProjectDark();
                    angry = true;
                    break;

                case PotionType.Confusion:
                    dt = new ProjectOldConf();
                    angry = true;
                    break;

                case PotionType.Sleep:
                    dt = new ProjectOldSleep();
                    angry = true;
                    break;

                case PotionType.Ruination:
                case PotionType.Detonations:
                    dt = new ProjectExplode();
                    dam = Program.Rng.DiceRoll(25, 25);
                    angry = true;
                    break;

                case PotionType.Death:
                    dt = new ProjectDeathRay();
                    angry = true;
                    radius = 1;
                    break;

                case PotionType.Speed:
                    dt = new ProjectOldSpeed();
                    break;

                case PotionType.CureLight:
                    dt = new ProjectOldHeal();
                    dam = Program.Rng.DiceRoll(2, 3);
                    break;

                case PotionType.CureSerious:
                    dt = new ProjectOldHeal();
                    dam = Program.Rng.DiceRoll(4, 3);
                    break;

                case PotionType.CureCritical:
                case PotionType.Curing:
                    dt = new ProjectOldHeal();
                    dam = Program.Rng.DiceRoll(6, 3);
                    break;

                case PotionType.Healing:
                    dt = new ProjectOldHeal();
                    dam = Program.Rng.DiceRoll(10, 10);
                    break;

                case PotionType.StarHealing:
                case PotionType.Life:
                    dt = new ProjectOldHeal();
                    dam = Program.Rng.DiceRoll(50, 50);
                    radius = 1;
                    break;

                case PotionType.RestoreMana:
                    dt = new ProjectMana();
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
                        Profile.Instance.MsgPrint("Probing...");
                    }
                    string mName = mPtr.MonsterDesc(0x04);
                    Profile.Instance.MsgPrint($"{mName} has {mPtr.Health} hit points.");
                    Level.Monsters.LoreDoProbe(i);
                    probe = true;
                }
            }
            if (probe)
            {
                Profile.Instance.MsgPrint("That's all.");
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
                    Profile.Instance.MsgPrint("You have nothing to recharge.");
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
                    Profile.Instance.MsgPrint("The recharge backfires, draining the rod further!");
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
                    Profile.Instance.MsgPrint("There is a bright flash of light.");
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
            return TargetedProject(new ProjectOldSleep(), dir, Player.Level, flg);
        }

        public bool SleepMonsters()
        {
            return ProjectAtAllInLos(new ProjectOldSleep(), Player.Level);
        }

        public void SleepMonstersTouch()
        {
            ProjectionFlag flg = ProjectionFlag.ProjectKill | ProjectionFlag.ProjectHide;
            Project(0, 1, Player.MapY, Player.MapX, Player.Level, new ProjectOldSleep(), flg);
        }

        public bool SlowMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldSlow(), dir, Player.Level, flg);
        }

        public bool SlowMonsters()
        {
            return ProjectAtAllInLos(new ProjectOldSlow(), Player.Level);
        }

        public bool SpeedMonster(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectOldSpeed(), dir, Player.Level, flg);
        }

        public void StairCreation()
        {
            if (!Level.CaveValidBold(Player.MapY, Player.MapX))
            {
                Profile.Instance.MsgPrint("The object resists the spell.");
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
            TargetedProject(new ProjectStasis(), dir, Player.Level, flg);
        }

        public void StasisMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectStasis(), dam);
        }

        public void StunMonster(int dir, int plev)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectStun(), dir, plev, flg);
        }

        public void StunMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectStun(), dam);
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
            return TargetedProject(new ProjectAwayAll(), dir, Constants.MaxSight * 5, flg);
        }

        public void TeleportPlayer(int dis)
        {
            int x = Player.MapY, y = Player.MapX;
            int xx = -1;
            bool look = true;
            if (Player.HasAntiTeleport)
            {
                Profile.Instance.MsgPrint("A mysterious force prevents you from teleporting!");
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
            TargetEngine targetEngine = new TargetEngine(Player, Level);
            targetEngine.RecenterScreenAroundPlayer();
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            HandleStuff();
        }

        public void TeleportPlayerLevel()
        {
            if (Player.HasAntiTeleport)
            {
                Profile.Instance.MsgPrint("A mysterious force prevents you from teleporting!");
                return;
            }
            var downDesc = CurDungeon.Tower ? "You rise up through the ceiling." : "You sink through the floor.";
            var upDesc = CurDungeon.Tower ? "You sink through the floor." : "You rise up through the ceiling.";
            if (CurrentDepth <= 0)
            {
                Profile.Instance.MsgPrint(downDesc);
                IsAutosave = true;
                DoCmdSaveGame();
                IsAutosave = false;
                CurrentDepth++;
                NewLevelFlag = true;
            }
            else if (Quests.IsQuest(CurrentDepth) ||
                     CurrentDepth >= CurDungeon.MaxLevel)
            {
                Profile.Instance.MsgPrint(upDesc);
                IsAutosave = true;
                DoCmdSaveGame();
                IsAutosave = false;
                CurrentDepth--;
                NewLevelFlag = true;
            }
            else if (Program.Rng.RandomLessThan(100) < 50)
            {
                Profile.Instance.MsgPrint(upDesc);
                IsAutosave = true;
                DoCmdSaveGame();
                IsAutosave = false;
                CurrentDepth--;
                NewLevelFlag = true;
                CameFrom = LevelStart.StartRandom;
            }
            else
            {
                Profile.Instance.MsgPrint(downDesc);
                IsAutosave = true;
                DoCmdSaveGame();
                IsAutosave = false;
                CurrentDepth++;
                NewLevelFlag = true;
            }
            IsAutosave = true;
            DoCmdSaveGame();
            IsAutosave = false;
            CurrentDepth++;
            NewLevelFlag = true;
            Gui.PlaySound(SoundEffect.TeleportLevel);
        }

        public void TeleportPlayerTo(int ny, int nx)
        {
            int y, x, dis = 0, ctr = 0;
            if (Player.HasAntiTeleport)
            {
                Profile.Instance.MsgPrint("A mysterious force prevents you from teleporting!");
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
            TargetEngine targetEngine = new TargetEngine(Player, Level);
            targetEngine.RecenterScreenAroundPlayer();
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateDistances);
            HandleStuff();
        }

        public void TeleportSwap(int dir)
        {
            TargetEngine targetEngine = new TargetEngine(Player, Level);
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
                Profile.Instance.MsgPrint("You can't trade places with that!");
            }
            else
            {
                Monster mPtr = Level.Monsters[cPtr.MonsterIndex];
                MonsterRace rPtr = mPtr.Race;
                if ((rPtr.Flags3 & MonsterFlag3.ResistTeleport) != 0)
                {
                    Profile.Instance.MsgPrint("Your teleportation is blocked!");
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
            return Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectMakeTrap(), flg);
        }

        public void TurnEvil(int dam)
        {
            ProjectAtAllInLos(new ProjectTurnEvil(), dam);
        }

        public void TurnMonsters(int dam)
        {
            ProjectAtAllInLos(new ProjectTurnAll(), dam);
        }

        public bool UnlightArea(int dam, int rad)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectKill;
            if (Player.TimedBlindness == 0)
            {
                Profile.Instance.MsgPrint("Darkness surrounds you.");
            }
            Project(0, rad, Player.MapY, Player.MapX, dam, new ProjectDarkWeak(), flg);
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
            _ = Project(0, 1, Player.MapY, Player.MapX, 0, new ProjectStoneWall(), flg);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight | UpdateFlags.UpdateScent);
            Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            Player.RedrawNeeded.Set(RedrawFlag.PrMap);
        }

        public bool WallToMud(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            return TargetedProject(new ProjectKillWall(), dir, 20 + Program.Rng.DieRoll(30), flg);
        }

        public void WizardLock(int dir)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectBeam | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            TargetedProject(new ProjectJamDoor(), dir, 20 + Program.Rng.DieRoll(30), flg);
        }

        public void YellowSign()
        {
            if (!Level.GridOpenNoItem(Player.MapY, Player.MapX))
            {
                Profile.Instance.MsgPrint("The object resists the spell.");
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
                            Profile.Instance.MsgPrint($"{mName} wakes up.");
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
                Profile.Instance.MsgPrint("You sense the presence of monsters!");
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
                Profile.Instance.MsgPrint($"Your {oName} is unaffected!");
                return true;
            }
            Profile.Instance.MsgPrint($"Your {oName} is damaged!");
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
            TargetEngine targetEngine = new TargetEngine(Player, Level);
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
        public void ProcessCommand(Player player, Level level, bool isRepeated)
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
                    command.Execute(player, level);

                    // Apply the default repeat value.  This handles the 0, for no repeat and default repeat count (TBDocs+ ... count = 99).
                    if (!isRepeated && command.Repeat.HasValue)
                    {
                        // Only apply the default once.
                        Gui.CommandArgument = command.Repeat.Value;
                    }

                    if (Gui.CommandArgument > 0)
                    {
                        CommandRepeat = Gui.CommandArgument - 1;
                        player.RedrawNeeded.Set(RedrawFlag.PrState);
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
                if (!alive || player.IsDead || SaveGame.Instance.NewLevelFlag)
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
                        Profile.Instance.MsgPrint($"{monsterName} is repelled.");
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
                        Profile.Instance.MsgPrint($"{monsterName} {act}");
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
                                        Profile.Instance.MsgPrint("Hagarg Ryonis's favour protects you!");
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
                                        Profile.Instance.MsgPrint("Energy drains from your pack!");
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
                                    Profile.Instance.MsgPrint("You quickly protect your money pouch!");
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
                                        Profile.Instance.MsgPrint("Nothing was stolen.");
                                    }
                                    else if (player.Gold != 0)
                                    {
                                        Profile.Instance.MsgPrint("Your purse feels lighter.");
                                        Profile.Instance.MsgPrint($"{gold} coins were stolen!");
                                    }
                                    else
                                    {
                                        Profile.Instance.MsgPrint("Your purse feels lighter.");
                                        Profile.Instance.MsgPrint("All of your coins were stolen!");
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
                                    Profile.Instance.MsgPrint("You grab hold of your backpack!");
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
                                    Profile.Instance.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was stolen!");
                                    int nextObjectIndex = Level.OPop();
                                    if (nextObjectIndex != 0)
                                    {
                                        // Give the item to the thief so it can later drop it
                                        Item stolenItem = new Item(item);
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
                                    Profile.Instance.MsgPrint($"{y}our {itemName} ({i.IndexToLabel()}) was eaten!");
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
                                        Profile.Instance.MsgPrint("Your light dims.");
                                        obvious = true;
                                    }
                                }
                                break;
                            }
                        case AttackEffect.Acid:
                            {
                                obvious = true;
                                Profile.Instance.MsgPrint("You are covered in acid!");
                                AcidDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsAcid);
                                break;
                            }
                        case AttackEffect.Electricity:
                            {
                                obvious = true;
                                Profile.Instance.MsgPrint("You are struck by electricity!");
                                ElecDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsElec);
                                break;
                            }
                        case AttackEffect.Fire:
                            {
                                obvious = true;
                                Profile.Instance.MsgPrint("You are enveloped in flames!");
                                FireDam(damage, monsterDescription);
                                level.Monsters.UpdateSmartLearn(monsterIndex, Constants.DrsFire);
                                break;
                            }
                        case AttackEffect.Cold:
                            {
                                obvious = true;
                                Profile.Instance.MsgPrint("You are covered with frost!");
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
                                    Profile.Instance.MsgPrint("You stand your ground!");
                                    obvious = true;
                                }
                                else if (Program.Rng.RandomLessThan(100) < player.SkillSavingThrow)
                                {
                                    Profile.Instance.MsgPrint("You stand your ground!");
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
                                    Profile.Instance.MsgPrint("You are unaffected!");
                                    obvious = true;
                                }
                                else if (Program.Rng.RandomLessThan(100) < player.SkillSavingThrow)
                                {
                                    Profile.Instance.MsgPrint("You resist the effects!");
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
                                    Profile.Instance.MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    Profile.Instance.MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(10, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        Profile.Instance.MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        Profile.Instance.MsgPrint("You feel your life draining away!");
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
                                    Profile.Instance.MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    Profile.Instance.MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(20, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        Profile.Instance.MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        Profile.Instance.MsgPrint("You feel your life draining away!");
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
                                    Profile.Instance.MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    Profile.Instance.MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(40, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        Profile.Instance.MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        Profile.Instance.MsgPrint("You feel your life draining away!");
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
                                    Profile.Instance.MsgPrint("You keep hold of your life force!");
                                }
                                else if (Program.Rng.DieRoll(10) <= player.Religion.GetNamedDeity(Pantheon.GodName.Hagarg_Ryonis).AdjustedFavour)
                                {
                                    // Hagarg Ryonis can protect us from experience loss
                                    Profile.Instance.MsgPrint("Hagarg Ryonis's favour protects you!");
                                }
                                else
                                {
                                    int d = Program.Rng.DiceRoll(80, 6) + (player.ExperiencePoints / 100 * Constants.MonDrainLife);
                                    if (player.HasHoldLife)
                                    {
                                        Profile.Instance.MsgPrint("You feel your life slipping away!");
                                        player.LoseExperience(d / 10);
                                    }
                                    else
                                    {
                                        Profile.Instance.MsgPrint("You feel your life draining away!");
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
                                Profile.Instance.MsgPrint($"{monsterName} is suddenly very hot!");
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
                                Profile.Instance.MsgPrint($"{monsterName} gets zapped!");
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
                                Profile.Instance.MsgPrint($"{monsterName} misses you.");
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
                Profile.Instance.MsgPrint("The thief flees laughing!");
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
                Profile.Instance.MsgPrint($"{monsterName} flees in terror!");
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
    }
}