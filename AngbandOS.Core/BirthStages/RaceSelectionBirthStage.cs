// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
        SaveGame.Screen.Print(ColourEnum.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
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
        SaveGame.Screen.Print(ColourEnum.Purple, "STR:", 36, 21);
        SaveGame.Screen.Print(ColourEnum.Purple, "INT:", 37, 21);
        SaveGame.Screen.Print(ColourEnum.Purple, "WIS:", 38, 21);
        SaveGame.Screen.Print(ColourEnum.Purple, "DEX:", 39, 21);
        SaveGame.Screen.Print(ColourEnum.Purple, "CON:", 40, 21);
        SaveGame.Screen.Print(ColourEnum.Purple, "CHA:", 41, 21);
        for (int i = 0; i < 6; i++)
        {
            int bonus = race.AbilityBonus[i] + SaveGame.BaseCharacterClass.AbilityBonus[i];
            SaveGame.DisplayStatBonus(26, 36 + i, bonus);
        }
        SaveGame.Screen.Print(ColourEnum.Purple, "Disarming   :", 36, 53);
        SaveGame.Screen.Print(ColourEnum.Purple, "Magic Device:", 37, 53);
        SaveGame.Screen.Print(ColourEnum.Purple, "Saving Throw:", 38, 53);
        SaveGame.Screen.Print(ColourEnum.Purple, "Stealth     :", 39, 53);
        SaveGame.Screen.Print(ColourEnum.Purple, "Fighting    :", 40, 53);
        SaveGame.Screen.Print(ColourEnum.Purple, "Shooting    :", 41, 53);
        SaveGame.Screen.Print(ColourEnum.Purple, "Experience  :", 36, 31);
        SaveGame.Screen.Print(ColourEnum.Purple, "Hit Dice    :", 37, 31);
        SaveGame.Screen.Print(ColourEnum.Purple, "Infravision :", 38, 31);
        SaveGame.Screen.Print(ColourEnum.Purple, "Searching   :", 39, 31);
        SaveGame.Screen.Print(ColourEnum.Purple, "Perception  :", 40, 31);
        SaveGame.DisplayAPlusB(67, 36, SaveGame.BaseCharacterClass.BaseDisarmBonus + race.BaseDisarmBonus, SaveGame.BaseCharacterClass.DisarmBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 37, SaveGame.BaseCharacterClass.BaseDeviceBonus + race.BaseDeviceBonus, SaveGame.BaseCharacterClass.DeviceBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 38, SaveGame.BaseCharacterClass.BaseSaveBonus + race.BaseSaveBonus, SaveGame.BaseCharacterClass.SaveBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 39, (SaveGame.BaseCharacterClass.BaseStealthBonus * 4) + (race.BaseStealthBonus * 4), SaveGame.BaseCharacterClass.StealthBonusPerLevel * 4);
        SaveGame.DisplayAPlusB(67, 40, SaveGame.BaseCharacterClass.BaseMeleeAttackBonus + race.BaseMeleeAttackBonus, SaveGame.BaseCharacterClass.MeleeAttackBonusPerLevel);
        SaveGame.DisplayAPlusB(67, 41, SaveGame.BaseCharacterClass.BaseRangedAttackBonus + race.BaseRangedAttackBonus, SaveGame.BaseCharacterClass.RangedAttackBonusPerLevel);
        SaveGame.Screen.Print(ColourEnum.Black, race.ExperienceFactor + SaveGame.BaseCharacterClass.ExperienceFactor + "%", 36, 45);
        SaveGame.Screen.Print(ColourEnum.Black, "1d" + (race.HitDieBonus + SaveGame.BaseCharacterClass.HitDieBonus), 37, 45);
        if (race.Infravision == 0)
        {
            SaveGame.Screen.Print(ColourEnum.Black, "nil", 38, 45);
        }
        else
        {
            SaveGame.Screen.Print(ColourEnum.Green, race.Infravision + "0 feet", 38, 45);
        }
        SaveGame.Screen.Print(ColourEnum.Black, $"{race.BaseSearchBonus + SaveGame.BaseCharacterClass.BaseSearchBonus:00}%", 39, 45);
        SaveGame.Screen.Print(ColourEnum.Black, $"{race.BaseSearchFrequency + SaveGame.BaseCharacterClass.BaseSearchFrequency:00}%", 40, 45);

        // Retrieve the description for the race and split the description into lines.
        string[] description = race.Description.Split("\n");

        // Render the description, center justified into row 32.
        int descriptionRow = 32 - (int)Math.Floor((double)description.Length / 2);
        foreach (string descriptionLine in description)
        {
            SaveGame.Screen.Print(ColourEnum.Purple, descriptionLine, descriptionRow++, 21);
        }
        return true;
    }
    private BaseBirthStage? GoForward(int index)
    {
        Race[] races = SaveGame.SingletonRepository.Races
            .OrderBy((Race race) => race.Title)
            .ToArray();
        SaveGame.Race = races[index];
        SaveGame.GetFirstLevelMutation = SaveGame.Race.AutomaticallyGainsFirstLevelMutationAtBirth;

        // Check to see how many realms the player can study.
        int availablePrimaryRealmCount = SaveGame.BaseCharacterClass.AvailablePrimaryRealms.Length;
        BaseRealm[] remainingAvailableSecondaryRealms = SaveGame.BaseCharacterClass.RemainingAvailableSecondaryRealms();
        int remainingAvailableSecondaryRealmCount = remainingAvailableSecondaryRealms.Length;
        if (availablePrimaryRealmCount == 0)
        {
            // The player cannot study any realms.
            SaveGame.PrimaryRealm = null;
            SaveGame.SecondaryRealm = null;
            return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
        }
        else if (availablePrimaryRealmCount == 1)
        {
            // There is only one realm, auto select it.
            SaveGame.PrimaryRealm = SaveGame.BaseCharacterClass.AvailablePrimaryRealms[0];

            // Check the secondary realm selection.
            if (remainingAvailableSecondaryRealmCount == 0)
            {
                SaveGame.SecondaryRealm = null;
                return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
            }
            else if (remainingAvailableSecondaryRealmCount == 1)
            {
                // There is only one realm, auto select it.
                SaveGame.SecondaryRealm = remainingAvailableSecondaryRealms[0];
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