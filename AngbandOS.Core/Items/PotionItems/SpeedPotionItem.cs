namespace AngbandOS.Core.Items
{
[Serializable]
    internal class SpeedPotionItem : PotionItem
    {
        public SpeedPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionSpeed>()) { }
    }
}