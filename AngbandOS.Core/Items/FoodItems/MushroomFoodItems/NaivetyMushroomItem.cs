namespace AngbandOS.Core.Items
{
[Serializable]
    internal class NaivetyMushroomItem : MushroomItem
    {
        public NaivetyMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomNaivety>()) { }
    }
}