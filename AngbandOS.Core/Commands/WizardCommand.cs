using AngbandOS.ActivationPowers;
using AngbandOS.Enumerations;
using AngbandOS.Projection;
using AngbandOS.StaticData;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface;

namespace AngbandOS.Commands
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
            saveGame.GetCom("Wizard Command: ", out char cmd);
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
                    DoCmdWizHelp(saveGame);
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
                    WizCreateNamedArt(saveGame, (FixedArtifactId)saveGame.CommandArgument);
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
                    if (saveGame.CommandArgument <= 0)
                    {
                        saveGame.CommandArgument = 1;
                    }
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.CommandArgument, false);
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
                    DoCmdWizNamedFriendly(saveGame, saveGame.CommandArgument, true);
                    break;

                case 'n':
                    DoCmdWizNamed(saveGame, saveGame.CommandArgument, true);
                    break;

                case 'o':
                    DoCmdWizPlay(saveGame);
                    break;

                case 'p':
                    saveGame.TeleportPlayer(10);
                    break;

                case 's':
                    if (saveGame.CommandArgument <= 0)
                    {
                        saveGame.CommandArgument = 1;
                    }
                    DoCmdWizSummon(saveGame, saveGame.CommandArgument);
                    break;

                case 't':
                    saveGame.TeleportPlayer(100);
                    break;

                case 'v':
                    if (saveGame.CommandArgument <= 0)
                    {
                        saveGame.CommandArgument = 1;
                    }
                    saveGame.Level.Acquirement(saveGame.Player.MapY, saveGame.Player.MapX, saveGame.CommandArgument, true);
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
                    if (saveGame.CommandArgument != 0)
                    {
                        saveGame.Player.GainExperience(saveGame.CommandArgument);
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
            saveGame.PrintLine("Enter Wizard Code: ", 0, 0);
            if (!saveGame.AskforAux(out string tmp, "", 31))
            {
                saveGame.Erase(0, 0, 255);
                return;
            }
            saveGame.Erase(0, 0, 255);
            if (tmp == "Dumbledore")
            {
                saveGame.Player.IsWizard = true;
                saveGame.MsgPrint("Wizard mode activated.");
                saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrTitle);
            }
        }

        private void DoCmdWizActivatePower(SaveGame saveGame)
        {
            saveGame.FullScreenOverlay = true;
            saveGame.Save();
            saveGame.SetBackground(BackgroundImage.Normal);

            saveGame.Clear();
            int index = 0;
            foreach (IActivationPower activationPower in ActivationPowerManager.ActivationPowers)
            {
                int row = 2 + (index % 40);
                int col = 30 * (index / 40);
                saveGame.PrintLine($"{index + 1}. {activationPower.Name}", row, col);
                index++;
            }
            if (!saveGame.GetString("Activation power?", out string selection, "", 3))
            {
                return;
            }

            saveGame.Load();
            saveGame.FullScreenOverlay = false;
            saveGame.SetBackground(BackgroundImage.Overhead);

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
            saveGame.Redraw();
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
                if (!saveGame.GetString(ppp, out tmpVal, $"{saveGame.Player.AbilityScores[i].InnateMax}", 3))
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
            if (!saveGame.GetString("Gold: ", out tmpVal, def, 9))
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
            if (!saveGame.GetString("Experience: ", out tmpVal, def, 9))
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

        private void DoCmdWizHelp(SaveGame saveGame)
        {
            saveGame.FullScreenOverlay = true;
            saveGame.Save();
            saveGame.UpdateScreen();
            saveGame.Clear();
            saveGame.SetBackground(BackgroundImage.Normal);
            saveGame.Print(Colour.Red, "Wizard Commands", 1, 31);
            saveGame.Print(Colour.Red, "===============", 2, 31);
            saveGame.Print(Colour.Red, "Character Editing", 4, 1);
            saveGame.Print(Colour.Red, "=================", 5, 1);
            saveGame.Print("a = Cure All", 7, 1);
            saveGame.Print("e = Edit Stats", 8, 1);
            saveGame.Print("h = Reroll Hitpoints", 9, 1);
            saveGame.Print("k = Self Knowledge", 10, 1);
            saveGame.Print("M = Gain Mutation", 11, 1);
            saveGame.Print("r = Gain Level Reward", 12, 1);
            saveGame.Print("x = Gain Experience", 13, 1);
            saveGame.Print(Colour.Red, "Movement", 15, 1);
            saveGame.Print(Colour.Red, "========", 16, 1);
            saveGame.Print("b = Teleport to Target", 18, 1);
            saveGame.Print("j = Jump Levels", 19, 1);
            saveGame.Print("p = Phase Door", 20, 1);
            saveGame.Print("t = Teleport", 21, 1);
            saveGame.Print(Colour.Red, "Monsters", 4, 26);
            saveGame.Print(Colour.Red, "========", 5, 26);
            saveGame.Print("s = Summon Monster", 7, 26);
            saveGame.Print("n = Summon Named Monster", 8, 26);
            saveGame.Print("N = Summon Named Pet", 9, 26);
            saveGame.Print("H = Summon Horde", 10, 26);
            saveGame.Print("Z = Carnage True", 11, 26);
            saveGame.Print("z = Zap (Wizard Bolt)", 12, 26);
            saveGame.Print(Colour.Red, "General Commands", 14, 26);
            saveGame.Print(Colour.Red, "================", 15, 26);
            saveGame.Print("\" = Generate spoilers", 17, 26);
            saveGame.Print("d = Detect All", 18, 26);
            saveGame.Print("m = Map Area", 19, 26);
            saveGame.Print("w = Wizard Light", 20, 26);
            saveGame.Print(Colour.Red, "Object Commands", 4, 51);
            saveGame.Print(Colour.Red, "===============", 5, 51);
            saveGame.Print("c = Create Item", 7, 51);
            saveGame.Print("C = Create Named artifact", 8, 51);
            saveGame.Print("f = Identify Fully", 9, 51);
            saveGame.Print("g = Generate Good Object", 10, 51);
            saveGame.Print("i = Identify Pack", 11, 51);
            saveGame.Print("l = Learn About Objects", 12, 51);
            saveGame.Print("o = Object Editor", 13, 51);
            saveGame.Print("v = Generate Very Good Object", 14, 51);
            saveGame.Print("Hit any key to continue", 43, 23);
            saveGame.Inkey();
            saveGame.Load();
            saveGame.SetBackground(BackgroundImage.Overhead);
            saveGame.FullScreenOverlay = false;
        }

        private void DoCmdWizJump(SaveGame saveGame)
        {
            if (saveGame.CommandArgument <= 0)
            {
                string ppp = $"Jump to level (0-{saveGame.CurDungeon.MaxLevel}): ";
                string def = $"{saveGame.CurrentDepth}";
                if (!saveGame.GetString(ppp, out string tmpVal, def, 10))
                {
                    return;
                }
                saveGame.CommandArgument = int.TryParse(tmpVal, out int i) ? i : 0;
            }
            if (saveGame.CommandArgument < 1)
            {
                saveGame.CommandArgument = 1;
            }
            if (saveGame.CommandArgument > saveGame.CurDungeon.MaxLevel)
            {
                saveGame.CommandArgument = saveGame.CurDungeon.MaxLevel;
            }
            saveGame.MsgPrint($"You jump to dungeon level {saveGame.CommandArgument}.");
            saveGame.DoCmdSaveGame(true);
            saveGame.CurrentDepth = saveGame.CommandArgument;
            saveGame.NewLevelFlag = true;
        }

        private void DoCmdWizLearn(SaveGame saveGame)
        {
            for (int i = 1; i < saveGame.ItemTypes.Count; i++)
            {
                ItemType kPtr = saveGame.ItemTypes[i];
                if (kPtr.Level <= saveGame.CommandArgument)
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
            saveGame.FullScreenOverlay = true;
            saveGame.Save();
            Item qPtr = new Item(saveGame, oPtr);
            while (true)
            {
                WizDisplayItem(saveGame, qPtr);
                if (!saveGame.GetCom("[a]ccept [s]tatistics [r]eroll [t]weak [q]uantity? ", out char ch))
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
                    WizTweakItem(saveGame, qPtr);
                }
                if (ch == 'q' || ch == 'Q')
                {
                    WizQuantityItem(saveGame, qPtr);
                }
            }
            saveGame.Load();
            saveGame.FullScreenOverlay = false;
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

        private void PrtBinary(SaveGame saveGame, FlagSet flags, int row, int col)
        {
            uint bitmask = 1u;
            for (int i = 1; i <= 32; i++)
            {
                if (flags.IsSet(bitmask))
                {
                    saveGame.Print(Colour.Blue, '*', row, col++);
                }
                else
                {
                    saveGame.Print(Colour.White, '-', row, col++);
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
            saveGame.FullScreenOverlay = true;
            saveGame.Save();
            saveGame.SetBackground(BackgroundImage.Normal);
            int kIdx = WizCreateItemtype(saveGame);
            saveGame.Load();
            saveGame.FullScreenOverlay = false;
            saveGame.SetBackground(BackgroundImage.Overhead);
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
            saveGame.Clear();
            for (num = 0; num < 60 && TvalDescriptionPair.Tvals[num].Tval != 0; num++)
            {
                row = 2 + (num % 20);
                col = 30 * (num / 20);
                ch = (char)(_head[num / 20] + (char)(num % 20));
                saveGame.PrintLine($"[{ch}] {TvalDescriptionPair.Tvals[num].Desc}", row, col);
            }
            int maxNum = num;
            if (!saveGame.GetCom("Get what type of object? ", out ch))
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
            saveGame.Clear();
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
                    saveGame.PrintLine($"[{ch}] {buf}", row, col);
                    choice[num++] = i;
                }
            }
            maxNum = num;
            if (!saveGame.GetCom($"What Kind of {tvalDesc}? ", out ch))
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

        private void WizDisplayItem(SaveGame saveGame, Item oPtr)
        {
            const int j = 13;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            oPtr.GetMergedFlags(f1, f2, f3);
            for (int i = 1; i <= 23; i++)
            {
                saveGame.PrintLine("", i, j - 2);
            }
            string buf = oPtr.StoreDescription(true, 3);
            saveGame.PrintLine(buf, 2, j);
            saveGame.PrintLine(
                $"kind = {oPtr.ItemType,5}  level = {oPtr.ItemType.Level,4}  ItemType = {oPtr.Category,5}  ItemSubType = {oPtr.ItemSubCategory,5}",
                4, j);
            saveGame.PrintLine(
                $"number = {oPtr.Count,3}  wgt = {oPtr.Weight,6}  BaseArmourClass = {oPtr.BaseArmourClass,5}    damage = {oPtr.DamageDice}d{oPtr.DamageDiceSides}",
                5, j);
            saveGame.PrintLine(
                $"TypeSpecificValue = {oPtr.TypeSpecificValue,5}  toac = {oPtr.BonusArmourClass,5}  tohit = {oPtr.BonusToHit,4}  todam = {oPtr.BonusDamage,4}",
                6, j);
            saveGame.PrintLine(
                $"FixedArtifactIndex = {oPtr.FixedArtifactIndex,4}  name2 = {oPtr.RareItemTypeIndex,4}  cost = {oPtr.Value()}",
                7, j);
            saveGame.PrintLine($"IdentifyFlags = {oPtr.IdentifyFlags:x4}  timeout = {oPtr.RechargeTimeLeft}", 8, j);
            saveGame.PrintLine("+------------FLAGS1------------+", 10, j);
            saveGame.PrintLine("AFFECT........SLAY........BRAND.", 11, j);
            saveGame.PrintLine("              cvae      xsqpaefc", 12, j);
            saveGame.PrintLine("siwdcc  ssidsahanvudotgddhuoclio", 13, j);
            saveGame.PrintLine("tnieoh  trnipttmiinmrrnrrraiierl", 14, j);
            saveGame.PrintLine("rtsxna..lcfgdkcpmldncltggpksdced", 15, j);
            PrtBinary(saveGame, f1, 16, j);
            saveGame.PrintLine("+------------FLAGS2------------+", 17, j);
            saveGame.PrintLine("SUST....IMMUN.RESIST............", 18, j);
            saveGame.PrintLine("        aefcprpsaefcpfldbc sn   ", 19, j);
            saveGame.PrintLine("siwdcc  cliooeatcliooeialoshtncd", 20, j);
            saveGame.PrintLine("tnieoh  ierlifraierliatrnnnrhehi", 21, j);
            saveGame.PrintLine("rtsxna..dcedslatdcedsrekdfddrxss", 22, j);
            PrtBinary(saveGame, f2, 23, j);
            saveGame.PrintLine("+------------FLAGS3------------+", 10, j + 32);
            saveGame.PrintLine("fe      ehsi  st    iiiiadta  hp", 11, j + 32);
            saveGame.PrintLine("il   n taihnf ee    ggggcregb vr", 12, j + 32);
            saveGame.PrintLine("re  nowysdose eld   nnnntalrl ym", 13, j + 32);
            saveGame.PrintLine("ec  omrcyewta ieirmsrrrriieaeccc", 14, j + 32);
            saveGame.PrintLine("aa  taauktmatlnpgeihaefcvnpvsuuu", 15, j + 32);
            saveGame.PrintLine("uu  egirnyoahivaeggoclioaeoasrrr", 16, j + 32);
            saveGame.PrintLine("rr  litsopdretitsehtierltxrtesss", 17, j + 32);
            saveGame.PrintLine("aa  echewestreshtntsdcedeptedeee", 18, j + 32);
            PrtBinary(saveGame, f3, 19, j + 32);
        }

        private void WizQuantityItem(SaveGame saveGame, Item oPtr)
        {
            if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
            {
                return;
            }
            string def = $"{oPtr.Count}";
            if (saveGame.GetString("Quantity: ", out string tmpVal, def, 2))
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
                WizDisplayItem(saveGame, qPtr);
                if (!saveGame.GetCom("[a]ccept, [n]ormal, [g]ood, [e]xcellent? ", out char ch))
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
                WizDisplayItem(saveGame, oPtr);
                if (!saveGame.GetCom(pmt, out char ch))
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
                        saveGame.DoNotWaitOnInkey = true;
                        if (saveGame.Inkey() == 0)
                        {
                            break;
                        }
                        saveGame.PrintLine(string.Format(q, i, matches, better, worse, other), 0, 0);
                        saveGame.UpdateScreen();
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

        private void WizTweakItem(SaveGame saveGame, Item oPtr)
        {
            if (oPtr.IsFixedArtifact() || !string.IsNullOrEmpty(oPtr.RandartName))
            {
                return;
            }
            string p = "Enter new 'TypeSpecificValue' setting: ";
            string def = $"{oPtr.TypeSpecificValue}";
            if (!saveGame.GetString(p, out string tmpVal, def, 5))
            {
                return;
            }
            oPtr.TypeSpecificValue = tmpVal.ToIntSafely();
            WizDisplayItem(saveGame, oPtr);
            p = "Enter new 'BonusArmourClass' setting: ";
            def = $"{oPtr.BonusArmourClass}";
            if (!saveGame.GetString(p, out tmpVal, def, 5))
            {
                return;
            }
            oPtr.BonusArmourClass = tmpVal.ToIntSafely();
            WizDisplayItem(saveGame, oPtr);
            p = "Enter new 'BonusToHit' setting: ";
            def = $"{oPtr.BonusToHit}";
            if (!saveGame.GetString(p, out tmpVal, def, 5))
            {
                return;
            }
            oPtr.BonusToHit = tmpVal.ToIntSafely();
            WizDisplayItem(saveGame, oPtr);
            p = "Enter new 'BonusDamage' setting: ";
            def = $"{oPtr.BonusDamage}";
            if (!saveGame.GetString(p, out tmpVal, def, 5))
            {
                return;
            }
            oPtr.BonusDamage = tmpVal.ToIntSafely();
            WizDisplayItem(saveGame, oPtr);
        }
    }
}
