namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ClumsinessPotionItem : PotionItem
    {
        public ClumsinessPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionClumsiness>()) { }
    }
}