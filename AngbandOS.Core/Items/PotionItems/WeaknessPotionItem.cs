namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WeaknessPotionItem : PotionItem
    {
        public WeaknessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<WeaknessPotionItemFactory>()) { }
    }
}