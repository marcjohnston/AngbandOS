namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreLifeLevelsPotionItem : PotionItem
    {
        public RestoreLifeLevelsPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionRestoreLifeLevels>()) { }
    }
}