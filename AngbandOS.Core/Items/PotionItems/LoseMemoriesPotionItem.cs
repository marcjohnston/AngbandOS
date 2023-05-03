namespace AngbandOS.Core.Items
{
[Serializable]
    internal class LoseMemoriesPotionItem : PotionItem
    {
        public LoseMemoriesPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LoseMemoriesPotionItemFactory>()) { }
    }
}