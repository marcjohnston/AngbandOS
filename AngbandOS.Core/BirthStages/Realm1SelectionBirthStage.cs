namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class Realm1SelectionBirthStage : BaseBirthStage
    {
        private Realm1SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[]? GetMenu()
        {
            DisplayPartialCharacter();
            return SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms
                .Select(_availablePrimaryRealms => _availablePrimaryRealms.Name)
                .ToArray();
        }

        public override bool RenderSelection(int index)
        {
            BaseRealm realm = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms[index];
            SaveGame.DisplayRealmInfo(realm);
            return true;
        }
        public override int? GoForward(int index)
        {
            BaseRealm realm = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms[index];
            SaveGame.Player.PrimaryRealm = realm;
            BaseRealm[] remainingAvailableSecondaryRealms = SaveGame.Player.BaseCharacterClass.RemainingAvailableSecondaryRealms();
            int remainingAvailableSecondaryRealmCount = remainingAvailableSecondaryRealms.Length;
            if (remainingAvailableSecondaryRealmCount == 0)
            {
                SaveGame.Player.SecondaryRealm = null;
                return BirthStage.GenderSelection;
            }
            else if (remainingAvailableSecondaryRealmCount == 1)
            {
                SaveGame.Player.SecondaryRealm = remainingAvailableSecondaryRealms[0];
                return BirthStage.GenderSelection;
            }
            return BirthStage.RealmSelection2;
        }

        public override int? GoBack()
        {
            return BirthStage.RaceSelection;
        }
    }
}