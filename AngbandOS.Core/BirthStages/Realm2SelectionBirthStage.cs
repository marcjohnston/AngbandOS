namespace AngbandOS.Core.BirthStages
{
    [Serializable]
    internal class Realm2SelectionBirthStage : BaseBirthStage
    {
        private Realm2SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[]? GetMenu()
        {
            return SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms
                .Where(_realm => _realm != SaveGame.Player.PrimaryRealm)
                .Select(_realm => _realm.Name)
                .ToArray();
        }

        public override bool RenderSelection(int index)
        {
            BaseRealm[] remainingRealms = SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.Player.PrimaryRealm).ToArray();
            BaseRealm realm = remainingRealms[index];
            SaveGame.DisplayRealmInfo(realm);
            return true;
        }
        public override int? GoForward(int index)
        {
            BaseRealm[] remainingRealms = SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms.Where(_realm => _realm != SaveGame.Player.PrimaryRealm).ToArray();
            SaveGame.Player.SecondaryRealm = remainingRealms[index];
            SaveGame.Player.Religion.Deity = SaveGame.Player.BaseCharacterClass.DefaultDeity(SaveGame.Player.SecondaryRealm);
            return BirthStage.GenderSelection;
        }

        public override int? GoBack()
        {
            int availablePrimaryRealmCount = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms.Length;
            if (availablePrimaryRealmCount <= 1)
            {
                return BirthStage.RaceSelection;
            }
            return BirthStage.RealmSelection1;
        }
    }
}