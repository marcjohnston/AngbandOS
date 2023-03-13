namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpecialHealingPotionItem : PotionItem
    {
        public SpecialHealingPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionSpecialHealing>()) { }
    }
}