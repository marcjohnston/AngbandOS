namespace AngbandOS.Core.Items
{
[Serializable]
    internal class UglinessPotionItem : PotionItem
    {
        public UglinessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionUgliness>()) { }
    }
}