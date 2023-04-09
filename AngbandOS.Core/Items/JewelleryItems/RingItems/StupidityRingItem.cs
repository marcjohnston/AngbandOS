namespace AngbandOS.Core.Items
{
[Serializable]
    internal class StupidityRingItem : RingItem
    {
        public StupidityRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RingStupidity>()) { }
    }
}