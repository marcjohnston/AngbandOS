namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NaivetyPotionItem : PotionItem
    {
        public NaivetyPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionNaivety>()) { }
    }
}