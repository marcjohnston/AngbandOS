namespace AngbandOS.Core.Items
{
[Serializable]
    internal class AppleJuicePotionItem : PotionItem
    {
        public AppleJuicePotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionAppleJuice>()) { }
    }
}