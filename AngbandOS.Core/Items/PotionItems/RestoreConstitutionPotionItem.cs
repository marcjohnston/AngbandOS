namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreConstitutionPotionItem : PotionItem
    {
        public RestoreConstitutionPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionRestoreConstitution>()) { }
    }
}