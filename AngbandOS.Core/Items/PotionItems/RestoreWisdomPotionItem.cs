namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreWisdomPotionItem : PotionItem
    {
        public RestoreWisdomPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionRestoreWisdom>()) { }
    }
}