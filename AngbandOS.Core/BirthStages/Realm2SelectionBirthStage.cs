namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class Realm2SelectionBirthStage : BaseBirthStage
    {
        private int currentSelection = 0;
        private Realm2SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override BaseBirthStage? Render()
        {
            DisplayPartialCharacter();
            string[]? menuItems = SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms
                .Where(_realm => _realm != SaveGame.Player.PrimaryRealm)
                .Select(_realm => _realm.Name)
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
            BaseRealm[] remainingRealms = SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.Player.PrimaryRealm).ToArray();
            BaseRealm realm = remainingRealms[index];
            SaveGame.DisplayRealmInfo(realm);
            return true;
        }
        private BaseBirthStage? GoForward(int index)
        {
            BaseRealm[] remainingRealms = SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.Player.PrimaryRealm).ToArray();
            SaveGame.Player.SecondaryRealm = remainingRealms[index];
            SaveGame.Player.Religion.Deity = SaveGame.Player.BaseCharacterClass.DefaultDeity(SaveGame.Player.SecondaryRealm);
            return SaveGame.SingletonRepository.BirthStages.Get<GenderSelectionBirthStage>();
        }

        private BaseBirthStage? GoBack()
        {
            int availablePrimaryRealmCount = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms.Length;
            if (availablePrimaryRealmCount <= 1)
            {
                return SaveGame.SingletonRepository.BirthStages.Get<RaceSelectionBirthStage>();
            }
            return SaveGame.SingletonRepository.BirthStages.Get<Realm1SelectionBirthStage>();
        }
    }
}