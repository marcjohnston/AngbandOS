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
    private IntroductionBirthStage(Game game) : base(game) { }

    public override BirthStage? Render()
    {
        string[]? menuItems = GetMenu();
        Game.Screen.Print(ColorEnum.Orange, "[Use up and down to select an option, right to confirm, or left to go back.]", 43, 1);
        while (!Game.Shutdown)
        {
            Game.MenuDisplay(currentSelection, menuItems);
            RenderSelection(currentSelection);
            char c = Game.Inkey();
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
                    Game.ShowManual();
                    break;
            }
        }
        return null;
    }

    private string[]? GetMenu()
    {
        Game.PlayerName.StringValue = Game._prevName;
        Game.Gender = Game._prevSex;
        Game.Race = Game._prevRace;
        Game.BaseCharacterClass = Game._prevCharacterClass;
        Game.PrimaryRealm = Game._prevPrimaryRealm;
        Game.SecondaryRealm = Game._prevSecondaryRealm;

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
                Game.Screen.Print(ColorEnum.Purple, "Choose your character's race, sex, and class; and select", 35, 20);
                Game.Screen.Print(ColorEnum.Purple, "which realms of magic your character will use.", 36, 20);
                break;

            case 1:
                Game.Screen.Print(ColorEnum.Purple, "Let the game generate a character for you randomly.", 35, 20);
                break;

            case 2:
                Game.Screen.Print(ColorEnum.Purple, "Re-play with a character similar to the one you played", 35, 20);
                Game.Screen.Print(ColorEnum.Purple, "last time.", 36, 20);
                break;
        }
        return true;
    }

    private BirthStage GoForward(int index)
    {
        Game.God = null;
        if (index == 1) // Random
        {
            Game.BaseCharacterClass = Game.SingletonRepository.ToWeightedRandom<BaseCharacterClass>().ChooseOrDefault();
            do
            {
                int raceIndex = Game.RandomLessThan(Game.SingletonRepository.Races.Count);
                Game.Race = Game.SingletonRepository.Races[raceIndex];
                Game.GetFirstLevelMutation = Game.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
            }
            while ((Game.Race.Choice & (1L << Game.BaseCharacterClass.ID)) == 0);

            // Use a weighted random to choose a the realms.
            Game.PrimaryRealm = new WeightedRandom<Realm>(Game, Game.BaseCharacterClass.AvailablePrimaryRealms).ChooseOrDefault();

            // We need to get the available secondary realms.  Note that we need to exclude the primary realm.
            Game.SecondaryRealm = new WeightedRandom<Realm>(Game, Game.BaseCharacterClass.RemainingAvailableSecondaryRealms()).ChooseOrDefault();
            if (Game.BaseCharacterClass.WorshipsADeity)
            {
                Game.God = Game.BaseCharacterClass.DefaultDeity(Game.SecondaryRealm);
            }

            Gender[] availableRandomGenders = Game.SingletonRepository.Genders.Where(_gender => _gender.CanBeRandomlySelected).ToArray();
            int genderIndex = Game.RandomBetween(0, availableRandomGenders.Length - 1);
            Game.Gender = availableRandomGenders[genderIndex];
            Game.PlayerName.StringValue = Game.Race.CreateRandomName();
            Game.Generation = 1;
            return Game.SingletonRepository.Get<BirthStage>(nameof(ConfirmationBirthStage));
        }
        else if (index == 2) // Previous
        {
            Game.BaseCharacterClass = Game._prevCharacterClass;
            Game.Race = Game._prevRace;
            Game.GetFirstLevelMutation = Game.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
            Game.PrimaryRealm = Game._prevPrimaryRealm;
            Game.SecondaryRealm = Game._prevSecondaryRealm;
            Game.God = Game.BaseCharacterClass.DefaultDeity(Game.SecondaryRealm);
            Game.Gender = Game._prevSex;
            Game.PlayerName.StringValue = Game._prevName;
            Game.Generation = Game._prevGeneration + 1;
            return Game.SingletonRepository.Get<BirthStage>(nameof(ConfirmationBirthStage));
        }
        else
        {
            Game.PlayerName.StringValue = "";
            Game.Generation = 1;
            Game.Gender = null; // Wait until the player has selected the gender.
            Game.BaseCharacterClass = null; // Wait until the player has selected the character class.
            Game.Race = null; // Wait until the player has selected the race.
            Game.PrimaryRealm = null; // Wait until the player has selected a primary realm.
            Game.SecondaryRealm = null; // Wait until the player has selected secondary realm.
        }
        return Game.SingletonRepository.Get<BirthStage>(nameof(ClassSelectionBirthStage));
    }
}