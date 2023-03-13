namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DexterityPotionItem : PotionItem
    {
        public DexterityPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionDexterity>()) { }
    }
}