namespace AngbandOS.Core.BirthStages
{
    internal class Realm2SelectionBirthStage : BaseBirthStage
    {
        private Realm2SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            return SaveGame.Player.BaseCharacterClass.AvailableSecondaryRealms
                .Where(_realm => _realm != SaveGame.Player.PrimaryRealm)
                .Select(_realm => _realm.Name)
                .ToArray();
        }
    }
}