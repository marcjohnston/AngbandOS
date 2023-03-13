namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StupidityMushroomItem : MushroomItem
    {
        public StupidityMushroomItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<MushroomStupidity>()) { }
    }
}