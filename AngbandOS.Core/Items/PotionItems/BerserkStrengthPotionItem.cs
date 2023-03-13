namespace AngbandOS.Core.Items
{
[Serializable]
    internal class BerserkStrengthPotionItem : PotionItem
    {
        public BerserkStrengthPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionBerserkStrength>()) { }
    }
}