// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RenderCharacterScript : UniversalScript, IGetKey
{
    private RenderCharacterScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Display the player's entire character sheet.
    /// </summary>
    public override void ExecuteScript()
    {
        Game.Screen.Clear(0);
        DisplayPlayerTop();
        DisplayPlayerHistory();
        DisplayPlayerAbilityScoresWithEffects();
        DisplayPlayerAbilityScoresWithModifiers();
        DisplayPlayerEssentials();
        DisplayPlayerSkills();
    }

    /// <summary>
    /// Create a summary of the bonuses given by a specific ability score
    /// </summary>
    /// <param name="abilityIndex"> The index of the ability score to summarise </param>
    /// <returns> The summary of the score's bonuses </returns>
    private string AbilitySummary(Ability ability)
    {
        // The summary will have up to five sections
        // Get the score
        // Fill in up to five pieces of bonus text
        (string bonus1, string bonus2, string bonus3, string bonus4, string bonus5) = ability.GetBonuses();

        // Add the bonus text for spell casting abilities
        if (Game.BaseCharacterClass.SpellStat == ability && ability != Game.StrengthAbility)
        {
            int mana = ability.ManaBonus;
            // Casting abilities only have one or two inherent bonuses, so it's safe to start at three
            bonus3 = mana % 2 == 0 ? $", {mana / 2} SP/lvl" : $", {mana / 2}.5 SP/lvl";
            // Not all casting classes have actual spells
            if (Game.BaseCharacterClass.ID != CharacterClassEnum.Mindcrafter && Game.BaseCharacterClass.ID != CharacterClassEnum.Mystic && Game.BaseCharacterClass.ID != CharacterClassEnum.Channeler)
            {
                int spells = ability.HalfSpellsPerLevel;
                if (spells == 2)
                {
                    bonus4 = ", 1 spell/lvl";
                }
                else if (spells % 2 == 0)
                {
                    bonus4 = $", {spells / 2} spells/lvl";
                }
                else
                {
                    bonus4 = $", {spells / 2}.5 spells/lvl";
                }
            }
            // Almost all casting classes have a failure chance
            if (Game.BaseCharacterClass.ID != CharacterClassEnum.Channeler)
            {
                int fail = ability.SpellMinFailChance;
                bonus5 = $", {fail}% min fail";
            }
        }
        // String together the bonuses and return the string
        return $"{bonus1}{bonus2}{bonus3}{bonus4}{bonus5}";
    }

    /// <summary>
    /// Display the player's ability scores including any bonuses or penalties these scores give them
    /// </summary>
    private void DisplayPlayerAbilityScoresWithEffects()
    {
        // Loop through the scores
        int i = 0;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            string buf;
            // If they've been drained, make them visually distinct
            if (ability.Innate < ability.InnateMax)
            {
                Game.Screen.Print(ColorEnum.Blue, ability.NameReduced, 14 + i, 1);
                int value = ability.Adjusted;
                buf = value.StatToString();
                Game.Screen.Print(ColorEnum.Grey, buf, 14 + i, 6);
                buf = AbilitySummary(ability);
                Game.Screen.Print(ColorEnum.Grey, buf, i + 14, 13);
            }
            else
            {
                Game.Screen.Print(ColorEnum.Blue, ability.Name, 14 + i, 1);
                buf = ability.Adjusted.StatToString();
                Game.Screen.Print(ColorEnum.Green, buf, 14 + i, 6);
                buf = AbilitySummary(ability);
                Game.Screen.Print(ColorEnum.Green, buf, i + 14, 13);
            }
            i++;
        }
    }

    private void ShowBonus(bool hasSustain, bool hasStat, int bonusValue, int row, int col)
    {
        if (hasSustain)
        {
            // Sustains show a green 's'
            Game.Screen.Print(ColorEnum.Green, "s", row, col);
        }
        else if (hasStat)
        {
            // Show stat
            if (bonusValue <= -10)
            {
                // Max display for negative value
                Game.Screen.Print(ColorEnum.Red, "*", row, col);
            }
            else if (bonusValue < 0)
            {
                // Display negative value
                Game.Screen.Print(ColorEnum.Red, (char)('0' - (char)bonusValue), row, col);
            }
            else if (bonusValue >= 10)
            {
                // Display max 
                Game.Screen.Print(ColorEnum.Green, "*", row, col);
            }
            else if (bonusValue > 0)
            {
                // Display positive value
                Game.Screen.Print(ColorEnum.Green, (char)('0' + (char)bonusValue), row, col);
            }
        }
        else
        {
            // Display neutral
            Game.Screen.Print(ColorEnum.Grey, ".", row, col);
        }
    }

    /// <summary>
    /// Display the ability scores including details of any modifiers to them
    /// </summary>
    private void DisplayPlayerAbilityScoresWithModifiers()
    {
        const int statCol = 1;
        const int row = 22;
        Game.Screen.Print(ColorEnum.Purple, "Initial", row - 1, statCol + 5);
        Game.Screen.Print(ColorEnum.Brown, "Race Class Mods", row - 1, statCol + 13);
        Game.Screen.Print(ColorEnum.Green, "Actual", row - 1, statCol + 29);
        Game.Screen.Print(ColorEnum.Red, "Reduced", row - 1, statCol + 36);

        // Loop through the scores
        int i = 0;
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            // Reverse engineer our equipment bonuses from our score
            int equipmentBonuses = 0;
            if (ability.InnateMax > 18 && ability.AdjustedMax > 18)
            {
                equipmentBonuses = (ability.AdjustedMax - ability.InnateMax) / 10;
            }
            if (ability.InnateMax <= 18 && ability.AdjustedMax <= 18)
            {
                equipmentBonuses = ability.AdjustedMax - ability.InnateMax;
            }
            if (ability.InnateMax <= 18 && ability.AdjustedMax > 18)
            {
                equipmentBonuses = ((ability.AdjustedMax - 18) / 10) - ability.InnateMax + 18;
            }
            if (ability.InnateMax > 18 && ability.AdjustedMax <= 18)
            {
                equipmentBonuses = ability.AdjustedMax - ((ability.InnateMax - 18) / 10) - 19;
            }
            // Take out the bonuses we got for our our race and profession
            RaceAbility raceAbility = Game.SingletonRepository.Get<RaceAbility>(RaceAbility.GetCompositeKey(Game.Race, ability));
            string compositeKey = CharacterClassAbility.GetCompositeKey(Game.BaseCharacterClass, ability);
            CharacterClassAbility characterClassAbility = Game.SingletonRepository.Get<CharacterClassAbility>(compositeKey);
            equipmentBonuses -= raceAbility.Bonus;
            equipmentBonuses -= characterClassAbility.Bonus;
            // Print each of the scores and bonuses
            Game.Screen.Print(ColorEnum.Blue, ability.Name, row + i, statCol);
            string buf = ability.InnateMax.StatToString();
            Game.Screen.Print(ColorEnum.Purple, buf, row + i, statCol + 4);
            buf = raceAbility.Bonus.ToString("+0;-0;+0").PadLeft(3);
            Game.Screen.Print(ColorEnum.Brown, buf, row + i, statCol + 13);
            buf = characterClassAbility.Bonus.ToString("+0;-0;+0").PadLeft(3);
            Game.Screen.Print(ColorEnum.Brown, buf, row + i, statCol + 19);
            buf = equipmentBonuses.ToString("+0;-0;+0").PadLeft(3);
            Game.Screen.Print(ColorEnum.Brown, buf, row + i, statCol + 24);
            buf = ability.AdjustedMax.StatToString();
            Game.Screen.Print(ColorEnum.Green, buf, row + i, statCol + 27);
            if (ability.Adjusted < ability.AdjustedMax)
            {
                buf = ability.Adjusted.StatToString();
                Game.Screen.Print(ColorEnum.Red, buf, row + i, statCol + 35);
            }
            i++;
        }

        // Print the bonuses for each score and each item we have
        int col = statCol + 44;
        Game.Screen.Print(ColorEnum.Blue, "abcdefghijklm@", row - 1, col);
        Game.Screen.Print(ColorEnum.Blue, "Modifications", row + 6, col);
        foreach (WieldSlot inventorySlot in Game.SingletonRepository.Get<WieldSlot>().Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int inventorySlotIndex in inventorySlot.InventorySlots)
            {
                Item? item = Game.GetInventoryItem(inventorySlotIndex);
                if (item == null)
                {
                    ShowBonus(false, false, 0, row + 0, col);
                    ShowBonus(false, false, 0, row + 1, col);
                    ShowBonus(false, false, 0, row + 2, col);
                    ShowBonus(false, false, 0, row + 3, col);
                    ShowBonus(false, false, 0, row + 4, col);
                    ShowBonus(false, false, 0, row + 5, col);
                }
                else
                {
                    // Only extract known bonuses, not full bonuses
                    EffectivePropertySet itemCharacteristics = item.ObjectFlagsKnown();
                    ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.BonusStrength > 0, item.EffectivePropertySet.BonusStrength, row + 0, col);
                    ShowBonus(itemCharacteristics.SustInt, itemCharacteristics.BonusIntelligence > 0, item.EffectivePropertySet.BonusIntelligence, row + 1, col);
                    ShowBonus(itemCharacteristics.SustWis, itemCharacteristics.BonusWisdom > 0, item.EffectivePropertySet.BonusWisdom, row + 2, col);
                    ShowBonus(itemCharacteristics.SustDex, itemCharacteristics.BonusDexterity > 0, item.EffectivePropertySet.BonusDexterity, row + 3, col);
                    ShowBonus(itemCharacteristics.SustCon, itemCharacteristics.BonusConstitution > 0, item.EffectivePropertySet.BonusConstitution, row + 4, col);
                    ShowBonus(itemCharacteristics.SustCha, itemCharacteristics.BonusCharisma > 0, item.EffectivePropertySet.BonusCharisma, row + 5, col);
                }
                col++;
            }
        }

        EffectivePropertySet playerCharacteristics = Game.GetAbilitiesAsItemFlags();
        DisplayPlayerStatWithModification(Game.StrengthBonus, playerCharacteristics.Str, row + 0, col);
        DisplayPlayerStatWithModification(Game.IntelligenceBonus, playerCharacteristics.Int, row + 1, col);
        DisplayPlayerStatWithModification(Game.WisdomBonus, playerCharacteristics.Wis, row + 2, col);
        DisplayPlayerStatWithModification(Game.DexterityBonus, playerCharacteristics.Dex, row + 3, col);
        DisplayPlayerStatWithModification(Game.ConstitutionBonus, playerCharacteristics.Con, row + 4, col);
        DisplayPlayerStatWithModification(Game.CharismaBonus, playerCharacteristics.Cha, row + 5, col);
    }

    private void DisplayPlayerStatWithModification(int extraModifier, bool isSet, int row, int col)
    {
        ColorEnum a = ColorEnum.Grey;
        char c = '.';
        if (extraModifier != 0)
        {
            c = '*';
            if (extraModifier > 0)
            {
                a = ColorEnum.Green;
                if (extraModifier < 10)
                {
                    c = (char)('0' + (char)extraModifier);
                }
            }
            if (extraModifier < 0)
            {
                a = ColorEnum.Red;
                if (extraModifier < 10)
                {
                    c = (char)('0' - (char)extraModifier);
                }
            }
        }
        if (isSet)
        {
            a = ColorEnum.Green;
            c = 's';
        }
        Game.Screen.Print(a, c, row, col);
    }

    /// <summary>
    /// Display essential player information such as level, experience, gold, health, mana
    /// </summary>
    private void DisplayPlayerEssentials()
    {
        int showTohit = Game.Bonuses.DisplayedAttackBonus;
        int showTodam = Game.Bonuses.DisplayedDamageBonus;
        MeleeWeaponWieldSlot meeleeWeaponInventorySlot = (MeleeWeaponWieldSlot)Game.SingletonRepository.Get<WieldSlot>(nameof(MeleeWeaponWieldSlot));
        Item? item = Game.GetInventoryItem(meeleeWeaponInventorySlot.WeightedRandom.ChooseOrDefault());
        // Only show bonuses if we know them
        if (item != null && item.IsKnown())
        {
            showTohit += item.EffectivePropertySet.BonusHit;
            showTodam += item.EffectivePropertySet.BonusDamage;
        }
        // Print some basics
        PrintBonus("+ To Hit    ", showTohit, 30, 1, ColorEnum.Brown);
        PrintBonus("+ To Damage ", showTodam, 31, 1, ColorEnum.Brown);
        PrintBonus("+ To AC     ", Game.DisplayedArmorClassBonus, 32, 1, ColorEnum.Brown);
        PrintShortScore("  Base AC   ", Game.DisplayedBaseArmorClass, 33, 1, ColorEnum.Brown);
        PrintShortScore("Level      ", Game.ExperienceLevel.IntValue, 30, 28, ColorEnum.Green);
        PrintLongScore("Experience ", Game.ExperiencePoints.IntValue, 31, 28,
            Game.ExperiencePoints.IntValue >= Game.MaxExperienceGained.IntValue ? ColorEnum.Green : ColorEnum.Red);
        PrintLongScore("Max Exp    ", Game.MaxExperienceGained.IntValue, 32, 28, ColorEnum.Green);
        // If we're max level we don't have any experience to advance
        if (Game.ExperienceLevel.IntValue >= Constants.PyMaxLevel)
        {
            Game.Screen.Print(ColorEnum.Blue, "Exp to Adv.", 33, 28);
            Game.Screen.Print(ColorEnum.Green, "    *****", 33, 28 + 11);
        }
        else
        {
            PrintLongScore("Exp to Adv.", (int)(Game.RequiredExperiencePerLevel[Game.ExperienceLevel.IntValue - 1] * Game.ExperienceMultiplier.IntValue / 100L), 33, 28,
                ColorEnum.Green);
        }
        PrintLongScore("Exp Factor ", Game.ExperienceMultiplier.IntValue, 34, 28, ColorEnum.Green);
        PrintShortScore("Max Hit Points ", Game.MaxHealth.IntValue, 30, 52, ColorEnum.Green);
        if (Game.Health.IntValue >= Game.MaxHealth.IntValue)
        {
            PrintShortScore("Cur Hit Points ", Game.Health.IntValue, 31, 52, ColorEnum.Green);
        }
        else if (Game.Health.IntValue > Game.MaxHealth.IntValue * Constants.HitpointWarn / 10)
        {
            PrintShortScore("Cur Hit Points ", Game.Health.IntValue, 31, 52, ColorEnum.BrightYellow);
        }
        else
        {
            PrintShortScore("Cur Hit Points ", Game.Health.IntValue, 31, 52, ColorEnum.BrightRed);
        }
        PrintShortScore("Max SP (Mana)  ", Game.MaxMana.IntValue, 32, 52, ColorEnum.Green);
        if (Game.Mana.IntValue >= Game.MaxMana.IntValue)
        {
            PrintShortScore("Cur SP (Mana)  ", Game.Mana.IntValue, 33, 52, ColorEnum.Green);
        }
        else if (Game.Mana.IntValue > Game.MaxMana.IntValue * Constants.HitpointWarn / 10)
        {
            PrintShortScore("Cur SP (Mana)  ", Game.Mana.IntValue, 33, 52, ColorEnum.BrightYellow);
        }
        else
        {
            PrintShortScore("Cur SP (Mana)  ", Game.Mana.IntValue, 33, 52, ColorEnum.BrightRed);
        }
        PrintLongScore("Gold           ", Game.Gold.IntValue, 34, 52, ColorEnum.Green);
    }

    /// <summary>
    /// Display the player's character history
    /// </summary>
    private void DisplayPlayerHistory()
    {
        for (int i = 0; i < 4; i++)
        {
            Game.Screen.Print(ColorEnum.Brown, Game.History[i], i + 9, 10);
        }
    }

    /// <summary>
    /// Display ther player's skills
    /// </summary>
    private void DisplayPlayerSkills()
    {
        MeleeWeaponWieldSlot meeleeWeaponInventorySlot = (MeleeWeaponWieldSlot)Game.SingletonRepository.Get<WieldSlot>(nameof(MeleeWeaponWieldSlot));
        int index = meeleeWeaponInventorySlot.WeightedRandom.ChooseOrDefault();
        Item? meeleeItem = Game.GetInventoryItem(index);

        int dambonus = Game.Bonuses.DisplayedDamageBonus;
        // Only include weapon damage if the player knows what it is
        int damdice = 0;
        int damsides = 0;
        int fighting = Game.SkillMelee + (Game.Bonuses.AttackBonus * Constants.BthPlusAdj);
        if (meeleeItem != null)
        {
            fighting += meeleeItem.EffectivePropertySet.BonusHit * Constants.BthPlusAdj;
            damdice += meeleeItem.EffectivePropertySet.DamageDice;
            damsides += meeleeItem.DamageSides;

            if (meeleeItem.IsKnown())
            {
                dambonus += meeleeItem.EffectivePropertySet.BonusDamage;
            }
        }

        RangedWeaponWieldSlot rangedWeaponInventorySlot = (RangedWeaponWieldSlot)Game.SingletonRepository.Get<WieldSlot>(nameof(RangedWeaponWieldSlot));
        Item? rangedItem = Game.GetInventoryItem(rangedWeaponInventorySlot.WeightedRandom.ChooseOrDefault());
        int shooting = Game.SkillRanged + (Game.Bonuses.AttackBonus * Constants.BthPlusAdj);
        if (rangedItem != null)
        {
            shooting += rangedItem.EffectivePropertySet.BonusHit * Constants.BthPlusAdj;
        }

        int attacksPerRound = Game.MeleeAttacksPerRound;
        int disarmTraps = Game.SkillDisarmTraps;
        int useDevice = Game.SkillUseDevice;
        int savingThrow = Game.SkillSavingThrow;
        int stealth = Game.SkillStealth;
        int searching = Game.SkillSearching;
        int searchFrequency = Game.SkillSearchFrequency;
        Game.Screen.Print(ColorEnum.Blue, "Fighting    :", 36, 1);
        PrintCategorisedNumber(fighting, 12, 36, 15);
        Game.Screen.Print(ColorEnum.Blue, "Shooting    :", 37, 1);
        PrintCategorisedNumber(shooting, 12, 37, 15);
        Game.Screen.Print(ColorEnum.Blue, "Saving Throw:", 38, 1);
        PrintCategorisedNumber(savingThrow, 6, 38, 15);
        Game.Screen.Print(ColorEnum.Blue, "Stealth     :", 39, 1);
        PrintCategorisedNumber(stealth, 1, 39, 15);
        Game.Screen.Print(ColorEnum.Blue, "Perception  :", 36, 28);
        PrintCategorisedNumber(searchFrequency, 6, 36, 42);
        Game.Screen.Print(ColorEnum.Blue, "Searching   :", 37, 28);
        PrintCategorisedNumber(searching, 6, 37, 42);
        Game.Screen.Print(ColorEnum.Blue, "Disarming   :", 38, 28);
        PrintCategorisedNumber(disarmTraps, 8, 38, 42);
        Game.Screen.Print(ColorEnum.Blue, "Magic Device:", 39, 28);
        PrintCategorisedNumber(useDevice, 6, 39, 42);
        Game.Screen.Print(ColorEnum.Blue, "Blows/Action:", 36, 55);
        Game.Screen.Print(ColorEnum.Green, $"{Game.MeleeAttacksPerRound}", 36, 69);
        Game.Screen.Print(ColorEnum.Blue, "Tot.Dmg./Act:", 37, 55);
        // Work out damage per action
        var buf = string.Empty;
        if (damdice == 0 || damsides == 0)
        {
            buf = dambonus <= 0 ? "nil!" : $"{attacksPerRound * dambonus}";
        }
        else
        {
            buf = dambonus == 0
                ? $"{attacksPerRound * damdice}d{damsides}"
                : $"{attacksPerRound * damdice}d{damsides}{attacksPerRound * dambonus:+0;-0;+0}";
        }
        Game.Screen.Print(ColorEnum.Green, buf, 37, 69);
        Game.Screen.Print(ColorEnum.Blue, "Shots/Action:", 38, 55);
        Game.Screen.Print(ColorEnum.Green, $"{Game.MissileAttacksPerRound}", 38, 69);
        Game.Screen.Print(ColorEnum.Blue, "Infra-Vision:", 39, 55);
        Game.Screen.Print(ColorEnum.Green, $"{Game.InfravisionRange * 10} feet", 39, 69);
    }

    /// <summary>
    /// Display the top panel of the character sheet with name, race, age, and so forth
    /// </summary>
    private void DisplayPlayerTop()
    {
        Game.Screen.Print(ColorEnum.Blue, "Name        :", 2, 1);
        Game.Screen.Print(ColorEnum.Blue, "Gender      :", 3, 1);
        Game.Screen.Print(ColorEnum.Blue, "Race        :", 4, 1);
        Game.Screen.Print(ColorEnum.Blue, "Class       :", 5, 1);
        if (Game.CanCastSpells)
        {
            Game.Screen.Print(ColorEnum.Blue, "Magic       :", 6, 1);
        }
        Game.Screen.Print(ColorEnum.Brown, Game.PlayerName.StringValue, 2, 15);
        Game.Screen.Print(ColorEnum.Brown, Game.Gender.Title, 3, 15);
        Game.Screen.Print(ColorEnum.Brown, Game.Race.Title, 4, 15);
        Game.Screen.Print(ColorEnum.Brown, Game.BaseCharacterClass.ClassSubName(Game.PrimaryRealm), 5, 15);
        // Only print realms if we have them
        if (Game.PrimaryRealm != null)
        {
            string realmBuff = Game.RealmNames(Game.PrimaryRealm, Game.SecondaryRealm);
            Game.Screen.Print(ColorEnum.Brown, realmBuff, 6, 15);
        }
        // Fanatics and Cultists get a patron
        if (Game.BaseCharacterClass.ID == CharacterClassEnum.Fanatic || Game.BaseCharacterClass.ID == CharacterClassEnum.Cultist)
        {
            Game.Screen.Print(ColorEnum.Blue, "Patron      :", 7, 1);
            Game.Screen.Print(ColorEnum.Brown, Game.GooPatron.LongName, 7, 15);
        }
        // Priests get a deity
        if (Game.God != null)
        {
            Game.Screen.Print(ColorEnum.Blue, "Deity       :", 7, 1);
            Game.Screen.Print(ColorEnum.Brown, Game.God.LongName, 7, 15);
        }
        Game.Screen.Print(ColorEnum.Blue, "Birthday", 2, 32);
        string dateBuff = Game.BirthdayText.PadLeft(8);
        Game.Screen.Print(ColorEnum.Brown, dateBuff, 2, 46);
        PrintShortScore("Age          ", Game.Age, 3, 32, ColorEnum.Brown);
        PrintShortScore("Height       ", Game.Height, 4, 32, ColorEnum.Brown);
        PrintShortScore("Weight       ", Game.Weight, 5, 32, ColorEnum.Brown);
        PrintShortScore("Social Class ", Game.SocialClass, 6, 32, ColorEnum.Brown);
        int i = 0;
        // Print a quick summary of ability scores, but no detail
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            string buf;
            if (ability.Innate < ability.InnateMax)
            {
                Game.Screen.Print(ColorEnum.Blue, ability.NameReduced, 2 + i, 61);
                int value = ability.Adjusted;
                buf = value.StatToString();
                Game.Screen.Print(ColorEnum.Red, buf, 2 + i, 66);
                value = ability.AdjustedMax;
                buf = value.StatToString();
                Game.Screen.Print(ColorEnum.Green, buf, 2 + i, 73);
            }
            else
            {
                Game.Screen.Print(ColorEnum.Blue, ability.Name, 2 + i, 61);
                buf = ability.Adjusted.StatToString();
                Game.Screen.Print(ColorEnum.Green, buf, 2 + i, 66);
            }
            i++;
        }
    }

    /// <summary>
    /// Print a number with a title, with a plus or minus sign
    /// </summary>
    /// <param name="title"> The title to put with the number </param>
    /// <param name="number"> The number </param>
    /// <param name="row"> The row on which to print </param>
    /// <param name="col"> The column in which to start printing </param>
    /// <param name="color"> The color in which to print the number </param>
    private void PrintBonus(string header, int num, int row, int col, ColorEnum color)
    {
        int len = header.Length;
        Game.Screen.Print(ColorEnum.Blue, header, row, col);
        Game.Screen.Print(ColorEnum.Blue, "   ", row, col + len);
        string outVal = num.ToString("+0;-0;0").PadLeft(6);
        Game.Screen.Print(color, outVal, row, col + len + 3);
    }

    /// <summary>
    /// Use a scale to divide a score into categories to show how good the score is
    /// </summary>
    /// <param name="score"> The score to be displayed </param>
    /// <param name="divider"> The divider for categories </param>
    /// <param name="screenRow"> The row at which to print the text </param>
    /// <param name="screenCol"> The column at which to print the text </param>
    private void PrintCategorisedNumber(int score, int divider, int screenRow, int screenCol)
    {
        if (divider <= 0)
        {
            divider = 1;
        }
        ColorEnum color;
        string text;
        var scoreString = (score.ToString() + "%").PadLeft(4);
        if (score < 0)
        {
            color = ColorEnum.Black;
            text = $"Awful {score}%";
        }
        else
        {
            switch (score / divider)
            {
                case 0:
                case 1:
                    {
                        color = ColorEnum.Red;
                        text = $"Bad     {scoreString}";
                        break;
                    }
                case 2:
                    {
                        color = ColorEnum.BrightRed;
                        text = $"Poor    {scoreString}";
                        break;
                    }
                case 3:
                case 4:
                    {
                        color = ColorEnum.Pink;
                        text = $"Medium  {scoreString}";
                        break;
                    }
                case 5:
                    {
                        color = ColorEnum.Orange;
                        text = $"Fair    {scoreString}";
                        break;
                    }
                case 6:
                    {
                        color = ColorEnum.BrightYellow;
                        text = $"Good    {scoreString}";
                        break;
                    }
                case 7:
                case 8:
                    {
                        color = ColorEnum.Green;
                        text = $"Great   {scoreString}";
                        break;
                    }
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    {
                        color = ColorEnum.BrightGreen;
                        text = $"Superb  {scoreString}";
                        break;
                    }
                case 14:
                case 15:
                case 16:
                case 17:
                    {
                        color = ColorEnum.Blue;
                        text = $"Amazing {scoreString}";
                        break;
                    }
                default:
                    {
                        color = ColorEnum.Purple;
                        text = $"Stellar {scoreString}";
                        break;
                    }
            }
        }
        Game.Screen.Print(color, text, screenRow, screenCol);
    }

    /// <summary>
    /// Print a number with a title, justified to nine characters
    /// </summary>
    /// <param name="title"> The title to put with the number </param>
    /// <param name="number"> The number </param>
    /// <param name="row"> The row on which to print </param>
    /// <param name="col"> The column in which to start printing </param>
    /// <param name="color"> The color in which to print the number </param>
    private void PrintLongScore(string title, int number, int row, int col, ColorEnum color)
    {
        int len = title.Length;
        Game.Screen.Print(ColorEnum.Blue, title, row, col);
        string outVal = number.ToString().PadLeft(9);
        Game.Screen.Print(color, outVal, row, col + len);
    }

    /// <summary>
    /// Print a number with a title, justified to six characters
    /// </summary>
    /// <param name="title"> The title to put with the number </param>
    /// <param name="number"> The number </param>
    /// <param name="row"> The row on which to print </param>
    /// <param name="col"> The column in which to start printing </param>
    /// <param name="color"> The color in which to print the number </param>
    private void PrintShortScore(string header, int num, int row, int col, ColorEnum color)
    {
        int len = header.Length;
        Game.Screen.Print(ColorEnum.Blue, header, row, col);
        Game.Screen.Print(ColorEnum.Blue, "   ", row, col + len);
        string outVal = num.ToString().PadLeft(6);
        Game.Screen.Print(color, outVal, row, col + len + 3);
    }
}
