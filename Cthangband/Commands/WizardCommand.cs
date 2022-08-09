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
                    DoCmdWizCureAll(saveGame.Player, saveGame.Level);
                    break;

                case 'b':
                    DoCmdWizBamf();
                    break;

                case 'c':
                    WizCreateItem(saveGame.Player, saveGame.Level);
                    break;

                case 'C':
                    WizCreateNamedArt(saveGame.Player, saveGame.Level, (FixedArtifactId)Gui.CommandArgument);
                    break;

                case 'd':
                    SaveGame.Instance.DetectAll();
                    break;

                case 'e':
                    DoCmdWizChange(saveGame.Player, saveGame.Level);
                    break;

                case 'f':
                    SaveGame.Instance.IdentifyFully();
                    break;

                case 'g':
                    if (Gui.CommandArgument <= 0)
                    {
                        Gui.CommandArgument = 1;
                    }
                    SaveGame.Instance.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, Gui.CommandArgument, false);
                    break;

                case 'h':
                    saveGame.Player.RerollHitPoints();
                    break;

                case 'H':
                    DoCmdSummonHorde(saveGame.Player, saveGame.Level);
                    break;

                case 'i':
                    SaveGame.Instance.IdentifyPack();
                    break;

                case 'j':
                    DoCmdWizJump();
                    break;

                case 'k':
                    SaveGame.Instance.SelfKnowledge();
                    break;

                case 'l':
                    DoCmdWizLearn();
                    break;

                case 'm':
                    saveGame.Level.MapArea();
                    break;

                case 'M':
                    saveGame.Player.Dna.GainMutation();
                    break;

                case 'r':
                    saveGame.Player.GainLevelReward();
                    break;

                case 'N':
                    DoCmdWizNamedFriendly(saveGame.Player, saveGame.Level, Gui.CommandArgument, true);
                    break;

                case 'n':
                    DoCmdWizNamed(saveGame.Player, saveGame.Level, Gui.CommandArgument, true);
                    break;

                case 'o':
                    DoCmdWizPlay(saveGame.Player, saveGame.Level);
                    break;

                case 'p':
                    SaveGame.Instance.TeleportPlayer(10);
                    break;

                case 's':
                    if (Gui.CommandArgument <= 0)
                    {
                        Gui.CommandArgument = 1;
                    }
                    DoCmdWizSummon(saveGame.Player, saveGame.Level, Gui.CommandArgument);
                    break;

                case 't':
                    SaveGame.Instance.TeleportPlayer(100);
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
                    SaveGame.Instance.MsgPrint("*** CONGRATULATIONS ***");
                    SaveGame.Instance.MsgPrint("You have won the game!");
                    SaveGame.Instance.MsgPrint("You may retire ('Q') when you are ready.");
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
                    DoCmdWizZap(saveGame.Player, saveGame.Level);
                    break;

                case 'z':
                    {
                        DoCmdWizardBolt(saveGame.Player, saveGame.Level);
                        break;
                    }
                default:
                    SaveGame.Instance.MsgPrint("That is not a valid wizard command.");
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
                SaveGame.Instance.MsgPrint("Wizard mode activated.");
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrTitle);
            }
        }

        private void DoCmdWizActivatePower(SaveGame saveGame)
        {
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Gui.SetBackground(Terminal.BackgroundImage.Normal);

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
            Gui.SetBackground(Terminal.BackgroundImage.Overhead);

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

        private void DoCmdRedraw(Player player, Level level)
        {
            player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses | UpdateFlags.UpdateHealth | UpdateFlags.UpdateMana | UpdateFlags.UpdateSpells);
            player.UpdatesNeeded.Set(UpdateFlags.UpdateRemoveView | UpdateFlags.UpdateRemoveLight);
            player.UpdatesNeeded.Set(UpdateFlags.UpdateView | UpdateFlags.UpdateLight);
            player.UpdatesNeeded.Set(UpdateFlags.UpdateMonsters);
            player.RedrawNeeded.Set(RedrawFlag.PrWipe | RedrawFlag.PrBasic | RedrawFlag.PrExtra | RedrawFlag.PrMap |
                              RedrawFlag.PrEquippy);
            SaveGame.Instance.HandleStuff();
            Gui.Redraw();
        }

        private void DoCmdSummonHorde(Player player, Level level)
        {
            int wy = player.MapY, wx = player.MapX;
            int attempts = 1000;
            while (--attempts != 0)
            {
                level.Scatter(out wy, out wx, player.MapY, player.MapX, 3);
                if (level.GridOpenNoItemOrCreature(wy, wx))
                {
                    break;
                }
            }
            level.Monsters.AllocHorde(wy, wx);
        }

        private void DoCmdWizardBolt(Player player, Level level)
        {
            ProjectionFlag flg = ProjectionFlag.ProjectStop | ProjectionFlag.ProjectGrid | ProjectionFlag.ProjectItem |
                      ProjectionFlag.ProjectKill;
            TargetEngine targetEngine = new TargetEngine(player, level);
            if (!targetEngine.GetDirectionWithAim(out int dir))
            {
                return;
            }
            int tx = player.MapX + (99 * level.KeypadDirectionXOffset[dir]);
            int ty = player.MapY + (99 * level.KeypadDirectionYOffset[dir]);
            if (dir == 5 && targetEngine.TargetOkay())
            {
                flg &= ~ProjectionFlag.ProjectStop;
                tx = SaveGame.Instance.TargetCol;
                ty = SaveGame.Instance.TargetRow;
            }
            SaveGame.Instance.Project(0, 0, ty, tx, 1000000, new ProjectWizardBolt(), flg);
        }

        private void DoCmdWizBamf()
        {
            if (SaveGame.Instance.TargetWho == 0)
            {
                return;
            }
            SaveGame.Instance.TeleportPlayerTo(SaveGame.Instance.TargetRow, SaveGame.Instance.TargetCol);
        }

        private void DoCmdWizChange(Player player, Level level)
        {
            DoCmdWizChangeAux(player, level);
            DoCmdRedraw(player, level);
        }

        private void DoCmdWizChangeAux(Player player, Level level)
        {
            string tmpVal;
            int tmpInt;
            for (int i = 0; i < 6; i++)
            {
                string ppp = $"{GlobalData.StatNames[i]} (3-118): ";
                if (!Gui.GetString(ppp, out tmpVal, $"{player.AbilityScores[i].InnateMax}", 3))
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
                player.AbilityScores[i].Innate = tmpInt;
                player.AbilityScores[i].InnateMax = tmpInt;
            }
            string def = $"{player.Gold}";
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
            player.Gold = tmpInt;
            def = $"{player.MaxExperienceGained}";
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
            player.MaxExperienceGained = tmpInt;
            player.CheckExperience();
        }

        private void DoCmdWizCureAll(Player player, Level level)
        {
            SaveGame.Instance.RemoveAllCurse();
            player.RestoreAbilityScore(Ability.Strength);
            player.RestoreAbilityScore(Ability.Intelligence);
            player.RestoreAbilityScore(Ability.Wisdom);
            player.RestoreAbilityScore(Ability.Constitution);
            player.RestoreAbilityScore(Ability.Dexterity);
            player.RestoreAbilityScore(Ability.Charisma);
            player.RestoreLevel();
            player.Health = player.MaxHealth;
            player.FractionalHealth = 0;
            player.Mana = player.MaxMana;
            player.FractionalMana = 0;
            player.SetTimedBlindness(0);
            player.SetTimedConfusion(0);
            player.SetTimedPoison(0);
            player.SetTimedFear(0);
            player.SetTimedParalysis(0);
            player.SetTimedHallucinations(0);
            player.SetTimedStun(0);
            player.SetTimedBleeding(0);
            player.SetTimedSlow(0);
            player.SetFood(Constants.PyFoodMax - 1);
            DoCmdRedraw(player, level);
        }

        private void DoCmdWizHelp()
        {
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Gui.Refresh();
            Gui.Clear();
            Gui.SetBackground(Terminal.BackgroundImage.Normal);
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
            Gui.SetBackground(Terminal.BackgroundImage.Overhead);
            Gui.FullScreenOverlay = false;
        }

        private void DoCmdWizJump()
        {
            if (Gui.CommandArgument <= 0)
            {
                string ppp = $"Jump to level (0-{SaveGame.Instance.CurDungeon.MaxLevel}): ";
                string def = $"{SaveGame.Instance.CurrentDepth}";
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
            if (Gui.CommandArgument > SaveGame.Instance.CurDungeon.MaxLevel)
            {
                Gui.CommandArgument = SaveGame.Instance.CurDungeon.MaxLevel;
            }
            SaveGame.Instance.MsgPrint($"You jump to dungeon level {Gui.CommandArgument}.");
            SaveGame.Instance.DoCmdSaveGame(true);
            SaveGame.Instance.CurrentDepth = Gui.CommandArgument;
            SaveGame.Instance.NewLevelFlag = true;
        }

        private void DoCmdWizLearn()
        {
            for (int i = 1; i < Profile.Instance.ItemTypes.Count; i++)
            {
                ItemType kPtr = Profile.Instance.ItemTypes[i];
                if (kPtr.Level <= Gui.CommandArgument)
                {
                    kPtr.FlavourAware = true;
                }
            }
        }

        private void DoCmdWizNamed(Player player, Level level, int rIdx, bool slp)
        {
            if (rIdx >= Profile.Instance.MonsterRaces.Count - 1)
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                const int d = 1;
                level.Scatter(out int y, out int x, player.MapY, player.MapX, d);
                if (!level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (level.Monsters.PlaceMonsterByIndex(y, x, rIdx, slp, true, false))
                {
                    break;
                }
            }
        }

        private void DoCmdWizNamedFriendly(Player player, Level level, int rIdx, bool slp)
        {
            if (rIdx >= Profile.Instance.MonsterRaces.Count - 1)
            {
                return;
            }
            for (int i = 0; i < 10; i++)
            {
                const int d = 1;
                level.Scatter(out int y, out int x, player.MapY, player.MapX, d);
                if (!level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (level.Monsters.PlaceMonsterByIndex(y, x, rIdx, slp, true, true))
                {
                    break;
                }
            }
        }

        private void DoCmdWizPlay(Player player, Level level)
        {
            if (!SaveGame.Instance.GetItem(out int item, "Play with which object? ", true, true, true))
            {
                if (item == -2)
                {
                    SaveGame.Instance.MsgPrint("You have nothing to play with.");
                }
                return;
            }
            Item oPtr = item >= 0 ? player.Inventory[item] : level.Items[0 - item];
            bool changed;
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Item qPtr = new Item(oPtr);
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
                    WizStatistics(qPtr);
                }
                if (ch == 'r' || ch == 'r')
                {
                    qPtr = WizRerollItem(player, level, qPtr);
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
                SaveGame.Instance.MsgPrint("Changes accepted.");
                if (item >= 0)
                {
                    player.Inventory[item] = qPtr;
                }
                else
                {
                    level.Items[0 - item] = qPtr;
                }
                player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
            }
            else
            {
                SaveGame.Instance.MsgPrint("Changes ignored.");
            }
        }

        private void DoCmdWizSummon(Player player, Level level, int num)
        {
            for (int i = 0; i < num; i++)
            {
                level.Monsters.SummonSpecific(player.MapY, player.MapX, SaveGame.Instance.Difficulty, 0);
            }
        }

        private void DoCmdWizZap(Player player, Level level)
        {
            for (int i = 1; i < level.MMax; i++)
            {
                Monster mPtr = level.Monsters[i];
                if (mPtr.Race == null)
                {
                    continue;
                }
                if (mPtr.DistanceFromPlayer <= Constants.MaxSight)
                {
                    level.Monsters.DeleteMonsterByIndex(i, true);
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

        private string StripName(int kIdx)
        {
            ItemType kPtr = Profile.Instance.ItemTypes[kIdx];
            return kPtr.Name.Trim().Replace("$", "").Replace("~", "");
        }

        private void WizCreateItem(Player player, Level level)
        {
            Gui.FullScreenOverlay = true;
            Gui.Save();
            Gui.SetBackground(Terminal.BackgroundImage.Normal);
            int kIdx = WizCreateItemtype();
            Gui.Load();
            Gui.FullScreenOverlay = false;
            Gui.SetBackground(Terminal.BackgroundImage.Overhead);
            if (kIdx == 0)
            {
                return;
            }
            Item qPtr = new Item();
            qPtr.AssignItemType(Profile.Instance.ItemTypes[kIdx]);
            qPtr.ApplyMagic(SaveGame.Instance.Difficulty, false, false, false);
            SaveGame.Instance.Level.DropNear(qPtr, -1, player.MapY, player.MapX);
            SaveGame.Instance.MsgPrint("Allocated.");
        }

        private int WizCreateItemtype()
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
            for (num = 0, i = 1; num < 60 && i < Profile.Instance.ItemTypes.Count; i++)
            {
                ItemType kPtr = Profile.Instance.ItemTypes[i];
                if (kPtr.Category == tval)
                {
                    //if (kPtr.Flags3.IsSet(ItemFlag3.InstaArt))
                    //{
                    //    continue;
                    //}
                    row = 2 + (num % 20);
                    col = 30 * (num / 20);
                    ch = (char)(_head[num / 20] + (char)(num % 20));
                    string buf = StripName(i);
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

        private void WizCreateNamedArt(Player player, Level level, FixedArtifactId aIdx)
        {
            if (aIdx == FixedArtifactId.None)
            {
                return;
            }
            FixedArtifact aPtr = Profile.Instance.FixedArtifacts[aIdx];
            Item qPtr = new Item();
            if (string.IsNullOrEmpty(aPtr.Name))
            {
                return;
            }
            ItemType i = Profile.Instance.ItemTypes.LookupKind(aPtr.Tval, aPtr.Sval);
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
            SaveGame.Instance.Level.DropNear(qPtr, -1, player.MapY, player.MapX);
            SaveGame.Instance.MsgPrint("Allocated.");
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

        private Item WizRerollItem(Player player, Level level, Item oPtr)
        {
            bool changed;
            if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
            {
                return oPtr;
            }
            Item qPtr = new Item(oPtr);
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
                    qPtr.ApplyMagic(SaveGame.Instance.Difficulty, false, false, false);
                }
                else if (ch == 'g' || ch == 'g')
                {
                    qPtr.AssignItemType(oPtr.ItemType);
                    qPtr.ApplyMagic(SaveGame.Instance.Difficulty, false, true, false);
                }
                else if (ch == 'e' || ch == 'e')
                {
                    qPtr.AssignItemType(oPtr.ItemType);
                    qPtr.ApplyMagic(SaveGame.Instance.Difficulty, false, true, true);
                }
            }
            if (changed)
            {
                player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
                player.NoticeFlags |= Constants.PnCombine | Constants.PnReorder;
                return qPtr;
            }
            return oPtr;
        }

        private void WizStatistics(Item oPtr)
        {
            const string q = "Rolls: {0}, Matches: {1}, Better: {2}, Worse: {3}, Other: {4}";
            if (oPtr.IsFixedArtifact())
            {
                Profile.Instance.FixedArtifacts[oPtr.FixedArtifactIndex].CurNum = 0;
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
                SaveGame.Instance.MsgPrint(
                    $"Creating a lot of {quality} items. Base level = {SaveGame.Instance.Difficulty}.");
                SaveGame.Instance.MsgPrint(null);
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
                    Item qPtr = new Item();
                    qPtr.MakeObject(good, great);
                    if (qPtr.IsFixedArtifact())
                    {
                        Profile.Instance.FixedArtifacts[qPtr.FixedArtifactIndex].CurNum = 0;
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
                SaveGame.Instance.MsgPrint(string.Format(q, i, matches, better, worse, other));
                SaveGame.Instance.MsgPrint(null);
            }
            if (oPtr.IsFixedArtifact())
            {
                Profile.Instance.FixedArtifacts[oPtr.FixedArtifactIndex].CurNum = 1;
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
