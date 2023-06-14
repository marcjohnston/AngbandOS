namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class GenderSelectionBirthStage : BaseBirthStage
    {
        private GenderSelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[]? GetMenu()
        {
            SaveGame.DisplayPartialCharacter(BirthStage.GenderSelection);
            return SaveGame.SingletonRepository.Genders
                .Select(_gender => _gender.Title)
                .ToArray();
        }

        public override bool RenderSelection(int index)
        {
            SaveGame.Screen.Print(Colour.Purple, "Your sex has no effect on gameplay.", 35, 21);
            return true;
        }
        public override int? GoForward(int index)
        {
            SaveGame.Player.Gender = SaveGame.SingletonRepository.Genders[index];
            return BirthStage.Confirmation;
        }

        public override int? GoBack()
        {
            int availablePrimaryRealmCount = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms.Length;
            int remainingAvailableSecondaryRealmCount = SaveGame.Player.BaseCharacterClass.RemainingAvailableSecondaryRealms().Length;
            if (remainingAvailableSecondaryRealmCount <= 1 && availablePrimaryRealmCount <= 1)
            {
                return BirthStage.RaceSelection;
            }
            else if (remainingAvailableSecondaryRealmCount <= 1)
            {
                return BirthStage.RealmSelection1;
            }
            return BirthStage.RealmSelection2;
        }
    }
}