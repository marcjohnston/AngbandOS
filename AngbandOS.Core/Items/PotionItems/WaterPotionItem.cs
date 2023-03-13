namespace AngbandOS.Core.Items
{
[Serializable]
    internal class WaterPotionItem : PotionItem
    {
        public WaterPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionWater>()) { }
    }
}