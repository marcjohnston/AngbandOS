namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StrengthPotionItem : PotionItem
    {
        public StrengthPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionStrength>()) { }
    }
}