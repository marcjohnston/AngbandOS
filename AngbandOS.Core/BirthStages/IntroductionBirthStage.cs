namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class IntroductionBirthStage : BaseBirthStage
    {
        private IntroductionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[]? GetMenu()
        {
            SaveGame.Player.Name = SaveGame._prevName;
            SaveGame.Player.Gender = SaveGame._prevSex;
            SaveGame.Player.Race = SaveGame._prevRace;
            SaveGame.Player.BaseCharacterClass = SaveGame._prevCharacterClass;
            SaveGame.Player.PrimaryRealm = SaveGame._prevPrimaryRealm;
            SaveGame.Player.SecondaryRealm = SaveGame._prevSecondaryRealm;

            DisplayPartialCharacter();
            List<string> menuItems = new List<string>();
            menuItems.Add("Choose");
            menuItems.Add("Random");
            menuItems.Add("Re-use");
            return menuItems.ToArray();
        }
        public override bool RenderSelection(int index)
        {
            switch (index)
            {
                case 0:
                    SaveGame.Screen.Print(Colour.Purple, "Choose your character's race, sex, and class; and select", 35, 20);
                    SaveGame.Screen.Print(Colour.Purple, "which realms of magic your character will use.", 36, 20);
                    break;

                case 1:
                    SaveGame.Screen.Print(Colour.Purple, "Let the game generate a character for you randomly.", 35, 20);
                    break;

                case 2:
                    SaveGame.Screen.Print(Colour.Purple, "Re-play with a character similar to the one you played", 35, 20);
                    SaveGame.Screen.Print(Colour.Purple, "last time.", 36, 20);
                    break;
            }
            return true;
        }

        public override int? GoForward(int index)
        {
            SaveGame.Player.Religion.Deity = GodName.None;
            if (index == 1) // Random
            {
                SaveGame.Player.BaseCharacterClass = SaveGame.SingletonRepository.CharacterClasses.ToWeightedRandom().Choose();
                do
                {
                    int raceIndex = Program.Rng.RandomLessThan(SaveGame.SingletonRepository.Races.Count);
                    SaveGame.Player.Race = SaveGame.SingletonRepository.Races[raceIndex];
                    SaveGame.Player.GetFirstLevelMutation = SaveGame.Player.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
                }
                while ((SaveGame.Player.Race.Choice & (1L << SaveGame.Player.BaseCharacterClass.ID)) == 0);

                // Use a weighted random to choose a the realms.
                SaveGame.Player.PrimaryRealm = new WeightedRandom<BaseRealm>(SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms).Choose();

                // We need to get the available secondary realms.  Note that we need to exclude the primary realm.
                SaveGame.Player.SecondaryRealm = new WeightedRandom<BaseRealm>(SaveGame.Player.BaseCharacterClass.RemainingAvailableSecondaryRealms()).Choose();
                if (SaveGame.Player.BaseCharacterClass.WorshipsADeity)
                {
                    SaveGame.Player.Religion.Deity = SaveGame.Player.BaseCharacterClass.DefaultDeity(SaveGame.Player.SecondaryRealm);
                }

                Gender[] availableRandomGenders = SaveGame.SingletonRepository.Genders.Where(_gender => _gender.CanBeRandomlySelected).ToArray();
                int genderIndex = Program.Rng.RandomBetween(0, availableRandomGenders.Length - 1);
                SaveGame.Player.Gender = availableRandomGenders[genderIndex];
                SaveGame.Player.Name = SaveGame.Player.Race.CreateRandomName();
                SaveGame.Player.Generation = 1;
                return BirthStage.Confirmation;
            }
            else if (index == 2) // Previous
            {
                SaveGame.Player.BaseCharacterClass = SaveGame._prevCharacterClass;
                SaveGame.Player.Race = SaveGame._prevRace;
                SaveGame.Player.GetFirstLevelMutation = SaveGame.Player.Race.AutomaticallyGainsFirstLevelMutationAtBirth;
                SaveGame.Player.PrimaryRealm = SaveGame._prevPrimaryRealm;
                SaveGame.Player.SecondaryRealm = SaveGame._prevSecondaryRealm;
                SaveGame.Player.Religion.Deity = SaveGame.Player.BaseCharacterClass.DefaultDeity(SaveGame.Player.SecondaryRealm);
                SaveGame.Player.Gender = SaveGame._prevSex;
                SaveGame.Player.Name = SaveGame._prevName;
                SaveGame.Player.Generation = SaveGame._prevGeneration + 1;
                return BirthStage.Confirmation;
            }
            else
            {
                SaveGame.Player.Name = "";
                SaveGame.Player.Generation = 1;
                SaveGame.Player.Gender = null; // Wait until the player has selected the gender.
                SaveGame.Player.BaseCharacterClass = null; // Wait until the player has selected the character class.
                SaveGame.Player.Race = null; // Wait until the player has selected the race.
                SaveGame.Player.PrimaryRealm = null; // Wait until the player has selected a primary realm.
                SaveGame.Player.SecondaryRealm = null; // Wait until the player has selected secondary realm.
            }
            return BirthStage.ClassSelection;
        }

        public override int? GoBack()
        {
            return null;
        }
    }
}