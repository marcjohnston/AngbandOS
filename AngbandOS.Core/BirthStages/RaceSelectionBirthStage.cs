namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class RaceSelectionBirthStage : BaseBirthStage
{
    private int currentSelection = 16;
    private RaceSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
    public override BaseBirthStage? Render()
    {
        DisplayPartialCharacter();
        string[]? menuItems = SaveGame.SingletonRepository.Races
            .OrderBy((Race race) => race.Title)
            .Select((Race race) => race.Title)
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

    private bool RenderSelection(int index)
    {
        Race[] races = SaveGame.SingletonRepository.Races
            .OrderBy((Race race) => race.Title)
            .ToArray();
        Race race = races[index];
        SaveGame.Screen.Print(Colour.Purple, "STR:", 36, 21);
        SaveGame.Screen.Print(Colour.Purple, "INT:", 37, 21);
        SaveGame.Screen.Print(Colour.Purple, "WIS:", 38, 21);
        SaveGame.Screen.Print(Colour.Purple, "DEX:", 39, 21);
        SaveGame.Screen.Print(Colour.Purple, "CON:", 40, 21);
        SaveGame.Screen.Print(Colour.Purple, "CHA:", 41, 21);
        for (int i = 0; i < 6; i++)
        {
            int bonus = race.AbilityBonus[i] + SaveGame.Player.BaseCharacterClass.AbilityBonus[i];
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
        SaveGame.DisplayAPlusB(67, 36, SaveGame.Player.BaseCharacterClass.BaseDisarmBonus + race.BaseDisarmBonus, SaveGame.Player.BaseCharacterClass.DisarmBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 37, SaveGame.Player.BaseCharacterClass.BaseDeviceBonus + race.BaseDeviceBonus, SaveGame.Player.BaseCharacterClass.DeviceBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 38, SaveGame.Player.BaseCharacterClass.BaseSaveBonus + race.BaseSaveBonus, SaveGame.Player.BaseCharacterClass.SaveBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 39, (SaveGame.Player.BaseCharacterClass.BaseStealthBonus * 4) + (race.BaseStealthBonus * 4), SaveGame.Player.BaseCharacterClass.StealthBonusPerLevel * 4);
        SaveGame.DisplayAPlusB(67, 40, SaveGame.Player.BaseCharacterClass.BaseMeleeAttackBonus + race.BaseMeleeAttackBonus, SaveGame.Player.BaseCharacterClass.MeleeAttackBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 41, SaveGame.Player.BaseCharacterClass.BaseRangedAttackBonus + race.BaseRangedAttackBonus, SaveGame.Player.BaseCharacterClass.RangedAttackBonusPerLevel);
        SaveGame.Screen.Print(Colour.Black, race.ExperienceFactor + SaveGame.Player.BaseCharacterClass.ExperienceFactor + "%", 36, 45);
        SaveGame.Screen.Print(Colour.Black, "1d" + (race.HitDieBonus + SaveGame.Player.BaseCharacterClass.HitDieBonus), 37, 45);
        if (race.Infravision == 0)
        {
            SaveGame.Screen.Print(Colour.Black, "nil", 38, 45);
        }
        else
        {
            SaveGame.Screen.Print(Colour.Green, race.Infravision + "0 feet", 38, 45);
        }
        SaveGame.Screen.Print(Colour.Black, $"{race.BaseSearchBonus + SaveGame.Player.BaseCharacterClass.BaseSearchBonus:00}%", 39, 45);
        SaveGame.Screen.Print(Colour.Black, $"{race.BaseSearchFrequency + SaveGame.Player.BaseCharacterClass.BaseSearchFrequency:00}%", 40, 45);

        // Retrieve the description for the race and split the description into lines.
        string[] description = race.Description.Split("\n");

        // Render the description, center justified into row 32.
        int descriptionRow = 32 - (int)Math.Floor((double)description.Length / 2);
        foreach (string descriptionLine in description)
        {
            SaveGame.Screen.Print(Colour.Purple, descriptionLine, descriptionRow++, 21);
        }
        return true;
    }
    private BaseBirthStage? GoForward(int index)
    {
        Race[] races = SaveGame.SingletonRepository.Races
            .OrderBy((Race race) => race.Title)
            .ToArray();
        SaveGame.Player.Race = races[index];
        SaveGame.Player.GetFirstLevelMutation = SaveGame.Player.Race.AutomaticallyGainsFirstLevelMutationAtBirth;

        // Check to see how many realms the player can study.
        int availablePrimaryRealmCount = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms.Length;
        BaseRealm[] remainingAvailableSecondaryRealms = SaveGame.Player.BaseCharacterClass.RemainingAvailableSecondaryRealms();
        int remainingAvailableSecondaryRealmCount = remainingAvailableSecondaryRealms.Length;
        if (availablePrimaryRealmCount == 0)
        {
            // The player cannot study any realms.
            SaveGame.Player.PrimaryRealm = null;
            SaveGame.Player.SecondaryRealm = null;
            return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
        }
        else if (availablePrimaryRealmCount == 1)
        {
            // There is only one realm, auto select it.
            SaveGame.Player.PrimaryRealm = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms[0];

            // Check the secondary realm selection.
            if (remainingAvailableSecondaryRealmCount == 0)
            {
                SaveGame.Player.SecondaryRealm = null;
                return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
            }
            else if (remainingAvailableSecondaryRealmCount == 1)
            {
                // There is only one realm, auto select it.
                SaveGame.Player.SecondaryRealm = remainingAvailableSecondaryRealms[0];
                return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
            }
            else
            {
                return SaveGame.SingletonRepository.BirthStages.Get<Realm2SelectionBirthStage>();
            }
        }

        return SaveGame.SingletonRepository.BirthStages.Get<Realm1SelectionBirthStage>();
    }

    private BaseBirthStage? GoBack()
    {
        return SaveGame.SingletonRepository.BirthStages.Get<ClassSelectionBirthStage>();
    }
}