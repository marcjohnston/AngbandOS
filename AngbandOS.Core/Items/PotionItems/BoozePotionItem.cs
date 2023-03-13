namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BoozePotionItem : PotionItem
    {
        public BoozePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionBooze>()) { }
    }
}