﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RenderCharacterScript : Script
{
    private RenderCharacterScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Display the player's entire character sheet.  Returns true.
    /// </summary>
    public override bool Execute()
    {
        SaveGame.Screen.Clear(0);
        DisplayPlayerTop();
        DisplayPlayerHistory();
        DisplayPlayerAbilityScoresWithEffects();
        DisplayPlayerAbilityScoresWithModifiers();
        DisplayPlayerEssentials();
        DisplayPlayerSkills();
        return true;
    }

    /// <summary>
    /// Create a summary of the bonuses given by a specific ability score
    /// </summary>
    /// <param name="abilityIndex"> The index of the ability score to summarise </param>
    /// <returns> The summary of the score's bonuses </returns>
    private string AbilitySummary(int abilityIndex)
    {
        // The summary will have up to five sections
        string bonus1 = string.Empty;
        string bonus2 = string.Empty;
        string bonus3 = string.Empty;
        string bonus4 = string.Empty;
        string bonus5 = string.Empty;
        // Get the score
        AbilityScore ability = SaveGame.AbilityScores[abilityIndex];
        // Fill in up to five pieces of bonus text
        switch (abilityIndex)
        {
            case Ability.Strength:
                int toHit = ability.StrAttackBonus;
                bonus1 = $"{toHit:+0;-0;+0} to hit";
                int toDam = ability.StrDamageBonus;
                bonus2 = $", {toDam:+0;-0;+0} damage";
                int carry = ability.StrCarryingCapacity * 5;
                bonus3 = $", carry {carry}lb";
                int weap = ability.StrMaxWeaponWeight;
                bonus4 = $", wield {weap}lb";
                int dig = ability.StrDiggingBonus;
                bonus5 = $", {dig}% digging";
                break;

            case Ability.Intelligence:
                int device = ability.IntUseDeviceBonus;
                bonus1 = $"{device:+0;-0;+0} device";
                int disarm = ability.IntDisarmBonus;
                bonus2 = $", {disarm:+0;-0;+0}% disarm";
                break;

            case Ability.Wisdom:
                int save = ability.WisSavingThrowBonus;
                bonus1 = $"{save:+0;-0;+0} save";
                break;

            case Ability.Dexterity:
                toHit = ability.DexAttackBonus;
                bonus1 = $"{toHit:+0;-0;+0} to hit";
                disarm = ability.DexDisarmBonus;
                bonus2 = $", {disarm:+0;-0;+0}% disarm";
                int ac = ability.DexArmourClassBonus;
                bonus3 = $", {ac:+0;-0;+0} AC";
                int theft = ability.DexTheftAvoidance;
                bonus4 = $", {theft}% anti-theft";
                break;

            case Ability.Constitution:
                int hits = ability.ConHealthBonus;
                if (hits == -1)
                {
                    bonus1 = "-0.5 HP/lvl";
                }
                else
                {
                    bonus1 = hits % 2 == 0 ? $"{hits / 2:+0;-0;+0} HP/lvl" : $"{hits / 2:+0;-0;+0}.5 HP/lvl";
                }
                int regen = ability.ConRecoverySpeed;
                bonus2 = $", x{regen + 1} recovery";
                break;

            case Ability.Charisma:
                int haggle = ability.ChaPriceAdjustment;
                bonus1 = $"{haggle}% prices";
                break;
        }
        // Add the bonus text for spell casting abilities
        if (SaveGame.BaseCharacterClass.SpellStat == abilityIndex && abilityIndex != Ability.Strength)
        {
            int mana = ability.ManaBonus;
            // Casting abilities only have one or two inherent bonuses, so it's safe to start at three
            bonus3 = mana % 2 == 0 ? $", {mana / 2} SP/lvl" : $", {mana / 2}.5 SP/lvl";
            // Not all casting classes have actual spells
            if (SaveGame.BaseCharacterClass.ID != CharacterClass.Mindcrafter && SaveGame.BaseCharacterClass.ID != CharacterClass.Mystic && SaveGame.BaseCharacterClass.ID != CharacterClass.Channeler)
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
            if (SaveGame.BaseCharacterClass.ID != CharacterClass.Channeler)
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
        for (int i = 0; i < 6; i++)
        {
            string buf;
            // If they've been drained, make them visually distinct
            if (SaveGame.AbilityScores[i].Innate < SaveGame.AbilityScores[i].InnateMax)
            {
                SaveGame.Screen.Print(ColourEnum.Blue, Constants.StatNamesReduced[i], 14 + i, 1);
                int value = SaveGame.AbilityScores[i].Adjusted;
                buf = value.StatToString();
                SaveGame.Screen.Print(ColourEnum.Grey, buf, 14 + i, 6);
                buf = AbilitySummary(i);
                SaveGame.Screen.Print(ColourEnum.Grey, buf, i + 14, 13);
            }
            else
            {
                SaveGame.Screen.Print(ColourEnum.Blue, Constants.StatNames[i], 14 + i, 1);
                buf = SaveGame.AbilityScores[i].Adjusted.StatToString();
                SaveGame.Screen.Print(ColourEnum.Green, buf, 14 + i, 6);
                buf = AbilitySummary(i);
                SaveGame.Screen.Print(ColourEnum.Green, buf, i + 14, 13);
            }
        }
    }

    private void ShowBonus(bool hasSustain, bool hasStat, int typeSpecificValue, int row, int col)
    {
        if (hasSustain)
        {
            // Sustains show a green 's'
            SaveGame.Screen.Print(ColourEnum.Green, "s", row, col);
        }
        else if (hasStat)
        {
            // Show stat
            if (typeSpecificValue <= -10)
            {
                // Max display for negative value
                SaveGame.Screen.Print(ColourEnum.Red, "*", row, col);
            }
            else if (typeSpecificValue < 0)
            {
                // Display negative value
                SaveGame.Screen.Print(ColourEnum.Red, (char)('0' - (char)typeSpecificValue), row, col);
            }
            else if (typeSpecificValue >= 10)
            {
                // Display max 
                SaveGame.Screen.Print(ColourEnum.Green, "*", row, col);
            }
            else if (typeSpecificValue > 0)
            {
                // Display positive value
                SaveGame.Screen.Print(ColourEnum.Green, (char)('0' + (char)typeSpecificValue), row, col);
            }
        }
        else
        {
            // Display neutral
            SaveGame.Screen.Print(ColourEnum.Grey, ".", row, col);
        }
    }

    /// <summary>
    /// Display the ability scores including details of any modifiers to them
    /// </summary>
    private void DisplayPlayerAbilityScoresWithModifiers()
    {
        const int statCol = 1;
        const int row = 22;
        SaveGame.Screen.Print(ColourEnum.Purple, "Initial", row - 1, statCol + 5);
        SaveGame.Screen.Print(ColourEnum.Brown, "Race Class Mods", row - 1, statCol + 13);
        SaveGame.Screen.Print(ColourEnum.Green, "Actual", row - 1, statCol + 29);
        SaveGame.Screen.Print(ColourEnum.Red, "Reduced", row - 1, statCol + 36);
        // Loop through the scores
        for (int i = 0; i < 6; i++)
        {
            // Reverse engineer our equipment bonuses from our score
            int equipmentBonuses = 0;
            if (SaveGame.AbilityScores[i].InnateMax > 18 && SaveGame.AbilityScores[i].AdjustedMax > 18)
            {
                equipmentBonuses = (SaveGame.AbilityScores[i].AdjustedMax - SaveGame.AbilityScores[i].InnateMax) / 10;
            }
            if (SaveGame.AbilityScores[i].InnateMax <= 18 && SaveGame.AbilityScores[i].AdjustedMax <= 18)
            {
                equipmentBonuses = SaveGame.AbilityScores[i].AdjustedMax - SaveGame.AbilityScores[i].InnateMax;
            }
            if (SaveGame.AbilityScores[i].InnateMax <= 18 && SaveGame.AbilityScores[i].AdjustedMax > 18)
            {
                equipmentBonuses = ((SaveGame.AbilityScores[i].AdjustedMax - 18) / 10) - SaveGame.AbilityScores[i].InnateMax + 18;
            }
            if (SaveGame.AbilityScores[i].InnateMax > 18 && SaveGame.AbilityScores[i].AdjustedMax <= 18)
            {
                equipmentBonuses = SaveGame.AbilityScores[i].AdjustedMax - ((SaveGame.AbilityScores[i].InnateMax - 18) / 10) - 19;
            }
            // Take out the bonuses we got for our our race and profession
            equipmentBonuses -= SaveGame.Race.AbilityBonus[i];
            equipmentBonuses -= SaveGame.BaseCharacterClass.AbilityBonus[i];
            // Print each of the scores and bonuses
            SaveGame.Screen.Print(ColourEnum.Blue, Constants.StatNames[i], row + i, statCol);
            string buf = SaveGame.AbilityScores[i].InnateMax.StatToString();
            SaveGame.Screen.Print(ColourEnum.Purple, buf, row + i, statCol + 4);
            buf = SaveGame.Race.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3);
            SaveGame.Screen.Print(ColourEnum.Brown, buf, row + i, statCol + 13);
            buf = SaveGame.BaseCharacterClass.AbilityBonus[i].ToString("+0;-0;+0").PadLeft(3);
            SaveGame.Screen.Print(ColourEnum.Brown, buf, row + i, statCol + 19);
            buf = equipmentBonuses.ToString("+0;-0;+0").PadLeft(3);
            SaveGame.Screen.Print(ColourEnum.Brown, buf, row + i, statCol + 24);
            buf = SaveGame.AbilityScores[i].AdjustedMax.StatToString();
            SaveGame.Screen.Print(ColourEnum.Green, buf, row + i, statCol + 27);
            if (SaveGame.AbilityScores[i].Adjusted < SaveGame.AbilityScores[i].AdjustedMax)
            {
                buf = SaveGame.AbilityScores[i].Adjusted.StatToString();
                SaveGame.Screen.Print(ColourEnum.Red, buf, row + i, statCol + 35);
            }
        }

        // Print the bonuses for each score and each item we have
        int col = statCol + 44;
        SaveGame.Screen.Print(ColourEnum.Blue, "abcdefghijklm@", row - 1, col);
        SaveGame.Screen.Print(ColourEnum.Blue, "Modifications", row + 6, col);
        foreach (BaseInventorySlot inventorySlot in SaveGame.SingletonRepository.InventorySlots.Where(_inventorySlot => _inventorySlot.IsEquipment))
        {
            foreach (int i in inventorySlot.InventorySlots)
            {
                ItemCharacteristics itemCharacteristics;
                int typeSpecificValue;

                Item? item = SaveGame.GetInventoryItem(i);
                if (item == null)
                {
                    itemCharacteristics = new ItemCharacteristics();
                    typeSpecificValue = 0;
                }
                else
                {
                    // Only extract known bonuses, not full bonuses
                    itemCharacteristics = item.ObjectFlagsKnown();
                    typeSpecificValue = item.TypeSpecificValue;
                }
                ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.Str, typeSpecificValue, row + 0, col);
                ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.Int, typeSpecificValue, row + 1, col);
                ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.Wis, typeSpecificValue, row + 2, col);
                ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.Dex, typeSpecificValue, row + 3, col);
                ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.Con, typeSpecificValue, row + 4, col);
                ShowBonus(itemCharacteristics.SustStr, itemCharacteristics.Cha, typeSpecificValue, row + 5, col);
                col++;
            }
        }

        ItemCharacteristics playerCharacteristics = SaveGame.GetAbilitiesAsItemFlags();
        DisplayPlayerStatWithModification(SaveGame.Dna.StrengthBonus, playerCharacteristics.Str, row + 0, col);
        DisplayPlayerStatWithModification(SaveGame.Dna.IntelligenceBonus, playerCharacteristics.Int, row + 1, col);
        DisplayPlayerStatWithModification(SaveGame.Dna.WisdomBonus, playerCharacteristics.Wis, row + 2, col);
        DisplayPlayerStatWithModification(SaveGame.Dna.DexterityBonus, playerCharacteristics.Dex, row + 3, col);
        DisplayPlayerStatWithModification(SaveGame.Dna.ConstitutionBonus, playerCharacteristics.Con, row + 4, col);
        DisplayPlayerStatWithModification(SaveGame.Dna.CharismaBonus, playerCharacteristics.Cha, row + 5, col);
    }

    private void DisplayPlayerStatWithModification(int extraModifier, bool isSet, int row, int col)
    {
        ColourEnum a = ColourEnum.Grey;
        char c = '.';
        if (extraModifier != 0)
        {
            c = '*';
            if (extraModifier > 0)
            {
                a = ColourEnum.Green;
                if (extraModifier < 10)
                {
                    c = (char)('0' + (char)extraModifier);
                }
            }
            if (extraModifier < 0)
            {
                a = ColourEnum.Red;
                if (extraModifier < 10)
                {
                    c = (char)('0' - (char)extraModifier);
                }
            }
        }
        if (isSet)
        {
            a = ColourEnum.Green;
            c = 's';
        }
        SaveGame.Screen.Print(a, c, row, col);
    }

    /// <summary>
    /// Display essential player information such as level, experience, gold, health, mana
    /// </summary>
    private void DisplayPlayerEssentials()
    {
        int showTohit = SaveGame.DisplayedAttackBonus;
        int showTodam = SaveGame.DisplayedDamageBonus;
        MeleeWeaponInventorySlot meeleeWeaponInventorySlot = SaveGame.SingletonRepository.InventorySlots.Get<MeleeWeaponInventorySlot>();
        Item? item = SaveGame.GetInventoryItem(meeleeWeaponInventorySlot.WeightedRandom.Choose());
        // Only show bonuses if we know them
        if (item != null && item.IsKnown())
        {
            showTohit += item.BonusToHit;
            showTodam += item.BonusDamage;
        }
        // Print some basics
        PrintBonus("+ To Hit    ", showTohit, 30, 1, ColourEnum.Brown);
        PrintBonus("+ To Damage ", showTodam, 31, 1, ColourEnum.Brown);
        PrintBonus("+ To AC     ", SaveGame.DisplayedArmourClassBonus, 32, 1, ColourEnum.Brown);
        PrintShortScore("  Base AC   ", SaveGame.DisplayedBaseArmourClass, 33, 1, ColourEnum.Brown);
        PrintShortScore("Level      ", SaveGame.ExperienceLevel, 30, 28, ColourEnum.Green);
        PrintLongScore("Experience ", SaveGame.ExperiencePoints, 31, 28,
            SaveGame.ExperiencePoints >= SaveGame.MaxExperienceGained ? ColourEnum.Green : ColourEnum.Red);
        PrintLongScore("Max Exp    ", SaveGame.MaxExperienceGained, 32, 28, ColourEnum.Green);
        // If we're max level we don't have any experience to advance
        if (SaveGame.ExperienceLevel >= Constants.PyMaxLevel)
        {
            SaveGame.Screen.Print(ColourEnum.Blue, "Exp to Adv.", 33, 28);
            SaveGame.Screen.Print(ColourEnum.Green, "    *****", 33, 28 + 11);
        }
        else
        {
            PrintLongScore("Exp to Adv.", (int)(Constants.PlayerExp[SaveGame.ExperienceLevel - 1] * SaveGame.ExperienceMultiplier / 100L), 33, 28,
                ColourEnum.Green);
        }
        PrintLongScore("Exp Factor ", SaveGame.ExperienceMultiplier, 34, 28, ColourEnum.Green);
        PrintShortScore("Max Hit Points ", SaveGame.MaxHealth, 30, 52, ColourEnum.Green);
        if (SaveGame.Health >= SaveGame.MaxHealth)
        {
            PrintShortScore("Cur Hit Points ", SaveGame.Health, 31, 52, ColourEnum.Green);
        }
        else if (SaveGame.Health > SaveGame.MaxHealth * Constants.HitpointWarn / 10)
        {
            PrintShortScore("Cur Hit Points ", SaveGame.Health, 31, 52, ColourEnum.BrightYellow);
        }
        else
        {
            PrintShortScore("Cur Hit Points ", SaveGame.Health, 31, 52, ColourEnum.BrightRed);
        }
        PrintShortScore("Max SP (Mana)  ", SaveGame.MaxMana, 32, 52, ColourEnum.Green);
        if (SaveGame.Mana >= SaveGame.MaxMana)
        {
            PrintShortScore("Cur SP (Mana)  ", SaveGame.Mana, 33, 52, ColourEnum.Green);
        }
        else if (SaveGame.Mana > SaveGame.MaxMana * Constants.HitpointWarn / 10)
        {
            PrintShortScore("Cur SP (Mana)  ", SaveGame.Mana, 33, 52, ColourEnum.BrightYellow);
        }
        else
        {
            PrintShortScore("Cur SP (Mana)  ", SaveGame.Mana, 33, 52, ColourEnum.BrightRed);
        }
        PrintLongScore("Gold           ", SaveGame.Gold, 34, 52, ColourEnum.Green);
    }

    /// <summary>
    /// Display the player's character history
    /// </summary>
    private void DisplayPlayerHistory()
    {
        for (int i = 0; i < 4; i++)
        {
            SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.History[i], i + 9, 10);
        }
    }

    /// <summary>
    /// Dislpay ther player's skills
    /// </summary>
    private void DisplayPlayerSkills()
    {
        MeleeWeaponInventorySlot meeleeWeaponInventorySlot = SaveGame.SingletonRepository.InventorySlots.Get<MeleeWeaponInventorySlot>();
        int index = meeleeWeaponInventorySlot.WeightedRandom.Choose();
        Item? meeleeItem = SaveGame.GetInventoryItem(index);

        int dambonus = SaveGame.DisplayedDamageBonus;
        // Only include weapon damage if the player knows what it is
        int damdice = 0;
        int damsides = 0;
        int fighting = SaveGame.SkillMelee + (SaveGame.AttackBonus * Constants.BthPlusAdj);
        if (meeleeItem != null)
        {
            fighting += meeleeItem.BonusToHit * Constants.BthPlusAdj;
            damdice += meeleeItem.DamageDice;
            damsides += meeleeItem.DamageDiceSides;

            if (meeleeItem.IsKnown())
            {
                dambonus += meeleeItem.BonusDamage;
            }
        }

        RangedWeaponInventorySlot rangedWeaponInventorySlot = SaveGame.SingletonRepository.InventorySlots.Get<RangedWeaponInventorySlot>();
        Item? rangedItem = SaveGame.GetInventoryItem(rangedWeaponInventorySlot.WeightedRandom.Choose());
        int shooting = SaveGame.SkillRanged + (SaveGame.AttackBonus * Constants.BthPlusAdj);
        if (rangedItem != null)
        {
            shooting += rangedItem.BonusToHit * Constants.BthPlusAdj;
        }

        int attacksPerRound = SaveGame.MeleeAttacksPerRound;
        int disarmTraps = SaveGame.SkillDisarmTraps;
        int useDevice = SaveGame.SkillUseDevice;
        int savingThrow = SaveGame.SkillSavingThrow;
        int stealth = SaveGame.SkillStealth;
        int searching = SaveGame.SkillSearching;
        int searchFrequency = SaveGame.SkillSearchFrequency;
        SaveGame.Screen.Print(ColourEnum.Blue, "Fighting    :", 36, 1);
        PrintCategorisedNumber(fighting, 12, 36, 15);
        SaveGame.Screen.Print(ColourEnum.Blue, "Shooting    :", 37, 1);
        PrintCategorisedNumber(shooting, 12, 37, 15);
        SaveGame.Screen.Print(ColourEnum.Blue, "Saving Throw:", 38, 1);
        PrintCategorisedNumber(savingThrow, 6, 38, 15);
        SaveGame.Screen.Print(ColourEnum.Blue, "Stealth     :", 39, 1);
        PrintCategorisedNumber(stealth, 1, 39, 15);
        SaveGame.Screen.Print(ColourEnum.Blue, "Perception  :", 36, 28);
        PrintCategorisedNumber(searchFrequency, 6, 36, 42);
        SaveGame.Screen.Print(ColourEnum.Blue, "Searching   :", 37, 28);
        PrintCategorisedNumber(searching, 6, 37, 42);
        SaveGame.Screen.Print(ColourEnum.Blue, "Disarming   :", 38, 28);
        PrintCategorisedNumber(disarmTraps, 8, 38, 42);
        SaveGame.Screen.Print(ColourEnum.Blue, "Magic Device:", 39, 28);
        PrintCategorisedNumber(useDevice, 6, 39, 42);
        SaveGame.Screen.Print(ColourEnum.Blue, "Blows/Action:", 36, 55);
        SaveGame.Screen.Print(ColourEnum.Green, $"{SaveGame.MeleeAttacksPerRound}", 36, 69);
        SaveGame.Screen.Print(ColourEnum.Blue, "Tot.Dmg./Act:", 37, 55);
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
        SaveGame.Screen.Print(ColourEnum.Green, buf, 37, 69);
        SaveGame.Screen.Print(ColourEnum.Blue, "Shots/Action:", 38, 55);
        SaveGame.Screen.Print(ColourEnum.Green, $"{SaveGame.MissileAttacksPerRound}", 38, 69);
        SaveGame.Screen.Print(ColourEnum.Blue, "Infra-Vision:", 39, 55);
        SaveGame.Screen.Print(ColourEnum.Green, $"{SaveGame.InfravisionRange * 10} feet", 39, 69);
    }

    /// <summary>
    /// Display the top panel of the character sheet with name, race, age, and so forth
    /// </summary>
    private void DisplayPlayerTop()
    {
        SaveGame.Screen.Print(ColourEnum.Blue, "Name        :", 2, 1);
        SaveGame.Screen.Print(ColourEnum.Blue, "Gender      :", 3, 1);
        SaveGame.Screen.Print(ColourEnum.Blue, "Race        :", 4, 1);
        SaveGame.Screen.Print(ColourEnum.Blue, "Class       :", 5, 1);
        if (SaveGame.CanCastSpells)
        {
            SaveGame.Screen.Print(ColourEnum.Blue, "Magic       :", 6, 1);
        }
        SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.Name, 2, 15);
        SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.Gender.Title, 3, 15);
        SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.Race.Title, 4, 15);
        SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.BaseCharacterClass.ClassSubName(SaveGame.PrimaryRealm), 5, 15);
        // Only print realms if we have them
        if (SaveGame.PrimaryRealm != null)
        {
            string realmBuff = SaveGame.RealmNames(SaveGame.PrimaryRealm, SaveGame.SecondaryRealm);
            SaveGame.Screen.Print(ColourEnum.Brown, realmBuff, 6, 15);
        }
        // Fanatics and Cultists get a patron
        if (SaveGame.BaseCharacterClass.ID == CharacterClass.Fanatic || SaveGame.BaseCharacterClass.ID == CharacterClass.Cultist)
        {
            SaveGame.Screen.Print(ColourEnum.Blue, "Patron      :", 7, 1);
            SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.GooPatron.LongName, 7, 15);
        }
        // Priests get a deity
        if (SaveGame.Religion.Deity != GodName.None)
        {
            SaveGame.Screen.Print(ColourEnum.Blue, "Deity       :", 7, 1);
            SaveGame.Screen.Print(ColourEnum.Brown, SaveGame.Religion.GetPatronDeity().LongName, 7, 15);
        }
        SaveGame.Screen.Print(ColourEnum.Blue, "Birthday", 2, 32);
        string dateBuff = SaveGame.GameTime.BirthdayText.PadLeft(8);
        SaveGame.Screen.Print(ColourEnum.Brown, dateBuff, 2, 46);
        PrintShortScore("Age          ", SaveGame.Age, 3, 32, ColourEnum.Brown);
        PrintShortScore("Height       ", SaveGame.Height, 4, 32, ColourEnum.Brown);
        PrintShortScore("Weight       ", SaveGame.Weight, 5, 32, ColourEnum.Brown);
        PrintShortScore("Social Class ", SaveGame.SocialClass, 6, 32, ColourEnum.Brown);
        int i;
        // Print a quick summary of ability scores, but no detail
        for (i = 0; i < 6; i++)
        {
            string buf;
            if (SaveGame.AbilityScores[i].Innate < SaveGame.AbilityScores[i].InnateMax)
            {
                SaveGame.Screen.Print(ColourEnum.Blue, Constants.StatNamesReduced[i], 2 + i, 61);
                int value = SaveGame.AbilityScores[i].Adjusted;
                buf = value.StatToString();
                SaveGame.Screen.Print(ColourEnum.Red, buf, 2 + i, 66);
                value = SaveGame.AbilityScores[i].AdjustedMax;
                buf = value.StatToString();
                SaveGame.Screen.Print(ColourEnum.Green, buf, 2 + i, 73);
            }
            else
            {
                SaveGame.Screen.Print(ColourEnum.Blue, Constants.StatNames[i], 2 + i, 61);
                buf = SaveGame.AbilityScores[i].Adjusted.StatToString();
                SaveGame.Screen.Print(ColourEnum.Green, buf, 2 + i, 66);
            }
        }
    }

    /// <summary>
    /// Print a number with a title, with a plus or minus sign
    /// </summary>
    /// <param name="title"> The title to put with the number </param>
    /// <param name="number"> The number </param>
    /// <param name="row"> The row on which to print </param>
    /// <param name="col"> The column in which to start printing </param>
    /// <param name="colour"> The colour in which to print the number </param>
    private void PrintBonus(string header, int num, int row, int col, ColourEnum colour)
    {
        int len = header.Length;
        SaveGame.Screen.Print(ColourEnum.Blue, header, row, col);
        SaveGame.Screen.Print(ColourEnum.Blue, "   ", row, col + len);
        string outVal = num.ToString("+0;-0;0").PadLeft(6);
        SaveGame.Screen.Print(colour, outVal, row, col + len + 3);
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
        ColourEnum colour;
        string text;
        var scoreString = (score.ToString() + "%").PadLeft(4);
        if (score < 0)
        {
            colour = ColourEnum.Black;
            text = $"Awful {score}%";
        }
        else
        {
            switch (score / divider)
            {
                case 0:
                case 1:
                    {
                        colour = ColourEnum.Red;
                        text = $"Bad     {scoreString}";
                        break;
                    }
                case 2:
                    {
                        colour = ColourEnum.BrightRed;
                        text = $"Poor    {scoreString}";
                        break;
                    }
                case 3:
                case 4:
                    {
                        colour = ColourEnum.Pink;
                        text = $"Medium  {scoreString}";
                        break;
                    }
                case 5:
                    {
                        colour = ColourEnum.Orange;
                        text = $"Fair    {scoreString}";
                        break;
                    }
                case 6:
                    {
                        colour = ColourEnum.BrightYellow;
                        text = $"Good    {scoreString}";
                        break;
                    }
                case 7:
                case 8:
                    {
                        colour = ColourEnum.Green;
                        text = $"Great   {scoreString}";
                        break;
                    }
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                    {
                        colour = ColourEnum.BrightGreen;
                        text = $"Superb  {scoreString}";
                        break;
                    }
                case 14:
                case 15:
                case 16:
                case 17:
                    {
                        colour = ColourEnum.Blue;
                        text = $"Amazing {scoreString}";
                        break;
                    }
                default:
                    {
                        colour = ColourEnum.Purple;
                        text = $"Stellar {scoreString}";
                        break;
                    }
            }
        }
        SaveGame.Screen.Print(colour, text, screenRow, screenCol);
    }

    /// <summary>
    /// Print a number with a title, justified to nine characters
    /// </summary>
    /// <param name="title"> The title to put with the number </param>
    /// <param name="number"> The number </param>
    /// <param name="row"> The row on which to print </param>
    /// <param name="col"> The column in which to start printing </param>
    /// <param name="colour"> The colour in which to print the number </param>
    private void PrintLongScore(string title, int number, int row, int col, ColourEnum colour)
    {
        int len = title.Length;
        SaveGame.Screen.Print(ColourEnum.Blue, title, row, col);
        string outVal = number.ToString().PadLeft(9);
        SaveGame.Screen.Print(colour, outVal, row, col + len);
    }

    /// <summary>
    /// Print a number with a title, justified to six characters
    /// </summary>
    /// <param name="title"> The title to put with the number </param>
    /// <param name="number"> The number </param>
    /// <param name="row"> The row on which to print </param>
    /// <param name="col"> The column in which to start printing </param>
    /// <param name="colour"> The colour in which to print the number </param>
    private void PrintShortScore(string header, int num, int row, int col, ColourEnum colour)
    {
        int len = header.Length;
        SaveGame.Screen.Print(ColourEnum.Blue, header, row, col);
        SaveGame.Screen.Print(ColourEnum.Blue, "   ", row, col + len);
        string outVal = num.ToString().PadLeft(6);
        SaveGame.Screen.Print(colour, outVal, row, col + len + 3);
    }
}