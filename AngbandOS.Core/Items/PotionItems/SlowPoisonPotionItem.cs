namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SlowPoisonPotionItem : PotionItem
    {
        public SlowPoisonPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionSlowPoison>()) { }
    }
}