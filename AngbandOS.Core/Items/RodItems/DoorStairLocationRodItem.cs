namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DoorStairLocationRodItem : RodItem
    {
        public DoorStairLocationRodItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<RodDoorStairLocation>()) { }
    }
}