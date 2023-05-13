// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    internal class Journal
    {
        private readonly Colour[] _menuColours = new Colour[128];
        private readonly int[] _menuIndices = new int[128];
        private readonly string[] _menuItem = new string[128];
        private readonly SaveGame SaveGame;
        private int _menuLength;

        public Journal(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public void ShowMenu()
        {
            SaveGame.FullScreenOverlay = true;
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            SaveGame.SetBackground(BackgroundImage.Paper);
            while (true && !SaveGame.Shutdown)
            {
                SaveGame.UpdateScreen();
                SaveGame.Screen.Clear();
                SaveGame.Screen.Print(Colour.Blue, "Journal", 0, 1);
                SaveGame.Screen.Print(Colour.Blue, "=======", 1, 1);
                SaveGame.Screen.Print(Colour.Blue, "(a) Abilities", 3, 0);
                SaveGame.Screen.Print(Colour.Blue, "(d) Deities", 4, 0);
                SaveGame.Screen.Print(Colour.Blue, "(k) Kill Count", 5, 0);
                SaveGame.Screen.Print(Colour.Blue, "(m) Mutations", 6, 0);
                SaveGame.Screen.Print(Colour.Blue, "(p) Pets", 7, 0);
                SaveGame.Screen.Print(Colour.Blue, "(q) Quests", 8, 0);
                SaveGame.Screen.Print(Colour.Blue, "(r) Word of Recall", 9, 0);
                SaveGame.Screen.Print(Colour.Blue, "(s) Monsters Seen", 10, 0);
                SaveGame.Screen.Print(Colour.Blue, "(u) Uniques", 11, 0);
                SaveGame.Screen.Print(Colour.Blue, "(w) Worthless Items", 12, 0);
                SaveGame.Screen.Print(Colour.Orange, "[Select a journal section, or Escape to finish.]", 43, 1);
                char k = SaveGame.Inkey();
                if (k == '\x1b')
                {
                    break;
                }
                switch (k)
                {
                    case 'a':
                    case 'A':
                        JournalAbilities();
                        break;

                    case 'd':
                    case 'D':
                        JournalDeities();
                        break;

                    case 'p':
                    case 'P':
                        JournalPets();
                        break;

                    case 'q':
                    case 'Q':
                        JournalQuests();
                        break;

                    case 's':
                    case 'S':
                        JournalMonsters();
                        break;

                    case 'u':
                    case 'U':
                        JournalUniques();
                        break;

                    case 'k':
                    case 'K':
                        JournalKills();
                        break;

                    case 'm':
                    case 'M':
                        JournalMutations();
                        break;

                    case 'r':
                    case 'R':
                        JournalRecall();
                        break;

                    case 'w':
                    case 'W':
                        JournalWorthlessItems();
                        break;
                }
            }
            SaveGame.SetBackground(BackgroundImage.Overhead);
            SaveGame.Screen.Restore(savedScreen);
            SaveGame.FullScreenOverlay = false;
        }

        private void DisplayStat(string title, int row, int col, Func<IItemCharacteristics, bool> getStat)
        {
            // Determine if the stat is granted via any equipment.  This allows us to choose the color before rendering any of the inventory slots.
            bool anyHasStat = false;
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsEquipment))
            {
                foreach (int i in inventorySlot.InventorySlots)
                {
                    Item? oPtr = SaveGame.GetInventoryItem(i);
                    if (oPtr != null)
                    {
                        IItemCharacteristics itemCharacteristics = oPtr.ObjectFlagsKnown();
                        if (getStat(itemCharacteristics))
                        {
                            anyHasStat = true;
                        }
                    }
                }
            }

            Colour baseColour = anyHasStat ? Colour.Green : Colour.Blue; // Blue default color for missing stat, green when stat is possessed.
            SaveGame.Screen.Print(baseColour, title, row, col);
            SaveGame.Screen.Print(baseColour, ':', row, col + 10); // Right aligned

            // Now render all of the inventory slots.
            int index = 0;
            foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsEquipment).OrderBy(_inventorySlot => _inventorySlot.SortOrder))
            {
                foreach (int i in inventorySlot.InventorySlots)
                {
                    bool thisHasStat = false;
                    Item? oPtr = SaveGame.GetInventoryItem(i);
                    if (oPtr != null)
                    {
                        IItemCharacteristics itemCharacteristics = oPtr.ObjectFlagsKnown();
                        if (getStat(itemCharacteristics))
                        {
                            thisHasStat = true;
                        }
                    }
                    if (thisHasStat)
                    {
                        SaveGame.Screen.Print(baseColour, "+", row, col + 10 + index + 1);
                    }
                    else
                    {
                        SaveGame.Screen.Print(Colour.Grey, ".", row, col + 10 + index + 1);
                    }
                    index++;
                }
            }

            ItemCharacteristics playerCharacteristics = SaveGame.Player.GetAbilitiesAsItemFlags();
            if (getStat(playerCharacteristics))
            {
                SaveGame.Screen.Print(baseColour, "+", row, col + 10 + 26); // col + 10 + InventorySlot.Total - InventorySlot.MeleeWeapon + 1);
            }
            else
            {
                SaveGame.Screen.Print(Colour.Grey, ".", row, col + 10 + 26); // col + 10 + InventorySlot.Total - InventorySlot.MeleeWeapon + 1);
            }

        }

        private void DisplayMonster(int rIdx, int num, int of)
        {
            for (int i = 0; Constants.SymbolIdentification[i] != null; i++)
            {
                if (Constants.SymbolIdentification[i][0] == SaveGame.SingletonRepository.MonsterRaces[rIdx].Character)
                {
                    string name = Constants.SymbolIdentification[i].Substring(2);
                    string buf = $"Monster Type: {name} ({num + 1} of {of})";
                    SaveGame.Screen.Print(Colour.Blue, buf, 3, 0);
                    break;
                }
            }
            SaveGame.Screen.Goto(5, 0);
            DisplayMonsterHeader(rIdx);
            SaveGame.Screen.Goto(6, 0);
            SaveGame.SingletonRepository.MonsterRaces[rIdx].Knowledge.DisplayBody(Colour.Brown);
        }

        private void DisplayMonsterHeader(int rIdx)
        {
            MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[rIdx];
            char c1 = rPtr.Character;
            Colour a1 = rPtr.Colour;
            if (!rPtr.Unique)
            {
                SaveGame.Screen.Print(Colour.Brown, "The ");
            }
            SaveGame.Screen.Print(Colour.Brown, $"{rPtr.Name} ('");
            SaveGame.Screen.Print(a1, c1.ToString());
            SaveGame.Screen.Print(Colour.Brown, "')");
        }

        private void JournalAbilities()
        {
            SaveGame.Screen.Clear();

            CharacterViewer.DisplayPlayerEquippy(SaveGame, 0, 0 + 11);
            SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 1, 0 + 11);
            DisplayStat("Add Str", 2, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Str);
            DisplayStat("Add Int", 3, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Int);
            DisplayStat("Add Wis", 4, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Wis);
            DisplayStat("Add Dex", 5, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Dex);
            DisplayStat("Add Con", 6, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Con);
            DisplayStat("Add Cha", 7, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Cha);


            DisplayStat("Add Stea.", 10, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Stealth);
            DisplayStat("Add Sear.", 11, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Search);
            DisplayStat("Add Infra", 12, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Infra);
            DisplayStat("Add Tun..", 13, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Tunnel);
            DisplayStat("Add Speed", 14, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Speed);
            DisplayStat("Add Blows", 15, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Blows);
            DisplayStat("Chaotic", 16, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Chaotic);
            DisplayStat("Vampiric", 17, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Vampiric);

            CharacterViewer.DisplayPlayerEquippy(SaveGame, 0, 26 + 11);
            SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 1, 26 + 11);
            DisplayStat("Slay Anim.", 2, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayAnimal);
            DisplayStat("Slay Evil", 3, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayEvil);
            DisplayStat("Slay Und.", 4, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayUndead);
            DisplayStat("Slay Demon", 5, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayDemon);
            DisplayStat("Slay Orc", 6, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayOrc);
            DisplayStat("Slay Troll", 7, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayTroll);
            DisplayStat("Slay Giant", 8, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayGiant);
            DisplayStat("Slay Drag.", 9, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlayDragon);
            DisplayStat("Kill Drag.", 10, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.KillDragon);
            DisplayStat("Sharpness", 11, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Vorpal);
            DisplayStat("Impact", 12, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Impact);
            DisplayStat("Poison Brd", 13, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.BrandPois);
            DisplayStat("Acid Brand", 14, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.BrandAcid);
            DisplayStat("Elec Brand", 15, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.BrandElec);
            DisplayStat("Fire Brand", 16, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.BrandFire);
            DisplayStat("Cold Brand", 17, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.BrandCold);

            CharacterViewer.DisplayPlayerEquippy(SaveGame, 0, 52 + 11);
            SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 1, 52 + 11);
            DisplayStat("Sust Str", 2, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustStr);
            DisplayStat("Sust Int", 3, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustInt);
            DisplayStat("Sust Wis", 4, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustWis);
            DisplayStat("Sust Dex", 5, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustDex);
            DisplayStat("Sust Con", 6, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCon);
            DisplayStat("Sust Cha", 7, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SustCha);


            DisplayStat("Imm Acid", 10, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ImAcid);
            DisplayStat("Imm Elec", 11, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ImElec);
            DisplayStat("Imm Fire", 12, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ImFire);
            DisplayStat("Imm Cold", 13, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ImCold);

            DisplayStat("Reflect", 15, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Reflect);
            DisplayStat("Free Act", 16, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.FreeAct);
            DisplayStat("Hold Life", 17, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HoldLife);

            CharacterViewer.DisplayPlayerEquippy(SaveGame, 20, 0 + 11);
            SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 21, 0 + 11);
            DisplayStat("Res Acid", 22, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResAcid);
            DisplayStat("Res Elec", 23, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResElec);
            DisplayStat("Res Fire", 24, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResFire);
            DisplayStat("Res Cold", 25, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResCold);
            DisplayStat("Res Pois", 26, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResPois);
            DisplayStat("Res Fear", 27, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResFear);
            DisplayStat("Res Light", 28, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResLight);
            DisplayStat("Res Dark", 29, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDark);
            DisplayStat("Res Blind", 30, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResBlind);
            DisplayStat("Res Conf", 31, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResConf);
            DisplayStat("Res Sound", 32, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResSound);
            DisplayStat("Res Shard", 33, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResShards);
            DisplayStat("Res Neth", 34, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNether);
            DisplayStat("Res Nexus", 35, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResNexus);
            DisplayStat("Res Chaos", 36, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResChaos);
            DisplayStat("Res Disen", 37, 0, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ResDisen);

            CharacterViewer.DisplayPlayerEquippy(SaveGame, 20, 26 + 11);
            SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 21, 26 + 11);
            DisplayStat("Aura Fire", 22, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ShFire);
            DisplayStat("Aura Elec", 23, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ShElec);

            DisplayStat("Anti-Theft", 25, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.AntiTheft);
            DisplayStat("Anti-Tele", 26, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.NoTele);
            DisplayStat("Anti-Magic", 27, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.NoMagic);
            DisplayStat("WraithForm", 28, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Wraith);
            DisplayStat("EvilCurse", 29, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.DreadCurse);
            DisplayStat("Easy Know", 30, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.EasyKnow);
            DisplayStat("Hide Type", 31, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HideType);
            DisplayStat("Show Mods", 32, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.ShowMods);
            DisplayStat("Insta Art", 33, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.InstaArt);
            DisplayStat("Levitate", 34, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Feather);
            DisplayStat("Light", 35, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Lightsource);
            DisplayStat("See Invis", 36, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SeeInvis);
            DisplayStat("Telepathy", 37, 26, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Telepathy);

            CharacterViewer.DisplayPlayerEquippy(SaveGame, 20, 52 + 11);
            SaveGame.Screen.Print(Colour.Blue, "abcdefghijklm@", 21, 52 + 11);
            DisplayStat("Digestion", 22, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.SlowDigest);
            DisplayStat("Regen", 23, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Regen);
            DisplayStat("Xtra Might", 24, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.XtraMight);
            DisplayStat("Xtra Shots", 25, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.XtraShots);
            DisplayStat("Ign Acid", 26, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.IgnoreAcid);
            DisplayStat("Ign Elec", 27, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.IgnoreElec);
            DisplayStat("Ign Fire", 28, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.IgnoreFire);
            DisplayStat("Ign Cold", 29, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.IgnoreCold);
            DisplayStat("Activate", 30, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Activate);
            DisplayStat("Drain Exp", 31, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.DrainExp);
            DisplayStat("Teleport", 32, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Teleport);
            DisplayStat("Aggravate", 33, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Aggravate);
            DisplayStat("Blessed", 34, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Blessed);
            DisplayStat("Cursed", 35, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.Cursed);
            DisplayStat("Hvy Curse", 36, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.HeavyCurse);
            DisplayStat("Prm Curse", 37, 52, (IItemCharacteristics itemCharacteristics) => itemCharacteristics.PermaCurse);

            SaveGame.Screen.Print(Colour.Orange, "[Press any key to finish.]", 43, 1);
            SaveGame.Inkey();
        }

        private void JournalDeities()
        {
            SaveGame.Screen.Clear();
            SaveGame.Screen.Print(Colour.Blue, "Standings with Deities", 0, 1);
            SaveGame.Screen.Print(Colour.Blue, "======================", 1, 1);
            int row = 3;
            God patron = null;
            foreach (var deity in SaveGame.Player.Religion.GetAllDeities())
            {
                var text = deity.ShortName;
                if (deity.IsPatron)
                {
                    patron = deity;
                }
                var adjusted = deity.AdjustedFavour;
                switch (adjusted)
                {
                    case 0:
                        if (deity.Favour < -1000)
                        {
                            text += " hates you";
                        }
                        else if (deity.Favour < -100)
                        {
                            text += " dislikes you";
                        }
                        else if (deity.Favour < -20)
                        {
                            text += " is annoyed by you";
                        }
                        else
                        {
                            text += " is indifferent to you";
                        }
                        break;

                    case 1:
                        text += " has noticed you";
                        break;

                    case 2:
                        text += " is watching you";
                        break;

                    case 3:
                        text += " approves of you";
                        break;

                    case 4:
                        text += " likes you";
                        break;

                    case 5:
                        text += " holds you dear";
                        break;

                    case 6:
                        text += " loves you";
                        break;

                    case 7:
                        text += " adores you";
                        break;

                    case 8:
                        text += " prizes you";
                        break;

                    case 9:
                        text += " dotes on you";
                        break;

                    case 10:
                        text += " cherishes you";
                        break;
                }
                if (adjusted > 0)
                {
                    switch (deity.Name)
                    {
                        case GodName.Lobon:
                            text += $" ({adjusted * 10}% chance to avoid ability drain)";
                            break;

                        case GodName.Nath_Horthah:
                            text += $" (+{adjusted * 10}% max health)";
                            break;

                        case GodName.Hagarg_Ryonis:
                            text += $" ({adjusted * 10}% chance to avoid poison/life drain)";
                            break;

                        case GodName.Tamash:
                            text += $" (+{adjusted * 10}% max mana)";
                            break;

                        case GodName.Zo_Kalar:
                            text += $" ({adjusted * 10}% chance to avoid death)";
                            break;
                    }
                }
                text += ".";
                SaveGame.Screen.Print(Colour.Blue, text, row, 1);
                row++;
            }
            if (patron != null)
            {
                SaveGame.Screen.Print(Colour.Blue, $"You are a follower of {patron.LongName}.", 12, 1);
                SaveGame.Screen.Print(Colour.Blue, $"Over time, your standing with {patron.ShortName} will revert to approval.", 13, 1);
                SaveGame.Screen.Print(Colour.Blue, $"Your standing with other deities will revert to annoyance.", 14, 1);
            }
            else
            {
                SaveGame.Screen.Print(Colour.Blue, "Over time, your standing with all deities will revert back to indifference.", 12, 1);
            }
            SaveGame.Screen.Print(Colour.Orange, "[Press any key to finish.]", 43, 1);
            SaveGame.Inkey();
        }

        private void JournalKills()
        {
            string[] names = new string[SaveGame.SingletonRepository.MonsterRaces.Count];
            int[] counts = new int[SaveGame.SingletonRepository.MonsterRaces.Count];
            bool[] unique = new bool[SaveGame.SingletonRepository.MonsterRaces.Count];
            int maxCount = 0;
            int total = 0;
            for (int i = 0; i < SaveGame.SingletonRepository.MonsterRaces.Count - 1; i++)
            {
                MonsterRace monster = SaveGame.SingletonRepository.MonsterRaces[i];
                if (monster.Unique)
                {
                    bool dead = monster.MaxNum == 0;
                    if (dead)
                    {
                        total++;
                        names[maxCount] = monster.Name;
                        counts[maxCount] = 1;
                        unique[maxCount] = true;
                        maxCount++;
                    }
                }
                else
                {
                    if (monster.Knowledge.RPkills > 0)
                    {
                        total += monster.Knowledge.RPkills;
                        names[maxCount] = monster.Name;
                        counts[maxCount] = monster.Knowledge.RPkills;
                        unique[maxCount] = false;
                        maxCount++;
                    }
                }
            }
            for (int i = 0; i < maxCount - 1; i++)
            {
                for (int j = maxCount - 1; j > i; j--)
                {
                    if (counts[j] <= counts[j - 1])
                    {
                        continue;
                    }
                    string tempName = names[j];
                    names[j] = names[j - 1];
                    names[j - 1] = tempName;
                    int tempCount = counts[j];
                    counts[j] = counts[j - 1];
                    counts[j - 1] = tempCount;
                    bool tempUnique = unique[j];
                    unique[j] = unique[j - 1];
                    unique[j - 1] = tempUnique;
                }
            }
            int first = 0;
            while (true && !SaveGame.Shutdown)
            {
                string buf;
                SaveGame.Screen.Clear();
                SaveGame.Screen.Print(Colour.Blue, "Kill Count", 0, 1);
                SaveGame.Screen.Print(Colour.Blue, "==========", 1, 1);
                if (maxCount == 0)
                {
                    SaveGame.Screen.Print(Colour.Blue, "You haven't killed anything yet!", 3, 0);
                }
                for (int i = first; i < first + 38; i++)
                {
                    if (i < maxCount)
                    {
                        if (unique[i])
                        {
                            buf = $"You have killed {names[i]}";
                        }
                        else
                        {
                            if (counts[i] > 1)
                            {
                                string plural = names[i].PluraliseMonsterName();
                                buf = $"You have killed {counts[i]} {plural}";
                            }
                            else
                            {
                                buf = $"You have killed {counts[i]} {names[i]}";
                            }
                        }
                        SaveGame.Screen.Print(Colour.Blue, buf, i - first + 3, 0);
                    }
                }
                buf = $"Total Kills: {total}";
                SaveGame.Screen.Print(Colour.Blue, buf, 41, 0);
                SaveGame.Screen.Print(Colour.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
                int c = SaveGame.Inkey();
                if (c == '\x1b')
                {
                    break;
                }
                if (c == '8' || c == '4')
                {
                    first--;
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
                if (c == '2' || c == '6')
                {
                    first++;
                    if (first > maxCount - 38)
                    {
                        first = maxCount - 38;
                    }
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
            }
        }

        private void JournalMonsters()
        {
            int[] seen = new int[SaveGame.SingletonRepository.MonsterRaces.Count];
            int[] filtered = new int[SaveGame.SingletonRepository.MonsterRaces.Count];
            int maxSeen = 0;
            bool[] filterMask = new bool[256];
            int[] filterLookup = new int[256];
            char[] usedFilters = new char[256];
            int maxUsedFilter = 0;
            for (int i = 0; i < 256; i++)
            {
                filterMask[i] = false;
            }
            for (int i = 1; i < SaveGame.SingletonRepository.MonsterRaces.Count; i++)
            {
                if (SaveGame.SingletonRepository.MonsterRaces[i].Knowledge.RSights != 0 || SaveGame.Player.IsWizard)
                {
                    seen[maxSeen] = i;
                    maxSeen++;
                    char symbol = SaveGame.SingletonRepository.MonsterRaces[i].Character;
                    if (!filterMask[symbol])
                    {
                        filterMask[symbol] = true;
                    }
                }
            }
            for (char i = (char)0; i < 256; i++)
            {
                usedFilters[i] = (char)0;
                if (!filterMask[i])
                {
                    continue;
                }
                usedFilters[maxUsedFilter] = i;
                filterLookup[i] = maxUsedFilter;
                maxUsedFilter++;
            }
            if (maxSeen == 0)
            {
                SaveGame.Screen.Clear();
                SaveGame.Screen.Print(Colour.Blue, "Monsters Seen", 0, 1);
                SaveGame.Screen.Print(Colour.Blue, "=============", 1, 1);
                SaveGame.Screen.Print(Colour.Blue, "You haven't seen any monsters yet!", 3, 0);
                SaveGame.Screen.Print(Colour.Orange, "[Press any key to finish]", 43, 1);
                SaveGame.Inkey();
                return;
            }
            int currentFilterIndex = 0;
            char currentFilter = usedFilters[0];
            bool useMax = false;
            while (true)
            {
                int maxFiltered = 0;
                for (int i = 0; i < maxSeen; i++)
                {
                    if (SaveGame.SingletonRepository.MonsterRaces[seen[i]].Character == currentFilter)
                    {
                        filtered[maxFiltered] = seen[i];
                        maxFiltered++;
                    }
                }
                int currentIndex = 0;
                if (useMax)
                {
                    currentIndex = maxFiltered - 1;
                }
                char c = '\x00';
                while (true && !SaveGame.Shutdown)
                {
                    SaveGame.Screen.Clear();
                    SaveGame.Screen.Print(Colour.Blue, "Monsters Seen", 0, 1);
                    SaveGame.Screen.Print(Colour.Blue, "=============", 1, 1);
                    DisplayMonster(filtered[currentIndex], currentIndex, maxFiltered);
                    SaveGame.Screen.Print(Colour.Orange,
                        "[Up and down to change type, left and right to change monster, Esc to finish]", 43, 1);
                    c = SaveGame.Inkey();
                    if (c == '4')
                    {
                        if (currentIndex > 0)
                        {
                            currentIndex--;
                        }
                        else
                        {
                            c = '8';
                            break;
                        }
                    }
                    else if (c == '6')
                    {
                        if (currentIndex < maxFiltered - 1)
                        {
                            currentIndex++;
                        }
                        else
                        {
                            c = '2';
                            break;
                        }
                    }
                    else if (c == '\x1b' || c == '2' || c == '8')
                    {
                        break;
                    }
                    else
                    {
                        if (filterMask[c])
                        {
                            currentFilterIndex = filterLookup[c];
                            currentFilter = usedFilters[currentFilterIndex];
                            break;
                        }
                    }
                }
                if (c == '8')
                {
                    if (currentFilterIndex > 0)
                    {
                        currentFilterIndex--;
                        currentFilter = usedFilters[currentFilterIndex];
                        useMax = true;
                    }
                    else
                    {
                        useMax = false;
                    }
                }
                if (c == '2')
                {
                    if (currentFilterIndex < maxUsedFilter - 1)
                    {
                        currentFilterIndex++;
                        currentFilter = usedFilters[currentFilterIndex];
                        useMax = false;
                    }
                    else
                    {
                        useMax = true;
                    }
                }
                if (c == '\x1b')
                {
                    break;
                }
            }
        }

        private void JournalMutations()
        {
            string[] features = SaveGame.Player.Dna.GetMutationList();
            int maxFeature = features.Length;
            int first = 0;
            while (true && !SaveGame.Shutdown)
            {
                SaveGame.Screen.Clear();
                SaveGame.Screen.Print(Colour.Blue, "Mutations", 0, 1);
                SaveGame.Screen.Print(Colour.Blue, "=========", 1, 1);
                if (maxFeature == 0)
                {
                    SaveGame.Screen.Print(Colour.Blue, "You have no mutations.", 3, 0);
                }
                else
                {
                    for (int i = first; i < first + 38; i++)
                    {
                        if (i < maxFeature)
                        {
                            SaveGame.Screen.Print(Colour.Blue, features[i], i - first + 3, 0);
                        }
                    }
                }
                SaveGame.Screen.Print(Colour.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
                int c = SaveGame.Inkey();
                if (c == '\x1b')
                {
                    break;
                }
                if (c == '8' || c == '4')
                {
                    first--;
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
                if (c == '2' || c == '6')
                {
                    first++;
                    if (first > maxFeature - 38)
                    {
                        first = maxFeature - 38;
                    }
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
            }
        }

        private void JournalPets()
        {
            List<string> petNames = new List<string>();
            int pets = 0;
            Level level = SaveGame.Level;
            for (int petCtr = level.MMax - 1; petCtr >= 1; petCtr--)
            {
                Monster mPtr = level.Monsters[petCtr];
                if (!mPtr.SmFriendly)
                {
                    continue;
                }
                petNames.Add(mPtr.Race.Name);
                pets++;
            }
            int first = 0;
            while (true && !SaveGame.Shutdown)
            {
                SaveGame.Screen.Clear();
                SaveGame.Screen.Print(Colour.Blue, "Pets", 0, 1);
                SaveGame.Screen.Print(Colour.Blue, "====", 1, 1);
                if (pets == 0)
                {
                    SaveGame.Screen.Print(Colour.Blue, "You have no pets.", 3, 0);
                }
                else
                {
                    for (int i = first; i < first + 38; i++)
                    {
                        if (i < pets)
                        {
                            SaveGame.Screen.Print(Colour.Blue, petNames[i], i - first + 3, 0);
                        }
                    }
                }
                SaveGame.Screen.Print(Colour.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
                int c = SaveGame.Inkey();
                if (c == '\x1b')
                {
                    break;
                }
                if (c == '8' || c == '4')
                {
                    first--;
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
                if (c == '2' || c == '6')
                {
                    first++;
                    if (first > pets - 38)
                    {
                        first = pets - 38;
                    }
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
            }
        }

        private void JournalQuests()
        {
            SaveGame.Screen.Clear();
            SaveGame.Screen.Print(Colour.Blue, "Outstanding Quests", 0, 1);
            SaveGame.Screen.Print(Colour.Blue, "==================", 1, 1);
            int[] lev = new int[Constants.MaxCaves];
            int[] first = new int[Constants.MaxCaves];
            for (int i = 0; i < Constants.MaxCaves; i++)
            {
                first[i] = -1;
                lev[i] = -1;
            }
            for (int i = 0; i < SaveGame.Quests.Count; i++)
            {
                Quest q = SaveGame.Quests[i];
                if (q.Level > 0)
                {
                    int dungeon = q.Dungeon;
                    if (first[dungeon] == -1 || q.Level < lev[dungeon])
                    {
                        first[dungeon] = i;
                        lev[dungeon] = q.Level;
                    }
                }
            }
            int row = 3;
            for (int i = 0; i < Constants.MaxCaves; i++)
            {
                if (first[i] != -1)
                {
                    string line = SaveGame.DescribeQuest(first[i]);
                    SaveGame.Screen.Print(Colour.Blue, line, row, 0);
                    row++;
                }
            }
            if (row == 3)
            {
                SaveGame.Screen.Print(Colour.Blue, "Congratulations! You have completed all the quests.", row, 0);
            }
            SaveGame.Screen.Print(Colour.Orange, "[Press any key to finish.]", 43, 1);
            SaveGame.Inkey();
        }

        private void JournalRecall()
        {
            SaveGame.Screen.Clear();
            SaveGame.Screen.Print(Colour.Blue, "Word of Recall", 0, 1);
            SaveGame.Screen.Print(Colour.Blue, "==============", 1, 1);
            string recallTown = SaveGame.Player.TownWithHouse > -1 ? SaveGame.SingletonRepository.Towns[SaveGame.Player.TownWithHouse].Name : SaveGame.CurTown.Name;
            string recallDungeon = SaveGame.RecallDungeon.Name;
            int recallLev = SaveGame.RecallDungeon.RecallLevel;
            SaveGame.Screen.Print(Colour.Blue, $"Your Word of Recall position is level {recallLev} of {recallDungeon}.", 3, 0);
            SaveGame.Screen.Print(Colour.Blue, $"Your home town is {recallTown}.", 4, 0);
            if (SaveGame.Player.TownWithHouse > -1)
            {
                recallTown = "your house in " + SaveGame.Dungeons[SaveGame.Player.TownWithHouse].Shortname;
            }
            SaveGame.Screen.Print(Colour.Brown,
                SaveGame.CurrentDepth == 0
                    ? $"If you recall now, you will return to level {recallLev} of {recallDungeon}."
                    : $"If you recall now, you will return to {recallTown}.", 6, 0);
            string description =
                "(If you own a house, your home town is always considered to be the town containing that house ";
            description += "and you will be transported directly to your house. ";
            description += "If not, your home town is updated each time you visit a new town, and you will be transported to a random location in that town. ";
            description += "Your Word of Recall position has its dungeon location updated ";
            description += "only when you recall from a new dungeon or tower; but has its level updated ";
            description += "each time you reach a new level within that dungeon or tower. In either case, you will be transported to a random location on the dungeon or tower level.)";
            SaveGame.Screen.Goto(8, 0);
            SaveGame.Screen.PrintWrap(Colour.Blue, description);
            SaveGame.Screen.Print(Colour.Orange, "[Press any key to finish.]", 43, 1);
            SaveGame.Inkey();
        }

        private void JournalUniques()
        {
            string[] names = new string[SaveGame.SingletonRepository.MonsterRaces.Count];
            bool[] alive = new bool[SaveGame.SingletonRepository.MonsterRaces.Count];
            int maxCount = 0;
            for (int i = 0; i < SaveGame.SingletonRepository.MonsterRaces.Count - 1; i++)
            {
                MonsterRace monster = SaveGame.SingletonRepository.MonsterRaces[i];
                if (monster.Unique &&
                    (monster.Knowledge.RSights > 0 || SaveGame.Player.IsWizard))
                {
                    names[maxCount] = monster.Name;
                    bool dead = monster.MaxNum == 0;
                    alive[maxCount] = !dead;
                    maxCount++;
                }
            }
            int first = 0;
            while (true && !SaveGame.Shutdown)
            {
                SaveGame.Screen.Clear();
                SaveGame.Screen.Print(Colour.Blue, "Unique Foes", 0, 1);
                SaveGame.Screen.Print(Colour.Blue, "===========", 1, 1);
                if (maxCount == 0)
                {
                    SaveGame.Screen.Print(Colour.Blue, "You know of no unique foes!", 3, 0);
                }
                for (int i = first; i < first + 38; i++)
                {
                    if (i < maxCount)
                    {
                        string buf = alive[i] ? $"{names[i]} is alive." : $"{names[i]} is dead.";
                        SaveGame.Screen.Print(Colour.Blue, buf, i - first + 3, 0);
                    }
                }
                SaveGame.Screen.Print(Colour.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
                int c = SaveGame.Inkey();
                if (c == '\x1b')
                {
                    break;
                }
                if (c == '8' || c == '4')
                {
                    first--;
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
                if (c == '2' || c == '6')
                {
                    first++;
                    if (first > maxCount - 38)
                    {
                        first = maxCount - 38;
                    }
                    if (first < 0)
                    {
                        first = 0;
                    }
                }
            }
        }

        private void JournalWorthlessItems()
        {
            SaveGame.Screen.Clear();
            SaveGame.Screen.Print(Colour.Blue, "Worthless Items", 0, 1);
            SaveGame.Screen.Print(Colour.Blue, "===============", 1, 1);
            SaveGame.Screen.Goto(3, 0);
            string text = "Items marked in red ";
            text += "will be considered 'worthless' and you will stomp on them (destroying them) rather than ";
            text += "picking them up. Destroying (using 'k' or 'K') a worthless object will be done automatically ";
            text += "without you being prompted. Items will only be destroyed if they are on the floor or in your ";
            text += "inventory. Items you are wielding will never be destroyed (giving you chance to improve their ";
            text += "quality to a non-worthless level).";
            SaveGame.Screen.PrintWrap(Colour.Blue, text);
            for (int i = 0; i < TvalDescriptionPair.Tvals.Length - 1; i++)
            {
                _menuItem[i] = TvalDescriptionPair.Tvals[i].Desc;
                _menuColours[i] = Colour.Blue;
            }
            _menuLength = TvalDescriptionPair.Tvals.Length - 1;
            int menu = _menuLength / 2;
            while (true && !SaveGame.Shutdown)
            {
                MenuDisplay(menu);
                SaveGame.Screen.Print(Colour.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
                while (true)
                {
                    char c = SaveGame.Inkey();
                    if (c == '8' && menu > 0)
                    {
                        menu--;
                        break;
                    }
                    if (c == '2' && menu < _menuLength - 1)
                    {
                        menu++;
                        break;
                    }
                    if (c == '6')
                    {
                        WorthlessItemTypeSelection(TvalDescriptionPair.Tvals[menu].Tval);
                        for (int i = 0; i < TvalDescriptionPair.Tvals.Length - 1; i++)
                        {
                            _menuItem[i] = TvalDescriptionPair.Tvals[i].Desc;
                            _menuColours[i] = Colour.Blue;
                        }
                        _menuLength = TvalDescriptionPair.Tvals.Length - 1;
                        break;
                    }
                    if (c == '4')
                    {
                        return;
                    }
                }
            }
        }

        private void MenuDisplay(int current)
        {
            SaveGame.Screen.Clear(9);
            SaveGame.Screen.Print(Colour.Orange, "=>", 25, 0);
            string desc = string.Empty;
            Colour descColour = Colour.Brown;
            for (int i = 0; i < _menuLength; i++)
            {
                int row = 25 + i - current;
                if (row < 10 || row > 40)
                {
                    continue;
                }
                Colour a = _menuColours[i];
                if (i == current)
                {
                    switch (a)
                    {
                        case Colour.Blue:
                            a = Colour.BrightBlue;
                            desc = "(This type of item has further sub-types.)";
                            break;

                        case Colour.Green:
                            a = Colour.BrightGreen;
                            desc = "(This type of item has value to you.)";
                            break;

                        default:
                            a = Colour.BrightRed;
                            desc = "(This type of item is worthless to you.)";
                            break;
                    }
                    descColour = a;
                }
                SaveGame.Screen.Print(a, _menuItem[i], row, 2);
            }
            SaveGame.Screen.Print(descColour, desc, 25, 33);
        }

        private string StripDownName(string name)
        {
            string val = name.Replace("~", "");
            val = val.Replace("%", "");
            val = val.Replace("&", "");
            return val.Trim();
        }

        private void WorthlessItemChestSelection(ItemFactory kPtr)
        {
            string[] qualityText = new[] { "Empty", "Unlocked", "Locked", "Trapped" };
            _menuLength = 0;
            for (int i = 0; i < 4; i++)
            {
                _menuItem[i] = qualityText[i];
                _menuColours[i] = kPtr.Stompable[i] ? Colour.Red : Colour.Green;
            }
            _menuLength = 4;
            int menu = 1;
            while (true && !SaveGame.Shutdown)
            {
                MenuDisplay(menu);
                SaveGame.Screen.Print(Colour.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
                while (true)
                {
                    char c = SaveGame.Inkey();
                    if (c == '8' && menu > 0)
                    {
                        menu--;
                        break;
                    }
                    if (c == '2' && menu < _menuLength - 1)
                    {
                        menu++;
                        break;
                    }
                    if (c == '6')
                    {
                        kPtr.Stompable[menu] = !kPtr.Stompable[menu];
                        _menuColours[menu] = kPtr.Stompable[menu] ? Colour.Red : Colour.Green;
                        break;
                    }
                    if (c == '4')
                    {
                        return;
                    }
                }
            }
        }

        private void WorthlessItemQualitySelection(ItemFactory kPtr)
        {
            string[] qualityText = new[] { "Bad", "Average", "Good", "Excellent" };
            _menuLength = 0;
            for (int i = 0; i < 4; i++)
            {
                _menuItem[i] = qualityText[i];
                _menuColours[i] = kPtr.Stompable[i] ? Colour.Red : Colour.Green;
            }
            _menuLength = 4;
            int menu = 1;
            while (true && !SaveGame.Shutdown)
            {
                MenuDisplay(menu);
                SaveGame.Screen.Print(Colour.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
                while (true)
                {
                    char c = SaveGame.Inkey();
                    if (c == '8' && menu > 0)
                    {
                        menu--;
                        break;
                    }
                    if (c == '2' && menu < _menuLength - 1)
                    {
                        menu++;
                        break;
                    }
                    if (c == '6')
                    {
                        kPtr.Stompable[menu] = !kPtr.Stompable[menu];
                        _menuColours[menu] = kPtr.Stompable[menu] ? Colour.Red : Colour.Green;
                        break;
                    }
                    if (c == '4')
                    {
                        return;
                    }
                }
            }
        }

        private void WorthlessItemTypeSelection(ItemTypeEnum tval)
        {
            _menuLength = 0;
            for (int i = 0; i < SaveGame.SingletonRepository.ItemFactories.Count; i++)
            {
                ItemFactory kPtr = SaveGame.SingletonRepository.ItemFactories[i];
                if (kPtr.CategoryEnum == tval)
                {
                    if (kPtr.InstaArt)
                    {
                        continue;
                    }
                    _menuItem[_menuLength] = StripDownName(kPtr.FriendlyName);
                    if (kPtr.HasQuality || kPtr.CategoryEnum == ItemTypeEnum.Chest)
                    {
                        _menuColours[_menuLength] = Colour.Blue;
                    }
                    else
                    {
                        _menuColours[_menuLength] = kPtr.Stompable[0] ? Colour.Red : Colour.Green;
                    }
                    _menuIndices[_menuLength] = i;
                    _menuLength++;
                }
            }
            int menu = _menuLength / 2;
            while (true && !SaveGame.Shutdown)
            {
                MenuDisplay(menu);
                SaveGame.Screen.Print(Colour.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
                while (true)
                {
                    char c = SaveGame.Inkey();
                    if (c == '8' && menu > 0)
                    {
                        menu--;
                        break;
                    }
                    if (c == '2' && menu < _menuLength - 1)
                    {
                        menu++;
                        break;
                    }
                    if (c == '6')
                    {
                        ItemFactory kPtr = SaveGame.SingletonRepository.ItemFactories[_menuIndices[menu]];
                        if (kPtr.HasQuality)
                        {
                            WorthlessItemQualitySelection(kPtr);
                            _menuLength = 0;
                            for (int i = 0; i < SaveGame.SingletonRepository.ItemFactories.Count; i++)
                            {
                                kPtr = SaveGame.SingletonRepository.ItemFactories[i];
                                if (kPtr.CategoryEnum == tval)
                                {
                                    if (kPtr.InstaArt)
                                    {
                                        continue;
                                    }
                                    _menuItem[_menuLength] = StripDownName(kPtr.FriendlyName);
                                    if (kPtr.HasQuality)
                                    {
                                        _menuColours[_menuLength] = Colour.Blue;
                                    }
                                    else
                                    {
                                        _menuColours[_menuLength] = kPtr.Stompable[0] ? Colour.Red : Colour.Green;
                                    }
                                    _menuIndices[_menuLength] = i;
                                    _menuLength++;
                                }
                            }
                        }
                        else if (kPtr.CategoryEnum == ItemTypeEnum.Chest)
                        {
                            WorthlessItemChestSelection(kPtr);
                            _menuLength = 0;
                            for (int i = 0; i < SaveGame.SingletonRepository.ItemFactories.Count; i++)
                            {
                                kPtr = SaveGame.SingletonRepository.ItemFactories[i];
                                if (kPtr.CategoryEnum == tval)
                                {
                                    if (kPtr.InstaArt)
                                    {
                                        continue;
                                    }
                                    _menuItem[_menuLength] = StripDownName(kPtr.FriendlyName);
                                    if (kPtr.CategoryEnum == ItemTypeEnum.Chest)
                                    {
                                        _menuColours[_menuLength] = Colour.Blue;
                                    }
                                    else
                                    {
                                        _menuColours[_menuLength] = kPtr.Stompable[0] ? Colour.Red : Colour.Green;
                                    }
                                    _menuIndices[_menuLength] = i;
                                    _menuLength++;
                                }
                            }
                        }
                        else
                        {
                            kPtr.Stompable[0] = !kPtr.Stompable[0];
                            _menuColours[menu] = kPtr.Stompable[0] ? Colour.Red : Colour.Green;
                        }
                        break;
                    }
                    if (c == '4')
                    {
                        return;
                    }
                }
            }
        }
    }
}