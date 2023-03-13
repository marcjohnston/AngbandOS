namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreDexterityPotionItem : PotionItem
    {
        public RestoreDexterityPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionRestoreDexterity>()) { }
    }
}