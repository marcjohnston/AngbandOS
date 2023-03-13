namespace AngbandOS.Core.Items
{
[Serializable]
    internal class HealingPotionItem : PotionItem
    {
        public HealingPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionHealing>()) { }
    }
}