namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreIntelligencePotionItem : PotionItem
    {
        public RestoreIntelligencePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionRestoreIntelligence>()) { }
    }
}