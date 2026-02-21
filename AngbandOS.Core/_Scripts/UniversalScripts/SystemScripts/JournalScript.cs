// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class JournalScript : UniversalScript, IGetKey
{
    private JournalScript(Game game) : base(game) { }
    private readonly ColorEnum[] _menuColors = new ColorEnum[128]; // TODO: This is state that we might not need
    private readonly int[] _menuIndices = new int[128]; // TODO: This is state that we might not need
    private readonly string[] _menuItem = new string[128]; // TODO: This is state that we might not need
    private int _menuLength; // TODO: This is state that we might not need

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public override bool RequiresRerendering => true;

    /// <summary>
    /// Renders the journal on the screen.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.SetBackground(BackgroundImageEnum.Paper);
        while (!Game.Shutdown)
        {
            Game.UpdateScreen();
            Game.Screen.Clear();
            Game.Screen.Print(ColorEnum.Blue, "Journal", 0, 1);
            Game.Screen.Print(ColorEnum.Blue, "=======", 1, 1);
            Game.Screen.Print(ColorEnum.Blue, "(a) Abilities", 3, 0);
            Game.Screen.Print(ColorEnum.Blue, "(d) Deities", 4, 0);
            Game.Screen.Print(ColorEnum.Blue, "(k) Kill Count", 5, 0);
            Game.Screen.Print(ColorEnum.Blue, "(m) Mutations", 6, 0);
            Game.Screen.Print(ColorEnum.Blue, "(p) Pets", 7, 0);
            Game.Screen.Print(ColorEnum.Blue, "(q) Quests", 8, 0);
            Game.Screen.Print(ColorEnum.Blue, "(r) Word of Recall", 9, 0);
            Game.Screen.Print(ColorEnum.Blue, "(s) Monsters Seen", 10, 0);
            Game.Screen.Print(ColorEnum.Blue, "(u) Uniques", 11, 0);
            Game.Screen.Print(ColorEnum.Blue, "(w) Worthless Items", 12, 0);
            Game.Screen.Print(ColorEnum.Orange, "[Select a journal section, or Escape to finish.]", 43, 1);
            char k = Game.Inkey();
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
        Game.SetBackground(BackgroundImageEnum.Overhead);
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
    }

    private void DisplayStat(string title, int row, int col, Func<EffectiveAttributeSet, bool> getStat)
    {
        // Determine if the stat is granted via any equipment.  This allows us to choose the color before rendering any of the inventory slots.
        bool anyHasStat = false;
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    EffectiveAttributeSet effectivePropertySet = oPtr.ObjectFlagsKnown();
                    if (getStat(effectivePropertySet))
                    {
                        anyHasStat = true;
                    }
                }
            }
        }

        ColorEnum baseColor = anyHasStat ? ColorEnum.Green : ColorEnum.Blue; // Blue default color for missing stat, green when stat is possessed.
        Game.Screen.Print(baseColor, title, row, col);
        Game.Screen.Print(baseColor, ':', row, col + 10); // Right aligned

        // Now render all of the inventory slots.
        int index = 0;
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment).OrderBy(_inventorySlot => _inventorySlot.SortOrder))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                bool thisHasStat = false;
                Item? oPtr = Game.GetInventoryItem(i);
                if (oPtr != null)
                {
                    EffectiveAttributeSet effectivePropertySet = oPtr.ObjectFlagsKnown();
                    if (getStat(effectivePropertySet))
                    {
                        thisHasStat = true;
                    }
                }
                if (thisHasStat)
                {
                    Game.Screen.Print(baseColor, "+", row, col + 10 + index + 1);
                }
                else
                {
                    Game.Screen.Print(ColorEnum.Grey, ".", row, col + 10 + index + 1);
                }
                index++;
            }
        }

        EffectiveAttributeSet playerCharacteristics = Game.GetAbilitiesAsItemFlags(); // TODO: This is done once for every call.
        if (getStat(playerCharacteristics))
        {
            Game.Screen.Print(baseColor, "+", row, col + 10 + 26); // col + 10 + InventorySlot.Total - InventorySlot.MeleeWeapon + 1);
        }
        else
        {
            Game.Screen.Print(ColorEnum.Grey, ".", row, col + 10 + 26); // col + 10 + InventorySlot.Total - InventorySlot.MeleeWeapon + 1);
        }

    }

    private void DisplayMonster(int rIdx, int num, int of)
    {
        foreach (Symbol symbol in Game.SingletonRepository.Get<Symbol>())
        {
            if (symbol.Character == Game.SingletonRepository.Get<MonsterRace>(rIdx).Symbol.Character)
            {
                string name = symbol.Name;
                string buf = $"Monster Type: {name} ({num + 1} of {of})";
                Game.Screen.Print(ColorEnum.Blue, buf, 3, 0);
                break;
            }

        }
        Game.Screen.Goto(5, 0);
        DisplayMonsterHeader(rIdx);
        Game.Screen.Goto(6, 0);
        Game.SingletonRepository.Get<MonsterRace>(rIdx).Knowledge.DisplayBody(ColorEnum.Brown);
    }

    private void DisplayMonsterHeader(int rIdx)
    {
        MonsterRace rPtr = Game.SingletonRepository.Get<MonsterRace>(rIdx);
        char c1 = rPtr.Symbol.Character;
        ColorEnum a1 = rPtr.Color;
        if (!rPtr.Unique)
        {
            Game.Screen.Print(ColorEnum.Brown, "The ");
        }
        Game.Screen.Print(ColorEnum.Brown, $"{rPtr.FriendlyName} ('");
        Game.Screen.Print(a1, c1.ToString());
        Game.Screen.Print(ColorEnum.Brown, "')");
    }

    private void JournalAbilities()
    {
        Game.Screen.Clear();

        Game.DisplayPlayerEquippy(0, 0 + 11);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 1, 0 + 11);
        DisplayStat("Add Str", 2, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Strength > 0);
        DisplayStat("Add Int", 3, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Intelligence > 0);
        DisplayStat("Add Wis", 4, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Wisdom > 0);
        DisplayStat("Add Dex", 5, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Dexterity > 0);
        DisplayStat("Add Con", 6, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Constitution > 0);
        DisplayStat("Add Cha", 7, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Charisma > 0);


        DisplayStat("Add Stea.", 10, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Stealth > 0);
        DisplayStat("Add Sear.", 11, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Search > 0);
        DisplayStat("Add Infra", 12, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Infravision > 0);
        DisplayStat("Add Tun..", 13, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Tunnel > 0);
        DisplayStat("Add Speed", 14, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Speed > 0);
        DisplayStat("Add Blows", 15, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Attacks > 0);
        DisplayStat("Chaotic", 16, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Chaotic);
        DisplayStat("Vampiric", 17, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(VampiricAttribute)).Get());

        Game.DisplayPlayerEquippy(0, 26 + 11);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 1, 26 + 11);
        DisplayStat("Slay Anim.", 2, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayAnimal);
        DisplayStat("Slay Evil", 3, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayEvil);
        DisplayStat("Slay Und.", 4, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayUndead);
        DisplayStat("Slay Demon", 5, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayDemon);
        DisplayStat("Slay Orc", 6, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayOrc);
        DisplayStat("Slay Troll", 7, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayTroll);
        DisplayStat("Slay Giant", 8, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayGiant);
        DisplayStat("Slay Drag.", 9, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlayDragon > 1);
        DisplayStat("Sharpness", 10, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Vorpal1InChance > 0);
        DisplayStat("Impact", 11, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Impact);
        DisplayStat("Poison Brd", 12, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.BrandPois);
        DisplayStat("Acid Brand", 13, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.BrandAcid);
        DisplayStat("Elec Brand", 14, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.BrandElec);
        DisplayStat("Fire Brand", 15, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.BrandFire);
        DisplayStat("Cold Brand", 16, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.BrandCold);

        Game.DisplayPlayerEquippy(0, 52 + 11);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 1, 52 + 11);
        DisplayStat("Sust Str", 2, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SustStr);
        DisplayStat("Sust Int", 3, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SustInt);
        DisplayStat("Sust Wis", 4, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(SustWisAttribute)).Get());
        DisplayStat("Sust Dex", 5, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SustDex);
        DisplayStat("Sust Con", 6, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SustCon);
        DisplayStat("Sust Cha", 7, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SustCha);


        DisplayStat("Imm Acid", 10, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ImAcid);
        DisplayStat("Imm Elec", 11, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ImElec);
        DisplayStat("Imm Fire", 12, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ImFire);
        DisplayStat("Imm Cold", 13, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ImCold);

        DisplayStat("Reflect", 15, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Reflect);
        DisplayStat("Free Act", 16, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.FreeAct);
        DisplayStat("Hold Life", 17, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.HoldLife);

        Game.DisplayPlayerEquippy(20, 0 + 11);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 21, 0 + 11);
        DisplayStat("Res Acid", 22, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResAcid);
        DisplayStat("Res Elec", 23, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResElec);
        DisplayStat("Res Fire", 24, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResFire);
        DisplayStat("Res Cold", 25, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResCold);
        DisplayStat("Res Pois", 26, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResPois);
        DisplayStat("Res Fear", 27, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResFear);
        DisplayStat("Res Light", 28, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResLight);
        DisplayStat("Res Dark", 29, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResDark);
        DisplayStat("Res Blind", 30, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResBlind);
        DisplayStat("Res Conf", 31, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResConf);
        DisplayStat("Res Sound", 32, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResSound);
        DisplayStat("Res Shard", 33, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResShards);
        DisplayStat("Res Neth", 34, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResNether);
        DisplayStat("Res Nexus", 35, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResNexus);
        DisplayStat("Res Chaos", 36, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResChaos);
        DisplayStat("Res Disen", 37, 0, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ResDisen);

        Game.DisplayPlayerEquippy(20, 26 + 11);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 21, 26 + 11);
        DisplayStat("Aura Fire", 22, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ShFire);
        DisplayStat("Aura Elec", 23, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ShElec);

        DisplayStat("Anti-Theft", 25, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.AntiTheft);
        DisplayStat("Anti-Tele", 26, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.NoTele);
        DisplayStat("Anti-Magic", 27, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.NoMagic);
        DisplayStat("WraithForm", 28, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(WraithAttribute)).Get());
        DisplayStat("EvilCurse", 29, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.DreadCurse);
        DisplayStat("Easy Know", 30, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.EasyKnow);
        DisplayStat("Hide Type", 31, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.HideType);
        DisplayStat("Show Mods", 32, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.ShowMods);
        DisplayStat("Levitate", 33, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Feather);
        DisplayStat("Light", 34, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Radius > 0);
        DisplayStat("See Invis", 35, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SeeInvis);
        DisplayStat("Telepathy", 36, 26, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(TelepathyAttribute)).Get());

        Game.DisplayPlayerEquippy(20, 52 + 11);
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", 21, 52 + 11);
        DisplayStat("Digestion", 22, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.SlowDigest);
        DisplayStat("Regen", 23, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Regen);
        DisplayStat("Xtra Might", 24, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(XtraMightAttribute)).Get());
        DisplayStat("Xtra Shots", 25, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(XtraShotsAttribute)).Get());
        DisplayStat("Ign Acid", 26, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.IgnoreAcid);
        DisplayStat("Ign Elec", 27, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.IgnoreElec);
        DisplayStat("Ign Fire", 28, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.IgnoreFire);
        DisplayStat("Ign Cold", 29, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.IgnoreCold);
        DisplayStat("Activate", 30, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Activation != null);
        DisplayStat("Drain Exp", 31, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.DrainExp);
        DisplayStat("Teleport", 32, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Get<OrEffectiveAttributeValue>(nameof(TeleportAttribute)).Get());
        DisplayStat("Aggravate", 33, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Aggravate);
        DisplayStat("Blessed", 34, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.Blessed);
        DisplayStat("Cursed", 35, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.IsCursed);
        DisplayStat("Hvy Curse", 36, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.HeavyCurse);
        DisplayStat("Prm Curse", 37, 52, (EffectiveAttributeSet itemCharacteristics) => itemCharacteristics.PermaCurse);

        Game.Screen.Print(ColorEnum.Orange, "[Press any key to finish.]", 43, 1);
        Game.Inkey();
    }

    private void JournalDeities()
    {
        Game.Screen.Clear();
        Game.Screen.Print(ColorEnum.Blue, "Standings with Deities", 0, 1);
        Game.Screen.Print(ColorEnum.Blue, "======================", 1, 1);
        int row = 3;
        God patron = null;
        foreach (var deity in Game.SingletonRepository.Get<God>())
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
                    if (deity.Favor < -1000)
                    {
                        text += " hates you";
                    }
                    else if (deity.Favor < -100)
                    {
                        text += " dislikes you";
                    }
                    else if (deity.Favor < -20)
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
                text += String.Format(deity.FavorDescription, adjusted * 10);
            }
            text += ".";
            Game.Screen.Print(ColorEnum.Blue, text, row, 1);
            row++;
        }
        if (patron != null)
        {
            Game.Screen.Print(ColorEnum.Blue, $"You are a follower of {patron.LongName}.", 12, 1);
            Game.Screen.Print(ColorEnum.Blue, $"Over time, your standing with {patron.ShortName} will revert to approval.", 13, 1);
            Game.Screen.Print(ColorEnum.Blue, $"Your standing with other deities will revert to annoyance.", 14, 1);
        }
        else
        {
            Game.Screen.Print(ColorEnum.Blue, "Over time, your standing with all deities will revert back to indifference.", 12, 1);
        }
        Game.Screen.Print(ColorEnum.Orange, "[Press any key to finish.]", 43, 1);
        Game.Inkey();
    }

    private void JournalKills()
    {
        string[] names = new string[Game.SingletonRepository.Count<MonsterRace>()];
        int[] counts = new int[Game.SingletonRepository.Count<MonsterRace>()];
        bool[] unique = new bool[Game.SingletonRepository.Count<MonsterRace>()];
        int maxCount = 0;
        int total = 0;
        for (int i = 0; i < Game.SingletonRepository.Count<MonsterRace>() - 1; i++)
        {
            MonsterRace monster = Game.SingletonRepository.Get<MonsterRace>(i);
            if (monster.Unique)
            {
                bool dead = monster.MaxNum == 0;
                if (dead)
                {
                    total++;
                    names[maxCount] = monster.FriendlyName;
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
                    names[maxCount] = monster.FriendlyName;
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
        while (!Game.Shutdown)
        {
            string buf;
            Game.Screen.Clear();
            Game.Screen.Print(ColorEnum.Blue, "Kill Count", 0, 1);
            Game.Screen.Print(ColorEnum.Blue, "==========", 1, 1);
            if (maxCount == 0)
            {
                Game.Screen.Print(ColorEnum.Blue, "You haven't killed anything yet!", 3, 0);
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
                            string plural = names[i].PluralizeMonsterName();
                            buf = $"You have killed {counts[i]} {plural}";
                        }
                        else
                        {
                            buf = $"You have killed {counts[i]} {names[i]}";
                        }
                    }
                    Game.Screen.Print(ColorEnum.Blue, buf, i - first + 3, 0);
                }
            }
            buf = $"Total Kills: {total}";
            Game.Screen.Print(ColorEnum.Blue, buf, 41, 0);
            Game.Screen.Print(ColorEnum.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
            int c = Game.Inkey();
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
        int[] seen = new int[Game.SingletonRepository.Count<MonsterRace>()];
        int[] filtered = new int[Game.SingletonRepository.Count<MonsterRace>()];
        int maxSeen = 0;
        bool[] filterMask = new bool[256];
        int[] filterLookup = new int[256];
        char[] usedFilters = new char[256];
        int maxUsedFilter = 0;
        for (int i = 0; i < 256; i++)
        {
            filterMask[i] = false;
        }
        for (int i = 1; i < Game.SingletonRepository.Count<MonsterRace>(); i++)
        {
            if (Game.SingletonRepository.Get<MonsterRace>(i).Knowledge.RSights != 0 || Game.IsWizard.BoolValue)
            {
                seen[maxSeen] = i;
                maxSeen++;
                char symbol = Game.SingletonRepository.Get<MonsterRace>(i).Symbol.Character;
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
            Game.Screen.Clear();
            Game.Screen.Print(ColorEnum.Blue, "Monsters Seen", 0, 1);
            Game.Screen.Print(ColorEnum.Blue, "=============", 1, 1);
            Game.Screen.Print(ColorEnum.Blue, "You haven't seen any monsters yet!", 3, 0);
            Game.Screen.Print(ColorEnum.Orange, "[Press any key to finish]", 43, 1);
            Game.Inkey();
            return;
        }
        int currentFilterIndex = 0;
        char currentFilter = usedFilters[0];
        bool useMax = false;
        while (!Game.Shutdown)
        {
            int maxFiltered = 0;
            for (int i = 0; i < maxSeen; i++)
            {
                if (Game.SingletonRepository.Get<MonsterRace>(seen[i]).Symbol.Character == currentFilter)
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
            while (!Game.Shutdown)
            {
                Game.Screen.Clear();
                Game.Screen.Print(ColorEnum.Blue, "Monsters Seen", 0, 1);
                Game.Screen.Print(ColorEnum.Blue, "=============", 1, 1);
                DisplayMonster(filtered[currentIndex], currentIndex, maxFiltered);
                Game.Screen.Print(ColorEnum.Orange, "[Up and down to change type, left and right to change monster, Esc to finish]", 43, 1);
                c = Game.Inkey();
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
        string[] features = Game.GetMutationList();
        int maxFeature = features.Length;
        int first = 0;
        while (!Game.Shutdown)
        {
            Game.Screen.Clear();
            Game.Screen.Print(ColorEnum.Blue, "Mutations", 0, 1);
            Game.Screen.Print(ColorEnum.Blue, "=========", 1, 1);
            if (maxFeature == 0)
            {
                Game.Screen.Print(ColorEnum.Blue, "You have no mutations.", 3, 0);
            }
            else
            {
                for (int i = first; i < first + 38; i++)
                {
                    if (i < maxFeature)
                    {
                        Game.Screen.Print(ColorEnum.Blue, features[i], i - first + 3, 0);
                    }
                }
            }
            Game.Screen.Print(ColorEnum.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
            int c = Game.Inkey();
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
        for (int petCtr = Game.MonsterMax - 1; petCtr >= 1; petCtr--)
        {
            Monster mPtr = Game.Monsters[petCtr];
            if (!mPtr.IsPet)
            {
                continue;
            }
            petNames.Add(mPtr.Race.FriendlyName);
            pets++;
        }
        int first = 0;
        while (!Game.Shutdown)
        {
            Game.Screen.Clear();
            Game.Screen.Print(ColorEnum.Blue, "Pets", 0, 1);
            Game.Screen.Print(ColorEnum.Blue, "====", 1, 1);
            if (pets == 0)
            {
                Game.Screen.Print(ColorEnum.Blue, "You have no pets.", 3, 0);
            }
            else
            {
                for (int i = first; i < first + 38; i++)
                {
                    if (i < pets)
                    {
                        Game.Screen.Print(ColorEnum.Blue, petNames[i], i - first + 3, 0);
                    }
                }
            }
            Game.Screen.Print(ColorEnum.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
            int c = Game.Inkey();
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
        Game.Screen.Clear();
        Game.Screen.Print(ColorEnum.Blue, "Outstanding Quests", 0, 1);
        Game.Screen.Print(ColorEnum.Blue, "==================", 1, 1);
        int row = 3;
        foreach (Dungeon dungeon in Game.SingletonRepository.Get<Dungeon>())
        {
            int firstQuest = dungeon.FirstQuest();
            if (firstQuest != -1)
            {
                string line = Game.Quests[firstQuest].Describe();
                Game.Screen.Print(ColorEnum.Blue, line, row, 0);
                row++;
            }
        }
        if (row == 3)
        {
            Game.Screen.Print(ColorEnum.Blue, "Congratulations! You have completed all the quests.", row, 0);
        }
        Game.Screen.Print(ColorEnum.Orange, "[Press any key to finish.]", 43, 1);
        Game.Inkey();
    }

    private void JournalRecall()
    {
        Game.Screen.Clear();
        Game.Screen.Print(ColorEnum.Blue, "Word of Recall", 0, 1);
        Game.Screen.Print(ColorEnum.Blue, "==============", 1, 1);
        string recallTown = Game.TownWithHouse != null ? Game.TownWithHouse.Name : Game.CurTown.Name;
        string recallDungeon = Game.RecallDungeon.Name;
        int recallLev = Game.RecallDungeon.RecallLevel;
        Game.Screen.Print(ColorEnum.Blue, $"Your Word of Recall position is level {recallLev} of {recallDungeon}.", 3, 0);
        Game.Screen.Print(ColorEnum.Blue, $"Your home town is {recallTown}.", 4, 0);
        if (Game.TownWithHouse != null)
        {
            recallTown = "your house in " + Game.TownWithHouse.Dungeon.Shortname;
        }
        Game.Screen.Print(ColorEnum.Brown,
            Game.CurrentDepth == 0
                ? $"If you recall now, you will return to level {recallLev} of {recallDungeon}."
                : $"If you recall now, you will return to {recallTown}.", 6, 0);
        string description =
            "(If you own a house, your home town is always considered to be the town containing that house ";
        description += "and you will be transported directly to your house. ";
        description += "If not, your home town is updated each time you visit a new town, and you will be transported to a random location in that town. ";
        description += "Your Word of Recall position has its dungeon location updated ";
        description += "only when you recall from a new dungeon or tower; but has its level updated ";
        description += "each time you reach a new level within that dungeon or tower. In either case, you will be transported to a random location on the dungeon or tower level.)";
        Game.Screen.Goto(8, 0);
        Game.Screen.PrintWrap(ColorEnum.Blue, description);
        Game.Screen.Print(ColorEnum.Orange, "[Press any key to finish.]", 43, 1);
        Game.Inkey();
    }

    private void JournalUniques()
    {
        string[] names = new string[Game.SingletonRepository.Count<MonsterRace>()];
        bool[] alive = new bool[Game.SingletonRepository.Count<MonsterRace>()];
        int maxCount = 0;
        for (int i = 0; i < Game.SingletonRepository.Count<MonsterRace>() - 1; i++)
        {
            MonsterRace monster = Game.SingletonRepository.Get<MonsterRace>(i);
            if (monster.Unique &&
                (monster.Knowledge.RSights > 0 || Game.IsWizard.BoolValue))
            {
                names[maxCount] = monster.FriendlyName;
                bool dead = monster.MaxNum == 0;
                alive[maxCount] = !dead;
                maxCount++;
            }
        }
        int first = 0;
        while (!Game.Shutdown)
        {
            Game.Screen.Clear();
            Game.Screen.Print(ColorEnum.Blue, "Unique Foes", 0, 1);
            Game.Screen.Print(ColorEnum.Blue, "===========", 1, 1);
            if (maxCount == 0)
            {
                Game.Screen.Print(ColorEnum.Blue, "You know of no unique foes!", 3, 0);
            }
            for (int i = first; i < first + 38; i++)
            {
                if (i < maxCount)
                {
                    string buf = alive[i] ? $"{names[i]} is alive." : $"{names[i]} is dead.";
                    Game.Screen.Print(ColorEnum.Blue, buf, i - first + 3, 0);
                }
            }
            Game.Screen.Print(ColorEnum.Orange, "[Use up and down to navigate list, and Escape to finish.]", 43, 1);
            int c = Game.Inkey();
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

    private void BuildMenuForForWorthlessItems()
    {
        _menuLength = 0;
        for (int i = 0; i < Game.SingletonRepository.Count<ItemClass>() - 1; i++)
        {
            ItemClass itemClass = Game.SingletonRepository.Get<ItemClass>(i);
            if (itemClass.AllowStomp)
            {
                _menuItem[_menuLength] = Game.Pluralize(Game.SingletonRepository.Get<ItemClass>(i).Name);
                _menuColors[_menuLength] = ColorEnum.Blue;
                _menuLength++;
            }
        }
    }

    private void JournalWorthlessItems()
    {
        Game.Screen.Clear();
        Game.Screen.Print(ColorEnum.Blue, "Worthless Items", 0, 1);
        Game.Screen.Print(ColorEnum.Blue, "===============", 1, 1);
        Game.Screen.Goto(3, 0);
        string text = "Items marked in red ";
        text += "will be considered 'worthless' and you will stomp on them (destroying them) rather than ";
        text += "picking them up. Destroying (using 'k' or 'K') a worthless object will be done automatically ";
        text += "without you being prompted. Items will only be destroyed if they are on the floor or in your ";
        text += "inventory. Items you are wielding will never be destroyed (giving you chance to improve their ";
        text += "quality to a non-worthless level).";
        Game.Screen.PrintWrap(ColorEnum.Blue, text);
        BuildMenuForForWorthlessItems();
        int menu = _menuLength / 2;
        while (!Game.Shutdown)
        {
            MenuDisplay(menu);
            Game.Screen.Print(ColorEnum.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
            while (true)
            {
                char c = Game.Inkey();
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
                    WorthlessItemTypeSelection(Game.SingletonRepository.Get<ItemClass>().First(_itemClass => Game.Pluralize(_itemClass.Name) == _menuItem[menu]));
                    BuildMenuForForWorthlessItems();
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
        Game.Screen.Clear(9);
        Game.Screen.Print(ColorEnum.Orange, "=>", 25, 0);
        string desc = string.Empty;
        ColorEnum descColor = ColorEnum.Brown;
        for (int i = 0; i < _menuLength; i++)
        {
            int row = 25 + i - current;
            if (row < 10 || row > 40)
            {
                continue;
            }
            ColorEnum a = _menuColors[i];
            if (i == current)
            {
                switch (a)
                {
                    case ColorEnum.Blue:
                        a = ColorEnum.BrightBlue;
                        desc = "(This type of item has further sub-types.)";
                        break;

                    case ColorEnum.Green:
                        a = ColorEnum.BrightGreen;
                        desc = "(This type of item has value to you.)";
                        break;

                    default:
                        a = ColorEnum.BrightRed;
                        desc = "(This type of item is worthless to you.)";
                        break;
                }
                descColor = a;
            }
            Game.Screen.Print(a, _menuItem[i], row, 2);
        }
        Game.Screen.Print(descColor, desc, 25, 33);
    }

    private void WorthlessItemChestSelection(ItemFactory kPtr)
    {
        string[] qualityText = new[] { "Empty", "Unlocked", "Locked", "Trapped" };
        _menuLength = 0;
        for (int i = 0; i < 4; i++)
        {
            _menuItem[i] = qualityText[i];
            _menuColors[i] = kPtr.Stompable[i] ? ColorEnum.Red : ColorEnum.Green;
        }
        _menuLength = 4;
        int menu = 1;
        while (!Game.Shutdown)
        {
            MenuDisplay(menu);
            Game.Screen.Print(ColorEnum.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
            while (true)
            {
                char c = Game.Inkey();
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
                    _menuColors[menu] = kPtr.Stompable[menu] ? ColorEnum.Red : ColorEnum.Green;
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
            _menuColors[i] = kPtr.Stompable[i] ? ColorEnum.Red : ColorEnum.Green;
        }
        _menuLength = 4;
        int menu = 1;
        while (!Game.Shutdown)
        {
            MenuDisplay(menu);
            Game.Screen.Print(ColorEnum.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
            while (true)
            {
                char c = Game.Inkey();
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
                    _menuColors[menu] = kPtr.Stompable[menu] ? ColorEnum.Red : ColorEnum.Green;
                    break;
                }
                if (c == '4')
                {
                    return;
                }
            }
        }
    }

    private void WorthlessItemTypeSelection(ItemClass tval)
    {
        _menuLength = 0;
        for (int i = 0; i < Game.SingletonRepository.Count<ItemFactory>(); i++)
        {
            ItemFactory itemFactory = Game.SingletonRepository.Get<ItemFactory>(i);
            if (itemFactory.ItemClass == tval)
            {
                if (itemFactory.DisableStomp) // TODO: This only pulls from the ItemFactory and not generated characteristcs
                {
                    continue;
                }
                _menuItem[_menuLength] = itemFactory.Name;
                if (!itemFactory.AskDestroyAll)
                {
                    _menuColors[_menuLength] = ColorEnum.Blue;
                }
                else
                {
                    _menuColors[_menuLength] = itemFactory.Stompable[0] ? ColorEnum.Red : ColorEnum.Green;
                }
                _menuIndices[_menuLength] = i;
                _menuLength++;
            }
        }
        int menu = _menuLength / 2;
        while (!Game.Shutdown)
        {
            MenuDisplay(menu);
            Game.Screen.Print(ColorEnum.Orange, "[Up/Down = select item type, Left/Right = forward/back.]", 43, 1);
            while (true)
            {
                char c = Game.Inkey();
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
                    ItemFactory itemFactory = Game.SingletonRepository.Get<ItemFactory>(_menuIndices[menu]);
                    if (!itemFactory.AskDestroyAll)
                    {
                        WorthlessItemQualitySelection(itemFactory);
                        _menuLength = 0;
                        for (int i = 0; i < Game.SingletonRepository.Count<ItemFactory>(); i++)
                        {
                            itemFactory = Game.SingletonRepository.Get<ItemFactory>(i);
                            if (itemFactory.ItemClass == tval)
                            {
                                if (itemFactory.DisableStomp) // TODO: This only pulls from the ItemFactory and not generated characteristcs
                                {
                                    continue;
                                }
                                _menuItem[_menuLength] = itemFactory.Name;
                                _menuColors[_menuLength] = ColorEnum.Blue;
                                _menuIndices[_menuLength] = i;
                                _menuLength++;
                            }
                        }
                    }
                    else
                    {
                        itemFactory.Stompable[0] = !itemFactory.Stompable[0];
                        _menuColors[menu] = itemFactory.Stompable[0] ? ColorEnum.Red : ColorEnum.Green;
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
