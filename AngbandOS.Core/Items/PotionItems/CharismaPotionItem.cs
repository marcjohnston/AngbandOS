namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CharismaPotionItem : PotionItem
    {
        public CharismaPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionCharisma>()) { }
    }
}