using Cthangband.ActivationPowers;
using Cthangband.Enumerations;
using Cthangband.Projection;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    [Serializable]
    internal class WizardCommand : ICommand
    {
        public char Key => 'W';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        private const int _testRoll = 100000;
        private readonly char[] _head = { 'a', 'A', '0' };

        public void Execute(SaveGame saveGame)
        {
            if (saveGame.Player.IsWizard)
            {
                DoCmdWizard(saveGame);
            }
            else
            {
                DoCmdWizmode(saveGame);
            }
        }

        public void DoCmdWizard(SaveGame saveGame)
        {
            Gui.GetCom("Wizard Command: ", out char cmd);
            switch (cmd)
            {
                case '\x1b':
                case ' ':
                case '\n':
                case '\r':
                    break;

                case '"':
                    //todo: doCmdSpoilers();
                    break;

                case '?':
                    DoCmdWizHelp();
                    break;

                case 'A':
                    DoCmdWizActivatePower(saveGame);
                    break;

                case 'a':
                    DoCmdWizCureAll(saveGame);
                    break;

                case 'b':
                    DoCmdWizBamf(saveGame);
                    break;

                case 'c':
                    WizCreateItem(saveGame);
                    break;

                case 'C':
                    WizCreateNamedArt(saveGame, (FixedArtifactId)Gui.CommandArgument);
                    break;

                case 'd':
                    saveGame.DetectAll();
                    break;

                case 'e':
                    DoCmdWizChange(saveGame);
                    break;

                case 'f':
                    saveGame.IdentifyFully();
                    break;

                case 'g':
                    if (Gui.CommandArgument <= 0)
                    {
                        Gui.CommandArgument = 1;
                    }
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Gui.CommandArgument, false);
                    break;

                case 'h':
                    saveGame.Player.RerollHitPoints();
                    break;

                case 'H':
                    DoCmdSummonHorde(saveGame);
                    break;

                case 'i':
                    saveGame.IdentifyPack();
                    break;

                case 'j':
                    DoCmdWizJump(saveGame);
                    break;

                case 'k':
                    saveGame.SelfKnowledge();
                    break;

                case 'l':
                    DoCmdWizLearn(saveGame);
                    break;

                case 'm':
                    saveGame.Level.MapArea();
                    break;

                case 'M':
                    saveGame.Player.Dna.GainMutation(saveGame);
                    break;

                case 'r':
                    saveGame.Player.GainLevelReward();
                    break;

                case 'N':
                    DoCmdWizNamedFriendly(saveGame, Gui.CommandArgument, true);
                    break;

                case 'n':
                    DoCmdWizNamed(saveGame, Gui.CommandArgument, true);
                    break;

                case 'o':
                    DoCmdWizPlay(saveGame);
                    break;

                case 'p':
                    saveGame.TeleportPlayer(10);
                    break;

                case 's':
                    if (Gui.CommandArgument <= 0)
                    {
                        Gui.CommandArgument = 1;
                    }
                    DoCmdWizSummon(saveGame, Gui.CommandArgument);
                    break;

                case 't':
                    saveGame.TeleportPlayer(100);
                    break;

                case 'v':
                    if (Gui.CommandArgument <= 0)
                    {
                        Gui.CommandArgument = 1;
                    }
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Gui.CommandArgument, true);
                    break;

                case 'w':
                    saveGame.Level.WizLight();
                    break;

                case 'W':
                    saveGame.Player.IsWinner = true;
                    saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrTitle);
                    saveGame.MsgPrint("*** CONGRATULATIONS ***");
                    saveGame.MsgPrint("You have won the game!");
                    saveGame.MsgPrint("You may retire ('Q') when you are ready.");
                    break;

                case 'x':
                    if (Gui.CommandArgument != 0)
                    {
                        saveGame.Player.GainExperience(Gui.CommandArgument);
                    }
                    else
                    {
                        saveGame.Player.GainExperience(saveGame.Player.ExperiencePoints + 1);
                    }
                    break;

                case 'Z':
                    DoCmdWizZap(saveGame);
                    break;

                case 'z':
                    {
                        DoCmdWizardBolt(saveGame);
                        break;
                    }
                default:
                    saveGame.MsgPrint("That is not a valid wizard command.");
                    break;
            }
        }

        public void DoCmdWizmode(SaveGame saveGame)
        {
            Gui.PrintLine("Enter Wizard Code: ", 0, 0);
            if (!Gui.AskforAux(out string tmp, "", 31))
            {
                return;
            }
            Gui.Erase(0, 0, 255);
            if (tmp == "Dumbledore")
            {
                saveGame.Player.IsWizard = true;
                saveGame.MsgPrint("Wizard mode activated.");
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrTitle);
            }
        }

        private void DoCmdWizActivatePower(SaveGame saveGame)
        {
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Gui.SetBackground(BackgroundImage.Normal);

            Gui.Clear();
            int index = 0;
            foreach (IActivationPower activationPower in ActivationPowerManager.ActivationPowers)
            {
                int row = 2 + (index % 40);
                int col = 30 * (index / 40);
                Gui.PrintLine($"{index + 1}. {activationPower.Name}", row, col);
                index++;
            }
            if (!Gui.GetString("Activation power?", out string selection, "", 3))
            {
                return;
            }

            Gui.Load();
            Gui.FullScreenOverlay = false;
            Gui.SetBackground(BackgroundImage.Overhead);

            if (!Int32.TryParse(selection, out int selectedIndex))
            {
                return;
            }
            selectedIndex--;
            if (selectedIndex < 0 || selectedIndex > ActivationPowerManager.ActivationPowers.Length)
            {
                return;
            }

            ActivationPowerManager.ActivationPowers[selectedIndex].Activate(saveGame);
        }

        private void DoCmdRedraw(SaveGame saveGame)
        {
            saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses | UpdateFlags.UpdateHealth | UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateRemoveView | UpdateFlags.UpdateRemoveLight);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrWipe | RedrawFlag.PrBasic | RedrawFlag.PrExtra | RedrawFlag.PrMap |
                              RedrawFlag.PrEquippy);
            saveGame.HandleStuff();
            Gui.Redraw();
        }

        private void DoCmdSummonHorde(SaveGame saveGame)
        {
            int wy = saveGame.Player.MapY, wx = saveGame.Player.MapX;
            int attempts = 1000;
            while (--attempts != 0)
            {
                saveGame.Level.Scatter(out wy, out wx, saveGame.Player.MapY, saveGame.Player.MapX, 3);
                if (saveGame.Level.GridOpenNoItemOrCreature(wy, wx))
                {
                    break;
                }
            }
            saveGame.Level.Monsters.AllocHorde(wy, wx);
        }

        private void DoCmdWizardBolt(SaveGame saveGame)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            TargetEngine targetEngine = new TargetEngine(saveGame);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            int tx = saveGame.Player.MapX + (99 * saveGame.Level.KeypadDirectionXOffset[dir]);
            int ty = saveGame.Player.MapY + (99 * saveGame.Level.KeypadDirectionYOffset[dir]);
            if (dir == 5 && targetEngine.TargetOkay())
            {
                flg &= ~ProjectionFlag.ProjectStop;
                tx = saveGame.TargetCol;
                ty = saveGame.TargetRow;
            }
            saveGame.Project(0, 0, ty, tx, 1000000, new ProjectWizardBolt(saveGame), flg);
        }

        private void DoCmdWizBamf(SaveGame saveGame)
        {
            if (saveGame.TargetWho == 0)
            {
                return;
            }
            saveGame.TeleportPlayerTo(saveGame.TargetRow, saveGame.TargetCol);
        }

        private void DoCmdWizChange(SaveGame saveGame)
        {
            DoCmdWizChangeAux(saveGame);
            DoCmdRedraw(saveGame);
        }

        private void DoCmdWizChangeAux(SaveGame saveGame)
        {
            string tmpVal;
            int tmpInt;
            for (int i = 0; i < 6; i++)
            {
                string ppp = $"{GlobalData.StatNames[i]} (3-118): ";
                if (!Gui.GetString(ppp, out tmpVal, $"{saveGame.Player.AbilityScores[i].InnateMax}", 3))
                {
                    return;
                }
                if (!int.TryParse(tmpVal, out tmpInt))
                {
                    tmpInt = 0;
                }
                if (tmpInt > 18 + 100)
                {
                    tmpInt = 18 + 100;
                }
                else if (tmpInt < 3)
                {
                    tmpInt = 3;
                }
                saveGame.Player.AbilityScores[i].Innate = tmpInt;
                saveGame.Player.AbilityScores[i].InnateMax = tmpInt;
            }
            string def = $"{saveGame.Player.Gold}";
            if (!Gui.GetString("Gold: ", out tmpVal, def, 9))
            {
                return;
            }
            if (!int.TryParse(tmpVal, out tmpInt))
            {
                tmpInt = 0;
            }
            if (tmpInt < 0)
            {
                tmpInt = 0;
            }
            saveGame.Player.Gold = tmpInt;
            def = $"{saveGame.Player.MaxExperienceGained}";
            if (!Gui.GetString("Experience: ", out tmpVal, def, 9))
            {
                return;
            }
            if (!int.TryParse(tmpVal, out tmpInt))
            {
                tmpInt = 0;
            }
            if (tmpInt < 0)
            {
                tmpInt = 0;
            }
            saveGame.Player.MaxExperienceGained = tmpInt;
            saveGame.Player.CheckExperience();
        }

        private void DoCmdWizCureAll(SaveGame saveGame)
        {
            saveGame.RemoveAllCurse();
            saveGame.Player.RestoreAbilityScore(Ability.Strength);
            saveGame.Player.RestoreAbilityScore(Ability.Intelligence);
            saveGame.Player.RestoreAbilityScore(Ability.Wisdom);
            saveGame.Player.RestoreAbilityScore(Ability.Constitution);
            saveGame.Player.RestoreAbilityScore(Ability.Dexterity);
            saveGame.Player.RestoreAbilityScore(Ability.Charisma);
            saveGame.Player.RestoreLevel();
            saveGame.Player.Health = saveGame.Player.MaxHealth;
            saveGame.Player.FractionalHealth = 0;
            saveGame.Player.Mana = saveGame.Player.MaxMana;
            saveGame.Player.FractionalMana = 0;
            saveGame.Player.SetTimedBlindness(0);
            saveGame.Player.SetTimedConfusion(0);
            saveGame.Player.SetTimedPoison(0);
            saveGame.Player.SetTimedFear(0);
            saveGame.Player.SetTimedParalysis(0);
            saveGame.Player.SetTimedHallucinations(0);
            saveGame.Player.SetTimedStun(0);
            saveGame.Player.SetTimedBleeding(0);
            saveGame.Player.SetTimedSlow(0);
            saveGame.Player.SetFood(Constants.PyFoodMax - 1);
            DoCmdRedraw(saveGame);
        }

        private void DoCmdWizHelp()
        {
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Gui.Refresh();
            Gui.Clear();
            Gui.SetBackground(BackgroundImage.Normal);
            Gui.Print(Colour.Red, "Wizard Commands", 1, 31);
            Gui.Print(Colour.Red, "===============", 2, 31);
            Gui.Print(Colour.Red, "Character Editing", 4, 1);
            Gui.Print(Colour.Red, "=================", 5, 1);
            Gui.Print("a = Cure All", 7, 1);
            Gui.Print("e = Edit Stats", 8, 1);
            Gui.Print("h = Reroll Hitpoints", 9, 1);
            Gui.Print("k = Self Knowledge", 10, 1);
            Gui.Print("M = Gain Mutation", 11, 1);
            Gui.Print("r = Gain Level Reward", 12, 1);
            Gui.Print("x = Gain Experience", 13, 1);
            Gui.Print(Colour.Red, "Movement", 15, 1);
            Gui.Print(Colour.Red, "========", 16, 1);
            Gui.Print("b = Teleport to Target", 18, 1);
            Gui.Print("j = Jump Levels", 19, 1);
            Gui.Print("p = Phase Door", 20, 1);
            Gui.Print("t = Teleport", 21, 1);
            Gui.Print(Colour.Red, "Monsters", 4, 26);
            Gui.Print(Colour.Red, "========", 5, 26);
            Gui.Print("s = Summon Monster", 7, 26);
            Gui.Print("n = Summon Named Monster", 8, 26);
            Gui.Print("N = Summon Named Pet", 9, 26);
            Gui.Print("H = Summon Horde", 10, 26);
            Gui.Print("Z = Carnage True", 11, 26);
            Gui.Print("z = Zap (Wizard Bolt)", 12, 26);
            Gui.Print(Colour.Red, "General Commands", 14, 26);
            Gui.Print(Colour.Red, "================", 15, 26);
            Gui.Print("\" = Generate spoilers", 17, 26);
            Gui.Print("d = Detect All", 18, 26);
            Gui.Print("m = Map Area", 19, 26);
            Gui.Print("w = Wizard Light", 20, 26);
            Gui.Print(Colour.Red, "Object Commands", 4, 51);
            Gui.Print(Colour.Red, "===============", 5, 51);
            Gui.Print("c = Create Item", 7, 51);
            Gui.Print("C = Create Named artifact", 8, 51);
            Gui.Print("f = Identify Fully", 9, 51);
            Gui.Print("g = Generate Good Object", 10, 51);
            Gui.Print("i = Identify Pack", 11, 51);
            Gui.Print("l = Learn About Objects", 12, 51);
            Gui.Print("o = Object Editor", 13, 51);
            Gui.Print("v = Generate Very Good Object", 14, 51);
            Gui.Print("Hit any key to continue", 43, 23);
            Gui.Inkey();
            Gui.Load();
            Gui.SetBackground(BackgroundImage.Overhead);
            Gui.FullScreenOverlay = false;
        }

        private void DoCmdWizJump(SaveGame saveGame)
        {
            if (Gui.CommandArgument <= 0)
            {
                string ppp = $"Jump to level (0-{saveGame.CurDungeon.MaxLevel}): ";
                string def = $"{saveGame.CurrentDepth}";
                if (!Gui.GetString(ppp, out string tmpVal, def, 10))
                {
                    return;
                }
                Gui.CommandArgument = int.TryParse(tmpVal, out int i) ? i : 0;
            }
            if (Gui.CommandArgument < 1)
            {
                Gui.CommandArgument = 1;
            }
            if (Gui.CommandArgument > saveGame.CurDungeon.MaxLevel)
            {
                Gui.CommandArgument = saveGame.CurDungeon.MaxLevel;
            }
            saveGame.MsgPrint($"You jump to dungeon level {Gui.CommandArgument}.");
            saveGame.DoCmdSaveGame(true);
            saveGame.CurrentDepth = Gui.CommandArgument;
            saveGame.NewLevelFlag = true;
        }

        private void DoCmdWizLearn(SaveGame saveGame)
        {
            for (int i = 1; i < saveGame.ItemTypes.Count; i++)
            {
                ItemType kPtr = saveGame.ItemTypes[i];
                if (kPtr.Level <= Gui.CommandArgument)
                {
                    kPtr.FlavourAware = true;
                }
            }
        }

        private void DoCmdWizNamed(SaveGame saveGame, int rIdx, bool slp)
        {
            if (rIdx >= saveGame.MonsterRaces.Count - 1)
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                const int d = 1;
                saveGame.Level.Scatter(out int y, out int x, saveGame.Player.MapY, saveGame.Player.MapX, d);
                if (!saveGame.Level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (saveGame.Level.Monsters.PlaceMonsterByIndex(y, x, rIdx, slp, true, false))
                {
                    break;
                }
            }
        }

        private void DoCmdWizNamedFriendly(SaveGame saveGame, int rIdx, bool slp)
        {
            if (rIdx >= saveGame.MonsterRaces.Count - 1)
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                const int d = 1;
                saveGame.Level.Scatter(out int y, out int x, saveGame.Player.MapY, saveGame.Player.MapX, d);
                if (!saveGame.Level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (saveGame.Level.Monsters.PlaceMonsterByIndex(y, x, rIdx, slp, true, true))
                {
                    break;
                }
            }
        }

        private void DoCmdWizPlay(SaveGame saveGame)
        {
            if (!saveGame.GetItem(out int item, "Play with which object? ", true, true, true))
            {
                if (item == -2)
                {
                    saveGame.MsgPrint("You have nothing to play with.");
                }
                return;
            }
            Item oPtr = item >= 0 ? saveGame.Player.Inventory[item] : saveGame.Level.Items[0 - item];
            bool changed;
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Item qPtr = new Item(saveGame, oPtr);
            while (true)
            {
                WizDisplayItem(qPtr);
                if (!Gui.GetCom("[a]ccept [s]tatistics [r]eroll [t]weak [q]uantity? ", out char ch))
                {
                    changed = false;
                    break;
                }
                if (ch == 'A' || ch == 'a')
                {
                    changed = true;
                    break;
                }
                if (ch == 's' || ch == 'S')
                {
                    WizStatistics(saveGame, qPtr);
                }
                if (ch == 'r' || ch == 'r')
                {
                    qPtr = WizRerollItem(saveGame, qPtr);
                }
                if (ch == 't' || ch == 'T')
                {
                    WizTweakItem(qPtr);
                }
                if (ch == 'q' || ch == 'Q')
                {
                    WizQuantityItem(qPtr);
                }
            }
            Gui.Load();
            Gui.FullScreenOverlay = false;
            if (changed)
            {
                saveGame.MsgPrint("Changes accepted.");
                if (item >= 0)
                {
                    saveGame.Player.Inventory[item] = qPtr;
                }
                else
                {
                    saveGame.Level.Items[0 - item] = qPtr;
                }
                saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            }
            else
            {
                saveGame.MsgPrint("Changes ignored.");
            }
        }

        private void DoCmdWizSummon(SaveGame saveGame, int num)
        {
            for (int i = 0; i < num; i++)
            {
                saveGame.Level.Monsters.SummonSpecific(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.Difficulty, 0);
            }
        }

        private void DoCmdWizZap(SaveGame saveGame)
        {
            for (int i = 1; i < saveGame.Level.MMax; i++)
            {
                Monster mPtr = saveGame.Level.Monsters[i];
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (mPtr.DistanceFromPlayer <= Constants.MaxSight)
                {
                    saveGame.Level.Monsters.DeleteMonsterByIndex(i, true);
                }
            }
        }

        private void PrtBinary(FlagSet flags, int row, int col)
        {
            uint bitmask = 1u;
            for (int i = 1; i <= 32; i++)
            {
                if (flags.IsSet(bitmask))
                {
                    Gui.Print(Colour.Blue, '*', row, col++);
                }
                else
                {
                    Gui.Print(Colour.White, '-', row, col++);
                }
                bitmask *= 2;
            }
        }

        private string StripName(SaveGame saveGame, int kIdx)
        {
            ItemType kPtr = saveGame.ItemTypes[kIdx];
            return kPtr.Name.Trim().Replace("$", "").Replace("~", "");
        }

        private void WizCreateItem(SaveGame saveGame)
        {
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Gui.SetBackground(BackgroundImage.Normal);
            int kIdx = WizCreateItemtype(saveGame);
            Gui.Load();
            Gui.FullScreenOverlay = false;
            Gui.SetBackground(BackgroundImage.Overhead);
            if (kIdx == 0)
            {
                return;
            }
            Item qPtr = new Item(saveGame);
            qPtr.AssignItemType(saveGame.ItemTypes[kIdx]);
            qPtr.ApplyMagic(saveGame.Difficulty, false, false, false);
            saveGame.Level.DropNear(qPtr, -1, saveGame.Player.MapY, saveGame.Player.MapX);
            saveGame.MsgPrint("Allocated.");
        }

        private int WizCreateItemtype(SaveGame saveGame)
        {
            int i, num;
            int col, row;
            char ch;
            int[] choice = new int[60];
            Gui.Clear();
            for (num = 0; num < 60 && TvalDescriptionPair.Tvals[num].Tval != 0; num++)
            {
                row = 2 + (num % 20);
                col = 30 * (num / 20);
                ch = (char)(_head[num / 20] + (char)(num % 20));
                Gui.PrintLine($"[{ch}] {TvalDescriptionPair.Tvals[num].Desc}", row, col);
            }
            int maxNum = num;
            if (!Gui.GetCom("Get what type of object? ", out ch))
            {
                return 0;
            }
            num = -1;
            if (ch >= _head[0] && ch < _head[0] + 20)
            {
                num = ch - _head[0];
            }
            if (ch >= _head[1] && ch < _head[1] + 20)
            {
                num = ch - _head[1] + 20;
            }
            if (ch >= _head[2] && ch < _head[2] + 10)
            {
                num = ch - _head[2] + 40;
            }
            if (num < 0 || num >= maxNum)
            {
                return 0;
            }
            ItemCategory tval = TvalDescriptionPair.Tvals[num].Tval;
            string tvalDesc = TvalDescriptionPair.Tvals[num].Desc;
            Gui.Clear();
            for (num = 0, i = 1; num < 60 && i < saveGame.ItemTypes.Count; i++)
            {
                ItemType kPtr = saveGame.ItemTypes[i];
                if (kPtr.Category == tval)
                {
                    //if (kPtr.Flags3.IsSet(ItemFlag3.InstaArt))
                    //{
                    //    continue;
                    //}
                    row = 2 + (num % 20);
                    col = 30 * (num / 20);
                    ch = (char)(_head[num / 20] + (char)(num % 20));
                    string buf = StripName(saveGame, i);
                    Gui.PrintLine($"[{ch}] {buf}", row, col);
                    choice[num++] = i;
                }
            }
            maxNum = num;
            if (!Gui.GetCom($"What Kind of {tvalDesc}? ", out ch))
            {
                return 0;
            }
            num = -1;
            if (ch >= _head[0] && ch < _head[0] + 20)
            {
                num = ch - _head[0];
            }
            if (ch >= _head[1] && ch < _head[1] + 20)
            {
                num = ch - _head[1] + 20;
            }
            if (ch >= _head[2] && ch < _head[2] + 10)
            {
                num = ch - _head[2] + 40;
            }
            if (num < 0 || num >= maxNum)
            {
                return 0;
            }
            return choice[num];
        }

        private void WizCreateNamedArt(SaveGame saveGame, FixedArtifactId aIdx)
        {
            if (aIdx == FixedArtifactId.None)
            {
                return;
            }
            FixedArtifact aPtr = saveGame.FixedArtifacts[aIdx];
            Item qPtr = new Item(saveGame);
            if (string.IsNullOrEmpty(aPtr.Name))
            {
                return;
            }
            ItemType i = saveGame.ItemTypes.LookupKind(aPtr.Tval, aPtr.Sval);
            if (i == null)
            {
                return;
            }
            qPtr.AssignItemType(i);
            qPtr.FixedArtifactIndex = aIdx;
            qPtr.TypeSpecificValue = aPtr.Pval;
            qPtr.BaseArmourClass = aPtr.Ac;
            qPtr.DamageDice = aPtr.Dd;
            qPtr.DamageDiceSides = aPtr.Ds;
            qPtr.BonusArmourClass = aPtr.ToA;
            qPtr.BonusToHit = aPtr.ToH;
            qPtr.BonusDamage = aPtr.ToD;
            qPtr.Weight = aPtr.Weight;
            if (aPtr.Flags3.IsSet(ItemFlag3.Cursed))
            {
                qPtr.IdentifyFlags.Set(Constants.IdentCursed);
            }
            qPtr.GetFixedArtifactResistances();
            saveGame.Level.DropNear(qPtr, -1, saveGame.Player.MapY, saveGame.Player.MapX);
            saveGame.MsgPrint("Allocated.");
        }

        private void WizDisplayItem(Item oPtr)
        {
            const int j = 13;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            oPtr.GetMergedFlags(f1, f2, f3);
            for (int i = 1; i <= 23; i++)
            {
                Gui.PrintLine("", i, j - 2);
            }
            string buf = oPtr.StoreDescription(true, 3);
            Gui.PrintLine(buf, 2, j);
            Gui.PrintLine(
                $"kind = {oPtr.ItemType,5}  level = {oPtr.ItemType.Level,4}  ItemType = {oPtr.Category,5}  ItemSubType = {oPtr.ItemSubCategory,5}",
                4, j);
            Gui.PrintLine(
                $"number = {oPtr.Count,3}  wgt = {oPtr.Weight,6}  BaseArmourClass = {oPtr.BaseArmourClass,5}    damage = {oPtr.DamageDice}d{oPtr.DamageDiceSides}",
                5, j);
            Gui.PrintLine(
                $"TypeSpecificValue = {oPtr.TypeSpecificValue,5}  toac = {oPtr.BonusArmourClass,5}  tohit = {oPtr.BonusToHit,4}  todam = {oPtr.BonusDamage,4}",
                6, j);
            Gui.PrintLine(
                $"FixedArtifactIndex = {oPtr.FixedArtifactIndex,4}  name2 = {oPtr.RareItemTypeIndex,4}  cost = {oPtr.Value()}",
                7, j);
            Gui.PrintLine($"IdentifyFlags = {oPtr.IdentifyFlags:x4}  timeout = {oPtr.RechargeTimeLeft}", 8, j);
            Gui.PrintLine("+------------FLAGS1------------+", 10, j);
            Gui.PrintLine("AFFECT........SLAY........BRAND.", 11, j);
            Gui.PrintLine("              cvae      xsqpaefc", 12, j);
            Gui.PrintLine("siwdcc  ssidsahanvudotgddhuoclio", 13, j);
            Gui.PrintLine("tnieoh  trnipttmiinmrrnrrraiierl", 14, j);
            Gui.PrintLine("rtsxna..lcfgdkcpmldncltggpksdced", 15, j);
            PrtBinary(f1, 16, j);
            Gui.PrintLine("+------------FLAGS2------------+", 17, j);
            Gui.PrintLine("SUST....IMMUN.RESIST............", 18, j);
            Gui.PrintLine("        aefcprpsaefcpfldbc sn   ", 19, j);
            Gui.PrintLine("siwdcc  cliooeatcliooeialoshtncd", 20, j);
            Gui.PrintLine("tnieoh  ierlifraierliatrnnnrhehi", 21, j);
            Gui.PrintLine("rtsxna..dcedslatdcedsrekdfddrxss", 22, j);
            PrtBinary(f2, 23, j);
            Gui.PrintLine("+------------FLAGS3------------+", 10, j + 32);
            Gui.PrintLine("fe      ehsi  st    iiiiadta  hp", 11, j + 32);
            Gui.PrintLine("il   n taihnf ee    ggggcregb vr", 12, j + 32);
            Gui.PrintLine("re  nowysdose eld   nnnntalrl ym", 13, j + 32);
            Gui.PrintLine("ec  omrcyewta ieirmsrrrriieaeccc", 14, j + 32);
            Gui.PrintLine("aa  taauktmatlnpgeihaefcvnpvsuuu", 15, j + 32);
            Gui.PrintLine("uu  egirnyoahivaeggoclioaeoasrrr", 16, j + 32);
            Gui.PrintLine("rr  litsopdretitsehtierltxrtesss", 17, j + 32);
            Gui.PrintLine("aa  echewestreshtntsdcedeptedeee", 18, j + 32);
            PrtBinary(f3, 19, j + 32);
        }

        private void WizQuantityItem(Item oPtr)
        {
            if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
            {
                return;
            }
            string def = $"{oPtr.Count}";
            if (Gui.GetString("Quantity: ", out string tmpVal, def, 2))
            {
                if (!int.TryParse(tmpVal, out int tmpInt))
                {
                    tmpInt = 1;
                }
                if (tmpInt < 1)
                {
                    tmpInt = 1;
                }
                if (tmpInt > 99)
                {
                    tmpInt = 99;
                }
                oPtr.Count = tmpInt;
            }
        }

        private Item WizRerollItem(SaveGame saveGame, Item oPtr)
        {
            bool changed;
            if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
            {
                return oPtr;
            }
            Item qPtr = new Item(saveGame, oPtr);
            while (true)
            {
                WizDisplayItem(qPtr);
                if (!Gui.GetCom("[a]ccept, [n]ormal, [g]ood, [e]xcellent? ", out char ch))
                {
                    changed = false;
                    break;
                }
                if (ch == 'A' || ch == 'a')
                {
                    changed = true;
                    break;
                }
                if (ch == 'n' || ch == 'N')
                {
                    qPtr.AssignItemType(oPtr.ItemType);
                    qPtr.ApplyMagic(saveGame.Difficulty, false, false, false);
                }
                else if (ch == 'g' || ch == 'g')
                {
                    qPtr.AssignItemType(oPtr.ItemType);
                    qPtr.ApplyMagic(saveGame.Difficulty, false, true, false);
                }
                else if (ch == 'e' || ch == 'e')
                {
                    qPtr.AssignItemType(oPtr.ItemType);
                    qPtr.ApplyMagic(saveGame.Difficulty, false, true, true);
                }
            }
            if (changed)
            {
                saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                saveGame.Player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
                return qPtr;
            }
            return oPtr;
        }

        private void WizStatistics(SaveGame saveGame, Item oPtr)
        {
            const string q = "Rolls: {0}, Matches: {1}, Better: {2}, Worse: {3}, Other: {4}";
            if (oPtr.IsFixedArtifact())
            {
                saveGame.FixedArtifacts[oPtr.FixedArtifactIndex].CurNum = 0;
            }
            while (true)
            {
                const string pmt = "Roll for [n]ormal, [g]ood, or [e]xcellent treasure? ";
                WizDisplayItem(oPtr);
                if (!Gui.GetCom(pmt, out char ch))
                {
                    break;
                }
                string quality;
                bool good;
                bool great;
                if (ch == 'n' || ch == 'N')
                {
                    good = false;
                    great = false;
                    quality = "normal";
                }
                else if (ch == 'g' || ch == 'G')
                {
                    good = true;
                    great = false;
                    quality = "good";
                }
                else if (ch == 'e' || ch == 'E')
                {
                    good = true;
                    great = true;
                    quality = "excellent";
                }
                else
                {
                    break;
                }
                saveGame.MsgPrint(
                    $"Creating a lot of {quality} items. Base level = {saveGame.Difficulty}.");
                saveGame.MsgPrint(null);
                long better;
                long worse;
                long other;
                long matches = better = worse = other = 0;
                long i;
                for (i = 0; i <= _testRoll; i++)
                {
                    if (i < 100 || i % 100 == 0)
                    {
                        Gui.DoNotWaitOnInkey = true;
                        if (Gui.Inkey() == 0)
                        {
                            break;
                        }
                        Gui.PrintLine(string.Format(q, i, matches, better, worse, other), 0, 0);
                        Gui.Refresh();
                    }
                    Item qPtr = new Item(saveGame);
                    qPtr.MakeObject(good, great);
                    if (qPtr.IsFixedArtifact())
                    {
                        saveGame.FixedArtifacts[qPtr.FixedArtifactIndex].CurNum = 0;
                    }
                    if (oPtr.Category != qPtr.Category)
                    {
                        continue;
                    }
                    if (oPtr.ItemSubCategory != qPtr.ItemSubCategory)
                    {
                        continue;
                    }
                    if (qPtr.TypeSpecificValue == oPtr.TypeSpecificValue &&
                        qPtr.BonusArmourClass == oPtr.BonusArmourClass && qPtr.BonusToHit == oPtr.BonusToHit &&
                        qPtr.BonusDamage == oPtr.BonusDamage)
                    {
                        matches++;
                    }
                    else if (qPtr.TypeSpecificValue >= oPtr.TypeSpecificValue &&
                             qPtr.BonusArmourClass >= oPtr.BonusArmourClass && qPtr.BonusToHit >= oPtr.BonusToHit &&
                             qPtr.BonusDamage >= oPtr.BonusDamage)
                    {
                        better++;
                    }
                    else if (qPtr.TypeSpecificValue <= oPtr.TypeSpecificValue &&
                             qPtr.BonusArmourClass <= oPtr.BonusArmourClass && qPtr.BonusToHit <= oPtr.BonusToHit &&
                             qPtr.BonusDamage <= oPtr.BonusDamage)
                    {
                        worse++;
                    }
                    else
                    {
                        other++;
                    }
                }
                saveGame.MsgPrint(string.Format(q, i, matches, better, worse, other));
                saveGame.MsgPrint(null);
            }
            if (oPtr.IsFixedArtifact())
            {
                saveGame.FixedArtifacts[oPtr.FixedArtifactIndex].CurNum = 1;
            }
        }

        private void WizTweakItem(Item oPtr)
        {
            if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
            {
                return;
            }
            string p = "Enter new 'TypeSpecificValue' setting: ";
            string def = $"{oPtr.TypeSpecificValue}";
            if (!Gui.GetString(p, out string tmpVal, def, 5))
            {
                return;
            }
            oPtr.TypeSpecificValue = tmpVal.ToIntSafely();
            WizDisplayItem(oPtr);
            p = "Enter new 'BonusArmourClass' setting: ";
            def = $"{oPtr.BonusArmourClass}";
            if (!Gui.GetString(p, out tmpVal, def, 5))
            {
                return;
            }
            oPtr.BonusArmourClass = tmpVal.ToIntSafely();
            WizDisplayItem(oPtr);
            p = "Enter new 'BonusToHit' setting: ";
            def = $"{oPtr.BonusToHit}";
            if (!Gui.GetString(p, out tmpVal, def, 5))
            {
                return;
            }
            oPtr.BonusToHit = tmpVal.ToIntSafely();
            WizDisplayItem(oPtr);
            p = "Enter new 'BonusDamage' setting: ";
            def = $"{oPtr.BonusDamage}";
            if (!Gui.GetString(p, out tmpVal, def, 5))
            {
                return;
            }
            oPtr.BonusDamage = tmpVal.ToIntSafely();
            WizDisplayItem(oPtr);
        }
    }
}
