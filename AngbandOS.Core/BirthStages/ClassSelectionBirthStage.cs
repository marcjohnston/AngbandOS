namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class ClassSelectionBirthStage : BaseBirthStage
{
    private int currentSelection = 14;
    private ClassSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
    public override BaseBirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = SaveGame.SingletonRepository.CharacterClasses
            .OrderBy(_characterClass => _characterClass.Title)
            .Select(_characterClass => _characterClass.Title)
            .ToArray(); ;
        SaveGame.Screen.Print(Colour.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
        while (!SaveGame.Shutdown)
        {
            SaveGame.MenuDisplay(currentSelection, menuItems);
            RenderSelection(currentSelection);
            char c = SaveGame.Inkey();
            switch (c)
            {
                case '8':
                    if (currentSelection > 0)
                    {
                        currentSelection--;
                    }
                    break;
                case '2':
                    if (currentSelection < menuItems.Length - 1)
                    {
                        currentSelection++;
                    }
                    break;
                case '6':
                    return GoForward(currentSelection);
                case '4':
                    return GoBack();
                case 'h':
                    SaveGame.ShowManual();
                    break;
            }
        }
        return null;
    }

    /// <summary>
    /// Renders the details of a Character Class during the Birth selection process.
    /// </summary>
    /// <param name="characterClass"></param>

    private bool RenderSelection(int index)
    {
        BaseCharacterClass[] classes = SaveGame.SingletonRepository.CharacterClasses
            .OrderBy(_characterClass => _characterClass.Title)
            .ToArray();

        BaseCharacterClass characterClass = classes[index];
        SaveGame.Screen.Print(Colour.Purple, "STR:", 36, 21);
        SaveGame.Screen.Print(Colour.Purple, "INT:", 37, 21);
        SaveGame.Screen.Print(Colour.Purple, "WIS:", 38, 21);
        SaveGame.Screen.Print(Colour.Purple, "DEX:", 39, 21);
        SaveGame.Screen.Print(Colour.Purple, "CON:", 40, 21);
        SaveGame.Screen.Print(Colour.Purple, "CHA:", 41, 21);
        for (int i = 0; i < 6; i++)
        {
            int bonus = characterClass.AbilityBonus[i];
            SaveGame.DisplayStatBonus(26, 36 + i, bonus);
        }
        SaveGame.Screen.Print(Colour.Purple, "Disarming   :", 36, 53);
        SaveGame.Screen.Print(Colour.Purple, "Magic Device:", 37, 53);
        SaveGame.Screen.Print(Colour.Purple, "Saving Throw:", 38, 53);
        SaveGame.Screen.Print(Colour.Purple, "Stealth     :", 39, 53);
        SaveGame.Screen.Print(Colour.Purple, "Fighting    :", 40, 53);
        SaveGame.Screen.Print(Colour.Purple, "Shooting    :", 41, 53);
        SaveGame.Screen.Print(Colour.Purple, "Experience  :", 36, 31);
        SaveGame.Screen.Print(Colour.Purple, "Hit Dice    :", 37, 31);
        SaveGame.Screen.Print(Colour.Purple, "Infravision :", 38, 31);
        SaveGame.Screen.Print(Colour.Purple, "Searching   :", 39, 31);
        SaveGame.Screen.Print(Colour.Purple, "Perception  :", 40, 31);
        SaveGame.DisplayAPlusB(67, 36, characterClass.BaseDisarmBonus, characterClass.DisarmBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 37, characterClass.BaseDeviceBonus, characterClass.DeviceBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 38, characterClass.BaseSaveBonus, characterClass.SaveBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 39, characterClass.BaseStealthBonus * 4, characterClass.StealthBonusPerLevel * 4);
        SaveGame.DisplayAPlusB(67, 40, characterClass.BaseMeleeAttackBonus, characterClass.MeleeAttackBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 41, characterClass.BaseRangedAttackBonus, characterClass.RangedAttackBonusPerLevel);
        string buf = "+" + characterClass.ExperienceFactor + "%";
        SaveGame.Screen.Print(Colour.Black, buf, 36, 45);
        buf = "1d" + characterClass.HitDieBonus;
        SaveGame.Screen.Print(Colour.Black, buf, 37, 45);
        SaveGame.Screen.Print(Colour.Black, "-", 38, 45);
        buf = $"{characterClass.BaseSearchBonus:00}%";
        SaveGame.Screen.Print(Colour.Black, buf, 39, 45);
        buf = $"{characterClass.BaseSearchFrequency:00}%";
        SaveGame.Screen.Print(Colour.Black, buf, 40, 45);

        int y = 30;
        foreach (string classInfo in characterClass.Info)
        {
            SaveGame.Screen.Print(Colour.Purple, classInfo, y, 20);
            y++;
        }
        return true;
    }
    private BaseBirthStage? GoForward(int index)
    {
        BaseCharacterClass[] classes = SaveGame.SingletonRepository.CharacterClasses
            .OrderBy(_characterClass => _characterClass.Title)
            .ToArray();

        SaveGame.Player.BaseCharacterClass = classes[index];
        return SaveGame.SingletonRepository.BirthStages.Get<RaceSelectionBirthStage>();
    }

    private BaseBirthStage? GoBack()
    {
        return SaveGame.SingletonRepository.BirthStages.Get<IntroductionBirthStage>();
    }
}