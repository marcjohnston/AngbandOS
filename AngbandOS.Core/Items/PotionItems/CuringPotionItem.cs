namespace AngbandOS.Core.Items
{
[Serializable]
    internal class CuringPotionItem : PotionItem
    {
        public CuringPotionItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<PotionCuring>()) { }
    }
}