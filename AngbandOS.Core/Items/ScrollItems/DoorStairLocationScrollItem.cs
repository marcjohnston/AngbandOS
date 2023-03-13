namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DoorStairLocationScrollItem : ScrollItem
    {
        public DoorStairLocationScrollItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<ScrollDoorStairLocation>()) { }
    }
}