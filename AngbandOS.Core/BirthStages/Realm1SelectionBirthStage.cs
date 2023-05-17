namespace AngbandOS.Core.BirthStages
{
    internal class Realm1SelectionBirthStage : BaseBirthStage
    {
        private Realm1SelectionBirthStage(SaveGame saveGame) : base(saveGame) { }
        public override string[] GetMenu()
        {
            return SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms
                .Select(_availablePrimaryRealms => _availablePrimaryRealms.Name)
                .ToArray();
        }

        public override void RenderSelection(int index)
        {
            BaseRealm realm = SaveGame.Player.BaseCharacterClass.AvailablePrimaryRealms[index];
            SaveGame.DisplayRealmInfo(realm);
        }
    }
}