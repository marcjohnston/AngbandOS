namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SaltWaterPotionItem : PotionItem
    {
        public SaltWaterPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionSaltWater>()) { }
    }
}