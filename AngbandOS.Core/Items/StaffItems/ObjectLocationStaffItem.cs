namespace AngbandOS.Core.Items
{
[Serializable]
    internal class ObjectLocationStaffItem : StaffItem
    {
        public ObjectLocationStaffItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemCategories.Get<StaffObjectLocation>()) { }
    }
}