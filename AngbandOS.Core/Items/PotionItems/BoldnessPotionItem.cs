namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BoldnessPotionItem : PotionItem
    {
        public BoldnessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionBoldness>()) { }
    }
}