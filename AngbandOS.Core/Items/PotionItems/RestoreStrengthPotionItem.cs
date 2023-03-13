namespace AngbandOS.Core.Items
{
[Serializable]
    internal class RestoreStrengthPotionItem : PotionItem
    {
        public RestoreStrengthPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionRestoreStrength>()) { }
    }
}