namespace AngbandOS.Core.Items
{
[Serializable]
    internal class DoorStairLocationStaffItem : StaffItem
    {
        public DoorStairLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffDoorStairLocation>()) { }
    }
}