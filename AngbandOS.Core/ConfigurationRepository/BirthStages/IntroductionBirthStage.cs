// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.BirthStages;

[Serializable]
internal class IntroductionBirthStage : BirthStage
{
    private int currentSelection = 0;
    private IntroductionBirthStage(SaveGame saveGame) : base(saveGame) { }

    public override BirthStage? Render()
    {
        string[]? menuItems = GetMenu();
        SaveGame.Screen.Print(ColorEnum.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
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
                    return null;
                case 'h':
                    SaveGame.ShowManual();
                    break;
            }
        }
        return null;
    }

    private string[]? GetMenu()
    {
        SaveGame.Name = SaveGame._prevName;
        SaveGame.Gender = SaveGame._prevSex;
        SaveGame.Race = SaveGame._prevRace;
        SaveGame.BaseCharacterClass = SaveGame._prevCharacterClass;
        SaveGame.PrimaryRealm = SaveGame._prevPrimaryRealm;
        SaveGame.SecondaryRealm = SaveGame._prevSecondaryRealm;

        DisplayPartialCharacter();
        List<string> menuItems = new List<string>();
        menuItems.Add("Choose");
        menuItems.Add("Random");
        menuItems.Add("Re-use");
        return menuItems.ToArray();
    }
    private bool RenderSelection(int index)
    {
        switch (index)
        {
            case 0:
                SaveGame.Screen.Print(ColorEnum.Purple, "Choose your character's race, sex, and class; and select", 35, 20);
                SaveGame.Screen.Print(ColorEnum.Purple, "which realms of magic your character will use.", 36, 20);
                break;

            case 1:
                SaveGame.Screen.Print(ColorEnum.Purple, "Let the game generate a character for you randomly.", 35, 20);
                break;

            case 2:
                SaveGame.Screen.Print(ColorEnum.Purple, "Re-play with a character similar to the one you played", 35, 20);
                SaveGame.Screen.Print(ColorEnum.Purple, "last time.", 36, 20);
                break;
        }
        return true;
    }

    private BirthStage GoForward(int index)
    {
        SaveGame.Religion.Deity = GodName.None;
        if (index == 1) // Random
        {
            SaveGame.BaseCharacterClass = SaveGame.SingletonRepository.CharacterClasses.ToWeightedRandom().Choose();
            do
            {
                int raceIndex = SaveGame.Rng.RandomLessThan(SaveGame.SingletonRepository.Races.Count);
                SaveGame.Race = SaveGame.SingletonRepository.Races[raceIndex];
                SaveGame.GetFirstLevelMutation = SaveGame.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
            }
            while ((SaveGame.Race.Choice & (1L << SaveGame.BaseCharacterClass.ID)) == 0);

            // Use a weighted random to choose a the realms.
            SaveGame.PrimaryRealm = new WeightedRandom<Realm>(SaveGame, SaveGame.BaseCharacterClass.AvailablePrimaryRealms).Choose();

            // We need to get the available secondary realms.  Note that we need to exclude the primary realm.
            SaveGame.SecondaryRealm = new WeightedRandom<Realm>(SaveGame, SaveGame.BaseCharacterClass.RemainingAvailableSecondaryRealms()).Choose();
            if (SaveGame.BaseCharacterClass.WorshipsADeity)
            {
                SaveGame.Religion.Deity = SaveGame.BaseCharacterClass.DefaultDeity(SaveGame.SecondaryRealm);
            }

            Gender[] availableRandomGenders = SaveGame.SingletonRepository.Genders.Where(_gender => _gender.CanBeRandomlySelected).ToArray();
            int genderIndex = SaveGame.Rng.RandomBetween(0, availableRandomGenders.Length - 1);
            SaveGame.Gender = availableRandomGenders[genderIndex];
            SaveGame.Name = SaveGame.Race.CreateRandomName();
            SaveGame.Generation = 1;
            return SaveGame.SingletonRepository.BirthStages.Get(nameof(ConfirmationBirthStage));
        }
        else if (index == 2) // Previous
        {
            SaveGame.BaseCharacterClass = SaveGame._prevCharacterClass;
            SaveGame.Race = SaveGame._prevRace;
            SaveGame.GetFirstLevelMutation = SaveGame.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
            SaveGame.PrimaryRealm = SaveGame._prevPrimaryRealm;
            SaveGame.SecondaryRealm = SaveGame._prevSecondaryRealm;
            SaveGame.Religion.Deity = SaveGame.BaseCharacterClass.DefaultDeity(SaveGame.SecondaryRealm);
            SaveGame.Gender = SaveGame._prevSex;
            SaveGame.Name = SaveGame._prevName;
            SaveGame.Generation = SaveGame._prevGeneration + 1;
            return SaveGame.SingletonRepository.BirthStages.Get(nameof(ConfirmationBirthStage));
        }
        else
        {
            SaveGame.Name = "";
            SaveGame.Generation = 1;
            SaveGame.Gender = null; // Wait until the player has selected the gender.
            SaveGame.BaseCharacterClass = null; // Wait until the player has selected the character class.
            SaveGame.Race = null; // Wait until the player has selected the race.
            SaveGame.PrimaryRealm = null; // Wait until the player has selected a primary realm.
            SaveGame.SecondaryRealm = null; // Wait until the player has selected secondary realm.
        }
        return SaveGame.SingletonRepository.BirthStages.Get(nameof(ClassSelectionBirthStage));
    }
}