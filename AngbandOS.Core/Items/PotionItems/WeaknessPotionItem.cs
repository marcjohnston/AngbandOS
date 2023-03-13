namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WeaknessPotionItem : PotionItem
    {
        public WeaknessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionWeakness>()) { }
    }
}