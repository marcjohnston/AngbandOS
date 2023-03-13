namespace AngbandOS.Core.Items
{
[Serializable]
    internal class PoisonPotionItem : PotionItem
    {
        public PoisonPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionPoison>()) { }
    }
}